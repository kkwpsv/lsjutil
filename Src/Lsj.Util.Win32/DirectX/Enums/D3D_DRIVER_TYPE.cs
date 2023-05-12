namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver type options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3dcommon/ne-d3dcommon-d3d_driver_type"/>
    /// </para>
    /// </summary>
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
        /// A reference driver, which is a software implementation that supports every Direct3D feature.
        /// A reference driver is designed for accuracy rather than speed and as a result is slow but accurate.
        /// The rasterizer portion of the driver does make use of special CPU instructions whenever it can,
        /// but it is not intended for retail applications; use it only for feature testing,
        /// demonstration of functionality, debugging, or verifying bugs in other drivers.
        /// The reference device for this driver is installed by the Windows SDK 8.0 or later and is intended only as a debug aid for development purposes.
        /// This driver may be referred to as a REF driver, a reference driver, or a reference rasterizer.
        /// Note  When you use the REF driver in Windows Store apps, the REF driver renders correctly but doesn't display any output on the screen. To verify bugs in hardware drivers for Windows Store apps, use D3D_DRIVER_TYPE_WARP for the WARP driver instead.
        /// </summary>
        D3D_DRIVER_TYPE_REFERENCE,

        /// <summary>
        /// 
        /// </summary>
        D3D_DRIVER_TYPE_NULL,
        D3D_DRIVER_TYPE_SOFTWARE,
        D3D_DRIVER_TYPE_WARP
    }
}
