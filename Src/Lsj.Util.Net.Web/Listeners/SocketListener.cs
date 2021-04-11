using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets;
using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Lsj.Util.Net.Web.Listeners
{
    /// <summary>
    /// SocketListener
    /// </summary>
    public class SocketListener : TcpAsyncListener, IListener
    {
        private bool _isSSL = false;
        private WebServer _server;
        private Timer _disposingtimer;
        private string _certFile;
        private string _certPassword;
        private LogProvider _log;

        /// <summary>
        /// WebServer
        /// </summary>
        public WebServer Server
        {
            get => _server;
            set
            {
                if (IsStarted)
                {
                    throw new InvalidOperationException("Cannot set server when started.");
                }
                _server = value;
            }
        }

        internal List<IContext> Contexts
        {
            get;
            private set;
        } = new List<IContext>();

        /// <inheritdoc/>
        public override LogProvider Log
        {
            get => _log ?? Server.Log;
            set => _log = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SocketListener"/> class.
        /// </summary>
        /// <param name="server"></param>
        public SocketListener(WebServer server = null) : this(false, null, null, server)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SocketListener"/> class.
        /// </summary>
        /// <param name="isSSL"></param>
        /// <param name="certFile"></param>
        /// <param name="certPassword"></param>
        /// <param name="server"></param>
        public SocketListener(bool isSSL, string certFile, string certPassword, WebServer server = null)
        {
            _isSSL = isSSL;
            Server = server;
            if (isSSL)
            {
                _certFile = certFile ?? throw new ArgumentNullException(nameof(certFile));
                _certPassword = certPassword ?? throw new ArgumentNullException(nameof(certPassword));
            }
        }

        /// <inheritdoc/>
        public override void Start()
        {
            base.Start();
            //定期清理无用的对象
            _disposingtimer = new Timer((state) =>
            {
                try
                {
                    Contexts.FindAll((x) => (x.Status == ContextStatus.Disposing)).ForEach((a) =>
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

        /// <inheritdoc/>
        public override void Stop()
        {
            if (_disposingtimer != null)
            {
                _disposingtimer.Dispose();
                _disposingtimer = null;
            }
            base.Stop();
        }

        /// <inheritdoc/>
        protected override void AfterOnAccepted(StateObject obj)
        {
            var context = _isSSL ? HttpsContext.Create(obj.handle, Log, Server, _certFile, _certPassword) : HttpContext.Create(obj.handle, Log, Server);
            Contexts.Add(context);
            context.Start();
        }
    }
}
