using System.Collections.Generic;
using System;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Error;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Logs;
using Lsj.Util.Collections;
using System.Reflection;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// WebServer
    /// </summary>
    public class WebServer
    {
        /// <summary>
        /// Name
        /// </summary>
        /// <value></value>
        public string Name
        {
            get;
            internal set;
#if NETSTANDARD
        } = $"LsjWebServer({typeof(WebServer).GetTypeInfo().Assembly.GetName().Version.ToString()})";
#else
        } = $"LsjWebServer({System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()})";
#endif


        List<IListener> listeners = new List<IListener>();
        /// <summary>
        /// Log
        /// </summary>
        public LogProvider Log
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// IsStarted
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool IsStarted
        {
            get;
            private set;
        }
        /// <summary>
        /// Websites
        /// </summary>
        public SafeDictionary<string, Website> Websites
        {
            get;
        } = new SafeDictionary<string, Website>();






        /// <summary>
        /// Start
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
        /// Stop
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
        /// Add listener
        /// </summary>
        /// <param name="listener">Listener</param>
        public void AddListener(IListener listener)
        {
            if (IsStarted)
            {
                StartListener(listener);
            }
            listeners.Add(listener);
        }
        /// <summary>
        /// Removes listener
        /// </summary>
        /// <param name="listener">Listener</param>
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
        /// RequestParsed EventHandler
        /// </summary>
        public event EventHandler<RequestParsedEventArgs> RequestParsed;

        internal void OnParsed(HttpContext x)
        {
            if (this.RequestParsed != null)
            {
                var args = new RequestParsedEventArgs
                {
                    Request = x.Request
                };
                this.RequestParsed(this, args);
            }
        }


        internal IHttpResponse OnProcess(HttpContext x)
        {
            try
            {
                var host = x.Request.Headers[HttpHeaders.Host];
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
