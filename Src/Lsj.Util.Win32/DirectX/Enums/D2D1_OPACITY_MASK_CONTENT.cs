using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Describes whether an opacity mask contains graphics or text. Direct2D uses this information to determine which gamma space to use when blending the opacity mask.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ne-d2d1-d2d1_opacity_mask_content"/>
    /// </para>
    /// </summary>
    public enum D2D1_OPACITY_MASK_CONTENT : uint
    {
        /// <summary>
        /// The opacity mask contains graphics.
        /// The opacity mask is blended in the gamma 2.2 color space.
        /// </summary>
        D2D1_OPACITY_MASK_CONTENT_GRAPHICS = 0,

        /// <summary>
        /// The opacity mask contains non-GDI text.
        /// The gamma space used for blending is obtained from the render target's text rendering parameters.
        /// (<see cref="ID2D1RenderTarget.SetTextRenderingParams"/>).
        /// </summary>
        D2D1_OPACITY_MASK_CONTENT_TEXT_NATURAL = 1,

        /// <summary>
        /// The opacity mask contains text rendered using the GDI-compatible rendering mode.
        /// The opacity mask is blended using the gamma for GDI rendering.
        /// </summary>
        D2D1_OPACITY_MASK_CONTENT_TEXT_GDI_COMPATIBLE = 2,

        /// <summary>
        /// 
        /// </summary>
        D2D1_OPACITY_MASK_CONTENT_FORCE_DWORD = 0xffffffff
    }
}
