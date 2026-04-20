using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies the type of resource being used.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_RESOURCE_DESC"/> structure.
    /// </remarks>
    public enum D3D12_RESOURCE_DIMENSION
    {
        /// <summary>
        /// Resource is of unknown type.
        /// </summary>
        D3D12_RESOURCE_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// Resource is a buffer.
        /// </summary>
        D3D12_RESOURCE_DIMENSION_BUFFER = 1,

        /// <summary>
        /// Resource is a 1D texture.
        /// </summary>
        D3D12_RESOURCE_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// Resource is a 2D texture.
        /// </summary>
        D3D12_RESOURCE_DIMENSION_TEXTURE2D = 3,

        /// <summary>
        /// Resource is a 3D texture.
        /// </summary>
        D3D12_RESOURCE_DIMENSION_TEXTURE3D = 4
    }
}
