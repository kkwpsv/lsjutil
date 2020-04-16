using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains thread-creation information that can be used by a debugger.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-create_thread_debug_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CREATE_THREAD_DEBUG_INFO
    {
        /// <summary>
        /// A handle to the thread whose creation caused the debugging event.
        /// If this member is <see cref="NULL"/>, the handle is not valid.
        /// Otherwise, the debugger has <see cref="THREAD_GET_CONTEXT"/>, <see cref="THREAD_SET_CONTEXT"/>,
        /// and <see cref="THREAD_SUSPEND_RESUME"/> access to the thread, allowing the debugger to read from and write
        /// to the registers of the thread and control execution of the thread.
        /// </summary>
        public HANDLE hThread;

        /// <summary>
        /// A pointer to a block of data.
        /// At offset 0x2C into this block is another pointer, called ThreadLocalStoragePointer,
        /// that points to an array of per-module thread local storage blocks.
        /// This gives a debugger access to per-thread data in the threads of the process being debugged using the same algorithms that a compiler would use.
        /// </summary>
        public LPVOID lpThreadLocalBase;

        /// <summary>
        /// A pointer to the starting address of the thread.
        /// This value may only be an approximation of the thread's starting address,
        /// because any application with appropriate access to the thread can change the thread's context by using the <see cref="SetThreadContext"/> function.
        /// </summary>
        public LPTHREAD_START_ROUTINE lpStartAddress;
    }
}
