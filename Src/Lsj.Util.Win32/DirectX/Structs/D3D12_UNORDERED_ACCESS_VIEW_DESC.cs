using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a resource that are accessible by using an unordered-access view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_unordered_access_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Pass an unordered-access-view description into <see cref="ID3D12Device.CreateUnorderedAccessView"/> to create a view.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_UNORDERED_ACCESS_VIEW_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D12_UAV_DIMENSION"/>-typed value that specifies the resource type of the view.
        /// This type specifies how the resource will be accessed.
        /// This member also determines which <c>_UAV</c> to use in the union below.
        /// </summary>
        public D3D12_UAV_DIMENSION ViewDimension;

        private D3D12_UNORDERED_ACCESS_VIEW_DESC_UNION _union;

        /// <summary>
        /// A <see cref="D3D12_BUFFER_UAV"/> structure that specifies which buffer elements can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_BUFFER_UAV Buffer => ref _union.Buffer;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_UAV"/> structure that specifies the subresources in a 1D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_UAV Texture1D => ref _union.Texture1D;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_ARRAY_UAV"/> structure that specifies the subresources in a 1D texture array that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_ARRAY_UAV Texture1DArray => ref _union.Texture1DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_UAV"/> structure that specifies the subresources in a 2D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_UAV Texture2D => ref _union.Texture2D;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_ARRAY_UAV"/> structure that specifies the subresources in a 2D texture array that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_ARRAY_UAV Texture2DArray => ref _union.Texture2DArray;

        /// <summary>
        /// 
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_UAV Texture2DMS => ref _union.Texture2DMS;

        /// <summary>
        /// 
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_ARRAY_UAV Texture2DMSArray => ref _union.Texture2DMSArray;

        /// <summary>
        /// A <see cref="D3D12_TEX3D_UAV"/> structure that specifies subresources in a 3D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX3D_UAV Texture3D => ref _union.Texture3D;

        internal struct D3D12_UNORDERED_ACCESS_VIEW_DESC_UNION
        {
            public D3D12_BUFFER_UAV Buffer;
            public D3D12_TEX1D_UAV Texture1D;
            public D3D12_TEX1D_ARRAY_UAV Texture1DArray;
            public D3D12_TEX2D_UAV Texture2D;
            public D3D12_TEX2D_ARRAY_UAV Texture2DArray;
            public D3D12_TEX2DMS_UAV Texture2DMS;
            public D3D12_TEX2DMS_ARRAY_UAV Texture2DMSArray;
            public D3D12_TEX3D_UAV Texture3D;
        }
    }
}
