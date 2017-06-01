using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#if NETCOREAPP1_1
using Lsj.Util.Core.Collections;
#else
using Lsj.Util.Collections;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder
#else
namespace Lsj.Util.HtmlBuilder
#endif
{
    /// <summary>
    /// HtmlParam
    /// </summary>
    public class HtmlParams : SafeStringToStringDirectionary
    {
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var a in this)
            {
                sb.Append($@" {a.Key}=""{a.Value}""");
            }
            return sb.ToString();
        }
    }
}
