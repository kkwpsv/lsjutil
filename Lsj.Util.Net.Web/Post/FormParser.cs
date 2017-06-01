using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;
using Lsj.Util.Text;

namespace Lsj.Util.Net.Web.Post
{
    /// <summary>
    /// FormParser
    /// </summary>
    public class FormParser
    {
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static SafeStringToStringDirectionary Parse(string str)
        {
            
            var form = new SafeStringToStringDirectionary();
            var a = str.Split('&');
            {
                foreach (var b in a)
                {
                    var c = b.Split('=');
                    if (c.Length >= 2)
                    {
                        var name = c[0].Trim().UrlDecode();
                        var content = c[1].Trim().UrlDecode();
                        form.Add(name,content);
                    }
                }
            }
            return form;
        }
        /// <summary>
        /// ToBytes
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static byte[] ToBytes(IDictionary<string,string> dic)
        {
            if (dic == null || dic.Count == 0)
            {
                return new byte[0];
            }
            var sb = new StringBuilder();
            foreach (var a in dic)
            {
                sb.Append(a.Key.UrlEncode());
                sb.Append("=");
                sb.Append(a.Value.UrlEncode());
                sb.Append("&");
            }
            return sb.ToString().RemoveLastOne().ConvertToBytes();
        }

    }
}
