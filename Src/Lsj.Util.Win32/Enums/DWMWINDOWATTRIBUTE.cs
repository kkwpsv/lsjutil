using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWMCloakReasons;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Options used by the <see cref="DwmGetWindowAttribute"/> and <see cref="DwmSetWindowAttribute"/> functions.
    /// </para>
    /// <para>
    /// https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute
    /// </para>
    /// </summary>
    public enum DWMWINDOWATTRIBUTE : uint
    {
        /// <summary>
        /// <para>
        /// IMPORTANT.
        /// The value of <see cref="DWMWA_NCRENDERING_ENABLED"/> is 1.
        /// </para>
        /// <para>
        /// Use with <see cref="DwmGetWindowAttribute"/>. Discovers whether non-client rendering is enabled.
        /// The retrieved value is of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> if non-client rendering is enabled; otherwise, <see cref="FALSE"/>.
        /// </para>
        /// </summary>
        DWMWA_NCRENDERING_ENABLED = 1,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Sets the non-client rendering policy.
        /// The pvAttribute parameter points to a value from the <see cref="DWMNCRENDERINGPOLICY"/> enumeration.
        /// </summary>
        DWMWA_NCRENDERING_POLICY,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Enables or forcibly disables DWM transitions.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to disable transitions, or <see cref="FALSE"/> to enable transitions.
        /// </summary>
        DWMWA_TRANSITIONS_FORCEDISABLED,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Enables content rendered in the non-client area to be visible on the frame drawn by DWM.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to enable content rendered in the non-client area to be visible on the frame; otherwise, <see cref="FALSE"/>.
        /// </summary>
        DWMWA_ALLOW_NCPAINT,

        /// <summary>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// Retrieves the bounds of the caption button area in the window-relative space.
        /// The retrieved value is of type <see cref="RECT"/>.
        /// If the window is minimized or otherwise not visible to the user, then the value of the <see cref="RECT"/> retrieved is undefined.
        /// You should check whether the retrieved <see cref="RECT"/> contains a boundary that you can work with,
        /// and if it doesn't then you can conclude that the window is minimized or otherwise not visible.
        /// </summary>
        DWMWA_CAPTION_BUTTON_BOUNDS,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Specifies whether non-client content is right-to-left (RTL) mirrored.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> if the non-client content is right-to-left (RTL) mirrored; otherwise, <see cref="FALSE"/>.
        /// </summary>
        DWMWA_NONCLIENT_RTL_LAYOUT,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Forces the window to display an iconic thumbnail or peek representation (a static bitmap),
        /// even if a live or snapshot representation of the window is available.
        /// This value is normally set during a window's creation, and not changed throughout the window's lifetime.
        /// Some scenarios, however, might require the value to change over time.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to require a iconic thumbnail or peek representation; otherwise, <see cref="FALSE"/>.
        /// </summary>
        DWMWA_FORCE_ICONIC_REPRESENTATION,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Sets how Flip3D treats the window.
        /// The pvAttribute parameter points to a value from the <see cref="DWMFLIP3DWINDOWPOLICY"/> enumeration.
        /// </summary>
        DWMWA_FLIP3D_POLICY,

        /// <summary>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// Retrieves the extended frame bounds rectangle in screen space.
        /// The retrieved value is of type <see cref="RECT"/>.
        /// </summary>
        DWMWA_EXTENDED_FRAME_BOUNDS,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window.
        /// <see cref="DWMWA_HAS_ICONIC_BITMAP"/> can be specified with <see cref="DWMWA_FORCE_ICONIC_REPRESENTATION"/>.
        /// <see cref="DWMWA_HAS_ICONIC_BITMAP"/> normally is set during a window's creation and not changed throughout the window's lifetime.
        /// Some scenarios, however, might require the value to change over time.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Windows Vista and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_HAS_ICONIC_BITMAP,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>. Do not show peek preview for the window.
        /// The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar.
        /// If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek
        /// (in case another window in the group has a peek preview showing).
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to prevent peek functionality, or <see cref="FALSE"/> to allow it.
        /// </para>
        /// <para>
        /// Windows Vista and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_DISALLOW_PEEK,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Prevents a window from fading to a glass sheet when peek is invoked.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to prevent the window from fading during another window's peek, or <see cref="FALSE"/> for normal behavior.
        /// </para>
        /// <para>
        /// Windows Vista and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_EXCLUDED_FROM_PEEK,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Cloaks the window such that it is not visible to the user.
        /// The window is still composed by DWM.
        /// </para>
        /// <para>
        /// Using with DirectComposition:
        /// Use the <see cref="DWMWA_CLOAK"/> flag to cloak the layered child window
        /// when animating a representation of the window's content via a DirectComposition visual that has been associated with the layered child window.
        /// For more details on this usage case, see How to animate the bitmap of a layered child window.
        /// </para>
        /// <para>
        /// Windows 7 and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_CLOAK,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// If the window is cloaked, provides one of the following values explaining why.
        /// </para>
        /// <para>
        /// <see cref="DWM_CLOAKED_APP"/> (value 0x00000001).
        /// The window was cloaked by its owner application.
        /// </para>
        /// <para>
        /// <see cref="DWM_CLOAKED_SHELL"/> (value 0x00000002).
        /// The window was cloaked by the Shell.
        /// </para>
        /// <para>
        /// <see cref="DWM_CLOAKED_INHERITED"/> (value 0x00000004).
        /// The cloak value was inherited from its owner window.
        /// </para>
        /// <para>
        /// Windows 7 and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_CLOAKED,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Freeze the window's thumbnail image with its current visuals.
        /// Do no further live updates on the thumbnail image to match the window's contents.
        /// </para>
        /// <para>
        /// Windows 7 and earlier: This value is not supported.
        /// </para>
        /// </summary>
        DWMWA_FREEZE_REPRESENTATION,

        /// <summary>
        /// DWMWA_PASSIVE_UPDATE_MODE
        /// </summary>
        DWMWA_PASSIVE_UPDATE_MODE,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Enables a non-UWP window to use host backdrop brushes.
        /// If this flag is set, then a Win32 app that calls Windows.UI.Composition APIs can build transparency effects
        /// using the host backdrop brush (see Compositor.CreateHostBackdropBrush).
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to enable host backdrop brushes for the window, or <see cref="FALSE"/> to disable it.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_USE_HOSTBACKDROPBRUSH,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Allows the window frame for this window to be drawn in dark mode colors when the dark mode system setting is enabled.
        /// For compatibility reasons, all windows default to light mode regardless of the system setting.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to honor dark mode for the window, <see cref="FALSE"/> to always use light mode.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_USE_IMMERSIVE_DARK_MODE = 20,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Specifies the rounded corner preference for a window.
        /// The pvAttribute parameter points to a value of type <see cref="DWM_WINDOW_CORNER_PREFERENCE"/>.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_WINDOW_CORNER_PREFERENCE = 33,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Specifies the color of the window border.
        /// The pvAttribute parameter points to a value of type <see cref="COLORREF"/>.
        /// The app is responsible for changing the border color according to state changes, such as a change in window activation.
        /// </para>
        /// <para>
        /// Specifying <see cref="DWMWA_COLOR_NONE"/> (value 0xFFFFFFFE) for the color will suppress the drawing of the window border.
        /// This makes it possible to have a rounded window with no border.
        /// </para>
        /// <para>
        /// Specifying <see cref="DWMWA_COLOR_DEFAULT"/> (value 0xFFFFFFFF) for the color
        /// will reset the window back to using the system's default behavior for the border color.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_BORDER_COLOR,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Specifies the color of the caption.
        /// The pvAttribute parameter points to a value of type <see cref="COLORREF"/>.
        /// </para>
        /// <para>
        /// Specifying <see cref="DWMWA_COLOR_DEFAULT"/> (value 0xFFFFFFFF) for the color
        /// will reset the window back to using the system's default behavior for the caption color.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_CAPTION_COLOR,

        /// <summary>
        /// <para>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Specifies the color of the caption text.
        /// The pvAttribute parameter points to a value of type <see cref="COLORREF"/>.
        /// </para>
        /// <para>
        /// Specifying <see cref="DWMWA_COLOR_DEFAULT"/> (value 0xFFFFFFFF) for the color
        /// will reset the window back to using the system's default behavior for the caption text color.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        /// </summary>
        DWMWA_TEXT_COLOR,

        /// <para>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// Retrieves the width of the outer border that the DWM would draw around this window.
        /// The value can vary depending on the DPI of the window.
        /// The pvAttribute parameter points to a value of type <see cref="UINT"/>.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22000.
        /// </para>
        DWMWA_VISIBLE_FRAME_BORDER_THICKNESS,

        /// <summary>
        /// /// <para>
        /// Use with <see cref="DwmGetWindowAttribute"/> or <see cref="DwmSetWindowAttribute"/>.
        /// Retrieves or specifies the system-drawn backdrop material of a window, including behind the non-client area.
        /// The pvAttribute parameter points to a value of type <see cref="DWM_SYSTEMBACKDROP_TYPE"/>.
        /// </para>
        /// <para>
        /// This value is supported starting with Windows 11 Build 22621.
        /// </para>
        /// </summary>
        DWMWA_SYSTEMBACKDROP_TYPE,

        /// <summary>
        /// DWMWA_REDIRECTIONBITMAP_ALPHA
        /// </summary>
        DWMWA_REDIRECTIONBITMAP_ALPHA,

        /// <summary>
        /// DWMWA_BORDER_MARGINS
        /// </summary>
        DWMWA_BORDER_MARGINS,

        /// <summary>
        /// The maximum recognized DWMWINDOWATTRIBUTE value, used for validation purposes.
        /// </summary>
        DWMWA_LAST
    }
}
