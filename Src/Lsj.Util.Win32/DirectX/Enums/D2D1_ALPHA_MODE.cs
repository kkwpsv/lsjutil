using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D2D1_TEXT_ANTIALIAS_MODE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how the alpha value of a bitmap or render target should be treated.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dcommon/ne-dcommon-d2d1_alpha_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="D2D1_ALPHA_MODE"/> enumeration is used with the <see cref="D2D1_PIXEL_FORMAT"/> enumeration
    /// to specify the alpha mode of a render target or bitmap.
    /// Different render targets and bitmaps support different alpha modes.
    /// For a list, see Supported Pixel Formats and Alpha Modes.
    /// </para>
    /// <para>
    /// The Differences Between Straight and Premultiplied Alpha
    /// </para>
    /// <para>
    /// When describing an RGBA color using straight alpha, the alpha value of the color is stored in the alpha channel.
    /// For example, to describe a red color that is 60% opaque, you'd use the following values:
    /// (255, 0, 0, 255 * 0.6) = (255, 0, 0, 153).
    /// The 255 value indicates full red, and 153 (which is 60 percent of 255) indicates
    /// that the color should have an opacity of 60 percent.
    /// </para>
    /// <para>
    /// When describing an RGBA color using premultiplied alpha, each color is multiplied by the alpha value:
    /// (255 * 0.6, 0 * 0.6, 0 * 0.6, 255 * 0.6) = (153, 0, 0, 153).
    /// </para>
    /// <para>
    /// Regardless of the alpha mode of the render target, <see cref="D2D1_COLOR_F"/> values are always interpreted as straight alpha.
    /// For example, when specifying the color of an <see cref="ID2D1SolidColorBrush"/>
    /// for use with a bitmap that uses the premultiplied alpha mode,
    /// you'd specify the color just as you would if the bitmap used straight alpha.
    /// When you paint with the brush, Direct2D translates the color to the destination format for you.
    /// </para>
    /// <para>
    /// Alpha Mode for Render Targets
    /// </para>
    /// <para>
    /// Regardless of the alpha mode setting, a render target's contents support transparency.
    /// For example, if you draw a partially transparent red rectangle with a render target
    /// with an alpha mode of <see cref="D2D1_ALPHA_MODE_IGNORE"/>,
    /// the rectangle will appear pink (if the background is white), as you might expect.
    /// </para>
    /// <para>
    /// If you draw a partially transparent red rectangle
    /// when the alpha mode is <see cref="ID2D1RenderTarget.CreateCompatibleRenderTarget"/> method)
    /// to create a bitmap that supports transparency.
    /// </para>
    /// <para>
    /// ClearType and Alpha Modes
    /// </para>
    /// <para>
    /// If you specify an alpha mode other than <see cref="D2D1_ALPHA_MODE_IGNORE"/> for a render target,
    /// the text antialiasing mode automatically changes from <see cref="D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE"/>
    /// to <see cref="D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE "/>.
    /// (When you specify an alpha mode of <see cref="D2D1_ALPHA_MODE_UNKNOWN"/>,
    /// Direct2D sets the alpha for you depending on the type of render target.
    /// For a list of what the <see cref="D2D1_ALPHA_MODE_UNKNOWN"/> setting resolves to for each render target,
    /// see the Supported Pixel Formats and Alpha Modes overview.)
    /// </para>
    /// <para>
    /// You can use the <see cref="ID2D1RenderTarget.SetTextAntialiasMode"/> method to change the text antialias mode
    /// back to <see cref="D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE"/>,
    /// but rendering ClearType text to a transparent surface can create unpredictable results.
    /// If you want to render ClearType text to a transparent render target,
    /// we recommend that you use one of the following two techniques.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Use the <see cref="ID2D1RenderTarget.PushAxisAlignedClip"/> method
    /// to clip the render target to the area where the text will be rendered,
    /// then call the <see cref="ID2D1RenderTarget.Clear"/> method and specify an opaque color, then render your text.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Use <see cref="ID2D1RenderTarget.DrawRectangle"/> to draw an opaque rectangle behind the area where the text will be rendered.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D2D1_ALPHA_MODE : uint
    {
        /// <summary>
        /// The alpha value might not be meaningful.
        /// </summary>
        D2D1_ALPHA_MODE_UNKNOWN = 0,

        /// <summary>
        /// The alpha value has been premultiplied. Each color is first scaled by the alpha value.
        /// The alpha value itself is the same in both straight and premultiplied alpha.
        /// Typically, no color channel value is greater than the alpha channel value.
        /// If a color channel value in a premultiplied format is greater than the alpha channel,
        /// the standard source-over blending math results in an additive blend.
        /// </summary>
        D2D1_ALPHA_MODE_PREMULTIPLIED = 1,

        /// <summary>
        /// The alpha value has not been premultiplied.
        /// The alpha channel indicates the transparency of the color.
        /// </summary>
        D2D1_ALPHA_MODE_STRAIGHT = 2,

        /// <summary>
        /// The alpha value is ignored.
        /// </summary>
        D2D1_ALPHA_MODE_IGNORE = 3,

        /// <summary>
        /// 
        /// </summary>
        D2D1_ALPHA_MODE_FORCE_DWORD = 0xffffffff
    }
}
