using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Exceptions;
using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Net;
using System.Net.Sockets;

namespace Lsj.Util.Net.Web.Listener
{
    /// <summary>
    /// HttpListener
    /// </summary>
    public class HttpListener : IListener
    {
        IPAddress m_ip = IPAddress.Any;
        int m_port = 80;
        /// <summary>
        /// /IP
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
        /// LogProvider
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// IsStarted
        /// </summary>
        public bool IsStarted
        {
            get;
            private set;
        } = false;
        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketAcceptedArgs> SocketAccepted;

        Socket socket;


        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public HttpListener()
        {
            this.socket = new TcpSocket();
        }
        /// <summary>
        /// Start
        /// </summary>
        public void Start()
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
                throw new ListenerException("Start Error", e);
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
                socket.Close();
                SocketAccepted = null;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ListenerException("Start Error", e);
            }
            finally
            {
                IsStarted = false;
            }
        }

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
                HttpContext.Create(handle, Log).Start();

            }
            catch(Exception e)
            {
                Log.Error(e);
                throw new ListenerException("Accept Error", e);
            }
        }
    }
}
