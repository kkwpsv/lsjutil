using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags to control pipeline state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_pipeline_state_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <c>Flags</c> member
    /// of the <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> and <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structures.
    /// </remarks>
    public enum D3D12_PIPELINE_STATE_FLAGS
    {
        /// <summary>
        /// Indicates no flags.
        /// </summary>
        D3D12_PIPELINE_STATE_FLAG_NONE = 0,

        /// <summary>
        /// <para>
        /// ndicates that the pipeline state should be compiled with additional information to assist debugging.
        /// </para>
        /// <para>
        /// This can only be set on WARP devices.
        /// </para>
        /// </summary>
        D3D12_PIPELINE_STATE_FLAG_TOOL_DEBUG = 0x1,

        /// <summary>
        /// Indicates that the pipeline state can be dynamically changed
        /// after the pipeline is set by using <see cref="ID3D12GraphicsCommandList9.RSSetDepthBias"/>.
        /// </summary>
        D3D12_PIPELINE_STATE_FLAG_DYNAMIC_DEPTH_BIAS = 0x4,

        /// <summary>
        /// Indicates that the pipeline state can be dynamically changed
        /// after the pipeline is set by using <see cref="ID3D12GraphicsCommandList9.IASetIndexBufferStripCutValue"/>.
        /// </summary>
        D3D12_PIPELINE_STATE_FLAG_DYNAMIC_INDEX_BUFFER_STRIP_CUT = 0x8
    }
}
