using System;
using static Lsj.Util.Win32.Enums.EditControlMessages;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// The following window styles are unique to rich edit controls.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/rich-edit-control-styles"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum RichEditControlStyles : uint
    {
        /// <summary>
        /// Automatically scrolls text to the right by 10 characters when the user types a character at the end of the line.
        /// When the user presses the ENTER key, the control scrolls all text back to position zero.
        /// </summary>
        ES_AUTOHSCROLL = 0x0080,

        /// <summary>
        /// Automatically scrolls text up one page when the user presses the ENTER key on the last line.
        /// </summary>
        ES_AUTOVSCROLL = 0x0040,

        /// <summary>
        /// Centers text in a single-line or multiline edit control.
        /// </summary>
        ES_CENTER = 0x0001,

        /// <summary>
        /// Aligns text with the left margin.
        /// </summary>
        ES_LEFT = 0x0000,

        /// <summary>
        /// Designates a multiline edit control. The default is single-line edit control.
        /// When the multiline edit control is in a dialog box, the default response to pressing the ENTER key is to activate the default button.
        /// To use the ENTER key as a carriage return, use the <see cref="ES_WANTRETURN"/> style.
        /// When the multiline edit control is not in a dialog box and the <see cref="ES_AUTOVSCROLL"/> style is specified,
        /// the edit control shows as many lines as possible and scrolls vertically when the user presses the ENTER key.
        /// If you do not specify <see cref="ES_AUTOVSCROLL"/>, the edit control shows as many lines as possible and beeps
        /// if the user presses the ENTER key when no more lines can be displayed.
        /// If you specify the <see cref="ES_AUTOHSCROLL"/> style, the multiline edit control automatically scrolls horizontally
        /// when the caret goes past the right edge of the control.
        /// To start a new line, the user must press the ENTER key.
        /// If you do not specify <see cref="ES_AUTOHSCROLL"/>, the control automatically wraps words to the beginning of the next line when necessary.
        /// A new line is also started if the user presses the ENTER key.
        /// The window size determines the position of the Wordwrap.
        /// If the window size changes, the Wordwrapping position changes and the text is redisplayed.
        /// Multiline edit controls can have scroll bars. An edit control with scroll bars processes its own scroll bar messages.
        /// Note that edit controls without scroll bars scroll as described in the previous paragraphs and process any scroll messages
        /// sent by the parent window.
        /// </summary>
        ES_MULTILINE = 0x0004,

        /// <summary>
        /// Negates the default behavior for an edit control.
        /// The default behavior hides the selection when the control loses the input focus and inverts the selection
        /// when the control receives the input focus.
        /// If you specify <see cref="ES_NOHIDESEL"/>, the selected text is inverted, even if the control does not have the focus.
        /// </summary>
        ES_NOHIDESEL = 0x0100,

        /// <summary>
        /// Allows only digits to be entered into the edit control. Note that, even with this set,
        /// it is still possible to paste non-digits into the edit control.
        /// To change this style after the control has been created, use SetWindowLong.
        /// To translate text that was entered into the edit control to an integer value, use the <see cref="GetDlgItemInt"/> function.
        /// To set the text of the edit control to the string representation of a specified integer, use the <see cref="SetDlgItemInt"/> function.
        /// </summary>
        ES_NUMBER = 0x2000,

        /// <summary>
        /// Displays an asterisk (*) for each character typed into the edit control.
        /// This style is valid only for single-line edit controls.
        /// To change the characters that is displayed, or set or clear this style, use the <see cref="EM_SETPASSWORDCHAR"/> message.
        /// To use Comctl32.dll version 6, specify it in a manifest.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </summary>
        ES_PASSWORD = 0x0020,

        /// <summary>
        /// Prevents the user from typing or editing text in the edit control.
        /// To change this style after the control has been created, use the <see cref="EM_SETREADONLY"/> message.
        /// </summary>
        ES_READONLY = 0x0800,

        /// <summary>
        /// Right-aligns text in a single-line or multiline edit control.
        /// </summary>
        ES_RIGHT = 0x0002,

        /// <summary>
        /// Specifies that a carriage return be inserted when the user presses the ENTER key
        /// while entering text into a multiline edit control in a dialog box.
        /// If you do not specify this style, pressing the ENTER key has the same effect as pressing the dialog box's default push button.
        /// This style has no effect on a single-line edit control.
        /// To change this style after the control has been created, use <see cref="SetWindowLong"/>.
        /// </summary>
        ES_WANTRETURN = 0x1000,

        /// <summary>
        /// Disables scroll bars instead of hiding them when they are not needed.
        /// </summary>
        ES_DISABLENOSCROLL = 0x00002000,

        /// <summary>
        /// Prevents the control from calling the <see cref="OleInitialize"/> function when created.
        /// This window style is useful only in dialog templates because <see cref="CreateWindowEx"/> does not accept this style.
        /// </summary>
        ES_EX_NOCALLOLEINIT = 0x00000000,

        /// <summary>
        /// Disables the IME operation.
        /// This style is available for Asian language support only.
        /// </summary>
        ES_NOIME = 0x00080000,

        /// <summary>
        /// Disables support for drag-drop of OLE objects.
        /// </summary>
        ES_NOOLEDRAGDROP = 0x00000008,

        /// <summary>
        /// Preserves the selection when the control loses the focus.
        /// By default, the entire contents of the control are selected when it regains the focus.
        /// </summary>
        ES_SAVESEL = 0x00008000,

        /// <summary>
        /// Adds space to the left margin where the cursor changes to a right-up arrow, allowing the user to select full lines of text.
        /// </summary>
        ES_SELECTIONBAR = 0x01000000,

        /// <summary>
        /// Directs the rich edit control to allow the application to handle all IME operations.
        /// This style is available for Asian language support only.
        /// </summary>
        ES_SELFIME = 0x00040000,

        /// <summary>
        /// Displays the control with a sunken border style so that the rich edit control appears recessed into its parent window.
        /// </summary>
        ES_SUNKEN = 0x00004000,

        /// <summary>
        /// Draws text and objects in a vertical direction.
        /// This style is available for Asian-language support only.
        /// </summary>
        ES_VERTICAL = 0x00400000,
    }
}
