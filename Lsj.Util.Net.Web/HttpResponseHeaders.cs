using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public class HttpResponseHeaders : IEnumerable<KeyValuePair<string, string>>
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        public HttpResponseHeaders()
        {
        }
        public string this[string key]
        {
            get
            {
                return headers.ContainsKey(key) ? headers[key] : "";
            }
        }

        public IEnumerator<KeyValuePair<string,string>> GetEnumerator()
        {
            return headers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(string key,string content)
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
