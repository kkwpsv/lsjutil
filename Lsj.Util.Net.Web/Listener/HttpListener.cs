using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Exceptions;
using System;
using System.Net;
using System.Net.Sockets;

namespace Lsj.Util.Net.Web.Listener
{
    /// <summary>
    /// HttpListener
    /// </summary>
    public class HttpListener
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
        public event EventHandler<SocketReceivedArgs> SocketReceved;

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
                Log = LogProvider.Default;
                SocketReceved = null;
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
                if (SocketReceved != null)
                    SocketReceved(this, new SocketReceivedArgs(handle));
            }
            catch(Exception e)
            {

            }
        }
    }
}
