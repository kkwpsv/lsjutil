using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

#if NETCOREAPP1_1
using Lsj.Util.Core.Logs;
using Lsj.Util.Core.Net.Sockets.Event;
#else
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;
#endif



#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Sockets
#else
namespace Lsj.Util.Net.Sockets
#endif
{
    /// <summary>
    /// Tcp Async listener.
    /// </summary>
    public class TcpAsyncListener
    {
        Socket socket;
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;




        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncListener"/> class.
        /// </summary>
        public TcpAsyncListener() : this(IPAddress.Any, 0)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncListener"/> class.
        /// </summary>
        /// <param name="address">Address.</param>
        /// <param name="port">Port.</param>
        public TcpAsyncListener(IPAddress address, int port)
        {
            this.socket = new TcpSocket();
            this.IP = address;
            this.Port = port;
        }

        /// <summary>
        /// Gets or sets the log.
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
        /// Gets or sets the port.
        /// </summary>
        /// <value>The port.</value>
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
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncListener"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool IsStarted
        {
            get;
            private set;
        } = false;
        /// <summary>
        /// SocketAccepted
        /// </summary>
        public event EventHandler<SocketAcceptedArgs> SocketAccepted;
        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketReceivedArgs> SocketReceived;
        /// <summary>
        /// SocketSent
        /// </summary>
        public event EventHandler<SocketSentArgs> SocketSent;



        /// <summary>
        /// Bind the specified address and port.
        /// </summary>
        /// <returns>The bind.</returns>
        /// <param name="address">Address.</param>
        /// <param name="port">Port.</param>
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
        /// Start this instance.
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
#if NETCOREAPP1_1
                Accept(null);
#else
                socket.BeginAccept(OnAccepted);
#endif
                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
#if NETCOREAPP1_1
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
#endif

        /// <summary>
        /// Stop this instance.
        /// </summary>
        public virtual void Stop()
        {
            if (!IsStarted)
                return;
            try
            {
#if NETCOREAPP1_1
                socket.Shutdown();
#else
                socket.Close();
#endif
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
#if NETCOREAPP1_1
        private void OnAccepted(Socket handle)
#else
        private void OnAccepted(IAsyncResult ar)
#endif
        {
            try
            {
#if NETCOREAPP1_1
#else
                var handle = socket.EndAccept(ar);
                socket.BeginAccept(OnAccepted);
#endif
                if (SocketAccepted != null)
                {
                    var args = new SocketAcceptedArgs(handle);
                    SocketAccepted(this, args);
                    if (args.IsReject)
                    {
                        Log.Warn("Socket was rejected" + ((args.socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.socket.RemoteEndPoint).ToString() : "") + " .");
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
        /// <param name="obj"></param>
        protected virtual void AfterOnAccepted(StateObject obj)
        {
        }
        /// <summary>
        /// BeginReceive
        /// </summary>
        /// <param name="obj"></param>
        protected void BeginReceive(StateObject obj)
        {
            var handle = obj.handle;
            var buffer = GetReadBuffer();
            obj.buffer = buffer;
#if NETCOREAPP1_1
            Receive(null, obj);
#else
            handle.BeginReceive(buffer, OnReceived, obj);
#endif
        }

#if NETCOREAPP1_1
        private void Receive(SocketAsyncEventArgs args, StateObject obj)
        {
            if (args == null)
            {
                args = new SocketAsyncEventArgs();
                args.Completed += this.Received_Completed;
            }
            args.UserToken = obj;
            args.SetBuffer(obj.buffer, 0, obj.buffer.Length);
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
#endif
#if NETCOREAPP1_1
        private void OnReceived(SocketAsyncEventArgs e)
#else
        private void OnReceived(IAsyncResult ar)
#endif
        {
#if NETCOREAPP1_1
            var obj = e.UserToken as StateObject;
#else
            var obj = ar.AsyncState as StateObject;
#endif
            var handle = obj.handle;
            var buffer = obj.buffer;
#if NETCOREAPP1_1
            var received = e.BytesTransferred;
#else
            var received = handle.EndReceive(ar);
#endif
            var newbuffer = GetReadBuffer();
#if NETCOREAPP1_1
            Receive(e, GetStateObject(handle, newbuffer));
#else
            handle.BeginReceive(newbuffer, OnReceived, GetStateObject(handle, newbuffer));
#endif
            if (SocketReceived != null)
            {
                var args = new SocketReceivedArgs(handle, buffer);
                SocketReceived(this, args);
                if (args.IsReject)
                {
                    Log.Warn("Socket was rejected" + ((args.socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.socket.RemoteEndPoint).ToString() : "") + " .");
                    return;
                }
            }
            AfterOnReceived(obj, received);

        }
        /// <summary>
        /// AfterOnReceived
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="received"></param>
        protected virtual void AfterOnReceived(StateObject obj, int received)
        {

        }
        /// <summary>
        /// BeginSend
        /// </summary>
        /// <param name="obj"></param>
        protected void BeginSend(StateObject obj)
        {
            var handle = obj.handle;
            var buffer = obj.buffer;
#if NETCOREAPP1_1
            Send(null, obj);
#else
            handle.BeginSend(buffer, OnSent, obj);
#endif
        }

#if NETCOREAPP1_1
        private void Send(SocketAsyncEventArgs args, StateObject obj)
        {
            if (args == null)
            {
                args = new SocketAsyncEventArgs();
                args.Completed += this.Send_Completed;
            }
            args.UserToken = obj;
            args.SetBuffer(obj.buffer, 0, obj.buffer.Length);
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
#endif

#if NETCOREAPP1_1
        private void OnSent(SocketAsyncEventArgs e)
#else
        private void OnSent(IAsyncResult ar)
#endif
        {
#if NETCOREAPP1_1
            var obj = e.UserToken as StateObject;
#else
            var obj = ar.AsyncState as StateObject;
#endif
            var handle = obj.handle;
            var buffer = obj.buffer;
#if NETCOREAPP1_1
#else
            handle.EndSend(ar);
#endif
            if (SocketSent != null)
            {
                var args = new SocketSentArgs(handle, buffer);
                SocketSent(this, args);
            }
            AfterSent(handle, buffer);
        }
        /// <summary>
        /// AfterSent
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="buffer"></param>
        protected virtual void AfterSent(Socket handle, byte[] buffer)
        {

        }

        /// <summary>
        /// GetReadBuffer
        /// </summary>
        /// <returns></returns>
        protected virtual byte[] GetReadBuffer()
        {
            return new byte[1024];
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
    }
}
