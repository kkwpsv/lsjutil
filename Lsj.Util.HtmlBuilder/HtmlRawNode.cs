using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlRawNode
    /// </summary>
    public class HtmlRawNode : HtmlNodeWithoutNewLine
    {
        /// <summary>
        /// HtmlRawNode
        /// </summary>
        /// <param name="content"></param>
        public HtmlRawNode(string content)
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
            return Content;
        }
    }
}
