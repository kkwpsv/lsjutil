using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SynchronizationObjectAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// CREATE_WAITABLE_TIMER_MANUAL_RESET
        /// </summary>
        public const uint CREATE_WAITABLE_TIMER_MANUAL_RESET = 1;

        /// <summary>
        /// <para>
        /// An application-defined timer completion routine.
        /// Specify this address when calling the <see cref="SetWaitableTimer"/> function.
        /// The <see cref="PTIMERAPCROUTINE"/> type defines a pointer to this callback function.
        /// TimerAPCProc is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nc-synchapi-ptimerapcroutine
        /// </para>
        /// </summary>
        /// <param name="lpArgToCompletionRoutine">
        /// The value passed to the function using the lpArgToCompletionRoutine parameter of the <see cref="SetWaitableTimer"/> function.
        /// </param>
        /// <param name="dwTimerLowValue">
        /// The low-order portion of the UTC-based time at which the timer was signaled.
        /// This value corresponds to the <see cref="FILETIME.dwLowDateTime"/> member of the <see cref="FILETIME"/> structure.
        /// For more information about UTC-based time, see System Time.
        /// </param>
        /// <param name="dwTimerHighValue">
        /// The high-order portion of the UTC-based time at which the timer was signaled.
        /// This value corresponds to the <see cref="FILETIME.dwHighDateTime"/> member of the <see cref="FILETIME"/> structure.
        /// </param>
        /// <remarks>
        /// The completion routine is executed by the thread that activates the timer using <see cref="SetWaitableTimer"/>.
        /// However, the thread must be in an alertable state.
        /// For more information, see Asynchronous Procedure Calls.
        /// </remarks>
        public delegate void PTIMERAPCROUTINE([In]IntPtr lpArgToCompletionRoutine, [In]uint dwTimerLowValue, [In]uint dwTimerHighValue);

        /// <summary>
        /// <para>
        /// Sets the specified waitable timer to the inactive state.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-cancelwaitabletimer
        /// </para>
        /// </summary>
        /// <param name="hTimer">
        /// A handle to the timer object.
        /// The <see cref="CreateWaitableTimer"/> or OpenWaitableTimer<see cref="OpenWaitableTimer"/> function returns this handle.
        /// The handle must have the <see cref="TIMER_MODIFY_STATE"/> access right.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelWaitableTimer", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CancelWaitableTimer([In]IntPtr hTimer);

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object.
        /// To specify an access mask for the object, use the <see cref="CreateWaitableTimerEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="bManualReset">
        /// If this parameter is <see langword="true"/>, the timer is a manual-reset notification timer.
        /// Otherwise, the timer is a synchronization timer.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The handle returned by <see cref="CreateWaitableTimer"/> is created with the <see cref="TIMER_ALL_ACCESS"/> access right;
        /// it can be used in any function that requires a handle to a timer object, provided that the caller has been granted access.
        /// If a timer is created from a service or thread that is impersonating a different user,
        /// you can either apply a security descriptor to the timer when you create it,
        /// or change the default security descriptor for the creating process by changing its default DACL.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimer(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes, [In]bool bManualReset,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName);

        /// <summary>
        /// <para>
        /// Creates or opens a waitable timer object and returns a handle to the object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-createwaitabletimerexw
        /// </para>
        /// </summary>
        /// <param name="lpTimerAttributes">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that specifies a security descriptor
        /// for the new timer object and determines whether child processes can inherit the returned handle.
        /// If <paramref name="lpTimerAttributes"/> is <see langword="null"/>,
        /// the timer object gets a default security descriptor and the handle cannot be inherited.
        /// The ACLs in the default security descriptor for a timer come from the primary or impersonation token of the creator.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
        /// If <param ref="lpTimerName"/> is <see langword="null"/>, the timer object is created without a name.
        /// If <param ref="lpTimerName"/> matches the name of an existing event, semaphore, mutex, job, or file-mapping object,
        /// the function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// This occurs because these objects share the same namespace.
        /// The name can have a "Global" or "Local" prefix to explicitly create the object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character().
        /// For more information, see Kernel Object Namespaces.
        /// Fast user switching is implemented using Terminal Services sessions.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// The object can be created in a private namespace.
        /// For more information, see Object Namespaces.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be 0 or the following value.
        /// <see cref="CREATE_WAITABLE_TIMER_MANUAL_RESET"/>:
        /// The timer must be manually reset. Otherwise, the system automatically resets the timer after releasing a single waiting thread.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access mask for the timer object.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the named timer object exists before the function call, the function returns a handle to the existing object
        /// and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Any thread of the calling process can specify the timer object handle in a call to one of the wait functions.
        /// Multiple processes can have handles to the same timer object, enabling use of the object for interprocess synchronization.
        /// A process created by the <see cref="CreateProcess"/> function can inherit a handle to a timer object
        /// if the <paramref name="lpTimerAttributes"/> parameter of <see cref="CreateWaitableTimer"/> enables inheritance.
        /// A process can specify the timer object handle in a call to the <see cref="DuplicateHandle"/> function.
        /// The resulting handle can be used by another process.
        /// A process can specify the name of a timer object in a call
        /// to the <see cref="OpenWaitableTimer"/> or <see cref="CreateWaitableTimer"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To associate a timer with a window, use the <see cref="SetTimer"/> function.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWaitableTimerExW", SetLastError = true)]
        public static extern IntPtr CreateWaitableTimerEx(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpTimerAttributes, [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName,
            [In]IntPtr dwFlags, [In]uint dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens an existing named waitable timer object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-openwaitabletimerw
        /// </para>
        /// </summary>
        /// <param name="dwDesiredAccess">
        /// The access to the timer object.
        /// The function fails if the security descriptor of the specified object does not permit the requested access for the calling process.
        /// For a list of access rights, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="bInheritHandle">
        /// If this value is <see langword="true"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="lpTimerName">
        /// The name of the timer object.
        /// The name is limited to <see cref="MAX_PATH"/> characters.
        /// Name comparison is case sensitive.
        /// This function can open objects in a private namespace. For more information, see Object Namespaces.
        /// Terminal Services: The name can have a "Global" or "Local" prefix to explicitly open an object in the global or session namespace.
        /// The remainder of the name can contain any character except the backslash character ().
        /// For more information, see Kernel Object Namespaces.
        /// Note Fast user switching is implemented using Terminal Services sessions.
        /// The first user to log on uses session 0, the next user to log on uses session 1, and so on.
        /// Kernel object names must follow the guidelines outlined for Terminal Services so that applications can support multiple users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer object.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="OpenWaitableTimer"/> function enables multiple processes to open handles to the same timer object.
        /// The function succeeds only if some process has already created the timer using the <see cref="CreateWaitableTimer"/> function.
        /// The calling process can use the returned handle in any function that requires the handle to a timer object,
        /// such as the wait functions, subject to the limitations of the access specified in the <paramref name="dwDesiredAccess"/> parameter.
        /// The returned handle can be duplicated by using the <see cref="DuplicateHandle"/> function.
        /// Use the <see cref="CloseHandle"/> function to close the handle.
        /// The system closes the handle automatically when the process terminates.
        /// The timer object is destroyed when its last handle has been closed.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenWaitableTimerW", SetLastError = true)]
        public static extern IntPtr OpenWaitableTimer([In]uint dwDesiredAccess, [In]bool bInheritHandle,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpTimerName);

        /// <summary>
        /// <para>
        /// Activates the specified waitable timer.
        /// When the due time arrives, the timer is signaled and the thread that set the timer calls the optional completion routine.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-setwaitabletimer
        /// </para>
        /// </summary>
        /// <param name="hTimer">
        /// A handle to the timer object.
        /// The <see cref="CreateWaitableTimer"/> or <see cref="OpenWaitableTimer"/> function returns this handle.
        /// The handle must have the <see cref="TIMER_MODIFY_STATE"/> access right.
        /// For more information, see Synchronization Object Security and Access Rights.
        /// </param>
        /// <param name="lpDueTime">
        /// The time after which the state of the timer is to be set to signaled, in 100 nanosecond intervals.
        /// Use the format described by the <see cref="FILETIME"/> structure.
        /// Positive values indicate absolute time.
        /// Be sure to use a UTC-based absolute time, as the system uses UTC-based time internally.
        /// Negative values indicate relative time.
        /// The actual timer accuracy depends on the capability of your hardware.
        /// For more information about UTC-based time, see System Time.
        /// </param>
        /// <param name="lPeriod">
        /// The period of the timer, in milliseconds.
        /// If <paramref name="lPeriod"/> is zero, the timer is signaled once.
        /// If <paramref name="lPeriod"/> is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses,
        /// until the timer is canceled using the <see cref="CancelWaitableTimer"/> function or reset using <see cref="SetWaitableTimer"/>.
        /// If <paramref name="lPeriod"/> is less than zero, the function fails.
        /// </param>
        /// <param name="pfnCompletionRoutine">
        /// A pointer to an optional completion routine.
        /// The completion routine is application-defined function of type <see cref="PTIMERAPCROUTINE"/> to be executed when the timer is signaled.
        /// For more information on the timer callback function, see <see cref="PTIMERAPCROUTINE"/>.
        /// For more information about APCs and thread pool threads, see Remarks.
        /// </param>
        /// <param name="lpArgToCompletionRoutine">
        /// A pointer to a structure that is passed to the completion routine.
        /// </param>
        /// <param name="fResume">
        /// If this parameter is <see langword="true"/>, restores a system in suspended power conservation mode when the timer state is set to signaled.
        /// Otherwise, the system is not restored.
        /// If the system does not support a restore, the call succeeds, but <see cref="GetLastError"/> returns <see cref="ERROR_NOT_SUPPORTED"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Timers are initially inactive.
        /// To activate a timer, call <see cref="SetWaitableTimer"/>.
        /// If the timer is already active when you call <see cref="SetWaitableTimer"/>, the timer is stopped, then it is reactivated.
        /// Stopping the timer in this manner does not set the timer state to signaled, so threads blocked in a wait operation on the timer remain blocked.
        /// However, it does cancel any pending completion routines.
        /// When the specified due time arrives, the timer becomes inactive and the optional APC is queued to the thread that set the timer.
        /// The state of the timer is set to signaled, the timer is reactivated using the specified period,
        /// and the thread that set the timer calls the completion routine when it enters an alertable wait state.
        /// If the timer is set before the thread enters an alertable wait state, the APC is canceled.
        /// For more information, see <see cref="QueueUserAPC"/>.
        /// Note that APCs do not work as well as other signaling mechanisms for thread pool threads
        /// because the system controls the lifetime of thread pool threads,
        /// so it is possible for a thread to be terminated before the notification is delivered.
        /// Instead of using the <paramref name="pfnCompletionRoutine"/> parameter or another APC-based signaling mechanism,
        /// use a waitable object such as a timer created with <see cref="CreateThreadpoolTimer"/>.
        /// For I/O, use an I/O completion object created with <see cref="CreateThreadpoolIo"/> or an hEvent-based <see cref="OVERLAPPED"/> structure
        /// where the event can be passed to the <see cref="SetThreadpoolWait"/> function.
        /// If the thread that set the timer terminates and there is an associated completion routine, the timer is canceled.
        /// However, the state of the timer remains unchanged.
        /// If there is no completion routine, then terminating the thread has no effect on the timer.
        /// When a manual-reset timer is set to the signaled state,
        /// it remains in this state until <see cref="SetWaitableTimer"/> is called to reset the timer.
        /// As a result, a periodic manual-reset timer is set to the signaled state when the initial due time arrives
        /// and remains signaled until it is reset.
        /// When a synchronization timer is set to the signaled state,
        /// it remains in this state until a thread completes a wait operation on the timer object.
        /// If the system time is adjusted, the due time of any outstanding absolute timers is adjusted.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0400 or later.
        /// For more information, see Using the Windows Headers.
        /// To use a timer to schedule an event for a window, use the <see cref="SetTimer"/> function.
        /// APIs that deal with timers use various different hardware clocks.
        /// These clocks may have resolutions significantly different from what you expect:
        /// some may be measured in milliseconds (for those that use an RTC-based timer chip),
        /// to those measured in nanoseconds (for those that use ACPI or TSC counters).
        /// You can change the resolution of your API with a call to the <see cref="timeBeginPeriod"/> and <see cref="timeEndPeriod"/> functions.
        /// How precise you can change the resolution depends on which hardware clock the particular API uses.
        /// For more information, check your hardware documentation.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenWaitableTimerW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWaitableTimer([In]IntPtr hTimer, [MarshalAs(UnmanagedType.LPStruct)][In]LARGE_INTEGER lpDueTime, [In]int lPeriod,
            [MarshalAs(UnmanagedType.FunctionPtr)][In]PTIMERAPCROUTINE pfnCompletionRoutine, [In]IntPtr lpArgToCompletionRoutine, [In]bool fResume);
    }
}
