using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlNodeWithoutNewLine
    /// </summary>
    public class HtmlNodeWithoutNewLine : HtmlNode
    {
        internal override bool IsWithoutNewLine
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append($@"<{Name}{Param.ToString()}>");
            sb.Append(GetContent(i));
            sb.Append($@"</{Name}>");
            return sb.ToString();
        }
    }
}
