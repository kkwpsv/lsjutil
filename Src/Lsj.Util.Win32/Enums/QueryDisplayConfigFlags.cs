using System;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="QueryDisplayConfig"/> Flags
    /// </summary>
    [Flags]
    public enum QueryDisplayConfigFlags : uint
    {
        /// <summary>
        /// QDC_ALL_PATHS
        /// </summary>
        QDC_ALL_PATHS = 0x00000001,

        /// <summary>
        /// QDC_ONLY_ACTIVE_PATHS
        /// </summary>
        QDC_ONLY_ACTIVE_PATHS = 0x00000002,

        /// <summary>
        /// QDC_DATABASE_CURRENT
        /// </summary>
        QDC_DATABASE_CURRENT = 0x00000004,

        /// <summary>
        /// QDC_VIRTUAL_MODE_AWARE
        /// </summary>
        QDC_VIRTUAL_MODE_AWARE = 0x00000010,

        /// <summary>
        /// QDC_INCLUDE_HMD
        /// </summary>
        QDC_INCLUDE_HMD = 0x00000020,

        /// <summary>
        /// QDC_VIRTUAL_REFRESH_RATE_AWARE
        /// </summary>
        QDC_VIRTUAL_REFRESH_RATE_AWARE = 0x00000040,
    }
}
