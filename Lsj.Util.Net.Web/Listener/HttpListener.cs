using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
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
        }

        Socket socket;


        /// <summary>
        /// Initial a new instance
        /// </summary>
        public HttpListener()
        {
            this.socket = new TcpSocket();
        }
    }
}
