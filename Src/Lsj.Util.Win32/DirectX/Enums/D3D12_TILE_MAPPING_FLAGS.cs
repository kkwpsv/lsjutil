using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to perform a tile-mapping operation.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_tile_mapping_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12CommandQueue.CopyTileMappings"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12CommandQueue.UpdateTileMappings"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_TILE_MAPPING_FLAGS
    {
        /// <summary>
        /// No tile-mapping flags are specified.
        /// </summary>
        D3D12_TILE_MAPPING_FLAG_NONE = 0,

        /// <summary>
        /// Unsupported, do not use.
        /// </summary>
        D3D12_TILE_MAPPING_FLAG_NO_HAZARD = 0x1
    }
}
