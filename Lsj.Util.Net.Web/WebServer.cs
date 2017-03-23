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
        ///名称
        /// </summary>
        public string Name
        {
            get;
            internal set;
        } = "LsjWebServer(1.0)";


        List<IListener> listeners = new List<IListener>();
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
        }
        /// <summary>
        /// 网站
        /// </summary>
        public SafeDictionary<string,Website> Websites
        {
            get;
        } = new SafeDictionary<string, Website>();
        





        /// <summary>
        /// 启动服务器
        /// </summary>
        public void Start()
        {
            if (IsStarted)
                return;
            if (Websites.Keys.Count == 0)
            {
                Websites.Add("", new Website(""));
            }
            foreach(var x in Websites)
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
        /// 停止服务器
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
        /// 添加Listener
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
        /// 移除Listener
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
                if(website==null)
                {
                    return ErrorHelper.Build(400, 0, Name,"Invaild Hostname");
                }
                return website.OnProcess(x);
            }
            catch(Exception e)
            {
                Log.Error(e);
                return ErrorHelper.Build(500, 0, Name);
            }
        }
    }
}
