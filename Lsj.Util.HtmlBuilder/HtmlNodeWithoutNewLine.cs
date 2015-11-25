using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlNodeWithoutNewLine : HtmlNode
    {
        public override bool IsWithoutNewLine
        {
            get
            {
                return true;
            }
        }
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
