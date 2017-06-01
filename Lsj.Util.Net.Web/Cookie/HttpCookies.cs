using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Logs;
using Lsj.Util.Collections;

namespace Lsj.Util.Net.Web.Cookie
{
    /// <summary>
    /// HttpCookies
    /// </summary>
    public class HttpCookies : IEnumerable<HttpCookie>
    {
        SafeDictionary<string, HttpCookie> cookies;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.Net.Web.Cookie.HttpCookies"/> class.
        /// </summary>
        public HttpCookies()
        {
            this.cookies = new SafeDictionary<string, HttpCookie>();
        }
        /// <summary>
        /// Gets the <see cref="T:Lsj.Util.Net.Web.Cookie.HttpCookies"/> with the specified key.
        /// </summary>
        /// <param name="key">Key.</param>
        public HttpCookie this[string key]
        {
            get
            {
                return cookies.ContainsKey(key) ? cookies[key] : new HttpCookie { name = key };
            }
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
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
        /// Add
        /// </summary>
        /// <param name="str"></param>
        public void Add(string str)
        {
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
                        this.Add(new HttpCookie { name = name, content = content });
                    }
                }
            }
            catch (Exception e)
            {
                LogProvider.Default.Warn("Error Cookies \r\n");
                LogProvider.Default.Warn(e);
            }
        }
    }
}
