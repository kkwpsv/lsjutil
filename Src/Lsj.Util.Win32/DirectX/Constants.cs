using Lsj.Util.Win32.BaseTypes;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static System.Net.WebRequestMethods;

namespace Lsj.Util.Win32.DirectX
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// <para>
        /// No error occurred.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3D_OK = S_OK;

        /// <summary>
        /// <para>
        /// Specifies the primary display adapter.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dadapter-default"/>
        /// </para>
        /// </summary>
        public const uint D3DADAPTER_DEFAULT = 0;

        /// <summary>
        /// <para>
        /// The device has been lost but cannot be reset at this time.
        /// Therefore, rendering is not possible.
        /// A Direct3D device object other than the one that returned this code caused the hardware adapter to be reset by the OS.
        /// Delete all video memory objects (surfaces, textures, state blocks) and call Reset() to return the device to a default state.
        /// If the application continues rendering without a reset, the rendering calls will succeed.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_DEVICELOST = 0x88760868;

        /// <summary>
        /// <para>
        /// The device has been lost but can be reset at this time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_DEVICENOTRESET = 0x88760869;

        /// <summary>
        /// <para>
        /// Internal driver error.
        /// Applications should destroy and recreate the device when receiving this error.
        /// For hints on debugging this error, see Driver Internal Errors (Direct3D 9).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_DRIVERINTERNALERROR = 0x88760827;

        /// <summary>
        /// <para>
        /// The method call is invalid.
        /// For example, a method's parameter may not be a valid pointer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_INVALIDCALL = 0x8876086c;
    }
}
