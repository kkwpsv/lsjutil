using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.HtmlBuilder.Header
#else
namespace Lsj.Util.HtmlBuilder.Header
#endif
{
    /// <summary>
    /// Link.
    /// </summary>
    public class link : HtmlNodeWithoutEnd
    {
    }
}
