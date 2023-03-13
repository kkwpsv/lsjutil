using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS3;
using static Lsj.Util.Win32.DirectX.Enums.D3DPRESENTFLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3DSWAPEFFECT;
using static Lsj.Util.Win32.Winmm;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes the relationship between the adapter refresh rate and the rate
    /// at which <see cref="IDirect3DSwapChain9.Present"/> or Present operations are completed.
    /// These values also serve as flag values for the <see cref="D3DCAPS9.PresentationIntervals"/> field of <see cref="D3DCAPS9"/>
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpresent"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Windowed mode supports <see cref="D3DPRESENT_INTERVAL_DEFAULT"/>, <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/>, and <see cref="D3DPRESENT_INTERVAL_ONE"/>.
    /// <see cref="D3DPRESENT_INTERVAL_DEFAULT"/> and the <see cref="D3DPRESENT_INTERVAL_ONE"/> are nearly equivalent (see the information regarding timer resolution below).
    /// They perform similarly to COPY_VSYNC in that there is only one present per frame, and they prevent tearing with beam-following.
    /// In contrast, <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/> will attempt to provide an unlimited presentation rate.
    /// Full-screen mode supports similar usage as windowed mode by supporting <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/> regardless of the refresh rate or swap effect.
    /// <see cref="D3DPRESENT_INTERVAL_DEFAULT"/> uses the default system timer resolution
    /// whereas the <see cref="D3DPRESENT_INTERVAL_ONE"/> calls <see cref="timeBeginPeriod"/> to enhance system timer resolution.
    /// This improves the quality of vertical sync, but consumes slightly more processing time.
    /// Both parameters attempt to synchronize vertically.
    /// </remarks>
    [Flags]
    public enum D3DPRESENT : uint
    {
        /// <summary>
        /// Use the front buffer as both the source and target surface during rendering.
        /// A frame synch is scheduled but the displayed surface does not change.
        /// This flag is only available when the application is in fullscreen mode and <see cref="D3DSWAPEFFECT_FLIPEX"/> has been specified.
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENT_DONOTFLIP = 0x00000004,

        /// <summary>
        /// A presentation cannot be scheduled by a hal device.
        /// If this flag is set in a call to <see cref="IDirect3DDevice9.Present"/>, and the hardware is busy processing or waiting for a vertical sync interval,
        /// then <see cref="IDirect3DDevice9.Present"/> will return <see cref="D3DERR_WASSTILLDRAWING"/> to indicate that the blit operation is incomplete.
        /// </summary>
        D3DPRESENT_DONOTWAIT = 0x00000001,

        /// <summary>
        /// Reserved.
        /// </summary>
        D3DPRESENT_FLIPRESTART = 0x00000008,

        /// <summary>
        /// <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/> is enforced on this Present call.
        /// This flag can only be specified when using <see cref="D3DSWAPEFFECT_FLIPEX"/>.
        /// Windowed and fullscreen presentation behaviors are the same.
        /// This is especially useful for media apps that want to discard frames that have been detected as late and present subsequent frames at composition time.
        /// An invalid parameter error will be returned if this flag is improperly specified.
        /// When multiple consecutive frames with <see cref="D3DPRESENT_FORCEIMMEDIATE"/>s are queued,
        /// only the last frame is displayed, for both windowed and fullscreen presentation.
        /// This flag is available in Direct3D 9Ex on Windows 7 or later operating systems.
        /// When using <see cref="D3DSWAPEFFECT_FLIPEX"/>, each frame presented using <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/>
        /// or <see cref="D3DPRESENT_INTERVAL_FORCEIMMEDIATE"/> will override the previous frame's present interval.
        /// For example, if you queue the following frames using the following swap effects:
        /// frame A (<see cref="D3DPRESENT_INTERVAL_ONE"/>), frame B(<see cref="D3DPRESENT_INTERVAL_ONE"/>),
        /// frame C(<see cref="D3DPRESENT_INTERVAL_ONE"/>), frame D(<see cref="D3DPRESENT_INTERVAL_FORCEIMMEDIATE"/>),
        /// frame D will override frame C's present interval.
        /// The displayed frames per present interval are frame A, frame B, (frame C overridden by) frame D.
        /// See Remarks.
        /// </summary>
        D3DPRESENT_FORCEIMMEDIATE = 0x00000100,

        /// <summary>
        /// This is nearly equivalent to <see cref="D3DPRESENT_INTERVAL_ONE"/>.
        /// See remarks.
        /// </summary>
        D3DPRESENT_INTERVAL_DEFAULT = 0x00000000,

        /// <summary>
        /// The driver will wait for the vertical retrace period (the runtime will "beam follow" to prevent tearing).
        /// Present operations will not be affected more frequently than the screen refresh;
        /// the runtime will complete at most one Present operation per adapter refresh period.
        /// This is equivalent to using <see cref="D3DSWAPEFFECT_COPYVSYNC"/> in DirectX 8.1.
        /// This option is always available for both windowed and full-screen swap chains.
        /// See remarks.
        /// </summary>
        D3DPRESENT_INTERVAL_ONE = 0x00000001,

        /// <summary>
        /// The driver will wait for the vertical retrace period.
        /// Present operations will not be affected more frequently than every second screen refresh.
        /// Check the <see cref="D3DCAPS9.PresentationIntervals"/> cap (see <see cref="D3DCAPS9"/>)
        /// to see if <see cref="D3DPRESENT_INTERVAL_TWO"/> is supported by the driver.
        /// </summary>
        D3DPRESENT_INTERVAL_TWO = 0x00000002,

        /// <summary>
        /// The driver will wait for the vertical retrace period.
        /// Present operations will not be affected more frequently than every third screen refresh.
        /// Check the <see cref="D3DCAPS9.PresentationIntervals"/> cap (see <see cref="D3DCAPS9"/>)
        /// to see if <see cref="D3DPRESENT_INTERVAL_THREE"/> is supported by the driver.
        /// </summary>
        D3DPRESENT_INTERVAL_THREE = 0x00000004,

        /// <summary>
        /// The driver will wait for the vertical retrace period.
        /// Present operations will not be affected more frequently than every fourth screen refresh.
        /// Check the <see cref="D3DCAPS9.PresentationIntervals"/> member (see <see cref="D3DCAPS9"/>) to see
        /// if <see cref="D3DPRESENT_INTERVAL_FOUR"/> is supported by the driver.
        /// </summary>
        D3DPRESENT_INTERVAL_FOUR = 0x00000008,

        /// <summary>
        /// The runtime updates the window client area immediately and might do so more than once during the adapter refresh period.
        /// This is equivalent to using <see cref="D3DSWAPEFFECT_COPY"/> in DirectX 8.
        /// Present operations might be affected immediately.
        /// This option is always available for both windowed and full-screen swap chains.
        /// See remarks.
        /// </summary>
        D3DPRESENT_INTERVAL_IMMEDIATE = 0x80000000,

        /// <summary>
        /// The content of the back buffer to be presented is in the linear color space.
        /// The presentation will implicitly convert from linear space to sRGB (gamma = 2.2). This is the only conversion that is supported.
        /// Because this flag represents a property of the content of the back buffer,
        /// the flag can be specified during an <see cref="IDirect3DSwapChain9.Present"/> call.
        /// In other words, an application can present linear content in one frame, and then switch to corrected content in the next.
        /// This flag is ignored when the swap chain is full screen.
        /// (Note that this flag is available only on the explicit swap chain version of <see cref="IDirect3DSwapChain9.Present"/>.
        /// The <see cref="IDirect3DDevice9.Present"/> method does not take a flags parameter.)
        /// This flag is always accepted, but will only take effect when the driver exposes <see cref="D3DCAPS3_LINEAR_TO_SRGB_PRESENTATION"/>.
        /// The only back buffer format supported is X8R8G8B8.
        /// See Windowed Swap Chains.
        /// </summary>
        D3DPRESENT_LINEAR_CONTENT = 0x00000002,

        /// <summary>
        /// Clips the rendered contents to the monitor/device the adapter is targeting,
        /// shows thumbnails for the content in the Flip3D view and taskbar thumbnails on other monitors.
        /// This flag is available in Direct3D 9Ex only.
        /// See Desktop Window Manager for further details on this feature of Windows Vista.
        /// If you are not running in desktop composition mode, the flag gives the same behavior as <see cref="D3DPRESENTFLAG_DEVICECLIP"/>.
        /// [!Note]
        /// This flag should only be used with swap effect <see cref="D3DSWAPEFFECT_FLIPEX"/>.
        /// The use of this flag with other swap effects is being deprecated, and may not work in future versions of Windows.
        /// </summary>
        D3DPRESENT_VIDEO_RESTRICT_TO_MONITOR = 0x00000010,

        /// <summary>
        /// Updates the overlay position or the colorkey data without causing an actual flip and without changing the duration with which the image is displayed.
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENT_UPDATEOVERLAYONLY = 0x00000020,

        /// <summary>
        /// Turns off the overlay hardware.
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENT_HIDEOVERLAY = 0x00000040,

        /// <summary>
        /// Redraws the colorkey data.
        /// This flag is available in Direct3D 9Ex only.
        /// </summary>
        D3DPRESENT_UPDATECOLORKEY = 0x00000080,
    }
}
