using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// Web String Helper
    /// </summary>
    public static class WebStringHelper
    {
        /// <summary>
        /// Url Encode
        /// </summary>
        /// <param name="src"></param>

        public static string UrlEncode(this string src)
        {
#if NET40
            return HttpUtility.UrlEncode(src);
#else
           return WebUtility.UrlEncode(src);
#endif
        }

        /// <summary>
        /// Url Decode
        /// </summary>
        /// <param name="src"></param>
        public static string UrlDecode(this string src)
        {
#if NET40
            return HttpUtility.UrlDecode(src);
#else
            return WebUtility.UrlDecode(src);
#endif
        }
    }
}
