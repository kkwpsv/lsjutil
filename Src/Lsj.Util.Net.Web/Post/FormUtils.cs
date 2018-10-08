using Lsj.Util.Collections;
using Lsj.Util.Text;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Net.Web.Post
{
    /// <summary>
    /// FormUtils
    /// </summary>
    public class FormUtils
    {
        /// <summary>
        /// ParseFromString
        /// </summary>
        /// <param name="bytes">form bytes</param>
        /// <returns></returns>
        public static IDictionary<string, string> ParseFromBytes(byte[] bytes) => ParseFromString(bytes.ConvertFromBytes());

        /// <summary>
        /// ParseFromString
        /// </summary>
        /// <param name="str">form string</param>
        /// <returns></returns>
        public static IDictionary<string, string> ParseFromString(string str)
        {
            var form = new SafeStringToStringDictionary();
            var a = str.Split('&');
            {
                foreach (var b in a)
                {
                    var c = b.Split('=');
                    if (c.Length >= 2)
                    {
                        var name = c[0].Trim().UrlDecode();
                        var content = c[1].Trim().UrlDecode();
                        form.Add(name, content);
                    }
                }
            }
            return form;
        }

        /// <summary>
        /// ConvertToString
        /// </summary>
        /// <param name="dic">form dic</param>
        /// <returns></returns>
        public static string ConvertToString(IDictionary<string, string> dic)
        {
            if (dic == null || dic.Count == 0)
            {
                return "";
            }
            var sb = new StringBuilder();
            foreach (var a in dic)
            {
                sb.Append(a.Key.UrlEncode());
                sb.Append("=");
                sb.Append(a.Value.UrlEncode());
                sb.Append("&");
            }
            return sb.ToString().RemoveLastOne();
        }

        /// <summary>
        /// ConvertToBytes
        /// </summary>
        /// <param name="dic">form dic</param>
        /// <returns></returns>
        public static byte[] ConvertToBytes(IDictionary<string, string> dic) => ConvertToString(dic).ConvertToBytes();

    }
}
