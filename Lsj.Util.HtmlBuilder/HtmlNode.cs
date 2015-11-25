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
        public virtual string Name
        {
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
                if (!a.IsWithoutNewLine)
                {
                    sb.AppendLine();
                }           
                sb.Append(a.ToString(i+1));               
            }
            if (!IsAllInOneLine)
            {
                sb.AppendLine();
                sb.Append(NULL, 4*i);
            }
            return sb.ToString();
        }
        protected List<HtmlNode> Children
        {
            get; set;
        } = new List<HtmlNode>();
        public HtmlParam Param = new HtmlParam();
        public bool IsAllInOneLine = true;
        public virtual bool IsWithoutNewLine { get; }=false;


        public void Add(HtmlNode node)
        {
            Children.Add(node);
            if (IsAllInOneLine)
            {
                if (!node.IsWithoutNewLine)
                    IsAllInOneLine = false;
            }
        }
        public void AddRange(List<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }
        public override string ToString() => ToString(0);
        public virtual string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i*4);
            sb.Append($@"<{Name}{Param.ToString()}>");
            sb.Append(GetContent(i));
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
