using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Shell link get path flags
    /// </summary>
    [Flags]
    public enum ShellLinkGetPathFlags
    {
        /// <summary>
        /// SLGP_SHORTPATH
        /// </summary>
        SLGP_SHORTPATH = 0x1,

        /// <summary>
        /// SLGP_UNCPRIORITY
        /// </summary>
        SLGP_UNCPRIORITY = 0x2,

        /// <summary>
        /// SLGP_RAWPATH
        /// </summary>
        SLGP_RAWPATH = 0x4,

        /// <summary>
        /// SLGP_RELATIVEPRIORITY
        /// </summary>
        SLGP_RELATIVEPRIORITY = 0x8
    }
}
