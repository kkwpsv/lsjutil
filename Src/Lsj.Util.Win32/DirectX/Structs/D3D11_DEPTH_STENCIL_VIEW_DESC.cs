using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources of a texture that are accessible from a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_depth_stencil_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// These are valid formats for a depth-stencil view:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_D16_UNORM"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_D24_UNORM_S8_UINT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_D32_FLOAT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_D32_FLOAT_S8X24_UINT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DXGI_FORMAT_UNKNOWN"/>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// A depth-stencil view cannot use a typeless format.
    /// If the format chosen is <see cref="DXGI_FORMAT_UNKNOWN"/>, then the format of the parent resource is used.
    /// </para>
    /// <para>
    /// A depth-stencil-view description is needed when calling <see cref="ID3D11Device.CreateDepthStencilView"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_DEPTH_STENCIL_VIEW_DESC
    {
        /// <summary>
        /// Resource data format (see <see cref="DXGI_FORMAT"/>).
        /// See remarks for allowable formats.
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// Type of resource (see <see cref="D3D11_DSV_DIMENSION"/>).
        /// Specifies how a depth-stencil resource will be accessed; the value is stored in the union in this structure.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_DSV_DIMENSION ViewDimension;

        /// <summary>
        /// A value that describes whether the texture is read only.
        /// Pass 0 to specify that it is not read only; otherwise, pass one of the members of the <see cref="D3D11_DSV_FLAG"/> enumerated type.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_DSV_FLAG Flags;

        /// <summary>
        /// Specifies a 1D texture subresource (see <see cref="D3D11_TEX1D_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX1D_DSV Texture1D;

        /// <summary>
        /// Specifies an array of 1D texture subresources (see <see cref="D3D11_TEX1D_ARRAY_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX1D_ARRAY_DSV Texture1DArray;

        /// <summary>
        /// Specifies a 2D texture subresource (see <see cref="D3D11_TEX2D_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX2D_DSV Texture2D;

        /// <summary>
        /// Specifies an array of 2D texture subresources (see <see cref="D3D11_TEX2D_ARRAY_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX2D_ARRAY_DSV Texture2DArray;

        /// <summary>
        /// Specifies a multisampled 2D texture (see <see cref="D3D11_TEX2DMS_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX2DMS_DSV Texture2DMS;

        /// <summary>
        /// Specifies an array of multisampled 2D textures (see <see cref="D3D11_TEX2DMS_ARRAY_DSV"/>).
        /// </summary>
        [FieldOffset(12)]
        public D3D11_TEX2DMS_ARRAY_DSV Texture2DMSArray;
    }
}
