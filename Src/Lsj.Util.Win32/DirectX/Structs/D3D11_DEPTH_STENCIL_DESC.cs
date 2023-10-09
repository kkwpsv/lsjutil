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
    /// Pass a pointer to <see cref="D3D11_DEPTH_STENCIL_DESC"/> to
    /// the <see cref="ID3D11Device.CreateDepthStencilState"/> method to create the depth-stencil state object.
    /// Depth-stencil state controls how depth-stencil testing is performed by the output-merger stage.
    /// The following table shows the default values of depth-stencil states.
    /// State                                                           Default Value
    /// <see cref="DepthEnable"/>                                       <see cref="TRUE"/>
    /// <see cref="DepthWriteMask"/>                                    <see cref="D3D11_DEPTH_WRITE_MASK_ALL"/>
    /// <see cref="DepthFunc"/>                                         <see cref="D3D11_COMPARISON_LESS"/>
    /// <see cref="StencilEnable"/>                                     <see cref="FALSE"/>
    /// <see cref="StencilReadMask"/>                                   <see cref="D3D11_DEFAULT_STENCIL_READ_MASK"/>
    /// <see cref="StencilWriteMask"/>                                  <see cref="D3D11_DEFAULT_STENCIL_WRITE_MASK"/>
    /// FrontFace.StencilFunc and BackFace.StencilFunc                  <see cref="D3D11_COMPARISON_ALWAYS"/>
    /// FrontFace.StencilDepthFailOp and BackFace.StencilDepthFailOp    <see cref="D3D11_STENCIL_OP_KEEP"/>
    /// FrontFace.StencilPassOp and BackFace.StencilPassOp              <see cref="D3D11_STENCIL_OP_KEEP"/>
    /// FrontFace.StencilFailOp and BackFace.StencilFailOp              <see cref="D3D11_STENCIL_OP_KEEP"/>
    /// The formats that support stenciling are <see cref="DXGI_FORMAT_D24_UNORM_S8_UINT"/> and <see cref="DXGI_FORMAT_D32_FLOAT_S8X24_UINT"/>.
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
