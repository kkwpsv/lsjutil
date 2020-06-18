using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Drawing Flags
    /// </summary>
    [Flags]
    public enum DrawingFlags : uint
    {
        /// <summary>
        /// DI_MASK
        /// </summary>
        DI_MASK = 0x0001,

        /// <summary>
        /// DI_IMAGE
        /// </summary>
        DI_IMAGE = 0x0002,

        /// <summary>
        /// DI_NORMAL
        /// </summary>
        DI_NORMAL = 0x0003,

        /// <summary>
        /// DI_COMPAT
        /// </summary>
        DI_COMPAT = 0x0004,

        /// <summary>
        /// DI_DEFAULTSIZE
        /// </summary>
        DI_DEFAULTSIZE = 0x0008,

        /// <summary>
        /// DI_NOMIRROR
        /// </summary>
        DI_NOMIRROR = 0x0010,
    }
}
