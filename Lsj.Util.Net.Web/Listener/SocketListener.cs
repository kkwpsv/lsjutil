using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Exceptions;
using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Lsj.Util.Net.Web.Listener
{
    /// <summary>
    /// HttpListener
    /// </summary>
    public class SocketListener : IListener
    {
        bool IsSSL = false;


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
        /// 端口
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
        /// 日志
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// 是否启动
        /// </summary>
        public bool IsStarted
        {
            get;
            private set;
        } = false;
        /// <summary>
        /// WebServer
        /// </summary>
        public WebServer Server
        {
            get;
            private set;
        }


        internal List<IContext> Contexts
        {
            get;
            private set;
        } = new List<IContext>();

        Timer disposingtimer;




        /// <summary>
        /// SocketReceived
        /// </summary>
        public event EventHandler<SocketAcceptedArgs> SocketAccepted;

        Socket socket;
        private string file;
        private string password;

        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public SocketListener() : this(false, "", "")
        {
        }
        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public SocketListener(bool IsSSL, string file, string password)
        {
            this.socket = new TcpSocket();
            this.IsSSL = IsSSL;
            this.file = file;
            this.password = password;
        }
        /// <summary>
        /// 启动
        /// </summary>
        public void Start(WebServer server)
        {
            if (IsStarted)
            {
                return;
            }
            try
            {
                this.Server = server;
                socket.Bind(IP, Port);
                socket.Listen();
                socket.BeginAccept(OnAccepted);

                //定期清理无用的对象
                this.disposingtimer = new Timer((state) =>
                {
                    try
                    {
                        Contexts.FindAll((x) => (x.Status == eContextStatus.Disposing)).ForEach((a) =>
                        {
                            a.Dispose();
                            Contexts.Remove(a);
                        });
                    }
                    catch
                    {
                    }
                }, null, 0, 1000 * 10);

                IsStarted = true;
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw new ListenerException("Start Error", e);
            }
        }
        /// <summary>
        /// 停止
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
                throw new ListenerException("Stop Error", e);
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
                IContext x;
                if (IsSSL)
                {
                    x = HttpsContext.Create(handle, Log, this.Server, file, password);
                }
                else
                {
                    x = HttpContext.Create(handle, Log, this.Server);
                }
                this.Contexts.Add(x);
                x.Start();
            }
            catch (Exception e)
            {
                Log.Error(e);
                //throw new ListenerException("Accept Error", e);
            }
        }
    }
}
