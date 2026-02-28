using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="GetLocalManagedApplications"/> function can be run on the target computer
        /// to get a list of managed applications on that computer.
        /// The function can also be called in the context of a user to get a list of managed applications for that user.
        /// This function only returns applications that can be installed by the Windows Installer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/nf-appmgmt-getlocalmanagedapplications"/>
        /// </para>
        /// </summary>
        /// <param name="bUserApps">
        /// A value that, if <see cref="TRUE"/>, the <paramref name="prgLocalApps"/> parameter
        /// contains a list of managed applications that applies to the user.
        /// If the value of this parameter is <see cref="FALSE"/>,
        /// the <paramref name="prgLocalApps"/> parameter contains a list of managed applications that applies to the local computer.
        /// </param>
        /// <param name="pdwApps">
        /// The address of a <see cref="DWORD"/> that specifies the number of applications in the list returned by <paramref name="prgLocalApps"/>.
        /// </param>
        /// <param name="prgLocalApps">
        /// The address of an array that contains the list of managed applications.
        /// You must call <see cref="LocalFree"/> to free this array when its contents are no longer required.
        /// This parameter cannot be null.
        /// The list is returned as a <see cref="LOCALMANAGEDAPPLICATION"/> structure.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// Otherwise, the function returns one of the system error codes.
        /// For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLocalManagedApplications", ExactSpelling = true)]
        public static extern DWORD GetLocalManagedApplications([In] BOOL bUserApps, [Out] out DWORD pdwApps,
            [Out] out P<LOCALMANAGEDAPPLICATION> prgLocalApps);

        /// <summary>
        /// <para>
        /// The <see cref="GetManagedApplications"/> function gets a list of applications
        /// that are displayed in the <c>Add</c> pane of <c>Add/Remove Programs (ARP)</c> for a specified user context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/nf-appmgmt-getmanagedapplications"/>
        /// </para>
        /// </summary>
        /// <param name="pCategory">
        /// A pointer to a GUID that specifies the category of applications to be listed.
        /// If <paramref name="pCategory"/> is not <see cref="NullRef{GUID}"/>,
        /// <paramref name="dwQueryFlags"/> must contain <see cref="MANAGED_APPS_FROMCATEGORY"/>.
        /// If <paramref name="pCategory"/> is <see cref="NullRef{GUID}"/>,
        /// <paramref name="dwQueryFlags"/> cannot contain <see cref="MANAGED_APPS_FROMCATEGORY"/>.
        /// </param>
        /// <param name="dwQueryFlags">
        /// <para>
        /// This parameter can contain one or more of the following values.
        /// </para>
        /// <para>
        /// <see cref="MANAGED_APPS_USERAPPLICATIONS"/>
        /// </para>
        /// <para>
        /// Lists all applications that apply to the user.
        /// The parameter <paramref name="pCategory"/> must be <see cref="NullRef{GUID}"/>.
        /// </para>
        /// <para>
        /// <see cref="MANAGED_APPS_FROMCATEGORY"/>
        /// </para>
        /// <para>
        /// Lists only applications in the category specified by <paramref name="pCategory"/>.
        /// The <paramref name="pCategory"/> parameter cannot be <see cref="NullRef{GUID}"/>.
        /// </para>
        /// </param>
        /// <param name="dwInfoLevel">
        /// This parameter must be <see cref="MANAGED_APPS_INFOLEVEL_DEFAULT"/>.
        /// </param>
        /// <param name="pdwApps">
        /// The count of applications in the list returned by this function.
        /// </param>
        /// <param name="prgManagedApps">
        /// This parameter is a pointer to an array of <see cref="MANAGEDAPPLICATION"/> structures.
        /// This array contains the list of applications listed in the <c>Add</c> pane of <c>Add/Remove Programs</c> (ARP).
        /// You must call <see cref="LocalFree"/> to free the array when they array is no longer required.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// Otherwise, the function returns one of the system error codes.
        /// For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetManagedApplications", ExactSpelling = true)]
        public static extern DWORD GetManagedApplications([In] in GUID pCategory, [In] DWORD dwQueryFlags, [In] DWORD dwInfoLevel,
            [Out] out DWORD pdwApps, [Out] out P<MANAGEDAPPLICATION> prgManagedApps);

        /// <summary>
        /// <para>
        /// The <see cref="InstallApplication"/> function can install applications
        /// that have been deployed to target users that belong to a domain.
        /// The security context of the user that is calling <see cref="InstallApplication"/>
        /// must be that of a domain user logged onto a computer in a domain that trusts the target user's domain.
        /// Group Policy must be successfully applied when the target user logs on.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/nf-appmgmt-installapplication"/>
        /// </para>
        /// </summary>
        /// <param name="pInstallInfo">
        /// A pointer to a <see cref="INSTALLDATA"/> structure that specifies the application to install.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// Otherwise, the function returns one of the system error codes.
        /// For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="InstallApplication"/> function can only install applications that have been deployed by using Group Policy.
        /// A domain administrator can deploy applications to target users
        /// by using the user configuration section of Group Policy Objects (GPO).
        /// The target user must belong to the target domain and the GPO must apply to this user in the target domain.
        /// The <see cref="InstallApplication"/> function installs applications according to standard Group Policy inheritance rules.
        /// If the same application is deployed in multiple GPOs,
        /// the function installs the version of the application deployed in the highest precedence GPO.
        /// After an application has been installed for a user, it is not visible to other users on the computer.
        /// This is standard for applications that are deployed through user group policy.
        /// </para>
        /// <para>
        /// The <see cref="InstallApplication"/> function can install deployed applications
        /// that use Windows Installer (.msi files) or software installation settings (.zap files) to handle setup and installation.
        /// </para>
        /// <para>
        /// The <see cref="InstallApplication"/> function can install applications
        /// that use a Windows Installer package for their installation.
        /// In this case, the user calling <see cref="InstallApplication"/> is not required to have administrator privileges.
        /// The system can install the application because the Windows Installer is a trusted application deployed by a domain administrator.
        /// The user that receives the application must have access to the location of the .msi files.
        /// </para>
        /// <para>
        /// Remove applications installed using .msi files
        /// by calling the Windows Installer function <see cref="MsiConfigureProduct"/> to uninstall the application.
        /// Then call <see cref="UninstallApplication"/> to inform the system
        /// that the application is no longer managed on the client by Group Policy.
        /// <see cref="UninstallApplication"/> should be called even if the uninstall fails
        /// because this enables the system to keep the Resultant Set of Policy (RSoP) accurate.
        /// </para>
        /// <para>
        /// The <see cref="InstallApplication"/> function can also install applications
        /// that use setup applications based on software installation settings (.zap files).
        /// The user that receives the application must have access to the location of the .zap files.
        /// A .zap file is a text file similar to an .ini file,
        /// which enables Windows to publish an application (for example, Setup.exe) for installation with Add or Remove Programs.
        /// To publish applications that do not use the Windows Installer,
        /// you must create a .zap file, copy the .zap file to the software distribution point servers,
        /// and then use Group Policy–based software deployment to publish the application for users.
        /// If the application is deployed using .zap files,
        /// the user installing the application must have privileges on the machine to install the software.
        /// You cannot use .zap files for assigned applications.
        /// </para>
        /// <para>
        /// Remove applications using software installation settings (.zap files)
        /// by calling the uninstall function or a command specific for the installation application.
        /// </para>
        /// <para>
        /// For information about using installation applications other than the Windows Installer see article 231747,
        /// "How to Publish non-MSI Programs with .zap Files," in the Microsoft Knowledge Base.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "InstallApplication", ExactSpelling = true)]
        public static extern DWORD InstallApplication([In] in INSTALLDATA pInstallInfo);

        /// <summary>
        /// <para>
        /// The <see cref="UninstallApplication"/> function uninstalls a group policy application
        /// that handles setup and installation using Windows Installer .msi files.
        /// The <see cref="UninstallApplication"/> function should only be called in the context of the user
        /// for whom the user group policy application has previously attempted an uninstall
        /// by calling the <see cref="MsiConfigureProduct"/> function.
        /// The <see cref="InstallApplication"/> function can install group policy applications.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Failure to call <see cref="UninstallApplication"/> as part of the protocol
        /// for uninstalling a group policy-based application can cause the Resultant Set of Policy (RSoP) to indicate inaccurate information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/appmgmt/nf-appmgmt-uninstallapplication"/>
        /// </para>
        /// </summary>
        /// <param name="ProductCode">
        /// The Windows Installer product code of the product being uninstalled.
        /// The product code of the application should be provided in the form of a Windows Installer GUID as a string with braces.
        /// </param>
        /// <param name="dwStatus">
        /// The status of the uninstall attempt.
        /// The <paramref name="dwStatus"/> parameter is the Windows success code of the uninstall attempt
        /// returned by <see cref="MsiConfigureProduct"/>.
        /// The system can use this to ensure that the Resultant Set of Policy (RSoP) indicates whether the uninstall failed or succeeded.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>.
        /// Otherwise, the function returns one of the system error codes.
        /// For a complete list of error codes, see System Error Codes or the header file WinError.h.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Remove a group policy application that uses .msi files
        /// by calling the Windows Installer function <see cref="MsiConfigureProduct"/> to uninstall the application.
        /// Then call <see cref="UninstallApplication"/> to inform the system
        /// that the application is no longer managed on the client by Group Policy.
        /// <see cref="UninstallApplication"/> should be called even if the uninstall fails
        /// because this enables the system to keep the Resultant Set of Policy (RSoP) accurate.
        /// </para>
        /// <para>
        /// Remove applications installed using software installation settings (.zap files)
        /// by calling the uninstall function or command specific for the installation application.
        /// For information about using installation applications other than the Windows Installer see article 231747,
        /// "How to Publish non-MSI Programs with .zap Files," in the Microsoft Knowledge Base.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UninstallApplication", ExactSpelling = true)]
        public static extern DWORD UninstallApplication([In] LPWSTR ProductCode, [In] DWORD dwStatus);
    }
}
