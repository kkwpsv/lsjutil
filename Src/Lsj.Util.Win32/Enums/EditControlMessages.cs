using System;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Edit Control Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-edit-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum EditControlMessages
    {
        /// <summary>
        /// ECM_FIRST
        /// </summary>
        ECM_FIRST = 0x1500,

        /// <summary>
        /// Determines whether there are any actions in an edit control's undo queue.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_CANUNDO = 0x00C6,

        /// <summary>
        /// Gets information about the character closest to a specified point in the client area of an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_CHARFROMPOS = 0x00D7,

        /// <summary>
        /// Resets the undo flag of an edit control.
        /// The undo flag is set whenever an operation within the edit control can be undone.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_EMPTYUNDOBUFFER = 0x00CD,

        /// <summary>
        /// Sets a flag that determines whether a multiline edit control includes soft line-break characters.
        /// A soft line break consists of two carriage returns and a line feed and is inserted at the end of a line that is broken because of wordwrapping.
        /// </summary>
        EM_FMTLINES = 0x00C8,

        /// <summary>
        /// Gets the text that is displayed as the textual cue, or tip, in an edit control.
        /// </summary>
        EM_GETCUEBANNER = ECM_FIRST + 2,

        /// <summary>
        /// Gets the zero-based index of the uppermost visible line in a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETFIRSTVISIBLELINE = 0x00CE,

        /// <summary>
        /// Gets a handle of the memory currently allocated for a multiline edit control's text.
        /// </summary>
        EM_GETHANDLE = 0x00BD,

        /// <summary>
        /// This message is not implemented.
        /// </summary>
        EM_GETHILITE = ECM_FIRST + 6,

        /// <summary>
        /// Gets a set of status flags that indicate how the edit control interacts with the Input Method Editor (IME).
        /// </summary>
        EM_GETIMESTATUS = 0x00D9,

        /// <summary>
        /// Gets the current text limit for an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETLIMITTEXT = 0x00D5,

        /// <summary>
        /// Copies a line of text from an edit control and places it in a specified buffer.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETLINE = 0x00C4,

        /// <summary>
        /// Gets the number of lines in a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETLINECOUNT = 0x00BA,

        /// <summary>
        /// Gets the widths of the left and right margins for an edit control.
        /// </summary>
        EM_GETMARGINS = 0x00D4,

        /// <summary>
        /// Gets the state of an edit control's modification flag.
        /// The flag indicates whether the contents of the edit control have been modified.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETMODIFY = 0x00B8,

        /// <summary>
        /// Gets the password character that an edit control displays when the user enters text.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETPASSWORDCHAR = 0x00D2,

        /// <summary>
        /// Gets the formatting rectangle of an edit control.
        /// The formatting rectangle is the limiting rectangle into which the control draws the text.
        /// The limiting rectangle is independent of the size of the edit-control window.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETRECT = 0x00B2,

        /// <summary>
        /// Gets the starting and ending character positions (in TCHARs) of the current selection in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETSEL = 0x00B0,

        /// <summary>
        /// Gets the position of the scroll box (thumb) in the vertical scroll bar of a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETTHUMB = 0x00BE,

        /// <summary>
        /// Gets the address of the current Wordwrap function.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_GETWORDBREAKPROC = 0x00D1,

        /// <summary>
        /// Hides any balloon tip associated with an edit control.
        /// </summary>
        EM_HIDEBALLOONTIP = ECM_FIRST + 4,

        /// <summary>
        /// Sets the text limit of an edit control.
        /// The text limit is the maximum amount of text, in TCHARs, that the user can type into the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_LIMITTEXT = 0x00C5,

        /// <summary>
        /// Gets the index of the line that contains the specified character index in a multiline edit control.
        /// A character index is the zero-based index of the character from the beginning of the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_LINEFROMCHAR = 0x00C9,

        /// <summary>
        /// Gets the character index of the first character of a specified line in a multiline edit control.
        /// A character index is the zero-based index of the character from the beginning of the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_LINEINDEX = 0x00BB,

        /// <summary>
        /// Retrieves the length, in characters, of a line in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_LINELENGTH = 0x00C1,

        /// <summary>
        /// Scrolls the text in a multiline edit control.
        /// </summary>
        EM_LINESCROLL = 0x00B6,

        /// <summary>
        /// Prevents a single-line edit control from receiving keyboard focus.
        /// You can send this message explicitly or by using the <see cref="Edit_NoSetFocus"/> macro.
        /// </summary>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This message may not be supported in future versions of Windows.")]
        EM_NOSETFOCUS = ECM_FIRST + 7,

        /// <summary>
        /// Retrieves the client area coordinates of a specified character in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_POSFROMCHAR = 0x00D6,

        /// <summary>
        /// Replaces the selected text in an edit control or a rich edit control with the specified text.
        /// </summary>
        EM_REPLACESEL = 0x00C2,

        /// <summary>
        /// Scrolls the text vertically in a multiline edit control.
        /// This message is equivalent to sending a <see cref="WM_VSCROLL"/> message to the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SCROLL = 0x00B5,

        /// <summary>
        /// Scrolls the caret into view in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SCROLLCARET = 0x00B7,

        /// <summary>
        /// Sets the textual cue, or tip, that is displayed by the edit control to prompt the user for information.
        /// </summary>
        EM_SETCUEBANNER = ECM_FIRST + 1,

        /// <summary>
        /// Sets the handle of the memory that will be used by a multiline edit control.
        /// </summary>
        EM_SETHANDLE = 0x00BC,

        /// <summary>
        /// This message is not implemented.
        /// </summary>
        EM_SETHILITE = ECM_FIRST + 5,

        /// <summary>
        /// Sets the status flags that determine how an edit control interacts with the Input Method Editor (IME).
        /// </summary>
        EM_SETIMESTATUS = 0x00D8,

        /// <summary>
        /// Sets the text limit of an edit control.
        /// The text limit is the maximum amount of text, in TCHARs, that the user can type into the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// For edit controls and Microsoft Rich Edit 1.0, bytes are used.
        /// For Microsoft Rich Edit 2.0 and later, characters are used.
        /// The <see cref="EM_SETLIMITTEXT"/> message is identical to the <see cref="EM_LIMITTEXT"/> message.
        /// </summary>
        EM_SETLIMITTEXT = EM_LIMITTEXT,

        /// <summary>
        /// Sets the widths of the left and right margins for an edit control.
        /// The message redraws the control to reflect the new margins.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETMARGINS = 0x00D3,

        /// <summary>
        /// Sets or clears the modification flag for an edit control.
        /// The modification flag indicates whether the text within the edit control has been modified.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETMODIFY = 0x00B9,

        /// <summary>
        /// Sets or removes the password character for an edit control.
        /// When a password character is set, that character is displayed in place of the characters typed by the user.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETPASSWORDCHAR = 0x00CC,

        /// <summary>
        /// Sets or removes the read-only style (<see cref="ES_READONLY"/>) of an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETREADONLY = 0x00CF,

        /// <summary>
        /// Sets the formatting rectangle of a multiline edit control.
        /// The formatting rectangle is the limiting rectangle into which the control draws the text.
        /// The limiting rectangle is independent of the size of the edit control window.
        /// This message is processed only by multiline edit controls.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETRECT = 0x00B3,

        /// <summary>
        /// Sets the formatting rectangle of a multiline edit control.
        /// The <see cref="EM_SETRECTNP"/> message is identical to the <see cref="EM_SETRECT"/> message,
        /// except that <see cref="EM_SETRECTNP"/> does not redraw the edit control window.
        /// </summary>
        EM_SETRECTNP = 0x00B4,

        /// <summary>
        /// Selects a range of characters in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETSEL = 0x00B1,

        /// <summary>
        /// The <see cref="EM_SETTABSTOPS"/> message sets the tab stops in a multiline edit control.
        /// When text is copied to the control, any tab character in the text causes space to be generated up to the next tab stop.
        /// This message is processed only by multiline edit controls.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETTABSTOPS = 0x00CB,

        /// <summary>
        /// Replaces an edit control's default Wordwrap function with an application-defined Wordwrap function.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_SETWORDBREAKPROC = 0x00D0,

        /// <summary>
        /// The <see cref="EM_SHOWBALLOONTIP"/> message displays a balloon tip associated with an edit control.
        /// </summary>
        EM_SHOWBALLOONTIP = ECM_FIRST + 3,

        /// <summary>
        /// Forces a single-line edit control to receive keyboard focus.
        /// You can send this message explicitly or by using the <see cref="Edit_TakeFocus"/> macro.
        /// </summary>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This message may not be supported in future versions of Windows.")]
        EM_TAKEFOCUS = ECM_FIRST + 8,

        /// <summary>
        /// This message undoes the last edit control operation in the control's undo queue.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        EM_UNDO = 0x00C7,
    }
}
