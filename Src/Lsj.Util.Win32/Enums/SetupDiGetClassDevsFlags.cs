using static Lsj.Util.Win32.SetupAPI;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetupDiGetClassDevs"/> flags
    /// </summary>
    public enum SetupDiGetClassDevsFlags : uint
    {
        /// <summary>
        /// DIGCF_DEFAULT
        /// </summary>
        DIGCF_DEFAULT = 0x00000001,

        /// <summary>
        /// DIGCF_PRESENT
        /// </summary>
        DIGCF_PRESENT = 0x00000002,

        /// <summary>
        /// DIGCF_ALLCLASSES
        /// </summary>
        DIGCF_ALLCLASSES = 0x00000004,

        /// <summary>
        /// DIGCF_PROFILE
        /// </summary>
        DIGCF_PROFILE = 0x00000008,

        /// <summary>
        /// DIGCF_DEVICEINTERFACE
        /// </summary>
        DIGCF_DEVICEINTERFACE = 0x00000010,
    }
}
