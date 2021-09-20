using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.DrawTextFormatFlags;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// UxTheme.dll
    /// </summary>
    public static class UxTheme
    {
        /// <summary>
        /// <para>
        /// Draws text using the color and font defined by the visual style.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/uxtheme/nf-uxtheme-drawthemetext"/>
        /// </para>
        /// </summary>
        /// <param name="hTheme">
        /// Handle to a window's theme data.
        /// Use <see cref="OpenThemeData"/> to create an <see cref="HTHEME"/>.
        /// </param>
        /// <param name="hdc">
        /// HDC to use for drawing.
        /// </param>
        /// <param name="iPartId">
        /// The control part that has the desired text appearance.
        /// See Parts and States.
        /// If this value is 0, the text is drawn in the default font, or a font selected into the device context.
        /// </param>
        /// <param name="iStateId">
        /// The control state that has the desired text appearance.
        /// See Parts and States.
        /// </param>
        /// <param name="pszText">
        /// Pointer to a string that contains the text to draw.
        /// </param>
        /// <param name="cchText">
        /// Value of type int that contains the number of characters to draw.
        /// If the parameter is set to -1, all the characters in the string are drawn.
        /// </param>
        /// <param name="dwTextFlags">
        /// DWORD that contains one or more values that specify the string's formatting.
        /// See Format Values for possible parameter values.
        /// Note
        /// <see cref="DrawThemeText"/> does not support <see cref="DT_CALCRECT"/>.
        /// However, <see cref="DrawThemeTextEx"/> does support <see cref="DT_CALCRECT"/>.
        /// </param>
        /// <param name="dwTextFlags2">
        /// Not used. Set to zero.
        /// </param>
        /// <param name="pRect">
        /// Pointer to a <see cref="RECT"/> structure that contains the rectangle, in logical coordinates, in which the text is to be drawn.
        /// It is recommended to use pExtentRect from <see cref="GetThemeTextExtent"/> to retrieve the correct coordinates.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The function always uses the themed font for the specified part and state if one is defined.
        /// Otherwise it uses the font currently selected into the device context.
        /// To find out if a themed font is defined, you can call <see cref="GetThemeFont"/>
        /// or <see cref="GetThemePropertyOrigin"/>with <see cref="TMT_FONT"/> as the property identifier.
        /// </remarks>
        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode, EntryPoint = "DrawThemeText", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT DrawThemeText([In] HTHEME hTheme, [In] HDC hdc, [In] int iPartId, [In] int iStateId, [In] LPCWSTR pszText,
            [In] int cchText, [In] DrawTextFormatFlags dwTextFlags, [In] DWORD dwTextFlags2, [In] in RECT pRect);
    }
}
