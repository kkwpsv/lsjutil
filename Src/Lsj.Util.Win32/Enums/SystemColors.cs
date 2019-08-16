using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// System Colors
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getsyscolor
    /// </para>
    /// </summary>
    public enum SystemColors
    {
        /// <summary>
        /// Dark shadow for three-dimensional display elements.
        /// </summary>
        COLOR_3DDKSHADOW = 21,

        /// <summary>
        /// Face color for three-dimensional display elements and for dialog box backgrounds.
        /// </summary>
        COLOR_3DFACE = 15,

        /// <summary>
        /// Highlight color for three-dimensional display elements (for edges facing the light source.)
        /// </summary>
        COLOR_3DHIGHLIGHT = 20,

        /// <summary>
        /// Highlight color for three-dimensional display elements (for edges facing the light source.)
        /// </summary>
        COLOR_3DHILIGHT = 20,

        /// <summary>
        /// Light color for three-dimensional display elements (for edges facing the light source.)
        /// </summary>
        COLOR_3DLIGHT = 22,

        /// <summary>
        /// Shadow color for three-dimensional display elements (for edges facing away from the light source).
        /// </summary>
        COLOR_3DSHADOW = 16,

        /// <summary>
        /// Active window border.
        /// </summary>
        COLOR_ACTIVEBORDER = 10,

        /// <summary>
        /// Active window title bar.
        /// The associated foreground color is <see cref="COLOR_CAPTIONTEXT"/>.
        /// Specifies the left side color in the color gradient of an active window's title bar if the gradient effect is enabled.
        /// </summary>
        COLOR_ACTIVECAPTION = 2,

        /// <summary>
        /// Background color of multiple document interface (MDI) applications.
        /// </summary>
        COLOR_APPWORKSPACE = 12,

        /// <summary>
        /// Desktop.
        /// </summary>
        COLOR_BACKGROUND = 1,

        /// <summary>
        /// Face color for three-dimensional display elements and for dialog box backgrounds. The associated foreground color is <see cref="COLOR_BTNTEXT"/>.
        /// </summary>
        COLOR_BTNFACE = 15,

        /// <summary>
        /// Highlight color for three-dimensional display elements (for edges facing the light source.)
        /// </summary>
        COLOR_BTNHIGHLIGHT = 20,

        /// <summary>
        /// Highlight color for three-dimensional display elements (for edges facing the light source.)
        /// </summary>
        COLOR_BTNHILIGHT = 20,

        /// <summary>
        /// Shadow color for three-dimensional display elements (for edges facing away from the light source).
        /// </summary>
        COLOR_BTNSHADOW = 16,

        /// <summary>
        /// Text on push buttons. The associated background color is <see cref="COLOR_BTNFACE"/>.
        /// </summary>
        COLOR_BTNTEXT = 18,

        /// <summary>
        /// Text in caption, size box, and scroll bar arrow box. The associated background color is <see cref="COLOR_ACTIVECAPTION"/>.
        /// </summary>
        COLOR_CAPTIONTEXT = 9,

        /// <summary>
        /// Desktop.
        /// </summary>
        COLOR_DESKTOP = 1,

        /// <summary>
        /// Right side color in the color gradient of an active window's title bar. <see cref="COLOR_ACTIVECAPTION"/> specifies the left side color.
        /// Use SPI_GETGRADIENTCAPTIONS with the SystemParametersInfo function to determine whether the gradient effect is enabled.
        /// </summary>
        COLOR_GRADIENTACTIVECAPTION = 27,

        /// <summary>
        /// Right side color in the color gradient of an inactive window's title bar. <see cref="COLOR_INACTIVECAPTION"/> specifies the left side color.
        /// </summary>
        COLOR_GRADIENTINACTIVECAPTION = 28,

        /// <summary>
        /// Grayed (disabled) text. This color is set to 0 if the current display driver does not support a solid gray color.
        /// </summary>
        COLOR_GRAYTEXT = 17,

        /// <summary>
        /// Item(s) selected in a control. The associated foreground color is <see cref="COLOR_HIGHLIGHTTEXT"/>.
        /// </summary>
        COLOR_HIGHLIGHT = 13,

        /// <summary>
        /// Text of item(s) selected in a control. The associated background color is <see cref="COLOR_HIGHLIGHT"/>.
        /// </summary>
        COLOR_HIGHLIGHTTEXT = 14,

        /// <summary>
        /// Color for a hyperlink or hot-tracked item. The associated background color is <see cref="COLOR_WINDOW"/>.
        /// </summary>
        COLOR_HOTLIGHT = 26,

        /// <summary>
        /// Inactive window border.
        /// </summary>
        COLOR_INACTIVEBORDER = 11,

        /// <summary>
        /// Inactive window caption. The associated foreground color is <see cref="COLOR_INACTIVECAPTIONTEXT"/>.
        /// Specifies the left side color in the color gradient of an inactive window's title bar if the gradient effect is enabled.
        /// </summary>
        COLOR_INACTIVECAPTION = 3,

        /// <summary>
        /// Color of text in an inactive caption. The associated background color is <see cref="COLOR_INACTIVECAPTION"/>.
        /// </summary>
        COLOR_INACTIVECAPTIONTEXT = 19,

        /// <summary>
        /// Background color for tooltip controls. The associated foreground color is <see cref="COLOR_INFOTEXT"/>.
        /// </summary>
        COLOR_INFOBK = 24,

        /// <summary>
        /// Text color for tooltip controls. The associated background color is <see cref="COLOR_INFOBK"/>.
        /// </summary>
        COLOR_INFOTEXT = 23,

        /// <summary>
        /// Menu background. The associated foreground color is <see cref="COLOR_MENUTEXT"/>.
        /// </summary>
        COLOR_MENU = 4,

        /// <summary>
        /// The color used to highlight menu items when the menu appears as a flat menu (see SystemParametersInfo).
        /// The highlighted menu item is outlined with <see cref="COLOR_MENUHILIGHT"/>.
        /// </summary>
        COLOR_MENUHILIGHT = 29,

        /// <summary>
        /// The background color for the menu bar when menus appear as flat menus (see SystemParametersInfo).
        /// However, <see cref="COLOR_MENU"/> continues to specify the background color of the menu popup.
        /// </summary>
        COLOR_MENUBAR = 30,

        /// <summary>
        /// Text in menus. The associated background color is <see cref="COLOR_MENU"/>.
        /// </summary>
        COLOR_MENUTEXT = 7,

        /// <summary>
        /// Scroll bar gray area.
        /// </summary>
        COLOR_SCROLLBAR = 0,

        /// <summary>
        /// Window background. The associated foreground colors are <see cref="COLOR_WINDOWTEXT"/> and COLOR_HOTLITE.
        /// </summary>
        COLOR_WINDOW = 5,

        /// <summary>
        /// Window frame.
        /// </summary>
        COLOR_WINDOWFRAME = 6,

        /// <summary>
        /// Text in windows. The associated background color is <see cref="COLOR_WINDOW"/>.
        /// </summary>
        COLOR_WINDOWTEXT = 8,
    }
}
