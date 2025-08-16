using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Multi byte conversion types
    /// </summary>
    [Flags]
    public enum MultiByteConversionTypes : uint
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
    }
}
