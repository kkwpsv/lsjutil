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
    /// SocketListener
    /// </summary>
    public class SocketListener :TcpAsyncListener, IListener
    {
        bool IsSSL = false;



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






        private string file;
        private string password;

        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public SocketListener(WebServer server) : this(false, "", "", server)
        {
        }
        /// <summary>
        /// Initialize a new instance
        /// </summary>
        public SocketListener(bool IsSSL, string file, string password, WebServer server) : base()
        {
            this.IsSSL = IsSSL;
            this.file = file;
            this.password = password;
            this.Server = server;
        }
        /// <summary>
        /// 启动
        /// </summary>
        public override void Start()
        {
            base.Start();
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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        protected override void AfterOnAccepted(StateObject obj)
        {
            IContext x;
            var handle = obj.handle;
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
    }
}
