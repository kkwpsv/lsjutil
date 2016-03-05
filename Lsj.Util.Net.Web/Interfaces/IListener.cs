﻿using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// Listener
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// Start
        /// </summary>
        void Start(WebServer server);
        /// <summary>
        /// Stop
        /// </summary>
        void Stop();
        /// <summary>
        /// LogProvider
        /// </summary>
        LogProvider Log
        {
            get;
            set;
        }
        /// <summary>
        /// Server
        /// </summary>
        WebServer Server
        {
            get;
        }
        /// <summary>
        /// SocketReceived
        /// </summary>
        event EventHandler<SocketAcceptedArgs> SocketAccepted;
    }
}
