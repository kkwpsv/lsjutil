using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an entry from a list that enumerates the heaps used by a specified process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/ns-tlhelp32-heaplist32"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HEAPLIST32
    {
        /// <summary>
        /// HF32_DEFAULT
        /// </summary>
        public static readonly DWORD HF32_DEFAULT = 1;

        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the <see cref="Heap32ListFirst"/> function, set this member to <code>sizeof(HEAPLIST32)</code>. 
        /// If you do not initialize <see cref="dwSize"/>, <see cref="Heap32ListFirst"/> will fail.
        /// </summary>
        public SIZE_T dwSize;

        /// <summary>
        /// The identifier of the process to be examined.
        /// </summary>
        public DWORD th32ProcessID;

        /// <summary>
        /// The heap identifier. This is not a handle, and has meaning only to the tool help functions.
        /// </summary>
        public ULONG_PTR th32HeapID;

        /// <summary>
        /// This member can be one of the following values.
        /// <see cref="HF32_DEFAULT"/>: Process's default heap
        /// </summary>
        public DWORD dwFlags;
    }
}
