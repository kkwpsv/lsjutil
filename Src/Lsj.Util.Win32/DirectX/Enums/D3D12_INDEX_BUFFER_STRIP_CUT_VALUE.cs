using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// When using triangle strip primitive topology, vertex positions are interpreted as vertices of a continuous triangle “strip”.
    /// There is a special index value that represents the desire to have a discontinuity in the strip, the cut index value.
    /// This enum lists the supported cut values.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_index_buffer_strip_cut_value"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> structure.
    /// </remarks>
    public enum D3D12_INDEX_BUFFER_STRIP_CUT_VALUE
    {
        /// <summary>
        /// Indicates that there is no cut value.
        /// </summary>
        D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_DISABLED = 0,

        /// <summary>
        /// Indicates that 0xFFFF should be used as the cut value.
        /// </summary>
        D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFF = 1,

        /// <summary>
        /// Indicates that 0xFFFFFFFF should be used as the cut value.
        /// </summary>
        D3D12_INDEX_BUFFER_STRIP_CUT_VALUE_0xFFFFFFFF = 2
    }
}
