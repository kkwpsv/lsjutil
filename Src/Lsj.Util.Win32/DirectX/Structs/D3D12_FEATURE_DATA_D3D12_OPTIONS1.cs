using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the level of support for HLSL 6.0 wave operations.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_d3d12_options1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A "lane" is single thread of execution.
    /// The shader models before version 6.0 expose only one of these at the language level,
    /// leaving expansion to parallel SIMD processing entirely up to the implementation.
    /// </para>
    /// <para>
    /// A "wave" is set of lanes (threads) executed simultaneously in the processor.
    /// No explicit barriers are required to guarantee that they execute in parallel.
    /// Similar concepts include "warp" and "wavefront".
    /// </para>
    /// <para>
    /// This structure is used with the <see cref="D3D12_FEATURE.D3D12_FEATURE_D3D12_OPTIONS1"/> member of <see cref="D3D12_FEATURE"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_D3D12_OPTIONS1
    {
        /// <summary>
        /// True if the driver supports HLSL 6.0 wave operations.
        /// </summary>
        public BOOL WaveOps;

        /// <summary>
        /// Specifies the baseline number of lanes in the SIMD wave that this implementation can support.
        /// This term is sometimes known as "wavefront size" or "warp width".
        /// Currently apps should rely only on this minimum value for sizing workloads.
        /// </summary>
        public UINT WaveLaneCountMin;

        /// <summary>
        /// Specifies the maximum number of lanes in the SIMD wave that this implementation can support.
        /// </summary>
        public UINT WaveLaneCountMax;

        /// <summary>
        /// Specifies the total number of SIMD lanes on the hardware.
        /// </summary>
        public UINT TotalLaneCount;

        /// <summary>
        /// Indicates transitions are possible in and out of the CBV, and indirect argument states, on compute command lists.
        /// If <see cref="ID3D12Device.CheckFeatureSupport"/> succeeds this value will always be true.
        /// </summary>
        public BOOL ExpandedComputeResourceStates;

        /// <summary>
        /// Indicates that 64bit integer operations are supported.
        /// </summary>
        public BOOL Int64ShaderOps;
    }
}
