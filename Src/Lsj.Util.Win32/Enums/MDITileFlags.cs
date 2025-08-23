using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// MDI tile flags
    /// </summary>
    [Flags]
    public enum MDITileFlags : uint
    {
        /// <summary>
        /// MDITILE_VERTICAL
        /// </summary>
        MDITILE_VERTICAL = 0x0000,

        /// <summary>
        /// MDITILE_HORIZONTAL
        /// </summary>
        MDITILE_HORIZONTAL = 0x0001,

        /// <summary>
        /// MDITILE_SKIPDISABLED
        /// </summary>
        MDITILE_SKIPDISABLED = 0x0002,
    }
}
