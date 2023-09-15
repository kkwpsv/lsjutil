using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="DISPLAYCONFIG_PATH_TARGET_INFO"/> Flags
    /// </summary>
    public enum DISPLAYCONFIG_PATH_TARGET_INFOFlags
    {
        /// <summary>
        /// DISPLAYCONFIG_TARGET_IN_USE
        /// </summary>
        DISPLAYCONFIG_TARGET_IN_USE = 0x00000001,

        /// <summary>
        /// DISPLAYCONFIG_TARGET_FORCIBLE
        /// </summary>
        DISPLAYCONFIG_TARGET_FORCIBLE = 0x00000002,

        /// <summary>
        /// DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT
        /// </summary>
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT = 0x00000004,

        /// <summary>
        /// DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH
        /// </summary>
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH = 0x00000008,

        /// <summary>
        /// DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM
        /// </summary>
        DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM = 0x00000010,

        /// <summary>
        /// DISPLAYCONFIG_TARGET_IS_HMD
        /// </summary>
        DISPLAYCONFIG_TARGET_IS_HMD = 0x00000020,
    }
}
