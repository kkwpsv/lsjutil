using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.CsBuilder
#else
namespace Lsj.Util.CsBuilder
#endif
{
    public enum eVisibility
    {
        None,
        Public,
        Private,
        Protected,
        Internal,
    }
}
