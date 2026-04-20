using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the size of a tiled region.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_tile_region_size"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used by the <see cref="ID3D12GraphicsCommandList.CopyTiles"/>,
    /// <see cref="ID3D12CommandQueue.CopyTileMappings"/> and <see cref="ID3D12CommandQueue.UpdateTileMappings"/> methods.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_TILE_REGION_SIZE
    {
        /// <summary>
        /// The number of tiles in the tiled region.
        /// </summary>
        public UINT NumTiles;

        /// <summary>
        /// <para>
        /// Specifies whether the runtime uses the <see cref="Width"/>, <see cref="Height"/>,
        /// and <see cref="Depth"/> members to define the region.
        /// </para>
        /// <para>
        /// If <see cref="TRUE"/>, the runtime uses the <see cref="Width"/>, <see cref="Height"/>,
        /// and <see cref="Depth"/> members to define the region.
        /// In this case, <see cref="NumTiles"/> should be equal to <see cref="Width"/> * <see cref="Height"/> * <see cref="Depth"/>.
        /// </para>
        /// <para>
        /// If <see cref="FALSE"/>, the runtime ignores the <see cref="Width"/>,
        /// <see cref="Height"/>, and <see cref="Depth"/> members
        /// and uses the <see cref="NumTiles"/> member to traverse tiles in the resource
        /// linearly across x, then y, then z (as applicable) and then spills over mipmaps/arrays in subresource order.
        /// For example, use this technique to map an entire resource at once.
        /// </para>
        /// <para>
        /// Regardless of whether you specify <see cref="TRUE"/> or <see cref="FALSE"/> for <see cref="UseBox"/>,
        /// you use a <see cref="D3D12_TILED_RESOURCE_COORDINATE"/> structure to specify the starting location for the region
        /// within the resource as a separate parameter outside of this structure by using x, y, and z coordinates.
        /// </para>
        /// <para>
        /// When the region includes mipmaps that are packed with nonstandard tiling,
        /// <see cref="UseBox"/> must be <see cref="FALSE"/> because tile dimensions are not standard
        /// and the app only knows a count of how many tiles are consumed by the packed area, which is per array slice.
        /// The corresponding (separate) starting location parameter uses x to offset into the flat range of tiles in this case,
        /// and y and z coordinates must each be 0.
        /// </para>
        /// </summary>
        public BOOL UseBox;

        /// <summary>
        /// The width of the tiled region, in tiles.
        /// Used for buffer and 1D, 2D, and 3D textures.
        /// </summary>
        public UINT Width;

        /// <summary>
        /// The height of the tiled region, in tiles.
        /// Used for 2D and 3D textures.
        /// </summary>
        public UINT16 Height;

        /// <summary>
        /// The depth of the tiled region, in tiles. Used for 3D textures or arrays.
        /// For arrays, used for advancing in depth jumps to next slice of same mipmap size,
        /// which isn't contiguous in the subresource counting space if there are multiple mipmaps.
        /// </summary>
        public UINT16 Depth;
    }
}
