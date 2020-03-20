using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ThreadCreationFlags;
using static Lsj.Util.Win32.Enums.ThreadPriorityFlags;
using static Lsj.Util.Win32.Enums.ProcessPriorityClasses;
using Lsj.Util.Win32.BaseTypes;

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
        public delegate void PTP_TIMER_CALLBACK([In]PTP_CALLBACK_INSTANCE Instance, [In]PVOID Context, [In] PTP_TIMER Timer);

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
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateThreadpoolTimer", SetLastError = true)]
        public static extern PTP_TIMER CreateThreadpoolTimer([MarshalAs(UnmanagedType.FunctionPtr)][In]PTP_TIMER_CALLBACK pfnti,
          [In]PVOID pv, [In]PTP_CALLBACK_ENVIRON pcbe);
    }
}
