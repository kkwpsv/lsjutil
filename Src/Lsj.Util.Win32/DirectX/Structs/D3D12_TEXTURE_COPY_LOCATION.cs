using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_COPY_TYPE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a portion of a texture for the purpose of texture copies.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_texture_copy_location"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use this structure with <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TEXTURE_COPY_LOCATION
    {
        /// <summary>
        /// <para>
        /// Specifies the resource which will be used for the copy operation.
        /// </para>
        /// <para>
        /// When <see cref="Type"/> is <see cref="D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT"/>,
        /// <see cref="pResource"/> must point to a buffer resource.
        /// </para>
        /// <para>
        /// When <see cref="Type"/> is <see cref="D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX"/>,
        /// <see cref="pResource"/> must point to a texture resource.
        /// </para>
        /// </summary>
        public P<ID3D12Resource> pResource;

        /// <summary>
        /// Specifies which type of resource location this is:
        /// a subresource of a texture, or a description of a texture layout which can be applied to a buffer.
        /// This <see cref="D3D12_TEXTURE_COPY_TYPE"/> enum indicates which union member to use.
        /// </summary>
        public D3D12_TEXTURE_COPY_TYPE Type;

        private D3D12_TEXTURE_COPY_LOCATION_UNION _union;

        /// <summary>
        /// Specifies a texture layout, with offset, dimensions, and pitches,
        /// for the hardware to understand how to treat a section of a buffer resource as a multi-dimensional texture.
        /// To fill-in the correct data for a <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/> call,
        /// see <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/>.
        /// </summary>
        [UnscopedRef]
        public ref D3D12_PLACED_SUBRESOURCE_FOOTPRINT PlacedFootprint => ref _union.PlacedFootprint;

        /// <summary>
        /// Specifies the index of the subresource of an arrayed, mip-mapped, or planar texture should be used for the copy operation.
        /// </summary>
        [UnscopedRef]
        public ref UINT SubresourceIndex => ref _union.SubresourceIndex;

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        internal struct D3D12_TEXTURE_COPY_LOCATION_UNION
        {
            [FieldOffset(0)]
            public D3D12_PLACED_SUBRESOURCE_FOOTPRINT PlacedFootprint;

            [FieldOffset(0)]
            public UINT SubresourceIndex;
        }
    }
}
