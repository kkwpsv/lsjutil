using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlRawNode : HtmlNode
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
        public override string ToString()
        {
            return Content;
        }
        public static explicit operator string (HtmlRawNode x)
        {
            return x.ToString();
        }
        public static explicit operator HtmlRawNode(string x)
        {
            return new HtmlRawNode(x);
        }
    }
}
