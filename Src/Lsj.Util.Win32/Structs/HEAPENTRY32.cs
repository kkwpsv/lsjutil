using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes one entry (block) of a heap that is being examined.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/tlhelp32/ns-tlhelp32-heapentry32"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HEAPENTRY32
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Before calling the <see cref="Heap32First"/> function, set this member to <c>sizeof(HEAPENTRY32)</c>.
        /// If you do not initialize <see cref="dwSize"/>, <see cref="Heap32First"/> fails.
        /// </summary>
        public SIZE_T dwSize;

        /// <summary>
        /// A handle to the heap block.
        /// </summary>
        public HANDLE hHandle;

        /// <summary>
        /// The linear address of the start of the block.
        /// </summary>
        public ULONG_PTR dwAddress;

        /// <summary>
        /// The size of the heap block, in bytes.
        /// </summary>
        public SIZE_T dwBlockSize;

        /// <summary>
        /// <para>
        /// This member can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="LF32_FIXED"/>
        /// </term>
        /// <term>
        /// The memory block has a fixed (unmovable) location.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LF32_FREE"/>
        /// </term>
        /// <term>
        /// The memory block is not used.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="LF32_MOVEABLE"/>
        /// </term>
        /// <term>
        /// The memory block location can be moved.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD dwFlags;

        /// <summary>
        /// This member is no longer used and is always set to zero.
        /// </summary>
        public DWORD dwLockCount;

        /// <summary>
        /// Reserved; do not use or alter.
        /// </summary>
        public DWORD dwResvd;

        /// <summary>
        /// The identifier of the process that uses the heap.
        /// </summary>
        public DWORD th32ProcessID;

        /// <summary>
        /// The heap identifier.
        /// This is not a handle, and has meaning only to the tool help functions.
        /// </summary>
        public ULONG_PTR th32HeapID;
    }
}
