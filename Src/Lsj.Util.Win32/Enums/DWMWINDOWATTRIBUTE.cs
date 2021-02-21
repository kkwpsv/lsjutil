using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Dwmapi;
using static Lsj.Util.Win32.Enums.DWM_CLOAKED;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Flags used by the <see cref="DwmGetWindowAttribute"/> and <see cref="DwmSetWindowAttribute"/> functions to specify window attributes
    /// for Desktop Window Manager (DWM) non-client rendering.
    /// For programming guidance, and code examples, see Controlling non-client region rendering.
    /// </para>
    /// </summary>
    public enum DWMWINDOWATTRIBUTE : uint
    {
        /// <summary>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// Discovers whether non-client rendering is enabled.
        /// The retrieved value is of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> if non-client rendering is enabled; otherwise, <see cref="FALSE"/>.
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
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// The window will provide a bitmap for use by DWM as an iconic thumbnail or peek representation (a static bitmap) for the window.
        /// <see cref="DWMWA_HAS_ICONIC_BITMAP"/> can be specified with <see cref="DWMWA_FORCE_ICONIC_REPRESENTATION"/>.
        /// <see cref="DWMWA_HAS_ICONIC_BITMAP"/> normally is set during a window's creation and not changed throughout the window's lifetime.
        /// Some scenarios, however, might require the value to change over time.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to inform DWM that the window will provide an iconic thumbnail or peek representation; otherwise, <see cref="FALSE"/>.
        /// Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_HAS_ICONIC_BITMAP,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Do not show peek preview for the window.
        /// The peek view shows a full-sized preview of the window when the mouse hovers over the window's thumbnail in the taskbar.
        /// If this attribute is set, hovering the mouse pointer over the window's thumbnail dismisses peek
        /// (in case another window in the group has a peek preview showing).
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to prevent peek functionality, or <see cref="FALSE"/> to allow it.
        /// Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_DISALLOW_PEEK,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Prevents a window from fading to a glass sheet when peek is invoked.
        /// The pvAttribute parameter points to a value of type <see cref="BOOL"/>.
        /// <see cref="TRUE"/> to prevent the window from fading during another window's peek, or <see cref="FALSE"/> for normal behavior.
        /// Windows Vista and earlier: This value is not supported.
        /// </summary>
        DWMWA_EXCLUDED_FROM_PEEK,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Cloaks the window such that it is not visible to the user. The window is still composed by DWM.
        /// Using with DirectComposition:
        /// Use the <see cref="DWMWA_CLOAK"/> flag to cloak the layered child windowwhen animating a representation of the window's content
        /// via a DirectComposition visual that has been associated with the layered child window.
        /// For more details on this usage case, see How to animate the bitmap of a layered child window.
        /// Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_CLOAK,

        /// <summary>
        /// Use with <see cref="DwmGetWindowAttribute"/>.
        /// If the window is cloaked, provides one of the following values explaining why.
        /// <see cref="DWM_CLOAKED_APP"/> (value 0x0000001). The window was cloaked by its owner application.
        /// <see cref="DWM_CLOAKED_SHELL"/> (value 0x0000002). The window was cloaked by the Shell.
        /// <see cref="DWM_CLOAKED_INHERITED"/> (value 0x0000004). The cloak value was inherited from its owner window.
        /// Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_CLOAKED,

        /// <summary>
        /// Use with <see cref="DwmSetWindowAttribute"/>.
        /// Freeze the window's thumbnail image with its current visuals.
        /// Do no further live updates on the thumbnail image to match the window's contents.
        /// Windows 7 and earlier: This value is not supported.
        /// </summary>
        DWMWA_FREEZE_REPRESENTATION,

        /// <summary>
        /// DWMWA_PASSIVE_UPDATE_MODE
        /// </summary>
        DWMWA_PASSIVE_UPDATE_MODE,

        /// <summary>
        /// The maximum recognized DWMWINDOWATTRIBUTE value, used for validation purposes.
        /// </summary>
        DWMWA_LAST
    }
}
