using Lsj.Util.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Logs;

namespace Lsj.Util.Net.Web.Cookie
{
    /// <summary>
    /// HttpCookies
    /// </summary>
    public class HttpCookies : IEnumerable<HttpCookie>
    {
        SafeDictionary<string, HttpCookie> cookies;
        /// <summary>
        /// Initial a new instance of HttpCookies
        /// </summary>
        public HttpCookies()
        {
            this.cookies = new SafeDictionary<string, HttpCookie>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public HttpCookie this[string key]
        {
            get
            {
                return cookies.ContainsKey(key) ? cookies[key] : new HttpCookie { name = key};
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<HttpCookie> GetEnumerator()
        {
            return cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="cookie"></param>
        public void Add(HttpCookie cookie)
        {
            cookies[cookie.name] = cookie;
        }
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
                LogProvider.Default.Warn("Error Cookies \r\n");
                LogProvider.Default.Warn(e);
            }
            return cookies;
        }

    }
}
