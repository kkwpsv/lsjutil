using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a range of tile mappings.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_range_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use these flags with <see cref="ID3D12CommandQueue.UpdateTileMappings"/>.
    /// </remarks>
    public enum D3D12_TILE_RANGE_FLAGS
    {
        /// <summary>
        /// No tile-mapping flags are specified.
        /// </summary>
        D3D12_TILE_RANGE_FLAG_NONE = 0,

        /// <summary>
        /// The tile range is NULL.
        /// </summary>
        D3D12_TILE_RANGE_FLAG_NULL = 1,

        /// <summary>
        /// Skip the tile range.
        /// </summary>
        D3D12_TILE_RANGE_FLAG_SKIP = 2,

        /// <summary>
        /// Reuse a single tile in the tile range.
        /// </summary>
        D3D12_TILE_RANGE_FLAG_REUSE_SINGLE_TILE = 4
    }
}
