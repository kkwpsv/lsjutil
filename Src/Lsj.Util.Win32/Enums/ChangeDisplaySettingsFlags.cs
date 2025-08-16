using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="ChangeDisplaySettings"/> and <see cref="ChangeDisplaySettingsEx"/> flags
    /// </summary>
    public enum ChangeDisplaySettingsFlags : uint
    {
        /// <summary>
        /// CDS_FULLSCREEN
        /// </summary>
        CDS_FULLSCREEN = 0x00000004,

        /// <summary>
        /// CDS_GLOBAL
        /// </summary>
        CDS_GLOBAL = 0x00000008,

        /// <summary>
        /// CDS_NORESET
        /// </summary>
        CDS_NORESET = 0x10000000,

        /// <summary>
        /// CDS_RESET
        /// </summary>
        CDS_RESET = 0x40000000,

        /// <summary>
        /// CDS_SET_PRIMARY
        /// </summary>
        CDS_SET_PRIMARY = 0x00000010,

        /// <summary>
        /// CDS_TEST
        /// </summary>
        CDS_TEST = 0x00000002,

        /// <summary>
        /// CDS_UPDATEREGISTRY
        /// </summary>
        CDS_UPDATEREGISTRY = 0x00000001,

        /// <summary>
        /// CDS_VIDEOPARAMETERS
        /// </summary>
        CDS_VIDEOPARAMETERS = 0x00000020,

        /// <summary>
        /// CDS_ENABLE_UNSAFE_MODES
        /// </summary>
        CDS_ENABLE_UNSAFE_MODES = 0x00000100,

        /// <summary>
        /// CDS_DISABLE_UNSAFE_MODES
        /// </summary>
        CDS_DISABLE_UNSAFE_MODES = 0x00000200,
    }
}
