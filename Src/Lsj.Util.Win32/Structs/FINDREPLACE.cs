using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.FINDREPLACEFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="FindText"/> and <see cref="ReplaceText"/> functions use to initialize the Find and Replace dialog boxes.
    /// The <see cref="FINDMSGSTRING"/> registered message uses this structure to pass the user's search or replacement input
    /// to the owner window of a Find or Replace dialog box.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-findreplacew"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct FINDREPLACE
    {
        /// <summary>
        /// The length, in bytes, of the structure.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// The window procedure of the specified window receives <see cref="FINDMSGSTRING"/> messages from the dialog box.
        /// This member can be any valid window handle, but it must not be <see cref="NULL"/>.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// If the <see cref="FR_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/>,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="FR_ENABLETEMPLATE"/> flag is set, hInstance is a handle to a module
        /// that contains a dialog box template named by the <see cref="lpTemplateName"/> member.
        /// If neither flag is set, this member is ignored.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// <para>
        /// A set of bit flags that you can use to initialize the dialog box.
        /// The dialog box sets these flags when it sends the <see cref="FINDMSGSTRING"/> registered message to indicate the user's input.
        /// This member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_DIALOGTERM"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the dialog box is closing.
        /// When you receive a message with this flag set, the dialog box handle
        /// returned by the <see cref="FindText"/> or <see cref="ReplaceText"/> function is no longer valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_DOWN"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If set, the Down button of the direction radio buttons in a Find dialog box is selected
        /// indicating that you should search from the current location to the end of the document.
        /// If not set, Up button is selected so you should search to the beginning of the document.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_ENABLEHOOK"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook function specified in the <see cref="lpfnHook"/> member.
        /// This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_ENABLETEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> and <see cref="lpTemplateName"/> members
        /// specify a dialog box template to use in place of the default template.
        /// This flag is used only to initialize the dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_ENABLETEMPLATEHANDLE"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the <see cref="hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="lpTemplateName"/> member if this flag is specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_FINDNEXT"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// If set in a <see cref="FINDMSGSTRING"/> message,
        /// indicates that the user clicked the Find Next button in a Find or Replace dialog box.
        /// The lpstrFindWhat member specifies the string to search for.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_HIDEUPDOWN"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find dialog box, hides the search direction radio buttons.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_HIDEMATCHCASE"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find or Replace dialog box, hides the Match Case check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_HIDEWHOLEWORD"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find or Replace dialog box, hides the Match Whole Word Only check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_MATCHCASE"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// If set, the Match Case check box is selected indicating that the search should be case-sensitive.
        /// If not set, the check box is unselected so the search should be case-insensitive.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_NOMATCHCASE"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find or Replace dialog box, disables the Match Case check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_NOUPDOWN"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find dialog box, disables the search direction radio buttons.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_NOWHOLEWORD"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// If set when initializing a Find or Replace dialog box, disables the Whole Word check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_REPLACE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the user clicked the Replace button in a Replace dialog box.
        /// The <see cref="lpstrFindWhat"/> member specifies the string to be replaced
        /// and the <see cref="lpstrReplaceWith"/> member specifies the replacement string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_REPLACEALL"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the user clicked the Replace All button in a Replace dialog box.
        /// The <see cref="lpstrFindWhat"/> member specifies the string to be replaced
        /// and the <see cref="lpstrReplaceWith"/> member specifies the replacement string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_SHOWHELP"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FR_WHOLEWORD"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// If set, the Match Whole Word Only check box is selected indicating that you should search only for whole words that match the search string.
        /// If not set, the check box is unselected so you should also search for word fragments that match the search string.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public FINDREPLACEFlags Flags;

        /// <summary>
        /// The search string that the user typed in the Find What edit control.
        /// You must dynamically allocate the buffer or use a global or static array so it does not go out of scope before the dialog box closes.
        /// The buffer should be at least 80 characters long.
        /// If the buffer contains a string when you initialize the dialog box, the string is displayed in the Find What edit control.
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_FINDNEXT"/> flag,
        /// <see cref="lpstrFindWhat"/> contains the string to search for.
        /// The <see cref="FR_DOWN"/>, <see cref="FR_WHOLEWORD"/>, and <see cref="FR_MATCHCASE"/> flags indicate the direction and type of search.
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_REPLACE"/> or <see cref="FR_REPLACE"/> flags,
        /// <see cref="lpstrFindWhat"/> contains the string to be replaced.
        /// </summary>
        public IntPtr lpstrFindWhat;

        /// <summary>
        /// <para>
        /// The replacement string that the user typed in the Replace With edit control.
        /// You must dynamically allocate the buffer or use a global or static array so it does not go out of scope before the dialog box closes.
        /// If the buffer contains a string when you initialize the dialog box, the string is displayed in the Replace With edit control.
        /// </para>
        /// <para>
        /// If a <see cref="FINDMSGSTRING"/> message specifies the <see cref="FR_REPLACE"/> or <see cref="FR_REPLACEALL"/> flags,
        /// <see cref="lpstrReplaceWith"/> contains the replacement string .
        /// </para>
        /// <para>
        /// The <see cref="FindText"/> function ignores this member.
        /// </para>
        /// </summary>
        public IntPtr lpstrReplaceWith;

        /// <summary>
        /// The length, in bytes, of the buffer pointed to by the <see cref="lpstrFindWhat"/> member.
        /// </summary>
        public WORD wFindWhatLen;

        /// <summary>
        /// The length, in bytes, of the buffer pointed to by the <see cref="lpstrReplaceWith"/> member.
        /// </summary>
        public WORD wReplaceWithLen;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="FINDREPLACE"/> structure specified when the dialog was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to an <see cref="LPFRHOOKPROC"/> hook procedure that can process messages intended for the dialog box.
        /// This member is ignored unless the <see cref="FR_ENABLEHOOK"/> flag is set in the <see cref="Flags"/> member.
        /// If the hook procedure returns <see cref="FALSE"/> in response to the <see cref="WM_INITDIALOG"/> message,
        /// the hook procedure must display the dialog box or else the dialog box will not be shown.
        /// To do this, first perform any other paint operations, and then call the <see cref="ShowWindow"/> and <see cref="UpdateWindow"/> functions.
        /// </summary>
        public LPFRHOOKPROC lpfnHook;

        /// <summary>
        /// The name of the dialog box template resource in the module identified by the <see cref="hInstance"/> member.
        /// This template is substituted for the standard dialog box template.
        /// For numbered dialog box resources, this can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="FR_ENABLETEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// </summary>
        public IntPtr lpTemplateName;
    }
}
