using Lsj.Util.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
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
