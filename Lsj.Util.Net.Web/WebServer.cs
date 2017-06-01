using System.Collections.Generic;
using System;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Logs;
using Lsj.Util.Collections;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebServer
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            internal set;
        } = "LsjWebServer(1.0)";


        List<IListener> listeners = new List<IListener>();
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
        /// Gets a value indicating whether this <see cref="T:Lsj.Util.Net.Web.WebServer"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool IsStarted
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the websites.
        /// </summary>
        /// <value>The websites.</value>
        public SafeDictionary<string, Website> Websites
        {
            get;
        } = new SafeDictionary<string, Website>();






        /// <summary>
        /// Start this instance.
        /// </summary>
        public void Start()
        {
            if (IsStarted)
                return;
            if (Websites.Keys.Count == 0)
            {
                Websites.Add("", new Website(""));
            }
            foreach (var x in Websites)
            {
                x.Value.Start(this);
            }
            foreach (var listener in listeners)
            {
                StartListener(listener);
            }
            IsStarted = true;
        }
        /// <summary>
        /// Stop this instance.
        /// </summary>
        public void Stop()
        {
            if (!IsStarted)
                return;
            foreach (var listener in listeners)
            {
                StopListener(listener);
            }
            IsStarted = true;
        }


        /// <summary>
        /// Adds the listener.
        /// </summary>
        /// <param name="listener">Listener.</param>
        public void AddListener(IListener listener)
        {
            if (IsStarted)
            {
                StartListener(listener);
            }
            listeners.Add(listener);
        }
        /// <summary>
        /// Removes the listener.
        /// </summary>
        /// <param name="listener">Listener.</param>
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
            listener.Start();

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


        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                var host = x.Request.Headers[eHttpHeader.Host];
                var website = Websites[host] ?? Websites[""];
                if (website == null)
                {
                    return ErrorHelper.Build(400, 0, Name, "Invaild Hostname");
                }
                return website.OnProcess(x);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ErrorHelper.Build(500, 0, Name);
            }
        }
    }
}
