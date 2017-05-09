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
        /// Gets the app settings.
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
        /// Containses the cookie.
        /// </summary>
        /// <returns><c>true</c>, if cookie was containsed, <c>false</c> otherwise.</returns>
        /// <param name="cookiecollection">Cookiecollection.</param>
        /// <param name="name">Name.</param>
        public static bool ContainsCookie(this HttpCookieCollection cookiecollection, string name) => cookiecollection.AllKeys.Contains(name.ToSafeString());
        /// <summary>
        /// Gets the safe value.
        /// </summary>
        /// <returns>The safe value.</returns>
        /// <param name="cookie">Cookie.</param>
        public static string GetSafeValue(this HttpCookie cookie) => cookie != null ? cookie.Value.ToSafeString() : "";
        /// <summary>
        /// Creates the cookie.
        /// </summary>
        /// <returns>The cookie.</returns>
        /// <param name="name">Name.</param>
        /// <param name="content">Content.</param>
        public static HttpCookie CreateCookie(string name, string content) => CreateCookie(name, content, DateTime.Now.AddYears(1));
        /// <summary>
        /// Creates the cookie.
        /// </summary>
        /// <returns>The cookie.</returns>
        /// <param name="name">Name.</param>
        /// <param name="content">Content.</param>
        /// <param name="expires">Expires.</param>
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
        /// Creates the cookie.
        /// </summary>
        /// <returns>The cookie.</returns>
        /// <param name="name">Name.</param>
        /// <param name="content">Content.</param>
        /// <param name="expires">Expires.</param>
        /// <param name="domain">Domain.</param>
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
        /// Returns the and redirect.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <param name="str">String.</param>
        /// <param name="uri">URI.</param>
        public static void ReturnAndRedirect(this HttpResponse response, string str, string uri) => response.Write(@"<script language=""javascript""> alert(""" + str + @""");document.location.href=""" + uri + @""";</script>");
        /// <summary>
        /// Redirects the with post.
        /// </summary>
        /// <param name="response">Response.</param>
        /// <param name="uri">URI.</param>
        public static void RedirectWithPost(this HttpResponse response, string uri)
        {
            response.RedirectLocation = uri;
            response.StatusCode = 307;
        }

    }
}