using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes stencil operations that can be performed based on the results of stencil test.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencilop_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// All stencil operations are specified as a <see cref="D3D12_STENCIL_OP"/>-typed value.
    /// Each stencil operation can be set differently based on the outcome of the stencil test,
    /// which is referred to as <see cref="StencilFunc"/>, in the stencil test portion of depth-stencil testing.
    /// </para>
    /// <para>
    /// Members of <see cref="D3D12_DEPTH_STENCIL_DESC"/> have this structure for their data type.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DEPTH_STENCILOP_DESC
    {
        /// <summary>
        /// A <see cref="D3D12_STENCIL_OP"/>-typed value that identifies the stencil operation to perform
        /// when stencil testing fails.
        /// </summary>
        public D3D12_STENCIL_OP StencilFailOp;

        /// <summary>
        /// A <see cref="D3D12_STENCIL_OP"/>-typed value that identifies the stencil operation to perform
        /// when stencil testing passes and depth testing fails.
        /// </summary>
        public D3D12_STENCIL_OP StencilDepthFailOp;

        /// <summary>
        /// A <see cref="D3D12_STENCIL_OP"/>-typed value that identifies the stencil operation to perform
        /// when stencil testing and depth testing both pass.
        /// </summary>
        public D3D12_STENCIL_OP StencilPassOp;

        /// <summary>
        /// A <see cref="D3D12_COMPARISON_FUNC"/>-typed value that identifies the function
        /// that compares stencil data against existing stencil data.
        /// </summary>
        public D3D12_COMPARISON_FUNC StencilFunc;
    }
}
