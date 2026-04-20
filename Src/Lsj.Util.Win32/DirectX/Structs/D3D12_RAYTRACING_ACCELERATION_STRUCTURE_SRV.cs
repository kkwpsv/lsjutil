using Lsj.Util.Win32.DirectX.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// A shader resource view (SRV) structure for storing a raytracing acceleration structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_raytracing_acceleration_structure_srv"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RAYTRACING_ACCELERATION_STRUCTURE_SRV
    {
        /// <summary>
        /// The GPU virtual address of the SRV.
        /// See remarks.
        /// </summary>
        public D3D12_GPU_VIRTUAL_ADDRESS Location;
    }
}
