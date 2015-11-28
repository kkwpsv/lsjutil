using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Cookie
{
    public class HttpCookies : IEnumerable<HttpCookie>
    {
        Dictionary<string, HttpCookie> cookies = new Dictionary<string, HttpCookie>();
        public HttpCookies(Dictionary<string, HttpCookie> cookies)
        {
            this.cookies = cookies;
        }
        public HttpCookie this[string key]
        {
            get
            {
                return cookies.ContainsKey(key) ? cookies[key] : new HttpCookie { name = key};
            }
        }

        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(HttpCookie cookie)
        {
            if (cookies.ContainsKey(cookie.name))
            {
                cookies[cookie.name] = cookie;
            }
            else
            {
                cookies.Add(cookie.name, cookie);
            }
        }

    }
}
