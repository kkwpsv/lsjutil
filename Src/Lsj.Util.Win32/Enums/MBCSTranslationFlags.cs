using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MBCS Translation Flags
    /// </summary>
    public enum MBCSTranslationFlags : uint
    {
        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        MB_PRECOMPOSED = 0x00000001,

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        MB_COMPOSITE = 0x00000002,

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        MB_USEGLYPHCHARS = 0x00000004,

        /// <summary>
        /// 
        /// </summary>
        MB_ERR_INVALID_CHARS = 0x00000008,
    }
}
