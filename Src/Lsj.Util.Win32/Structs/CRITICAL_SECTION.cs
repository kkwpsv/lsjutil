using System;
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
        public IntPtr DebugInfo;

        /// <summary>
        /// LockCount
        /// </summary>
        public int LockCount;

        /// <summary>
        /// RecursionCount
        /// </summary>
        public int RecursionCount;

        /// <summary>
        /// OwningThread
        /// </summary>
        public IntPtr OwningThread;

        /// <summary>
        /// LockSemaphore
        /// </summary>
        public IntPtr LockSemaphore;

        /// <summary>
        /// SpinCount
        /// </summary>
        public UIntPtr SpinCount;
    }
}
