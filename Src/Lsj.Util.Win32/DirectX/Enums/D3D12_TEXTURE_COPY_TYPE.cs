using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies what type of texture copy is to take place.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_texture_copy_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_TEXTURE_COPY_LOCATION"/> structure.
    /// </remarks>
    public enum D3D12_TEXTURE_COPY_TYPE
    {
        /// <summary>
        /// Indicates a subresource, identified by an index, is to be copied.
        /// </summary>
        D3D12_TEXTURE_COPY_TYPE_SUBRESOURCE_INDEX = 0,

        /// <summary>
        /// Indicates a place footprint, identified by a <see cref="D3D12_PLACED_SUBRESOURCE_FOOTPRINT"/> structure, is to be copied.
        /// </summary>
        D3D12_TEXTURE_COPY_TYPE_PLACED_FOOTPRINT = 1
    }
}
