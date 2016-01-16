using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Logs;
using System.Net.Sockets;
using System.Collections.Specialized;
using System.Net;
using Lsj.Util.Net.Sockets;
using System.Threading;

namespace Lsj.Util.Net.Async
{
    /// <summary>
    /// TCPAsyncServer
    /// </summary>
    public class TcpAsyncServer : DisposableClass,IDisposable
    {
        private Log log;
        public static readonly int SEND_BUFF_SIZE = 16384;
        protected readonly HybridDictionary m_clients = new HybridDictionary();
        protected Socket _linstener;
        protected SocketAsyncEventArgs ac_event;


        public int ClientCount =>this.m_clients.Count;
        public TcpAsyncServer() : this(new Log(new LogConfig()))
        {
        }
        public TcpAsyncServer(Log log)
        {
            this.log = log;
            this.ac_event = new SocketAsyncEventArgs();
            this.ac_event.Completed += this.AcceptAsyncCompleted;
        }
        public virtual bool InitSocket(IPAddress ip, int port)
        {
            bool result;
            try
            {
                this._linstener = new TcpSocket();
                this._linstener.Bind(new IPEndPoint(ip, port));
            }
            catch (Exception e)
            {
                log.Error("InitSocket", e);
                result = false;
                return result;
            }
            result = true;
            return result;
        }
        public virtual bool Start()
        {
            bool result;
            if (this._linstener == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    this._linstener.Listen(100);
                    this.AcceptAsync();
                    log.Debug("Server is now listening to incoming connections!");
                }
                catch (Exception e)
                {
                    log.Error("Start", e);
                    if (this._linstener != null)
                    {
                        this._linstener.Close();
                    }
                    result = false;
                    return result;
                }
                result = true;
            }
            return result;
        }
        public virtual void Stop()
        {
            log.Debug("Stopping server! - Entering method");
            try
            {
                if (this._linstener != null)
                {
                    Socket socket = this._linstener;
                    this._linstener = null;
                    socket.Close();
                    log.Debug("Server is no longer listening for incoming connections!");
                }
            }
            catch (Exception e)
            {
                log.Error("Stop", e);
            }
            if (this.m_clients != null)
            {
                object syncRoot;
                Monitor.Enter(syncRoot = this.m_clients.SyncRoot);
                try
                {
                    TcpAsyncClient[] list = new TcpAsyncClient[this.m_clients.Keys.Count];
                    this.m_clients.Keys.CopyTo(list, 0);
                    for (int i = 0; i < list.Length; i++)
                    {
                        var client = list[i];
                        client.Disconnect();
                    }
                    log.Debug("Stopping server! - Cleaning up client list!");
                }
                catch (Exception e)
                {
                    log.Error("Stop", e);
                }
                finally
                {
                    Monitor.Exit(syncRoot);
                }
            }
            log.Debug("Stopping server! - End of method!");
        }
        public TcpAsyncClient[] GetAllClients()
        {
            object syncRoot;
            Monitor.Enter(syncRoot = this.m_clients.SyncRoot);
            TcpAsyncClient[] result;
            try
            {
                TcpAsyncClient[] temp = new TcpAsyncClient[this.m_clients.Count];
                this.m_clients.Keys.CopyTo(temp, 0);
                result = temp;
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
            return result;
        }




        protected virtual TcpAsyncClient GetNewClient() => new TcpAsyncClient(new byte[2048], new byte[2048],this);
        private void AcceptAsync()
        {
            try
            {
                if (this._linstener != null)
                {
                    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                    e.Completed += this.AcceptAsyncCompleted;
                    this._linstener.AcceptAsync(e);
                }
            }
            catch (Exception ex)
            {
                log.Error("AcceptAsync is error!", ex);
            }
        }
        private void AcceptAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            Socket sock = null;
            try
            {
                sock = e.AcceptSocket;
                sock.SendBufferSize = TcpAsyncServer.SEND_BUFF_SIZE;
                TcpAsyncClient client = this.GetNewClient();
                try
                {
                    log.Debug("Incoming connection from " + (sock.Connected ? sock.RemoteEndPoint.ToString() : "socket disconnected"));
                    
                    object syncRoot;
                    Monitor.Enter(syncRoot = this.m_clients.SyncRoot);
                    try
                    {
                        this.m_clients.Add(client, client);
                        client.Disconnected += this.client_Disconnected;
                    }
                    finally
                    {
                        Monitor.Exit(syncRoot);
                    }
                    client.Connect(sock);
                    client.ReceiveAsync();
                }
                catch (Exception ex)
                {
                    log.ErrorFormat("create client failed:{0}", ex);
                    client.Disconnect();
                }
            }
            catch
            {
                if (sock != null)
                {
                    try
                    {
                        sock.Close();
                    }
                    catch
                    {
                    }
                }
            }
            finally
            {
                e.Dispose();
                this.AcceptAsync();
            }
        }
        private void client_Disconnected(TcpAsyncClient client)
        {
            client.Disconnected -= this.client_Disconnected;
            this.RemoveClient(client);
        }
        private void RemoveClient(TcpAsyncClient client)
        {
            object syncRoot;
            Monitor.Enter(syncRoot = this.m_clients.SyncRoot);
            try
            {
                this.m_clients.Remove(client);
            }
            finally
            {
                Monitor.Exit(syncRoot);
            }
        }
        
        protected override void CleanUpManagedResources()
        {
            this.ac_event.Dispose();
        }
    }
}
