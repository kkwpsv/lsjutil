#if !NETSTANDARD
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Lsj.Util.Config;
using System.Web;
using Lsj.Util.Text;

namespace Lsj.Util
{
    /// <summary>
    /// WebHelper
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// AppSetting
        /// </summary>
        /// <value>The app settings.</value>
        public static NameValueCollection AppSettings
        {
            get
            {
                return AppConfig.AppSettings;
            }
        }
        /// <summary>
        /// If contain the cookie with specified name
        /// </summary>
        /// <returns></returns>
        /// <param name="cookiecollection"></param>
        /// <param name="name"></param>
        public static bool ContainsCookie(this HttpCookieCollection cookiecollection, string name) => cookiecollection.AllKeys.Contains(name.ToSafeString());
        /// <summary>
        /// Avoid Null
        /// </summary>
        /// <returns></returns>
        /// <param name="cookie">Cookie</param>
        public static string GetSafeValue(this HttpCookie cookie) => cookie != null ? cookie.Value.ToSafeString() : "";
        /// <summary>
        /// Create cookie
        /// </summary>
        /// <returns></returns>
        /// <param name="name">Name</param>
        /// <param name="content">Content</param>
        public static HttpCookie CreateCookie(string name, string content) => CreateCookie(name, content, DateTime.Now.AddYears(1));
        /// <summary>
        /// Create cookie
        /// </summary>
        /// <returns>The cookie.</returns>
        /// <param name="name">Name</param>
        /// <param name="content">Content</param>
        /// <param name="expires">Expires</param>
        public static HttpCookie CreateCookie(string name, string content, DateTime expires)
        {
            var a = new HttpCookie(name)
            {
                Value = content,
                Expires = expires
            };
            return a;
        }
        /// <summary>
        /// Create cookie
        /// </summary>
        /// <returns></returns>
        /// <param name="name">Name</param>
        /// <param name="content">Content</param>
        /// <param name="expires">Expires</param>
        /// <param name="domain">Domain</param>
        public static HttpCookie CreateCookie(string name, string content, DateTime expires, string domain)
        {
            var a = new HttpCookie(name)
            {
                Value = content,
                Expires = expires,
                Domain = domain
            };
            return a;
        }
        /// <summary>
        /// Returns and redirect
        /// </summary>
        /// <param name="response"></param>
        /// <param name="str">content</param>
        /// <param name="url">url</param>
        public static void ReturnAndRedirect(this HttpResponse response, string str, string url) => response.Write(@"<script language=""javascript""> alert(""" + str + @""");document.location.href=""" + url + @""";</script>");
        /// <summary>
        /// Redirect with post
        /// </summary>
        /// <param name="response"></param>
        /// <param name="url">url</param>
        public static void RedirectWithPost(this HttpResponse response, string url)
        {
            response.RedirectLocation = url;
            response.StatusCode = 307;
        }

    }
}
#endif