using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#if NETCOREAPP1_1
namespace Lsj.Util.Core.SQLBuilder
#else
namespace Lsj.Util.SQLBuilder
#endif
{
    public class SQLStatement
    {
        public override string ToString() => "";
    }
}
