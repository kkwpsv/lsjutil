using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Information about the video card's performance counter capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_counter_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is returned by <see cref="ID3D11Device.CheckCounterInfo"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_COUNTER_INFO
    {
        /// <summary>
        /// Largest device-dependent counter ID that the device supports.
        /// If none are supported, this value will be 0.
        /// Otherwise it will be greater than or equal to <see cref="D3D11_COUNTER_DEVICE_DEPENDENT_0"/>.
        /// See <see cref="D3D11_COUNTER"/>.
        /// </summary>
        public D3D11_COUNTER LastDeviceDependentCounter;

        /// <summary>
        /// Number of counters that can be simultaneously supported.
        /// </summary>
        public UINT NumSimultaneousCounters;

        /// <summary>
        /// Number of detectable parallel units that the counter is able to discern.
        /// Values are 1 ~ 4.
        /// Use <see cref="NumDetectableParallelUnits"/> to interpret the values of the <see cref="VERTEX_PROCESSING"/>,
        /// <see cref="GEOMETRY_PROCESSING"/>, <see cref="PIXEL_PROCESSING"/>, and <see cref="OTHER_GPU_PROCESSING"/> counters.
        /// </summary>
        public UINT8 NumDetectableParallelUnits;
    }
}
