
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Interfaces;
#else
using Lsj.Util.Net.Web.Interfaces;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Event
#else
namespace Lsj.Util.Net.Web.Event
#endif
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
