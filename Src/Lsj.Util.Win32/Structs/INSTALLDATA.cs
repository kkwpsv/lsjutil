using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="INSTALLDATA"/> structure specifies a group-policy application to be installed by <see cref="InstallApplication"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-installdata"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INSTALLDATA
    {
        /// <summary>
        /// Defines how <see cref="Spec"/> specifies the application to <see cref="InstallApplication"/>.
        /// <see cref="Type"/> can be one of the <see cref="INSTALLSPECTYPE"/> enumeration values.
        /// Set <see cref="Type"/> to APPNAME to install an application specified by its user-friendly name and GPO GUID. 
        /// Set <see cref="Type"/> to FILEEXT to install an application specified by its file name extension.
        /// </summary>
        public INSTALLSPECTYPE Type;

        /// <summary>
        /// An <see cref="INSTALLSPEC"/> structure that specifies the application.
        /// </summary>
        public INSTALLSPEC Spec;
    }
}
