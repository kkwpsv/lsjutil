using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a resource that are accessible using a render-target view.
    /// </para>
    /// <para>
    /// From：<see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_render_target_view_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A render-target-view description is passed into <see cref="ID3D11Device3.CreateRenderTargetView1"/> to create a render target.
    /// </para>
    /// <para>
    /// A render-target-view cannot use the following formats:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Any typeless format.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// DXGI_FORMAT_R32G32B32 if the view will be used to bind a buffer (vertex, index, constant, or stream-output).
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// If the format is set to <see cref="DXGI_FORMAT_UNKNOWN"/>,
    /// then the format of the resource that the view binds to the pipeline will be used.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_RENDER_TARGET_VIEW_DESC1
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the data format.
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D11_RTV_DIMENSION"/>-typed value that specifies the resource type and how the render-target resource will be accessed.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_RTV_DIMENSION ViewDimension;

        /// <summary>
        /// A <see cref="D3D11_BUFFER_RTV"/> structure that specifies which buffer elements can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFER_RTV Buffer;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_RTV"/> structure that specifies the subresources in a 1D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_RTV Texture1D;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_ARRAY_RTV"/> structure that specifies the subresources in a 1D texture array that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_ARRAY_RTV Texture1DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_RTV1"/> structure that specifies the subresources in a 2D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_RTV1 Texture2D;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_ARRAY_RTV1"/> structure that specifies the subresources in a 2D texture array that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_ARRAY_RTV1 Texture2DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX2DMS_RTV"/> structure that specifies a single subresource because a multisampled 2D texture only contains one subresource.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_RTV Texture2DMS;

        /// <summary>
        /// A <see cref="D3D11_TEX2DMS_ARRAY_RTV"/> structure that specifies the subresources in a multisampled 2D texture array that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;

        /// <summary>
        /// A <see cref="D3D11_TEX3D_RTV"/> structure that specifies subresources in a 3D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX3D_RTV Texture3D;
    }
}
