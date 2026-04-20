using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Indicates the level of support that the adapter provides for render passes, ray tracing, and shader-resource view tier 3 tiled resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options5"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Pass <see cref="D3D12_FEATURE_D3D12_OPTIONS5"/> to <see cref="ID3D12Device.CheckFeatureSupport"/>
    /// to retrieve a <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS5"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS5
    {
        /// <summary>
        /// A boolean value indicating whether the options require shader-resource view tier 3 tiled resource support.
        /// For more information, see <see cref="D3D12_TILED_RESOURCES_TIER"/>.
        /// </summary>
        public BOOL SRVOnlyTiledResourceTier3;

        /// <summary>
        /// The extent to which a device driver and/or the hardware efficiently supports render passes.
        /// See <see cref="D3D12_RENDER_PASS_TIER"/>.
        /// </summary>
        public D3D12_RENDER_PASS_TIER RenderPassesTier;

        /// <summary>
        /// Specifies the level of ray tracing support on the graphics device. See <see cref="D3D12_RAYTRACING_TIER"/>.
        /// </summary>
        public D3D12_RAYTRACING_TIER RaytracingTier;
    }
}
