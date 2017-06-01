using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Protocol;
using Lsj.Util.Core.Text;
#else
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Message
#else
namespace Lsj.Util.Net.Web.Message
#endif
{
    /// <summary>
    /// Http response for client.
    /// </summary>
    public class HttpResponseForClient : HttpResponse
    {

        /// <summary>
        /// ContentLength
        /// </summary>
        public override int ContentLength => Headers[eHttpHeader.ContentLength].ConvertToInt(0);
    }
}
