using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MBCS Translation Flags
    /// </summary>
    [Flags]
    public enum MBCSTranslationFlags : uint
    {
        /// <summary>
        /// MB_PRECOMPOSED
        /// </summary>
        [Obsolete]
        MB_PRECOMPOSED = 0x00000001,

        /// <summary>
        /// MB_COMPOSITE
        /// </summary>
        [Obsolete]
        MB_COMPOSITE = 0x00000002,

        /// <summary>
        /// MB_USEGLYPHCHARS
        /// </summary>
        [Obsolete]
        MB_USEGLYPHCHARS = 0x00000004,

        /// <summary>
        /// MB_ERR_INVALID_CHARS
        /// </summary>
        MB_ERR_INVALID_CHARS = 0x00000008,

        /// <summary>
        /// WC_COMPOSITECHECK
        /// </summary>
        WC_COMPOSITECHECK =  0x00000200 ,

        /// <summary>
        /// WC_DISCARDNS
        /// </summary>
        WC_DISCARDNS =      0x00000010 ,

        /// <summary>
        /// WC_SEPCHARS
        /// </summary>
        WC_SEPCHARS =  0x00000020 ,

        /// <summary>
        /// WC_DEFAULTCHAR
        /// </summary>
        WC_DEFAULTCHAR = 0x00000040,

        /// <summary>
        /// WC_ERR_INVALID_CHARS
        /// </summary>
        WC_ERR_INVALID_CHARS =   0x00000080 ,

        /// <summary>
        /// WC_NO_BEST_FIT_CHARS
        /// </summary>
        WC_NO_BEST_FIT_CHARS =   0x00000400,
    }
}
