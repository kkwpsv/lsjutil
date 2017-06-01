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
    public abstract class ClassMember
    {
        internal static char NULL = ' ';
        public abstract string ToString(int i);
    }
}
