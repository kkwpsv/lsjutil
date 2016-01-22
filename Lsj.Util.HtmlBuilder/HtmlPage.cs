using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlPage
    /// </summary>
    public class HtmlPage:HtmlNode
    {
        /// <summary>
        /// Version
        /// </summary>
        public const string Version = "HtmlBuilder/lsj(1.2)";
        /// <summary>
        /// HtmlPage
        /// </summary>
        public HtmlPage()
        {
            Children.Add(head);
            Children.Add(body);
        }
        /// <summary>
        /// head
        /// </summary>
        public head head
        {
            get;
            set;
        } = new head();
        /// <summary>
        /// body
        /// </summary>
        public body body
        {
            get;
            set;
        } = new body();
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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
