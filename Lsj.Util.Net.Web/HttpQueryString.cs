using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpQueryString
    {
        Dictionary<string, string> querystring = new Dictionary<string, string>();
        public HttpQueryString(Dictionary<string, string> querystring)
        {
            this.querystring = querystring;
        }
        public string this[string key]
        {
            get
            {
                return querystring.ContainsKey(key) ? querystring[key] : "";
            }
        }
    }
}
