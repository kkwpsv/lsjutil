using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="LOCALMANAGEDAPPLICATION"/> structure describes a managed application installed for a user or a computer.
    /// Returned by the <see cref="GetLocalManagedApplications"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/ns-appmgmt-localmanagedapplication"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOCALMANAGEDAPPLICATION
    {
        /// <summary>
        /// This is a Unicode string that gives the user friendly name of the application as it appears in the Application Deployment Editor (ADE).
        /// </summary>
        public IntPtr pszDeploymentName;

        /// <summary>
        /// This is the user-friendly name of the group policy object (GPO) from which the application originates.
        /// </summary>
        public IntPtr pszPolicyName;

        /// <summary>
        /// This is a Unicode string that gives the Windows Installer product code GUID for the application.
        /// </summary>
        public IntPtr pszProductId;

        /// <summary>
        /// <para>
        /// Indicates the state of the installed application.
        /// This parameter can contain one or more of the following values.
        /// </para>
        /// <para>
        /// <see cref="LOCAL_STATE_ASSIGNED"/>
        /// </para>
        /// <para>
        /// The application is installed in the assigned state.
        /// </para>
        /// <para>
        /// <see cref="LOCAL_STATE_PUBLISHED"/>
        /// </para>
        /// <para>
        /// The application is installed in the published state.
        /// </para>
        /// <para>
        /// <see cref="LOCAL_STATE_UNINSTALL_UNMANAGED"/>
        /// </para>
        /// <para>
        /// The installation of this application uninstalled an unmanaged application with a conflicting transform.
        /// </para>
        /// <para>
        /// <see cref="LOCAL_STATE_POLICYREMOVE_ORPHAN"/>
        /// </para>
        /// <para>
        /// If the policy from which this application originates is removed, the application is left on the computer.
        /// </para>
        /// <para>
        /// <see cref="LOCAL_STATE_POLICYREMOVE_UNINSTALL"/>
        /// </para>
        /// <para>
        /// If the policy from which this application originates is removed, the application is uninstalled from the computer.
        /// </para>
        /// </summary>
        public DWORD dwState;
    }
}
