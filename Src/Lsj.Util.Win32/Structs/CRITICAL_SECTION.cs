using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// CRITICAL_SECTION
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CRITICAL_SECTION
    {
        /// <summary>
        /// DebugInfo
        /// </summary>
        public nint DebugInfo;

        /// <summary>
        /// LockCount
        /// </summary>
        public LONG LockCount;

        /// <summary>
        /// RecursionCount
        /// </summary>
        public LONG RecursionCount;

        /// <summary>
        /// OwningThread
        /// </summary>
        public HANDLE OwningThread;

        /// <summary>
        /// LockSemaphore
        /// </summary>
        public HANDLE LockSemaphore;

        /// <summary>
        /// SpinCount
        /// </summary>
        public ULONG_PTR SpinCount;
    }
}
