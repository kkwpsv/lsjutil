using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="MANAGEDAPPLICATION"/> structure contains information about an application.
    /// The function <see cref="GetManagedApplications"/> returns an array of <see cref="MANAGEDAPPLICATION"/> structures.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-managedapplication"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MANAGEDAPPLICATION
    {
        /// <summary>
        /// The user-friendly name of the application.
        /// </summary>
        public IntPtr pszPackageName;

        /// <summary>
        /// The name of the application's publisher.
        /// </summary>
        public IntPtr pszPublisher;

        /// <summary>
        /// The major version number of the application.
        /// </summary>
        public DWORD dwVersionHi;

        /// <summary>
        /// The minor version number of the application.
        /// </summary>
        public DWORD dwVersionLo;

        /// <summary>
        /// The version number of the deployment.
        /// The version changes each time an application gets patched.
        /// </summary>
        public DWORD dwRevision;

        /// <summary>
        /// The GUID of the GPO from which this application is deployed.
        /// </summary>
        public GUID GpoId;

        /// <summary>
        /// The user-friendly name for the GPO from which this application is deployed.
        /// </summary>
        public IntPtr pszPolicyName;

        /// <summary>
        /// If this application is installed by Windows Installer, this member is the ProductId GUID.
        /// </summary>
        public GUID ProductId;

        /// <summary>
        /// The numeric language identifier that indicates the language version of the application.
        /// For a list of language numeric identifiers, see the Language Identifier Constants and Strings topic.
        /// </summary>
        public LANGID Language;

        /// <summary>
        /// This member is unused.
        /// </summary>
        public IntPtr pszOwner;

        /// <summary>
        /// This member is unused.
        /// </summary>
        public IntPtr pszCompany;

        /// <summary>
        /// This member is unused.
        /// </summary>
        public IntPtr pszComments;

        /// <summary>
        /// This member is unused.
        /// </summary>
        public IntPtr pszContact;

        /// <summary>
        /// This member is unused.
        /// </summary>
        public IntPtr pszSupportUrl;

        /// <summary>
        /// <para>
        /// Indicates the type of package used to install the application.
        /// This member can have one of the following values.
        /// </para>
        /// <para>
        /// <see cref="MANAGED_APPTYPE_WINDOWSINSTALLER"/>
        /// </para>
        /// <para>
        /// The application is installed using the Windows Installer.
        /// </para>
        /// <para>
        /// <see cref="MANAGED_APPTYPE_SETUPEXE"/>
        /// </para>
        /// <para>
        /// The application is installed using a legacy setup application.
        /// </para>
        /// <para>
        /// <see cref="MANAGED_APPTYPE_UNSUPPORTED"/>
        /// </para>
        /// <para>
        /// The application is installed by an unsupported setup application.
        /// </para>
        /// </summary>
        public DWORD dwPathType;

        /// <summary>
        /// This parameter is <see cref="TRUE"/> if the application is currently installed and is <see cref="FALSE"/> otherwise.
        /// </summary>
        public BOOL bInstalled;
    }
}
