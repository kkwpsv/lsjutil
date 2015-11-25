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
        public const string Version = "HtmlBuilder/lsj(1.2)";
        public HtmlPage()
        {
            Children.Add(head);
            Children.Add(body);
        }
        public head head
        {
            get;
            set;
        } = new head();
        public body body
        {
            get;
            set;
        } = new body();
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
<!--The Page Is Built By {Version}.-->{GetContent(-1)}
</html>
";
            }
        }
    }
}
