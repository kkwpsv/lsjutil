using static Lsj.Util.Win32.Enums.ButtonControlMessages;
using static Lsj.Util.Win32.Enums.ButtonControlNotifications;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a combination of button styles.
    /// If you create a button using the BUTTON class with the <see cref="CreateWindow"/> or <see cref="CreateWindowEx"/> function,
    /// you can specify any of the button styles listed below.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/controls/button-styles
    /// </para>
    /// </summary>
    /// <remarks>
    /// For illustrations of the principal button styles such as <see cref="BS_CHECKBOX"/> and <see cref="BS_GROUPBOX"/>, see Button Types.
    /// The appearance of text or an icon or both on a button control depends on the <see cref="BS_ICON"/> and <see cref="BS_BITMAP"/> styles,
    /// and whether the <see cref="BM_SETIMAGE"/> message is sent. The possible results are as follows.
    /// <see cref="BS_ICON"/> or <see cref="BS_BITMAP"/> set: Yes. <see cref="BM_SETIMAGE"/> called: Yes. Result: Show icon only.
    /// <see cref="BS_ICON"/> or <see cref="BS_BITMAP"/> set: No. <see cref="BM_SETIMAGE"/> called: Yes. Result: Show icon and text.
    /// <see cref="BS_ICON"/> or <see cref="BS_BITMAP"/> set: Yes. <see cref="BM_SETIMAGE"/> called: No. Result: Show text only.
    /// <see cref="BS_ICON"/> or <see cref="BS_BITMAP"/> set: No. <see cref="BM_SETIMAGE"/> called: No. Result: Show text only.
    /// </remarks>
    public enum ButtonStyles
    {
        /// <summary>
        /// Creates a button that is the same as a check box, except that the box can be grayed as well as checked or cleared.
        /// Use the grayed state to show that the state of the check box is not determined.
        /// </summary>
        BS_3STATE = 0x00000005,

        /// <summary>
        /// Creates a button that is the same as a three-state check box, except that the box changes its state when the user selects it.
        /// The state cycles through checked, indeterminate, and cleared.
        /// </summary>
        BS_AUTO3STATE = 0x00000006,

        /// <summary>
        /// Creates a button that is the same as a check box,
        /// except that the check state automatically toggles between checked and cleared each time the user selects the check box.
        /// </summary>
        BS_AUTOCHECKBOX = 0x00000003,

        /// <summary>
        /// Creates a button that is the same as a radio button, except that when the user selects it,
        /// the system automatically sets the button's check state to checked and automatically sets the check state
        /// for all other buttons in the same group to cleared.
        /// </summary>
        BS_AUTORADIOBUTTON = 0x00000009,

        /// <summary>
        /// Specifies that the button displays a bitmap. See the Remarks section for its interaction with <see cref="BS_ICON"/>.
        /// </summary>
        BS_BITMAP = 0x00000080,

        /// <summary>
        /// Places text at the bottom of the button rectangle.
        /// </summary>
        BS_BOTTOM = 0x00000800,

        /// <summary>
        /// Centers text horizontally in the button rectangle.
        /// </summary>
        BS_CENTER = 0x00000300,

        /// <summary>
        /// Creates a small, empty check box with text.
        /// By default, the text is displayed to the right of the check box.
        /// To display the text to the left of the check box, combine this flag
        /// with the <see cref="BS_LEFTTEXT"/> style (or with the equivalent <see cref="BS_RIGHTBUTTON"/> style).
        /// </summary>
        BS_CHECKBOX = 0x00000002,

        /// <summary>
        /// Creates a command link button that behaves like a <see cref="BS_PUSHBUTTON"/> style button,
        /// but the command link button has a green arrow on the left pointing to the button text.
        /// A caption for the button text can be set by sending the <see cref="BCM_SETNOTE"/> message to the button.
        /// </summary>
        BS_COMMANDLINK = 0x0000000E,

        /// <summary>
        /// Creates a command link button that behaves like a <see cref="BS_PUSHBUTTON"/> style button.
        /// If the button is in a dialog box, the user can select the command link button by pressing the ENTER key,
        /// even when the command link button does not have the input focus.
        /// This style is useful for enabling the user to quickly select the most likely (default) option.
        /// </summary>
        BS_DEFCOMMANDLINK = 0x0000000F,

        /// <summary>
        /// Creates a push button that behaves like a <see cref="BS_PUSHBUTTON"/> style button, but has a distinct appearance.
        /// If the button is in a dialog box, the user can select the button by pressing the ENTER key,
        /// even when the button does not have the input focus.
        /// This style is useful for enabling the user to quickly select the most likely (default) option.
        /// </summary>
        BS_DEFPUSHBUTTON = 0x00000001,

        /// <summary>
        /// Creates a split button that behaves like a <see cref="BS_PUSHBUTTON"/> style button, but also has a distinctive appearance.
        /// If the split button is in a dialog box, the user can select the split button by pressing the ENTER key,
        /// even when the split button does not have the input focus.
        /// This style is useful for enabling the user to quickly select the most likely (default) option.
        /// </summary>
        BS_DEFSPLITBUTTON = 0x0000000D,

        /// <summary>
        /// Creates a rectangle in which other controls can be grouped.
        /// Any text associated with this style is displayed in the rectangle's upper left corner.
        /// </summary>
        BS_GROUPBOX = 0x00000007,

        /// <summary>
        /// Specifies that the button displays an icon.
        /// See the Remarks section for its interaction with <see cref="BS_BITMAP"/>.
        /// </summary>
        BS_ICON = 0x00000040,

        /// <summary>
        /// Specifies that the button is two-dimensional; it does not use the default shading to create a 3-D image.
        /// </summary>
        BS_FLAT = 0x00008000,

        /// <summary>
        /// Left-justifies the text in the button rectangle.
        /// However, if the button is a check box or radio button that does not have the <see cref="BS_RIGHTBUTTON"/> style,
        /// the text is left justified on the right side of the check box or radio button.
        /// </summary>
        BS_LEFT = 0x00000100,

        /// <summary>
        /// Places text on the left side of the radio button or check box when combined with a radio button or check box style.
        /// Same as the <see cref="BS_RIGHTBUTTON"/> style.
        /// </summary>
        BS_LEFTTEXT = 0x00000020,

        /// <summary>
        /// Wraps the button text to multiple lines if the text string is too long to fit on a single line in the button rectangle.
        /// </summary>
        BS_MULTILINE = 0x00002000,

        /// <summary>
        /// Enables a button to send <see cref="BN_KILLFOCUS"/> and
        /// <see cref="BN_SETFOCUS"/> notification codes to its parent window.
        /// Note that buttons send the <see cref="BN_CLICKED"/> notification code regardless of whether it has this style.
        /// To get <see cref="BN_DBLCLK"/> notification codes,
        /// the button must have the <see cref="BS_RADIOBUTTON"/> or <see cref="BS_OWNERDRAW"/> style.
        /// </summary>
        BS_NOTIFY = 0x00004000,

        /// <summary>
        /// Creates an owner-drawn button.
        /// The owner window receives a <see cref="WM_DRAWITEM"/> message when a visual aspect of the button has changed.
        /// Do not combine the <see cref="BS_OWNERDRAW"/> style with any other button styles.
        /// </summary>
        BS_OWNERDRAW = 0x0000000B,

        /// <summary>
        /// Creates a push button that posts a <see cref="WM_COMMAND"/> message to the owner window when the user selects the button.
        /// </summary>
        BS_PUSHBUTTON = 0x00000000,

        /// <summary>
        /// Makes a button (such as a check box, three-state check box, or radio button) look and act like a push button.
        /// The button looks raised when it isn't pushed or checked, and sunken when it is pushed or checked.
        /// </summary>
        BS_PUSHLIKE = 0x00001000,

        /// <summary>
        /// Creates a small circle with text.
        /// By default, the text is displayed to the right of the circle.
        /// To display the text to the left of the circle, combine this flag with the <see cref="BS_LEFTTEXT"/> style
        /// (or with the equivalent <see cref="BS_RIGHTBUTTON"/> style).
        /// Use radio buttons for groups of related, but mutually exclusive choices.
        /// </summary>
        BS_RADIOBUTTON = 0x00000004,

        /// <summary>
        /// Right-justifies text in the button rectangle.
        /// However, if the button is a check box or radio button that does not have the <see cref="BS_RIGHTBUTTON"/> style,
        /// the text is right justified on the right side of the check box or radio button.
        /// </summary>
        BS_RIGHT = 0x00000200,

        /// <summary>
        /// Positions a radio button's circle or a check box's square on the right side of the button rectangle.
        /// Same as the <see cref="BS_LEFTTEXT"/> style.
        /// </summary>
        BS_RIGHTBUTTON = BS_LEFTTEXT,

        /// <summary>
        /// Creates a split button. A split button has a drop down arrow.
        /// </summary>
        BS_SPLITBUTTON = 0x0000000C,

        /// <summary>
        /// Specifies that the button displays text.
        /// </summary>
        BS_TEXT = 0x00000000,

        /// <summary>
        /// Places text at the top of the button rectangle.
        /// </summary>
        BS_TOP = 0x00000400,

        /// <summary>
        /// Do not use this style.
        /// A composite style bit that results from using the OR operator on BS_* style bits.
        /// It can be used to mask out valid BS_* bits from a given bitmask.
        /// Note that this is out of date and does not correctly include all valid styles. Thus, you should not use this style.
        /// </summary>
        BS_TYPEMASK = 0x0000000F,

        /// <summary>
        /// Obsolete, but provided for compatibility with 16-bit versions of Windows.
        /// Applications should use <see cref="BS_OWNERDRAW"/> instead.
        /// </summary>
        BS_USERBUTTON = 0x00000008,

        /// <summary>
        /// Places text in the middle (vertically) of the button rectangle.
        /// </summary>
        BS_VCENTER = 0x00000C00,
    }
}
