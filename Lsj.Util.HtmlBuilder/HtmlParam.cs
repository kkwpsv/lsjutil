using Lsj.Util.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlParam : SafeDictionary<string,string>
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var a in this)
            {
                sb.Append($@" {a.Key}=""{a.Value}""");
            }
            return sb.ToString();
        }
    }
}
