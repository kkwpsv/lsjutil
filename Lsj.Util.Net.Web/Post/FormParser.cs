using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Post
{
    public class FormParser
    {
        public static HttpForm Parse(string str)
        {
            SafeDictionary<string, string> form = new SafeDictionary<string, string>();
            var a = str.Split('&');
            {
                foreach (var b in a)
                {
                    var c = b.Split('=');
                    if (c.Length >= 2)
                    {
                        var name = c[0].Trim();
                        var content = c[1].Trim();
                        form.Add(c[0], c[1]);
                    }
                }
            }
            return new HttpForm(form);
        }

    }
}
