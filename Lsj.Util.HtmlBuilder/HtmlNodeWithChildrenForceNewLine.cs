using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlNodeWithChildrenForceNewLine :HtmlNode
    {
        public override string GetContent(int i)
        {
            var sb = new StringBuilder();
            if (Children.First().IsWithoutNewLine)
            {
                sb.AppendLine();
                sb.Append(NULL, i * 4 + 4);
            }               
            foreach (var a in Children)
            {
                if (!a.IsWithoutNewLine)
                {
                    sb.AppendLine();
                }
                sb.Append(a.ToString(i + 1));
            }
            sb.AppendLine();
            sb.Append(NULL, 4 * i);
            return sb.ToString();
        }
    }
}
