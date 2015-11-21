using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlRawNode : HtmlNodeWithoutNewLine
    {
        public HtmlRawNode(string content)
        {
            this.Content = content;
        }
        public string Content
        {
            get;
            set;
        } = "";
        public override string ToString(int i)
        {
            return Content;
        }
    }
}
