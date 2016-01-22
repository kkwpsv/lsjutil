using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlNode
    /// </summary>
    public abstract class HtmlNode : IEnumerable<HtmlNode>
    {
        internal static char NULL = ' ';

        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name
        {
            get
            {
                return this.GetType().Name;
            }
        }
        /// <summary>
        /// GetContent
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Children
        /// </summary>
        protected List<HtmlNode> Children
        {
            get; set;
        } = new List<HtmlNode>();
        /// <summary>
        /// Param
        /// </summary>
        public HtmlParam Param = new HtmlParam();

        bool IsAllInOneLine = true;
        internal virtual bool IsWithoutNewLine { get; }=false;

        /// <summary>
        /// Add Child
        /// </summary>
        /// <param name="node"></param>
        public void Add(HtmlNode node)
        {
            Children.Add(node);
            if (IsAllInOneLine)
            {
                if (!node.IsWithoutNewLine)
                    IsAllInOneLine = false;
            }
        }
        /// <summary>
        /// Add Children
        /// </summary>
        /// <param name="nodes"></param>
        public void AddRange(List<HtmlNode> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString(0);
        /// <summary>
        /// ToString
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public virtual string ToString(int i)
        {
            var sb = new StringBuilder();
            sb.Append(NULL, i*4);
            sb.Append($@"<{Name}{Param.ToString()}>");
            sb.Append(GetContent(i));
            sb.Append($@"</{Name}>");
            return sb.ToString();
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
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
