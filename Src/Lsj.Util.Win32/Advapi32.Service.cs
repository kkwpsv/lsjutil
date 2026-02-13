using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Constants;
using Lsj.Util.Win32.Structs;
using System.Reflection;
using System;

namespace Lsj.Util.Win32
{
    public static partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// Changes the configuration parameters of a service.
        /// </para>
        /// <para>
        /// To change the optional configuration parameters, use the <see cref="ChangeServiceConfig2"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-changeserviceconfigw"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function
        /// and must have the <see cref="SERVICE_CHANGE_CONFIG"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwServiceType">
        /// <para>
        /// The type of service.
        /// Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing service type;
        /// otherwise, specify one of the following service types.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// File system driver service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_KERNEL_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Driver service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_OWN_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Service that runs in its own process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_SHARE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Service that shares a process with other services.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If you specify either <see cref="SERVICE_WIN32_OWN_PROCESS"/> or <see cref="SERVICE_WIN32_SHARE_PROCESS"/>,
        /// and the service is running in the context of the LocalSystem account, you can also specify the following type.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_INTERACTIVE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can interact with the desktop.
        /// </para>
        /// <para>
        /// For more information, see Interactive Services.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwStartType">
        /// <para>
        /// The service start options.
        /// Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing start type;
        /// otherwise, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_AUTO_START"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// A service started automatically by the service control manager during system startup.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_BOOT_START"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// A device driver started by the system loader.
        /// This value is valid only for driver services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_DEMAND_START"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// A service started by the service control manager
        /// when a process calls the <see cref="StartService"/> function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// A service that cannot be started.
        /// Attempts to start the service result in the error code <see cref="ERROR_SERVICE_DISABLED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_SYSTEM_START"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// A device driver started by the <see cref="IoInitSystem"/> function.
        /// This value is valid only for driver services.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwErrorControl">
        /// <para>
        /// The severity of the error, and action taken, if this service fails to start.
        /// Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing error control;
        /// otherwise, specify one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_CRITICAL"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log, if possible.
        /// If the last-known-good configuration is being started, the startup operation fails.
        /// Otherwise, the system is restarted with the last-known good configuration.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_IGNORE"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// The startup program ignores the error and continues the startup operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_NORMAL"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log but continues the startup operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_SEVERE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log.
        /// If the last-known-good configuration is being started, the startup operation continues.
        /// Otherwise, the system is restarted with the last-known-good configuration.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBinaryPathName">
        /// <para>
        /// The fully qualified path to the service binary file.
        /// Specify <see cref="NULL"/> if you are not changing the existing path. 
        /// If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// For example, "d:\my share\myservice.exe" should be specified as ""d:\my share\myservice.exe"".
        /// </para>
        /// <para>
        /// The path can also include arguments for an auto-start service.
        /// For example, "d:\myshare\myservice.exe arg1 arg2".
        /// These arguments are passed to the service entry point (typically the <c>main</c> function).
        /// </para>
        /// <para>
        /// If you specify a path on another computer,
        /// the share must be accessible by the computer account of the local computer
        /// because this is the security context used in the remote call.
        /// However, this requirement allows any potential vulnerabilities in the remote computer to affect the local computer.
        /// Therefore, it is best to use a local file.
        /// </para>
        /// </param>
        /// <param name="lpLoadOrderGroup">
        /// <para>
        /// The name of the load ordering group of which this service is a member.
        /// Specify <see cref="NULL"/> if you are not changing the existing group.
        /// Specify an empty string if the service does not belong to a group.
        /// </para>
        /// <para>
        /// The startup program uses load ordering groups to load groups of services
        /// in a specified order with respect to the other groups.
        /// The list of load ordering groups is contained in the <c>ServiceGroupOrder</c> value of the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>
        /// </para>
        /// </param>
        /// <param name="lpdwTagId">
        /// <para>
        /// A pointer to a variable that receives a tag value that is unique in the group
        /// specified in the <paramref name="lpLoadOrderGroup"/> parameter.
        /// Specify <see cref="NULL"/> if you are not changing the existing tag.
        /// </para>
        /// <para>
        /// You can use a tag for ordering service startup within a load ordering group
        /// by specifying a tag order vector in the <see cref="GroupOrderList"/> value of the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control</c>
        /// </para>
        /// <para>
        /// Tags are only evaluated for driver services
        /// that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.
        /// </para>
        /// </param>
        /// <param name="lpDependencies">
        /// <para>
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups
        /// that the system must start before this service can be started.
        /// (Dependency on a group means that this service can run
        /// if at least one member of the group is running after an attempt to start all members of the group.)
        /// Specify <see cref="NULL"/> if you are not changing the existing dependencies.
        /// Specify an empty string if the service has no dependencies.
        /// </para>
        /// <para>
        /// You must prefix group names with <see cref="SC_GROUP_IDENTIFIER"/>
        /// so that they can be distinguished from a service name, because services and service groups share the same name space.
        /// </para>
        /// </param>
        /// <param name="lpServiceStartName">
        /// <para>
        /// The name of the account under which the service should run.
        /// Specify <see cref="NULL"/> if you are not changing the existing account name.
        /// If the service type is <see cref="SERVICE_WIN32_OWN_PROCESS"/>,
        /// use an account name in the form <c>DomainName\UserName</c>.
        /// The service process will be logged on as this user.
        /// If the account belongs to the built-in domain, you can specify <c>.\UserName</c>
        /// (note that the corresponding C/C++ string is <c>".\\UserName"</c>).
        /// For more information, see Service User Accounts and the warning in the Remarks section.
        /// </para>
        /// <para>
        /// A shared process can run as any user.
        /// </para>
        /// <para>
        /// If the service type is <see cref="SERVICE_KERNEL_DRIVER"/> or <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>,
        /// the name is the driver object name that the system uses to load the device driver.
        /// Specify <see cref="NULL"/> if the driver is to use a default object name created by the I/O system.
        /// </para>
        /// <para>
        /// A service can be configured to use a managed account or a virtual account.
        /// If the service is configured to use a managed service account, the name is the managed service account name.
        /// If the service is configured to use a virtual account, specify the name as <c>NT SERVICE\ServiceName</c>.
        /// For more information about managed service accounts and virtual accounts, see the Service Accounts Step-by-Step Guide.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Managed service accounts and virtual accounts are not supported until Windows 7 and Windows Server 2008 R2.
        /// </para>
        /// </param>
        /// <param name="lpPassword">
        /// <para>
        /// The password to the account name specified by the <paramref name="lpServiceStartName"/> parameter.
        /// Specify <see cref="NULL"/> if you are not changing the existing password.
        /// Specify an empty string if the account has no password
        /// or if the service runs in the LocalService, NetworkService, or LocalSystem account.
        /// For more information, see Service Record List.
        /// </para>
        /// <para>
        /// If the account name specified by the <paramref name="lpServiceStartName"/> parameter
        /// is the name of a managed service account or virtual account name,
        /// the <paramref name="lpPassword"/> parameter must be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Passwords are ignored for driver services.
        /// </para>
        /// </param>
        /// <param name="lpDisplayName">
        /// <para>
        /// The display name to be used by applications to identify the service for its users.
        /// Specify <see cref="NULL"/> if you are not changing the existing display name;
        /// otherwise, this string has a maximum length of 256 characters.
        /// The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </para>
        /// <para>
        /// This parameter can specify a localized string using the following format:
        /// </para>
        /// <para>
        /// <c>@[path]dllname,-strID</c>
        /// </para>
        /// <para>
        /// The string with identifier <c>strID</c> is loaded from <c>dllname</c>;
        /// the <c>path</c> is optional. 
        /// For more information, see <see cref="RegLoadMUIString"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP: Localized strings are not supported until Windows Vista.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes may be set by the service control manager.
        /// Other error codes may be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SERVICE_CHANGE_CONFIG"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_CIRCULAR_DEPENDENCY"/>
        /// </term>
        /// <term>
        /// A circular service dependency was specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DUPLICATE_SERVICE_NAME"/>
        /// </term>
        /// <term>
        /// The display name already exists in the service controller manager database,
        /// either as a service name or as another display name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter that was specified is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SERVICE_ACCOUNT"/>
        /// </term>
        /// <term>
        /// The account name does not exist, or a service is specified to share the same binary file as an already installed service
        /// but with an account name that is not the same as the installed service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/>
        /// </term>
        /// <term>
        /// The service has been marked for deletion.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ChangeServiceConfig"/> function changes the configuration information
        /// for the specified service in the service control manager database.
        /// You can obtain the current configuration information by using the <see cref="QueryServiceConfig"/> function.
        /// </para>
        /// <para>
        /// If the configuration is changed for a service that is running,
        /// with the exception of <paramref name="lpDisplayName"/>,
        /// the changes do not take effect until the service is stopped.
        /// To update the credentials without having to restart the service,
        /// use the <see cref="LsaCallAuthenticationPackage"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeServiceConfigW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeServiceConfig([In] SC_HANDLE hService, [In] DWORD dwServiceType, [In] DWORD dwStartType,
            [In] DWORD dwErrorControl, [In] LPCWSTR lpBinaryPathName, [In] LPCWSTR lpLoadOrderGroup, [Out] out DWORD lpdwTagId,
            [In] LPCWSTR lpDependencies, [In] LPCWSTR lpServiceStartName, [In] LPCWSTR lpPassword, [In] LPCWSTR lpDisplayName);

        /// <summary>
        /// <para>
        /// Closes a handle to a service control manager or service object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-closeservicehandle"/>
        /// </para>
        /// </summary>
        /// <param name="hSCObject">
        /// A handle to the service control manager object or the service object to close.
        /// Handles to service control manager objects are returned by the <see cref="OpenSCManager"/> function,
        /// and handles to service objects are returned by either the <see cref="OpenService"/> or <see cref="CreateService"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error code can be set by the service control manager.
        /// Other error codes can be set by registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="CloseServiceHandle"/> function does not destroy the service control manager object referred to by the handle.
        /// A service control manager object cannot be destroyed.
        /// A service object can be destroyed by calling the <see cref="DeleteService"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseServiceHandle", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseServiceHandle([In] SC_HANDLE hSCObject);

        /// <summary>
        /// <para>
        /// Sends a control code to a service.
        /// </para>
        /// <para>
        /// To specify additional information when stopping a service, use the <see cref="ControlServiceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-controlservice"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function.
        /// The access rights required for this handle depend on the <paramref name="dwControl"/> code requested.
        /// </param>
        /// <param name="dwControl">
        /// <para>
        /// This parameter can be one of the following control codes.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Control code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_CONTINUE"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a paused service that it should resume.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_INTERROGATE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that it should report its current status information to the service control manager.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_INTERROGATE"/> access right.
        /// </para>
        /// <para>
        /// Note that this control is not generally useful as the SCM is aware of the current state of the service.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_NETBINDADD"/>
        /// </para>
        /// <para>
        /// 0x00000007
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a network service that there is a new component for binding.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// However, this control code has been deprecated; use Plug and Play functionality instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_NETBINDDISABLE"/>
        /// </para>
        /// <para>
        /// 0x0000000A
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a network service that one of its bindings has been disabled.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// However, this control code has been deprecated; use Plug and Play functionality instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_NETBINDENABLE"/>
        /// </para>
        /// <para>
        /// 0x00000009
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a network service that a disabled binding has been enabled.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// However, this control code has been deprecated; use Plug and Play functionality instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_NETBINDREMOVE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a network service that a component for binding has been removed.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// However, this control code has been deprecated; use Plug and Play functionality instead.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_PARAMCHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000006
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service that its startup parameters have changed.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_PAUSE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service that it should pause.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_STOP"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that it should stop.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_STOP"/> access right.
        /// </para>
        /// <para>
        /// After sending the stop request to a service, you should not send other controls to the service.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This value can also be a user-defined control code, as described in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Control code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// Range 128 to 255
        /// </term>
        /// <term>
        /// The service defines the action associated with the control code.
        /// The <paramref name="hService"/> handle must have the <see cref="SERVICE_USER_DEFINED_CONTROL"/> access right.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpServiceStatus">
        /// <para>
        /// A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the latest service status information.
        /// The information returned reflects the most recent status that the service reported to the service control manager.
        /// </para>
        /// <para>
        /// The service control manager fills in the structure
        /// only when <see cref="GetLastError"/> returns one of the following error codes:
        /// <see cref="NO_ERROR"/>, <see cref="ERROR_INVALID_SERVICE_CONTROL"/>,
        /// <see cref="ERROR_SERVICE_CANNOT_ACCEPT_CTRL"/>, or <see cref="ERROR_SERVICE_NOT_ACTIVE"/>.
        /// Otherwise, the structure is not filled in.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Other error codes can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the required access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DEPENDENT_SERVICES_RUNNING"/>
        /// </term>
        /// <term>
        /// The service cannot be stopped because other running services are dependent on it.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle was not obtained using <see cref="CreateService"/> or <see cref="OpenService"/>,
        /// or the handle is no longer valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// The requested control code is undefined.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SERVICE_CONTROL"/>
        /// </term>
        /// <term>
        /// The requested control code is not valid, or it is unacceptable to the service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_CANNOT_ACCEPT_CTRL"/>
        /// </term>
        /// <term>
        /// The requested control code cannot be sent to the service
        /// because the state of the service is <see cref="SERVICE_STOPPED"/>,
        /// <see cref="SERVICE_START_PENDING"/>, or <see cref="SERVICE_STOP_PENDING"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_NOT_ACTIVE"/>
        /// </term>
        /// <term>
        /// The service has not been started.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_REQUEST_TIMEOUT"/>
        /// </term>
        /// <term>
        /// The process for the service was started, but it did not call <see cref="StartServiceCtrlDispatcher"/>,
        /// or the thread that called <see cref="StartServiceCtrlDispatcher"/> may be blocked in a control handler function.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/>
        /// </term>
        /// <term>
        /// The system is shutting down.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ControlService"/> function asks the Service Control Manager (SCM)
        /// to send the requested control code to the service.
        /// The SCM sends the code if the service has specified that it will accept the code,
        /// and is in a state in which a control code can be sent to it.
        /// </para>
        /// <para>
        /// The SCM processes service control notifications in a serial fashion—
        /// it will wait for one service to complete processing a service control notification before sending the next one.
        /// Because of this, a call to <see cref="ControlService"/> will block for 30 seconds
        /// if any service is busy handling a control code.
        /// If the busy service still has not returned from its handler function when the timeout expires,
        /// <see cref="ControlService"/> fails with <see cref="ERROR_SERVICE_REQUEST_TIMEOUT"/>.
        /// </para>
        /// <para>
        /// To stop and start a service requires a security descriptor that allows you to do so.
        /// The default security descriptor allows the LocalSystem account,
        /// and members of the Administrators and Power Users groups to stop and start services.
        /// To change the security descriptor of a service, see Modifying the DACL for a Service.
        /// </para>
        /// <para>
        /// The <see cref="QueryServiceStatusEx"/> function returns a <see cref="SERVICE_STATUS_PROCESS"/> structure
        /// whose <see cref="SERVICE_STATUS_PROCESS.dwCurrentState"/> and <see cref="SERVICE_STATUS_PROCESS.dwControlsAccepted"/> members
        /// indicate the current state and controls accepted by a running service.
        /// All running services accept the <see cref="SERVICE_CONTROL_INTERROGATE"/> control code by default.
        /// Drivers do not accept control codes other than <see cref="SERVICE_CONTROL_STOP"/> and <see cref="SERVICE_CONTROL_INTERROGATE"/>.
        /// Each service specifies the other control codes that it accepts
        /// when it calls the <see cref="SetServiceStatus"/> function to report its status.
        /// A service should always accept these codes when it is running, no matter what it is doing.
        /// </para>
        /// <para>
        /// The following table shows the action of the SCM in each of the possible service states.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Service state
        /// </term>
        /// <term>
        /// Stop
        /// </term>
        /// <term>
        /// Other controls
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="STOPPED"/>
        /// </term>
        /// <term>
        /// (c)
        /// </term>
        /// <term>
        /// (c)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STOP_PENDING"/>
        /// </term>
        /// <term>
        /// (b)
        /// </term>
        /// <term>
        /// (b)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="START_PENDING"/>
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// <term>
        /// (b)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RUNNING"/>
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CONTINUE_PENDING"/>
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAUSE_PENDING"/>
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="PAUSED"/>
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// <term>
        /// (a)
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// (a)
        /// </para>
        /// <para>
        /// If the service accepts this control code, send the request to the service;
        /// otherwise, <see cref="ControlService"/> returns zero
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_SERVICE_CONTROL"/>.
        /// </para>
        /// <para>
        /// (b)
        /// </para>
        /// <para>
        /// The service is not in a state in which a control can be sent to it,
        /// so <see cref="ControlService"/> returns zero
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_SERVICE_CANNOT_ACCEPT_CTRL"/>.
        /// </para>
        /// <para>
        /// (c)
        /// </para>
        /// <para>
        /// The service is not active, so <see cref="ControlService"/> returns zero
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_SERVICE_NOT_ACTIVE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ControlService", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ControlService([In] SC_HANDLE hService, [In] DWORD dwControl, [Out] out SERVICE_STATUS lpServiceStatus);

        /// <summary>
        /// <para>
        /// Creates a service object and adds it to the specified service control manager database.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-createservicew"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function
        /// and must have the <see cref="SC_MANAGER_CREATE_SERVICE"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="lpServiceName">
        /// The name of the service to install.
        /// The maximum string length is 256 characters.
        /// The service control manager database preserves the case of the characters,
        /// but service name comparisons are always case insensitive.
        /// Forward-slash (/) and backslash (\) are not valid service name characters.
        /// </param>
        /// <param name="lpDisplayName">
        /// The display name to be used by user interface programs to identify the service.
        /// This string has a maximum length of 256 characters.
        /// The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the service.
        /// Before granting the requested access, the system checks the access token of the calling process.
        /// For a list of values, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwServiceType">
        /// <para>
        /// The service type. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ADAPTER"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// File system driver service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_KERNEL_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Driver service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_RECOGNIZER_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_OWN_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Service that runs in its own process.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_SHARE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Service that shares a process with one or more other services.
        /// For more information, see Service Programs.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If you specify either <see cref="SERVICE_WIN32_OWN_PROCESS"/> or <see cref="SERVICE_WIN32_SHARE_PROCESS"/>,
        /// and the service is running in the context of the LocalSystem account, you can also specify the following value.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_INTERACTIVE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can interact with the desktop.
        /// </para>
        /// <para>
        /// For more information, see Interactive Services.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwStartType">
        /// <para>
        /// The service start options. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_AUTO_START"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// A service started automatically by the service control manager during system startup.
        /// For more information, see Automatically Starting Services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_BOOT_START"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// A device driver started by the system loader.
        /// This value is valid only for driver services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_DEMAND_START"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// A service started by the service control manager
        /// when a process calls the <see cref="StartService"/> function.
        /// For more information, see Starting Services on Demand.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_DISABLED"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// A service that cannot be started.
        /// Attempts to start the service result in the error code <see cref="ERROR_SERVICE_DISABLED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_SYSTEM_START"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// A device driver started by the <c>IoInitSystem</c> function.
        /// This value is valid only for driver services.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwErrorControl">
        /// <para>
        /// The severity of the error, and action taken, if this service fails to start.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_CRITICAL"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log, if possible.
        /// If the last-known-good configuration is being started, the startup operation fails.
        /// Otherwise, the system is restarted with the last-known good configuration.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_IGNORE"/>
        /// </para>
        /// <para>
        /// 0x00000000
        /// </para>
        /// </term>
        /// <term>
        /// The startup program ignores the error and continues the startup operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_NORMAL"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log but continues the startup operation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ERROR_SEVERE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The startup program logs the error in the event log.
        /// If the last-known-good configuration is being started, the startup operation continues.
        /// Otherwise, the system is restarted with the last-known-good configuration.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBinaryPathName">
        /// <para>
        /// The fully qualified path to the service binary file.
        /// If the path contains a space, it must be quoted so that it is correctly interpreted.
        /// For example, "d:\my share\myservice.exe" should be specified as ""d:\my share\myservice.exe"".
        /// </para>
        /// <para>
        /// The path can also include arguments for an auto-start service.
        /// For example, "d:\myshare\myservice.exe arg1 arg2".
        /// These arguments are passed to the service entry point (typically the <c>main</c> function).
        /// </para>
        /// <para>
        /// If you specify a path on another computer, the share must be accessible by the computer account of the local computer
        /// because this is the security context used in the remote call.
        /// However, this requirement allows any potential vulnerabilities in the remote computer to affect the local computer.
        /// Therefore, it is best to use a local file.
        /// </para>
        /// </param>
        /// <param name="lpLoadOrderGroup">
        /// <para>
        /// The names of the load ordering group of which this service is a member.
        /// Specify <see cref="NULL"/> or an empty string if the service does not belong to a group.
        /// </para>
        /// <para>
        /// The startup program uses load ordering groups to load groups of services
        /// in a specified order with respect to the other groups.
        /// The list of load ordering groups is contained in the following registry value:
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\ServiceGroupOrder</c>
        /// </para>
        /// </param>
        /// <param name="lpdwTagId">
        /// <para>
        /// A pointer to a variable that receives a tag value that is unique in the group
        /// specified in the <paramref name="lpLoadOrderGroup"/> parameter.
        /// Specify <see cref="NULL"/> if you are not changing the existing tag.
        /// </para>
        /// <para>
        /// You can use a tag for ordering service startup within a load ordering group
        /// by specifying a tag order vector in the following registry value:
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList</c>
        /// </para>
        /// <para>
        /// Tags are only evaluated for driver services
        /// that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.
        /// </para>
        /// </param>
        /// <param name="lpDependencies">
        /// <para>
        /// A pointer to a double null-terminated array of null-separated names of services or load ordering groups
        /// that the system must start before this service.
        /// Specify <see cref="NULL"/> or an empty string if the service has no dependencies.
        /// Dependency on a group means that this service can run
        /// if at least one member of the group is running after an attempt to start all members of the group.
        /// </para>
        /// <para>
        /// You must prefix group names with <see cref="SC_GROUP_IDENTIFIER"/>
        /// so that they can be distinguished from a service name, because services and service groups share the same name space.
        /// </para>
        /// </param>
        /// <param name="lpServiceStartName">
        /// <para>
        /// The name of the account under which the service should run.
        /// If the service type is <see cref="SERVICE_WIN32_OWN_PROCESS"/>, use an account name in the form <c>DomainName\UserName</c>.
        /// The service process will be logged on as this user.
        /// If the account belongs to the built-in domain, you can specify <c>.\UserName</c>.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, <see cref="CreateService"/> uses the LocalSystem account.
        /// If the service type specifies <see cref="SERVICE_INTERACTIVE_PROCESS"/>, the service must run in the LocalSystem account.
        /// </para>
        /// <para>
        /// If this parameter is <c>NT AUTHORITY\LocalService</c>, <see cref="CreateService"/> uses the LocalService account.
        /// If the parameter is <c>NT AUTHORITY\NetworkService</c>, <see cref="CreateService"/> uses the NetworkService account.
        /// </para>
        /// <para>
        /// A shared process can run as any user.
        /// </para>
        /// <para>
        /// If the service type is <see cref="SERVICE_KERNEL_DRIVER"/> or <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>,
        /// the name is the driver object name that the system uses to load the device driver.
        /// Specify <see cref="NULL"/> if the driver is to use a default object name created by the I/O system.
        /// </para>
        /// <para>
        /// A service can be configured to use a managed account or a virtual account.
        /// If the service is configured to use a managed service account, the name is the managed service account name.
        /// If the service is configured to use a virtual account, specify the name as <c>NT SERVICE\ServiceName</c>.
        /// For more information about managed service accounts and virtual accounts, see the Service Accounts Step-by-Step Guide.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// Managed service accounts and virtual accounts are not supported until Windows 7 and Windows Server 2008 R2.
        /// </para>
        /// </param>
        /// <param name="lpPassword">
        /// <para>
        /// The password to the account name specified by the <paramref name="lpServiceStartName"/> parameter.
        /// Specify an empty string if the account has no password
        /// or if the service runs in the LocalService, NetworkService, or LocalSystem account.
        /// For more information, see Service Record List.
        /// </para>
        /// <para>
        /// If the account name specified by the <paramref name="lpServiceStartName"/> parameter
        /// is the name of a managed service account or virtual account name,
        /// the <paramref name="lpPassword"/> parameter must be <see cref="NULL"/>.
        /// </para>
        /// <para>
        /// Passwords are ignored for driver services.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the service.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Other error codes can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle to the SCM database does not have the <see cref="SC_MANAGER_CREATE_SERVICE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_CIRCULAR_DEPENDENCY"/>
        /// </term>
        /// <term>
        /// A circular service dependency was specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DUPLICATE_SERVICE_NAME"/>
        /// </term>
        /// <term>
        /// The display name already exists in the service control manager database either as a service name or as another display name.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle to the specified service control manager database is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_NAME"/>
        /// </term>
        /// <term>
        /// The specified service name is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter that was specified is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_SERVICE_ACCOUNT"/>
        /// </term>
        /// <term>
        /// The user account name specified in the <paramref name="lpServiceStartName"/> parameter does not exist.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_EXISTS"/>
        /// </term>
        /// <term>
        /// The specified service already exists in this database.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/>
        /// </term>
        /// <term>
        /// The specified service already exists in this database and has been marked for deletion.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateService"/> function creates a service object and installs it in the service control manager database
        /// by creating a key with the same name as the service under the following registry key:
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services</c>
        /// </para>
        /// <para>
        /// Information specified by <see cref="CreateService"/>, <see cref="ChangeServiceConfig"/>,
        /// and <see cref="ChangeServiceConfig2"/> is saved as values under this key.
        /// The following are examples of values stored for a service.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <c>DependOnGroup</c>
        /// </term>
        /// <term>
        /// Load-ordering groups on which this service depends, as specified by <paramref name="lpDependencies"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>DependOnService</c>
        /// </term>
        /// <term>
        /// Services on which this service depends, as specified by <paramref name="lpDependencies"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>Description</c>
        /// </term>
        /// <term>
        /// Description specified by <see cref="ChangeServiceConfig2"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>DisplayName</c>
        /// </term>
        /// <term>
        /// Display name specified by <paramref name="lpDisplayName"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>ErrorControl</c>
        /// </term>
        /// <term>
        /// Error control specified by <paramref name="dwErrorControl"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>FailureActions</c>
        /// </term>
        /// <term>
        /// Failure actions specified by <see cref="ChangeServiceConfig2"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>Group</c>
        /// </term>
        /// <term>
        /// Load ordering group specified by <paramref name="lpLoadOrderGroup"/>.
        /// Note that setting this value can override the setting of the <c>DependOnService</c> value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>ImagePath</c>
        /// </term>
        /// <term>
        /// Name of binary file, as specified by <paramref name="lpBinaryPathName"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>ObjectName</c>
        /// </term>
        /// <term>
        /// Account name specified by <paramref name="lpServiceStartName"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>Start</c>
        /// </term>
        /// <term>
        /// When to start service, as specified by <paramref name="dwStartType"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>Tag</c>
        /// </term>
        /// <term>
        /// Tag identifier specified by <paramref name="lpdwTagId"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <c>Type</c>
        /// </term>
        /// <term>
        /// Service type specified by <paramref name="dwServiceType"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Setup programs and the service itself can create additional subkeys for service-specific information.
        /// </para>
        /// <para>
        /// The returned handle is only valid for the process that called <see cref="CreateService"/>.
        /// It can be closed by calling the <see cref="CloseServiceHandle"/> function.
        /// </para>
        /// <para>
        /// If you are creating services that share a process,
        /// avoid calling functions with process-wide effects, such as <see cref="ExitProcess"/>.
        /// In addition, do not unload your service DLL.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateServiceW", ExactSpelling = true, SetLastError = true)]
        public static extern SC_HANDLE CreateService([In] SC_HANDLE hSCManager, [In] LPCWSTR lpServiceName, [In] LPCWSTR lpDisplayName,
            [In] DWORD dwDesiredAccess, [In] DWORD dwServiceType, [In] DWORD dwStartType, [In] DWORD dwErrorControl,
            [In] LPCWSTR lpBinaryPathName, [In] LPCWSTR lpLoadOrderGroup, [Out] out DWORD lpdwTagId,
            [In] LPCWSTR lpDependencies, [In] LPCWSTR lpServiceStartName, [In] LPCWSTR lpPassword);

        /// <summary>
        /// <para>
        /// Marks the specified service for deletion from the service control manager database.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-deleteservice"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function,
        /// and it must have the <see cref="DELETE"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes may be set by the service control manager.
        /// Others may be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="DELETE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/>
        /// </term>
        /// <term>
        /// The specified service has already been marked for deletion.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="DeleteService"/> function marks a service for deletion from the service control manager database.
        /// The database entry is not removed until all open handles to the service have been closed
        /// by calls to the <see cref="CloseServiceHandle"/> function, and the service is not running.
        /// A running service is stopped by a call to the <see cref="ControlService"/> function
        /// with the <see cref="SERVICE_CONTROL_STOP"/> control code.
        /// If the service cannot be stopped, the database entry is removed when the system is restarted.
        /// </para>
        /// <para>
        /// The service control manager deletes the service by deleting the service key and its subkeys from the registry.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteService", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteService([In] SC_HANDLE hService);

        /// <summary>
        /// <para>
        /// Retrieves the name and status of each service that depends on the specified service;
        /// that is, the specified service must be running before the dependent services can run.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumdependentservicesw"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function,
        /// and it must have the <see cref="SERVICE_ENUMERATE_DEPENDENTS"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwServiceState">
        /// <para>
        /// The state of the services to be enumerated. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates services that are in the following states: <see cref="SERVICE_START_PENDING"/>,
        /// <see cref="SERVICE_STOP_PENDING"/>, <see cref="SERVICE_RUNNING"/>, <see cref="SERVICE_CONTINUE_PENDING"/>,
        /// <see cref="SERVICE_PAUSE_PENDING"/>, and <see cref="SERVICE_PAUSED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_INACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates services that are in the <see cref="SERVICE_STOPPED"/> state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_STATE_ALL"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Combines the following states: <see cref="SERVICE_ACTIVE"/> and <see cref="SERVICE_INACTIVE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpServices">
        /// <para>
        /// A pointer to an array of <see cref="ENUM_SERVICE_STATUS"/> structures
        /// that receives the name and service status information for each dependent service in the database.
        /// The buffer must be large enough to hold the structures, plus the strings to which their members point.
        /// </para>
        /// <para>
        /// The order of the services in this array is the reverse of the start order of the services.
        /// In other words, the first service in the array is the one that would be started last,
        /// and the last service in the array is the one that would be started first.
        /// </para>
        /// <para>
        /// The maximum size of this array is 64,000 bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_MORE_DATA"/>.
        /// The <paramref name="pcbBytesNeeded"/> parameter will receive the required size.
        /// </para>
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpServices"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to store the array of service entries.
        /// The variable only receives this value if the buffer pointed to by <paramref name="lpServices"/> is too small,
        /// indicated by function failure and the <see cref="ERROR_MORE_DATA"/> error;
        /// otherwise, the contents of <paramref name="pcbBytesNeeded"/> are undefined.
        /// </param>
        /// <param name="lpServicesReturned">
        /// A pointer to a variable that receives the number of service entries returned.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes may be set by the service control manager.
        /// Other error codes may be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SERVICE_ENUMERATE_DEPENDENTS"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter that was specified is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_MORE_DATA"/>
        /// </term>
        /// <term>
        /// The buffer pointed to by <paramref name="lpServices"/> is not large enough.
        /// The function sets the variable pointed to by <paramref name="lpServicesReturned"/>
        /// to the actual number of service entries stored into the buffer.
        /// The function sets the variable pointed to by <paramref name="pcbBytesNeeded"/>
        /// to the number of bytes required to store all of the service entries.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The returned services entries are ordered in the reverse order of the start order, with group order taken into account.
        /// If you need to stop the dependent services,
        /// you can use the order of entries written to the <paramref name="lpServices"/> buffer
        /// to stop the dependent services in the proper order.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDependentServicesW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDependentServices([In] SC_HANDLE hService, [In] DWORD dwServiceState,
            [Out] ENUM_SERVICE_STATUS[]? lpServices, [In] DWORD cbBufSize, [Out] DWORD pcbBytesNeeded, [Out] DWORD lpServicesReturned);

        /// <summary>
        /// <para>
        /// Enumerates services in the specified service control manager database. The name and status of each service are provided.
        /// </para>
        /// <para>
        /// This function has been superseded by the <see cref="EnumServicesStatusEx"/> function.
        /// It returns the same information <see cref="EnumServicesStatus"/> returns,
        /// plus the process identifier and additional information for the service.
        /// In addition, <see cref="EnumServicesStatusEx"/> enables you to enumerate services that belong to a specified group.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumservicesstatusw"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function,
        /// and must have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwServiceType">
        /// <para>
        /// The type of services to be enumerated.
        /// This parameter can be one or more of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x0000000B
        /// </para>
        /// </term>
        /// <term>
        /// Services of type <see cref="SERVICE_KERNEL_DRIVER"/> and <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// File system driver services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_KERNEL_DRIVER"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Driver services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32"/>
        /// </para>
        /// <para>
        /// 0x00000030
        /// </para>
        /// </term>
        /// <term>
        /// Services of type <see cref="SERVICE_WIN32_OWN_PROCESS"/> and <see cref="SERVICE_WIN32_SHARE_PROCESS"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_OWN_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Services that run in their own processes.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_WIN32_SHARE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Services that share a process with one or more other services.
        /// For more information, see Service Programs.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwServiceState">
        /// <para>
        /// The state of the services to be enumerated. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates services that are in the following states:
        /// <see cref="SERVICE_START_PENDING"/>, <see cref="SERVICE_STOP_PENDING"/>, <see cref="SERVICE_RUNNING"/>,
        /// <see cref="SERVICE_CONTINUE_PENDING"/>, <see cref="SERVICE_PAUSE_PENDING"/>, and <see cref="SERVICE_PAUSED"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_INACTIVE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Enumerates services that are in the <see cref="SERVICE_STOPPED"/> state.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_STATE_ALL"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// Combines the following states: <see cref="SERVICE_ACTIVE"/> and <see cref="SERVICE_INACTIVE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpServices">
        /// <para>
        /// A pointer to a buffer that contains an array of <see cref="ENUM_SERVICE_STATUS"/> structures
        /// that receive the name and service status information for each service in the database.
        /// The buffer must be large enough to hold the structures, plus the strings to which their members point.
        /// </para>
        /// <para>
        /// The maximum size of this array is 256K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="pcbBytesNeeded"/> parameter will receive the required size.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP: 
        /// The maximum size of this array is 64K bytes.
        /// This limit was increased as of Windows Server 2003 with SP1 and Windows XP with SP2.
        /// </para>
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpServices"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed
        /// to return the remaining service entries, if the buffer is too small.
        /// </param>
        /// <param name="lpServicesReturned">
        /// A pointer to a variable that receives the number of service entries returned.
        /// </param>
        /// <param name="lpResumeHandle">
        /// A pointer to a variable that, on input, specifies the starting point of enumeration.
        /// You must set this value to zero the first time this function is called.
        /// On output, this value is zero if the function succeeds.
        /// However, if the function returns zero and the <see cref="GetLastError"/> function returns <see cref="ERROR_MORE_DATA"/>,
        /// this value is used to indicate the next service entry to be read
        /// when the function is called to retrieve the additional data.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Other error codes can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// A parameter that was specified is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_MORE_DATA"/>
        /// </term>
        /// <term>
        /// There are more service entries than would fit into the <paramref name="lpServices"/> buffer.
        /// The actual number of service entries written to <paramref name="lpServices"/>
        /// is returned in the <paramref name="lpServicesReturned"/> parameter.
        /// The number of bytes required to get the remaining entries is returned in the <paramref name="pcbBytesNeeded"/> parameter.
        /// The remaining services can be enumerated by additional calls to <see cref="EnumServicesStatus"/>
        /// with the <paramref name="lpResumeHandle"/> parameter indicating the next service to read.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumServicesStatusW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumServicesStatus([In] SC_HANDLE hSCManager, [In] DWORD dwServiceType, [In] DWORD dwServiceState,
            [Out] ENUM_SERVICE_STATUS[]? lpServices, [In] DWORD cbBufSize, [Out] DWORD pcbBytesNeeded, [Out] DWORD lpServicesReturned,
            [In][Out] ref DWORD lpResumeHandle);

        /// <summary>
        /// <para>
        /// Retrieves the display name of the specified service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-getservicedisplaynamew"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service control manager database, as returned by the <see cref="OpenSCManager"/> function.
        /// </param>
        /// <param name="lpServiceName">
        /// The service name.
        /// This name is the same as the service's registry key name.
        /// It is best to choose a name that is less than 256 characters.
        /// </param>
        /// <param name="lpDisplayName">
        /// <para>
        /// A pointer to a buffer that receives the service's display name.
        /// If the function fails, this buffer will contain an empty string.
        /// </para>
        /// <para>
        /// The maximum size of this array is 4K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="lpcchBuffer"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="lpcchBuffer"/> parameter will receive the required size.
        /// </para>
        /// <para>
        /// This parameter can specify a localized string using the following format:
        /// </para>
        /// <para>
        /// <c>@[path]dllname,-strID</c>
        /// </para>
        /// <para>
        /// The string with identifier <c>strID</c> is loaded from <c>dllname</c>; the <c>path</c> is optional.
        /// For more information, see <see cref="RegLoadMUIString"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// Localized strings are not supported until Windows Vista.
        /// </para>
        /// </param>
        /// <param name="lpcchBuffer">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer pointed to by <paramref name="lpDisplayName"/>, in TCHARs.
        /// </para>
        /// <para>
        /// On output, this variable receives the size of the service's display name, in characters,
        /// excluding the null-terminating character.
        /// </para>
        /// <para>
        /// If the buffer pointed to by <paramref name="lpDisplayName"/> is too small to contain the display name,
        /// the function does not store it.
        /// When the function returns, <paramref name="lpcchBuffer"/> contains the size of the service's display name,
        /// excluding the null-terminating character.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the functions succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// There are two names for a service: the service name and the display name.
        /// The service name is the name of the service's key in the registry.
        /// The display name is a user-friendly name that appears in the Services control panel application,
        /// and is used with the <c>NET START</c> command.
        /// To map the service name to the display name, use the <see cref="GetServiceDisplayName"/> function.
        /// To map the display name to the service name, use the <see cref="GetServiceKeyName"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetServiceDisplayNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetServiceDisplayName([In] SC_HANDLE hService, [In] LPCWSTR lpServiceName,
            [In] LPWSTR lpDisplayName, [In][Out] ref DWORD lpcchBuffer);

        /// <summary>
        /// <para>
        /// Retrieves the service name of the specified service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-getservicekeynamew"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service control manager database, as returned by <see cref="OpenSCManager"/>.
        /// </param>
        /// <param name="lpDisplayName">
        /// The service display name.
        /// This string has a maximum length of 256 characters.
        /// </param>
        /// <param name="lpServiceName">
        /// <para>
        /// A pointer to a buffer that receives the service name.
        /// If the function fails, this buffer will contain an empty string.
        /// </para>
        /// <para>
        /// The maximum size of this array is 4K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="lpcchBuffer"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="lpcchBuffer"/> parameter will receive the required size.
        /// </para>
        /// </param>
        /// <param name="lpcchBuffer">
        /// <para>
        /// A pointer to a variable that specifies the size of the buffer pointed to by <paramref name="lpServiceName"/>, in TCHARs.
        /// </para>
        /// <para>
        /// On output, this variable receives the size of the service's display name, in characters,
        /// excluding the null-terminating character.
        /// </para>
        /// <para>
        /// /// If the buffer pointed to by <paramref name="lpServiceName"/> is too small
        /// to contain the service name, the function stores no data in it.
        /// When the function returns, <paramref name="lpcchBuffer"/> contains the size of the service name,
        /// excluding the NULL terminator.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the functions succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// There are two names for a service: the service name and the display name.
        /// The service name is the name of the service's key in the registry.
        /// The display name is a user-friendly name that appears in the Services control panel application,
        /// and is used with the <c>NET START</c> command.
        /// Both names are specified with the <see cref="CreateService"/> function
        /// and can be modified with the <see cref="ChangeServiceConfig"/> function.
        /// Information specified for a service is stored in a key with the same name as the service name
        /// under the <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Services\ServiceName</c> registry key.
        /// </para>
        /// <para>
        /// To map the service name to the display name, use the <see cref="GetServiceDisplayName"/> function.
        /// To map the display name to the service name, use the <see cref="GetServiceKeyName"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetServiceKeyNameW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetServiceKeyName([In] SC_HANDLE hService, [In] LPCWSTR lpDisplayName,
            [In] LPWSTR lpServiceName, [In][Out] ref DWORD lpcchBuffer);

        /// <summary>
        /// <para>
        /// Requests ownership of the service control manager (SCM) database lock.
        /// Only one process can own the lock at any specified time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-lockservicedatabase"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the SCM database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function,
        /// and must have the <see cref="SC_MANAGER_LOCK"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a lock to the specified SCM database.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the SCM.
        /// Other error codes can be set by registry functions that are called by the SCM.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SC_MANAGER_LOCK"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_DATABASE_LOCKED"/>
        /// </term>
        /// <term>
        /// The database is locked.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// A lock is a protocol used by setup and configuration programs and the SCM to serialize access to the service tree in the registry.
        /// The only time the SCM requests ownership of the lock is when it is starting a service.
        /// </para>
        /// <para>
        /// A program that acquires the SCM database lock
        /// and fails to release it prevents the SCM from starting other services.
        /// Because of the severity of this issue, processes are no longer allowed to lock the database.
        /// For compatibility with older applications,
        /// the <see cref="LockServiceDatabase"/> function returns a lock but has no other effect.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// Acquiring the SCM database lock prevents the SCM from starting a service until the lock is released.
        /// For example, a program that must configure several related services
        /// before any of them starts could call <see cref="LockServiceDatabase"/> before configuring the first service.
        /// Alternatively, it could ensure that none of the services are started until the configuration has been completed.
        /// </para>
        /// <para>
        /// A call to the <see cref="StartService"/> function to start a service in a locked database fails.
        /// No other SCM functions are affected by a lock.
        /// </para>
        /// <para>
        /// The lock is held until the <see cref="SC_LOCK"/> handle is specified
        /// in a subsequent call to the <see cref="UnlockServiceDatabase"/> function.
        /// If a process that owns a lock terminates, the SCM automatically cleans up and releases ownership of the lock.
        /// </para>
        /// <para>
        /// Failing to release the lock can cause system problems.
        /// A process that acquires the lock should release it as soon as possible.
        /// </para>
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is provided for application compatibility and has no effect on the database.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockServiceDatabase", ExactSpelling = true, SetLastError = true)]
        public static extern SC_LOCK LockServiceDatabase([In] SC_HANDLE hSCManager);

        /// <summary>
        /// <para>
        /// Reports the boot status to the service control manager.
        /// It is used by boot verification programs.
        /// This function can be called only by a process running in the LocalSystem or Administrator's account.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-notifybootconfigstatus"/>
        /// </para>
        /// </summary>
        /// <param name="BootAcceptable">
        /// If the value is <see cref="TRUE"/>, the system saves the configuration as the last-known good configuration.
        /// If the value is <see cref="FALSE"/>, the system immediately reboots,
        /// using the previously saved last-known good configuration.
        /// </param>
        /// <returns>
        /// <para>
        /// If the <paramref name="BootAcceptable"/> parameter is <see cref="FALSE"/>, the function does not return.
        /// </para>
        /// <para>
        /// If the last-known good configuration was successfully saved, the return value is nonzero.
        /// </para>
        /// <para>
        /// If an error occurs, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes may be set by the service control manager.
        /// Other error codes may be set by the registry functions that are called by the service control manager
        /// to set parameters in the configuration registry.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The user does not have permission to perform this operation.
        /// Only the system and members of the Administrator's group can do so.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Saving the configuration of a running system with this function
        /// is an acceptable method for saving the last-known good configuration.
        /// If the boot configuration is unacceptable,
        /// use this function to reboot the system using the existing last-known good configuration.
        /// </para>
        /// <para>
        /// This function call requires the caller's token to have permission
        /// to acquire the <see cref="SC_MANAGER_MODIFY_BOOT_CONFIG"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "NotifyBootConfigStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL NotifyBootConfigStatus([In] BOOL BootAcceptable);

        /// <summary>
        /// <para>
        /// Establishes a connection to the service control manager on the specified computer
        /// and opens the specified service control manager database.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openscmanagerw"/>
        /// </para>
        /// </summary>
        /// <param name="lpMachineName">
        /// The name of the target computer.
        /// If the pointer is <see cref="NULL"/> or points to an empty string,
        /// the function connects to the service control manager on the local computer.
        /// </param>
        /// <param name="lpDatabaseName">
        /// The name of the service control manager database.
        /// This parameter should be set to <see cref="SERVICES_ACTIVE_DATABASE"/>.
        /// If it is <see cref="NULL"/>, the <see cref="SERVICES_ACTIVE_DATABASE"/> database is opened by default.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access to the service control manager.
        /// For a list of access rights, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// Before granting the requested access rights, the system checks the access token of the calling process
        /// against the discretionary access-control list of the security descriptor associated with the service control manager.
        /// </para>
        /// <para>
        /// The <see cref="SC_MANAGER_CONNECT"/> access right is implicitly specified by calling this function.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the specified service control manager database.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the SCM.
        /// Other error codes can be set by the registry functions that are called by the SCM.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The requested access was denied.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_DATABASE_DOES_NOT_EXIST"/>
        /// </term>
        /// <term>
        /// The specified database does not exist.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a process uses the <see cref="OpenSCManager"/> function to open a handle to a service control manager database,
        /// the system performs a security check before granting the requested access.
        /// For more information, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// If the current user does not have proper access when connecting to a service on another computer,
        /// the <see cref="OpenSCManager"/> function call fails.
        /// To connect to a service remotely, call the <see cref="LogonUser"/> function with <see cref="LOGON32_LOGON_NEW_CREDENTIALS"/>
        /// and then call <see cref="ImpersonateLoggedOnUser"/> before calling <see cref="OpenSCManager"/>.
        /// For more information about connecting to services remotely, see Services and RPC/TCP.
        /// </para>
        /// <para>
        /// Only processes with Administrator privileges are able to open a database handle
        /// that can be used by the <see cref="CreateService"/> function.
        /// </para>
        /// <para>
        /// The returned handle is only valid for the process that called the <see cref="OpenSCManager"/> function.
        /// It can be closed by calling the <see cref="CloseServiceHandle"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenSCManagerW", ExactSpelling = true, SetLastError = true)]
        public static extern SC_HANDLE OpenSCManager([In] LPCWSTR lpMachineName, [In] LPCWSTR lpDatabaseName, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens an existing service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openservicew"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// The <see cref="OpenSCManager"/> function returns this handle.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="lpServiceName">
        /// <para>
        /// The name of the service to be opened.
        /// This is the name specified by the <paramref name="lpServiceName"/> parameter of the <see cref="CreateService"/> function
        /// when the service object was created, not the service display name
        /// that is shown by user interface applications to identify the service.
        /// </para>
        /// <para>
        /// The maximum string length is 256 characters.
        /// The service control manager database preserves the case of the characters,
        /// but service name comparisons are always case insensitive.
        /// Forward-slash (/) and backslash (\) are invalid service name characters.
        /// </para>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access to the service.
        /// For a list of access rights, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// Before granting the requested access, the system checks the access token of the calling process
        /// against the discretionary access-control list of the security descriptor associated with the service object.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the service.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Others can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have access to the service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_NAME"/>
        /// </term>
        /// <term>
        /// The specified service name is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_DOES_NOT_EXIST"/>
        /// </term>
        /// <term>
        /// The specified service does not exist.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The returned handle is only valid for the process that called <see cref="OpenService"/>.
        /// It can be closed by calling the <see cref="CloseServiceHandle"/> function.
        /// </para>
        /// <para>
        /// To use <see cref="OpenService"/>, no privileges are required aside from <see cref="SC_MANAGER_CONNECT"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenServiceW", ExactSpelling = true, SetLastError = true)]
        public static extern SC_HANDLE OpenService([In] SC_HANDLE hSCManager, [In] LPCWSTR lpServiceName, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Retrieves the configuration parameters of the specified service.
        /// Optional configuration parameters are available using the <see cref="QueryServiceConfig2"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryserviceconfigw"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function,
        /// and it must have the <see cref="SERVICE_QUERY_CONFIG"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="lpServiceConfig">
        /// <para>
        /// A pointer to a buffer that receives the service configuration information.
        /// The format of the data is a <see cref="QUERY_SERVICE_CONFIG"/> structure.
        /// </para>
        /// <para>
        /// The maximum size of this array is 8K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="pcbBytesNeeded"/> parameter will receive the required size.
        /// </para>
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpServiceConfig"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to store all the configuration information,
        /// if the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Others can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SERVICE_QUERY_CONFIG"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// There is more service configuration information than would fit into the <paramref name="lpServiceConfig"/> buffer.
        /// The number of bytes required to get all the information is returned in the <paramref name="pcbBytesNeeded"/> parameter.
        /// Nothing is written to <paramref name="lpServiceConfig"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="QueryServiceConfig"/> function returns the service configuration information
        /// kept in the registry for a particular service.
        /// This configuration information is first set by a service control program
        /// using the <see cref="CreateService"/> function.
        /// This information may have been updated by a service configuration program
        /// using the <see cref="ChangeServiceConfig"/> function.
        /// </para>
        /// <para>
        /// If the service was running when the configuration information was last changed,
        /// the information returned by <see cref="QueryServiceConfig"/> will not reflect the current configuration of the service.
        /// Instead, it will reflect the configuration of the service when it is next run.
        /// The <c>DisplayName</c> key is an exception to this.
        /// When the<c>DisplayName</c> key is changed, it takes effect immediately, regardless of whether the service is running.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceConfigW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceConfig([In] SC_HANDLE hService, [Out] out QUERY_SERVICE_CONFIG lpServiceConfig,
            [In] DWORD cbBufSize, [Out] out DWORD pcbBytesNeeded);

        /// <summary>
        /// <para>
        /// Retrieves the lock status of the specified service control manager database.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryservicelockstatusw"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// The <see cref="OpenSCManager"/> function returns this handle,
        /// which must have the <see cref="SC_MANAGER_QUERY_LOCK_STATUS"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="lpLockStatus">
        /// A pointer to a <see cref="QUERY_SERVICE_LOCK_STATUS"/> structure
        /// that receives the lock status of the specified database is returned,
        /// plus the strings to which its members point.
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpLockStatus"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed
        /// to return all the lock status information, if the function fails.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
        /// Other error codes can be set by the registry functions that are called by the service control manager.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the <see cref="SC_MANAGER_QUERY_LOCK_STATUS"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// There is more lock status information than would fit into the <paramref name="lpLockStatus"/> buffer.
        /// The number of bytes required to get all the information is returned in the <paramref name="pcbBytesNeeded"/> parameter.
        /// Nothing is written to <paramref name="lpLockStatus"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="QueryServiceLockStatus"/> function returns a <see cref="QUERY_SERVICE_LOCK_STATUS"/> structure
        /// that indicates whether the specified database is locked.
        /// If the database is locked, the structure provides the account name of the user
        /// that owns the lock and the length of time that the lock has been held.
        /// </para>
        /// <para>
        /// A process calls the <see cref="LockServiceDatabase"/> function to acquire ownership of a service control manager database
        /// lock and the <see cref="UnlockServiceDatabase"/> function to release the lock.
        /// </para>
        /// </remarks>
        [Obsolete("This function has no effect as of Windows Vista.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceLockStatusW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceLockStatus([In] SC_HANDLE hSCManager, [Out] out QUERY_SERVICE_LOCK_STATUS lpLockStatus,
            [In] DWORD cbBufSize, [Out] out DWORD pcbBytesNeeded);
    }
}
