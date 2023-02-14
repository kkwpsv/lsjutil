using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ThreadAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains process creation information that can be used by a debugger.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-create_process_debug_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CREATE_PROCESS_DEBUG_INFO
    {
        /// <summary>
        /// A handle to the process's image file.
        /// If this member is <see cref="NULL"/>, the handle is not valid.
        /// Otherwise, the debugger can use the member to read from and write to the image file.
        /// When the debugger is finished with this file, it should close the handle using the <see cref="CloseHandle"/> function.
        /// </summary>
        public HANDLE hFile;

        /// <summary>
        /// A handle to the process.
        /// If this member is <see cref="NULL"/>, the handle is not valid.
        /// Otherwise, the debugger can use the member to read from and write to the process's memory.
        /// </summary>
        public HANDLE hProcess;

        /// <summary>
        /// A handle to the initial thread of the process identified by the <see cref="hProcess"/> member.
        /// If <see cref="hThread"/> param is <see cref="NULL"/>, the handle is not valid.
        /// Otherwise, the debugger has <see cref="THREAD_GET_CONTEXT"/>, <see cref="THREAD_SET_CONTEXT"/>,
        /// and <see cref="THREAD_SUSPEND_RESUME"/> access to the thread,
        /// allowing the debugger to read from and write to the registers of the thread and to control execution of the thread.
        /// </summary>
        public HANDLE hThread;

        /// <summary>
        /// The base address of the executable image that the process is running.
        /// </summary>
        public LPVOID lpBaseOfImage;

        /// <summary>
        /// The offset to the debugging information in the file identified by the <see cref="hFile"/> member.
        /// </summary>
        public DWORD dwDebugInfoFileOffset;

        /// <summary>
        /// The size of the debugging information in the file, in bytes. If this value is zero, there is no debugging information.
        /// </summary>
        public DWORD nDebugInfoSize;

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

        /// <summary>
        /// A pointer to the file name associated with the <see cref="hFile"/> member.
        /// This parameter may be <see cref="NULL"/>, or it may contain the address of a string pointer in the address space of the process being debugged.
        /// That address may, in turn, either be <see cref="NULL"/> or point to the actual filename.
        /// If <see cref="fUnicode"/> is a nonzero value, the name string is Unicode; otherwise, it is ANSI.
        /// This member is strictly optional.
        /// Debuggers must be prepared to handle the case where <see cref="lpImageName"/> is <see cref="NULL"/>
        /// or *<see cref="lpImageName"/> (in the address space of the process being debugged) is <see cref="NULL"/>.
        /// Specifically, the system does not provide an image name for a create process event,
        /// and will not likely pass an image name for the first DLL event.
        /// The system also does not provide this information in the case of debug events
        /// that originate from a call to the <see cref="DebugActiveProcess"/> function.
        /// </summary>
        public LPVOID lpImageName;

        /// <summary>
        /// A value that indicates whether a file name specified by the <see cref="lpImageName"/> member is Unicode or ANSI.
        /// A nonzero value indicates Unicode; zero indicates ANSI.
        /// </summary>
        public WORD fUnicode;
    }
}
