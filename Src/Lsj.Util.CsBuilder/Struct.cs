using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.CsBuilder
{
    /// <summary>
    /// Struct
    /// </summary>
    public class Struct : TopLevelItem
    {
        /// <inheritdoc/>
        protected override string Keyword => "struct";
    }
}
