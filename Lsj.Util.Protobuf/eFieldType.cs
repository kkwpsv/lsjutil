using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Protobuf
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
