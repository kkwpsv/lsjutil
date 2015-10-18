using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpRequestHeaders : IEnumerable<string>
    {
        Dictionary<eHttpRequestHeader, string> headers = new Dictionary<eHttpRequestHeader, string>();
        public HttpRequestHeaders()
        {
        }
        public string this[eHttpRequestHeader key]
        {
            get
            {
                return headers.ContainsKey(key) ? headers[key] : "";
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(eHttpRequestHeader key,string content)
        {
            if (headers.ContainsKey(key))
            {
                headers[key] = content;
            }
            else
            {
                this.headers.Add(key, content);
            }
        }
    }
}
