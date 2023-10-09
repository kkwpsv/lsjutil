using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Option(s) for raising an error to a non-continuable exception.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_raise_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These flags are used by <see cref="ID3D11Device.GetExceptionMode"/> and <see cref="ID3D11Device.SetExceptionMode"/>.
    /// Use 0 to indicate no flags; multiple flags can be logically OR'ed together.
    /// </remarks>
    public enum D3D11_RAISE_FLAG
    {
        /// <summary>
        /// Raise an internal driver error to a non-continuable exception.
        /// </summary>
        D3D11_RAISE_FLAG_DRIVER_INTERNAL_ERROR = 0x1,
    }
}
