
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;



namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlPage
    /// </summary>
    public class HtmlPage : HtmlNode
    {
        /// <summary>
        /// Version
        /// </summary>
        public const string Version = "HtmlBuilder/lsj(2.0)";
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
<html{Params.ToString()}>
<!--The Page Is Built By {Version}.-->{GetContent(0)}
</html>
";
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="node"></param>
        public override void Add(HtmlNode node)
        {
            if (node is head)
            {
                this.Children.Remove(this.head);
                this.head = node as head;
                this.Children.Add(this.head);
            }
            else if (node is body)
            {
                this.Children.Remove(this.body);
                this.body = node as body;
                this.Children.Add(this.body);
            }
            else
            {
                base.Add(node);
            }

        }
    }
}
