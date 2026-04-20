using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Indicates the level of support that the adapter provides for depth-bounds tests and programmable sample positions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure with <see cref="ID3D12Device.CheckFeatureSupport"/> to determine
    /// the level of support offered for the optional Depth-bounds test and programmable sample positions features.
    /// </para>
    /// <para>
    /// See the enumeration constant <see cref="D3D12_FEATURE.D3D12_FEATURE_D3D12_OPTIONS2"/> in the <see cref="D3D12_FEATURE"/> enumeration.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS2
    {
        /// <summary>
        /// On return, contains true if depth-bounds tests are supported; otherwise, false.
        /// </summary>
        public BOOL DepthBoundsTestSupported;

        /// <summary>
        /// On return, contains a value that indicates the level of support offered for programmable sample positions.
        /// </summary>
        public D3D12_PROGRAMMABLE_SAMPLE_POSITIONS_TIER ProgrammableSamplePositionsTier;
    }
}
