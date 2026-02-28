using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.ACCESS_MASK;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public static partial class Advapi32
    {
        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="RegisterServiceCtrlHandler"/> function.
        /// A service program can use it as the control handler function of a particular service.
        /// </para>
        /// <para>
        /// The <see cref="LPHANDLER_FUNCTION"/> type defines a pointer to this function.
        /// <c>Handler</c> is a placeholder for the application-defined name.
        /// </para>
        /// <para>
        /// This function has been superseded by the <c>HandlerEx</c> control handler function
        /// used with the <see cref="RegisterServiceCtrlHandlerEx"/> function.
        /// A service can use either control handler,
        /// but the new control handler supports user-defined context data and additional extended control codes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function"/>
        /// </para>
        /// </summary>
        /// <param name="dwControl">
        /// </param>
        /// <remarks>
        /// <para>
        /// When a service is started, its <c>ServiceMain</c> function should immediately call the <see cref="RegisterServiceCtrlHandler"/> function
        /// to specify a <c>Handler</c> function to process control requests.
        /// </para>
        /// <para>
        /// The control dispatcher in the main thread of a service process invokes the control handler function for the specified service
        /// whenever it receives a control request from the service control manager.
        /// After processing the control request, the control handler must call the <see cref="SetServiceStatus"/> function
        /// if the service state changes to report its new status to the service control manager.
        /// </para>
        /// <para>
        /// The control handler function is intended to receive notification and return immediately.
        /// The callback function should save its parameters and create other threads to perform additional work.
        /// (Your application must ensure that such threads have exited before stopping the service.)
        /// In particular, a control handler should avoid operations that might block, such as taking a lock,
        /// because this could result in a deadlock or cause the system to stop responding.
        /// </para>
        /// <para>
        /// When the service control manager sends a control code to a service,
        /// it waits for the handler function to return before sending additional control codes to other services.
        /// The control handler should return as quickly as possible; if it does not return within 30 seconds, the SCM returns an error.
        /// If a service must do lengthy processing when the service is executing the control handler,
        /// it should create a secondary thread to perform the lengthy processing, and then return from the control handler.
        /// This prevents the service from tying up the control dispatcher and blocking other services from receiving control codes.
        /// </para>
        /// <para>
        /// The <see cref="SERVICE_CONTROL_SHUTDOWN"/> control code should only be processed by services
        /// that must absolutely clean up during shutdown, because there is a limited time (about 20 seconds) available for service shutdown.
        /// After this time expires, system shutdown proceeds regardless of whether service shutdown is complete.
        /// Note that if the system is left in the shutdown state (not restarted or powered down), the service continues to run.
        /// If your service registers to accept <see cref="SERVICE_CONTROL_SHUTDOWN"/>,
        /// it must handle the control code and stop in a timely fashion.
        /// Otherwise, the service can increase the time required to shut down the system,
        /// because the system must wait for the full amount of time allowed for service shutdown before system shutdown can proceed.
        /// </para>
        /// <para>
        /// If the service requires more time to clean up, it should send <see cref="STOP_PENDING"/> status messages,
        /// along with a wait hint, so the service controller knows how long to wait before reporting to the system that service shutdown is complete.
        /// However, to prevent a service from stopping shutdown, there is a limit to how long the service controller will wait.
        /// If the service is being shut down through the Services snap-in, the limit is 125 seconds.
        /// If the operating system is rebooting, the time limit is specified
        /// in the <c>WaitToKillServiceTimeout</c> value of the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control</c>
        /// </para>
        /// <para>
        /// Services can also use the <see cref="SetConsoleCtrlHandler"/> function to receive shutdown notification.
        /// This notification is received when the running applications are shutting down, which occurs before services are shut down.
        /// </para>
        /// </remarks>
        public delegate void LphandlerFunction([In] DWORD dwControl);

        /// <summary>
        /// <para>
        /// An application-defined callback function used with the <see cref="RegisterServiceCtrlHandlerEx"/> function.
        /// A service program can use it as the control handler function of a particular service.
        /// </para>
        /// <para>
        /// The <see cref="LPHANDLER_FUNCTION_EX"/> type defines a pointer to this function.
        /// <c>HandlerEx</c> is a placeholder for the application-defined name.
        /// </para>
        /// <para>
        /// This function supersedes the <c>Handler</c> control handler function
        /// used with the <see cref="RegisterServiceCtrlHandler"/> function.
        /// A service can use either control handler,
        /// but the new control handler supports user-defined context data and additional extended control codes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function_ex"/>
        /// </para>
        /// </summary>
        /// <param name="dwControl">
        /// <para>
        /// The control code. This parameter can be one of the following values.
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
        /// Notifies a service to report its current status information to the service control manager.
        /// </para>
        /// <para>
        /// The handler should simply return <see cref="NO_ERROR"/>;
        /// the SCM is aware of the current state of the service.
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
        /// <para>
        /// Notifies a network service that there is a new component for binding.
        /// The service should bind to the new component.
        /// </para>
        /// <para>
        /// Applications should use Plug and Play functionality instead.
        /// </para>
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
        /// <para>
        /// Notifies a network service that one of its bindings has been disabled.
        /// The service should reread its binding information and remove the binding.
        /// </para>
        /// <para>
        /// Applications should use Plug and Play functionality instead.
        /// </para>
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
        /// <para>
        /// Notifies a network service that a disabled binding has been enabled.
        /// The service should reread its binding information and add the new binding.
        /// </para>
        /// <para>
        /// Applications should use Plug and Play functionality instead.
        /// </para>
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
        /// <para>
        /// Notifies a network service that a component for binding has been removed.
        /// The service should reread its binding information and unbind from the removed component.
        /// </para>
        /// <para>
        /// Applications should use Plug and Play functionality instead.
        /// </para>
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
        /// Notifies a service that service-specific startup parameters have changed.
        /// The service should reread its startup parameters.
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
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_PRESHUTDOWN"/>
        /// </para>
        /// <para>
        /// 0x0000000F
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that the system will be shutting down.
        /// Services that need additional time to perform cleanup tasks
        /// beyond the tight time restriction at system shutdown can use this notification.
        /// The service control manager sends this notification to applications
        /// that have registered for it before sending a <see cref="SERVICE_CONTROL_SHUTDOWN"/> notification
        /// to applications that have registered for that notification.
        /// </para>
        /// <para>
        /// A service that handles this notification blocks system shutdown
        /// until the service stops or the preshutdown time-out interval
        /// specified through <see cref="SERVICE_PRESHUTDOWN_INFO"/> expires.
        /// Because this affects the user experience, services should use this feature
        /// only if it is absolutely necessary to avoid data loss or significant recovery time at the next system start.
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
        /// <see cref="SERVICE_CONTROL_SHUTDOWN"/>
        /// </para>
        /// <para>
        /// 0x00000005
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that the system is shutting down so the service can perform cleanup tasks.
        /// Note that services that register for <see cref="SERVICE_CONTROL_PRESHUTDOWN"/> notifications
        /// cannot receive this notification because they have already stopped.
        /// </para>
        /// <para>
        /// If a service accepts this control code,
        /// it must stop after it performs its cleanup tasks and return <see cref="NO_ERROR"/>.
        /// After the SCM sends this control code, it will not send other control codes to the service.
        /// </para>
        /// <para>
        /// For more information, see the Remarks section of this topic.
        /// </para>
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
        /// </para>
        /// <para>
        /// If a service accepts this control code, it must stop upon receipt and return <see cref="NO_ERROR"/>.
        /// After the SCM sends this control code, it will not send other control codes to the service.
        /// </para>
        /// <para>
        /// Windows XP:  If the service returns <see cref="NO_ERROR"/> and continues to run,
        /// it continues to receive control codes.
        /// This behavior changed starting with Windows Server 2003 and Windows XP with SP2.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// This parameter can also be one of the following extended control codes.
        /// Note that these control codes are not supported by the <c>Handler</c> function.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Control Code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_DEVICEEVENT"/>
        /// </para>
        /// <para>
        /// 0x0000000B
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service of device events.
        /// (The service must have registered to receive these notifications
        /// using the <see cref="RegisterDeviceNotification"/> function.)
        /// The <paramref name="dwEventType"/> and <paramref name="lpEventData"/> parameters contain additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/>
        /// </para>
        /// <para>
        /// 0x0000000C
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service that the computer's hardware profile has changed.
        /// The <paramref name="dwEventType"/> parameter contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_POWEREVENT"/>
        /// </para>
        /// <para>
        /// 0x0000000D
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service of system power events.
        /// The <paramref name="dwEventType"/> parameter contains additional information.
        /// If <paramref name="dwEventType"/> is <see cref="PBT_POWERSETTINGCHANGE"/>,
        /// the <paramref name="lpEventData"/> parameter also contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_SESSIONCHANGE"/>
        /// </para>
        /// <para>
        /// 0x0000000E
        /// </para>
        /// </term>
        /// <term>
        /// Notifies a service of session change events.
        /// Note that a service will only be notified of a user logon if it is fully loaded before the logon attempt is made.
        /// The <paramref name="dwEventType"/> and <paramref name="lpEventData"/> parameters contain additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONTROL_TIMECHANGE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that the system time has changed.
        /// The <paramref name="lpEventData"/> parameter contains additional information.
        /// The <paramref name="dwEventType"/> parameter is not used.
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
        /// <see cref="SERVICE_CONTROL_TRIGGEREVENT"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service registered for a service trigger event that the event has occurred.
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
        /// <see cref="SERVICE_CONTROL_USERMODEREBOOT"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Notifies a service that the user has initiated a reboot.
        /// </para>
        /// <para>
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This control code is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// This parameter can also be a user-defined control code, as described in the following table.
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
        /// Range 128 to 255.
        /// </term>
        /// <term>
        /// The service defines the action associated with the control code.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwEventType">
        /// <para>
        /// The type of event that has occurred.
        /// This parameter is used if <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_DEVICEEVENT"/>,
        /// <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/>, <see cref="SERVICE_CONTROL_POWEREVENT"/>,
        /// or <see cref="SERVICE_CONTROL_SESSIONCHANGE"/>.
        /// Otherwise, it is zero.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_DEVICEEVENT"/>,
        /// this parameter can be one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DBT_DEVICEARRIVAL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_DEVICEREMOVECOMPLETE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_DEVICEQUERYREMOVE"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_DEVICEQUERYREMOVEFAILED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_DEVICEREMOVEPENDING"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_CUSTOMEVENT"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/>,
        /// this parameter can be one of the following values:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="DBT_CONFIGCHANGED"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_QUERYCHANGECONFIG"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DBT_CONFIGCHANGECANCELED"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_POWEREVENT"/>,
        /// this parameter can be one of the values
        /// specified in the <c>wParam</c> parameter of the <see cref="WM_POWERBROADCAST"/> message.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_SESSIONCHANGE"/>,
        /// this parameter can be one of the values
        /// specified in the <c>wParam</c> parameter of the <see cref="WM_WTSSESSION_CHANGE"/> message.
        /// </para>
        /// </param>
        /// <param name="lpEventData">
        /// <para>
        /// Additional device information, if required.
        /// The format of this data depends on the value of the <paramref name="dwControl"/> and <paramref name="dwEventType"/> parameters.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_DEVICEEVENT"/>,
        /// this data corresponds to the <c>lParam</c> parameter
        /// that applications receive as part of a <see cref="WM_DEVICECHANGE"/> message.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_POWEREVENT"/>
        /// and <paramref name="dwEventType"/> is <see cref="PBT_POWERSETTINGCHANGE"/>,
        /// this data is a pointer to a <see cref="POWERBROADCAST_SETTING"/> structure.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_SESSIONCHANGE"/>,
        /// this parameter is a pointer to a <see cref="WTSSESSION_NOTIFICATION"/> structure.
        /// </para>
        /// <para>
        /// If <paramref name="dwControl"/> is <see cref="SERVICE_CONTROL_TIMECHANGE"/>,
        /// this data is a pointer to a <see cref="SERVICE_TIMECHANGE_INFO"/> structure.
        /// </para>
        /// </param>
        /// <param name="lpContext">
        /// User-defined data passed from <see cref="RegisterServiceCtrlHandlerEx"/>.
        /// When multiple services share a process, the <paramref name="lpContext"/> parameter can help identify the service.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value for this function depends on the control code received.
        /// </para>
        /// <para>
        /// The following list identifies the rules for this return value:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// In general, if your service does not handle the control, return <see cref="ERROR_CALL_NOT_IMPLEMENTED"/>.
        /// However, your service should return <see cref="NO_ERROR"/> for <see cref="SERVICE_CONTROL_INTERROGATE"/>
        /// even if your service does not handle it.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If your service handles <see cref="SERVICE_CONTROL_STOP"/> or <see cref="SERVICE_CONTROL_SHUTDOWN"/>,
        /// return <see cref="NO_ERROR"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If your service handles <see cref="SERVICE_CONTROL_DEVICEEVENT"/>,
        /// return <see cref="NO_ERROR"/> to grant the request and an error code to deny the request.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If your service handles <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/>,
        /// return <see cref="NO_ERROR"/> to grant the request and an error code to deny the request.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If your service handles <see cref="SERVICE_CONTROL_POWEREVENT"/>,
        /// return <see cref="NO_ERROR"/> to grant the request and an error code to deny the request.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// For all other control codes your service handles, return <see cref="NO_ERROR"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a service is started, its <c>ServiceMain</c> function
        /// should immediately call the <see cref="RegisterServiceCtrlHandlerEx"/> function
        /// to specify a <c>HandlerEx</c> function to process control requests.
        /// To specify the control codes to be accepted,
        /// use the <see cref="SetServiceStatus"/> and <see cref="RegisterDeviceNotification"/> functions.
        /// </para>
        /// <para>
        /// The control dispatcher in the main thread of a service invokes the control handler function for the specified service
        /// whenever it receives a control request from the service control manager.
        /// After processing the control request, the control handler must call <see cref="SetServiceStatus"/>
        /// if the service state changes to report its new status to the service control manager.
        /// </para>
        /// <para>
        /// The control handler function is intended to receive notification and return immediately.
        /// The callback function should save its parameters and create other threads to perform additional work.
        /// (Your application must ensure that such threads have exited before stopping the service.)
        /// In particular, a control handler should avoid operations that might block, such as taking a lock,
        /// because this could result in a deadlock or cause the system to stop responding.
        /// </para>
        /// <para>
        /// When the service control manager sends a control code to a service,
        /// it waits for the handler function to return before sending additional control codes to other services.
        /// The control handler should return as quickly as possible;
        /// if it does not return within 30 seconds, the SCM returns an error.
        /// If a service must do lengthy processing when the service is executing the control handler,
        /// it should create a secondary thread to perform the lengthy processing, and then return from the control handler.
        /// This prevents the service from tying up the control dispatcher and blocking other services from receiving control codes.
        /// </para>
        /// <para>
        /// The <see cref="SERVICE_CONTROL_SHUTDOWN"/> control code should only be processed by services
        /// that must absolutely clean up during shutdown,
        /// because there is a limited time (about 20 seconds) available for service shutdown.
        /// After this time expires, system shutdown proceeds regardless of whether service shutdown is complete.
        /// Note that if the system is left in the shutdown state (not restarted or powered down), the service continues to run.
        /// If your service registers to accept <see cref="SERVICE_CONTROL_SHUTDOWN"/>,
        /// it must handle the control code and return <see cref="NO_ERROR"/>.
        /// Returning an error for this control code and not stopping in a timely fashion
        /// can increase the time required to shut down the system,
        /// because the system must wait for the full amount of time allowed for service shutdown before system shutdown can proceed.
        /// </para>
        /// <para>
        /// If the service requires more time to clean up, it should send <see cref="STOP_PENDING"/> status messages,
        /// along with a wait hint, so the service controller knows
        /// how long to wait before reporting to the system that service shutdown is complete.
        /// However, to prevent a service from stopping shutdown, there is a limit to how long the service controller waits.
        /// If the service is being shut down through the Services snap-in, the limit is 125 seconds.
        /// If the operating system is rebooting,
        /// the time limit is specified in the <c>WaitToKillServiceTimeout</c> value of the following registry key:
        /// </para>
        /// <para>
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control</c>
        /// </para>
        /// <para>
        /// Be sure to handle Plug and Play device events as quickly as possible;
        /// otherwise, the system may become unresponsive.
        /// If your event handler is to perform an operation that may block execution (such as I/O),
        /// it is best to start another thread to perform the operation asynchronously.
        /// </para>
        /// <para>
        /// Services can also use the <see cref="SetConsoleCtrlHandler"/> function to receive shutdown notification.
        /// This notification is received when the running applications are shutting down, which occurs before services are shut down.
        /// </para>
        /// </remarks>
        public delegate DWORD LphandlerFunctionEx([In] DWORD dwControl, [In] DWORD dwEventType, [In] LPVOID lpEventData, [In] LPVOID lpContext);

        /// <summary>
        /// <para>
        /// The entry point for a service.
        /// </para>
        /// <para>
        /// The <see cref="LPSERVICE_MAIN_FUNCTION"/> type defines a pointer to this callback function.
        /// <c>ServiceMain</c> is a placeholder for an application-defined function name.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lpservice_main_functionw"/>
        /// </para>
        /// </summary>
        /// <param name="dwNumServicesArgs">
        /// The number of arguments in the <paramref name="lpServiceArgVectors"/> array.
        /// </param>
        /// <param name="lpServiceArgVectors">
        /// <para>
        /// The null-terminated argument strings passed to the service by the call to the <see cref="StartService"/> function that started the service.
        /// If there are no arguments, this parameter can be <see langword="null"/>.
        /// Otherwise, the first argument (<c>lpServiceArgVectors[0]</c>) is the name of the service,
        /// followed by any additional arguments (<c>lpServiceArgVectors[1]</c> through <c>lpServiceArgVectors[dwNumServicesArgs-1]</c>).
        /// </para>
        /// <para>
        /// If the user starts a manual service using the Services snap-in from the Control Panel,
        /// the strings for the <paramref name="lpServiceArgVectors"/> parameter come from the properties dialog box for the service
        /// (from the Services snap-in, right-click the service entry, click <c>Properties</c>, and enter the parameters in Start parameters.)
        /// </para>
        /// </param>
        public delegate void LpserviceMainFunction([In] DWORD dwNumServicesArgs, [In] IntPtr[]? lpServiceArgVectors);


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
        /// Changes the optional configuration parameters of a service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-changeserviceconfig2w"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// <para>
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function
        /// and must have the <see cref="SERVICE_CHANGE_CONFIG"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// If the service controller handles the <see cref="SC_ACTION_RESTART"/> action,
        /// <paramref name="hService"/> must have the <see cref="SERVICE_START"/> access right.
        /// </para>
        /// </param>
        /// <param name="dwInfoLevel">
        /// <para>
        /// The configuration information to be changed.
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
        /// <see cref="SERVICE_CONFIG_DELAYED_AUTO_START_INFO"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_DELAYED_AUTO_START_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_DESCRIPTION"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_DESCRIPTION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_FAILURE_ACTIONS"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS"/> structure.
        /// </para>
        /// <para>
        /// If the service controller handles the <see cref="SC_ACTION_REBOOT"/> action,
        /// the caller must have the <see cref="SE_SHUTDOWN_NAME"/>.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_FAILURE_ACTIONS_FLAG"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS_FLAG"/> structure.
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
        /// <see cref="SERVICE_CONFIG_PREFERRED_NODE"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_PREFERRED_NODE_INFO"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_PRESHUTDOWN_INFO"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_PRESHUTDOWN_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_REQUIRED_PRIVILEGES_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_SERVICE_SID_INFO"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_SID_INFO"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_TRIGGER_INFO"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpInfo"/> parameter is a pointer to a <see cref="SERVICE_TRIGGER_INFO"/> structure.
        /// This value is not supported by the ANSI version of <see cref="ChangeServiceConfig2"/>.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported until Windows Server 2008 R2.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_LAUNCH_PROTECTED"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpInfo"/> parameter is a pointer a <see cref="SERVICE_LAUNCH_PROTECTED_INFO"/> structure.
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 8.1.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpInfo">
        /// A pointer to the new value to be set for the configuration information.
        /// The format of this data depends on the value of the <paramref name="dwInfoLevel"/> parameter.
        /// If this value is <see cref="NULL"/>, the information remains unchanged.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="ChangeServiceConfig2"/> function changes the optional configuration information
        /// for the specified service in the service control manager database.
        /// You can obtain the current optional configuration information by using the <see cref="QueryServiceConfig2"/> function.
        /// </para>
        /// <para>
        /// You cannot set the <see cref="SERVICE_CONFIG_FAILURE_ACTIONS"/> value
        /// for a service that shares the service control manager's process.
        /// This includes all services whose executable image is "Services.exe".
        /// </para>
        /// <para>
        /// You can change and query additional configuration information
        /// using the <see cref="ChangeServiceConfigW"/> and <see cref="QueryServiceConfigW"/> functions, respectively.
        /// </para>
        /// <para>
        /// If a service is configured to restart after it finishes with an error,
        /// the service control manager queues the restart action to occur after the specified time delay.
        /// A queued restart action cannot be canceled.
        /// If the service is manually restarted and then stopped before the queued restart action occurs,
        /// the service will restart unexpectedly when the time delay elapses.
        /// The service must be explicitly disabled to prevent it from restarting.
        /// </para>
        /// <para>
        /// The <see cref="SERVICE_CONFIG_LAUNCH_PROTECTED"/> value can be used to launch the service as protected.
        /// In order to launch the service as protected, the service must be signed with a special certificate.
        /// </para>
        /// <para>
        /// <see cref="SERVICE_CONFIG_LAUNCH_PROTECTED"/> example:
        /// </para>
        /// <code>
        /// SERVICE_LAUNCH_PROTECTED_INFO Info;
        /// SC_HANDLE hService;
        /// 
        /// Info.dwLaunchProtected = SERVICE_LAUNCH_PROTECTED_ANTIMALWARE_LIGHT;
        /// 
        /// hService = CreateService (...);
        /// 
        /// if (ChangeServiceConfig2(hService, 
        ///                         SERVICE_CONFIG_LAUNCH_PROTECTED,
        ///                         &amp;Info) == FALSE)
        /// {
        ///     Result = GetLastError();
        /// }
        /// </code>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeServiceConfig2W", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeServiceConfig2([In] SC_HANDLE hService, [In] DWORD dwInfoLevel, [In] LPVOID lpInfo);

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
        /// Enumerates services in the specified service control manager database.
        /// The name and status of each service are provided, along with additional data based on the specified information level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumservicesstatusexw"/>
        /// </para>
        /// </summary>
        /// <param name="hSCManager">
        /// A handle to the service control manager database.
        /// This handle is returned by the <see cref="OpenSCManager"/> function,
        /// and must have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="InfoLevel">
        /// <para>
        /// The service attributes that are to be returned.
        /// Use <see cref="SC_ENUM_PROCESS_INFO"/> to retrieve the name and service status information for each service in the database.
        /// The <paramref name="lpServices"/> parameter is a pointer to a buffer
        /// that receives an array of <see cref="ENUM_SERVICE_STATUS_PROCESS"/> structures.
        /// The buffer must be large enough to hold the structures as well as the strings to which their members point.
        /// </para>
        /// <para>
        /// Currently, no other information levels are defined.
        /// </para>
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
        /// Services of type <see cref="SERVICE_KERNEL_DRIVER"/> and <see cref="SERVICE_FILE_SYSTEM_DRIVER"/>.
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
        /// Services of type <see cref="SERVICE_WIN32_OWN_PROCESS"/> and <see cref="SERVICE_WIN32_SHARE_PROCESS"/>.
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
        /// <see cref="SERVICE_START_PENDING"/>, <see cref="SERVICE_STOP_PENDING"/>, <see cref="SERVICE_RUNNING"/>,
        /// <see cref="SERVICE_CONTINUE_PENDING"/>, <see cref="SERVICE_PAUSE_PENDING"/>, and <see cref="SERVICE_PAUSED"/>.
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
        /// Combines the <see cref="SERVICE_ACTIVE"/> and <see cref="SERVICE_INACTIVE"/> states.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpServices">
        /// <para>
        /// A pointer to the buffer that receives the status information.
        /// The format of this data depends on the value of the <paramref name="InfoLevel"/> parameter.
        /// </para>
        /// <para>
        /// The maximum size of this array is 256K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_MORE_DATA"/>.
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
        /// You must set this value to zero the first time the <see cref="EnumServicesStatusEx"/> function is called.
        /// On output, this value is zero if the function succeeds.
        /// However, if the function returns zero and the <see cref="GetLastError"/> function returns <see cref="ERROR_MORE_DATA"/>,
        /// this value indicates the next service entry to be read
        /// when the <see cref="EnumServicesStatusEx"/> function is called to retrieve the additional data.
        /// </param>
        /// <param name="pszGroupName">
        /// The load-order group name. If this parameter is a string, 
        /// the only services enumerated are those that belong to the group that has the name specified by the string.
        /// If this parameter is an empty string, only services that do not belong to any group are enumerated.
        /// If this parameter is <see cref="NULL"/>, group membership is ignored and all services are enumerated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following errors may be returned.
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
        /// The handle does not have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_MORE_DATA"/>
        /// </term>
        /// <term>
        /// The buffer is too small. Not all data in the active database could be returned.
        /// The <paramref name="pcbBytesNeeded"/> parameter contains the number of bytes required to receive the remaining entries.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// An illegal parameter value was used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_LEVEL"/>
        /// </term>
        /// <term>
        /// The <paramref name="InfoLevel"/> parameter contains an unsupported value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/>
        /// </term>
        /// <term>
        /// The system is shutting down; this function cannot be called.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the caller does not have the <see cref="SERVICE_QUERY_STATUS"/> access right to a service,
        /// the service is silently omitted from the list of services returned to the client.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumServicesStatusExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumServicesStatusEx([In] SC_HANDLE hSCManager, [In] SC_ENUM_TYPE InfoLevel, [In] DWORD dwServiceType,
            [In] DWORD dwServiceState, [In] nint lpServices, [In] DWORD cbBufSize, [Out] DWORD pcbBytesNeeded,
            [Out] DWORD lpServicesReturned, [In][Out] ref DWORD lpResumeHandle, [In] LPCWSTR pszGroupName);

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
        /// Retrieves the optional configuration parameters of the specified service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryserviceconfig2w"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function
        /// and must have the <see cref="SERVICE_QUERY_CONFIG"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwInfoLevel">
        /// <para>
        /// The configuration information to be queried. This parameter can be one of the following values.
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
        /// <see cref="SERVICE_CONFIG_DELAYED_AUTO_START_INFO"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_DELAYED_AUTO_START_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_DESCRIPTION"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_DESCRIPTION"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_FAILURE_ACTIONS"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_FAILURE_ACTIONS_FLAG"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS_FLAG"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:  This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_PREFERRED_NODE"/>
        /// </para>
        /// <para>
        /// 9
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_PREFERRED_NODE_INFO"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_PRESHUTDOWN_INFO"/>
        /// </para>
        /// <para>
        /// 7
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_PRESHUTDOWN_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_REQUIRED_PRIVILEGES_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_SERVICE_SID_INFO"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_SID_INFO"/> structure.
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
        /// <see cref="SERVICE_CONFIG_TRIGGER_INFO"/>
        /// </para>
        /// <para>
        /// 8
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_TRIGGER_INFO"/> structure.
        /// </para>
        /// <para>
        /// Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="SERVICE_CONFIG_LAUNCH_PROTECTED"/>
        /// </para>
        /// <para>
        /// 12
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="lpBuffer"/> parameter is a pointer a <see cref="SERVICE_LAUNCH_PROTECTED_INFO"/> structure.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 8.1.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to the buffer that receives the service configuration information.
        /// The format of this data depends on the value of the <paramref name="dwInfoLevel"/> parameter.
        /// </para>
        /// <para>
        /// The maximum size of this array is 8K bytes.
        /// To determine the required size, specify <see cref="NULL"/> for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// The <paramref name="pcbBytesNeeded"/> parameter receives the needed size.
        /// </para>
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the structure pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes required to store the configuration information,
        /// if the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
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
        /// The handle does not have the <see cref="SERVICE_QUERY_CONFIG"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// There is more service configuration information than would fit into the <paramref name="lpBuffer"/> buffer.
        /// The number of bytes required to get all the information
        /// is returned in the <paramref name="pcbBytesNeeded"/> parameter.
        /// Nothing is written to <paramref name="lpBuffer"/>.
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
        /// The <see cref="QueryServiceConfig2"/> function returns the optional configuration information
        /// stored in the service control manager database for the specified service.
        /// You can change this configuration information by using the <see cref="ChangeServiceConfig2"/> function.
        /// </para>
        /// <para>
        /// You can change and query additional configuration information
        /// using the <see cref="ChangeServiceConfig"/> and <see cref="QueryServiceConfig"/> functions, respectively.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceConfig2W", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceConfig2([In] SC_HANDLE hService, DWORD dwInfoLevel, [In] nint lpBuffer,
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

        /// <summary>
        /// <para>
        /// The <see cref="QueryServiceObjectSecurity"/> function retrieves a copy of the security descriptor associated with a service object.
        /// You can also use the <see cref="GetNamedSecurityInfo"/> function to retrieve a security descriptor.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryserviceobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service control manager or the service.
        /// Handles to the service control manager are returned by the <see cref="OpenSCManager"/> function,
        /// and handles to a service are returned by either the <see cref="OpenService"/> or <see cref="CreateService"/> function.
        /// The handle must have the <see cref="READ_CONTROL"/> access right.
        /// </param>
        /// <param name="dwSecurityInformation">
        /// A set of bit flags that indicate the type of security information to retrieve.
        /// This parameter can be a combination of the <see cref="SECURITY_INFORMATION"/> bit flags,
        /// with the exception that this function does not support the <see cref="LABEL_SECURITY_INFORMATION"/> value.
        /// </param>
        /// <param name="lpSecurityDescriptor">
        /// A pointer to a buffer that receives a copy of the security descriptor of the specified service object.
        /// The calling process must have the appropriate access to view the specified aspects of the security descriptor of the object.
        /// The <see cref="SECURITY_DESCRIPTOR"/> structure is returned in self-relative format.
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpSecurityDescriptor"/> parameter, in bytes.
        /// The largest size allowed is 8 kilobytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to return the requested security descriptor information, if the function fails.
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
        /// The specified handle was not opened with <see cref="READ_CONTROL"/> access,
        /// or the calling process is not the owner of the object.
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
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// The security descriptor information is too large for the <paramref name="lpSecurityDescriptor"/> buffer.
        /// The number of bytes required to get all the information is returned in the <paramref name="pcbBytesNeeded"/> parameter.
        /// Nothing is written to the <paramref name="lpSecurityDescriptor"/> buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// The specified security information is not valid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a service is created, the service control manager assigns a default security descriptor to the service object.
        /// To retrieve a copy of the security descriptor for a service object, call the <see cref="QueryServiceObjectSecurity"/> function.
        /// To change the security descriptor, call the <see cref="SetServiceObjectSecurity"/> function.
        /// For a description of the default security descriptor for a service object, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// To read the owner, group, or DACL from the security descriptor of the service object,
        /// the calling process must have been granted <see cref="READ_CONTROL"/> access when the handle was opened.
        /// To get <see cref="READ_CONTROL"/> access, the caller must be the owner of the object or the DACL of the object must grant the access.
        /// </para>
        /// <para>
        /// To read the SACL from the security descriptor,
        /// the calling process must have been granted <see cref="ACCESS_SYSTEM_SECURITY"/> access when the handle was opened.
        /// The correct way to get this access is to enable the <see cref="SE_SECURITY_NAME"/> privilege in the caller's current token,
        /// open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access, and then disable the privilege.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceObjectSecurity([In] SC_HANDLE hService, [In] SECURITY_INFORMATION dwSecurityInformation,
            [In] PSECURITY_DESCRIPTOR lpSecurityDescriptor, [In] DWORD cbBufSize, [Out] out DWORD pcbBytesNeeded);

        /// <summary>
        /// <para>
        /// Retrieves the current status of the specified service.
        /// </para>
        /// <para>
        /// This function has been superseded by the <see cref="QueryServiceStatusEx"/> function.
        /// <see cref="QueryServiceStatusEx"/> returns the same information <see cref="QueryServiceStatus"/> returns,
        /// with the addition of the process identifier and additional information for the service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryservicestatus"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or the <see cref="CreateService"/> function,
        /// and it must have the <see cref="SERVICE_QUERY_STATUS"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="lpServiceStatus">
        /// A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the status information.
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
        /// The handle does not have the <see cref="SERVICE_QUERY_STATUS"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceStatus([In] SC_HANDLE hService, [Out] out SERVICE_STATUS lpServiceStatus);

        /// <summary>
        /// <para>
        /// Retrieves the current status of the specified service based on the specified information level.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryservicestatusex"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="CreateService"/> or <see cref="OpenService"/> function,
        /// and it must have the <see cref="SERVICE_QUERY_STATUS"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="InfoLevel">
        /// <para>
        /// The service attributes to be returned.
        /// Use <see cref="SC_STATUS_PROCESS_INFO"/> to retrieve the service status information.
        /// The <paramref name="lpBuffer"/> parameter is a pointer to a <see cref="SERVICE_STATUS_PROCESS"/> structure.
        /// </para>
        /// <para>
        /// Currently, no other information levels are defined.
        /// </para>
        /// </param>
        /// <param name="lpBuffer">
        /// <para>
        /// A pointer to the buffer that receives the status information.
        /// The format of this data depends on the value of the <paramref name="InfoLevel"/> parameter.
        /// </para>
        /// <para>
        /// The maximum size of this array is 8K bytes.
        /// To determine the required size, specify NULL for this parameter
        /// and 0 for the <paramref name="cbBufSize"/> parameter.
        /// The function will fail and <see cref="GetLastError"/> will return ERROR_INSUFFICIENT_BUFFER.
        /// The <paramref name="pcbBytesNeeded"/> parameter will receive the required size.
        /// </para>
        /// </param>
        /// <param name="cbBufSize">
        /// The size of the buffer pointed to by the <paramref name="lpBuffer"/> parameter, in bytes.
        /// </param>
        /// <param name="pcbBytesNeeded">
        /// A pointer to a variable that receives the number of bytes needed to store all status information,
        /// if the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// The following errors can be returned.
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
        /// The handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_ACCESS_DENIED"/>
        /// </term>
        /// <term>
        /// The handle does not have the SERVICE_QUERY_STATUS access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// </term>
        /// <term>
        /// The buffer is too small for the <see cref="SERVICE_STATUS_PROCESS"/> structure.
        /// Nothing was written to the structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// The <see cref="SERVICE_STATUS_PROCESS.cbSize"/> member of <see cref="SERVICE_STATUS_PROCESS"/> is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_LEVEL"/>
        /// </term>
        /// <term>
        /// The <paramref name="InfoLevel"/> parameter contains an unsupported value.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SHUTDOWN_IN_PROGRESS"/>
        /// </term>
        /// <term>
        /// The system is shutting down; this function cannot be called.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="QueryServiceStatusEx"/> function returns the most recent service status information reported to the service control manager.
        /// If the service just changed its status, it may not have updated the service control manager yet.
        /// </para>
        /// <para>
        /// The process identifier returned in the <see cref="SERVICE_STATUS_PROCESS"/> structure
        /// is valid provided that the state of the service is one of <see cref="SERVICE_RUNNING"/>,
        /// <see cref="SERVICE_PAUSE_PENDING"/>, <see cref="SERVICE_PAUSED"/>, or <see cref="SERVICE_CONTINUE_PENDING"/>.
        /// If the service is in a <see cref="SERVICE_START_PENDING"/> or <see cref="SERVICE_STOP_PENDING"/> state,
        /// however, the process identifier may not be valid,
        /// and if the service is in the <see cref="SERVICE_STOPPED"/> state, it is never valid.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "QueryServiceStatusEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL QueryServiceStatusEx([In] SC_HANDLE hService, DWORD InfoLevel, [In] nint lpBuffer,
            [In] DWORD cbBufSize, [Out] out DWORD pcbBytesNeeded);

        /// <summary>
        /// <para>
        /// Registers a function to handle service control requests.
        /// </para>
        /// <para>
        /// This function has been superseded by the <see cref="RegisterServiceCtrlHandlerEx"/> function.
        /// A service can use either function, but the new function supports user-defined context data,
        /// and the new handler function supports additional extended control codes.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-registerservicectrlhandlerw"/>
        /// </para>
        /// </summary>
        /// <param name="lpServiceName">
        /// <para>
        /// The name of the service run by the calling thread.
        /// This is the service name that the service control program specified in the <see cref="CreateService"/> function when creating the service.
        /// </para>
        /// <para>
        /// If the service type is <see cref="SERVICE_WIN32_OWN_PROCESS"/>, the function does not verify that the specified name is valid,
        /// because there is only one registered service in the process.
        /// </para>
        /// </param>
        /// <param name="lpHandlerProc">
        /// A pointer to the handler function to be registered.
        /// For more information, see <c>Handler</c>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a service status handle.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
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
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Not enough memory is available to convert an ANSI string parameter to Unicode.
        /// This error does not occur for Unicode string parameters.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_NOT_IN_EXE"/>
        /// </term>
        /// <term>
        /// The service entry was specified incorrectly when the process called the <see cref="StartServiceCtrlDispatcher"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <c>ServiceMain</c> function of a new service should immediately call the <see cref="RegisterServiceCtrlHandler"/> function
        /// to register a control handler function with the control dispatcher.
        /// This enables the control dispatcher to invoke the specified function when it receives control requests for this service.
        /// For a list of possible control codes, see <c>Handler</c>.
        /// The threads of the calling process can use the service status handle returned by this function
        /// to identify the service in subsequent calls to the <see cref="SetServiceStatus"/> function.
        /// </para>
        /// <para>
        /// The <see cref="RegisterServiceCtrlHandler"/> function must be called before the first <see cref="SetServiceStatus"/> call
        /// because <see cref="RegisterServiceCtrlHandler"/> returns a service status handle for the caller
        /// to use so that no other service can inadvertently set this service status.
        /// In addition, the control handler must be in place to receive control requests by the time
        /// the service specifies the controls it accepts through the <see cref="SetServiceStatus"/> function.
        /// </para>
        /// <para>
        /// When the control handler function is invoked with a control request,
        /// the service must call <see cref="SetServiceStatus"/> to report status to the service control manager
        /// only if the service status has changed, such as when the service is processing stop or shutdown controls.
        /// If the service status has not changed, the service should not report status to the service control manager.
        /// </para>
        /// <para>
        /// The service status handle does not have to be closed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterServiceCtrlHandlerW", ExactSpelling = true, SetLastError = true)]
        public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandler([In] LPCWSTR lpServiceName, [In] LPHANDLER_FUNCTION lpHandlerProc);

        /// <summary>
        /// <para>
        /// Registers a function to handle extended service control requests.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-registerservicectrlhandlerexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpServiceName">
        /// The name of the service run by the calling thread.
        /// This is the service name that the service control program
        /// specified in the <see cref="CreateService"/> function when creating the service.
        /// </param>
        /// <param name="lpHandlerProc">
        /// A pointer to the handler function to be registered.
        /// For more information, see <c>HandlerEx</c>.
        /// </param>
        /// <param name="lpContext">
        /// Any user-defined data. This parameter, which is passed to the handler function,
        /// can help identify the service when multiple services share a process.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a service status handle.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The following error codes can be set by the service control manager.
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
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>
        /// </term>
        /// <term>
        /// Not enough memory is available to convert an ANSI string parameter to Unicode.
        /// This error does not occur for Unicode string parameters.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_NOT_IN_EXE"/>
        /// </term>
        /// <term>
        /// The service entry was specified incorrectly
        /// when the process called the <see cref="StartServiceCtrlDispatcher"/> function.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <c>ServiceMain</c> function of a new service should immediately call the <see cref="RegisterServiceCtrlHandlerEx"/> function
        /// to register a control handler function with the control dispatcher.
        /// This enables the control dispatcher to invoke the specified function
        /// when it receives control requests for this service.
        /// For a list of possible control codes, see <c>HandlerEx</c>.
        /// The threads of the calling process can use the service status handle returned by this function
        /// to identify the service in subsequent calls to the <see cref="SetServiceStatus"/> function.
        /// </para>
        /// <para>
        /// The <see cref="RegisterServiceCtrlHandlerEx"/> function must be called
        /// before the first <see cref="SetServiceStatus"/> call
        /// because <see cref="RegisterServiceCtrlHandlerEx"/> returns a service status handle for the caller
        /// to use so that no other service can inadvertently set this service status.
        /// In addition, the control handler must be in place to receive control requests
        /// by the time the service specifies the controls it accepts through the <see cref="SetServiceStatus"/> function.
        /// </para>
        /// <para>
        /// When the control handler function is invoked with a control request,
        /// the service must call <see cref="SetServiceStatus"/> to report status to the service control manager
        /// only if the service status has changed, such as when the service is processing stop or shutdown controls.
        /// If the service status has not changed, the service should not report status to the service control manager.
        /// </para>
        /// <para>
        /// The service status handle does not have to be closed.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterServiceCtrlHandlerExW", ExactSpelling = true, SetLastError = true)]
        public static extern SERVICE_STATUS_HANDLE RegisterServiceCtrlHandlerEx([In] LPCWSTR lpServiceName,
            [In] LPHANDLER_FUNCTION_EX lpHandlerProc, [In] LPVOID lpContext);

        /// <summary>
        /// <para>
        /// Registers a service type with the service control manager and the Server service.
        /// The Server service can then announce the registered service type as one it currently supports.
        /// The <see cref="NetServerGetInfo"/> and <see cref="NetServerEnum"/> functions obtain a specified machine's supported service types.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/lmserver/nf-lmserver-setservicebits"/>
        /// </para>
        /// </summary>
        /// <param name="hServiceStatus">
        /// A handle to the status information structure for the service.
        /// A service obtains the handle by calling the <see cref="RegisterServiceCtrlHandlerEx"/> function.
        /// </param>
        /// <param name="dwServiceBits">
        /// <para>
        /// Certain bit flags (0xC00F3F7B) are reserved for use by Microsoft.
        /// The <see cref="SetServiceBits"/> function fails with the error <see cref="ERROR_INVALID_DATA"/>
        /// if any of these bit flags are set in <paramref name="dwServiceBits"/>.
        /// The following bit flags are reserved for use by Microsoft.
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_WORKSTATION"/> (0x00000001)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_SERVER"/> (0x00000002)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_CTRL"/> (0x00000008)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_BAKCTRL"/> (0x00000010)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_TIME_SOURCE"/> (0x00000020)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_AFP"/> (0x00000040)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_MEMBER"/> (0x00000100)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_PRINTQ_SERVER"/> (0x00000200)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DIALIN_SERVER"/> (0x00000400)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_XENIX_SERVER"/> (0x00000800)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_SERVER_UNIX"/> (0x00000800)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_NT"/> (0x00001000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_WFW"/> (0x00002000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_POTENTIAL_BROWSER"/> (0x00010000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_BACKUP_BROWSER"/> (0x00020000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_MASTER_BROWSER"/> (0x00040000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_MASTER"/> (0x00080000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_LOCAL_LIST_ONLY"/> (0x40000000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_ENUM"/> (0x80000000)
        /// </para>
        /// <para>
        /// Certain bit flags (0x00300084) are defined by Microsoft, but are not specifically reserved for systems software.
        /// The following are these bit flags.
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_SV_TYPE_SQLSERVER"/> (0x00000004)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_NOVELL"/> (0x00000080)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_CTRL"/> (0x00100000)
        /// </para>
        /// <para>
        /// <see cref="SV_TYPE_DOMAIN_BAKCTRL"/> (0x00200000)
        /// </para>
        /// <para>
        /// Certain bit flags (0x3FC0C000) are not defined by Microsoft, and their use is not coordinated by Microsoft.
        /// Developers of applications that use these bits should be aware that other applications can also use them, thus creating a conflict.
        /// The following are these bit flags.
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// <para>
        /// 0x00400000
        /// </para>
        /// <para>
        /// 0x00800000
        /// </para>
        /// <para>
        /// 0x01000000
        /// </para>
        /// <para>
        /// 0x02000000
        /// </para>
        /// <para>
        /// 0x04000000
        /// </para>
        /// <para>
        /// 0x08000000
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// <para>
        /// 0x20000000
        /// </para>
        /// </param>
        /// <param name="bSetBitsOn">
        /// If this value is <see cref="TRUE"/>, the bits in <paramref name="dwServiceBit"/> are to be set.
        /// If this value is <see cref="FALSE"/>, the bits are to be cleared.
        /// </param>
        /// <param name="bUpdateImmediately">
        /// If this value is <see cref="TRUE"/>, the Server service is to perform an immediate update.
        /// If this value is <see cref="FALSE"/>, the update is not be performed immediately.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetServiceBits", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetServiceBits([In] SERVICE_STATUS_HANDLE hServiceStatus, [In] DWORD dwServiceBits,
            [In] BOOL bSetBitsOn, [In] BOOL bUpdateImmediately);

        /// <summary>
        /// <para>
        /// The <see cref="SetServiceObjectSecurity"/> function sets the security descriptor of a service object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-setserviceobjectsecurity"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function.
        /// The access required for this handle depends on the security information
        /// specified in the <paramref name="dwSecurityInformation"/> parameter.
        /// </param>
        /// <param name="dwSecurityInformation">
        /// <para>
        /// Specifies the components of the security descriptor to set.
        /// This parameter can be a combination of the following values.
        /// Note that flags not handled by <see cref="SetServiceObjectSecurity"/> will be silently ignored.
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
        /// <see cref="DACL_SECURITY_INFORMATION"/>
        /// </term>
        /// <term>
        /// Sets the discretionary access control list (DACL) of the object.
        /// The handle specified by <paramref name="hService"/> must have <see cref="WRITE_DAC"/> access,
        /// or the calling process must be the owner of the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="GROUP_SECURITY_INFORMATION"/>
        /// </term>
        /// <term>
        /// Sets the primary group security identifier (SID) of the object.
        /// The handle specified by <paramref name="hService"/> must have <see cref="WRITE_OWNER"/> access,
        /// or the calling process must be the owner of the object.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="OWNER_SECURITY_INFORMATION"/>
        /// </term>
        /// <term>
        /// Sets the SID of the owner of the object.
        /// The handle specified by <paramref name="hService"/> must have <see cref="WRITE_OWNER"/> access,
        /// or the calling process must be the owner of the object or have the <see cref="SE_TAKE_OWNERSHIP_NAME"/> privilege enabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SACL_SECURITY_INFORMATION"/>
        /// </term>
        /// <term>
        /// <para>
        /// Sets the system access control list (SACL) of the object.
        /// The handle specified by <paramref name="hService"/> must have <see cref="ACCESS_SYSTEM_SECURITY"/> access.
        /// </para>
        /// <para>
        /// To obtain <see cref="ACCESS_SYSTEM_SECURITY"/> access
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// Enable the <see cref="SE_SECURITY_NAME"/> privilege in the current access token of the caller.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Open the handle for <see cref="ACCESS_SYSTEM_SECURITY"/> access.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Disable the privilege.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="lpSecurityDescriptor">
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that contains the new security information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the function returns nonzero.
        /// </para>
        /// <para>
        /// If the function fails, it returns zero.
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
        /// The specified handle was not opened with the required access,
        /// or the calling process is not the owner of the object.
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
        /// <see cref="ERROR_INVALID_PARAMETER"/>
        /// </term>
        /// <term>
        /// The specified security information or security descriptor is not valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/>
        /// </term>
        /// <term>
        /// The specified service has been marked for deletion.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SetServiceObjectSecurity"/> function sets the specified portions of the security descriptor
        /// of the service object based on the information specified in the <paramref name="lpSecurityDescriptor"/> buffer.
        /// This function replaces any or all of the security information associated with the service object,
        /// according to the flags set in the <paramref name="dwSecurityInformation"/> parameter
        /// and subject to the access rights of the calling process.
        /// </para>
        /// <para>
        /// When a service is created, the service control manager assigns a default security descriptor to the service object.
        /// To retrieve a copy of the security descriptor for a service object, call the <see cref="QueryServiceObjectSecurity"/> function.
        /// For a description of the default security descriptor for a service object, see Service Security and Access Rights.
        /// </para>
        /// <para>
        /// Note that granting certain access to untrusted users (such as <see cref="SERVICE_CHANGE_CONFIG"/> or <see cref="SERVICE_STOP"/>)
        /// can allow them to interfere with the execution of your service
        /// and possibly allow them to run applications under the LocalSystem account.
        /// </para>
        /// </remarks>
        [Obsolete("SetServiceObjectSecurity is available for use in the operating systems specified in the Requirements section. " +
            "It may be altered or unavailable in subsequent versions. " +
            "Instead, use the SetNamedSecurityInfo function.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetServiceObjectSecurity", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetServiceObjectSecurity([In] SC_HANDLE hService, [In] SECURITY_INFORMATION dwSecurityInformation,
            [In] PSECURITY_DESCRIPTOR lpSecurityDescriptor);

        /// <summary>
        /// <para>
        /// Updates the service control manager's status information for the calling service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-setservicestatus"/>
        /// </para>
        /// </summary>
        /// <param name="hServiceStatus">
        /// A handle to the status information structure for the current service.
        /// This handle is returned by the <see cref="RegisterServiceCtrlHandlerEx"/> function.
        /// </param>
        /// <param name="lpServiceStatus">
        /// A pointer to the <see cref="SERVICE_STATUS"/> structure the contains the latest status information for the calling service.
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
        /// <see cref="ERROR_INVALID_DATA"/>
        /// </term>
        /// <term>
        /// The specified service status structure is invalid.
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
        /// A <c>ServiceMain</c> function first calls the <see cref="RegisterServiceCtrlHandlerEx"/> function
        /// to get the service's <see cref="SERVICE_STATUS_HANDLE"/>.
        /// Then it immediately calls the <see cref="SetServiceStatus"/> function
        /// to notify the service control manager that its status is <see cref="SERVICE_START_PENDING"/>.
        /// During initialization, the service can provide updated status to indicate that it is making progress but it needs more time.
        /// A common bug is for the service to have the main thread perform the initialization
        /// while a separate thread continues to call <see cref="SetServiceStatus"/>
        /// to prevent the service control manager from marking it as hung.
        /// However, if the main thread hangs, then the service start ends up in an infinite loop
        /// because the worker thread continues to report that the main thread is making progress.
        /// </para>
        /// <para>
        /// After processing a control request, the service's <c>Handler</c> function must call <see cref="SetServiceStatus"/>
        /// if the service status changes to report its new status to the service control manager.
        /// It is only necessary to do so when the service is changing state, such as when it is processing stop or shutdown controls.
        /// A service can also use this function at any time from any thread of the service
        /// to notify the service control manager of state changes, such as when the service must stop due to a recoverable error.
        /// </para>
        /// <para>
        /// A service can call this function only after it has called <see cref="RegisterServiceCtrlHandlerEx"/> to get a service status handle.
        /// </para>
        /// <para>
        /// If a service calls <see cref="SetServiceStatus"/>
        /// with the <see cref="SERVICE_STATUS.dwCurrentState"/> member set to <see cref="SERVICE_STOPPED"/>
        /// and the <see cref="SERVICE_STATUS.dwWin32ExitCode"/> member set to a nonzero value,
        /// the following entry is written into the System event log:
        /// </para>
        /// <code>
        ///    Event ID    = 7023
        ///    Source      = Service Control Manager
        ///    Type        = Error
        ///    Description = &lt;ServiceName&gt; terminated with the following error:
        ///                  &lt;ExitCode&gt;.
        /// </code>
        /// <para>
        /// The following are best practices when calling this function:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Initialize all fields in the <see cref="SERVICE_STATUS"/> structure,
        /// ensuring that there are valid check-point and wait hint values for pending states.
        /// Use reasonable wait hints.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Do not register to accept controls while the status is <see cref="SERVICE_START_PENDING"/> or the service can crash.
        /// After initialization is completed, accept the <see cref="SERVICE_CONTROL_STOP"/> code.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Call this function with checkpoint and wait-hint values only if the service is making progress on the tasks
        /// related to the pending start, stop, pause, or continue operation.
        /// Otherwise, SCM cannot detect if your service is hung.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Enter the stopped state with an appropriate exit code if <c>ServiceMain</c> fails.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the status is <see cref="SERVICE_STOPPED"/>,
        /// perform all necessary cleanup and call <see cref="SetServiceStatus"/> one time only.
        /// This function makes an LRPC call to the SCM.
        /// The first call to the function in the <see cref="SERVICE_STOPPED"/> state
        /// closes the RPC context handle and any subsequent calls can cause the process to crash.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Do not attempt to perform any additional work after calling <see cref="SetServiceStatus"/> with <see cref="SERVICE_STOPPED"/>,
        /// because the service process can be terminated at any time.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetServiceStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetServiceStatus([In] SERVICE_STATUS_HANDLE hServiceStatus, [In] in SERVICE_STATUS lpServiceStatus);

        /// <summary>
        /// <para>
        /// Connects the main thread of a service process to the service control manager,
        /// which causes the thread to be the service control dispatcher thread for the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-startservicectrldispatcherw"/>
        /// </para>
        /// </summary>
        /// <param name="lpServiceStartTable">
        /// A pointer to an array of <see cref="SERVICE_TABLE_ENTRY"/> structures
        /// containing one entry for each service that can execute in the calling process.
        /// The members of the last entry in the table must have <c>NULL</c> values to designate the end of the table.
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
        /// <see cref="ERROR_FAILED_SERVICE_CONTROLLER_CONNECT"/>
        /// </term>
        /// <term>
        /// <para>
        /// This error is returned if the program is being run as a console application rather than as a service.
        /// </para>
        /// <para>
        /// If the program will be run as a console application for debugging purposes,
        /// structure it such that service-specific code is not called when this error is returned.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_DATA"/>
        /// </term>
        /// <term>
        /// The specified dispatch table contains entries that are not in the proper format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_ALREADY_RUNNING"/>
        /// </term>
        /// <term>
        /// The process has already called <see cref="StartServiceCtrlDispatcher"/>.
        /// Each process can call <see cref="StartServiceCtrlDispatcher"/> only one time.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When the service control manager starts a service process,
        /// it waits for the process to call the <see cref="StartServiceCtrlDispatcher"/> function.
        /// The main thread of a service process should make this call as soon as possible after it starts up (within 30 seconds).
        /// If <see cref="StartServiceCtrlDispatcher"/> succeeds, it connects the calling thread to the service control manager
        /// and does not return until all running services in the process have entered the <see cref="SERVICE_STOPPED"/> state.
        /// The service control manager uses this connection to send control and service start requests
        /// to the main thread of the service process.
        /// The main thread acts as a dispatcher by invoking the appropriate <c>HandlerEx</c> function to handle control requests,
        /// or by creating a new thread to execute the appropriate <see cref="ServiceMain"/> function when a new service is started.
        /// </para>
        /// <para>
        /// The <paramref name="lpServiceStartTable"/> parameter contains an entry for each service that can run in the calling process.
        /// Each entry specifies the <c>ServiceMain</c> function for that service.
        /// For <see cref="SERVICE_WIN32_SHARE_PROCESS"/> services, each entry must contain the name of a service.
        /// This name is the service name that was specified by the <see cref="CreateService"/> function when the service was installed.
        /// For <see cref="SERVICE_WIN32_OWN_PROCESS"/> services, the service name in the table entry is ignored.
        /// </para>
        /// <para>
        /// If a service runs in its own process, the main thread of the service process should immediately call <see cref="StartServiceCtrlDispatcher"/>.
        /// All initialization tasks are done in the service's <c>ServiceMain</c> function when the service is started.
        /// </para>
        /// <para>
        /// If multiple services share a process and some common process-wide initialization needs to be done
        /// before any <c>ServiceMain</c> function is called, the main thread can do the work before calling <see cref="StartServiceCtrlDispatcher"/>,
        /// as long as it takes less than 30 seconds.
        /// Otherwise, another thread must be created to do the process-wide initialization,
        /// while the main thread calls <see cref="StartServiceCtrlDispatcher"/> and becomes the service control dispatcher.
        /// Any service-specific initialization should still be done in the individual service main functions.
        /// </para>
        /// <para>
        /// Services should not attempt to display a user interface directly.
        /// For more information, see Interactive Services.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartServiceCtrlDispatcherW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StartServiceCtrlDispatcher([In] SERVICE_TABLE_ENTRY[] lpServiceStartTable);

        /// <summary>
        /// <para>
        /// Starts a service.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-startservicew"/>
        /// </para>
        /// </summary>
        /// <param name="hService">
        /// A handle to the service.
        /// This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function,
        /// and it must have the <see cref="SERVICE_START"/> access right.
        /// For more information, see Service Security and Access Rights.
        /// </param>
        /// <param name="dwNumServiceArgs">
        /// The number of strings in the <paramref name="lpServiceArgVectors"/> array.
        /// If <paramref name="lpServiceArgVectors"/> is <see langword="null"/>, this parameter can be zero.
        /// </param>
        /// <param name="lpServiceArgVectors">
        /// <para>
        /// The null-terminated strings to be passed to the <c>ServiceMain</c> function for the service as arguments.
        /// If there are no arguments, this parameter can be <see langword="null"/>.
        /// Otherwise, the first argument (<c>lpServiceArgVectors[0]</c>) is the name of the service,
        /// followed by any additional arguments (<c>lpServiceArgVectors[1]</c> through <c>lpServiceArgVectors[dwNumServiceArgs-1]</c>).
        /// </para>
        /// <para>
        /// Driver services do not receive these arguments.
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
        /// The handle does not have the <see cref="SERVICE_START"/> access right.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_HANDLE"/>
        /// </term>
        /// <term>
        /// The handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_PATH_NOT_FOUND"/>
        /// </term>
        /// <term>
        /// The service binary file could not be found.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_ALREADY_RUNNING"/>
        /// </term>
        /// <term>
        /// An instance of the service is already running.
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
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_DEPENDENCY_DELETED"/>
        /// </term>
        /// <term>
        /// The service depends on a service that does not exist or has been marked for deletion.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_DEPENDENCY_FAIL"/>
        /// </term>
        /// <term>
        /// The service depends on another service that has failed to start.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_DISABLED"/>
        /// </term>
        /// <term>
        /// The service has been disabled.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_LOGON_FAILED"/>
        /// </term>
        /// <term>
        /// The service did not start due to a logon failure.
        /// This error occurs if the service is configured to run under an account
        /// that does not have the "Log on as a service" right.
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
        /// <item>
        /// <term>
        /// <see cref="ERROR_SERVICE_NO_THREAD"/>
        /// </term>
        /// <term>
        /// A thread could not be created for the service.
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
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a driver service is started, the <see cref="StartService"/> function does not return
        /// until the device driver has finished initializing.
        /// </para>
        /// <para>
        /// When a service is started, the Service Control Manager (SCM) spawns the service process, if necessary.
        /// If the specified service shares a process with other services, the required process may already exist.
        /// The <see cref="StartService"/> function does not wait for the first status update from the new service,
        /// because it can take a while.
        /// Instead, it returns when the SCM receives notification from the service control dispatcher
        /// that the <c>ServiceMain</c> thread for this service was created successfully.
        /// </para>
        /// <para>
        /// The SCM sets the following default status values before returning from <see cref="StartService"/>:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Current state of the service is set to <see cref="SERVICE_START_PENDING"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Controls accepted is set to none (zero).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The CheckPoint value is set to zero.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The WaitHint time is set to 2 seconds.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The calling process can determine if the new service has finished its initialization
        /// by calling the <see cref="QueryServiceStatus"/> function periodically to query the service's status.
        /// </para>
        /// <para>
        /// A service cannot call <see cref="StartService"/> during initialization.
        /// The reason is that the SCM locks the service control database during initialization,
        /// so a call to <see cref="StartService"/> will block.
        /// After the service reports to the SCM that it has successfully started, it can call <see cref="StartService"/>.
        /// </para>
        /// <para>
        /// As with <see cref="ControlService"/>, <see cref="StartService"/> will block for 30 seconds
        /// if any service is busy handling a control code.
        /// If the busy service still has not returned from its handler function when the timeout expires,
        /// <see cref="StartService"/> fails with <see cref="ERROR_SERVICE_REQUEST_TIMEOUT"/>.
        /// This is because the SCM processes only one service control notification at a time.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "StartServiceW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL StartService([In] SC_HANDLE hService, [In] DWORD dwNumServiceArgs, [In] IntPtr[]? lpServiceArgVectors);

        /// <summary>
        /// <para>
        /// Unlocks a service control manager database by releasing the specified lock.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-unlockservicedatabase"/>
        /// </para>
        /// </summary>
        /// <param name="ScLock">
        /// The lock, which is obtained from a previous call to the <see cref="LockServiceDatabase"/> function.
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
        /// <see cref="ERROR_INVALID_SERVICE_LOCK"/>
        /// </term>
        /// <term>
        /// The specified lock is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        [Obsolete("This function has no effect as of Windows Vista.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnlockServiceDatabase", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnlockServiceDatabase([In] SC_LOCK ScLock);
    }
}
