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
    /// Tcp async client.
    /// </summary>
    public class TcpAsyncClient
    {
        Socket socket;
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncClient"/> class.
        /// </summary>
        public TcpAsyncClient() : this(IPAddress.Any, 0)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncClient"/> class.
        /// </summary>
        /// <param name="address">Address.</param>
        /// <param name="port">Port.</param>
        public TcpAsyncClient(IPAddress address, int port)
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
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Net.Sockets.TcpAsyncClient"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool IsStarted
        {
            get;
            private set;
        } = false;



        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketConnectedArgs> SocketConnected;
        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketReceivedArgs> SocketReceived;
        /// <summary>
        /// SocketSent
        /// </summary>
        public event EventHandler<SocketSentArgs> SocketSent;




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
                socket.BeginConnect(IP, Port, OnConnected);
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
        public void Stop()
        {
            if (!IsStarted)
                return;
            try
            {
                socket.Close();
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

        /// <summary>
        /// OnConnected.
        /// </summary>
        /// <param name="ar">Ar.</param>
        private void OnConnected(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
                if (SocketConnected != null)
                {
                    var args = new SocketConnectedArgs(socket);
                    SocketConnected(this, args);
                    if (args.IsReject)
                    {
                        Log.Warn("Socket was rejected" + ((args.socket.RemoteEndPoint is IPEndPoint) ? " from " + ((IPEndPoint)args.socket.RemoteEndPoint).ToString() : "") + " .");
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
        /// AfterOnConnected.
        /// </summary>
        /// <param name="obj">Object.</param>
        protected virtual void AfterOnConnected(StateObject obj)
        {

        }
        /// <summary>
        /// BeginReceive.
        /// </summary>
        /// <param name="obj">Object.</param>
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
            handle.EndReceive(ar);
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
            AfterOnReceived(obj);

        }
        /// <summary>
        /// AfterOnReceived
        /// </summary>
        /// <param name="obj"></param>
        protected virtual void AfterOnReceived(StateObject obj)
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
