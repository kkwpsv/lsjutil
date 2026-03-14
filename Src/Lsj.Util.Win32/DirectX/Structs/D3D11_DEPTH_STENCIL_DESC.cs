using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_COMPARISON_FUNC;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_DEPTH_WRITE_MASK;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_STENCIL_OP;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes depth-stencil state.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencil_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Pass a pointer to <see cref="D3D11_DEPTH_STENCIL_DESC"/> to the <see cref="ID3D11Device.CreateDepthStencilState"/> method
    /// to create the depth-stencil state object.
    /// </para>
    /// <para>
    /// Depth-stencil state controls how depth-stencil testing is performed by the output-merger stage.
    /// </para>
    /// <para>
    /// The following table shows the default values of depth-stencil states. 
    /// </para>
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
    /// <see cref="D3D11_DEPTH_WRITE_MASK_ALL"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="DepthFunc"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_COMPARISON_LESS"/>
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
    /// <see cref="D3D11_DEFAULT_STENCIL_READ_MASK"/>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="StencilWriteMask"/>
    /// </term>
    /// <term>
    /// <see cref="D3D11_DEFAULT_STENCIL_WRITE_MASK"/>
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
    /// <see cref="D3D11_COMPARISON_ALWAYS"/>
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
    /// <see cref="D3D11_STENCIL_OP_KEEP"/>
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
    /// <see cref="D3D11_STENCIL_OP_KEEP"/>
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
    /// <see cref="D3D11_STENCIL_OP_KEEP"/>
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// The formats that support stenciling are <see cref="DXGI_FORMAT_D24_UNORM_S8_UINT"/> and <see cref="DXGI_FORMAT_D32_FLOAT_S8X24_UINT"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_DEPTH_STENCIL_DESC
    {
        /// <summary>
        /// Enable depth testing.
        /// </summary>
        public BOOL DepthEnable;

        /// <summary>
        /// Identify a portion of the depth-stencil buffer that can be modified by depth data (see <see cref="D3D11_DEPTH_WRITE_MASK"/>).
        /// </summary>
        public D3D11_DEPTH_WRITE_MASK DepthWriteMask;

        /// <summary>
        /// A function that compares depth data against existing depth data.
        /// The function options are listed in <see cref="D3D11_COMPARISON_FUNC"/>.
        /// </summary>
        public D3D11_COMPARISON_FUNC DepthFunc;

        /// <summary>
        /// Enable stencil testing.
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
        /// Identify how to use the results of the depth test and the stencil test for pixels
        /// whose surface normal is facing towards the camera (see <see cref="D3D11_DEPTH_STENCILOP_DESC"/>).
        /// </summary>
        public D3D11_DEPTH_STENCILOP_DESC FrontFace;

        /// <summary>
        /// Identify how to use the results of the depth test and the stencil test for pixels
        /// whose surface normal is facing away from the camera (see <see cref="D3D11_DEPTH_STENCILOP_DESC"/>).
        /// </summary>
        public D3D11_DEPTH_STENCILOP_DESC BackFace;
    }
}
