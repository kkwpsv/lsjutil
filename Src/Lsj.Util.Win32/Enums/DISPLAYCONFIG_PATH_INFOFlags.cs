using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DISPLAYCONFIG_PATH_INFO"/> Flags
    /// </summary>
    public enum DISPLAYCONFIG_PATH_INFOFlags : uint
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
