using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes minimum precision support options for shaders in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_min_precision_support"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure.
    /// </para>
    /// <para>
    /// The returned info just indicates that the graphics hardware can perform HLSL operations
    /// at a lower precision than the standard 32-bit float precision,
    /// but doesn’t guarantee that the graphics hardware will actually run at a lower precision.
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D12_SHADER_MIN_PRECISION_SUPPORT
    {
        /// <summary>
        /// The driver supports only full 32-bit precision for all shader stages.
        /// </summary>
        D3D12_SHADER_MIN_PRECISION_SUPPORT_NONE = 0,

        /// <summary>
        /// The driver supports 10-bit precision.
        /// </summary>
        D3D12_SHADER_MIN_PRECISION_SUPPORT_10_BIT = 0x1,

        /// <summary>
        /// The driver supports 16-bit precision.
        /// </summary>
        D3D12_SHADER_MIN_PRECISION_SUPPORT_16_BIT = 0x2
    }
}
