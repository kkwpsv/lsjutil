using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.EditControlStyles;
using static Lsj.Util.Win32.Enums.GetWindowLongIndexes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Macros.EditControlMacros;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Edit Control Messages
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/controls/bumper-edit-control-reference-messages"/>
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
        /// <remarks>
        /// <para>
        /// If the undo queue is not empty, you can send the <see cref="EM_UNDO"/> message to the control to undo the most recent operation.
        /// </para>
        /// <para>
        /// Edit controls and Rich Edit 1.0: The undo queue contains only the most recent operation.
        /// </para>
        /// <para>
        /// Rich Edit 2.0 and later: The undo queue can contain multiple operations.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_CANUNDO = 0x00C6,

        /// <summary>
        /// Gets information about the character closest to a specified point in the client area of an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// <para>
        /// If a point is passed to <see cref="EM_CHARFROMPOS"/> as the lParam and the point is outside the bounds of the edit control, 
        /// then the lResult is (65535, 65535).
        /// </para>
        /// </remarks>
        EM_CHARFROMPOS = 0x00D7,

        /// <summary>
        /// Resets the undo flag of an edit control.
        /// The undo flag is set whenever an operation within the edit control can be undone.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The undo flag is automatically reset whenever the edit control receives a <see cref="WM_SETTEXT"/> or <see cref="EM_SETHANDLE"/> message.
        /// </para>
        /// <para>
        /// Edit controls and Rich Edit 1.0: The control can only undo or redo the most recent operation.
        /// </para>
        /// <para>
        /// Rich Edit 2.0 and later: The <see cref="EM_EMPTYUNDOBUFFER"/> message empties all undo and redo buffers.
        /// Rich edit controls enable the user to undo or redo multiple operations.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_EMPTYUNDOBUFFER = 0x00CD,

        /// <summary>
        /// Sets a flag that determines whether a multiline edit control includes soft line-break characters.
        /// A soft line break consists of two carriage returns and a line feed and is inserted at the end of a line that is broken because of wordwrapping.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message affects only the buffer returned by the <see cref="EM_GETHANDLE"/> message
        /// and the text returned by the <see cref="WM_GETTEXT"/> message.
        /// It has no effect on the display of the text within the edit control.
        /// </para>
        /// <para>
        /// The <see cref="EM_FMTLINES"/> message does not affect a line that ends with a hard line break.
        /// A hard line break consists of one carriage return and a line feed.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// The size of the text changes when this message is processed.
        /// </para>
        /// <para>
        /// Rich Edit: The <see cref="EM_FMTLINES"/> message is not supported.
        /// </para>
        /// </remarks>
        EM_FMTLINES = 0x00C8,

        /// <summary>
        /// Gets the text that is displayed as the textual cue, or tip, in an edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </para>
        /// </remarks>
        EM_GETCUEBANNER = ECM_FIRST + 2,

        /// <summary>
        /// Gets the zero-based index of the uppermost visible line in a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <para>
        /// The number of lines and the length of the lines in an edit control depend on the width of the control and the current Wordwrap setting.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        EM_GETFIRSTVISIBLELINE = 0x00CE,

        /// <summary>
        /// Gets a handle of the memory currently allocated for a multiline edit control's text.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the function succeeds, the application can access the contents of the edit control
        /// by casting the return value to <see cref="HLOCAL"/> and passing it to <see cref="LocalLock"/>.
        /// <see cref="LocalLock"/> returns a pointer to a buffer that is a null-terminated array of <see cref="CHAR"/>s or <see cref="WCHAR"/>s,
        /// depending on whether an ANSI or Unicode function created the control.
        /// For example, if CreateWindowExA was used the buffer is an array of <see cref="CHAR"/>s,
        /// but if CreateWindowExW was used the buffer is an array of <see cref="WCHAR"/>s.
        /// The application may not change the contents of the buffer.
        /// To unlock the buffer, the application calls <see cref="LocalUnlock"/> before allowing the edit control to receive new messages.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// For Comctl32.dll version 6, the buffer always contains an array of <see cref="WCHAR"/>s,
        /// regardless of whether an ANSI or Unicode function created the edit control.
        /// For more information on DLL versions, see Common Control Versions.
        /// </para>
        /// <para>
        /// If your application cannot abide by the restrictions imposed by <see cref="EM_GETHANDLE"/>,
        /// use the <see cref="GetWindowTextLength"/> and <see cref="GetWindowText"/> functions
        /// to copy the contents of the edit control into an application-provided buffer.
        /// </para>
        /// <para>
        /// Rich Edit: The <see cref="EM_GETHANDLE"/> message is not supported. Rich edit controls do not store text as a simple array of characters.
        /// </para>
        /// </remarks>
        EM_GETHANDLE = 0x00BD,

        /// <summary>
        /// This message is not implemented.
        /// </summary>
        EM_GETHILITE = ECM_FIRST + 6,

        /// <summary>
        /// Gets a set of status flags that indicate how the edit control interacts with the Input Method Editor (IME).
        /// </summary>
        /// <para>
        /// Rich Edit: The <see cref="EM_GETIMESTATUS"/> message is not supported.
        /// </para>
        EM_GETIMESTATUS = 0x00D9,

        /// <summary>
        /// Gets the current text limit for an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <para>
        /// Edit controls, Rich Edit 2.0 and later:
        /// The text limit is the maximum amount of text, in TCHARs, that the control can contain.
        /// For ANSI text, this is the number of bytes; for Unicode text, this is the number of characters.
        /// Two documents with the same character limit will yield the same text limit, even if one is ANSI and the other is Unicode.
        /// </para>
        /// <para>
        /// Rich Edit 1.0: The text limit is the maximum amount of text, in bytes, that the rich edit control can contain.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        EM_GETLIMITTEXT = 0x00D5,

        /// <summary>
        /// Copies a line of text from an edit control and places it in a specified buffer.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Edit controls: The copied line does not contain a terminating null character.
        /// </para>
        /// <para>
        /// Rich edit controls: Supported in Microsoft Rich Edit 1.0 and later.
        /// The copied line does not contain a terminating null character, unless no text was copied.
        /// If no text was copied, the message places a null character at the beginning of the buffer.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_GETLINE = 0x00C4,

        /// <summary>
        /// Gets the number of lines in a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <para>
        /// The <see cref="EM_GETLINECOUNT"/> message retrieves the total number of text lines, not just the number of lines that are currently visible.
        /// </para>
        /// <para>
        /// If the Wordwrap feature is enabled, the number of lines can change when the dimensions of the editing window change.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        EM_GETLINECOUNT = 0x00BA,

        /// <summary>
        /// Gets the widths of the left and right margins for an edit control.
        /// </summary>
        /// <remarks>
        /// Rich Edit: The <see cref="EM_GETMARGINS"/> message is not supported.
        /// </remarks>
        EM_GETMARGINS = 0x00D4,

        /// <summary>
        /// Gets the state of an edit control's modification flag.
        /// The flag indicates whether the contents of the edit control have been modified.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remark>
        /// <para>
        /// The system automatically clears the modification flag to zero when the control is created.
        /// If the user changes the control's text, the system sets the flag to nonzero.
        /// You can send the <see cref="EM_SETMODIFY"/> message to the edit control to set or clear the flag.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remark>
        EM_GETMODIFY = 0x00B8,

        /// <summary>
        /// Gets the password character that an edit control displays when the user enters text.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If an edit control is created with the <see cref="ES_PASSWORD"/> style,
        /// the default password character is set to an asterisk (*).
        /// If an edit control is created without the <see cref="ES_PASSWORD"/> style, there is no password character.
        /// To change the password character, send the <see cref="EM_SETPASSWORDCHAR"/> message.
        /// </para>
        /// <para>
        /// Edit controls: Multiline edit controls do not support the password style or messages.
        /// </para>
        /// <para>
        /// Rich edit: Supported in Microsoft Rich Edit 2.0 and later.
        /// Both single-line and multiline edit controls support the password style and messages.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_GETPASSWORDCHAR = 0x00D2,

        /// <summary>
        /// Gets the formatting rectangle of an edit control.
        /// The formatting rectangle is the limiting rectangle into which the control draws the text.
        /// The limiting rectangle is independent of the size of the edit-control window.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// You can modify the formatting rectangle of a multiline edit control
        /// by using the <see cref="EM_SETRECT"/> and <see cref="EM_SETRECTNP"/> messages.
        /// </para>
        /// <para>
        /// Under certain conditions, <see cref="EM_GETRECT"/> might not return the exact values
        /// that <see cref="EM_SETRECT"/> or <see cref="EM_SETRECTNP"/> set it will be approximately correct, but it can be off by a few pixels.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// The formatting rectangle does not include the selection bar, which is an unmarked area to the left of each paragraph.
        /// When clicked, the selection bar selects the line.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_GETRECT = 0x00B2,

        /// <summary>
        /// Gets the starting and ending character positions (in TCHARs) of the current selection in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If there is no selection, the starting and ending values are both the position of the caret.
        /// </para>
        /// <para>
        /// Rich edit controls: You can also use the <see cref="EM_EXGETSEL"/> message to retrieve the same information.
        /// <see cref="EM_EXGETSEL"/> also returns starting and ending character positions as 32-bit values.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_GETSEL = 0x00B0,

        /// <summary>
        /// Gets the position of the scroll box (thumb) in the vertical scroll bar of a multiline edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// Rich Edit: Supported in Microsoft Rich Edit 2.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </remarks>
        EM_GETTHUMB = 0x00BE,

        /// <summary>
        /// Gets the address of the current Wordwrap function.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A Wordwrap function scans a text buffer that contains text to be sent to the display,
        /// looking for the first word that does not fit on the current display line.
        /// The wordwrap function places this word at the beginning of the next line on the display.
        /// A Wordwrap function defines the point at which the system should break a line of text for multiline edit controls,
        /// usually at a space character that separates two words.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_GETWORDBREAKPROC = 0x00D1,

        /// <summary>
        /// Hides any balloon tip associated with an edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        ///  Note
        /// </para>
        /// <para>
        /// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see Enabling Visual Styles.
        /// </para>
        /// </remarks>
        EM_HIDEBALLOONTIP = ECM_FIRST + 4,

        /// <summary>
        /// Sets the text limit of an edit control.
        /// The text limit is the maximum amount of text, in TCHARs, that the user can type into the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="EM_LIMITTEXT"/> message limits only the text the user can enter.
        /// It does not affect any text already in the edit control when the message is sent,
        /// nor does it affect the length of the text copied to the edit control by the <see cref="WM_SETTEXT"/> message.
        /// If an application uses the <see cref="WM_SETTEXT"/> message to place more text into an edit control
        /// than is specified in the <see cref="EM_LIMITTEXT"/> message, the user can edit the entire contents of the edit control.
        /// </para>
        /// <para>
        /// Before <see cref="EM_LIMITTEXT"/> is called, the default limit for the amount of text a user can enter in an edit control is 32,767 characters.
        /// </para>
        /// <para>
        /// For single-line edit controls, the text limit is either 0x7FFFFFFE bytes or the value of the wParam parameter, whichever is smaller.
        /// For multiline edit controls, this value is either -1 byte or the value of the wParam parameter, whichever is smaller.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// Use the message <see cref="EM_EXLIMITTEXT"/> for text length values greater than 64,000.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_LIMITTEXT = 0x00C5,

        /// <summary>
        /// Gets the index of the line that contains the specified character index in a multiline edit control.
        /// A character index is the zero-based index of the character from the beginning of the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// If the character index is greater than 64,000, use the <see cref="EM_EXLINEFROMCHAR"/> message.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </remarks>
        EM_LINEFROMCHAR = 0x00C9,

        /// <summary>
        /// Gets the character index of the first character of a specified line in a multiline edit control.
        /// A character index is the zero-based index of the character from the beginning of the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </remarks>
        EM_LINEINDEX = 0x00BB,

        /// <summary>
        /// Retrieves the length, in characters, of a line in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the <see cref="EM_LINEINDEX"/> message to retrieve a character index for a given line number within a multiline edit control.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_LINELENGTH = 0x00C1,

        /// <summary>
        /// Scrolls the text in a multiline edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The control does not scroll vertically past the last line of text in the edit control.
        /// If the current line plus the number of lines specified by the lParam parameter
        /// exceeds the total number of lines in the edit control,
        /// the value is adjusted so that the last line of the edit control is scrolled to the top of the edit-control window.
        /// </para>
        /// <para>
        /// Edit controls: The <see cref="EM_LINESCROLL"/> message scrolls the text vertically or horizontally in a multiline edit control.
        /// The <see cref="EM_LINESCROLL"/> message can be used to scroll horizontally past the last character of any line.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// The <see cref="EM_LINESCROLL"/> message scrolls the text vertically in a multiline edit control.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_LINESCROLL = 0x00B6,

        /// <summary>
        /// Prevents a single-line edit control from receiving keyboard focus.
        /// You can send this message explicitly or by using the <see cref="Edit_NoSetFocus"/> macro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is ignored if the edit control is not a single-line edit control.
        /// </para>
        /// <para>
        /// After this message is sent, the effect is permanent.
        /// </para>
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This message may not be supported in future versions of Windows.")]
        EM_NOSETFOCUS = ECM_FIRST + 7,

        /// <summary>
        /// Retrieves the client area coordinates of a specified character in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A returned coordinate can be a negative value if the specified character is not displayed in the edit control's client area.
        /// The coordinates are truncated to integer values.
        /// </para>
        /// <para>
        /// If the character is a line delimiter, the returned coordinates indicate a point just beyond the last visible character in the line.
        /// If the specified index is greater than the index of the last character in the control, the control returns -1.
        /// </para>
        /// <para>
        /// Rich Edit 3.0 and later:
        /// For backward compatibility, Microsoft Rich Edit 3.0 supports the syntax used by Microsoft Rich Edit 2.0.
        /// If Microsoft Rich Edit 3.0 detects that wParam is not a valid <see cref="POINTL"/> pointer,
        /// it assumes the message was sent using the Microsoft Rich Edit 2.0 syntax.
        /// In this case, it uses the return value to return the coordinates.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_POSFROMCHAR = 0x00D6,

        /// <summary>
        /// Replaces the selected text in an edit control or a rich edit control with the specified text.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Use the <see cref="EM_REPLACESEL"/> message to replace only a portion of the text in an edit control.
        /// To replace all of the text, use the <see cref="WM_SETTEXT"/> message.
        /// </para>
        /// <para>
        /// If there is no selection, the replacement text is inserted at the caret.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// <para>
        /// In a rich edit control, the replacement text takes the formatting of the character at the caret or,
        /// if there is a selection, of the first character in the selection.
        /// </para>
        /// </remarks>
        EM_REPLACESEL = 0x00C2,

        /// <summary>
        /// Scrolls the text vertically in a multiline edit control.
        /// This message is equivalent to sending a <see cref="WM_VSCROLL"/> message to the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// To scroll to a specific line or character position, use the <see cref="EM_LINESCROLL"/> message.
        /// To scroll the caret into view, use the <see cref="EM_SCROLLCARET"/> message.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SCROLL = 0x00B5,

        /// <summary>
        /// Scrolls the caret into view in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </remarks>
        EM_SCROLLCARET = 0x00B7,

        /// <summary>
        /// Sets the textual cue, or tip, that is displayed by the edit control to prompt the user for information.
        /// </summary>
        /// <remarks>
        /// <para>
        /// An edit control that is used to begin a search may display "Enter search here" in gray text as a textual cue.
        /// When the user clicks the text, the text goes away and the user can type.
        /// </para>
        /// <para>
        /// You cannot set a cue banner on a multiline edit control or on a rich edit control.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To use this API, you must provide a manifest specifying Comclt32.dll version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </para>
        /// </remarks>
        EM_SETCUEBANNER = ECM_FIRST + 1,

        /// <summary>
        /// Sets the handle of the memory that will be used by a multiline edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Before an application sets a new memory handle, it should send an <see cref="EM_GETHANDLE"/> message
        /// to retrieve the handle of the current memory buffer and should free that memory.
        /// </para>
        /// <para>
        /// An edit control automatically reallocates the given buffer whenever it needs additional space for text,
        /// or it removes enough text so that additional space is no longer needed.
        /// </para>
        /// <para>
        /// Sending an <see cref="EM_SETHANDLE"/> message clears the undo buffer (<see cref="EM_CANUNDO"/> returns zero)
        /// and the internal modification flag (<see cref="EM_GETMODIFY"/> returns zero).
        /// The edit control window is redrawn.
        /// </para>
        /// <para>
        /// Rich Edit: The <see cref="EM_SETHANDLE"/> message is not supported.
        /// Rich edit controls do not store text as a simple array of characters.
        /// </para>
        /// </remarks>
        EM_SETHANDLE = 0x00BC,

        /// <summary>
        /// This message is not implemented.
        /// </summary>
        EM_SETHILITE = ECM_FIRST + 5,

        /// <summary>
        /// Sets the status flags that determine how an edit control interacts with the Input Method Editor (IME).
        /// </summary>
        /// <remarks>
        /// Rich Edit: The <see cref="EM_SETIMESTATUS"/> message is not supported.
        /// </remarks>
        EM_SETIMESTATUS = 0x00D8,

        /// <summary>
        /// Sets the text limit of an edit control.
        /// The text limit is the maximum amount of text, in TCHARs, that the user can type into the edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// For edit controls and Microsoft Rich Edit 1.0, bytes are used.
        /// For Microsoft Rich Edit 2.0 and later, characters are used.
        /// The <see cref="EM_SETLIMITTEXT"/> message is identical to the <see cref="EM_LIMITTEXT"/> message.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="EM_SETLIMITTEXT"/> message limits only the text the user can enter.
        /// It does not affect any text already in the edit control when the message is sent,
        /// nor does it affect the length of the text copied to the edit control by the <see cref="WM_SETTEXT"/> message.
        /// If an application uses the <see cref="WM_SETTEXT"/> message to place more text into an edit control
        /// than is specified in the <see cref="EM_SETLIMITTEXT"/> message, the user can edit the entire contents of the edit control.
        /// </para>
        /// <para>
        /// Before <see cref="EM_SETLIMITTEXT"/> is called,
        /// the default limit for the amount of text a user can enter in an edit control is 32,767 characters.
        /// </para>
        /// <para>
        /// For single-line edit controls, the text limit is either 0x7FFFFFFE bytes or the value of the wParam parameter, whichever is smaller.
        /// For multiline edit controls, this value is either 1 bytes or the value of the wParam parameter, whichever is smaller.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// Use the message <see cref="EM_EXLIMITTEXT"/> for text length values greater than 64,000.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETLIMITTEXT = EM_LIMITTEXT,

        /// <summary>
        /// Sets the widths of the left and right margins for an edit control.
        /// The message redraws the control to reflect the new margins.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Edit controls: You cannot use <see cref="EC_USEFONTINFO"/> in the wParam parameter, but you can use it in the lParam parameter.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// All rich edit versions support the use of <see cref="EC_USEFONTINFO"/> in the wParam parameter.
        /// However, only Microsoft Rich Edit 3.0 and later support the use of <see cref="EC_USEFONTINFO"/> in the lParam parameter.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETMARGINS = 0x00D3,

        /// <summary>
        /// Sets or clears the modification flag for an edit control.
        /// The modification flag indicates whether the text within the edit control has been modified.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The system automatically clears the modification flag to zero when the control is created.
        /// If the user changes the control's text, the system sets the flag to nonzero.
        /// You can send the <see cref="EM_GETMODIFY"/> message to the edit control to retrieve the current state of the flag.
        /// </para>
        /// <para>
        /// Rich Edit 1.0: Objects created without the <see cref="REO_DYNAMICSIZE"/> flag
        /// will lock in their extents when the modify flag is set to <see cref="FALSE"/>.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETMODIFY = 0x00B9,

        /// <summary>
        /// Sets or removes the password character for an edit control.
        /// When a password character is set, that character is displayed in place of the characters typed by the user.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// When an edit control receives the <see cref="EM_SETPASSWORDCHAR"/> message,
        /// the control redraws all visible characters using the character specified by the wParam parameter.
        /// If wParam is zero, the control redraws all visible characters using the characters typed by the user.
        /// </para>
        /// <para>
        /// If an edit control is created with the <see cref="ES_PASSWORD"/> style, the default password character is set to an asterisk (*).
        /// If an edit control is created without the <see cref="ES_PASSWORD"/> style, there is no password character.
        /// The <see cref="ES_PASSWORD"/> style is removed if an <see cref="EM_SETPASSWORDCHAR"/> message is sent with the wParam parameter set to zero.
        /// </para>
        /// <para>
        /// Edit controls: Multiline edit controls do not support the password style or messages.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 2.0 and later.
        /// Both single-line and multiline edit controls support the password style and messages.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETPASSWORDCHAR = 0x00CC,

        /// <summary>
        /// Sets or removes the read-only style (<see cref="ES_READONLY"/>) of an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <para>
        /// When an edit control has the <see cref="ES_READONLY"/> style, the user cannot change the text within the edit control.
        /// </para>
        /// <para>
        /// To determine whether an edit control has the <see cref="ES_READONLY"/> style,
        /// use the <see cref="GetWindowLong"/> function with the <see cref="GWL_STYLE"/> flag.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        EM_SETREADONLY = 0x00CF,

        /// <summary>
        /// Sets the formatting rectangle of a multiline edit control.
        /// The formatting rectangle is the limiting rectangle into which the control draws the text.
        /// The limiting rectangle is independent of the size of the edit control window.
        /// This message is processed only by multiline edit controls.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Setting lParam to <see cref="NULL"/> has no effect if a touch device is installed,
        /// or if <see cref="EM_SETRECT"/> is sent from a thread that has a hook installed (see <see cref="SetWindowsHookEx"/>).
        /// In these cases, lParam should contain a valid pointer to a <see cref="RECT"/> structure.
        /// </para>
        /// <para>
        /// The <see cref="EM_SETRECT"/> message causes the text of the edit control to be redrawn.
        /// To change the size of the formatting rectangle without redrawing the text, use the <see cref="EM_SETRECTNP"/> message.
        /// </para>
        /// <para>
        /// When an edit control is first created, the formatting rectangle is set to a default size.
        /// You can use the <see cref="EM_SETRECT"/> message to make the formatting rectangle larger or smaller than the edit control window.
        /// </para>
        /// <para>
        /// If the edit control does not have a horizontal scroll bar,
        /// and the formatting rectangle is set to be larger than the edit control window,
        /// lines of text exceeding the width of the edit control window
        /// (but smaller than the width of the formatting rectangle) are clipped instead of wrapped.
        /// </para>
        /// <para>
        /// If the edit control contains a border, the formatting rectangle is reduced by the size of the border.
        /// If you are adjusting the rectangle returned by an <see cref="EM_GETRECT"/> message,
        /// you must remove the size of the border before using the rectangle with the <see cref="EM_SETRECT"/> message.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// The formatting rectangle does not include the selection bar, which is an unmarked area to the left of each paragraph.
        /// When the user clicks in the selection bar, the corresponding line is selected.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETRECT = 0x00B3,

        /// <summary>
        /// Sets the formatting rectangle of a multiline edit control.
        /// The <see cref="EM_SETRECTNP"/> message is identical to the <see cref="EM_SETRECT"/> message,
        /// except that <see cref="EM_SETRECTNP"/> does not redraw the edit control window.
        /// </summary>
        /// <remarks>
        /// Rich Edit: Supported in Microsoft Rich Edit 3.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </remarks>
        EM_SETRECTNP = 0x00B4,

        /// <summary>
        /// Selects a range of characters in an edit control.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The start value can be greater than the end value.
        /// The lower of the two values specifies the character position of the first character in the selection.
        /// The higher value specifies the position of the first character beyond the selection.
        /// </para>
        /// <para>
        /// The start value is the anchor point of the selection, and the end value is the active end.
        /// If the user uses the SHIFT key to adjust the size of the selection,
        /// the active end can move but the anchor point remains the same.
        /// </para>
        /// <para>
        /// If the start is 0 and the end is -1, all the text in the edit control is selected.
        /// If the start is -1, any current selection is deselected.
        /// </para>
        /// <para>
        /// Edit controls: The control displays a flashing caret at the end position regardless of the relative values of start and end.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// <para>
        /// If the edit control has the <see cref="ES_NOHIDESEL"/> style, the selected text is highlighted regardless of whether the control has focus.
        /// Without the <see cref="ES_NOHIDESEL"/> style, the selected text is highlighted only when the edit control has the focus.
        /// </para>
        /// </remarks>
        EM_SETSEL = 0x00B1,

        /// <summary>
        /// The <see cref="EM_SETTABSTOPS"/> message sets the tab stops in a multiline edit control.
        /// When text is copied to the control, any tab character in the text causes space to be generated up to the next tab stop.
        /// This message is processed only by multiline edit controls.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The <see cref="EM_SETTABSTOPS"/> message does not automatically redraw the edit control window.
        /// If the application is changing the tab stops for text already in the edit control,
        /// it should call the <see cref="InvalidateRect"/> function to redraw the edit control window.
        /// </para>
        /// <para>
        /// The values specified in the array are in dialog template units,
        /// which are the device-independent units used in dialog box templates.
        /// To convert measurements from dialog template units to screen units (pixels), use the <see cref="MapDialogRect"/> function.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 3.0 and later.
        /// A rich edit control can have the maximum number of tab stops specified by MAX_TAB_STOPS.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETTABSTOPS = 0x00CB,

        /// <summary>
        /// Replaces an edit control's default Wordwrap function with an application-defined Wordwrap function.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A Wordwrap function scans a text buffer that contains text to be sent to the screen,
        /// looking for the first word that does not fit on the current screen line.
        /// The Wordwrap function places this word at the beginning of the next line on the screen.
        /// </para>
        /// <para>
        /// A Wordwrap function defines the point at which the system should break a line of text for multiline edit controls,
        /// usually at a space character that separates two words.
        /// Either a multiline or a single-line edit control might call this function
        /// when the user presses arrow keys in combination with the CTRL key to move the caret to the next word or previous word.
        /// The default Wordwrap function breaks a line of text at a space character.
        /// The application-defined function may define the Wordwrap to occur at a hyphen or a character other than the space character.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_SETWORDBREAKPROC = 0x00D0,

        /// <summary>
        /// The <see cref="EM_SHOWBALLOONTIP"/> message displays a balloon tip associated with an edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// To use this message, you must provide a manifest specifying Comclt32.dll version 6.0. For more information on manifests, see Enabling Visual Styles.
        /// </para>
        /// </remarks>
        EM_SHOWBALLOONTIP = ECM_FIRST + 3,

        /// <summary>
        /// Forces a single-line edit control to receive keyboard focus.
        /// You can send this message explicitly or by using the <see cref="Edit_TakeFocus"/> macro.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This message is ignored if the edit control is not a single-line edit control.
        /// </para>
        /// <para>
        /// If the edit control previously received an <see cref="EM_NOSETFOCUS"/> message,
        /// the edit control will appear to have the focus without actually having it; otherwise, the edit control will receive focus.
        /// </para>
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This message may not be supported in future versions of Windows.")]
        EM_TAKEFOCUS = ECM_FIRST + 8,

        /// <summary>
        /// This message undoes the last edit control operation in the control's undo queue.
        /// You can send this message to either an edit control or a rich edit control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Edit controls and Rich Edit 1.0: An undo operation can also be undone.
        /// For example, you can restore deleted text with the first <see cref="EM_UNDO"/> message,
        /// and remove the text again with a second <see cref="EM_UNDO"/> message as long as there is no intervening edit operation.
        /// </para>
        /// <para>
        /// Rich Edit 2.0 and later:
        /// The undo feature is multilevel so sending two <see cref="EM_UNDO"/> messages will undo the last two operations in the undo queue.
        /// To redo an operation, send the <see cref="EM_REDO"/> message.
        /// </para>
        /// <para>
        /// Rich Edit: Supported in Microsoft Rich Edit 1.0 and later.
        /// For information about the compatibility of rich edit versions with the various system versions, see About Rich Edit Controls.
        /// </para>
        /// </remarks>
        EM_UNDO = 0x00C7,
    }
}
