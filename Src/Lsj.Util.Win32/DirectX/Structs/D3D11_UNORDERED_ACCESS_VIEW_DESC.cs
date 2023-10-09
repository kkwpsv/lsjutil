using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the subresources from a resource that are accessible using an unordered-access view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_unordered_access_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// An unordered-access-view description is passed into <see cref="ID3D11Device.CreateUnorderedAccessView"/> to create a view.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct D3D11_UNORDERED_ACCESS_VIEW_DESC
    {
        /// <summary>
        /// The data format (see <see cref="DXGI_FORMAT"/>).
        /// </summary>
        [FieldOffset(0)]
        public DXGI_FORMAT Format;

        /// <summary>
        /// The resource type (see <see cref="D3D11_UAV_DIMENSION"/>), which specifies how the resource will be accessed.
        /// </summary>
        [FieldOffset(4)]
        public D3D11_UAV_DIMENSION ViewDimension;

        /// <summary>
        /// Specifies which buffer elements can be accessed (see <see cref="D3D11_BUFFER_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_BUFFER_UAV Buffer;

        /// <summary>
        /// Specifies the subresources in a 1D texture that can be accessed (see <see cref="D3D11_TEX1D_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_UAV Texture1D;

        /// <summary>
        /// Specifies the subresources in a 1D texture array that can be accessed (see <see cref="D3D11_TEX1D_ARRAY_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX1D_ARRAY_UAV Texture1DArray;

        /// <summary>
        /// Specifies the subresources in a 2D texture that can be accessed (see <see cref="D3D11_TEX2D_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_UAV Texture2D;

        /// <summary>
        /// Specifies the subresources in a 2D texture array that can be accessed (see <see cref="D3D11_TEX2D_ARRAY_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX2D_ARRAY_UAV Texture2DArray;

        /// <summary>
        /// Specifies subresources in a 3D texture that can be accessed (see <see cref="D3D11_TEX3D_UAV"/>).
        /// </summary>
        [FieldOffset(8)]
        public D3D11_TEX3D_UAV Texture3D;
    }
}
