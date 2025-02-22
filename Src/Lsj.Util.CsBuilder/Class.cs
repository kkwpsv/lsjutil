using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Class
    /// </summary>
    public class Class : TopLevelItem
    {
        /// <inheritdoc/>
        protected override string Keyword => "class";

        /// <summary>
        /// Members
        /// </summary>
        public List<ClassMember> Members
        {
            get;
        } = new List<ClassMember>();

        /// <inheritdoc/>
        protected override IEnumerable<Statement> Children => Members;
    }
}
