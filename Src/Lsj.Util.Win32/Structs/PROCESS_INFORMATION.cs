using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a newly created process and its primary thread.
    /// It is used with the <see cref="CreateProcess"/>, <see cref="CreateProcessAsUser"/>, <see cref="CreateProcessWithLogonW"/>,
    /// or <see cref="CreateProcessWithTokenW"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-process_information"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the function succeeds, be sure to call the <see cref="CloseHandle"/> function to close
    /// the <see cref="hProcess"/> and <see cref="hThread"/> handles when you are finished with them.
    /// Otherwise, when the child process exits, the system cannot clean up the process structures for the child process
    /// because the parent process still has open handles to the child process.
    /// However, the system will close these handles when the parent process terminates,
    /// so the structures related to the child process object would be cleaned up at this point.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESS_INFORMATION
    {
        /// <summary>
        /// A handle to the newly created process.
        /// The handle is used to specify the process in all functions that perform operations on the process object.
        /// </summary>
        public HANDLE hProcess;

        /// <summary>
        /// A handle to the primary thread of the newly created process.
        /// The handle is used to specify the thread in all functions that perform operations on the thread object.
        /// </summary>
        public HANDLE hThread;

        /// <summary>
        /// A value that can be used to identify a process.
        /// The value is valid from the time the process is created until all handles to the process are closed and the process object is freed;
        /// at this point, the identifier may be reused.
        /// </summary>
        public DWORD dwProcessId;

        /// <summary>
        /// A value that can be used to identify a thread.
        /// The value is valid from the time the thread is created until all handles to the thread are closed and the thread object is freed;
        /// at this point, the identifier may be reused.
        /// </summary>
        public DWORD dwThreadId;
    }
}
