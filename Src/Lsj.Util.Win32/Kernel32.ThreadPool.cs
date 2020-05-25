using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadPoolFlags;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// PTP_CLEANUP_GROUP_CANCEL_CALLBACK
        /// </summary>
        /// <param name="ObjectContext"></param>
        /// <param name="CleanupContext"></param>
        public delegate void PTP_CLEANUP_GROUP_CANCEL_CALLBACK([In] PVOID ObjectContext, [In] PVOID CleanupContext);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="TrySubmitThreadpoolCallback"/> function to start a worker thread.
        /// The <see cref="PTP_SIMPLE_CALLBACK"/> type defines a pointer to this callback function.
        /// SimpleCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms686295(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance. Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        public delegate void PTP_SIMPLE_CALLBACK([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SubmitThreadpoolWork"/> function
        /// to start a worker thread for the work object.
        /// The <see cref="PTP_WORK_CALLBACK"/> type defines a pointer to this callback function.
        /// WorkCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms687396(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A <see cref="TP_CALLBACK_INSTANCE"/> structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="SetEventWhenCallbackReturns"/>
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>
        /// <see cref="ReleaseMutexWhenCallbackReturns"/>
        /// <see cref="FreeLibraryWhenCallbackReturns"/>
        /// <see cref="CallbackMayRunLong"/>
        /// <see cref="DisassociateCurrentThreadFromCallback"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Work">
        /// A TP_WORK structure that defines the work object that generated the callback.
        /// </param>
        public delegate void PTP_WORK_CALLBACK([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_WORK Work);

        /// <summary>
        /// <para>
        /// Applications implement this callback if they call the <see cref="SetThreadpoolTimer"/> function to start a worker thread for the timer object.
        /// The <see cref="PTP_TIMER_CALLBACK"/> type defines a pointer to this callback function.
        /// TimerCallback is a placeholder for the application-defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/ms686790(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="Instance">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance.
        /// Applications do not modify the members of this structure.
        /// This structure can be passed to one of the following functions:
        /// <see cref="CallbackMayRunLong"/>, <see cref="DisassociateCurrentThreadFromCallback"/>, <see cref="FreeLibraryWhenCallbackReturns"/>,
        /// <see cref="LeaveCriticalSectionWhenCallbackReturns"/>, <see cref="ReleaseMutexWhenCallbackReturns"/>,
        /// <see cref="ReleaseSemaphoreWhenCallbackReturns"/>, <see cref="SetEventWhenCallbackReturns"/>
        /// </param>
        /// <param name="Context">
        /// The application-defined data.
        /// </param>
        /// <param name="Timer">
        /// A TP_TIMER structure that defines the timer object that generated the callback.
        /// </param>
        public delegate void PTP_TIMER_CALLBACK([In] PTP_CALLBACK_INSTANCE Instance, [In] PVOID Context, [In] PTP_TIMER Timer);

        /// <summary>
        /// <para>
        /// Indicates that the callback may not return quickly.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-callbackmayrunlong
        /// </para>
        /// </summary>
        /// <param name="pci">
        /// A TP_CALLBACK_INSTANCE structure that defines the callback instance. The structure is passed to the callback function.
        /// </param>
        /// <returns>
        /// The function returns <see cref="TRUE"/> if another thread in the thread pool is available for processing callbacks
        /// or the thread pool was able to spin up a new thread. In this case, the current callback function may use the current thread indefinitely.
        /// The function returns <see cref="FALSE"/> if another thread in the thread pool is not available to process callbacks
        /// and the thread pool was not able to spin up a new thread.
        /// The thread pool will attempt to spin up a new thread after a delay, but if the current callback function runs long,
        /// the thread pool may lose efficiency.
        /// </returns>
        /// <remarks>
        /// The thread pool may use this information to better determine when a new thread should be created.
        /// The <see cref="CallbackMayRunLong"/> function should be called only by the thread that is processing the callback.
        /// Calling this function from another thread may cause a race condition.
        /// The <see cref="CallbackMayRunLong"/> function always marks the callback as long-running,
        /// whether or not a thread is available for processing callbacks or the threadpool is able to allocate a new thread.
        /// Therefore, this function should be called only once, even if it returns <see cref="FALSE"/>.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CallbackMayRunLong", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CallbackMayRunLong([In] PTP_CALLBACK_INSTANCE pci);

        /// <summary>
        /// <para>
        /// Creates a new timer object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpooltimer
        /// </para>
        /// </summary>
        /// <param name="pfnti">
        /// The callback function to call each time the timer object expires.
        /// For details, see <see cref="PTP_TIMER_CALLBACK"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A TP_CALLBACK_ENVIRON structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_TIMER structure that defines the timer object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="IntPtr.Zero"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set the timer object, call the <see cref="SetThreadpoolTimer"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_TIMER CreateThreadpoolTimer([MarshalAs(UnmanagedType.FunctionPtr)][In] PTP_TIMER_CALLBACK pfnti,
          [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a new work object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-createthreadpoolwork
        /// </para>
        /// </summary>
        /// <param name="pfnwk">
        /// The callback function.
        /// A worker thread calls this callback each time you call <see cref="SubmitThreadpoolWork"/> to post the work object.
        /// For details, see WorkCallback.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a TP_WORK structure that defines the work object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="NULL"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_WORK CreateThreadpoolWork([In] PTP_WORK_CALLBACK pfnwk, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Creates a queue for timers.
        /// Timer-queue timers are lightweight objects that enable you to specify a callback function to be called at a specified time.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueue
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the timer queue.
        /// This handle can be used only in functions that require a handle to a timer queue.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To add a timer to the queue, call the <see cref="CreateTimerQueueTimer"/> function.
        /// To remove a timer from the queue, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// When you are finished with the queue of timers, call the <see cref="DeleteTimerQueueEx"/> function to delete the timer queue.
        /// Any pending timers in the queue are canceled and deleted.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueue", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateTimerQueue();

        /// <summary>
        /// <para>
        /// Creates a timer-queue timer.
        /// This timer expires at the specified due time, then after every specified period.
        /// When the timer expires, the callback function is called.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueuetimer
        /// </para>
        /// </summary>
        /// <param name="phNewTimer">
        /// A pointer to a buffer that receives a handle to the timer-queue timer on return.
        /// When this handle has expired and is no longer required, release it by calling <see cref="DeleteTimerQueueTimer"/>.
        /// </param>
        /// <param name="TimerQueue">
        /// A handle to the timer queue. This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// If this parameter is <see cref="NULL"/>, the timer is associated with the default timer queue.
        /// </param>
        /// <param name="Callback">
        /// A pointer to the application-defined function of type <see cref="WAITORTIMERCALLBACK"/> to be executed when the timer expires.
        /// For more information, see WaitOrTimerCallback.
        /// </param>
        /// <param name="DueTime">
        /// The amount of time in milliseconds relative to the current time that must elapse before the timer is signaled for the first time.
        /// </param>
        /// <param name="Period">
        /// The period of the timer, in milliseconds.
        /// If this parameter is zero, the timer is signaled once.
        /// If this parameter is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses, until the timer is canceled.
        /// </param>
        /// <param name="Flags">
        /// This parameter can be one or more of the following values from WinNT.h.
        /// <see cref="WT_EXECUTEDEFAULT"/>, <see cref="WT_EXECUTEINTIMERTHREAD"/>, <see cref="WT_EXECUTEINIOTHREAD"/>,
        /// <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, <see cref="WT_EXECUTELONGFUNCTION"/>, <see cref="WT_EXECUTEONLYONCE"/>,
        /// <see cref="WT_TRANSFER_IMPERSONATION"/>
        /// </param>
        /// <param name="Parameter">
        /// A single parameter value that will be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the DueTime and Period parameters are both nonzero, the timer will be signaled first at the due time, then periodically.
        /// The callback is called every time the period elapses, whether or not the previous callback has finished executing.
        /// Callback functions are queued to the thread pool.
        /// These threads are subject to scheduling delays, so the timing can vary depending on what else is happening in the application or the system.
        /// The time that the system spends in sleep or hibernation does not count toward the expiration of the timer.
        /// The timer is signaled when the cumulative amount of elapsed time the system spends in the waking state matches the timer's due time or period.
        /// Windows Server 2003 and Windows XP:
        /// The time that the system spends in sleep or hibernation counts toward the expiration of the timer.
        /// If the timer expires while the system is sleeping, the timer is signaled immediately when the system wakes.
        /// To cancel a timer, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
        /// By default, the thread pool has a maximum of 500 threads.
        /// To raise this limit, use the <see cref="WT_SET_MAX_THREADPOOL_THREAD"/> macro defined in WinNT.h.
        /// <code>
        /// #define WT_SET_MAX_THREADPOOL_THREADS(Flags,Limit) \
        /// ((Flags)|=(Limit)&lt;&lt;16)
        /// </code>
        /// Use this macro when specifying the <paramref name="Flags"/> parameter.
        /// The macro parameters are the desired flags and the new limit (up to (2&lt;&lt;16)-1 threads).
        /// However, note that your application can improve its performance by keeping the number of worker threads low.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateTimerQueueTimer([Out] out HANDLE phNewTimer, [In] HANDLE TimerQueue, [In] WAITORTIMERCALLBACK Callback,
            [In] PVOID DueTime, [In] DWORD Period, [In] ThreadPoolFlags Flags, [In] ULONG Parameter);

        /// <summary>
        /// <para>
        /// Deletes a timer queue. Any pending timers in the queue are canceled and deleted.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-deletetimerqueueex
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// A handle to the timer queue. This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// A handle to the event object to be signaled when the function is successful and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Do not make blocking calls to <see cref="DeleteTimerQueueEx"/> from within a timer callback.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteTimerQueueEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteTimerQueueEx([In] HANDLE TimerQueue, [In] HANDLE CompletionEvent);

        /// <summary>
        /// <para>
        /// Removes a timer from the timer queue and optionally waits for currently running timer callback functions to complete before deleting the timer.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-deletetimerqueuetimer
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// If the timer was created using the default timer queue, this parameter should be <see cref="NULL"/>.
        /// </param>
        /// <param name="Timer">
        /// A handle to the timer-queue timer.
        /// This handle is returned by the <see cref="CreateTimerQueueTimer"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// A handle to the event object to be signaled when the system has canceled the timer and all callback functions have completed.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, 
        /// the function waits for any running timer callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// If the timer has already expired, the timer callback function will run to completion.
        /// However, there is no notification sent when the timer callback function has completed.
        /// Most callers should not use this option, and should wait for running timer callback functions to complete
        /// so they can perform any needed cleanup.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// If the error code is <see cref="ERROR_IO_PENDING"/>, it is not necessary to call this function again.
        /// For any other error, you should retry the call.
        /// </returns>
        /// <remarks>
        /// This function cannot be called while the thread is using impersonation.
        /// The resulting behavior is undefined.
        /// You can set <paramref name="CompletionEvent"/> to <see cref="INVALID_HANDLE_VALUE"/> when calling this function
        /// from within the timer callback of another timer as long as the callback function is not executed in the timer thread.
        /// However, a deadlock may occur if two callback functions attempt a blocking <see cref="DeleteTimerQueueTimer"/> call on each others' timers.
        /// Furthermore, you cannot make a blocking deletion call on a timer associated with the callback.
        /// Be careful when making a blocking <see cref="DeleteTimerQueueTimer"/> call on a persistent thread.
        /// If the timer being deleted was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// If there are outstanding callback functions and <paramref name="CompletionEvent"/> is <see cref="NULL"/>,
        /// the function will fail and set the error code to <see cref="ERROR_IO_PENDING"/>.
        /// This indicates that there are outstanding callback functions.
        /// Those callbacks either will execute or are in the middle of executing.
        /// The timer is cleaned up when the callback function is finished executing.
        /// To cancel all timers in a timer queue, call the <see cref="DeleteTimerQueueEx"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteTimerQueueTimer([In] HANDLE TimerQueue, [In] HANDLE Timer, [In] HANDLE CompletionEvent);

        /// <summary>
        /// <para>
        /// Initializes a callback environment.
        /// </para>
        /// <para>
        /// https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-initializethreadpoolenvironment
        /// </para>
        /// </summary>
        /// <param name="pcbe">
        /// A TP_CALLBACK_ENVIRON structure that defines a callback environment.
        /// </param>
        /// <remarks>
        /// By default, a callback executes in the default thread pool for the process.
        /// No cleanup group is associated with the callback environment, the caller is responsible for
        /// keeping the callback's DLL loaded while there are outstanding callbacks,
        /// and the callback is expected to run in a reasonable amount of time for the application.
        /// Create a callback environment if you plan to call one of the following functions to modify the environment:
        /// <see cref="SetThreadpoolCallbackCleanupGroup"/>
        /// <see cref="SetThreadpoolCallbackLibrary"/>
        /// <see cref="SetThreadpoolCallbackPool"/>
        /// <see cref="SetThreadpoolCallbackPriority"/>
        /// <see cref="SetThreadpoolCallbackRunsLong"/>
        /// To use the default callback environment, set the optional callback environment parameter to <see cref="NULL"/>
        /// when calling one of the following functions:
        /// <see cref="CreateThreadpoolIo"/>
        /// <see cref="CreateThreadpoolTimer"/>
        /// <see cref="CreateThreadpoolWait"/>
        /// <see cref="CreateThreadpoolWork"/>
        /// <see cref="TrySubmitThreadpoolCallback"/>
        /// The <see cref="InitializeThreadpoolEnvironment"/> function is implemented as an inline function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "InitializeThreadpoolEnvironment", ExactSpelling = true, SetLastError = true)]
        public static extern void InitializeThreadpoolEnvironment([In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Posts a work object to the thread pool.
        /// A worker thread calls the work object's callback function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-submitthreadpoolwork
        /// </para>
        /// </summary>
        /// <param name="pwk">
        /// A TP_WORK structure that defines the work object.
        /// The <see cref="CreateThreadpoolWork"/> function returns this structure.
        /// </param>
        /// <remarks>
        /// You can post a work object one or more times (up to <see cref="MAXULONG"/>) without waiting for prior callbacks to complete.
        /// The callbacks will execute in parallel.
        /// To improve efficiency, the thread pool may throttle the threads.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SubmitThreadpoolWork", ExactSpelling = true, SetLastError = true)]
        public static extern void SubmitThreadpoolWork([In] PTP_WORK pwk);

        /// <summary>
        /// <para>
        /// Requests that a thread pool worker thread call the specified callback function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoolapiset/nf-threadpoolapiset-trysubmitthreadpoolcallback
        /// </para>
        /// </summary>
        /// <param name="pfns">
        /// The callback function. For details, see <see cref="PTP_SIMPLE_CALLBACK"/>.
        /// </param>
        /// <param name="pv">
        /// Optional application-defined data to pass to the callback function.
        /// </param>
        /// <param name="pcbe">
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback function.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="NullRef{TP_CALLBACK_ENVIRON}"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrySubmitThreadpoolCallback", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrySubmitThreadpoolCallback([In] PTP_SIMPLE_CALLBACK pfns, [In] PVOID pv, [In][Out] ref TP_CALLBACK_ENVIRON pcbe);

        /// <summary>
        /// <para>
        /// Cancels a registered wait operation issued by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-unregisterwaitex
        /// </para>
        /// </summary>
        /// <param name="WaitHandle">
        /// The wait handle.
        /// This handle is returned by the <see cref="RegisterWaitForSingleObject"/> function.
        /// </param>
        /// <param name="CompletionEvent">
        /// A handle to the event object to be signaled when the wait operation has been unregistered.
        /// This parameter can be <see cref="NULL"/>.
        /// If this parameter is <see cref="INVALID_HANDLE_VALUE"/>, the function waits for all callback functions to complete before returning.
        /// If this parameter is <see cref="NULL"/>, the function marks the timer for deletion and returns immediately.
        /// However, most callers should wait for the callback function to complete so they can perform any needed cleanup.
        /// If the caller provides this event and the function succeeds or the function fails with <see cref="ERROR_IO_PENDING"/>,
        /// do not close the event until it is signaled.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// You cannot make a blocking call to <see cref="UnregisterWaitEx"/> from within a callback function for the same wait operation.
        /// Otherwise, the callback will be waiting for itself to finish.
        /// In general, a blocking call to <see cref="UnregisterWaitEx"/> creates a dependency between the current thread and the callback,
        /// so to make a blocking unregister call on another wait operation, you must ensure that the callback functions do not depend on
        /// one another and that the second wait operation does not also perform a blocking unregister call on the first operation.
        /// Be careful when making a blocking <see cref="UnregisterWaitEx"/> call on a persistent thread.
        /// If the wait operation being unregistered was created with <see cref="WT_EXECUTEINPERSISTENTTHREAD"/>, a deadlock may occur.
        /// After making non-blocking call to <see cref="UnregisterWaitEx"/>,
        /// no new callback functions associated with <paramref name="WaitHandle"/> can be queued.
        /// However, there may be pending callback functions already queued to worker threads.
        /// Under some conditions, the function will fail with <see cref="ERROR_IO_PENDING"/> if <paramref name="CompletionEvent"/> is <see cref="NULL"/>.
        /// This indicates that there are outstanding callback functions. Those callbacks either will execute or are in the middle of executing.
        /// If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller, it is possible for the function to succeed,
        /// fail with <see cref="ERROR_IO_PENDING"/>, or fail with a different error code.
        /// If the function succeeds, or if the function fails with <see cref="ERROR_IO_PENDING"/>,
        /// the caller should always wait until the event is signaled to close the event.
        /// If the function fails with a different error code, it is not necessary to wait until the event is signaled to close the event.
        /// Windows XP: If <paramref name="CompletionEvent"/> is a handle to an event provided by the caller
        /// and the function fails with <see cref="ERROR_IO_PENDING"/>, the caller should wait until the event is signaled to close the event.
        /// This behavior changed starting with Windows Vista.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later.
        /// For more information, see Using the Windows Headers.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "UnregisterWaitEx", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnregisterWaitEx([In] HANDLE WaitHandle, [In] HANDLE CompletionEvent);
    }
}
