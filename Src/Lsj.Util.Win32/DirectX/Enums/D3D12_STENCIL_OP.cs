using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the stencil operations that can be performed during depth-stencil testing.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_stencil_op"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_DEPTH_STENCILOP_DESC"/> structure.
    /// </remarks>
    public enum D3D12_STENCIL_OP
    {
        /// <summary>
        /// Keep the existing stencil data.
        /// </summary>
        D3D12_STENCIL_OP_KEEP = 1,

        /// <summary>
        /// Set the stencil data to 0.
        /// </summary>
        D3D12_STENCIL_OP_ZERO = 2,

        /// <summary>
        /// Set the stencil data to the reference value set by calling <see cref="ID3D12GraphicsCommandList.OMSetStencilRef"/>.
        /// </summary>
        D3D12_STENCIL_OP_REPLACE = 3,

        /// <summary>
        /// Increment the stencil value by 1, and clamp the result.
        /// </summary>
        D3D12_STENCIL_OP_INCR_SAT = 4,

        /// <summary>
        /// Decrement the stencil value by 1, and clamp the result.
        /// </summary>
        D3D12_STENCIL_OP_DECR_SAT = 5,

        /// <summary>
        /// Invert the stencil data.
        /// </summary>
        D3D12_STENCIL_OP_INVERT = 6,

        /// <summary>
        /// Increment the stencil value by 1, and wrap the result if necessary.
        /// </summary>
        D3D12_STENCIL_OP_INCR = 7,

        /// <summary>
        /// Decrement the stencil value by 1, and wrap the result if necessary.
        /// </summary>
        D3D12_STENCIL_OP_DECR = 8
    }
}
