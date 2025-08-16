using static Lsj.Util.Win32.SetupAPI;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="SetupDiOpenDeviceInfo"/> flags
    /// </summary>
    public enum SetupDiOpenDeviceInfoFlags : uint
    {
        /// <summary>
        /// DIOD_INHERIT_CLASSDRVS
        /// </summary>
        DIOD_INHERIT_CLASSDRVS = 0x00000002,

        /// <summary>
        /// DIOD_CANCEL_REMOVE
        /// </summary>
        DIOD_CANCEL_REMOVE = 0x0000000,
    }
}
