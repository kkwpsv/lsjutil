using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Listener;
using System.Collections.Generic;
using Lsj.Util.Net.Web.Event;
using System;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Modules;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebServer
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get;
            internal set;
        } = "LsjWebServer(1.0)";


        List<IListener> listeners = new List<IListener>();
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
        /// <summary>
        /// Websites
        /// </summary>
        public SafeDictionary<string,Website> Websites
        {
            get;
        } = new SafeDictionary<string, Website>();
        /// <summary>
        /// Modules
        /// </summary>
        public List<IModule> Modules
        {
            get;
        } = new List<IModule>();





        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            if (IsStarted)
                return;
            if (Websites.Keys.Count == 0)
            {
                Websites.Add("", new Website());
            }
            if (Modules.Count == 0)
            {
                Modules.Insert(0, new FileModule());
            }
            Modules.ForEach((x) =>
            {
                Process += x.Process;
            });
            IsStarted = true;
            foreach (var listener in listeners)
            {
                StartListener(listener);
            }
        }



        /// <summary>
        /// Add a Listener
        /// </summary>
        /// <param name="listener"></param>
        public void AddListener(IListener listener)
        {
            if (IsStarted)
            {
                StartListener(listener);
            }
            listeners.Add(listener);
        }
        /// <summary>
        /// RemoveListener
        /// </summary>
        /// <param name="listener"></param>
        public void RemoveListener(IListener listener)
        {
            if (!listeners.Contains(listener))
            {
                Log.Warn("Try to remove a listener which hasn't been added");
                return;
            }
            if (IsStarted)
            {
                StopListener(listener);
            }
            listeners.Remove(listener);
        }



        void StartListener(IListener listener)
        {
            listener.Log = this.Log;
            listener.Start(this);

        }
        void StopListener(IListener listener)
        {
            listener.Log = LogProvider.Default;
            listener.Stop();
        }

        /// <summary>
        /// RequestParsed
        /// </summary>
        public event EventHandler<RequestParsedEventArgs> RequestParsed;

        internal void OnParsed(HttpContext x)
        {
            if (this.RequestParsed != null)
            {
                var args = new RequestParsedEventArgs();
                args.Request = x.Request;
                this.RequestParsed(this, args);
            }
        }
        /// <summary>
        /// Process
        /// </summary>
        public event EventHandler<ProcessEventArgs> Process;

        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                var host = x.Request.Headers[eHttpHeader.Host];
                var server = Websites[host] ?? Websites[""];

                if (this.Process != null)
                {
                    var args = new ProcessEventArgs();
                    args.Request = x.Request;
                    args.ServerName = this.Name;
                    this.Process(server, args);
                    if (args.IsParsed)
                    {
                        return args.Response;
                    }
                }
                return ErrorMgr.Build(501, 0,Name);
            }
            catch(Exception e)
            {
                Log.Error(e);
                return ErrorMgr.Build(500, 0, Name);
            }
        }
    }
}
