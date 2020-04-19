using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32
{
    public static partial class Kernel32
    {
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
        /// A <see cref="TP_CALLBACK_INSTANCE"/> structure that defines the callback instance.
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
        /// A <see cref="TP_TIMER"/> structure that defines the timer object that generated the callback.
        /// </param>
        public delegate void PTP_TIMER_CALLBACK([In]PTP_CALLBACK_INSTANCE Instance, [In]PVOID Context, [In]PTP_TIMER Timer);

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
        public static extern BOOL CallbackMayRunLong([In]PTP_CALLBACK_INSTANCE pci);

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
        /// A <see cref="TP_CALLBACK_ENVIRON"/> structure that defines the environment in which to execute the callback.
        /// The <see cref="InitializeThreadpoolEnvironment"/> function returns this structure.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the callback executes in the default callback environment.
        /// For more information, see <see cref="InitializeThreadpoolEnvironment"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a <see cref="TP_TIMER"/> structure that defines the timer object.
        /// Applications do not modify the members of this structure.
        /// If the function fails, it returns <see cref="IntPtr.Zero"/>.
        /// To retrieve extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To set the timer object, call the <see cref="SetThreadpoolTimer"/> function.
        /// To compile an application that uses this function, define _WIN32_WINNT as 0x0600 or higher.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolTimer", ExactSpelling = true, SetLastError = true)]
        public static extern PTP_TIMER CreateThreadpoolTimer([MarshalAs(UnmanagedType.FunctionPtr)][In]PTP_TIMER_CALLBACK pfnti,
          [In]PVOID pv, [In]PTP_CALLBACK_ENVIRON pcbe);
    }
}
