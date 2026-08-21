using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the thread profiling and hardware counter data that you requested.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-performance_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// You must initialize the <see cref="Size"/> and <see cref="Version"/> members
    /// before calling the <see cref="ReadThreadProfilingData"/> function to read the profiling data.
    /// </para>
    /// <para>
    /// The profile data contained in this structure depends on the data that you requested
    /// when you called the <see cref="ReadThreadProfilingData"/> function.
    /// The following members are set when you specify the <see cref="READ_THREAD_PROFILING_FLAG_DISPATCHING"/> flag:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ContextSwitchCount"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="CycleTime"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="RetryCount"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="WaitReasonBitMap"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The following members are set when you specify the <see cref="READ_THREAD_PROFILING_FLAG_HARDWARE_COUNTERS"/> flag:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="HwCounters"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="HwCountersCount"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct PERFORMANCE_DATA
    {
        /// <summary>
        /// The size of this structure.
        /// </summary>
        public WORD Size;

        /// <summary>
        /// The version of this structure.
        /// Must be set to <see cref="PERFORMANCE_DATA_VERSION"/>.
        /// </summary>
        public BYTE Version;

        /// <summary>
        /// The number of array elements in the <see cref="HwCounters"/> array that contain hardware counter data.
        /// A value of 3 means that the array contains data for three hardware counters,
        /// not that elements 0 through 2 contain counter data.
        /// </summary>
        public BYTE HwCountersCount;

        /// <summary>
        /// The number of context switches that occurred from the time profiling was enabled.
        /// </summary>
        public DWORD ContextSwitchCount;

        /// <summary>
        /// A bitmask that identifies the reasons for the context switches
        /// that occurred since the last time the data was read.
        /// For possible values, see the <c>KWAIT_REASON</c> enumeration
        /// (the enumeration is included in the Wdm.h file in the WDK).
        /// </summary>
        public DWORD64 WaitReasonBitMap;

        /// <summary>
        /// The cycle time of the thread (excludes the time spent interrupted) from the time profiling was enabled.
        /// </summary>
        public DWORD64 CycleTime;

        /// <summary>
        /// The number of times that the read operation read the data to ensure a consistent snapshot of the data.
        /// </summary>
        public DWORD RetryCount;

        /// <summary>
        /// Reserved. Set to zero.
        /// </summary>
        public DWORD Reserved;

        /// <summary>
        /// An array of <see cref="HARDWARE_COUNTER_DATA"/> structures that contain the counter values.
        /// The elements of the array that contain counter data relate directly to the bits set
        /// in the <c>HardwareCounters</c> bitmask that you specified
        /// when you called the <see cref="EnableThreadProfiling"/> function.
        /// For example, if you set bit 3 in the <c>HardwareCounters</c> bitmask,
        /// <c>HwCounters[3]</c> will contain the counter data for that counter.
        /// </summary>
        public ByValHARDWARE_COUNTER_DATAArrayStructForSize16 HwCounters;
    }
}
