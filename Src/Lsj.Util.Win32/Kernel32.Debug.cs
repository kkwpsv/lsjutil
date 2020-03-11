﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Waits for a debugging event to occur in a process being debugged.
        /// In the past, the operating system did not output Unicode strings via <see cref="OutputDebugString"/> and instead only output ASCII strings.
        /// To force <see cref="OutputDebugString"/> to correctly output Unicode strings,
        /// debuggers are required to call <see cref="WaitForDebugEventEx"/> to opt into the new behavior.
        /// On calling <see cref="WaitForDebugEventEx"/>, the operating system will know that the debugger supports Unicode
        /// and is specifically opting into receiving Unicode strings.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/debugapi/nf-debugapi-waitfordebugevent
        /// </para>
        /// </summary>
        /// <param name="lpDebugEvent">
        /// A pointer to a <see cref="DEBUG_EVENT"/> structure that receives information about the debugging event.
        /// </param>
        /// <param name="dwMilliseconds">
        /// The number of milliseconds to wait for a debugging event.
        /// If this parameter is zero, the function tests for a debugging event and returns immediately.
        /// If the parameter is <see cref="INFINITE"/>, the function does not return until a debugging event has occurred.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Only the thread that created the process being debugged can call <see cref="WaitForDebugEvent"/>.
        /// When a <see cref="CREATE_PROCESS_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the image file of the process being debugged,
        /// a handle to the process being debugged, and a handle to the initial thread of the process being debugged in the <see cref="DEBUG_EVENT"/> structure.
        /// The members these handles are returned in are u.CreateProcessInfo.hFile (image file), u.CreateProcessInfo.hProcess (process),
        /// and u.CreateProcessInfo.hThread (initial thread).
        /// If the system previously reported an <see cref="EXIT_PROCESS_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the process and thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// The debugger should close the handle to the image file by calling the CloseHandle function.
        /// Similarly, when a <see cref="CREATE_THREAD_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the thread
        /// whose creation caused the debugging event in the u.CreateThread.hThread member of the <see cref="DEBUG_EVENT"/> structure.
        /// If the system previously reported an <see cref="EXIT_THREAD_DEBUG_EVENT"/> debugging event,
        /// the system closes the handles to the thread when the debugger calls the <see cref="ContinueDebugEvent"/> function.
        /// When a <see cref="LOAD_DLL_DEBUG_EVENT"/> occurs, the debugger application receives a handle to the loaded DLL
        /// in the u.LoadDll.hFile member of the <see cref="DEBUG_EVENT"/> structure.
        /// This handle should be closed by the debugger application by calling the <see cref="CloseHandle"/> function.
        /// Do not queue an asynchronous procedure call (APC) to a thread that calls <see cref="WaitForDebugEvent"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "WaitForDebugEvent", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WaitForDebugEvent([In]IntPtr lpDebugEvent, [In]uint dwMilliseconds);
    }
}
