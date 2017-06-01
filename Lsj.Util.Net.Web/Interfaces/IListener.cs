
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Logs;
using Lsj.Util.Core.Net.Sockets.Event;
#else
using Lsj.Util.Logs;
using Lsj.Util.Net.Sockets.Event;
using Lsj.Util.Net.Web.Event;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Interfaces
#else
namespace Lsj.Util.Net.Web.Interfaces
#endif
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
