using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies which unordered resource options are supported for a provided format.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_format_support2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_FORMAT_SUPPORT"/> structure.
    /// </remarks>
    [Flags]
    public enum D3D12_FORMAT_SUPPORT2
    {
        /// <summary>
        /// No unordered resource options are supported.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_NONE = 0,

        /// <summary>
        /// Format supports atomic add.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_ADD = 0x1,

        /// <summary>
        /// Format supports atomic bitwise operations.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_BITWISE_OPS = 0x2,

        /// <summary>
        /// Format supports atomic compare with store or exchange.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_COMPARE_STORE_OR_COMPARE_EXCHANGE = 0x4,

        /// <summary>
        /// Format supports atomic exchange.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_EXCHANGE = 0x8,

        /// <summary>
        /// Format supports atomic min and max.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_SIGNED_MIN_OR_MAX = 0x10,

        /// <summary>
        /// Format supports atomic unsigned min and max.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_ATOMIC_UNSIGNED_MIN_OR_MAX = 0x20,

        /// <summary>
        /// Format supports a typed load.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_TYPED_LOAD = 0x40,

        /// <summary>
        /// Format supports a typed store.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_UAV_TYPED_STORE = 0x80,

        /// <summary>
        /// Format supports logic operations in blend state.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_OUTPUT_MERGER_LOGIC_OP = 0x100,

        /// <summary>
        /// Format supports tiled resources. Refer to Volume Tiled Resources.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_TILED = 0x200,

        /// <summary>
        /// Format supports multi-plane overlays.
        /// </summary>
        D3D12_FORMAT_SUPPORT2_MULTIPLANE_OVERLAY = 0x4000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FORMAT_SUPPORT2_SAMPLER_FEEDBACK = 0x8000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_FORMAT_SUPPORT2_DISPLAYABLE = 0x10000
    }
}
