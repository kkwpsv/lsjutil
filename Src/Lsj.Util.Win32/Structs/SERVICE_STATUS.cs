using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains status information for a service.
    /// The <see cref="ControlService"/>, <see cref="EnumDependentServices"/>,
    /// <see cref="EnumServicesStatus"/>, and <see cref="QueryServiceStatus"/> functions use this structure.
    /// A service uses this structure in the <see cref="SetServiceStatus"/> function
    /// to report its current status to the service control manager.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_status"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SERVICE_STATUS
    {
        /// <summary>
        /// <para>
        /// The type of service. This member can be one of the following values.
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
        /// The service is a file system driver.
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
        /// The service is a device driver.
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
        /// The service runs in its own process.
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
        /// The service shares a process with other services.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_USER_OWN_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000050
        /// </para>
        /// </term>
        /// <term>
        /// The service runs in its own process under the logged-on user account.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_USER_SHARE_PROCESS"/>
        /// </para>
        /// <para>
        /// 0x00000060
        /// </para>
        /// </term>
        /// <term>
        /// The service shares a process with one or more other services that run under the logged-on user account.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the service type is either <see cref="SERVICE_WIN32_OWN_PROCESS"/> or <see cref="SERVICE_WIN32_SHARE_PROCESS"/>,
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
        /// The current state of the service.
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
        /// <see cref="SERVICE_CONTINUE_PENDING"/>
        /// </para>
        /// <para>
        /// 0x00000005
        /// </para>
        /// </term>
        /// <term>
        /// The service continue is pending.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_PAUSE_PENDING"/>
        /// </para>
        /// <para>
        /// 0x00000006
        /// </para>
        /// </term>
        /// <term>
        /// The service pause is pending.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_PAUSED"/>
        /// </para>
        /// <para>
        /// 0x00000007
        /// </para>
        /// </term>
        /// <term>
        /// The service is paused.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_RUNNING"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The service is running.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_START_PENDING"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The service is starting.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_STOP_PENDING"/>
        /// </para>
        /// <para>
        /// 0x00000003
        /// </para>
        /// </term>
        /// <term>
        /// The service is stopping.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_STOPPED"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The service is not running.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwCurrentState;

        /// <summary>
        /// <para>
        /// The control codes the service accepts and processes in its handler function
        /// (see <c>Handler</c> and <c>HandlerEx</c>).
        /// A user interface process can control a service by specifying a control command 
        /// in the <see cref="ControlService"/> or <see cref="ControlServiceEx"/> function.
        /// By default, all services accept the <see cref="SERVICE_CONTROL_INTERROGATE"/> value.
        /// </para>
        /// <para>
        /// To accept the <see cref="SERVICE_CONTROL_DEVICEEVENT"/> value,
        /// the service must register to receive device events by using the <see cref="RegisterDeviceNotification"/> function.
        /// </para>
        /// <para>
        /// The following are the control codes.
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
        /// <see cref="SERVICE_ACCEPT_NETBINDCHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service is a network component that can accept changes in its binding without being stopped and restarted.
        /// </para>
        /// <para>
        /// This control code allows the service to receive <see cref="SERVICE_CONTROL_NETBINDADD"/>,
        /// <see cref="SERVICE_CONTROL_NETBINDREMOVE"/>, <see cref="SERVICE_CONTROL_NETBINDENABLE"/>,
        /// and <see cref="SERVICE_CONTROL_NETBINDDISABLE"/> notifications.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_PARAMCHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can reread its startup parameters without being stopped and restarted.
        /// </para>
        /// <para>
        /// This control code allows the service to receive <see cref="SERVICE_CONTROL_PARAMCHANGE"/> notifications.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_PAUSE_CONTINUE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can be paused and continued.
        /// </para>
        /// <para>
        /// This control code allows the service to receive <see cref="SERVICE_CONTROL_PAUSE"/>
        /// and <see cref="SERVICE_CONTROL_CONTINUE"/> notifications.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_PRESHUTDOWN"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can perform preshutdown tasks.
        /// </para>
        /// <para>
        /// This control code enables the service to receive <see cref="SERVICE_CONTROL_PRESHUTDOWN"/> notifications.
        /// Note that <see cref="ControlService"/> and <see cref="ControlServiceEx"/> cannot send this notification;
        /// only the system can send it.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_SHUTDOWN"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service is notified when system shutdown occurs.
        /// </para>
        /// <para>
        /// This control code allows the service to receive <see cref="SERVICE_CONTROL_SHUTDOWN"/> notifications.
        /// Note that <see cref="ControlService"/> and <see cref="ControlServiceEx"/> cannot send this notification;
        /// only the system can send it.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_STOP"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service can be stopped.
        /// </para>
        /// <para>
        /// This control code allows the service to receive <see cref="SERVICE_CONTROL_STOP"/> notifications.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This member can also contain the following extended control codes, which are supported only by <c>HandlerEx</c>.
        /// (Note that these control codes cannot be sent by <see cref="ControlService"/> or <see cref="ControlServiceEx"/>.)
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
        /// <see cref="SERVICE_ACCEPT_HARDWAREPROFILECHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// The service is notified when the computer's hardware profile has changed.
        /// This enables the system to send <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/> notifications to the service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_POWEREVENT"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// The service is notified when the computer's power status has changed.
        /// This enables the system to send <see cref="SERVICE_CONTROL_POWEREVENT"/> notifications to the service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_SESSIONCHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// The service is notified when the computer's session status has changed.
        /// This enables the system to send <see cref="SERVICE_CONTROL_SESSIONCHANGE"/> notifications to the service.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_TIMECHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service is notified when the system time has changed.
        /// This enables the system to send <see cref="SERVICE_CONTROL_TIMECHANGE"/> notifications to the service.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This control code is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_TRIGGEREVENT"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The service is notified when an event for which the service has registered occurs.
        /// This enables the system to send <see cref="SERVICE_CONTROL_TRIGGEREVENT"/> notifications to the service.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This control code is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_ACCEPT_USERMODEREBOOT"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The services is notified when the user initiates a reboot.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This control code is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwControlsAccepted;

        /// <summary>
        /// The error code the service uses to report an error that occurs when it is starting or stopping.
        /// To return an error code specific to the service,
        /// the service must set this value to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/> to indicate
        /// that the <see cref="dwServiceSpecificExitCode"/> member contains the error code.
        /// The service should set this value to <see cref="NO_ERROR"/>
        /// when it is running and on normal termination.
        /// </summary>
        public DWORD dwWin32ExitCode;

        /// <summary>
        /// A service-specific error code that the service returns when an error occurs while the service is starting or stopping.
        /// This value is ignored unless the <see cref="dwWin32ExitCode"/> member is set to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/>.
        /// </summary>
        public DWORD dwServiceSpecificExitCode;

        /// <summary>
        /// The check-point value the service increments periodically to report its progress
        /// during a lengthy start, stop, pause, or continue operation.
        /// For example, the service should increment this value as it completes each step of its initialization when it is starting up.
        /// The user interface program that invoked the operation on the service
        /// uses this value to track the progress of the service during a lengthy operation.
        /// This value is not valid and should be zero
        /// when the service does not have a start, stop, pause, or continue operation pending.
        /// </summary>
        public DWORD dwCheckPoint;

        /// <summary>
        /// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds.
        /// Before the specified amount of time has elapsed,
        /// the service should make its next call to the <see cref="SetServiceStatus"/> function
        /// with either an incremented <see cref="dwCheckPoint"/> value or a change in <see cref="dwCurrentState"/>.
        /// If the amount of time specified by <see cref="dwWaitHint"/> passes,
        /// and <see cref="dwCheckPoint"/> has not been incremented or <see cref="dwCurrentState"/> has not changed,
        /// the service control manager or service control program can assume
        /// that an error has occurred and the service should be stopped.
        /// However, if the service shares a process with other services,
        /// the service control manager cannot terminate the service application
        /// because it would have to terminate the other services sharing the process as well.
        /// </summary>
        public DWORD dwWaitHint;
    }
}
