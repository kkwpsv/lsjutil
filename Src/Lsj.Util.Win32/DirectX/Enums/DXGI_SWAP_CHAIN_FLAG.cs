using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_SWAP_EFFECT;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Options for swap-chain behavior.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/ne-dxgi-dxgi_swap_chain_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enumeration is used by the <see cref="DXGI_SWAP_CHAIN_DESC"/> structure and the <see cref="IDXGISwapChain.ResizeTarget"/> method.
    /// </para>
    /// <para>
    /// This enumeration is also used by the <see cref="DXGI_SWAP_CHAIN_DESC1"/> structure.
    /// </para>
    /// <para>
    /// You don't need to set <see cref="DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY"/> for swap chains
    /// that you create in full-screen mode with the <see cref="IDXGIFactory.CreateSwapChain"/> method
    /// because those swap chains already behave as if <see cref="DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY"/> is set.
    /// That is, presented content is not accessible by remote access or through the desktop duplication APIs.
    /// </para>
    /// <para>
    /// Swap chains that you create with the <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>,
    /// <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>, and <see cref="IDXGIFactory2.CreateSwapChainForComposition"/> methods
    /// are not protected if <see cref="DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY"/> is not set
    /// and are protected if <see cref="DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY"/> is set.
    /// When swap chains are protected, screen scraping is prevented and, 
    /// in full-screen mode, presented content is not accessible through the desktop duplication APIs.
    /// </para>
    /// <para>
    /// When you call <see cref="IDXGISwapChain.ResizeBuffers"/> to change the swap chain's back buffer,
    /// you can reset or change all <see cref="DXGI_SWAP_CHAIN_FLAG"/> flags.
    /// </para>
    /// </remarks>
    [Flags]
    public enum DXGI_SWAP_CHAIN_FLAG
    {
        /// <summary>
        /// <para>
        /// Set this flag to turn off automatic image rotation;
        /// that is, do not perform a rotation when transferring the contents of the front buffer to the monitor.
        /// </para>
        /// <para>
        /// Use this flag to avoid a bandwidth penalty when an application expects to handle rotation.
        /// This option is valid only during full-screen mode.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_NONPREROTATED = 1,

        /// <summary>
        /// <para>
        /// Set this flag to enable an application to switch modes by calling <see cref="IDXGISwapChain.ResizeTarget"/>.
        /// </para>
        /// <para>
        /// When switching from windowed to full-screen mode,
        /// the display mode (or monitor resolution) will be changed to match the dimensions of the application window.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_ALLOW_MODE_SWITCH = 2,

        /// <summary>
        /// <para>
        /// Set this flag to enable an application to render using GDI on a swap chain or a surface.
        /// </para>
        /// <para>
        /// This will allow the application to call <see cref="IDXGISurface1.GetDC"/> on the 0th back buffer or a surface.
        /// </para>
        /// <para>
        /// This flag is not applicable for Direct3D 12.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_GDI_COMPATIBLE = 4,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that the swap chain might contain protected content;
        /// therefore, the operating system supports the creation of the swap chain only when driver and hardware protection is used.
        /// If the driver and hardware do not support content protection, the call to create a resource for the swap chain fails.
        /// </para>
        /// <para>
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_RESTRICTED_CONTENT = 8,

        /// <summary>
        /// <para>
        /// Set this flag to indicate that shared resources that are created within the swap chain must be protected
        /// by using the driver’s mechanism for restricting access to shared surfaces.
        /// </para>
        /// <para>
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_RESTRICT_SHARED_RESOURCE_DRIVER = 16,

        /// <summary>
        /// <para>
        /// Set this flag to restrict presented content to the local displays.
        /// Therefore, the presented content is not accessible via remote accessing or through the desktop duplication APIs.
        /// </para>
        /// <para>
        /// This flag supports the window content protection features of Windows.
        /// Applications can use this flag to protect their own onscreen window content
        /// from being captured or copied through a specific set of public operating system features and APIs.
        /// </para>
        /// <para>
        /// If you use this flag with windowed (<see cref="HWND"/> or IWindow) swap chains where another process created the <see cref="HWND"/>,
        /// the owner of the <see cref="HWND"/> must use the <see cref="SetWindowDisplayAffinity"/> function appropriately
        /// in order to allow calls to <see cref="IDXGISwapChain.Present"/> or <see cref="IDXGISwapChain1.Present1"/> to succeed.
        /// </para>
        /// <para>
        /// Direct3D 11: This enumeration value is supported starting with Windows 8.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_DISPLAY_ONLY = 32,

        /// <summary>
        /// <para>
        /// Set this flag to create a waitable object you can use to ensure rendering does not begin while a frame is still being presented.
        /// When this flag is used, the swapchain's latency must be set
        /// with the <see cref="IDXGISwapChain2.SetMaximumFrameLatency"/> API instead of <see cref="IDXGIDevice1.SetMaximumFrameLatency"/>.
        /// </para>
        /// <para>
        /// This flag isn't supported in full-screen mode, unless the render API is Direct3D 12.
        /// </para>
        /// <para>
        /// Note This enumeration value is supported starting with Windows 8.1.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_FRAME_LATENCY_WAITABLE_OBJECT = 64,

        /// <summary>
        /// <para>
        /// Set this flag to create a swap chain in the foreground layer for multi-plane rendering.
        /// This flag can only be used with CoreWindow swap chains, which are created with <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>.
        /// Apps should not create foreground swap chains
        /// if <see cref="IDXGIOutput2.SupportsOverlays"/> indicates that hardware support for overlays is not available.
        /// </para>
        /// <para>
        /// Note that <see cref="IDXGISwapChain.ResizeBuffers"/> cannot be used to add or remove this flag.
        /// </para>
        /// <para>
        /// Note  This enumeration value is supported starting with Windows 8.1.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_FOREGROUND_LAYER = 128,

        /// <summary>
        /// <para>
        /// Set this flag to create a swap chain for full-screen video.
        /// </para>
        /// <para>
        /// Note This enumeration value is supported starting with Windows 8.1.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_FULLSCREEN_VIDEO = 256,

        /// <summary>
        /// <para>
        /// Set this flag to create a swap chain for YUV video.
        /// </para>
        /// <para>
        /// Note This enumeration value is supported starting with Windows 8.1.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_YUV_VIDEO = 512,

        /// <summary>
        /// <para>
        /// Indicates that the swap chain should be created such that all underlying resources can be protected by the hardware.
        /// Resource creation will fail if hardware content protection is not supported.
        /// </para>
        /// <para>
        /// This flag has the following restrictions:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This flag can only be used with swap effect <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Creating a swap chain using this flag does not automatically guarantee
        /// that hardware protection will be enabled for the underlying allocation.
        /// Some implementations require that the DRM components are first initialized prior to any guarantees of protection.
        /// </para>
        /// <para>
        /// Note This enumeration value is supported starting with Windows 10.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_HW_PROTECTED = 1024,

        /// <summary>
        /// <para>
        /// Tearing support is a requirement to enable displays that support variable refresh rates to function properly
        /// when the application presents a swap chain tied to a full screen borderless window.
        /// Win32 apps can already achieve tearing in fullscreen exclusive mode by calling <c>SetFullscreenState(TRUE)</c>,
        /// but the recommended approach for Win32 developers is to use this tearing flag instead.
        /// This flag requires the use of a DXGI_SWAP_EFFECT_FLIP_* swap effect.
        /// </para>
        /// <para>
        /// To check for hardware support of this feature, refer to <see cref="IDXGIFactory5.CheckFeatureSupport"/>.
        /// For usage information refer to <see cref="IDXGISwapChain.Present"/> and the <see cref="DXGI_PRESENT"/> flags.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// <see cref="IDXGISwapChain.ResizeBuffers"/> can't be used to add or remove this flag.
        /// </para>
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_ALLOW_TEARING = 2048,

        /// <summary>
        /// 
        /// </summary>
        DXGI_SWAP_CHAIN_FLAG_RESTRICTED_TO_ALL_HOLOGRAPHIC_DISPLAYS = 4096,
    }
}
