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
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Members
        /// </summary>
        public List<ClassMember> Members
        {
            get;
        } = new List<ClassMember>();

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
            sb.AppendLine($@"{(Visibility == Visibility.None ? "" : Visibility.ToString().ToLower())} {Keyword} {Name}");
            sb.Append(' ', level * 4);
            sb.AppendLine("{");

            level++;
            foreach (var member in Members)
            {
                sb.Append(member.ToString(level));
            }
            level--;

            sb.Append(' ', level * 4);
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
