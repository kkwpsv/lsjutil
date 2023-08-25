using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies overlay support to check for in a call to <see cref="IDXGIOutput3.CheckOverlaySupport"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ne-dxgi1_3-dxgi_overlay_support_flag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Priority determines how likely the operating system is to discard an offered resource.
    /// Resources offered with lower priority are discarded first.
    /// </remarks>
    public enum DXGI_OVERLAY_SUPPORT_FLAG
    {
        /// <summary>
        /// Direct overlay support.
        /// </summary>
        DXGI_OVERLAY_SUPPORT_FLAG_DIRECT = 0x1,

        /// <summary>
        /// Scaling overlay support.
        /// </summary>
        DXGI_OVERLAY_SUPPORT_FLAG_SCALING = 0x2,
    }
}
