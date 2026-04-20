using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources of a texture that are accessible from a depth-stencil view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_depth_stencil_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// These are valid formats for a depth-stencil view:
    /// </para>
    /// <para>
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
    /// </para>
    /// <para>
    /// A depth-stencil view can't use a typeless format.
    /// If the format chosen is <see cref="DXGI_FORMAT_UNKNOWN"/>, the format of the parent resource is used.
    /// </para>
    /// <para>
    /// Pass a depth-stencil-view description into <see cref="ID3D12Device.CreateDepthStencilView"/> to create a depth-stencil view.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_DEPTH_STENCIL_VIEW_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format.
        /// For allowable formats, see Remarks.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D12_DSV_DIMENSION"/>-typed value that specifies how the depth-stencil resource will be accessed.
        /// This member also determines which <c>_DSV</c> to use in the following union.
        /// </summary>
        public D3D12_DSV_DIMENSION ViewDimension;

        /// <summary>
        /// <para>
        /// A combination of <see cref="D3D12_DSV_FLAGS"/> enumeration constants that are combined by using a bitwise OR operation.
        /// The resulting value specifies whether the texture is read only.
        /// </para>
        /// <para>
        /// Pass 0 to specify that it isn't read only;
        /// otherwise, pass one or more of the members of the <see cref="D3D12_DSV_FLAGS"/> enumerated type.
        /// </para>
        /// </summary>
        public D3D12_DSV_FLAGS Flags;

        private D3D12_DEPTH_STENCIL_VIEW_DESC_UNION _union;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_DSV"/> structure that specifies a 1D texture subresource.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_DSV Texture1D => ref _union.Texture1D;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_ARRAY_DSV"/> structure that specifies an array of 1D texture subresources.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_ARRAY_DSV Texture1DArray => ref _union.Texture1DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_DSV"/> structure that specifies a 2D texture subresource.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_DSV Texture2D => ref _union.Texture2D;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_ARRAY_DSV"/> structure that specifies an array of 2D texture subresources.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_ARRAY_DSV Texture2DArray => ref _union.Texture2DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_DSV"/> structure that specifies a multisampled 2D texture.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_DSV Texture2DMS => ref _union.Texture2DMS;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_ARRAY_DSV"/> structure that specifies an array of multisampled 2D textures.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_ARRAY_DSV Texture2DMSArray => ref _union.Texture2DMSArray;

        internal struct D3D12_DEPTH_STENCIL_VIEW_DESC_UNION
        {
            public D3D12_TEX1D_DSV Texture1D;
            public D3D12_TEX1D_ARRAY_DSV Texture1DArray;
            public D3D12_TEX2D_DSV Texture2D;
            public D3D12_TEX2D_ARRAY_DSV Texture2DArray;
            public D3D12_TEX2DMS_DSV Texture2DMS;
            public D3D12_TEX2DMS_ARRAY_DSV Texture2DMSArray;
        }
    }
}
