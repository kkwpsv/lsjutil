using Lsj.Util.Logs;
using Lsj.Util.Net.Web.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Listener
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
        /// SocketReceived
        /// </summary>
        event EventHandler<SocketReceivedArgs> SocketReceved;
    }
}
