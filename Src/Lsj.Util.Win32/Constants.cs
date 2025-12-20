using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
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
        /// AC_SRC_OVER
        /// </summary>
        public const byte AC_SRC_OVER = 0;

        /// <summary>
        /// AC_SRC_ALPHA
        /// </summary>
        public const byte AC_SRC_ALPHA = 1;

        /// <summary>
        /// AD_COUNTERCLOCKWISE
        /// </summary>
        public const int AD_COUNTERCLOCKWISE = 1;

        /// <summary>
        /// AD_CLOCKWISE
        /// </summary>
        public const int AD_CLOCKWISE = 2;

        /// <summary>
        /// ANYSIZE_ARRAY
        /// </summary>
        public const int ANYSIZE_ARRAY = 1;

        /// <summary>
        /// ATTACH_PARENT_PROCESS
        /// </summary>
        public const uint ATTACH_PARENT_PROCESS = unchecked((uint)-1);

        /// <summary>
        /// AUDIT_ALLOW_NO_PRIVILEGE
        /// </summary>
        public const uint AUDIT_ALLOW_NO_PRIVILEGE = 0x1;

        /// <summary>
        /// AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD
        /// </summary>
        public const uint AUTHZ_ACCESS_CHECK_NO_DEEP_COPY_SD = 1;

        /// <summary>
        /// BROADCAST_QUERY_DENY
        /// </summary>
        public const int BROADCAST_QUERY_DENY = 0x424D5144;

        /// <summary>
        /// CACHE_FULLY_ASSOCIATIVE
        /// </summary>
        public const byte CACHE_FULLY_ASSOCIATIVE = 0xFF;

        /// <summary>
        /// CCHDEVICENAME
        /// </summary>
        public const int CCHDEVICENAME = 32;

        /// <summary>
        /// CCHFORMNAME
        /// </summary>
        public const int CCHFORMNAME = 32;

        /// <summary>
        /// CF_EMBEDSOURCE
        /// </summary>
        public const string CF_EMBEDSOURCE = "Embed Source";

        /// <summary>
        /// CF_EMBEDDEDOBJECT
        /// </summary>
        public const string CF_EMBEDDEDOBJECT = "Embedded Object";

        /// <summary>
        /// CF_FILENAME
        /// </summary>
        public const string CF_FILENAME = "FileName";

        /// <summary>
        /// CHILDID_SELF
        /// </summary>
        public const uint CHILDID_SELF = 0;

        /// <summary>
        /// COLE_DEFAULT_AUTHINFO
        /// </summary>
        public static readonly IntPtr COLE_DEFAULT_AUTHINFO = (IntPtr)(-1);

        /// <summary>
        /// COLE_DEFAULT_PRINCIPAL
        /// </summary>
        public static readonly IntPtr COLE_DEFAULT_PRINCIPAL = (IntPtr)(-1);

        /// <summary>
        /// CONDITION_VARIABLE_LOCKMODE_SHARED
        /// </summary>
        public const uint CONDITION_VARIABLE_LOCKMODE_SHARED = unchecked((uint)-1);

        /// <summary>
        /// CONSOLE_TEXTMODE_BUFFER
        /// </summary>
        public const uint CONSOLE_TEXTMODE_BUFFER = 1;

        /// <summary>
        /// CREATE_MUTEX_INITIAL_OWNER
        /// </summary>
        public const uint CREATE_MUTEX_INITIAL_OWNER = 1;

        /// <summary>
        /// CRITICAL_SECTION_NO_DEBUG_INFO
        /// </summary>
        public const uint CRITICAL_SECTION_NO_DEBUG_INFO = 0x01000000;

        /// <summary>
        /// CWF_CREATE_ONLY
        /// </summary>
        public const uint CWF_CREATE_ONLY = 0x00000001;

        /// <summary>
        /// DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION
        /// </summary>
        public const uint DEACTIVATE_ACTCTX_FLAG_FORCE_EARLY_DEACTIVATION = 1;

        /// <summary>
        /// DF_ALLOWOTHERACCOUNTHOOK
        /// </summary>
        public const uint DF_ALLOWOTHERACCOUNTHOOK = 0x0001;

        /// <summary>
        /// DLGWINDOWEXTRA
        /// </summary>
        public const int DLGWINDOWEXTRA = 30;

        /// <summary>
        /// DM_SPECVERSION
        /// </summary>
        public const ushort DM_SPECVERSION = 0x401;

        /// <summary>
        /// DN_DEFAULTPRN
        /// </summary>
        public const ushort DN_DEFAULTPRN = 0x0001;

        /// <summary>
        /// DWLP_DLGPROC
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_DLGPROC = DWLP_MSGRESULT + IntPtr.Size;

        /// <summary>
        /// DWLP_MSGRESULT
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_MSGRESULT = 0;

        /// <summary>
        /// DWLP_USER
        /// </summary>
        public static readonly GetWindowLongIndexes DWLP_USER = DWLP_DLGPROC + IntPtr.Size;

        /// <summary>
        /// DWM_SIT_DISPLAYFRAME
        /// </summary>
        public const uint DWM_SIT_DISPLAYFRAME = 0x00000001;

        /// <summary>
        /// ENUM_CURRENT_SETTINGS
        /// </summary>
        public static readonly DWORD ENUM_CURRENT_SETTINGS = (DWORD)(-1);

        /// <summary>
        /// ENUM_REGISTRY_SETTINGS
        /// </summary>
        public static readonly DWORD ENUM_REGISTRY_SETTINGS = (DWORD)(-2);

        /// <summary>
        /// EXCEPTION_CONTINUE_EXECUTION
        /// </summary>
        public const int EXCEPTION_CONTINUE_EXECUTION = unchecked(-1);

        /// <summary>
        /// EXCEPTION_CONTINUE_SEARCH
        /// </summary>
        public const int EXCEPTION_CONTINUE_SEARCH = 0;

        /// <summary>
        /// EXCEPTION_EXECUTE_HANDLER
        /// </summary>
        public const int EXCEPTION_EXECUTE_HANDLER = 1;

        /// <summary>
        /// EXCEPTION_MAXIMUM_PARAMETERS
        /// </summary>
        public const int EXCEPTION_MAXIMUM_PARAMETERS = 15;

        /// <summary>
        /// FIBER_FLAG_FLOAT_SWITCH
        /// </summary>
        public const uint FIBER_FLAG_FLOAT_SWITCH = 0x1;

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
        /// GDI_ERROR
        /// </summary>
        public const uint GDI_ERROR = 0xFFFFFFFF;

        /// <summary>
        /// GDICOMMENT_IDENTIFIER
        /// </summary>
        public const uint GDICOMMENT_IDENTIFIER = 0x43494447;

        /// <summary>
        /// HBMMENU_CALLBACK
        /// </summary>
        public static readonly HBITMAP HBMMENU_CALLBACK = (IntPtr)(-1);

        /// <summary>
        /// HBMMENU_MBAR_CLOSE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_CLOSE = (IntPtr)5;

        /// <summary>
        /// HBMMENU_MBAR_CLOSE_D
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_CLOSE_D = (IntPtr)6;

        /// <summary>
        /// HBMMENU_MBAR_MINIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_MINIMIZE = (IntPtr)3;

        /// <summary>
        /// HBMMENU_MBAR_MINIMIZE_D
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_MINIMIZE_D = (IntPtr)7;

        /// <summary>
        /// HBMMENU_MBAR_RESTORE
        /// </summary>
        public static readonly HBITMAP HBMMENU_MBAR_RESTORE = (IntPtr)2;

        /// <summary>
        /// HBMMENU_POPUP_CLOSE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_CLOSE = (IntPtr)8;

        /// <summary>
        /// HBMMENU_POPUP_MAXIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_MAXIMIZE = (IntPtr)10;

        /// <summary>
        /// HBMMENU_POPUP_MINIMIZE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_MINIMIZE = (IntPtr)11;

        /// <summary>
        /// HBMMENU_POPUP_RESTORE
        /// </summary>
        public static readonly HBITMAP HBMMENU_POPUP_RESTORE = (IntPtr)9;

        /// <summary>
        /// HBMMENU_SYSTEM
        /// </summary>
        public static readonly HBITMAP HBMMENU_SYSTEM = (IntPtr)1;

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
        /// HGDI_ERROR
        /// </summary>
        public static readonly IntPtr HGDI_ERROR = new IntPtr(-1);

        /// <summary>
        /// HOVER_DEFAULT
        /// </summary>
        public const uint HOVER_DEFAULT = 0xFFFFFFFF;

        /// <summary>
        /// HWND_BROADCAST
        /// </summary>
        public static readonly HWND HWND_BROADCAST = new IntPtr(0xFFFF);

        /// <summary>
        /// HWND_MESSAGE
        /// </summary>
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);

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
        /// INIT_ONCE_CTX_RESERVED_BITS
        /// </summary>
        public const int INIT_ONCE_CTX_RESERVED_BITS = 2;

        /// <summary>
        /// INVALID_FILE_SIZE
        /// </summary>
        public const uint INVALID_FILE_SIZE = 0xFFFFFFFF;

        /// <summary>
        /// INVALID_HANDLE_VALUE
        /// </summary>
        public readonly static IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        /// <summary>
        /// INVALID_SET_FILE_POINTER
        /// </summary>
        public const uint INVALID_SET_FILE_POINTER = unchecked((uint)-1);

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
        /// LF_FACESIZE
        /// </summary>
        public const int LF_FACESIZE = 32;

        /// <summary>
        /// LF_FULLFACESIZE
        /// </summary>
        public const int LF_FULLFACESIZE = 64;

        /// <summary>
        /// LINE_LEN
        /// </summary>
        public const int LINE_LEN = 256;

        /// <summary>
        /// <para>
        /// Name of an invariant locale that provides stable locale and calendar data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public const string LOCALE_NAME_INVARIANT = "";

        /// <summary>
        /// <para>
        /// Maximum length of a locale name. The maximum number of characters allowed for this string is 85, including a terminating null character.
        /// Your application must use the constant for the maximum locale name length, instead of hard-coding the value "85". 
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public const int LOCALE_NAME_MAX_LENGTH = 85;

        /// <summary>
        /// <para>
        /// Name of the current operating system locale.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public const string LOCALE_NAME_SYSTEM_DEFAULT = "!x-sys-default-locale";

        /// <summary>
        /// <para>
        /// Name of the current user locale, matching the preference set in the regional and language options portion of Control Panel.
        /// This locale can be different from the locale for the current user interface language.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/intl/locale-name-constants"/>
        /// </para>
        /// </summary>
        public const string LOCALE_NAME_USER_DEFAULT = null;

        /// <summary>
        /// LPSTR_TEXTCALLBACK
        /// </summary>
        public static readonly IntPtr LPSTR_TEXTCALLBACK = (IntPtr)(-1);

        /// <summary>
        /// MAILSLOT_WAIT_FOREVER
        /// </summary>
        public const uint MAILSLOT_WAIT_FOREVER = unchecked((uint)-1);

        /// <summary>
        /// MAX_COMPUTERNAME_LENGTH
        /// </summary>
        public const int MAX_COMPUTERNAME_LENGTH = 15;

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
        /// MM_MAX_NUMAXES
        /// </summary>
        public const int MM_MAX_NUMAXES = 16;

        /// <summary>
        /// MM_MAX_AXES_NAMELEN
        /// </summary>
        public const int MM_MAX_AXES_NAMELEN = 16;

        /// <summary>
        /// NMPWAIT_NOWAIT
        /// </summary>
        public const uint NMPWAIT_NOWAIT = 0x00000001;

        /// <summary>
        /// NMPWAIT_USE_DEFAULT_WAIT
        /// </summary>
        public const uint NMPWAIT_USE_DEFAULT_WAIT = 0x00000000;

        /// <summary>
        /// NMPWAIT_WAIT_FOREVER
        /// </summary>
        public const uint NMPWAIT_WAIT_FOREVER = 0xffffffff;

        /// <summary>
        /// NULL
        /// </summary>
        public readonly static IntPtr NULL = IntPtr.Zero;

        /// <summary>
        /// NUMA_NO_PREFERRED_NODE
        /// </summary>
        public const uint NUMA_NO_PREFERRED_NODE = 0xffffffff;

        /// <summary>
        /// OFS_MAXPATHNAME
        /// </summary>
        public const int OFS_MAXPATHNAME = 128;

        /// <summary>
        /// PIPE_CLIENT_END
        /// </summary>
        public const uint PIPE_CLIENT_END = 0x00000000;

        /// <summary>
        /// PIPE_SERVER_END
        /// </summary>
        public const uint PIPE_SERVER_END = 0x00000001;

        /// <summary>
        /// PIPE_UNLIMITED_INSTANCES
        /// </summary>
        public const uint PIPE_UNLIMITED_INSTANCES = 255;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_GROUP_AFFINITY = (UIntPtr)0x30003;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_HANDLE_LIST
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_HANDLE_LIST = (UIntPtr)0x20002;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_IDEAL_PROCESSOR = (UIntPtr)0x30005;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_MITIGATION_POLICY = (UIntPtr)0x20007;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_PARENT_PROCESS
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PARENT_PROCESS = (UIntPtr)0x20000;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_PREFERRED_NODE
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PREFERRED_NODE = (UIntPtr)0x20004;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_UMS_THREAD
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_UMS_THREAD = (UIntPtr)0x30006;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_SECURITY_CAPABILITIES = (UIntPtr)0x20009;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_PROTECTION_LEVEL = (UIntPtr)0x2000B;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_CHILD_PROCESS_POLICY = (UIntPtr)0x2000E;

        /// <summary>
        /// PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY
        /// </summary>
        public static readonly UIntPtr PROC_THREAD_ATTRIBUTE_DESKTOP_APP_POLICY = (UIntPtr)0x20012;

        /// <summary>
        /// PROCESS_NAME_NATIVE
        /// </summary>
        public const uint PROCESS_NAME_NATIVE = 0x00000001;

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
        /// SOCKET_ERROR
        /// </summary>
        public const int SOCKET_ERROR = -1;

        /// <summary>
        /// SRWLOCK_INIT
        /// </summary>
        public readonly static SRWLOCK SRWLOCK_INIT = new SRWLOCK();

        /// <summary>
        /// STD_ERROR_HANDLE 
        /// </summary>
        public const uint STD_ERROR_HANDLE = unchecked((uint)-12);

        /// <summary>
        /// STD_INPUT_HANDLE
        /// </summary>
        public const uint STD_INPUT_HANDLE = unchecked((uint)-10);

        /// <summary>
        /// STD_OUTPUT_HANDLE
        /// </summary>
        public const uint STD_OUTPUT_HANDLE = unchecked((uint)-11);

        /// <summary>
        /// STILL_ACTIVE
        /// </summary>
        public const uint STILL_ACTIVE = (uint)NTSTATUS.STATUS_PENDING;

        /// <summary>
        /// TRANSACTION_DO_NOT_PROMOTE
        /// </summary>
        public const uint TRANSACTION_DO_NOT_PROMOTE = 0x00000001;

        /// <summary>
        /// STORAGE_INFO_OFFSET_UNKNOWN 
        /// </summary>
        public const uint STORAGE_INFO_OFFSET_UNKNOWN = 0xFFFFFFFF;

        /// <summary>
        /// SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE 
        /// </summary>
        public const uint SYMBOLIC_LINK_FLAG_ALLOW_UNPRIVILEGED_CREATE = 0x2;

        /// <summary>
        /// SYMBOLIC_LINK_FLAG_DIRECTORY 
        /// </summary>
        public const uint SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1;

        /// <summary>
        /// USER_TIMER_MAXIMUM
        /// </summary>
        public const uint USER_TIMER_MAXIMUM = 0x7FFFFFFF;

        /// <summary>
        /// USER_TIMER_MINIMUM
        /// </summary>
        public const uint USER_TIMER_MINIMUM = 0x0000000A;

        /// <summary>
        /// WAVE_MAPPER
        /// </summary>
        public const uint WAVE_MAPPER = unchecked((uint)-1);

        /// <summary>
        /// WHEEL_DELTA
        /// </summary>
        public static int WHEEL_DELTA = 120;

        /// <summary>
        /// WRITE_WATCH_FLAG_RESET
        /// </summary>
        public const uint WRITE_WATCH_FLAG_RESET = 0x01;

        /// <summary>
        /// XBUTTON1
        /// </summary>
        public const ushort XBUTTON1 = 0x0001;

        /// <summary>
        /// XBUTTON2
        /// </summary>
        public const ushort XBUTTON2 = 0x0002;
    }
}
