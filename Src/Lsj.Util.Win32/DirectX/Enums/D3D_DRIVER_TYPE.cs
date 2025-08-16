using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.D3D11;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver type options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_driver_type"/>
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// For programming with Direct3D 10, this API has a type alias that begins <c>D3D10_</c> instead of <c>D3D_</c>.
    /// These Direct3D 10 type aliases are defined in <c>d3d10.h</c>, <c>d3d10misc.h</c>, and <c>d3d10shader.h</c>.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The driver type is required when calling <see cref="D3D11CreateDevice"/> or <see cref="D3D11CreateDeviceAndSwapChain"/>.
    /// </remarks>
    public enum D3D_DRIVER_TYPE
    {
        /// <summary>
        /// The driver type is unknown.
        /// </summary>
        D3D_DRIVER_TYPE_UNKNOWN = 0,

        /// <summary>
        /// A hardware driver, which implements Direct3D features in hardware.
        /// This is the primary driver that you should use in your Direct3D applications because it provides the best performance.
        /// A hardware driver uses hardware acceleration (on supported hardware)
        /// but can also use software for parts of the pipeline that are not supported in hardware.
        /// This driver type is often referred to as a hardware abstraction layer or HAL.
        /// </summary>
        D3D_DRIVER_TYPE_HARDWARE,

        /// <summary>
        /// <para>
        /// A reference driver, which is a software implementation that supports every Direct3D feature.
        /// A reference driver is designed for accuracy rather than speed and as a result is slow but accurate.
        /// The rasterizer portion of the driver does make use of special CPU instructions whenever it can,
        /// but it is not intended for retail applications;
        /// use it only for feature testing, demonstration of functionality, debugging, or verifying bugs in other drivers.
        /// The reference device for this driver is installed by the Windows SDK 8.0 or later
        /// and is intended only as a debug aid for development purposes.
        /// This driver may be referred to as a REF driver, a reference driver, or a reference rasterizer.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// When you use the REF driver in Windows Store apps, the REF driver renders correctly but doesn't display any output on the screen.
        /// To verify bugs in hardware drivers for Windows Store apps, use <see cref="D3D_DRIVER_TYPE_WARP"/> for the WARP driver instead.
        /// </para>
        /// </summary>
        D3D_DRIVER_TYPE_REFERENCE,

        /// <summary>
        /// A NULL driver, which is a reference driver without render capability.
        /// This driver is commonly used for debugging non-rendering API calls, it is not appropriate for retail applications.
        /// This driver is installed by the DirectX SDK.
        /// </summary>
        D3D_DRIVER_TYPE_NULL,

        /// <summary>
        /// A software driver, which is a driver implemented completely in software.
        /// The software implementation is not intended for a high-performance application due to its very slow performance.
        /// </summary>
        D3D_DRIVER_TYPE_SOFTWARE,

        /// <summary>
        /// <para>
        /// A WARP driver, which is a high-performance software rasterizer.
        /// The rasterizer supports feature levels 9_1 through level 10_1 with a high performance software implementation.
        /// For information about limitations creating a WARP device on certain feature levels,
        /// see Limitations Creating WARP and Reference Devices.
        /// For more information about using a WARP driver, see Windows Advanced Rasterization Platform (WARP) In-Depth Guide.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The WARP driver that Windows 8 includes supports feature levels 9_1 through level 11_1.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The WARP driver that Windows 8.1 includes fully supports feature level 11_1, including tiled resources,
        /// <see cref="IDXGIDevice3.Trim"/>, shared BCn surfaces, minblend, and map default.
        /// </para>
        /// </summary>
        D3D_DRIVER_TYPE_WARP,
    }
}
