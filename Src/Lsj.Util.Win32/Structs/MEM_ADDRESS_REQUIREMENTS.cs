using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies a lowest and highest base address and alignment as part of an extended parameter to a function that manages virtual memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-mem_address_requirements"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Specifying a <see cref="MEM_ADDRESS_REQUIREMENTS"/> structure with all fields set to 0 is the same as not specifying one at all.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MEM_ADDRESS_REQUIREMENTS
    {
        /// <summary>
        /// Specifies the lowest acceptable address.
        /// This address must be a multiple of the allocation granularity returned by <see cref="GetSystemInfo"/>,
        /// or a multiple of the large page size returned by <see cref="GetLargePageMinimum"/> if large pages are being requested.
        /// If this member is <see cref="NULL"/>, then there is no lower limit.
        /// </summary>
        public PVOID LowestStartingAddress;

        /// <summary>
        /// <para>
        /// Specifies the highest acceptable address (inclusive).
        /// This address must not exceed lpMaximumApplicationAddress returned by <see cref="GetSystemInfo"/>.
        /// If this member is <see cref="NULL"/>, then there is no upper limit.
        /// </para>
        /// </summary>
        public PVOID HighestEndingAddress;

        /// <summary>
        /// Specifies power-of-2 alignment.
        /// Specifying 0 aligns the returned address on the system allocation granularity.
        /// </summary>
        public SIZE_T Alignment;
    }
}
