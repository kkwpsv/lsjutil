using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// The following is a list of the values that can be returned by Direct3D methods.
    /// See the individual method descriptions for lists of the values that each can return.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3derr"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Errors are represented by negative values and cannot be combined.
    /// Other return codes are contained in <see cref="S_PRESENT"/>.
    /// The facility code _FACD3D is used to generate error codes, as in the following macros.
    /// <code>
    /// // Direct3D Errors
    /// #define D3DERR_UNSUPPORTEDFACTORVALUE  MAKE_D3DHRESULT(2079)
    /// #define D3DERR_WASSTILLDRAWING         MAKE_D3DHRESULT(540)
    /// 
    /// #define _FACD3D                  0x876   // Direct3D facility code
    /// #define MAKE_D3DHRESULT( code )  MAKE_HRESULT( 1, _FACD3D, code )
    /// #define MAKE_D3DSTATUS( code )   MAKE_HRESULT( 0, _FACD3D, code )
    /// </code>
    /// </remarks>
    public enum D3DERR : uint
    {
        /// <summary>
        /// D3DERR_COMMAND_UNPARSED
        /// </summary>
        D3DERR_COMMAND_UNPARSED = 0x88760BB8,

        /// <summary>
        /// The currently set render states cannot be used together.
        /// </summary>
        D3DERR_CONFLICTINGRENDERSTATE = 0x88760821,

        /// <summary>
        /// The current texture filters cannot be used together.
        /// </summary>
        D3DERR_CONFLICTINGTEXTUREFILTER = 0x8876081e,

        /// <summary>
        /// The device that returned this code caused the hardware adapter to be reset by the OS.
        /// Most applications should destroy the device and quit.
        /// Applications that must continue should destroy all video memory objects (surfaces, textures, state blocks etc)
        /// and call <see cref="IDirect3DDevice9.Reset"/> to put the device in a default state.
        /// If the application then continues rendering in the same way, the device will return to this state.
        /// Applies to Direct3D 9Ex only.
        /// </summary>
        D3DERR_DEVICEHUNG = 0x88760874,

        /// <summary>
        /// The device has been lost but cannot be reset at this time.
        /// Therefore, rendering is not possible.
        /// A Direct3D device object other than the one that returned this code caused the hardware adapter to be reset by the OS.
        /// Delete all video memory objects (surfaces, textures, state blocks) and call Reset() to return the device to a default state.
        /// If the application continues rendering without a reset, the rendering calls will succeed.
        /// </summary>
        D3DERR_DEVICELOST = 0x88760868,

        /// <summary>
        /// The device has been lost but can be reset at this time.
        /// </summary>
        D3DERR_DEVICENOTRESET = 0x88760869,

        /// <summary>
        /// The hardware adapter has been removed.
        /// Application must destroy the device, do enumeration of adapters and create another Direct3D device.
        /// If application continues rendering without calling Reset, the rendering calls will succeed.
        /// Applies to Direct3D 9Ex only.
        /// </summary>
        D3DERR_DEVICEREMOVED = 0x88760870,

        /// <summary>
        /// Internal driver error.
        /// Applications should destroy and recreate the device when receiving this error.
        /// For hints on debugging this error, see Driver Internal Errors (Direct3D 9).
        /// </summary>
        D3DERR_DRIVERINTERNALERROR = 0x88760827,

        /// <summary>
        /// The method call is invalid.
        /// For example, a method's parameter may not be a valid pointer.
        /// </summary>
        D3DERR_INVALIDCALL = 0x8876086c,

        /// <summary>
        /// The requested device type is not valid.
        /// </summary>
        D3DERR_INVALIDDEVICE = 0x8876086b,

        /// <summary>
        /// D3DERR_MOREDATA
        /// </summary>
        D3DERR_MOREDATA = 0x88760867,

        /// <summary>
        /// This device does not support the queried technique.
        /// </summary>
        D3DERR_NOTAVAILABLE = 0x8876086a,

        /// <summary>
        /// The requested item was not found.
        /// </summary>
        D3DERR_NOTFOUND = 0x88760866,

        /// <summary>
        /// Direct3D does not have enough display memory to perform the operation.
        /// The device is using more resources in a single scene than can fit simultaneously into video memory.
        /// <see cref="IDirect3DDevice9.Present"/>, <see cref="IDirect3DDevice9Ex.PresentEx"/>,
        /// or <see cref="IDirect3DDevice9Ex.CheckDeviceState"/> can return this error.
        /// Recovery is similar to <see cref="D3DERR_DEVICEHUNG"/>,
        /// though the application may want to reduce its per-frame memory usage as well to avoid having the error recur.
        /// </summary>
        D3DERR_OUTOFVIDEOMEMORY = 0x8876017c,

        /// <summary>
        /// The application is requesting more texture-filtering operations than the device supports.
        /// </summary>
        D3DERR_TOOMANYOPERATIONS = 0x8876081d,

        /// <summary>
        /// The device does not support a specified texture-blending argument for the alpha channel.
        /// </summary>
        D3DERR_UNSUPPORTEDALPHAARG = 0x8876081c,

        /// <summary>
        /// The device does not support a specified texture-blending operation for the alpha channel.
        /// </summary>
        D3DERR_UNSUPPORTEDALPHAOPERATION = 0x8876081b,

        /// <summary>
        /// The device does not support a specified texture-blending argument for color values.
        /// </summary>
        D3DERR_UNSUPPORTEDCOLORARG = 0x8876081a,

        /// <summary>
        /// The device does not support a specified texture-blending operation for color values.
        /// </summary>
        D3DERR_UNSUPPORTEDCOLOROPERATION = 0x88760819,

        /// <summary>
        /// The device does not support the specified texture factor value.
        /// Not used; provided only to support older drivers.
        /// </summary>
        D3DERR_UNSUPPORTEDFACTORVALUE = 0x8876081f,

        /// <summary>
        /// The device does not support the specified texture filter.
        /// </summary>
        D3DERR_UNSUPPORTEDTEXTUREFILTER = 0x88760822,

        /// <summary>
        /// The previous blit operation that is transferring information to or from this surface is incomplete.
        /// </summary>
        D3DERR_WASSTILLDRAWING = 0x8876021c,

        /// <summary>
        /// The pixel format of the texture surface is not valid.
        /// </summary>
        D3DERR_WRONGTEXTUREFORMAT = 0x88760818,
    }
}
