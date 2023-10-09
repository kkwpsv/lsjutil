using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Unordered-access view options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_uav_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used by a unordered access-view description (see <see cref="D3D11_UNORDERED_ACCESS_VIEW_DESC"/>).
    /// </remarks>
    public enum D3D11_UAV_DIMENSION
    {
        /// <summary>
        /// The view type is unknown.
        /// </summary>
        D3D11_UAV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// View the resource as a buffer.
        /// </summary>
        D3D11_UAV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// View the resource as a 1D texture.
        /// </summary>
        D3D11_UAV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// View the resource as a 1D texture array.
        /// </summary>
        D3D11_UAV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// View the resource as a 2D texture.
        /// </summary>
        D3D11_UAV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// View the resource as a 2D texture array.
        /// </summary>
        D3D11_UAV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// View the resource as a 3D texture array.
        /// </summary>
        D3D11_UAV_DIMENSION_TEXTURE3D = 8,
    }
}
