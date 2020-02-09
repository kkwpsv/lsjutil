using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;



namespace Lsj.Util.Net.Sockets
{
    /// <summary>
    /// TcpAsync Listener
    /// </summary>
    public class TcpAsyncListener : DisposableClass, IDisposable
    {
        Socket socket;
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;

        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Sockets.TcpAsyncListener"/> class.
        /// </summary>
        public TcpAsyncListener() : this(IPAddress.Any, 0)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Lsj.Util.Net.Sockets.TcpAsyncListener"/> class.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public TcpAsyncListener(IPAddress address, int port)
        {
            this.socket = new TcpSocket();
            this.IP = address;
            this.Port = port;
        }

        /// <summary>
        /// Log
        /// </summary>
        /// <value>The log.</value>
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
        /// SocketAccepted EventHandler
        /// </summary>
        public event EventHandler<SocketAcceptedArgs> SocketAccepted;
        /// <summary>
        /// SocketReceived EventHandler
        /// </summary>
        public event EventHandler<SocketReceivedArgs> SocketReceived;
        /// <summary>
        /// SocketSent EventHandler
        /// </summary>
        public event EventHandler<SocketSentArgs> SocketSent;



        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public virtual void Bind(IPAddress address, int port)
        {
            try
            {
                socket.Bind(address, port);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

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
                socket.Bind(IP, Port);
                socket.Listen();
                Accept(null);
                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private void Accept(SocketAsyncEventArgs args)
        {
            if (args == null)
            {
                args = new SocketAsyncEventArgs();
                args.Completed += this.Accepted_Completed;
            }
            else
            {
                args.AcceptSocket = null;
            }
            if (!socket.AcceptAsync(args))
            {
                OnAccepted(args.ConnectSocket);
            }
        }
        private void Accepted_Completed(object sender, SocketAsyncEventArgs args)
        {
            OnAccepted(args.AcceptSocket);
            Accept(args);
        }

        /// <summary>
        /// Stop
        /// </summary>
        public virtual void Stop()
        {
            if (!IsStarted)
                return;
            try
            {
                socket.Close();
                SocketAccepted = null;
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

        private void OnAccepted(Socket handle)
        {
            try
            {
                if (SocketAccepted != null)
                {
                    var args = new SocketAcceptedArgs(handle);
                    SocketAccepted(this, args);
                    if (args.IsReject)
                    {
                        Log.Warn("Socket was rejected" + ((args.Socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.Socket.RemoteEndPoint).ToString() : "") + " .");
                        return;
                    }
                }
                AfterOnAccepted(GetStateObject(handle, null));
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// AfterOnAccepted
        /// </summary>
        /// <param name="obj">StateObject</param>
        protected virtual void AfterOnAccepted(StateObject obj)
        {
        }
        /// <summary>
        /// Receive
        /// </summary>
        /// <param name="obj">StateObject</param>
        protected void Receive(StateObject obj)
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
        protected void Send(StateObject obj, byte[] tosend) => Send(obj, tosend, 0, tosend.Length);
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tosend"></param>
        /// <param name="offet"></param>
        /// <param name="count"></param>
        protected void Send(StateObject obj, byte[] tosend, int offet, int count)
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
