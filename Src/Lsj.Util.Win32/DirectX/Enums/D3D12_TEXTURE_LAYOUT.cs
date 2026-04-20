using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies texture layout options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_layout"/>
    /// </para>
    /// </summary>
    public enum D3D12_TEXTURE_LAYOUT
    {
        /// <summary>
        /// <para>
        /// Indicates that the layout is unknown, and is likely adapter-dependent.
        /// </para>
        /// <para>
        /// During creation, the driver chooses the most efficient layout based on other resource properties, especially resource size and flags.
        /// </para>
        /// <para>
        /// Prefer this choice unless certain functionality is required from another texture layout.
        /// </para>
        /// <para>
        /// Zero-copy texture upload optimizations exist for UMA architectures; see <see cref="ID3D12Resource.WriteToSubresource"/>.
        /// </para>
        /// </summary>
        D3D12_TEXTURE_LAYOUT_UNKNOWN = 0,

        /// <summary>
        /// <para>
        /// Indicates that data for the texture is stored in row-major order (sometimes called "pitch-linear order").
        /// </para>
        /// <para>
        /// This texture layout locates consecutive texels of a row contiguously in memory, before the texels of the next row.
        /// </para>
        /// <para>
        /// Similarly, consecutive texels of a particular depth or array slice are contiguous in memory
        /// before the texels of the next depth or array slice.
        /// </para>
        /// <para>
        /// Padding may exist between rows and between depth or array slices to align collections of data.
        /// </para>
        /// <para>
        /// A stride is the distance in memory between rows, depth, or array slices; and it includes any padding.
        /// </para>
        /// <para>
        /// This texture layout enables sharing of the texture data between multiple adapters, when other layouts aren't available.
        /// </para>
        /// <para>
        /// Many restrictions apply, because this layout is generally not efficient for extensive usage:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The locality of nearby texels is not rotationally invariant.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Only the following texture properties are supported:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE2D"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A single mip level.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// A single array slice.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 64KB alignment.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Non-MSAA.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// No <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The format cannot be a YUV format.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The texture must be created on a heap with <see cref="D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Buffers are created with <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/>,
        /// because row-major texture data can be located in them without creating a texture object.
        /// </para>
        /// <para>
        /// This is commonly used for uploading or reading back texture data, especially for discrete/NUMA adapters.
        /// </para>
        /// <para>
        /// However, <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/> can also be used
        /// when marshaling texture data between GPUs or adapters.
        /// </para>
        /// <para>
        /// For examples of usage with <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/>, see some of the following topics:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Default Texture Mapping and Standard Swizzle
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Predication
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Multi-engine synchronization
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Uploading Texture Data
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_TEXTURE_LAYOUT_ROW_MAJOR = 1,

        /// <summary>
        /// <para>
        /// Indicates that the layout within 64KB tiles and tail mip packing is up to the driver.
        /// </para>
        /// <para>
        /// No standard swizzle pattern.
        /// </para>
        /// <para>
        /// This texture layout is arranged into contiguous 64KB regions, also known as tiles,
        /// containing near equilateral amount of consecutive number of texels along each dimension.
        /// </para>
        /// <para>
        /// Tiles are arranged in row-major order.
        /// </para>
        /// <para>
        /// While there is no padding between tiles,
        /// there are typically unused texels within the last tile in each dimension.
        /// </para>
        /// <para>
        /// The layout of texels within the tile is undefined.
        /// </para>
        /// <para>
        /// Each subresource immediately follows where the previous subresource end,
        /// and the subresource order follows the same sequence as subresource ordinals.
        /// </para>
        /// <para>
        /// However, tail mip packing is adapter-specific.
        /// </para>
        /// <para>
        /// For more details, see tiled resource tier and <see cref="ID3D12Device.GetResourceTiling"/>.
        /// </para>
        /// <para>
        /// This texture layout enables partially resident or sparse texture scenarios
        /// when used together with virtual memory page mapping functionality.
        /// </para>
        /// <para>
        /// This texture layout must be used together with <see cref="ID3D12Device.CreateReservedResource"/>
        /// to enable the usage of <see cref="ID3D12CommandQueue.UpdateTileMappings"/>.
        /// </para>
        /// <para>
        /// Some restrictions apply to textures with this layout:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The adapter must support <see cref="D3D12_TILED_RESOURCES_TIER"/> 1 or greater.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// 64KB alignment must be used.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/> is not supported, nor are all formats.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The tiled resource tier indicates whether textures with <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE3D"/> is supported.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE = 2,

        /// <summary>
        /// <para>
        /// Indicates that a default texture uses the standardized swizzle pattern.
        /// </para>
        /// <para>
        /// This texture layout is arranged the same way that <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/> is,
        /// except that the layout of texels within the tile is defined.
        /// Tail mip packing is adapter-specific.
        /// </para>
        /// <para>
        /// This texture layout enables optimizations when marshaling data between multiple adapters or between the CPU and GPU.
        /// </para>
        /// <para>
        /// The amount of copying can be reduced when multiple components understand the texture memory layout.
        /// </para>
        /// <para>
        /// This layout is generally more efficient for extensive usage than row-major layout,
        /// due to the rotationally invariant locality of neighboring texels.
        /// </para>
        /// <para>
        /// This layout can typically only be used with adapters that support standard swizzle,
        /// but exceptions exist for cross-adapter shared heaps.
        /// </para>
        /// <para>
        /// The restrictions for this layout are that the following aren't supported:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Multi-sample anti-aliasing (MSAA)
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Formats within the <see cref="DXGI_FORMAT_R32G32B32_TYPELESS"/> group
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE = 3
    }
}
