using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the portion of a depth-stencil buffer for writing depth data.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_depth_write_mask"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_DEPTH_STENCIL_DESC"/> structure.
    /// </remarks>
    public enum D3D12_DEPTH_WRITE_MASK
    {
        /// <summary>
        /// Turn off writes to the depth-stencil buffer.
        /// </summary>
        D3D12_DEPTH_WRITE_MASK_ZERO = 0,

        /// <summary>
        /// Turn on writes to the depth-stencil buffer.
        /// </summary>
        D3D12_DEPTH_WRITE_MASK_ALL = 1
    }
}
