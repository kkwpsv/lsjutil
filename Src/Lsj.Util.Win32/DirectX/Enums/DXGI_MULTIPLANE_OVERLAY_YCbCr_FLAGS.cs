using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Options for swap-chain color space.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_3/ne-dxgi1_3-dxgi_multiplane_overlay_ycbcr_flags"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by <see cref="IDXGIDecodeSwapChain.SetColorSpace"/>.
    /// </remarks>
    public enum DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAGS
    {
        /// <summary>
        /// Specifies nominal range YCbCr, which isn't an absolute color space, but a way of encoding RGB info.
        /// </summary>
        DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAG_NOMINAL_RANGE = 0x1,

        /// <summary>
        /// Specifies BT.709, which standardizes the format of high-definition television and has 16:9 (widescreen) aspect ratio.
        /// </summary>
        DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAG_BT709 = 0x2,

        /// <summary>
        /// Specifies xvYCC or extended-gamut YCC (also x.v.Color) color space
        /// that can be used in the video electronics of television sets to support a gamut 1.8 times as large as that of the sRGB color space.
        /// </summary>
        DXGI_MULTIPLANE_OVERLAY_YCbCr_FLAG_xvYCC = 0x4,
    }
}
