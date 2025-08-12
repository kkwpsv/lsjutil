using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// TopLevelItem (class, struct...)
    /// </summary>
    public abstract class TopLevelItem : ClassMember
    {
        /// <summary>
        /// Visibility
        /// </summary>
        public Visibility Visibility
        {
            get;
            set;
        }

        /// <summary>
        /// Keyword
        /// </summary>
        protected abstract string Keyword { get; }

        /// <summary>
        /// Children
        /// </summary>
        protected abstract IEnumerable<Statement> Children { get; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Inherits
        /// </summary>
        public List<string> Inherits
        {
            get;
        } = new List<string>();

        /// <summary>
        /// Attributes
        /// </summary>
        public List<Attribute> Attributes
        {
            get;
        } = new List<Attribute>();

        /// <inheritdoc/>
        public override string ToString(int level)
        {
            var sb = new StringBuilder();

            foreach (var attr in Attributes)
            {
                sb.Append(attr.ToString(level));
            }

            sb.Append(' ', level * 4);
            sb.Append($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {Keyword} {Name}");
            if (Inherits.Count != 0)
            {
                sb.Append($" : {string.Join(", ", Inherits)}");
            }
            sb.AppendLine();
            sb.Append(' ', level * 4);
            sb.AppendLine("{");

            level++;
            var children = Children.ToArray();
            for (int i = 0; i < children.Length; i++)
            {
                sb.AppendLine(children[i].ToString(level));
                if (i != children.Length - 1)
                {
                    sb.AppendLine();
                }
            }
            level--;

            sb.Append(' ', level * 4);
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
