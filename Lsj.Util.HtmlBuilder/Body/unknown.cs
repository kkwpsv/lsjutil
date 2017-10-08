using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder.Body
{
    /// <summary>
    /// Unknown Node
    /// </summary>
    public class Unknown : HtmlNode
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
        /// Initializes a new instance of the <see cref="Lsj.Util.HtmlBuilder.Body.Unknown"/> class.
        /// </summary>
        /// <param name="type">Type.</param>
        public Unknown(string type)
        {
            name = type;
        }

    }
}
