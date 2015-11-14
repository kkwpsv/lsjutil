using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public abstract class HtmlNode : IEnumerable<HtmlNode>
    {
        public virtual string Name { get;} = "";
        public virtual string GetContent()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in Children)
            {
                sb.Append(a);
            }
            return sb.ToString();
        }
        public virtual List<HtmlNode> Children
        {
            get; set;
        } = new List<HtmlNode>();
        public HtmlParam Param = new HtmlParam();

        public void Add(HtmlNode node)
        {
            Children.Add(node);
        }
        public override string ToString()
        {
            return 
                $@"
<{Name}{Param.ToString()}>
    {GetContent()}
</{Name}>
";
        }

        public IEnumerator<HtmlNode> GetEnumerator()
        {
            return Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
