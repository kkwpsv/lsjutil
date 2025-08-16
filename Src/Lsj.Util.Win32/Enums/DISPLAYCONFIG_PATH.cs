using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// DISPLAYCONFIG_PATH
    /// </summary>
    [Flags]
    public enum DISPLAYCONFIG_PATH : uint
    {
        /// <summary>
        /// DISPLAYCONFIG_PATH_ACTIVE
        /// </summary>
        DISPLAYCONFIG_PATH_ACTIVE = 0x00000001,

        /// <summary>
        /// DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE
        /// </summary>
        DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE = 0x00000008,

        /// <summary>
        /// DISPLAYCONFIG_PATH_BOOST_REFRESH_RATE
        /// </summary>
        DISPLAYCONFIG_PATH_BOOST_REFRESH_RATE = 0x00000010,
    }
}
