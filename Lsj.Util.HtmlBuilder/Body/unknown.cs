using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.HtmlBuilder.Body
{
    /// <summary>
    /// unknown
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
        /// unknown
        /// </summary>
        /// <param name="type"></param>
        public unknown(string type)
        {
            name = type;
        }

    }
}
