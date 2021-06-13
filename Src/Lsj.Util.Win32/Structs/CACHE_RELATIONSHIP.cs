using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes cache attributes. This structure is used with the <see cref="GetLogicalProcessorInformationEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-cache_relationship"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CACHE_RELATIONSHIP
    {
        /// <summary>
        /// The cache level.
        /// This member can be one of the following values.
        /// 1: L1
        /// 2: L2
        /// 3: L3
        /// </summary>
        public BYTE Level;

        /// <summary>
        /// The cache associativity.
        /// If this member is <see cref="CACHE_FULLY_ASSOCIATIVE"/>, the cache is fully associative.
        /// </summary>
        public BYTE Associativity;

        /// <summary>
        /// The cache line size, in bytes.
        /// </summary>
        public WORD LineSize;

        /// <summary>
        /// The cache size, in bytes.
        /// </summary>
        public DWORD CacheSize;

        /// <summary>
        /// The cache type. This member is a <see cref="PROCESSOR_CACHE_TYPE"/> value.
        /// </summary>
        public PROCESSOR_CACHE_TYPE Type;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 20)]
        public byte[] Reserved;

        /// <summary>
        /// A GROUP_AFFINITY structure that specifies a group number and processor affinity within the group.
        /// </summary>
        public GROUP_AFFINITY GroupMask;
    }
}
