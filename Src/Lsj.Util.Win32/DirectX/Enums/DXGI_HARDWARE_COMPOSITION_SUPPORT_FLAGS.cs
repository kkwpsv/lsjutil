using Lsj.Util.Win32.DirectX.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes which levels of hardware composition are supported.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/ne-dxgi1_6-dxgi_hardware_composition_support_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Values of this enumeration are returned from the <see cref="IDXGIOutput6.CheckHardwareCompositionSupport"/> method in the pFlags out parameter.
    /// </remarks>
    [Flags]
    public enum DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS
    {
        /// <summary>
        /// This flag specifies that swapchain composition can be facilitated in a performant manner using hardware for fullscreen applications.
        /// </summary>
        DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_FULLSCREEN = 1,

        /// <summary>
        /// This flag specifies that swapchain composition can be facilitated in a performant manner using hardware for windowed applications.
        /// </summary>
        DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_WINDOWED = 2,

        /// <summary>
        /// This flag specifies that swapchain composition facilitated using hardware can cause the cursor to appear stretched.
        /// </summary>
        DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAG_CURSOR_STRETCHED = 4
    }
}
