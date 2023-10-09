using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Stencil operations that can be performed based on the results of stencil test.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencilop_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// All stencil operations are specified as a <see cref="D3D11_STENCIL_OP"/>.
    /// The stencil operation can be set differently based on the outcome of the stencil test
    /// (which is referred to as <see cref="StencilFunc"/> in the stencil test portion of depth-stencil testing.
    /// This structure is a member of a depth-stencil description.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_DEPTH_STENCILOP_DESC
    {
        /// <summary>
        /// The stencil operation to perform when stencil testing fails.
        /// </summary>
        public D3D11_STENCIL_OP StencilFailOp;

        /// <summary>
        /// The stencil operation to perform when stencil testing passes and depth testing fails.
        /// </summary>
        public D3D11_STENCIL_OP StencilDepthFailOp;

        /// <summary>
        /// The stencil operation to perform when stencil testing passes and depth testing fails.
        /// </summary>
        public D3D11_STENCIL_OP StencilPassOp;

        /// <summary>
        /// A function that compares stencil data against existing stencil data.
        /// The function options are listed in <see cref="D3D11_COMPARISON_FUNC"/>.
        /// </summary>
        public D3D11_COMPARISON_FUNC StencilFunc;
    }
}
