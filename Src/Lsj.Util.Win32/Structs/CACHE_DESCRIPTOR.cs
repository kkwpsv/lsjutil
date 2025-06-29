using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes the cache attributes.
    /// </para>
    /// <para>
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-cache_descriptor
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CACHE_DESCRIPTOR
    {
        /// <summary>
        /// <para>
        /// The cache level. This member can currently be one of the following values; other values may be supported in the future.
        /// </para>
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
        /// 1
        /// </term>
        /// <term>
        /// L1
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// L2
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// L3
        /// </term>
        /// </item>
        /// </list>
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
        public DWORD Size;

        /// <summary>
        /// The cache type. This member is a <see cref="PROCESSOR_CACHE_TYPE"/> value.
        /// </summary>
        public PROCESSOR_CACHE_TYPE Type;
    }
}
