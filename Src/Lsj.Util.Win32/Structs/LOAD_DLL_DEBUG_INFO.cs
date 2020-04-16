using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a dynamic-link library (DLL) that has just been loaded.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-load_dll_debug_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LOAD_DLL_DEBUG_INFO
    {
        /// <summary>
        /// A handle to the loaded DLL.
        /// If this member is <see cref="NULL"/>, the handle is not valid.
        /// Otherwise, the member is opened for reading and read-sharing in the context of the debugger.
        /// When the debugger is finished with this file, it should close the handle using the <see cref="CloseHandle"/> function.
        /// </summary>
        public HANDLE hFile;

        /// <summary>
        /// A pointer to the base address of the DLL in the address space of the process loading the DLL.
        /// </summary>
        public LPVOID lpBaseOfDll;

        /// <summary>
        /// The offset to the debugging information in the file identified by the <see cref="hFile"/> member, in bytes.
        /// The system expects the debugging information to be in CodeView 4.0 format.
        /// This format is currently a derivative of Common Object File Format (COFF).
        /// </summary>
        public DWORD dwDebugInfoFileOffset;

        /// <summary>
        /// The size of the debugging information in the file, in bytes.
        /// If this member is zero, there is no debugging information.
        /// </summary>
        public DWORD nDebugInfoSize;

        /// <summary>
        /// A pointer to the file name associated with <see cref="hFile"/>.
        /// This member may be <see cref="NULL"/>, or it may contain the address of a string pointer in the address space of the process being debugged.
        /// That address may, in turn, either be <see cref="NULL"/> or point to the actual filename.
        /// If <see cref="fUnicode"/> is a nonzero value, the name string is Unicode; otherwise, it is ANSI.
        /// This member is strictly optional.
        /// Debuggers must be prepared to handle the case where <see cref="lpImageName"/> is <see cref="NULL"/>
        /// or *<see cref="lpImageName"/> (in the address space of the process being debugged) is <see cref="NULL"/>.
        /// Specifically, the system will never provide an image name for a create process event,
        /// and it will not likely pass an image name for the first DLL event.
        /// The system will also never provide this information in the case of debugging events that originate
        /// from a call to the <see cref="DebugActiveProcess"/> function.
        /// </summary>
        public LPVOID lpImageName;

        /// <summary>
        /// A value that indicates whether a filename specified by lpImageName is Unicode or ANSI.
        /// A nonzero value for this member indicates Unicode; zero indicates ANSI.
        /// </summary>
        public WORD fUnicode;
    }
}
