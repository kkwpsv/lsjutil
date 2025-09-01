using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Enums.FindReplaceDialogFlags;
using static Lsj.Util.Win32.Enums.OpenFileDialogFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// ANYSIZE_ARRAY
        /// </summary>
        public const int ANYSIZE_ARRAY = 1;

        /// <summary>
        /// AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD
        /// </summary>
        public const uint AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD = 1;

        /// <summary>
        /// AC_SRC_OVER
        /// </summary>
        public const byte AC_SRC_OVER = 0;

        /// <summary>
        /// AC_SRC_ALPHA
        /// </summary>
        public const byte AC_SRC_ALPHA = 1;

        /// <summary>
        /// AUDIT_ALLOW_NO_PRIVILEGE
        /// </summary>
        public const uint AUDIT_ALLOW_NO_PRIVILEGE = 0x1;

        /// <summary>
        /// CACHE_FULLY_ASSOCIATIVE
        /// </summary>
        public const byte CACHE_FULLY_ASSOCIATIVE = 0xFF;

        /// <summary>
        /// EXCEPTION_MAXIMUM_PARAMETERS
        /// </summary>
        public const int EXCEPTION_MAXIMUM_PARAMETERS = 15;

        /// <summary>
        /// <para>
        /// An Open or Save As dialog box sends the <see cref="FILEOKSTRING"/> registered message to your hook procedure,
        /// OFNHookProc, when the user specifies a file name and clicks the OK button.
        /// The hook procedure can accept the file name and allow the dialog box to close,
        /// or reject the file name and force the dialog box to remain open.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to an <see cref="OPENFILENAME"/> structure.
        /// The <see cref="OPENFILENAME.lpstrFile"/> member of this structure
        /// contains the drive, path, and file name specified by the user.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// If the hook procedure returns zero, the Open or Save As dialog box accepts the specified file name and closes.
        /// </para>
        /// <para>
        /// If the hook procedure returns a nonzero value,
        /// the Open or Save As dialog box rejects the specified file name and remains open.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/fileokstring"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The hook procedure must specify the <see cref="FILEOKSTRING"/> constant
        /// in a call to the <see cref="RegisterWindowMessage"/> function to get the identifier for the message sent by the dialog box.
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog. " +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        public const string FILEOKSTRING = "commdlg_FileNameOK";

        /// <summary>
        /// <para>
        /// A Find or Replace dialog box sends the <see cref="FINDMSGSTRING"/> registered message
        /// to the window procedure of its owner window
        /// when the user clicks the Find Next, Replace, or Replace All button, or closes the dialog box.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="FINDREPLACE"/> structure.
        /// The members of this structure contain the latest user input,
        /// including the string to search for, the replacement string (if any) and the search-and-replacement options.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/findmsgstring"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You must specify the <see cref="FINDMSGSTRING"/> constant in a call to the <see cref="RegisterWindowMessage"/> function
        /// to get the identifier for the message sent by the dialog box.
        /// </para>
        /// <para>
        /// When you create the dialog box, use the <see cref="FINDREPLACE.hwndOwner"/> member
        /// of the <see cref="FINDREPLACE"/> structure to identify the window to receive <see cref="FINDMSGSTRING"/> messages.
        /// </para>
        /// <para>
        /// The <see cref="FINDREPLACE.Flags"/> member of the <see cref="FINDREPLACE"/> structure
        /// includes one of the following flags to indicate the event that caused the message.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FR_DIALOGTERM"/> (0x00000040)
        /// </term>
        /// <term>
        /// The dialog box is closing. After the owner window processes this message,
        /// a handle to the dialog box is no longer valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_FINDNEXT"/> (0x00000008)
        /// </term>
        /// <term>
        /// The user clicked the Find Next button in a Find or Replace dialog box.
        /// The <see cref="FINDREPLACE.lpstrFindWhat"/> member specifies the string to search for.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_REPLACE"/> (0x00000010)
        /// </term>
        /// <term>
        /// The user clicked the Replace button in a Replace dialog box.
        /// The <see cref="FINDREPLACE.lpstrFindWhat"/> member specifies the string to replace
        /// and the <see cref="FINDREPLACE.lpstrReplaceWith"/> member specifies the replacement string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_REPLACEALL"/> (0x00000020)
        /// </term>
        /// <term>
        /// The user clicked the Replace All button in a Replace dialog box.
        /// The <see cref="FINDREPLACE.lpstrFindWhat"/> member specifies the string to replace
        /// and the <see cref="FINDREPLACE.lpstrReplaceWith"/> member specifies the replacement string.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For a Find Next or Replace All message,
        /// the <see cref="FINDREPLACE.Flags"/> member can include one or more of the following flags to indicate the search options.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Flag
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="FR_DOWN"/> (0x00000001)
        /// </term>
        /// <term>
        /// If set, the Down button of the direction radio buttons is selected
        /// indicating that user wants to search from the current location to the end of the document.
        /// If <see cref="FR_DOWN"/> is not set,
        /// the Up button is selected so the user wants to search to the beginning of the document.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_MATCHCASE"/> (0x00000004)
        /// </term>
        /// <term>
        /// If set, the Match Case check box is selected indicating that the user wants the search to be case-sensitive.
        /// If <see cref="FR_MATCHCASE"/> is not set, the check box is unselected so the search should be case-insensitive.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="FR_WHOLEWORD"/> (0x00000002)
        /// </term>
        /// <term>
        /// If set, the Match Whole Word Only check box is selected indicating
        /// that the user wants to search only for whole words that match the search string.
        /// If <see cref="FR_WHOLEWORD"/> is not set,
        /// the check box is unselected so you should also search for word fragments that match the search string.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        public const string FINDMSGSTRING = "commdlg_FindReplace";

        /// <summary>
        /// GDICOMMENT_IDENTIFIER
        /// </summary>
        public const uint GDICOMMENT_IDENTIFIER = 0x43494447;

        /// <summary>
        /// <para>
        /// A common dialog box sends the <see cref="HELPMSGSTRING"/> registered message
        /// to the window procedure of its owner window when the user clicks the Help button.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// A handle to the common dialog box.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to the initialization structure for the common dialog box.
        /// This structure can be a <see cref="CHOOSECOLOR"/>, <see cref="CHOOSEFONT"/>, <see cref="FINDREPLACE"/>,
        /// <see cref="OPENFILENAME"/>, <see cref="PRINTDLG"/> or <see cref="PAGESETUPDLG"/> structure.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/helpmsgstring"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// You must specify the <see cref="HELPMSGSTRING"/> constant in a call to the <see cref="RegisterWindowMessage"/> function
        /// to get the identifier for the message sent by the dialog box.
        /// </para>
        /// <para>
        /// When you create the dialog box, use the hwndOwner member of the initialization structure
        /// to identify the window to receive <see cref="HELPMSGSTRING"/> messages.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        public const string HELPMSGSTRING = "commdlg_help";

        /// <summary>
        /// HOVER_DEFAULT
        /// </summary>
        public const uint HOVER_DEFAULT = 0xFFFFFFFF;

        /// <summary>
        /// I_IMAGECALLBACK
        /// </summary>
        public const int I_IMAGECALLBACK = -1;

        /// <summary>
        /// I_IMAGENONE
        /// </summary>
        public const int I_IMAGENONE = -2;

        /// <summary>
        /// INFINITE
        /// </summary>
        public const uint INFINITE = 0xFFFFFFFF;

        /// <summary>
        /// INFOTIPSIZE
        /// </summary>
        public const int INFOTIPSIZE = 1024;

        /// <summary>
        /// INVALID_HANDLE_VALUE
        /// </summary>
        public readonly static IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        /// <summary>
        /// <para>
        /// An Open or Save As dialog box sends the <see cref="LBSELCHSTRING"/> registered message
        /// to your hook procedure when the selection changes in any of the list boxes or combo boxes of the dialog box.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// The identifier of the list box or combo box in which the selection changed.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// The low-order word specifies the item number of the selected string in the list box or combo box.
        /// The high-order word specifies the type of selection change.
        /// This parameter can be one of the following values.
        /// </para>
        /// <para>
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
        /// <see cref="CD_LBSELCHANGE"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// The item is the only item selected in a single-selection list box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CD_LBSELADD"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The item is one of the items selected in a multiple-selection list box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CD_LBSELSUB"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The item is no longer selected in a multiple-selection list box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="CD_LBSELNOITEMS"/>
        /// </para>
        /// <para>
        /// -1
        /// </para>
        /// </term>
        /// <term>
        /// No items exist in a multiple-selection list box.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// This message has no return value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/lbselchstring"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// The hook procedure must specify the <see cref="LBSELCHSTRING"/> constant
        /// in a call to the <see cref="RegisterWindowMessage"/> function to get the identifier for the message sent by the dialog box.
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog. " +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        public const string LBSELCHSTRING = "commdlg_LBSelChangedNotify";

        /// <summary>
        /// LINE_LEN
        /// </summary>
        public const int LINE_LEN = 256;

        /// <summary>
        /// LPSTR_TEXTCALLBACK
        /// </summary>
        public static readonly IntPtr LPSTR_TEXTCALLBACK = (IntPtr)(-1);

        /// <summary>
        /// MAX_DEFAULTCHAR
        /// </summary>
        public const int MAX_DEFAULTCHAR = 2;

        /// <summary>
        /// MAX_LEADBYTES
        /// </summary>
        public const int MAX_LEADBYTES = 12;

        /// <summary>
        /// MAX_MODULE_NAME32
        /// </summary>
        public const int MAX_MODULE_NAME32 = 255;

        /// <summary>
        /// MAX_PATH
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// MAX_SHUTDOWN_TIMEOUT
        /// </summary>
        public const int MAX_SHUTDOWN_TIMEOUT = 10 * 365 * 24 * 60 * 60;

        /// <summary>
        /// MAXIMUM_PROCESSORS
        /// </summary>
        public const int MAXIMUM_PROCESSORS = 64;

        /// <summary>
        /// MAXIMUM_SUSPEND_COUNT
        /// </summary>
        public const int MAXIMUM_SUSPEND_COUNT = 0x7F;

        /// <summary>
        /// NULL
        /// </summary>
        public readonly static IntPtr NULL = IntPtr.Zero;

        /// <summary>
        /// <para>
        /// An Open or Save As dialog box sends the <see cref="SHAREVISTRING"/> registered message to your hook procedure,
        /// OFNHookProc, if a sharing violation occurs for the selected file when the user clicks the OK button.
        /// </para>
        /// <para>
        /// Parameters
        /// </para>
        /// <para>
        /// wParam
        /// </para>
        /// <para>
        /// This parameter is not used.
        /// </para>
        /// <para>
        /// lParam
        /// </para>
        /// <para>
        /// A pointer to a <see cref="OPENFILENAME"/> structure.
        /// The <see cref="OPENFILENAME.lpstrFile"/> member of this structure contains the file name that caused the sharing violation.
        /// </para>
        /// <para>
        /// Return value
        /// </para>
        /// <para>
        /// The hook procedure must return one of the following values to indicate how the dialog box should handle the sharing violation.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code/value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_SHAREFALLTHROUGH"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// Accept the file name
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_SHARENOWARN"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// Reject the file name but do not warn the user.
        /// The application is responsible for displaying a warning message.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_SHAREWARN"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// Reject the file name and displays a warning message (the same result as if there were no hook procedure).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/dlgbox/sharevistring"/>
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// The hook procedure must specify the <see cref="SHAREVISTRING"/> constant
        /// in a call to the <see cref="RegisterWindowMessage"/> function to get the identifier for the message sent by the dialog box.
        /// </para>
        /// <para>
        /// The dialog box sends the <see cref="SHAREVISTRING"/> registered message
        /// only if you did not specify the <see cref="OFN_SHAREAWARE"/> flag
        /// in the <see cref="OPENFILENAME.Flags"/> member of the <see cref="OPENFILENAME"/> structure when you created the dialog.
        /// </para>
        /// <para>
        /// If the hook procedure returns an undefined value, the dialog box responds as if <see cref="OFN_SHAREWARN"/> was returned.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog. " +
            "We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        public const string SHAREVISTRING = "commdlg_ShareViolation";

        /// <summary>
        /// STILL_ACTIVE
        /// </summary>
        public const uint STILL_ACTIVE = (uint)NTSTATUS.STATUS_PENDING;

        /// <summary>
        /// USER_TIMER_MAXIMUM
        /// </summary>
        public const uint USER_TIMER_MAXIMUM = 0x7FFFFFFF;

        /// <summary>
        /// USER_TIMER_MINIMUM
        /// </summary>
        public const uint USER_TIMER_MINIMUM = 0x0000000A;

        /// <summary>
        /// WHEEL_DELTA
        /// </summary>
        public static int WHEEL_DELTA = 120;
    }
}
