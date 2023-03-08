using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

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
        /// D3DERR_COMMAND_UNPARSED
        /// </summary>
        public static readonly HRESULT D3DERR_COMMAND_UNPARSED = 0x88760BB8;

        /// <summary>
        /// <para>
        /// The device that returned this code caused the hardware adapter to be reset by the OS.
        /// Most applications should destroy the device and quit.
        /// Applications that must continue should destroy all video memory objects (surfaces, textures, state blocks etc)
        /// and call <see cref="IDirect3DDevice9.Reset"/> to put the device in a default state.
        /// If the application then continues rendering in the same way, the device will return to this state.
        /// Applies to Direct3D 9Ex only.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_DEVICEHUNG = 0x88760874;

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
        /// The hardware adapter has been removed.
        /// Application must destroy the device, do enumeration of adapters and create another Direct3D device.
        /// If application continues rendering without calling Reset, the rendering calls will succeed.
        /// Applies to Direct3D 9Ex only.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_DEVICEREMOVED = 0x88760870;

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

        /// <summary>
        /// <para>
        /// This device does not support the queried technique.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_NOTAVAILABLE = 0x8876086a;

        /// <summary>
        /// <para>
        /// The requested item was not found.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_NOTFOUND = 0x88760866;

        /// <summary>
        /// <para>
        /// Direct3D does not have enough display memory to perform the operation.
        /// The device is using more resources in a single scene than can fit simultaneously into video memory.
        /// <see cref="IDirect3DDevice9.Present"/>, <see cref="IDirect3DDevice9Ex.PresentEx"/>,
        /// or <see cref="IDirect3DDevice9Ex.CheckDeviceState"/> can return this error.
        /// Recovery is similar to <see cref="D3DERR_DEVICEHUNG"/>,
        /// though the application may want to reduce its per-frame memory usage as well to avoid having the error recur.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_OUTOFVIDEOMEMORY = 0x8876017c;

        /// <summary>
        /// <para>
        /// The previous blit operation that is transferring information to or from this surface is incomplete.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DERR_WASSTILLDRAWING = 0x8876021c;

        /// <summary>
        /// <para>
        /// This is a success code. However, the autogeneration of mipmaps is not supported for this format.
        /// This means that resource creation will succeed but the mipmap levels will not be automatically generated.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
        /// </para>
        /// </summary>
        public static readonly HRESULT D3DOK_NOAUTOGEN = 0x0876086f;
    }
}
