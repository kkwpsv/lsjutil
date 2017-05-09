using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder.Body
{
    /// <summary>
    /// Html note.
    /// </summary>
    public class HtmlNote : HtmlNode
    {
        /// <summary>
        /// HtmlNote
        /// </summary>
        /// <param name="content"></param>
        public HtmlNote(string content)
        {
            this.Content = content;
        }
        /// <summary>
        /// Content
        /// </summary>
        public string Content
        {
            get;
            set;
        } = "";
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i * 4);
            sb.Append($@"<!-- {Content} -->");
            return sb.ToString();
        }
    }
}
