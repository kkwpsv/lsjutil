using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a shader-resource view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_shader_resource_view_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A view is a format-specific way to look at the data in a resource.
    /// The view determines what data to look at, and how it is cast when read.
    /// </para>
    /// <para>
    /// When viewing a resource, the resource-view description must specify a typed format,
    /// that is compatible with the resource format.
    /// So that means that you cannot create a resource-view description using any format with _TYPELESS in the name.
    /// You can however view a typeless resource by specifying a typed format for the view.
    /// For example, a <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> resource can be viewed with one of these typed formats:
    /// <see cref="DXGI_FORMAT_R32G32B32_FLOAT"/>, <see cref="DXGI_FORMAT_R32G32B32_UINT"/>,
    /// and <see cref="DXGI_FORMAT_R32G32B32_SINT"/>, since these typed formats are compatible with the typeless resource.
    /// </para>
    /// <para>
    /// Create a shader-resource-view description by calling <see cref="ID3D11Device.CreateShaderResourceView"/>.
    /// To view a shader-resource-view description, call <see cref="ID3D11ShaderResourceView.GetDesc"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_SHADER_RESOURCE_VIEW_DESC1
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format.
        /// See remarks.
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D11_SRV_DIMENSION"/>-typed value that specifies the resource type of the view.
        /// This type is the same as the resource type of the underlying resource.
        /// This member also determines which _SRV to use in the union below.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_SRV_DIMENSION ViewDimension;

        /// <summary>
        /// A <see cref="D3D11_BUFFER_SRV"/> structure that views the resource as a buffer.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFER_SRV Buffer;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_SRV"/> structure that views the resource as a 1D texture.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_SRV Texture1D;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_ARRAY_SRV"/> structure that views the resource as a 1D-texture array.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_ARRAY_SRV Texture1DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_SRV1"/> structure that views the resource as a 2D-texture.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_SRV1 Texture2D;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_ARRAY_SRV1"/> structure that views the resource as a 2D-texture array.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_ARRAY_SRV1 Texture2DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX2DMS_SRV"/> structure that views the resource as a 2D-multisampled texture.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_SRV Texture2DMS;

        /// <summary>
        /// A <see cref="D3D11_TEX2DMS_ARRAY_SRV"/> structure that views the resource as a 2D-multisampled-texture array.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2DMS_ARRAY_SRV Texture2DMSArray;

        /// <summary>
        /// A <see cref="D3D11_TEX3D_SRV"/> structure that views the resource as a 3D texture.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX3D_SRV Texture3D;

        /// <summary>
        /// A <see cref="D3D11_TEXCUBE_SRV"/> structure that views the resource as a 3D-cube texture.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEXCUBE_SRV TextureCube;

        /// <summary>
        /// A <see cref="D3D11_TEXCUBE_ARRAY_SRV"/> structure that views the resource as a 3D-cube-texture array.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEXCUBE_ARRAY_SRV TextureCubeArray;

        /// <summary>
        /// A <see cref="D3D11_BUFFEREX_SRV"/> structure that views the resource as a raw buffer.
        /// For more info about raw viewing of buffers, see Raw Views of Buffers.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFEREX_SRV BufferEx;
    }
}
