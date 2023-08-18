using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.Enums.WindowStylesEx;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies resize behavior when the back-buffer size does not match the size of the target output.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/ne-dxgi1_2-dxgi_scaling"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The DXGI_SCALING_NONE value is supported only for flip presentation model swap chains
    /// that you create with the <see cref="DXGI_SWAP_EFFECT_FLIP_SEQUENTIAL"/> value.
    /// You pass these values in a call to <see cref="IDXGIFactory2.CreateSwapChainForHwnd"/>, <see cref="IDXGIFactory2.CreateSwapChainForCoreWindow"/>,
    /// or <see cref="IDXGIFactory2.CreateSwapChainForComposition"/>.
    /// <see cref="DXGI_SCALING_ASPECT_RATIO_STRETCH"/> will prefer to use a horizontal fill, otherwise it will use a vertical fill, using the following logic.
    /// <code>
    /// float aspectRatio = backBufferWidth / float(backBufferHeight);
    /// 
    /// // Horizontal fill
    /// float scaledWidth = outputWidth;
    /// float scaledHeight = outputWidth / aspectRatio;
    /// if (scaledHeight &gt;= outputHeight)
    /// {
    ///     // Do vertical fill
    ///     scaledWidth = outputHeight * aspectRatio;
    ///     scaledHeight = outputHeight;
    /// }
    /// 
    /// float offsetX = (outputWidth - scaledWidth) * 0.5f;
    /// float offsetY = (outputHeight - scaledHeight) * 0.5f;
    /// 
    /// rect.left = static_cast&lt;LONG&gt;(offsetX);
    /// rect.top = static_cast&lt;LONG&gt;(offsetY);
    /// rect.right = static_cast&lt;LONG&gt;(offsetX + scaledWidth);
    /// rect.bottom = static_cast&lt;LONG&gt;(offsetY + scaledHeight);
    /// 
    /// rect.left = std::max&lt;LONG&gt;(0, rect.left);
    /// rect.top = std::max&lt;LONG&gt;(0, rect.top);
    /// rect.right = std::min&lt;LONG&gt;(static_cast&lt;LONG&gt;(outputWidth), rect.right);
    /// rect.bottom = std::min&lt;LONG&gt;(static_cast&lt;LONG&gt;(outputHeight), rect.bottom);
    /// </code>
    /// Note that outputWidth and outputHeight are the pixel sizes of the presentation target size.
    /// In the case of CoreWindow, this requires converting the logicalWidth and logicalHeight values from DIPS to pixels using the window's DPI property.
    /// </remarks>
    public enum DXGI_SCALING
    {
        /// <summary>
        /// Directs DXGI to make the back-buffer contents scale to fit the presentation target size.
        /// This is the implicit behavior of DXGI when you call the <see cref="IDXGIFactory.CreateSwapChain"/> method.
        /// </summary>
        DXGI_SCALING_STRETCH = 0,

        /// <summary>
        /// Directs DXGI to make the back-buffer contents appear without any scaling when the presentation target size is not equal to the back-buffer size.
        /// The top edges of the back buffer and presentation target are aligned together.
        /// If the <see cref="WS_EX_LAYOUTRTL"/> style is associated with the HWND handle to the target output window,
        /// the right edges of the back buffer and presentation target are aligned together; otherwise, the left edges are aligned together.
        /// All target area outside the back buffer is filled with window background color.
        /// This value specifies that all target areas outside the back buffer of a swap chain are filled with the background color
        /// that you specify in a call to <see cref="IDXGISwapChain1.SetBackgroundColor"/>.
        /// </summary>
        DXGI_SCALING_NONE = 1,

        /// <summary>
        /// Directs DXGI to make the back-buffer contents scale to fit the presentation target size, while preserving the aspect ratio of the back-buffer.
        /// If the scaled back-buffer does not fill the presentation area, it will be centered with black borders.
        /// This constant is supported on Windows Phone 8 and Windows 10.
        /// Note that with legacy Win32 window swapchains, this works the same as <see cref="DXGI_SCALING_STRETCH"/>.
        /// </summary>
        DXGI_SCALING_ASPECT_RATIO_STRETCH = 2
    }
}
