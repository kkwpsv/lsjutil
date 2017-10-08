using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlNodeWithoutEnd
    /// </summary>
    public class HtmlNodeWithoutEnd : HtmlNode
    {
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i">Count of blank</param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.Append($@"<{Name}{Params.ToString()} />");
            return sb.ToString();
        }
    }
}
