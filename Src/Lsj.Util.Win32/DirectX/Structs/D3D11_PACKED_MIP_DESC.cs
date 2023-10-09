using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the tile structure of a tiled resource with mipmaps.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ns-d3d11_2-d3d11_packed_mip_desc"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_PACKED_MIP_DESC
    {
        /// <summary>
        /// Number of standard mipmaps in the tiled resource.
        /// </summary>
        public UINT8 NumStandardMips;

        /// <summary>
        /// Number of packed mipmaps in the tiled resource.
        /// This number starts from the least detailed mipmap (either sharing tiles or using non standard tile layout).
        /// This number is 0 if no such packing is in the resource.
        /// For array surfaces, this value is the number of mipmaps that are packed for a given array slice where each array slice repeats the same packing.
        /// On Tier_2 tiled resources hardware, mipmaps that fill at least one standard shaped tile in all dimensions are not allowed
        /// to be included in the set of packed mipmaps.
        /// On Tier_1 hardware, mipmaps that are an integer multiple of one standard shaped tile in all dimensions are not allowed
        /// to be included in the set of packed mipmaps.
        /// Mipmaps with at least one dimension less than the standard tile shape may or may not be packed.
        /// When a given mipmap needs to be packed, all coarser mipmaps for a given array slice are considered packed as well.
        /// </summary>
        public UINT8 NumPackedMips;

        /// <summary>
        /// Number of tiles for the packed mipmaps in the tiled resource.
        /// If there is no packing, this value is meaningless and is set to 0.
        /// Otherwise, it is set to the number of tiles that are needed to represent the set of packed mipmaps.
        /// The pixel layout within the packed mipmaps is hardware specific.
        /// If apps define only partial mappings for the set of tiles in packed mipmaps, read and write behavior is vendor specific and undefined.
        /// For arrays, this value is only the count of packed mipmaps within the subresources for each array slice.
        /// </summary>
        public UINT NumTilesForPackedMips;

        /// <summary>
        /// Offset of the first packed tile for the resource in the overall range of tiles.
        /// If <see cref="NumPackedMips"/> is 0, this value is meaningless and is 0.
        /// Otherwise, it is the offset of the first packed tile for the resource in the overall range of tiles for the resource.
        /// A value of 0 for <see cref="StartTileIndexInOverallResource"/> means the entire resource is packed.
        /// For array surfaces, this is the offset for the tiles that contain the packed mipmaps for the first array slice.
        /// Packed mipmaps for each array slice in arrayed surfaces are at this offset past the beginning of the tiles for each array slice.
        /// Note
        /// The number of overall tiles, packed or not, for a given array slice is simply the total number of tiles
        /// for the resource divided by the resource's array size, so it is easy to locate the range of tiles for any given array slice,
        /// out of which <see cref="StartTileIndexInOverallResource"/> identifies which of those are packed.
        /// </summary>
        public UINT StartTileIndexInOverallResource;
    }
}
