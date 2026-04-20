using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_LAYOUT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the tier level at which tiled resources are supported.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tiled_resources_tier"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS"/> structure.
    /// </para>
    /// <para>
    /// There are three discrete pieces of functionality bundled together for tiled resource functionality:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// A tile-based texture layout option where nearby texel addresses contain nearby data coordinates.
    /// A tile of texels contains nearly the same amount of texels in each cardinal dimension of the resource.
    /// This layout is represented in D3D12 by <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Reserve a region of virtual address space for a resource, where each page is initially NULL-mapped.
    /// In D3D12, this is operation is encapsulated within <see cref="ID3D12Device.CreateReservedResource"/>,
    /// which only works with textures that have the <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/> layout.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The ability to change page mappings and manipulate texture data on tile granularities.
    /// In D3D12, these operations are <see cref="ID3D12CommandQueue.UpdateTileMappings"/>,
    /// <see cref="ID3D12CommandQueue.CopyTileMappings"/>, and <see cref="ID3D12GraphicsCommandList.CopyTiles"/>.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Three significant changes over D3D11 are:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Tile pools are replaced by heaps. Heaps provide a superset of capabilities than D3D11 tile pools do.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Reserved resources may be mapped to pages from multiple heaps at the same time.
    /// The D3D11 restriction that all non-NULL mapped pages must come from the same heap does not exist.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Applications should be aware of GPU virtual address capabilities, which enable litmus tests for particular usage scenarios.
    /// See <see cref="D3D12_FEATURE_GPU_VIRTUAL_ADDRESS_SUPPORT"/>.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_TILED_RESOURCES_TIER
    {
        /// <summary>
        /// <para>
        /// Indicates that textures cannot be created with the <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/> layout.
        /// </para>
        /// <para>
        /// <see cref="ID3D12Device.CreateReservedResource"/> cannot be used, not even for buffers.
        /// </para>
        /// </summary>
        D3D12_TILED_RESOURCES_TIER_NOT_SUPPORTED = 0,

        /// <summary>
        /// <para>
        /// Indicates that 2D textures can be created with the <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/> layout.
        /// </para>
        /// <para>
        /// Limitations exist for certain resource formats and properties.
        /// </para>
        /// <para>
        /// For more details, see <see cref="D3D12_TEXTURE_LAYOUT_64KB_UNDEFINED_SWIZZLE"/>.
        /// </para>
        /// <para>
        /// <see cref="ID3D12Device.CreateReservedResource"/> can be used.
        /// </para>
        /// <para>
        /// GPU reads or writes to <see cref="NULL"/> mappings are undefined.
        /// </para>
        /// <para>
        /// Applications are encouraged to workaround this limitation
        /// by repeatedly mapping the same page to everywhere a <see cref="NULL"/> mapping would've been used.
        /// </para>
        /// <para>
        /// When the size of a texture mipmap level is an integer multiple of the standard tile shape for its format,
        /// it is guaranteed to be nonpacked.
        /// </para>
        /// </summary>
        D3D12_TILED_RESOURCES_TIER_1 = 1,

        /// <summary>
        /// <para>
        /// Indicates that a superset of Tier_1 functionality is supported, including this additional support:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// When the size of a texture mipmap level is at least one standard tile shape for its format,
        /// the mipmap level is guaranteed to be nonpacked.
        /// </para>
        /// <para>
        /// For more info, see <see cref="D3D12_PACKED_MIP_INFO"/>.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Shader instructions are available for clamping level-of-detail (LOD) and for obtaining status about the shader operation.
        /// </para>
        /// <para>
        /// For info about one of these shader instructions, see <c>Sample(S,float,int,float,uint)</c>.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Reading from <see cref="NULL"/>-mapped tiles treat that sampled value as zero.
        /// </para>
        /// <para>
        /// Writes to <see cref="NULL"/>-mapped tiles are discarded.
        /// </para>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Adapters that support feature level 12_0 all support TIER_2 or greater.
        /// </para>
        /// </summary>
        D3D12_TILED_RESOURCES_TIER_2 = 2,

        /// <summary>
        /// Indicates that a superset of Tier 2 is supported, with the addition that 3D textures (Volume Tiled Resources) are supported.
        /// </summary>
        D3D12_TILED_RESOURCES_TIER_3 = 3,

        /// <summary>
        /// 
        /// </summary>
        D3D12_TILED_RESOURCES_TIER_4 = 4
    }
}
