using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3DCAPS3;
using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines swap effects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dswapeffect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The state of the back buffer after a call to Present is well-defined by each of these swap effects,
    /// and whether the Direct3D device was created with a full-screen swap chain or a windowed swap chain has no effect on this state.
    /// In particular, the <see cref="D3DSWAPEFFECT_FLIP"/> swap effect operates the same whether windowed or full-screen,
    /// and the Direct3D runtime guarantees this by creating extra buffers.
    /// As a result, it is recommended that applications use <see cref="D3DSWAPEFFECT_DISCARD"/> whenever possible to avoid any such penalties.
    /// This is because this swap effect will always be the most efficient in terms of memory consumption and performance.
    /// Applications that use <see cref="D3DSWAPEFFECT_FLIP"/> or <see cref="D3DSWAPEFFECT_DISCARD"/> should not expect full-screen destination alpha to work.
    /// This means that the <see cref="D3DRS_DESTBLEND"/> render state will not work as expected
    /// because full-screen swap chains with these swap effects do not have an explicit pixel format from the driver's point of view.
    /// The driver infers that they should take on the display format, which does not have an alpha channel.
    /// To work around this, take the following steps:
    /// Use <see cref="D3DSWAPEFFECT_COPY"/>.
    /// Check the <see cref="D3DCAPS3_ALPHA_FULLSCREEN_FLIP_OR_DISCARD"/> flag
    /// in the <see cref="D3DCAPS9.Caps3"/> member of the <see cref="D3DCAPS9"/> structure.
    /// This flag indicates whether the driver can do alpha blending when <see cref="D3DSWAPEFFECT_FLIP"/> or <see cref="D3DSWAPEFFECT_DISCARD"/> is used.
    /// Applications using flip mode swap effect (<see cref="D3DSWAPEFFECT_FLIPEX"/>) should call <see cref="IDirect3DDevice9Ex.PresentEx"/>
    /// after a window resize or region change to ensure that the display content is updated.
    /// An invisible window cannot receive user-mode events; furthermore, an invisible-fullscreen window
    /// will interfere with the presentation of another applications' windowed-mode window.
    /// Therefore, each application needs to ensure that a device window is visible when a swapchain is presented in fullscreen mode.
    /// </remarks>
    public enum D3DSWAPEFFECT
    {
        /// <summary>
        /// When a swap chain is created with a swap effect of <see cref="D3DSWAPEFFECT_FLIP"/> or <see cref="D3DSWAPEFFECT_COPY"/>,
        /// the runtime will guarantee that an <see cref="IDirect3DDevice9.Present"/> operation will not affect the content of any of the back buffers.
        /// Unfortunately, meeting this guarantee can involve substantial video memory or processing overheads,
        /// especially when implementing flip semantics for a windowed swap chain or copy semantics for a full-screen swap chain.
        /// An application may use the <see cref="D3DSWAPEFFECT_DISCARD"/> swap effect to avoid these overheads
        /// and to enable the display driver to select the most efficient presentation technique for the swap chain.
        /// This is also the only swap effect that may be used when specifying a value other than <see cref="D3DMULTISAMPLE_NONE"/>
        /// for the <see cref="D3DPRESENT_PARAMETERS.MultiSampleType"/> member of <see cref="D3DPRESENT_PARAMETERS"/>.
        /// Like a swap chain that uses <see cref="D3DSWAPEFFECT_FLIP"/>,
        /// a swap chain that uses <see cref="D3DSWAPEFFECT_DISCARD"/> might include more than one back buffer,
        /// any of which may be accessed using <see cref="IDirect3DDevice9.GetBackBuffer"/> or <see cref="IDirect3DSwapChain9.GetBackBuffer"/>.
        /// The swap chain is best envisaged as a queue in which 0 always indexes the back buffer that will be displayed by the next Present operation
        /// and from which buffers are discarded when they have been displayed.
        /// An application that uses this swap effect cannot make any assumptions about the contents of a discarded back buffer
        /// and should therefore update an entire back buffer before invoking a Present operation that would display it.
        /// Although this is not enforced, the debug version of the runtime will overwrite the contents of discarded back buffers
        /// with random data to enable developers to verify that their applications are updating the entire back buffer surfaces correctly.
        /// </summary>
        D3DSWAPEFFECT_DISCARD = 1,

        /// <summary>
        /// The swap chain might include multiple back buffers and is best envisaged as a circular queue that includes the front buffer.
        /// Within this queue, the back buffers are always numbered sequentially from 0 to (n - 1),
        /// where n is the number of back buffers, so that 0 denotes the least recently presented buffer.
        /// When Present is invoked, the queue is "rotated" so that the front buffer becomes back buffer (n - 1),
        /// while the back buffer 0 becomes the new front buffer.
        /// </summary>
        D3DSWAPEFFECT_FLIP = 2,

        /// <summary>
        /// This swap effect may be specified only for a swap chain comprising a single back buffer.
        /// Whether the swap chain is windowed or full-screen, the runtime will guarantee the semantics implied by a copy-based Present operation,
        /// namely that the operation leaves the content of the back buffer unchanged,
        /// instead of replacing it with the content of the front buffer as a flip-based Present operation would.
        /// For a full-screen swap chain, the runtime uses a combination of flip operations and copy operations,
        /// supported if necessary by hidden back buffers, to accomplish the Present operation.
        /// Accordingly, the presentation is synchronized with the display adapter's vertical retrace
        /// and its rate is constrained by the chosen presentation interval.
        /// A swap chain specified with the <see cref="D3DPRESENT_INTERVAL_IMMEDIATE"/> flag is the only exception.
        /// (Refer to the description of the <see cref="D3DPRESENT_PARAMETERS.PresentationIntervals"/> member
        /// of the <see cref="D3DPRESENT_PARAMETERS"/> structure.)
        /// In this case, a Present operation copies the back buffer content directly to the front buffer without waiting for the vertical retrace.
        /// </summary>
        D3DSWAPEFFECT_COPY = 3,

        /// <summary>
        /// Use a dedicated area of video memory that can be overlayed on the primary surface.
        /// No copy is performed when the overlay is displayed.
        /// The overlay operation is performed in hardware, without modifying the data in the primary surface.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DSWAPEFFECT_OVERLAY"/> is only available in Direct3D9Ex running on Windows 7 (or more current operating system).
        /// </summary>
        D3DSWAPEFFECT_OVERLAY = 4,

        /// <summary>
        /// Designates when an application is adopting flip mode, during which time an application's frame is passed
        /// instead of copied to the Desktop Window Manager(DWM) for composition when the application is presenting in windowed mode.
        /// Flip mode allows an application to more efficiently use memory bandwidth as well as
        /// enabling an application to take advantage of full-screen-present statistics.
        /// Flip mode does not affect full-screen behavior.
        /// If you create a swap chain with <see cref="D3DSWAPEFFECT_FLIPEX"/>,
        /// you can't override the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member of the <see cref="D3DPRESENT_PARAMETERS"/> structure
        /// when you present a new frame for display.
        /// That is, you must pass <see cref="NULL"/> to the hDestWindowOverride parameter of <see cref="IDirect3DDevice9Ex.PresentEx"/> to instruct the runtime
        /// to use the <see cref="D3DPRESENT_PARAMETERS.hDeviceWindow"/> member of <see cref="D3DPRESENT_PARAMETERS"/> for the presentation.
        /// Differences between Direct3D 9 and Direct3D 9Ex:
        /// <see cref="D3DSWAPEFFECT_FLIPEX"/> is only available in Direct3D9Ex running on Windows 7 (or more current operating system).
        /// </summary>
        D3DSWAPEFFECT_FLIPEX = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits. This value is not used.
        /// </summary>
        D3DSWAPEFFECT_FORCE_DWORD = unchecked((int)0xFFFFFFFF),
    }
}
