using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a resource that are accessible using an unordered-access view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ns-d3d11_3-d3d11_unordered_access_view_desc1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An unordered-access-view description is passed into <see cref="ID3D11Device3.CreateUnorderedAccessView1"/> to create a view.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_UNORDERED_ACCESS_VIEW_DESC1
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the data format.
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D11_UAV_DIMENSION"/>-typed value that specifies the resource type of the view.
        /// This type is the same as the resource type of the underlying resource.
        /// This member also determines which _UAV to use in the union below.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_UAV_DIMENSION ViewDimension;

        /// <summary>
        /// A <see cref="D3D11_BUFFER_UAV"/> structure that specifies which buffer elements can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFER_UAV Buffer;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_UAV"/> structure that specifies the subresources in a 1D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_UAV Texture1D;

        /// <summary>
        /// A <see cref="D3D11_TEX1D_ARRAY_UAV"/> structure that specifies the subresources in a 1D texture array that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_ARRAY_UAV Texture1DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_UAV1"/> structure that specifies the subresources in a 2D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_UAV1 Texture2D;

        /// <summary>
        /// A <see cref="D3D11_TEX2D_ARRAY_UAV1"/> structure that specifies the subresources in a 2D texture array that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_ARRAY_UAV1 Texture2DArray;

        /// <summary>
        /// A <see cref="D3D11_TEX3D_UAV"/> structure that specifies subresources in a 3D texture that can be accessed.
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX3D_UAV Texture3D;
    }
}
