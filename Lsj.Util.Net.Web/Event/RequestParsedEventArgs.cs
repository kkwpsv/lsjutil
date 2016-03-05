using Lsj.Util.Net.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// SocketReceivedArgs
    /// </summary>
    public class RequestParsedEventArgs : EventArgs
    {
        /// <summary>
        /// Request
        /// </summary>
        public IHttpRequest Request
        {
            get;
            set;
        }
        /// <summary>
        /// RequestParsedEventArgs
        /// </summary>
        public RequestParsedEventArgs()
        {
        }
    }
}
