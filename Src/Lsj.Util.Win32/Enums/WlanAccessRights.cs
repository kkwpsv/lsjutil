using static Lsj.Util.Win32.Enums.FileAccessRights;
using static Lsj.Util.Win32.Enums.StandardAccessRights;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Wlan Access Rights
    /// </summary>
    public enum WlanAccessRights : uint
    {
        /// <summary>
        /// The user can view the contents of the profile.
        /// </summary>
        WLAN_READ_ACCESS = StandardAccessRights.STANDARD_RIGHTS_READ | FILE_READ_DATA,

        /// <summary>
        /// The user has read access, and the user can also connect to and disconnect from a network using the profile.
        /// If a user has <see cref="WLAN_EXECUTE_ACCESS"/>, then the user also has <see cref="WLAN_READ_ACCESS"/>.
        /// </summary>
        WLAN_EXECUTE_ACCESS = WLAN_READ_ACCESS | STANDARD_RIGHTS_EXECUTE | FILE_EXECUTE,

        /// <summary>
        /// The user has execute access and the user can also modify the content of the profile or delete the profile.
        /// If a user has <see cref="WLAN_WRITE_ACCESS"/>, then the user also has <see cref="WLAN_EXECUTE_ACCESS"/> and <see cref="WLAN_READ_ACCESS"/>.
        /// </summary>
        WLAN_WRITE_ACCESS = WLAN_READ_ACCESS | WLAN_EXECUTE_ACCESS | StandardAccessRights.STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | DELETE | WRITE_DAC,
    }
}
