using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Local Memory Flags
    /// </summary>
    [Flags]
    public enum LocalMemoryFlags
    {
        /// <summary>
        /// LMEM_FIXED
        /// </summary>
        LMEM_FIXED = 0x0000,

        /// <summary>
        /// LMEM_MOVEABLE
        /// </summary>
        LMEM_MOVEABLE = 0x0002,

        /// <summary>
        /// LMEM_NOCOMPACT
        /// </summary>
        LMEM_NOCOMPACT = 0x0010,

        /// <summary>
        /// LMEM_NODISCARD
        /// </summary>
        LMEM_NODISCARD = 0x0020,

        /// <summary>
        /// LMEM_ZEROINIT
        /// </summary>
        LMEM_ZEROINIT = 0x0040,

        /// <summary>
        ///  LMEM_MODIFY
        /// </summary>
        LMEM_MODIFY = 0x0080,

        /// <summary>
        ///  LMEM_DISCARDABLE
        /// </summary>
        LMEM_DISCARDABLE = 0x0F00,

        /// <summary>
        /// LMEM_VALID_FLAGS
        /// </summary>
        LMEM_VALID_FLAGS = 0x0F72,

        /// <summary>
        ///  LMEM_INVALID_HANDLE
        /// </summary>
        LMEM_INVALID_HANDLE = 0x8000,

        /// <summary>
        /// LHND
        /// </summary>
        LHND = LMEM_MOVEABLE | LMEM_ZEROINIT,

        /// <summary>
        /// LPTR
        /// </summary>
        LPTR = LMEM_FIXED | LMEM_ZEROINIT,

        /// <summary>
        /// NONZEROLHND
        /// </summary>
        NONZEROLHND = LMEM_MOVEABLE,

        /// <summary>
        /// NONZEROLPTR
        /// </summary>
        NONZEROLPTR = LMEM_FIXED,
    }
}
