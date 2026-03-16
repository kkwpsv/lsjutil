using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// File cache size flags
    /// </summary>
    [Flags]
    public enum FileCacheSizeFlags : uint
    {
        /// <summary>
        /// FILE_CACHE_MAX_HARD_ENABLE
        /// </summary>
        FILE_CACHE_MAX_HARD_ENABLE = 0x00000001,

        /// <summary>
        /// FILE_CACHE_MAX_HARD_DISABLE
        /// </summary>
        FILE_CACHE_MAX_HARD_DISABLE = 0x00000002,

        /// <summary>
        /// FILE_CACHE_MIN_HARD_ENABLE
        /// </summary>
        FILE_CACHE_MIN_HARD_ENABLE = 0x00000004,

        /// <summary>
        /// FILE_CACHE_MIN_HARD_DISABLE
        /// </summary>
        FILE_CACHE_MIN_HARD_DISABLE = 0x00000008,
    }
}
