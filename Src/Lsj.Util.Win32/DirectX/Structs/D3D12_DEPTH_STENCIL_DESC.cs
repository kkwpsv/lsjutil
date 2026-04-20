using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_COMPARISON_FUNC;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_DEPTH_WRITE_MASK;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_STENCIL_OP;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes depth-stencil state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/> object contains a depth-stencil-state structure
    /// that controls how depth-stencil testing is performed by the output-merger stage.
    /// </para>
    /// <para>
    /// This table shows the default values of depth-stencil states.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// State
    /// </term>
    /// <term>
    /// Default Value
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="DepthEnable"/>
    /// </term>
    /// <term>
    /// <see cref="TRUE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthWriteMask"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_DEPTH_WRITE_MASK_ALL"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthFunc"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_COMPARISON_FUNC_LESS"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="StencilEnable"/>
    /// </term>
    /// <term>
    /// <see cref="FALSE"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="StencilReadMask"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_DEFAULT_STENCIL_READ_MASK"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="StencilWriteMask"/>
    /// </term>
    /// <term>
    /// <see cref="D3D12_DEFAULT_STENCIL_WRITE_MASK"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <para>
    /// <c>FrontFace.StencilFailOp</c>
    /// </para>
    /// <para>
    /// and
    /// </para>
    /// <para>
    /// <c>BackFace.StencilFailOp</c>
    /// </para>
    /// </term>
    /// <term>
    /// <see cref="D3D12_STENCIL_OP_KEEP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <para>
    /// <c>FrontFace.StencilDepthFailOp</c>
    /// </para>
    /// <para>
    /// and
    /// </para>
    /// <para>
    /// <c>BackFace.StencilDepthFailOp</c>
    /// </para>
    /// </term>
    /// <term>
    /// <see cref="D3D12_STENCIL_OP_KEEP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <para>
    /// <c>FrontFace.StencilPassOp</c>
    /// </para>
    /// <para>
    /// and
    /// </para>
    /// <para>
    /// <c>BackFace.StencilPassOp</c>
    /// </para>
    /// </term>
    /// <term>
    /// <see cref="D3D12_STENCIL_OP_KEEP"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <para>
    /// <c>FrontFace.StencilFunc</c>
    /// </para>
    /// <para>
    /// and
    /// </para>
    /// <para>
    /// <c>BackFace.StencilFunc</c>
    /// </para>
    /// </term>
    /// <term>
    /// <see cref="D3D12_COMPARISON_FUNC_ALWAYS"/>
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The formats that support stenciling are <see cref="DXGI_FORMAT_D24_UNORM_S8_UINT"/> and <see cref="DXGI_FORMAT_D32_FLOAT_S8X24_UINT"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DEPTH_STENCIL_DESC
    {
        /// <summary>
        /// Specifies whether to enable depth testing.
        /// Set this member to <see cref="TRUE"/> to enable depth testing.
        /// </summary>
        public BOOL DepthEnable;

        /// <summary>
        /// A <see cref="D3D12_DEPTH_WRITE_MASK"/>-typed value
        /// that identifies a portion of the depth-stencil buffer that can be modified by depth data.
        /// </summary>
        public D3D12_DEPTH_WRITE_MASK DepthWriteMask;

        /// <summary>
        /// A <see cref="D3D12_COMPARISON_FUNC"/>-typed value
        /// that identifies a function that compares depth data against existing depth data.
        /// </summary>
        public D3D12_COMPARISON_FUNC DepthFunc;

        /// <summary>
        /// Specifies whether to enable stencil testing.
        /// Set this member to <see cref="TRUE"/> to enable stencil testing.
        /// </summary>
        public BOOL StencilEnable;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer for reading stencil data.
        /// </summary>
        public UINT8 StencilReadMask;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer for writing stencil data.
        /// </summary>
        public UINT8 StencilWriteMask;

        /// <summary>
        /// A <see cref="D3D12_DEPTH_STENCILOP_DESC"/> structure that describes
        /// how to use the results of the depth test and the stencil test for pixels whose surface normal is facing towards the camera.
        /// </summary>
        public D3D12_DEPTH_STENCILOP_DESC FrontFace;

        /// <summary>
        /// A <see cref="D3D12_DEPTH_STENCILOP_DESC"/> structure that describes
        /// how to use the results of the depth test and the stencil test for pixels whose surface normal is facing away from the camera.
        /// </summary>
        public D3D12_DEPTH_STENCILOP_DESC BackFace;
    }
}
