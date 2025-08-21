using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources from a resource that are accessible using a render-target view.
    /// </para>
    /// <para>
    /// From：<see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_render_target_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A render-target-view description is passed into <see cref="ID3D11Device.CreateRenderTargetView"/> to create a render target.
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
    public struct D3D11_RENDER_TARGET_VIEW_DESC
    {
        /// <summary>
        /// The data format (see <see cref="DXGI_FORMAT"/>).
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// The resource type (see <see cref="D3D11_RTV_DIMENSION"/>), which specifies how the render-target resource will be accessed.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_RTV_DIMENSION ViewDimension;

        /// <summary>
        /// Specifies which buffer elements can be accessed (see <see cref="D3D11_BUFFER_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFER_RTV Buffer;

        /// <summary>
        /// Specifies the subresources in a 1D texture that can be accessed (see <see cref="D3D11_TEX1D_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_RTV Texture1D;

        /// <summary>
        /// Specifies the subresources in a 1D texture array that can be accessed (see <see cref="D3D11_TEX1D_ARRAY_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_ARRAY_RTV Texture1DArray;

        /// <summary>
        /// Specifies the subresources in a 2D texture that can be accessed (see <see cref="D3D11_TEX2D_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_RTV Texture2D;

        /// <summary>
        /// Specifies the subresources in a 2D texture array that can be accessed (see <see cref="D3D11_TEX2D_ARRAY_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_ARRAY_RTV Texture2DArray;

        /// <summary>
        /// Specifies a single subresource because a multisampled 2D texture only contains one subresource (see <see cref="D3D11_TEX2DMS_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_RTV Texture2DMS;

        /// <summary>
        /// Specifies the subresources in a multisampled 2D texture array that can be accessed (see <see cref="D3D11_TEX2DMS_ARRAY_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_ARRAY_RTV Texture2DMSArray;

        /// <summary>
        /// Specifies subresources in a 3D texture that can be accessed (see <see cref="D3D11_TEX3D_RTV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX3D_RTV Texture3D;
    }
}
