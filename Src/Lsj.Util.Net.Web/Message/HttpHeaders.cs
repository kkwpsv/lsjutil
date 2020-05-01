
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpHeaders
    /// </summary>
    public class HttpHeaders : SafeStringToStringDictionary
    {
        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string this[Protocol.HttpHeaders x]
        {
            get
            {
                return this[HttpHeadersHelper.GetNameByHeader(x)];
            }
            set
            {
                this[HttpHeadersHelper.GetNameByHeader(x)] = value;
            }
        }

        internal void Add(Protocol.HttpHeaders x, string content)
        {
            Add(HttpHeadersHelper.GetNameByHeader(x), content);
        }
    }
}
