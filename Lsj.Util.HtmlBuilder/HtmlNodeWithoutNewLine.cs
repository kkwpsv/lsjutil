using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder
#else
namespace Lsj.Util.HtmlBuilder
#endif
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
            sb.Append($@"<{Name}{Params.ToString()}>");
            sb.Append(GetContent(i));
            sb.Append($@"</{Name}>");
            return sb.ToString();
        }
    }
}
