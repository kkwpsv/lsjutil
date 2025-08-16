using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Composition window position styles
    /// </summary>
    [Flags]
    public enum CompositionWindowPositionStyles
    {
        /// <summary>
        /// CFS_DEFAULT
        /// </summary>
        CFS_DEFAULT = 0x0000,

        /// <summary>
        /// CFS_RECT
        /// </summary>
        CFS_RECT = 0x0001,

        /// <summary>
        /// CFS_POINT
        /// </summary>
        CFS_POINT = 0x0002,

        /// <summary>
        /// CFS_FORCE_POSITION
        /// </summary>
        CFS_FORCE_POSITION = 0x0020,

        /// <summary>
        /// CFS_CANDIDATEPOS
        /// </summary>
        CFS_CANDIDATEPOS = 0x0040,

        /// <summary>
        /// CFS_EXCLUDE
        /// </summary>
        CFS_EXCLUDE = 0x0080,
    }
}
