using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains configuration information for an installed service. It is used by the <see cref="QueryServiceConfig"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-query_service_configw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The configuration information for a service is initially specified
    /// when the service is created by a call to the <see cref="CreateService"/> function.
    /// The information can be modified by calling the <see cref="ChangeServiceConfig"/> function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct QUERY_SERVICE_CONFIG
    {
        /// <summary>
        /// <para>
        /// The type of service.
        /// This member can be one of the following values.
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
        ///  
        /// </para>
        /// <para>
        /// If the value is <see cref="SERVICE_WIN32_OWN_PROCESS"/> or <see cref="SERVICE_WIN32_SHARE_PROCESS"/>,
        /// and the service is running in the context of the LocalSystem account, the following type may also be specified.
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
        /// </summary>
        public DWORD dwServiceType;

        /// <summary>
        /// <para>
        /// When to start the service.
        /// This member can be one of the following values.
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
        /// A service started by the service control manager when a process calls the <see cref="StartService"/> function.
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
        /// </summary>
        public DWORD dwStartType;

        /// <summary>
        /// <para>
        /// The severity of the error, and action taken, if this service fails to start.
        /// This member can be one of the following values.
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
        /// If the last-known good configuration is being started, the startup operation fails.
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
        /// The startup program logs the error in the event log and continues the startup operation.
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
        /// If the last-known good configuration is being started, the startup operation continues.
        /// Otherwise, the system is restarted with the last-known-good configuration.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwErrorControl;

        /// <summary>
        /// <para>
        /// The fully qualified path to the service binary file.
        /// </para>
        /// <para>
        /// The path can also include arguments for an auto-start service.
        /// These arguments are passed to the service entry point (typically the <c>main</c> function).
        /// </para>
        /// </summary>
        public IntPtr lpBinaryPathName;

        /// <summary>
        /// <para>
        /// The name of the load ordering group to which this service belongs.
        /// If the member is <see cref="NULL"/> or an empty string, the service does not belong to a load ordering group.
        /// </para>
        /// <para>
        /// The startup program uses load ordering groups to load groups of services in a specified order with respect to the other groups.
        /// The list of load ordering groups is contained in the following registry value:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\ServiceGroupOrder</c>
        /// </para>
        /// </summary>
        public IntPtr lpLoadOrderGroup;

        /// <summary>
        /// <para>
        /// A unique tag value for this service in the group specified by the <see cref="lpLoadOrderGroup"/> parameter.
        /// A value of zero indicates that the service has not been assigned a tag.
        /// You can use a tag for ordering service startup within a load order group
        /// by specifying a tag order vector in the registry located at:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\System\CurrentControlSet\Control\GroupOrderList</c>
        /// </para>
        /// <para>
        /// Tags are only evaluated for <see cref="SERVICE_KERNEL_DRIVER"/> and <see cref="SERVICE_FILE_SYSTEM_DRIVER"/> type services
        /// that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.
        /// </para>
        /// </summary>
        public DWORD dwTagId;

        /// <summary>
        /// A pointer to an array of null-separated names of services or load ordering groups that must start before this service.
        /// The array is doubly null-terminated.
        /// If the pointer is <see cref="NULL"/> or if it points to an empty string, the service has no dependencies.
        /// If a group name is specified, it must be prefixed by the <see cref="SC_GROUP_IDENTIFIER"/> (defined in WinSvc.h) character
        /// to differentiate it from a service name, because services and service groups share the same name space.
        /// Dependency on a service means that this service can only run if the service it depends on is running.
        /// Dependency on a group means that this service can run if at least one member of the group is running
        /// after an attempt to start all members of the group.
        /// </summary>
        public IntPtr lpDependencies;

        /// <summary>
        /// <para>
        /// If the service type is <see cref="SERVICE_WIN32_OWN_PROCESS"/> or <see cref="SERVICE_WIN32_SHARE_PROCESS"/>,
        /// this member is the name of the account that the service process will be logged on as when it runs.
        /// This name can be of the form <c>Domain\UserName.</c>.
        /// If the account belongs to the built-in domain, the name can be of the form <c>.\UserName</c>.
        /// The name can also be "LocalSystem" if the process is running under the LocalSystem account.
        /// </para>
        /// <para>
        /// If the service type is <see cref="SERVICE_KERNEL_DRIVER"/> or <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>,
        /// this member is the driver object name (that is, <c>\FileSystem\Rdr</c> or <c>\Driver\Xns</c>)
        /// which the input and output (I/O) system uses to load the device driver.
        /// If this member is <see cref="NULL"/>, the driver is to be run with a default object name
        /// created by the I/O system, based on the service name.
        /// </para>
        /// </summary>
        public IntPtr lpServiceStartName;

        /// <summary>
        /// <para>
        /// The display name to be used by service control programs to identify the service.
        /// This string has a maximum length of 256 characters.
        /// The name is case-preserved in the service control manager.
        /// Display name comparisons are always case-insensitive.
        /// </para>
        /// <para>
        /// This parameter can specify a localized string using the following format:
        /// </para>
        /// <para>
        /// <c>@[Path]DLLName,-StrID</c>
        /// </para>
        /// <para>
        /// The string with identifier <c>StrID</c> is loaded from <c>DLLName</c>;
        /// the <c>Path</c> is optional.
        /// For more information, see <see cref="RegLoadMUIString"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// Localized strings are not supported until Windows Vista.
        /// </para>
        /// </summary>
        public IntPtr lpDisplayName;
    }
}
