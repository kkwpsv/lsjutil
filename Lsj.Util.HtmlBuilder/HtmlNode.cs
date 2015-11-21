using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    public abstract class HtmlNode : IEnumerable<HtmlNode>
    {
        
        public static char NULL = ' ';
        public virtual string Name{
            get
            {
                return this.GetType().Name;
            }
        }
        public virtual string GetContent(int i)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in Children)
            {
                if (a is HtmlNodeWithoutNewLine)
                {
                    sb.Append(a.ToString(i));
                }
                else
                {
                    if (a == Children.First())
                    {
                        sb.AppendLine();
                    }                    
                    sb.Append(a.ToString(i));
                    sb.AppendLine();
                }
                
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
        public override string ToString() => ToString(0);
        public virtual string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i*4);
            sb.Append($@"<{Name}{Param.ToString()}>");
            sb.Append(GetContent(i + 1));
            if(!(this.Children.Last() is HtmlNodeWithoutNewLine))
                sb.Append(NULL, i * 4);
            sb.Append($@"</{Name}>");
            return sb.ToString();
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
