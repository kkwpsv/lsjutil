
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;
using Lsj.Util.Net.Web.Event;


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
        void Start();
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
