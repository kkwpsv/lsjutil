using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Details the adapter's GPU virtual address space limitations, including maximum address bits per resource and per process.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_gpu_virtual_address_support"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// See the enumeration constant <see cref="D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT"/>
    /// in the <see cref="D3D12_FEATURE"/> enumeration.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT
    {
        /// <summary>
        /// <para>
        /// The maximum GPU virtual address bits per resource.
        /// </para>
        /// <para>
        /// Some adapters have significantly less bits available per resource than per process,
        /// while other adapters have significantly greater bits available per resource than per process.
        /// The latter scenario tends to happen in less common scenarios, like when running a 32-bit process on certain UMA adapters.
        /// When per resource capabilities are greater than per process,
        /// the greater per resource capabilities can only be leveraged by reserved resources or NULL mapped pages.
        /// </para>
        /// </summary>
        public UINT MaxGPUVirtualAddressBitsPerResource;

        /// <summary>
        /// <para>
        /// The maximum GPU virtual address bits per process.
        /// </para>
        /// <para>
        /// When this value is nearly equal to the available residency budget,
        /// <see cref="ID3D12Device.Evict"/> will not be a feasible option to manage residency.
        /// See <see cref="ID3D12Device.MakeResident"/> for more details.
        /// </para>
        /// </summary>
        public UINT MaxGPUVirtualAddressBitsPerProcess;
    }
}
