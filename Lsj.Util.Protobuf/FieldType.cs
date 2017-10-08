using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Protobuf
{
    /// <summary>
    /// FieldType
    /// </summary>
    public enum FieldType : byte
    {
        /// <summary>
        /// Varint
        /// </summary>
        Varint,
        /// <summary>
        /// Bit64
        /// </summary>
        Bit64,
        /// <summary>
        /// LengthDelimited
        /// </summary>
        LengthDelimited,
        /// <summary>
        /// StartGroup
        /// </summary>
        StartGroup,
        /// <summary>
        /// EndGroup
        /// </summary>
        EndGroup,
        /// <summary>
        /// Bit32
        /// </summary>
        Bit32

    }
}
