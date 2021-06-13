using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a processor group-specific affinity, such as the affinity of a thread.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-group_affinity"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GROUP_AFFINITY
    {
        /// <summary>
        /// A bitmap that specifies the affinity for zero or more processors within the specified group.
        /// </summary>
        public KAFFINITY Mask;

        /// <summary>
        /// The processor group number.
        /// </summary>
        public WORD Group;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public WORD[] Reserved;
    }
}
