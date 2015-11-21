using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlNodeWithoutNewLine : HtmlNode
    {
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append($@"<{Name}{Param.ToString()}>");
            sb.Append(GetContent(i + 1));
            if (!(this.Children.Last() is HtmlNodeWithoutNewLine))
                sb.Append(NULL, i * 4);
            sb.Append($@"</{Name}>");
            return sb.ToString();
        }
    }
}
