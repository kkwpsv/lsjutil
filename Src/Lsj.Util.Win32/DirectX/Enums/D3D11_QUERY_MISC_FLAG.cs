using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags that describe miscellaneous query behavior.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_query_misc_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This flag is part of a query description (see <see cref="D3D11_QUERY_DESC"/>).
    /// </remarks>
    public enum D3D11_QUERY_MISC_FLAG
    {
        /// <summary>
        /// Tell the hardware that if it is not yet sure if something is hidden or not to draw it anyway.
        /// This is only used with an occlusion predicate.
        /// Predication data cannot be returned to your application via <see cref="ID3D11DeviceContext.GetData"/> when using this flag.
        /// </summary>
        D3D11_QUERY_MISC_PREDICATEHINT = 0x1,
    }
}
