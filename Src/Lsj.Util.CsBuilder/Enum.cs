using System.Collections.Generic;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Enum
    /// </summary>
    public class Enum : TopLevelItem
    {
        /// <inheritdoc/>
        protected override string Keyword => "enum";

        /// <summary>
        /// Items
        /// </summary>
        public List<EnumItem> Items
        {
            get;
        } = new List<EnumItem>();

        /// <inheritdoc/>
        protected override IEnumerable<Statement> Children => Items;
    }
}
