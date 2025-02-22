using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Name Space Scope
    /// </summary>
    public class NameSpaceScope
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Children
        /// </summary>
        public List<TopLevelItem> Children { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"namespace {Name}");
            sb.AppendLine("{");
            foreach (var child in Children)
            {
                sb.AppendLine(child.ToString(1));
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
