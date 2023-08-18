using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a range of hardware features, to be used when checking for feature support.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_5/ne-dxgi1_5-dxgi_feature"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="IDXGIFactory5.CheckFeatureSupport"/> method.
    /// </remarks>
    public enum DXGI_FEATURE
    {
        /// <summary>
        /// The display supports tearing, a requirement of variable refresh rate displays.
        /// </summary>
        DXGI_FEATURE_PRESENT_ALLOW_TEARING = 0,
    }
}
