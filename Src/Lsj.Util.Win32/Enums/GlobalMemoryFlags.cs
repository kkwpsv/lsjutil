using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Global Memory Flags
    /// </summary>
    [Flags]
    public enum GlobalMemoryFlags
    {
        /// <summary>
        /// GMEM_FIXED
        /// </summary>
        GMEM_FIXED = 0x0000,

        /// <summary>
        /// GMEM_MOVEABLE
        /// </summary>
        GMEM_MOVEABLE = 0x0002,

        /// <summary>
        /// GMEM_NOCOMPACT
        /// </summary>
        GMEM_NOCOMPACT = 0x0010,

        /// <summary>
        /// GMEM_NODISCARD
        /// </summary>
        GMEM_NODISCARD = 0x0020,

        /// <summary>
        /// GMEM_ZEROINIT
        /// </summary>
        GMEM_ZEROINIT = 0x0040,

        /// <summary>
        /// GMEM_MODIFY
        /// </summary>
        GMEM_MODIFY = 0x0080,

        /// <summary>
        /// GMEM_DISCARDABLE
        /// </summary>
        GMEM_DISCARDABLE = 0x0100,

        /// <summary>
        /// GMEM_NOT_BANKED
        /// </summary>
        GMEM_NOT_BANKED = 0x1000,

        /// <summary>
        /// GMEM_SHARE
        /// </summary>
        GMEM_SHARE = 0x2000,

        /// <summary>
        /// GMEM_DDESHARE
        /// </summary>
        GMEM_DDESHARE = 0x2000,

        /// <summary>
        /// GMEM_NOTIFY
        /// </summary>
        GMEM_NOTIFY = 0x4000,

        /// <summary>
        /// GMEM_LOWER
        /// </summary>
        GMEM_LOWER = GMEM_NOT_BANKED,

        /// <summary>
        /// GMEM_VALID_FLAGS
        /// </summary>
        GMEM_VALID_FLAGS = 0x7F72,

        /// <summary>
        /// GMEM_INVALID_HANDLE
        /// </summary>
        GMEM_INVALID_HANDLE = 0x8000,

        /// <summary>
        /// GHND
        /// </summary>
        GHND = GMEM_MOVEABLE | GMEM_ZEROINIT,

        /// <summary>
        /// GPTR
        /// </summary>
        GPTR = GMEM_FIXED | GMEM_ZEROINIT,

        /// <summary>
        /// GMEM_DISCARDED
        /// </summary>
        GMEM_DISCARDED = 0x4000,

        /// <summary>
        /// GMEM_LOCKCOUNT
        /// </summary>
        GMEM_LOCKCOUNT = 0x00FF,
    }
}
