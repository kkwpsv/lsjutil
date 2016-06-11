using Lsj.Util.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Cookie
{
    public class HttpCookies : IEnumerable<HttpCookie>
    {
        SafeDictionary<string, HttpCookie> cookies;
        public HttpCookies()
        {
            this.cookies = new SafeDictionary<string, HttpCookie>();
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
            cookies[cookie.name] = cookie;
        }
        public static HttpCookies Parse(string str)
        {
            HttpCookies cookies = new HttpCookies();
            try
            {                
                var cookiestrings = str.Split(';');
                foreach (string cookiestring in cookiestrings)
                {
                    var cookie = cookiestring.Split('=');
                    if (cookie.Length >= 2)
                    {
                        var name = cookie[0].Trim();
                        var content = cookie[1].Trim();
                        cookies.Add(new HttpCookie { name = name, content = content });
                    }
                }
            }
            catch (Exception e)
            {
                if (cookies == null)
                    cookies = new HttpCookies();
                //Log.Log.Default.Warn("Error Cookies \r\n");
               // Log.Log.Default.Warn(e);
            }
            return cookies;
        }

    }
}
