using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="FINDREPLACE"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-findreplacew"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum FINDREPLACEFlags : uint
    {
        /// <summary>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the dialog box is closing.
        /// When you receive a message with this flag set, the dialog box handle
        /// returned by the <see cref="FindText"/> or <see cref="ReplaceText"/> function is no longer valid.
        /// </summary>
        FR_DIALOGTERM = 0x00000040,

        /// <summary>
        /// If set, the Down button of the direction radio buttons in a Find dialog box is selected indicating
        /// that you should search from the current location to the end of the document.
        /// If not set, the Up button is selected so you should search to the beginning of the document.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </summary>
        FR_DOWN = 0x00000001,

        /// <summary>
        /// Enables the hook function specified in the <see cref="FINDREPLACE.lpfnHook"/> member.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        FR_ENABLEHOOK = 0x00000100,

        /// <summary>
        /// Indicates that the <see cref="FINDREPLACE.hInstance"/> and <see cref="FINDREPLACE.lpTemplateName"/> members
        /// specify a dialog box template to use in place of the default template.
        /// This flag is used only to initialize the dialog box.
        /// </summary>
        FR_ENABLETEMPLATE = 0x00000200,

        /// <summary>
        /// Indicates that the hInstance member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores the <see cref="FINDREPLACE.lpTemplateName"/> member if this flag is specified.
        /// </summary>
        FR_ENABLETEMPLATEHANDLE = 0x00002000,

        /// <summary>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the user clicked the Find Next button in a Find or Replace dialog box.
        /// The lpstrFindWhat member specifies the string to search for.
        /// </summary>
        FR_FINDNEXT = 0x00000008,

        /// <summary>
        /// If set when initializing a Find dialog box, hides the search direction radio buttons.
        /// </summary>
        FR_HIDEUPDOWN = 0x00004000,

        /// <summary>
        /// If set when initializing a Find or Replace dialog box, hides the Match Case check box.
        /// </summary>
        FR_HIDEMATCHCASE = 0x00008000,

        /// <summary>
        /// If set when initializing a Find or Replace dialog box, hides the Match Whole Word Only check box.
        /// </summary>
        FR_HIDEWHOLEWORD = 0x00010000,

        /// <summary>
        /// If set, the Match Case check box is selected indicating that the search should be case-sensitive.
        /// If not set, the check box is unselected so the search should be case-insensitive.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </summary>
        FR_MATCHCASE = 0x00000004,

        /// <summary>
        /// If set when initializing a Find or Replace dialog box, disables the Match Case check box.
        /// </summary>
        FR_NOMATCHCASE = 0x00000800,

        /// <summary>
        /// If set when initializing a Find dialog box, disables the search direction radio buttons.
        /// </summary>
        FR_NOUPDOWN = 0x00000400,

        /// <summary>
        /// If set when initializing a Find or Replace dialog box, disables the Whole Word check box.
        /// </summary>
        FR_NOWHOLEWORD = 0x00001000,

        /// <summary>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the user clicked the Replace button in a Replace dialog box.
        /// The <see cref="FINDREPLACE.lpstrFindWhat"/> member specifies the string to be replaced
        /// and the <see cref="FINDREPLACE.lpstrReplaceWith"/> member specifies the replacement string.
        /// </summary>
        FR_REPLACE = 0x00000010,

        /// <summary>
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates that the user clicked the Replace All button in a Replace dialog box.
        /// The <see cref="FINDREPLACE.lpstrFindWhat"/> member specifies the string to be replaced
        /// and the <see cref="FINDREPLACE.lpstrReplaceWith"/> member specifies the replacement string.
        /// </summary>
        FR_REPLACEALL = 0x00000020,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="FINDREPLACE.hwndOwner"/> member must specify the window
        /// to receive the <see cref="HELPMSGSTRING"/> registered messages that the dialog box sends when the user clicks the Help button.
        /// </summary>
        FR_SHOWHELP = 0x00000080,

        /// <summary>
        /// If set, the Match Whole Word Only check box is selected indicating that you should search only for whole words that match the search string.
        /// If not set, the check box is unselected so you should also search for word fragments that match the search string.
        /// You can set this flag to initialize the dialog box.
        /// If set in a <see cref="FINDMSGSTRING"/> message, indicates the user's selection.
        /// </summary>
        FR_WHOLEWORD = 0x00000002,
    }
}
