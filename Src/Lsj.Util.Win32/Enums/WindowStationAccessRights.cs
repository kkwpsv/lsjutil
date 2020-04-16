using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Window Station Access Rights
    /// The valid access rights for window station objects include the standard access rights and some object-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// <see cref="DELETE"/>, <see cref="READ_CONTROL"/>, <see cref="SYNCHRONIZE"/>, <see cref="WRITE_DAC"/>, <see cref="WRITE_OWNER"/>
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winstation/window-station-security-and-access-rights
    /// </para>
    /// </summary>
    public enum WindowStationAccessRights : uint
    {
        /// <summary>
        /// All possible access rights for the window station.
        /// </summary>
        WINSTA_ALL_ACCESS = 0x37F,

        /// <summary>
        /// Required to use the clipboard.
        /// </summary>
        WINSTA_ACCESSCLIPBOARD = 0x0004,

        /// <summary>
        /// Required to manipulate global atoms.
        /// </summary>
        WINSTA_ACCESSGLOBALATOMS = 0x0020,

        /// <summary>
        /// Required to create new desktop objects on the window station.
        /// </summary>
        WINSTA_CREATEDESKTOP = 0x0008,

        /// <summary>
        /// Required to enumerate existing desktop objects.
        /// </summary>
        WINSTA_ENUMDESKTOPS = 0x0001,

        /// <summary>
        /// Required for the window station to be enumerated.
        /// </summary>
        WINSTA_ENUMERATE = 0x0100,

        /// <summary>
        /// Required to successfully call the <see cref="ExitWindows"/> or <see cref="ExitWindowsEx"/> function.
        /// Window stations can be shared by users and this access type can prevent other users of a window station
        /// from logging off the window station owner.
        /// </summary>
        WINSTA_EXITWINDOWS = 0x0040,

        /// <summary>
        /// Required to read the attributes of a window station object. This attribute includes color settings and other global window station properties.
        /// </summary>
        WINSTA_READATTRIBUTES = 0x0002,

        /// <summary>
        /// Required to access screen contents.
        /// </summary>
        WINSTA_READSCREEN = 0x0200,

        /// <summary>
        /// Required to modify the attributes of a window station object.
        /// The attributes include color settings and other global window station properties.
        /// </summary>
        WINSTA_WRITEATTRIBUTES = 0x0010,
    }
}
