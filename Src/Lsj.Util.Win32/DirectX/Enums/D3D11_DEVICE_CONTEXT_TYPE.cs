using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Device context options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_device_context_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enumeration is used by <see cref="ID3D11DeviceContext.GetType"/>.
    /// </remarks>
    public enum D3D11_DEVICE_CONTEXT_TYPE
    {
        /// <summary>
        /// The device context is an immediate context.
        /// </summary>
        D3D11_DEVICE_CONTEXT_IMMEDIATE = 0,

        /// <summary>
        /// The device context is a deferred context.
        /// </summary>
        D3D11_DEVICE_CONTEXT_DEFERRED
    }
}
