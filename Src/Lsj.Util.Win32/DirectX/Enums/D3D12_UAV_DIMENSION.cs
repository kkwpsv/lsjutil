using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies unordered-access view options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_uav_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Specify one of the values in this enumeration in the <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC.ViewDimension"/> member
    /// of a <see cref="D3D12_UNORDERED_ACCESS_VIEW_DESC"/> structure.
    /// </remarks>
    public enum D3D12_UAV_DIMENSION
    {
        /// <summary>
        /// The view type is unknown.
        /// </summary>
        D3D12_UAV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// View the resource as a buffer.
        /// </summary>
        D3D12_UAV_DIMENSION_BUFFER = 1,

        /// <summary>
        /// View the resource as a 1D texture.
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE1D = 2,

        /// <summary>
        /// View the resource as a 1D texture array.
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE1DARRAY = 3,

        /// <summary>
        /// View the resource as a 2D texture.
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE2D = 4,

        /// <summary>
        /// View the resource as a 2D texture array.
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE2DARRAY = 5,

        /// <summary>
        /// 
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE2DMS = 6,

        /// <summary>
        /// 
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE2DMSARRAY = 7,

        /// <summary>
        /// View the resource as a 3D texture array.
        /// </summary>
        D3D12_UAV_DIMENSION_TEXTURE3D = 8
    }
}
