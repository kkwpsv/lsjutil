using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.INSTALLSPECTYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="INSTALLSPEC"/> structure specifies a group policy application
    /// by its user-friendly name and group policy GUID or by its file name extension.
    /// The <see cref="INSTALLDATA.Spec"/> member of the <see cref="INSTALLDATA"/> structure
    /// provides this information to the <see cref="InstallApplication"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-installspec"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INSTALLSPEC
    {
        /// <summary>
        /// Structure that contains the following members.
        /// </summary>
        public INSTALLSPEC_AppName AppName;

        /// <summary>
        /// <para>
        /// The file name extension, such as .jpg, of the application to be installed.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="InstallApplication"/> fails if the <see cref="INSTALLDATA.Type"/> member
        /// of <see cref="INSTALLDATA"/> equals <see cref="FILEEXT"/>
        /// and there is no application deployed to the user with this file name extension.
        /// </para>
        /// </summary>
        public P<WCHAR> FileExt;

        /// <summary>
        /// This parameter is reserved and should not be used.
        /// </summary>
        public P<WCHAR> ProgId;

        /// <summary>
        /// This parameter is reserved and should not be used.
        /// </summary>
        public INSTALLSPEC_COMClass COMClass;

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct INSTALLSPEC_AppName
        {
            /// <summary>
            /// The user-friendly name of the application as it appears in Add or Remove Programs and the Group Policy Object Editor.
            /// You can obtain the name by calling <see cref="GetManagedApplications"/>.
            /// </summary>
            public P<WCHAR> Name;

            /// <summary>
            /// The <see cref="GUID"/> for the group policy object in which the application exists.
            /// You can obtain the group policy object <see cref="GUID"/> by calling <see cref="GetManagedApplications"/>.
            /// </summary>
            public GUID GPOId;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct INSTALLSPEC_COMClass
        {
            /// <summary>
            /// This parameter is reserved and should not be used.
            /// </summary>
            public GUID Clsid;

            /// <summary>
            /// This parameter is reserved and should not be used.
            /// </summary>
            public DWORD ClsCtx;
        }
    }
}
