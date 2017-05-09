using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Sockets
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
                socket.BeginAccept(OnAccepted);
                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        /// <summary>
        /// Stop this instance.
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

        /// <summary>
        /// OnAccepted.
        /// </summary>
        /// <param name="ar">Ar.</param>
        private void OnAccepted(IAsyncResult ar)
        {
            try
            {
                var handle = socket.EndAccept(ar);
                socket.BeginAccept(OnAccepted);
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
            handle.BeginReceive(buffer, OnReceived, obj);
        }
        private void OnReceived(IAsyncResult ar)
        {

            var obj = ar.AsyncState as StateObject;
            var handle = obj.handle;
            var buffer = obj.buffer;
            var received = handle.EndReceive(ar);
            var newbuffer = GetReadBuffer();
            handle.BeginReceive(newbuffer, OnReceived, GetStateObject(handle, newbuffer));
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
            handle.BeginSend(buffer, OnSent, obj);
        }
        private void OnSent(IAsyncResult ar)
        {

            var obj = ar.AsyncState as StateObject;
            var handle = obj.handle;
            var buffer = obj.buffer;
            handle.EndSend(ar);
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
