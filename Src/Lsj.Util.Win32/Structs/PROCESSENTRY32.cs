using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an entry from a list of the processes residing in the system address space when a snapshot was taken.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/tlhelp32/ns-tlhelp32-processentry32"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PROCESSENTRY32
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the <see cref="Process32First"/> function, set this member to <code>sizeof(PROCESSENTRY32)</code>. 
        /// If you do not initialize <see cref="dwSize"/>, <see cref="Process32First"/> fails.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD cntUsage;

        /// <summary>
        /// The process identifier.
        /// </summary>
        public DWORD th32ProcessID;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public ULONG_PTR th32DefaultHeapID;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD th32ModuleID;

        /// <summary>
        /// The number of execution threads started by the process.
        /// </summary>
        public DWORD cntThreads;

        /// <summary>
        /// The identifier of the process that created this process (its parent process).
        /// </summary>
        public DWORD th32ParentProcessID;

        /// <summary>
        /// The base priority of any threads created by this process.
        /// </summary>
        public LONG pcPriClassBase;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// The name of the executable file for the process.
        /// To retrieve the full path to the executable file, call the <see cref="Module32First"/> function
        /// and check the <see cref="MODULEENTRY32.szExePath"/> member of the <see cref="MODULEENTRY32"/> structure that is returned.
        /// However, if the calling process is a 32-bit process, you must call the <see cref="QueryFullProcessImageName"/> function
        /// to retrieve the full path of the executable file for a 64-bit process.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExeFile;
    }
}
