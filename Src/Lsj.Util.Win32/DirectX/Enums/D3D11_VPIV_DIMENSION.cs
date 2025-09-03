using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how to access a resource that is used in a video processor input view.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_vpiv_dimension"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used with the <see cref="D3D11_VIDEO_PROCESSOR_INPUT_VIEW_DESC"/> structure.
    /// </remarks>
    public enum D3D11_VPIV_DIMENSION
    {
        /// <summary>
        /// Not a valid value.
        /// </summary>
        D3D11_VPIV_DIMENSION_UNKNOWN = 0,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        D3D11_VPIV_DIMENSION_TEXTURE2D = 1,
    }
}
