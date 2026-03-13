using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.ULONG;
using static Lsj.Util.Win32.BaseTypes.WaitResult;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FileCompletionNotificationModes;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.ThreadPoolCallbackPriorities;
using static Lsj.Util.Win32.Enums.WorkThreadFlags;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TimerQueue"></param>
        /// <param name="Timer"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CancelTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CancelTimerQueueTimer([In] HANDLE TimerQueue, [In] HANDLE Timer);

        /// <summary>
        /// <para>
        /// Updates a timer-queue timer that was created by the <see cref="CreateTimerQueueTimer"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-changetimerqueuetimer"/>
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// <para>
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the timer is associated with the default timer queue.
        /// </para>
        /// </param>
        /// <param name="Timer">
        /// A handle to the timer-queue timer.
        /// This handle is returned by the <see cref="CreateTimerQueueTimer"/> function.
        /// </param>
        /// <param name="DueTime">
        /// The time after which the timer should expire, in milliseconds.s
        /// </param>
        /// <param name="Period">
        /// The period of the timer, in milliseconds.
        /// If this parameter is zero, the timer is signaled once.
        /// If this parameter is greater than zero, the timer is periodic.
        /// A periodic timer automatically reactivates each time the period elapses,
        /// until the timer is canceled using the <see cref="DeleteTimerQueueTimer"/> function
        /// or reset using <see cref="ChangeTimerQueueTimer"/>.
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
        /// This function cannot be called while the thread is using impersonation.
        /// The resulting behavior is undefined.
        /// </para>
        /// <para>
        /// You can call <see cref="ChangeTimerQueueTimer"/> in a timer callback.
        /// </para>
        /// <para>
        /// If you call <see cref="ChangeTimerQueueTimer"/> on a one-shot timer (its period is zero)
        /// that has already expired, the timer is not updated.
        /// </para>
        /// <para>
        /// Do not call <see cref="ChangeTimerQueueTimer"/> after calling <see cref="DeleteTimerQueueTimer"/> on a handle.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "ChangeTimerQueueTimer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ChangeTimerQueueTimer([In] HANDLE TimerQueue, [In] HANDLE Timer, [In] ULONG DueTime, [In] ULONG Period);

        /// <summary>
        /// <para>
        /// Creates a queue for timers.
        /// Timer-queue timers are lightweight objects that enable you to specify a callback function to be called at a specified time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-createtimerqueue"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the timer queue.
        /// This handle can be used only in functions that require a handle to a timer queue.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To add a timer to the queue, call the <see cref="CreateTimerQueueTimer"/> function.
        /// To remove a timer from the queue, call the <see cref="DeleteTimerQueueTimer"/> function.
        /// </para>
        /// <para>
        /// When you are finished with the queue of timers, call the <see cref="DeleteTimerQueueEx"/> function to delete the timer queue.
        /// Any pending timers in the queue are canceled and deleted.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateTimerQueue", ExactSpelling = true, SetLastError = true)]
        public static extern HANDLE CreateTimerQueue();

        /// <summary>
        /// <para>
        /// Deletes a timer queue.
        /// Any pending timers in the queue are canceled and deleted.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This function is obsolete and has been replaced by the <see cref="DeleteTimerQueueEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/threadpoollegacyapiset/nf-threadpoollegacyapiset-deletetimerqueue"/>
        /// </para>
        /// </summary>
        /// <param name="TimerQueue">
        /// A handle to the timer queue.
        /// This handle is returned by the <see cref="CreateTimerQueue"/> function.
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
        /// <see cref="DeleteTimerQueue"/> does not wait for all callback functions associated with the timer to complete.
        /// </remarks>
        [Obsolete]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteTimerQueue", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DeleteTimerQueue([In] HANDLE TimerQueue);
    }
}
