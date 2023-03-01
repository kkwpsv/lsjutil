using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3DFORMAT;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// These constants are used by <see cref="D3DPRESENT_PARAMETERS"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpresentflag"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum D3DPRESENTFLAG : uint
    {
        /// <summary>
        /// Clip a windowed Present blit into the window client area, within the monitor screen area of the video adapter that created the Direct3D device.
        /// <see cref="D3DPRESENTFLAG_DEVICECLIP"/> is not valid with <see cref="D3DSWAPEFFECT_FLIPEX"/>.
        /// </summary>
        D3DPRESENTFLAG_DEVICECLIP = 0x00000004,

        /// <summary>
        /// Set this flag when the device or swap chain is created to enable z-buffer discarding.
        /// If this flag is set, the contents of the depth stencil buffer will be invalid
        /// after calling either <see cref="IDirect3DDevice9.Present"/>, or <see cref="IDirect3DDevice9.SetDepthStencilSurface"/> with a different depth surface.
        /// Discarding z-buffer data can increase performance and is driver dependent.
        /// The debug runtime will enforce discarding by clearing the z-buffer to some constant value
        /// after calling either <see cref="IDirect3DDevice9.Present"/>, or <see cref="IDirect3DDevice9.SetDepthStencilSurface"/> with a different depth surface.
        /// Discarding z-buffer data is illegal for all lockable formats, <see cref="D3DFMT_D16_LOCKABLE"/> and <see cref="D3DFMT_D32F_LOCKABLE"/>.
        /// Any use of <see cref="IDirect3D9.CreateDevice"/> specifying a lockable format and z-buffer discarding will fail.
        /// For more information about formats, see <see cref="D3DFORMAT"/>.
        /// </summary>
        D3DPRESENTFLAG_DISCARD_DEPTHSTENCIL = 0x00000002,

        /// <summary>
        /// Set this flag if the application requires the ability to lock the back buffer directly.
        /// Note that back buffers are not lockable unless the application specifies <see cref="D3DPRESENTFLAG_LOCKABLE_BACKBUFFER"/>
        /// when calling <see cref="IDirect3D9.CreateDevice"/> or <see cref="IDirect3DDevice9.Reset"/>.
        /// Lockable back buffers incur a performance cost on some graphics hardware configurations.
        /// Performing a lock operation (or using <see cref="IDirect3DDevice9.UpdateSurface"/> to write) on the lockable back buffer decreases performance on many cards.
        /// In this case, consider using textured triangles to move data to the back buffer.
        /// </summary>
        D3DPRESENTFLAG_LOCKABLE_BACKBUFFER = 0x00000001,

        /// <summary>
        /// Rotated monitors are handled automatically with a rotating copy during presentation, which is not very efficient.
        /// This flag means the application will perform it's own display rotation.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// Applications can achieve their own rotation possibly by using a rotated view matrix.
        /// The methods <see cref="GetDisplayModeEx"/> and <see cref="GetAdapterDisplayModeEx"/> should be used to to find the current rotation setting.
        /// The backbuffer Width and Height parameters in <see cref="CreateDeviceEx"/> and <see cref="ResetEx"/> must be use landscape orientation,
        /// while the fullscreen display mode structure should be the same as
        /// what is returned from <see cref="EnumAdapterModesEx"/> (i.e. Width and Height are swapped when rotated 90 and 270 degrees).
        /// When using Lock on rotated render targets, upper-left corner assumptions no longer hold true,
        /// the render target <see cref="SURFACE_DESC"/> will remain landscape (as implied by the creation parameters),
        /// and GDI window, mouse coordinates, and such need to be properly translated when used with the Direct3D render target and scene.
        /// </summary>
        D3DPRESENTFLAG_NOAUTOROTATE = 0x00000020,

        /// <summary>
        /// Use this flag to specify any RAW display mode enumerated by the display adapter even though Direct3D may have indicated the mode is invalid.
        /// The application should implement this in a robust manner in case the desired mode really is invalid.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_UNPRUNEDMODE = 0x00000040,

        /// <summary>
        /// This is a hint to the driver that the back buffers will contain video data.
        /// </summary>
        D3DPRESENTFLAG_VIDEO = 0x00000010,

        /// <summary>
        /// Specifies whether the overlay is full range RGB or limited range RGB. Setting this flag indicates limited range RGB.
        /// In limited range RGB, the RGB range is compressed such that 16:16:16 is black and 235:235:235 is white.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_OVERLAY_LIMITEDRGB = 0x00000080,

        /// <summary>
        /// Specifies whether the overlay is BT.601 or BT.709.
        /// Setting this flag indicates BT.709, for high-definition TV (HDTV).
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_OVERLAY_YCbCr_BT709 = 0x00000100,

        /// <summary>
        /// Specifies whether the overlay is conventional YCbCr or extended YCbCr (xvYCC).
        /// Setting this flag indicates extended YCbCr (xvYCC).
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_OVERLAY_YCbCr_xvYCC = 0x00000200,

        /// <summary>
        /// Setting this flag indicates that the swapchain contains protected content and automatically causes the runtime
        /// to restrict access to the swapchain so that only the Desktop Windows Manager (DWM) can use the swapchain.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_RESTRICTED_CONTENT = 0x00000400,

        /// <summary>
        /// Setting this flag indicates that the driver should restrict access to any shared resources that are created for DWM interaction.
        /// The caller must create an authenticated channel with the driver.
        /// The driver should then allow access to processes that attempt to open those shared resources.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENTFLAG_RESTRICT_SHARED_RESOURCE_DRIVER = 0x00000800,
    }
}
