using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_CHAIN_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// The <see cref="DXGI_PRESENT"/> constants specify options for presenting frames to the output.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-present"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Presentation options are supplied during the <see cref="IDXGISwapChain.Present"/> or <see cref="IDXGISwapChain1.Present1"/> call.
    /// The buffers are specified in the swap chain description (see <see cref="DXGI_SWAP_CHAIN_DESC"/> or <see cref="DXGI_SWAP_CHAIN_DESC1"/>).
    /// <see cref="DXGI_PRESENT_RESTART"/> is valid only for flip-model swap chains and full screen.
    /// Applications can use <see cref="DXGI_PRESENT_RESTART"/> to recover from glitches in playback, as well as to discard previously queued presentations.
    /// Discarding previously queued presentations is useful if those queued presentations are windowed scenarios.
    /// In particular, the previously queued presentation might have assumed that the window is an old size (that is, a resize operation occurred after submission).
    /// <see cref="DXGI_PRESENT_RESTRICT_TO_OUTPUT"/> is valid only for swap chains that specified a particular output
    /// to restrict content to when those swap chains were created (<see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>).
    /// If there is no output to restrict to, the flag is invalid.
    /// <see cref="DXGI_PRESENT_STEREO_PREFER_RIGHT"/> indicates that if the stereo present must be reduced to mono the right eye should be used rather than the left (default) eye.
    /// You can use this flag if one side is higher quality (for example, if the stereo pair is synthesized from a standard image.)
    /// <see cref="DXGI_PRESENT_STEREO_TEMPORARY_MONO"/> indicates that the present should use the left buffer as a mono buffer.
    /// You can use this flag to avoid updating the right buffer when an application temporarily has no stereo content.
    /// You should use this flag whenever possible because it enables significant optimization by the operating system
    /// and under some circumstances it can avoid visible mode change artifacts.
    /// You should use the <see cref="DXGI_PRESENT_STEREO_TEMPORARY_MONO"/> flag in preference
    /// to switching to a mono swap chain for most applications that you anticipate will use stereo again.
    /// You need to balance the use of this flag in applications that are extremely long running or that rarely display stereo against the disadvantage of unused memory.
    /// Note
    /// Full-screen applications that switch to a mono swap chain cause a mode change that generally has visible artifacts (for example, "flashing”).
    /// However, temporary mono might not be supported for full-screen swap chains.
    /// The <see cref="DXGI_PRESENT_STEREO_PREFER_RIGHT"/> and <see cref="DXGI_PRESENT_STEREO_TEMPORARY_MONO"/> flags apply only to stereo swap chains.
    /// If you use them when you present mono swap chains, an invalid operation occurs.
    /// If you use the <see cref="DXGI_PRESENT_STEREO_TEMPORARY_MONO"/> flag when you present a stereo swap chain that does not support temporary mono,
    /// an error occurs, the swap chain does not display, and the presentation returns <see cref="DXGI_ERROR_INVALID_CALL"/>.
    /// </remarks>
    [Flags]
    public enum DXGI_PRESENT : uint
    {
        /// <summary>
        /// Present a frame from the current buffer to the output.
        /// Use this flag so that the presentation can use vertical-blank synchronization instead of sequencing buffers in the chain in the usual manner.
        /// Note: 
        /// If the calling application sets the <see cref="DXGI_PRESENT_DO_NOT_SEQUENCE"/> constant on the first present operation (that is, when there is no current buffer),
        /// the runtime ignores that present operation and does not call the driver.
        /// </summary>
        DXGI_PRESENT_DO_NOT_SEQUENCE = 0x00000002,

        /// <summary>
        /// Do not present the frame to the output.
        /// The status of the swap chain will be tested and appropriate errors returned.
        /// <see cref="DXGI_PRESENT_TEST"/> is intended for use only when switching from the idle state;
        /// do not use it to determine when to switch to the idle state because doing so can leave the swap chain unable to exit full-screen mode.
        /// </summary>
        DXGI_PRESENT_TEST = 0x00000001,

        /// <summary>
        /// Specifies that the runtime will discard outstanding queued presents.
        /// </summary>
        DXGI_PRESENT_RESTART = 0x00000004,

        /// <summary>
        /// Specifies that the runtime will fail the presentation (that is, fail a call to <see cref="IDXGISwapChain1.Present1"/>)
        /// with the <see cref="DXGI_ERROR_WAS_STILL_DRAWING"/> error code if the calling thread is blocked;
        /// the runtime returns <see cref="DXGI_ERROR_WAS_STILL_DRAWING"/> instead of sleeping until the dependency is resolved.
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_PRESENT_DO_NOT_WAIT = 0x00000008,

        /// <summary>
        /// Indicates that presentation content will be shown only on the particular output.
        /// The content will not be visible on other outputs.
        /// For example, if the user tries to relocate video content on another output, the video content will not be visible.
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// Note: This flag should only be used with swap effect <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> or <see cref="DXGI_SWAP_EFFECT_FLIP_DISCARD"/>.
        /// The use of this flag with other swap effects is being deprecated, and may not work in future versions of Windows.
        /// </summary>
        DXGI_PRESENT_RESTRICT_TO_OUTPUT = 0x00000010,

        /// <summary>
        /// Indicates that if the stereo present must be reduced to mono, right-eye viewing is used rather than left-eye viewing.
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_PRESENT_STEREO_PREFER_RIGHT = 0x00000020,

        /// <summary>
        /// Indicates that the presentation should use the left buffer as a mono buffer.
        /// An application calls the <see cref="IDXGISwapChain1.IsTemporaryMonoSupported"/> method to determine whether a swap chain supports "temporary mono".
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </summary>
        DXGI_PRESENT_STEREO_TEMPORARY_MONO = 0x00000040,

        /// <summary>
        /// This flag must be set by media apps that are currently using a custom present duration(custom refresh rate).
        /// See <see cref="IDXGISwapChainMedia"/>.
        /// Note: This value is supported starting in Windows 8.1.
        /// </summary>
        DXGI_PRESENT_USE_DURATION = 0x00000100,

        /// <summary>
        /// Allowing tearing is a requirement of variable refresh rate displays.
        /// The conditions for using <see cref="DXGI_PRESENT_ALLOW_TEARING"/> during Present are as follows:
        /// The swap chain must be created with the <see cref="DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING"/> flag.
        /// The sync interval passed in to <see cref="IDXGISwapChain.Present"/> (or <see cref="IDXGISwapChain1.Present1"/>) must be 0.
        /// The <see cref="DXGI_PRESENT_ALLOW_TEARING"/> flag cannot be used in an application
        /// that is currently in full screen exclusive mode (set by calling <code>SetFullscreenState(TRUE)</code>).
        /// It can only be used in windowed mode.
        /// To use this flag in full screen Win32 apps, the application should present to a fullscreen borderless window
        /// and disable automatic ALT+ENTER fullscreen switching using <see cref="IDXGIFactory.MakeWindowAssociation"/>.
        /// UWP apps that enter fullscreen mode by calling Windows::UI::ViewManagement::ApplicationView::TryEnterFullscreen() are fullscreen borderless windows and may use the flag.
        /// Calling <see cref="IDXGISwapChain.Present"/> (or <see cref="IDXGISwapChain1.Present1"/>) with this flag
        /// and not meeting the conditions above will result in a <see cref="DXGI_ERROR_INVALID_CALL"/> error being returned to the calling application.
        /// </summary>
        DXGI_PRESENT_ALLOW_TEARING = 0x00000200,
    }
}
