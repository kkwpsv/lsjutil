using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Protobuf
#else
namespace Lsj.Util.Protobuf
#endif
{
    public enum eFieldType :byte
    {
        Varint,
        Bit64,
        LengthDelimited,
        StartGroup,
        EndGroup,
        Bit32

    }
}
