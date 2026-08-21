using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the hardware counter value.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-hardware_counter_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is a member of the <see cref="PERFORMANCE_DATA"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HARDWARE_COUNTER_DATA
    {
        /// <summary>
        /// The type of hardware counter data collected.
        /// For possible values, see the <see cref="HARDWARE_COUNTER_TYPE"/> enumeration.
        /// </summary>
        public HARDWARE_COUNTER_TYPE Type;

        /// <summary>
        /// Reserved. Initialize to zero.
        /// </summary>
        public DWORD Reserved;

        /// <summary>
        /// The counter index.
        /// Each hardware counter in a processor's performance monitoring unit (PMU) is identified by an index.
        /// </summary>
        public DWORD64 Value;
    }
}
