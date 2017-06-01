using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder
#else
namespace Lsj.Util.HtmlBuilder
#endif
{
    /// <summary>
    /// HtmlParam
    /// </summary>
    public struct HtmlParam
    {
        /// <summary>
        /// The name.
        /// </summary>
        public string name;
        /// <summary>
        /// The value.
        /// </summary>
        public string value;
    }
}
