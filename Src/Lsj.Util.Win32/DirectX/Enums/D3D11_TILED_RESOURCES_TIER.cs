using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_RESOURCE_MISC_FLAG;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the tier level at which tiled resources are supported.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_tiled_resources_tier"/>
    /// </para>
    /// </summary>
    public enum D3D11_TILED_RESOURCES_TIER
    {
        /// <summary>
        /// Tiled resources are not supported.
        /// </summary>
        D3D11_TILED_RESOURCES_NOT_SUPPORTED = 0,

        /// <summary>
        /// <para>
        /// Tier_1 tiled resources are supported.
        /// </para>
        /// <para>
        /// The device supports calls to <see cref="ID3D11Device.CreateTexture2D"/> and so on with the <see cref="D3D11_RESOURCE_MISC_TILED"/> flag.
        /// </para>
        /// <para>
        /// The device supports calls to <see cref="ID3D11Device.CreateBuffer"/> with the <see cref="D3D11_RESOURCE_MISC_TILE_POOL"/> flag.
        /// </para>
        /// <para>
        /// If you access tiles (read or write) that are <see cref="NULL"/>-mapped, you get undefined behavior, which includes device-removed.
        /// Apps can map all tiles to a single "default" tile to avoid this condition.
        /// </para>
        /// </summary>
        D3D11_TILED_RESOURCES_TIER_1 = 1,

        /// <summary>
        /// <para>
        /// Tier_2 tiled resources are supported.
        /// </para>
        /// <para>
        /// Superset of Tier_1 functionality, which includes this additional support:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <para>
        /// On Tier_1, if the size of a texture mipmap level is an integer multiple of the standard tile shape for its format,
        /// it is guaranteed to be nonpacked.
        /// On Tier_2, this guarantee is expanded to include mipmap levels whose size is at least one standard tile shape.
        /// </para>
        /// <para>
        /// For more info, see <see cref="D3D11_PACKED_MIP_DESC"/>.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// Shader instructions are available for clamping level-of-detail (LOD) and for obtaining status about the shader operation.
        /// For info about one of these shader instructions, see <c>Sample(S,float,int,float,uint)</c>.
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Reading from <c>NULL</c>-mapped tiles treat that sampled value as zero.
        /// Writes to <c>NULL</c>-mapped tiles are discarded.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D11_TILED_RESOURCES_TIER_2 = 2,

        /// <summary>
        /// /// <list type="table">
        /// <listheader>
        /// <term>
        /// Superset of Tier_2 functionality, Tier 3 is essentially Tier 2
        /// but with the additional support of Texture3D for Tiled Resources.
        /// </term>
        /// </listheader>
        /// </list>
        /// </summary>
        D3D11_TILED_RESOURCES_TIER_3 = 3,
    }
}
