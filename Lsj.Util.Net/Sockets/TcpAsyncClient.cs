using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;




namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// Tcp async client.
    /// </summary>
    public class TcpAsyncClient : DisposableClass, IDisposable
    {
        Socket socket;
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;


        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Sockets.TcpAsyncClient"/> class.
        /// </summary>
        public TcpAsyncClient() : this(IPAddress.Any, 0)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Sockets.TcpAsyncClient"/> class.
        /// </summary>
        /// <param name="address">Address</param>
        /// <param name="port">Port</param>
        public TcpAsyncClient(IPAddress address, int port)
        {
            this.socket = new TcpSocket();
            this.IP = address;
            this.Port = port;
        }

        /// <summary>
        /// Log
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// IP
        /// </summary>
        public IPAddress IP
        {
            get
            {
                return m_ip;
            }
            set
            {
                if (IsStarted)
                {
                    throw new InvalidOperationException("Cannot set ip when listener is running");
                }
                m_ip = value;
            }
        }
        /// <summary>
        /// Port
        /// </summary>
        public int Port
        {
            get
            {
                return m_port;
            }
            set
            {
                if (IsStarted)
                {
                    throw new InvalidOperationException("Cannot set port when listener is running");
                }
                m_port = value;
            }
        }
        /// <summary>
        /// Is Started
        /// </summary>
        public bool IsStarted
        {
            get;
            private set;
        } = false;

        /// <summary>
        /// SocketConnected EventHandler
        /// </summary>
        public event EventHandler<SocketConnectedArgs> SocketConnected;
        /// <summary>
        /// SocketReceived EventHandler
        /// </summary>
        public event EventHandler<SocketReceivedArgs> SocketReceived;
        /// <summary>
        /// SocketSent EventHandler
        /// </summary>
        public event EventHandler<SocketSentArgs> SocketSent;


        /// <summary>
        /// Start
        /// </summary>
        public virtual void Start()
        {
            if (IsStarted)
            {
                return;
            }
            try
            {
                Connect();
                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            if (!IsStarted)
                return;
            try
            {
#if NETCOREAPP2_0
                socket.Shutdown();
#else
                socket.Close();
#endif
                SocketConnected = null;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            finally
            {
                IsStarted = false;
            }
        }

        private void Connect()
        {
            var args = new SocketAsyncEventArgs();
            args.Completed += this.Connect_Completed;
            args.RemoteEndPoint = new IPEndPoint(IP, Port);
            if (!socket.ConnectAsync(args))
            {
                OnConnected();
            }
        }
        private void Connect_Completed(object sender, SocketAsyncEventArgs args)
        {
            OnConnected();
        }

        private void OnConnected()
        {
            try
            {
                if (SocketConnected != null)
                {
                    var args = new SocketConnectedArgs(socket);
                    SocketConnected(this, args);
                    if (args.IsReject)
                    {
                        Log.Warn("Socket was rejected" + ((args.Socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.Socket.RemoteEndPoint).ToString() : "") + " .");
                        return;
                    }
                }
                AfterOnConnected(GetStateObject(socket, null));
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        /// AfterOnConnected
        /// </summary>
        /// <param name="obj">StateObject</param>
        protected virtual void AfterOnConnected(StateObject obj)
        {

        }
        /// <summary>
        /// Receive
        /// </summary>
        /// <param name="obj"></param>
        public void Receive(StateObject obj)
        {
            var args = new SocketAsyncEventArgs();
            args.Completed += this.Received_Completed;
            args.UserToken = obj;
            args.SetBuffer(obj.buffer, obj.offset, obj.buffer.Length - obj.offset);
            var handle = obj.handle;
            if (handle.ReceiveAsync(args))
            {
                OnReceived(args);
            }
        }
        private void Received_Completed(object sender, SocketAsyncEventArgs args)
        {
            OnReceived(args);
        }

        private void OnReceived(SocketAsyncEventArgs e)
        {
            var obj = e.UserToken as StateObject;
            var received = e.BytesTransferred;
            if (SocketReceived != null)
            {
                var args = new SocketReceivedArgs(e.ConnectSocket, e.Buffer, e.Offset, e.BytesTransferred);
                SocketReceived(this, args);
                if (args.IsReject)
                {
                    Log.Warn("Socket was rejected" + ((args.Socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.Socket.RemoteEndPoint).ToString() : "") + " .");
                    return;
                }
            }
            AfterOnReceived(obj, received);
        }
        /// <summary>
        /// AfterOnReceived
        /// </summary>
        /// <param name="obj">StateObject</param>
        /// <param name="received">Received byte count</param>
        protected virtual void AfterOnReceived(StateObject obj, int received)
        {

        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tosend"></param>
        /// <param name="offet"></param>
        /// <param name="count"></param>
        public void Send(StateObject obj, byte[] tosend, int offet, int count)
        {
            var args = new SocketAsyncEventArgs();
            args.Completed += this.Send_Completed;
            args.UserToken = obj;
            args.SetBuffer(tosend, offet, count);
            var handle = obj.handle;
            if (handle.SendAsync(args))
            {
                OnSent(args);
            }
        }
        private void Send_Completed(object sender, SocketAsyncEventArgs args)
        {
            OnSent(args);
        }
        private void OnSent(SocketAsyncEventArgs e)
        {
            var obj = e.UserToken as StateObject;
            if (SocketSent != null)
            {
                var args = new SocketSentArgs(e.ConnectSocket, e.Buffer, e.Offset, e.BytesTransferred);
                SocketSent(this, args);
            }
            AfterSent(obj, e.Buffer, e.Offset, e.BytesTransferred);
        }
        /// <summary>
        /// AfterSent
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        protected virtual void AfterSent(StateObject handle, byte[] buffer, int offset, int count)
        {

        }

        /// <summary>
        /// GetStateObject
        /// </summary>
        /// <returns></returns>
        protected virtual StateObject GetStateObject(Socket handle, byte[] buffer)
        {
            return new StateObject
            {
                buffer = buffer,
                handle = handle
            };
        }

        /// <summary>
        /// Clean Up Managed Resources
        /// </summary>
        protected override void CleanUpManagedResources()
        {
            this.socket.Dispose();
            base.CleanUpManagedResources();
        }
    }
}
