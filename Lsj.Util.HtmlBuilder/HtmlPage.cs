using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public class HtmlPage:HtmlNode
    {
        public const string Version = "HtmlBuilder/lsj(1.1)";
        public HtmlPage()
        {
            Children.Add(head);
            Children.Add(body);
        }
        public HtmlHead head
        {
            get;
            set;
        } = new HtmlHead();
        public HtmlBody body
        {
            get;
            set;
        } = new HtmlBody();
        public override string ToString(int i)
        {
            if (i != 0)
            {
                throw new Exception("HtmlPage Must Be The Root Node");
            }
            else
            {
                return
$@"<!DOCTYPE html>
<html>
<!--The Page Is Built By {Version}.-->{GetContent(i)}</html>
";
            }
        }
    }
}
