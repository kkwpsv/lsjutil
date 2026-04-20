using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the subresources from a resource that are accessible by using a render-target view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_render_target_view_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Pass a render-target-view description into <see cref="ID3D12Device.CreateRenderTargetView"/> to create a render-target view.
    /// </para>
    /// <para>
    /// A render-target view can't use the following formats:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Any typeless format.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <c>DXGI_FORMAT_R32G32B32</c> if the view will be used to bind a buffer (vertex, index, constant, or stream-output).
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// If the format is set to <see cref="DXGI_FORMAT_UNKNOWN"/>,
    /// then the format of the resource that the view binds to the pipeline will be used.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RENDER_TARGET_VIEW_DESC
    {
        /// <summary>
        /// A <see cref="DXGI_FORMAT"/>-typed value that specifies the viewing format.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// A <see cref="D3D12_RTV_DIMENSION"/>-typed value that specifies how the render-target resource will be accessed.
        /// This type specifies how the resource will be accessed.
        /// This member also determines which <c>_RTV</c> to use in the following union.
        /// </summary>
        public D3D12_RTV_DIMENSION ViewDimension;

        private D3D12_RENDER_TARGET_VIEW_DESC_UNION _union;

        /// <summary>
        /// A <see cref="D3D12_BUFFER_RTV"/> structure that specifies which buffer elements can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_BUFFER_RTV Buffer => ref _union.Buffer;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_RTV"/> structure that specifies the subresources in a 1D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_RTV Texture1D => ref _union.Texture1D;

        /// <summary>
        /// A <see cref="D3D12_TEX1D_ARRAY_RTV"/> structure that specifies the subresources in a 1D texture array that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX1D_ARRAY_RTV Texture1DArray => ref _union.Texture1DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_RTV"/> structure that specifies the subresources in a 2D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_RTV Texture2D => ref _union.Texture2D;

        /// <summary>
        /// A <see cref="D3D12_TEX2D_ARRAY_RTV"/> structure that specifies the subresources in a 2D texture array that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2D_ARRAY_RTV Texture2DArray => ref _union.Texture2DArray;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_RTV"/> structure that specifies a single subresource
        /// because a multisampled 2D texture only contains one subresource.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_RTV Texture2DMS => ref _union.Texture2DMS;

        /// <summary>
        /// A <see cref="D3D12_TEX2DMS_ARRAY_RTV"/> structure that specifies the subresources
        /// in a multisampled 2D texture array that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX2DMS_ARRAY_RTV Texture2DMSArray => ref _union.Texture2DMSArray;

        /// <summary>
        /// A <see cref="D3D12_TEX3D_RTV"/> structure that specifies subresources in a 3D texture that can be accessed.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_TEX3D_RTV Texture3D => ref _union.Texture3D;

        internal struct D3D12_RENDER_TARGET_VIEW_DESC_UNION
        {
            public D3D12_BUFFER_RTV Buffer;
            public D3D12_TEX1D_RTV Texture1D;
            public D3D12_TEX1D_ARRAY_RTV Texture1DArray;
            public D3D12_TEX2D_RTV Texture2D;
            public D3D12_TEX2D_ARRAY_RTV Texture2DArray;
            public D3D12_TEX2DMS_RTV Texture2DMS;
            public D3D12_TEX2DMS_ARRAY_RTV Texture2DMSArray;
            public D3D12_TEX3D_RTV Texture3D;
        }
    }
}
