using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Heap Flags
    /// </summary>
    [Flags]
    public enum HeapFlags : uint
    {
        /// <summary>
        /// HEAP_GENERATE_EXCEPTIONS
        /// </summary>
        HEAP_GENERATE_EXCEPTIONS = 0x00000004,

        /// <summary>
        /// HEAP_NO_SERIALIZE
        /// </summary>
        HEAP_NO_SERIALIZE = 0x00000001,

        /// <summary>
        /// HEAP_ZERO_MEMORY
        /// </summary>
        HEAP_ZERO_MEMORY = 0x00000008,
    }
}
