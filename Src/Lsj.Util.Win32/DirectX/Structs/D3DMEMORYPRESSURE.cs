using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains data for memory pressure reporting.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dmemorypressure"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3DMEMORYPRESSURE
    {
        /// <summary>
        /// The number of bytes that were evicted by the process during the duration of the query.
        /// </summary>
        public UINT64 BytesEvictedFromProcess;

        /// <summary>
        /// The total number of bytes placed in nonoptimal memory segments, due to inadequate space within the preferred memory segments.
        /// </summary>
        public UINT64 SizeOfInefficientAllocation;

        /// <summary>
        /// The overall efficiency of the memory allocations that were placed in nonoptimal memory.
        /// The value is expressed as a percentage.
        /// For example, the value 95 indicates that the allocations placed in nonpreferred memory segments are 95% efficient.
        /// This number should not be considered an exact measurement.
        /// </summary>
        public DWORD LevelOfEfficiency;
    }
}
