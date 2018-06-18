using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Collections;


namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// Html Params
    /// </summary>
    public class HtmlParams : SafeStringToStringDirectionary
    {
        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
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
