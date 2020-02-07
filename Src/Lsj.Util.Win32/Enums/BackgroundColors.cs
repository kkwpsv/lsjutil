using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// BackgroundColors For <see cref="WNDCLASSEX"/>
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-tagwndclassexw
    /// </para>
    /// </summary>
    public enum BackgroundColors
    {
        /// <summary>
        /// Active window border.
        /// </summary>
        COLOR_ACTIVEBORDER = SystemColors.COLOR_ACTIVEBORDER + 1,

        /// <summary>
        /// Active window title bar.
        /// The associated foreground color is <see cref="COLOR_CAPTIONTEXT"/>.
        /// Specifies the left side color in the color gradient of an active window's title bar if the gradient effect is enabled.
        /// </summary>
        COLOR_ACTIVECAPTION = SystemColors.COLOR_ACTIVECAPTION + 1,

        /// <summary>
        /// Background color of multiple document interface (MDI) applications.
        /// </summary>
        COLOR_APPWORKSPACE = SystemColors.COLOR_APPWORKSPACE + 1,

        /// <summary>
        /// Desktop.
        /// </summary>
        COLOR_BACKGROUND = SystemColors.COLOR_BACKGROUND + 1,

        /// <summary>
        /// Face color for three-dimensional display elements and for dialog box backgrounds.
        /// The associated foreground color is <see cref="COLOR_BTNTEXT"/>.
        /// </summary>
        COLOR_BTNFACE = SystemColors.COLOR_BTNFACE + 1,

        /// <summary>
        /// Shadow color for three-dimensional display elements (for edges facing away from the light source).
        /// </summary>
        COLOR_BTNSHADOW = SystemColors.COLOR_BTNSHADOW + 1,

        /// <summary>
        /// Text on push buttons.
        /// The associated background color is <see cref="COLOR_BTNFACE"/>.
        /// </summary>
        COLOR_BTNTEXT = SystemColors.COLOR_BTNTEXT + 1,

        /// <summary>
        /// Text in caption, size box, and scroll bar arrow box.
        /// The associated background color is <see cref="COLOR_ACTIVECAPTION"/>.
        /// </summary>
        COLOR_CAPTIONTEXT = SystemColors.COLOR_CAPTIONTEXT + 1,

        /// <summary>
        /// Grayed (disabled) text.
        /// This color is set to 0 if the current display driver does not support a solid gray color.
        /// </summary>
        COLOR_GRAYTEXT = SystemColors.COLOR_GRAYTEXT + 1,

        /// <summary>
        /// Item(s) selected in a control. The associated foreground color is <see cref="COLOR_HIGHLIGHTTEXT"/>.
        /// </summary>
        COLOR_HIGHLIGHT = SystemColors.COLOR_HIGHLIGHT + 1,

        /// <summary>
        /// Text of item(s) selected in a control. The associated background color is <see cref="COLOR_HIGHLIGHT"/>.
        /// </summary>
        COLOR_HIGHLIGHTTEXT = SystemColors.COLOR_HIGHLIGHTTEXT + 1,

        /// <summary>
        /// Inactive window border.
        /// </summary>
        COLOR_INACTIVEBORDER = SystemColors.COLOR_INACTIVEBORDER + 1,

        /// <summary>
        /// Inactive window caption. The associated foreground color is <see cref="COLOR_INACTIVECAPTIONTEXT"/>".
        /// Specifies the left side color in the color gradient of an inactive window's title bar if the gradient effect is enabled.
        /// </summary>
        COLOR_INACTIVECAPTION = SystemColors.COLOR_INACTIVECAPTION + 1,

        /// <summary>
        /// Menu background. The associated foreground color is <see cref="COLOR_MENUTEXT"/>.
        /// </summary>
        COLOR_MENU = SystemColors.COLOR_MENU + 1,

        /// <summary>
        /// Text in menus. The associated background color is <see cref="COLOR_MENU"/>.
        /// </summary>
        COLOR_MENUTEXT = SystemColors.COLOR_MENUTEXT + 1,

        /// <summary>
        /// Scroll bar gray area.
        /// </summary>
        COLOR_SCROLLBAR = SystemColors.COLOR_SCROLLBAR + 1,

        /// <summary>
        /// Window background. The associated foreground colors are <see cref="COLOR_WINDOWTEXT"/> and COLOR_HOTLITE.
        /// </summary>
        COLOR_WINDOW = SystemColors.COLOR_WINDOW + 1,

        /// <summary>
        /// Window frame.
        /// </summary>
        COLOR_WINDOWFRAME = SystemColors.COLOR_WINDOWFRAME + 1,

        /// <summary>
        /// Text in windows. The associated background color is <see cref="COLOR_WINDOW"/>.
        /// </summary>
        COLOR_WINDOWTEXT = SystemColors.COLOR_WINDOWTEXT + 1,
    }
}
