using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Lsj.Util.Net.Web.Interfaces;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// RequestParsedEventArgs
    /// </summary>
    public class RequestParsedEventArgs :EventArgs
    {
        /// <summary>
        /// Request
        /// </summary>
        /// <value>The request.</value>
        public IHttpRequest Request
        {
            get;
            set;
        }
    }
}
