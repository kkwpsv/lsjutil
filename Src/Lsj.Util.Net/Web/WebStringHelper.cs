using System.Net;

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
           return WebUtility.UrlEncode(src);
        }

        /// <summary>
        /// Url Decode
        /// </summary>
        /// <param name="src"></param>
        public static string UrlDecode(this string src)
        {
            return WebUtility.UrlDecode(src);
        }
    }
}
