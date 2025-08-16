using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Wlan access rights
    /// </summary>
    public enum WlanAccessRights : uint
    {
        /// <summary>
        /// WLAN_READ_ACCESS
        /// </summary>
        WLAN_READ_ACCESS = StandardAccessRights.STANDARD_RIGHTS_READ | FILE_READ_DATA,

        /// <summary>
        /// WLAN_EXECUTE_ACCESS
        /// </summary>
        WLAN_EXECUTE_ACCESS = WLAN_READ_ACCESS | STANDARD_RIGHTS_EXECUTE | FILE_EXECUTE,

        /// <summary>
        /// WLAN_WRITE_ACCESS
        /// </summary>
        WLAN_WRITE_ACCESS = WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS | StandardAccessRights.STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | DELETE | WRITE_DAC,
    }
}
