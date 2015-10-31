using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpStatic
    {
        static Dictionary<string, eHttpRequestHeader> Headers = new Dictionary<string, eHttpRequestHeader>
        {
            {"Accept",eHttpRequestHeader.Accept},
            {"Accept-Charset",eHttpRequestHeader.AcceptCharset},


        };
        public eHttpRequestHeader GetHeaderType(string name)
        {
            if (Headers.ContainsKey(name))
            {
                return Headers[name];
            }
            else
            {
                return eHttpRequestHeader.Unknown;
            }
        }
    }
}
