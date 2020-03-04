using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Waits until the specified object is in the signaled state or the time-out interval elapses.
        /// To enter an alertable wait state, use the <see cref="WaitForSingleObjectEx"/> function.
        /// To wait for multiple objects, use <see cref="WaitForMultipleObjects"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/synchapi/nf-synchapi-waitforsingleobject
        /// </para>
        /// </summary>
        /// <param name="hHandle">
        /// A handle to the object.
        /// For a list of the object types whose handles can be specified, see the following Remarks section.
        /// If this handle is closed while the wait is still pending, the function's behavior is undefined.
        /// The handle must have the <see cref="SYNCHRONIZE"/> access right.
        /// For more information, see Standard Access Rights.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The time-out interval, in milliseconds.
        /// If a nonzero value is specified, the function waits until the object is signaled or the interval elapses.
        /// If <paramref name="dwMilliseconds"/> is zero, the function does not enter a wait state if the object is not signaled; it always returns immediately.
        /// If <paramref name="dwMilliseconds"/> is <see cref="INFINITE"/>, the function will return only when the object is signaled.
        /// Windows XP, Windows Server 2003, Windows Vista, Windows 7, Windows Server 2008 and Windows Server 2008 R2:
        /// The <paramref name="dwMilliseconds"/> value does include time spent in low-power states.
        /// For example, the timeout does keep counting down while the computer is asleep.
        /// Windows 8, Windows Server 2012, Windows 8.1, Windows Server 2012 R2, Windows 10 and Windows Server 2016:
        /// The <paramref name="dwMilliseconds"/> value does not include time spent in low-power states.
        /// For example, the timeout does not keep counting down while the computer is asleep.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value indicates the event that caused the function to return.
        /// It can be one of the following values.
        /// <see cref="WAIT_ABANDONED"/>:
        /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated.
        /// Ownership of the mutex object is granted to the calling thread and the mutex state is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// <see cref="WAIT_OBJECT_0"/>:
        /// The state of the specified object is signaled.
        /// <see cref="WAIT_TIMEOUT"/>:
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// <see cref="WAIT_FAILED"/>:
        /// The function has failed. To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="WaitForSingleObject"/> function checks the current state of the specified object.
        /// If the object's state is nonsignaled, the calling thread enters the wait state until the object is signaled or the time-out interval elapses.
        /// The function modifies the state of some types of synchronization objects.
        /// Modification occurs only for the object whose signaled state caused the function to return.
        /// For example, the count of a semaphore object is decreased by one.
        /// The <see cref="WaitForSingleObject"/> function can wait for the following objects:
        /// Change notification, Console input, Event, Memory resource notification, Mutex, Process, Semaphore, Thread, Waitable timer
        /// Use caution when calling the wait functions and code that directly or indirectly creates windows.
        /// If a thread creates any windows, it must process messages.
        /// Message broadcasts are sent to all windows in the system.
        /// A thread that uses a wait function with no time-out interval may cause the system to become deadlocked.
        /// Two examples of code that indirectly creates windows are DDE and the <see cref="CoInitialize"/> function.
        /// Therefore, if you have a thread that creates windows, use <see cref="MsgWaitForMultipleObjects"/> or <see cref="MsgWaitForMultipleObjectsEx"/>,
        /// rather than <see cref="WaitForSingleObject"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForSingleObject", SetLastError = true)]
        public static extern uint WaitForSingleObject([In]IntPtr hHandle, [In]uint dwMilliseconds);
    }
}
