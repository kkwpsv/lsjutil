using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Security enables you to control access to window station objects.
    /// For more information about security, see Access-Control Model.
    /// </para>
    /// <para>
    /// You can specify a security descriptor for a window station object when you call the <see cref="CreateWindowStation"/> function.
    /// If you specify NULL, the window station gets a default security descriptor.
    /// The ACLs in the default security descriptor for a window station come from the primary or impersonation token of the creator.
    /// </para>
    /// <para>
    /// To get or set the security descriptor of a window station object,
    /// call the <see cref="GetSecurityInfo"/> and <see cref="SetSecurityInfo"/> functions.
    /// </para>
    /// <para>
    /// When you call the <see cref="OpenWindowStation"/> function,
    /// the system checks the requested access rights against the object's security descriptor.
    /// </para>
    /// <para>
    /// The valid access rights for window station objects include the standard access rights and some object-specific access rights.
    /// The following table lists the standard access rights used by all objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/winstation/window-station-security-and-access-rights"/>
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
        /// Required to read the attributes of a window station object.
        /// This attribute includes color settings and other global window station properties.
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
