using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Lsj.Util.Config;
using System.Web;

namespace Lsj.Util
{
    /// <summary>
    /// WebHelper
    /// </summary>
    public static class WebHelper
    {
        /// <summary>
        /// Read AppSettingsSection in Web.config
        /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                return AppConfig.AppSettings;
            }
        }
        /// <summary>
        /// GetSafeValue
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string GetSafeValue(this HttpCookie cookie) => cookie!=null?cookie.Value.ToSafeString():"";
        public static HttpCookie CreateCookie(string name, string content) => CreateCookie(name, content, DateTime.Now.AddYears(1));
        /// <summary>
        /// CreateCookie
        /// </summary>
        /// <param name="name"></param>
        /// <param name="content"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public static HttpCookie CreateCookie(string name, string content, DateTime expires)
        {
            var a = new HttpCookie(name);
            a.Value = content;
            a.Expires = expires;
            return a;
        }
        /// <summary>
        /// ReturnAndRedict
        /// </summary>
        /// <param name="response"></param>
        /// <param name="str"></param>
        /// <param name="uri"></param>
        public static void ReturnAndRedirect(this HttpResponse response, string str, string uri) => response.Write(@"<script language=""javascript""> alert("""+ str +@""");document.location.href="""+uri+@""";</script>");

    }
}