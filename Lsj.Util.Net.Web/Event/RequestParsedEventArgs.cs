using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Lsj.Util.Net.Web.Interfaces;

namespace Lsj.Util.Net.Web.Event
{
    /// <summary>
    /// Request parsed event arguments.
    /// </summary>
    public class RequestParsedEventArgs :EventArgs
    {
        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>The request.</value>
        public IHttpRequest Request
        {
            get;
            set;
        }
    }
}
