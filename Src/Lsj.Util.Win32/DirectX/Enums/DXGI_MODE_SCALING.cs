using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags indicating how an image is stretched to fit a given monitor's resolution.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173066(v=vs.85)"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Selecting the CENTERED or STRETCHED modes can result in a mode change even if you specify the native resolution of the display in the <see cref="DXGI_MODE_DESC"/>.
    /// If you know the native resolution of the display and want to make sure that you do not initiate a mode change when transitioning a swap chain to full screen
    /// (either via ALT+ENTER or <see cref="IDXGISwapChain.SetFullscreenState"/>), you should use UNSPECIFIED.
    /// This enum is used by the <see cref="DXGI_MODE_DESC1"/> and <see cref="DXGI_SWAP_CHAIN_FULLSCREEN_DESC"/> structures.
    /// </remarks>
    public enum DXGI_MODE_SCALING
    {
        /// <summary>
        /// Unspecified scaling.
        /// </summary>
        DXGI_MODE_SCALING_UNSPECIFIED = 0,

        /// <summary>
        /// Specifies no scaling.
        /// The image is centered on the display.
        /// This flag is typically used for a fixed-dot-pitch display (such as an LED display).
        /// </summary>
        DXGI_MODE_SCALING_CENTERED = 1,

        /// <summary>
        /// Specifies stretched scaling.
        /// </summary>
        DXGI_MODE_SCALING_STRETCHED = 2,
    }
}
