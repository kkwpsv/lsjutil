using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="INSTALLSPECTYPE"/> enumeration values define the ways
    /// a group policy application can be specified to the <see cref="InstallApplication"/> function.
    /// The values are used in the <see cref="INSTALLDATA.Type"/> member of <see cref="INSTALLDATA"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/ne-appmgmt-installspectype"/>
    /// </para>
    /// </summary>
    public enum INSTALLSPECTYPE
    {
        /// <summary>
        /// This constant equals 1.
        /// The application is specified by its display name and group policy GUID.
        /// </summary>
        APPNAME = 1,

        /// <summary>
        /// The application is specified by its file name extension, for example, .jpg.
        /// </summary>
        FILEEXT,

        /// <summary>
        /// 
        /// </summary>
        PROGID,

        /// <summary>
        /// 
        /// </summary>
        COMCLASS
    }
}
