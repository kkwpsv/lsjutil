using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder.Body
#else
namespace Lsj.Util.HtmlBuilder.Body
#endif
{
    /// <summary>
    /// Unknown Node.
    /// </summary>
    public class unknown : HtmlNode
    {
        /// <summary>
        /// Name
        /// </summary>
        public override string Name
        {
            get
            {
                return name;
            }
        }
        string name = "unknown";
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lsj.Util.HtmlBuilder.Body.unknown"/> class.
        /// </summary>
        /// <param name="type">Type.</param>
        public unknown(string type)
        {
            name = type;
        }

    }
}
