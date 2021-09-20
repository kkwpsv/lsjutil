using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommDlgExtendedErrorCodes;
using static Lsj.Util.Win32.Enums.OPENFILENAMEFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> functions
    /// use to initialize an Open or Save As dialog box.
    /// After the user closes the dialog box, the system returns information about the user's selection in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commdlg/ns-commdlg-openfilenamew"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For compatibility reasons, the Places Bar is hidden if <see cref="Flags"/> is set to <see cref="OFN_ENABLEHOOK"/>
    /// and <see cref="lStructSize"/> is <see cref="OPENFILENAME_SIZE_VERSION_400"/>.
    /// </remarks>
    [Obsolete("Starting with Windows Vista, the Open and Save As common dialog boxes have been superseded by the Common Item Dialog." +
        " We recommended that you use the Common Item Dialog API instead of these dialog boxes from the Common Dialog Box Library.")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OPENFILENAME
    {
        /// <summary>
        /// OFN_EX_NOPLACESBAR
        /// </summary>
        public static readonly DWORD OFN_EX_NOPLACESBAR = 1;

        /// <summary>
        /// The length, in bytes, of the structure.
        /// Use <code>sizeof(OPENFILENAME)</code> for this parameter.
        /// </summary>
        public DWORD lStructSize;

        /// <summary>
        /// A handle to the window that owns the dialog box.
        /// This member can be any valid window handle, or it can be <see cref="NULL"/> if the dialog box has no owner.
        /// </summary>
        public HWND hwndOwner;

        /// <summary>
        /// If the <see cref="OFN_ENABLETEMPLATEHANDLE"/> flag is set in the <see cref="Flags"/> member,
        /// <see cref="hInstance"/> is a handle to a memory object containing a dialog box template.
        /// If the <see cref="OFN_ENABLETEMPLATE"/> flag is set, hInstance is a handle to a module
        /// that contains a dialog box template named by the <see cref="lpTemplateName"/> member.
        /// If neither flag is set, this member is ignored.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set, the system uses the template to create an old-style dialog box
        /// that replaces the default dialog box.
        /// </summary>
        public HINSTANCE hInstance;

        /// <summary>
        /// A buffer containing pairs of null-terminated filter strings.
        /// The last string in the buffer must be terminated by two NULL characters.
        /// The first string in each pair is a display string that describes the filter (for example, "Text Files"),
        /// and the second string specifies the filter pattern (for example, ".TXT").
        /// To specify multiple filter patterns for a single display string, use a semicolon to separate the patterns (for example, ".TXT;.DOC;.BAK").
        /// A pattern string can be a combination of valid file name characters and the asterisk (*) wildcard character.
        /// Do not include spaces in the pattern string.
        /// The system does not change the order of the filters.
        /// It displays them in the File Types combo box in the order specified in <see cref="lpstrFilter"/>.
        /// If lpstrFilter is NULL, the dialog box does not display any filters.
        /// In the case of a shortcut, if no filter is set, <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> retrieve
        /// the name of the .lnk file, not its target.
        /// This behavior is the same as setting the <see cref="OFN_NODEREFERENCELINKS"/> flag in the <see cref="Flags"/> member.
        /// To retrieve a shortcut's target without filtering, use the string "All Files\0*.*\0\0".
        /// </summary>
        public IntPtr lpstrFilter;

        /// <summary>
        /// A static buffer that contains a pair of null-terminated filter strings for preserving the filter pattern chosen by the user.
        /// The first string is your display string that describes the custom filter, and the second string is the filter pattern selected by the user.
        /// The first time your application creates the dialog box, you specify the first string, which can be any nonempty string.
        /// When the user selects a file, the dialog box copies the current filter pattern to the second string.
        /// The preserved filter pattern can be one of the patterns specified in the <see cref="lpstrFilter"/> buffer,
        /// or it can be a filter pattern typed by the user.
        /// The system uses the strings to initialize the user-defined file filter the next time the dialog box is created.
        /// If the <see cref="nFilterIndex"/> member is zero, the dialog box uses the custom filter.
        /// If this member is <see cref="NULL"/>, the dialog box does not preserve user-defined filter patterns.
        /// If this member is not <see cref="NULL"/>, the value of the <see cref="nMaxCustFilter"/> member must specify the size,
        /// in characters, of the <see cref="lpstrCustomFilter"/> buffer.
        /// </summary>
        public IntPtr lpstrCustomFilter;

        /// <summary>
        /// The size, in characters, of the buffer identified by <see cref="lpstrCustomFilter"/>.
        /// This buffer should be at least 40 characters long.
        /// This member is ignored if <see cref="lpstrCustomFilter"/> is <see cref="NULL"/> or points to a <see cref="NULL"/> string.
        /// </summary>
        public DWORD nMaxCustFilter;

        /// <summary>
        /// The index of the currently selected filter in the File Types control.
        /// The buffer pointed to by <see cref="lpstrFilter"/> contains pairs of strings that define the filters.
        /// The first pair of strings has an index value of 1, the second pair 2, and so on.
        /// An index of zero indicates the custom filter specified by <see cref="lpstrCustomFilter"/>.
        /// You can specify an index on input to indicate the initial filter description and filter pattern for the dialog box.
        /// When the user selects a file, <see cref="nFilterIndex"/> returns the index of the currently displayed filter.
        /// If <see cref="nFilterIndex"/> is zero and <see cref="lpstrCustomFilter"/> is <see cref="NULL"/>,
        /// the system uses the first filter in the <see cref="lpstrFilter"/> buffer.
        /// If all three members are zero or <see cref="NULL"/>, the system does not use any filters and does not show any files
        /// in the file list control of the dialog box.
        /// </summary>
        public DWORD nFilterIndex;

        /// <summary>
        /// The file name used to initialize the File Name edit control.
        /// The first character of this buffer must be <see cref="NULL"/> if initialization is not necessary.
        /// When the <see cref="GetOpenFileName"/> or <see cref="GetSaveFileName"/> function returns successfully,
        /// this buffer contains the drive designator, path, file name, and extension of the selected file.
        /// If the <see cref="OFN_ALLOWMULTISELECT"/> flag is set and the user selects multiple files,
        /// the buffer contains the current directory followed by the file names of the selected files.
        /// For Explorer-style dialog boxes, the directory and file name strings are <see cref="NULL"/> separated,
        /// with an extra <see cref="NULL"/> character after the last file name.
        /// For old-style dialog boxes, the strings are space separated and the function uses short file names for file names with spaces.
        /// You can use the <see cref="FindFirstFile"/> function to convert between long and short file names.
        /// If the user selects only one file, the <see cref="lpstrFile"/> string does not have a separator between the path and file name.
        /// If the buffer is too small, the function returns <see cref="FALSE"/>
        /// and the <see cref="CommDlgExtendedError"/> function returns <see cref="FNERR_BUFFERTOOSMALL"/>.
        /// In this case, the first two bytes of the <see cref="lpstrFile"/> buffer contain the required size, in bytes or characters.
        /// </summary>
        public IntPtr lpstrFile;

        /// <summary>
        /// The size, in characters, of the buffer pointed to by <see cref="lpstrFile"/>.
        /// The buffer must be large enough to store the path and file name string or strings, including the terminating NULL character.
        /// The <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> functions return <see cref="FALSE"/>
        /// if the buffer is too small to contain the file information.
        /// The buffer should be at least 256 characters long.
        /// </summary>
        public DWORD nMaxFile;

        /// <summary>
        /// The file name and extension (without path information) of the selected file.
        /// This member can be <see cref="NULL"/>.
        /// </summary>
        public IntPtr lpstrFileTitle;

        /// <summary>
        /// The size, in characters, of the buffer pointed to by <see cref="lpstrFileTitle"/>.
        /// This member is ignored if <see cref="lpstrFileTitle"/> is <see cref="NULL"/>.
        /// </summary>
        public DWORD nMaxFileTitle;

        /// <summary>
        /// The initial directory. The algorithm for selecting the initial directory varies on different platforms.
        /// Windows 7:
        /// If <see cref="lpstrInitialDir"/> has the same value as was passed the first time the application used an Open or Save As dialog box,
        /// the path most recently selected by the user is used as the initial directory.
        /// Otherwise, if <see cref="lpstrFile"/> contains a path, that path is the initial directory.
        /// Otherwise, if <see cref="lpstrInitialDir"/> is not <see cref="NULL"/>, it specifies the initial directory.
        /// If <see cref="lpstrInitialDir"/> is <see cref="NULL"/> and the current directory contains any files of the specified filter types,
        /// the initial directory is the current directory.
        /// Otherwise, the initial directory is the personal files directory of the current user.
        /// Otherwise, the initial directory is the Desktop folder.
        /// Windows 2000/XP/Vista:
        /// If <see cref="lpstrFile"/> contains a path, that path is the initial directory.
        /// Otherwise, <see cref="lpstrInitialDir"/> specifies the initial directory.
        /// Otherwise, if the application has used an Open or Save As dialog box in the past,
        /// the path most recently used is selected as the initial directory.
        /// However, if an application is not run for a long time, its saved selected path is discarded.
        /// If <see cref="lpstrInitialDir"/> is <see cref="NULL"/> and the current directory contains any files of the specified filter types,
        /// the initial directory is the current directory.
        /// Otherwise, the initial directory is the personal files directory of the current user.
        /// Otherwise, the initial directory is the Desktop folder.
        /// </summary>
        public IntPtr lpstrInitialDir;

        /// <summary>
        /// A string to be placed in the title bar of the dialog box.
        /// If this member is <see cref="NULL"/>, the system uses the default title (that is, Save As or Open).
        /// </summary>
        public IntPtr lpstrTitle;

        /// <summary>
        /// A set of bit flags you can use to initialize the dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be a combination of the following flags.
        /// <see cref="OFN_ALLOWMULTISELECT"/>, <see cref="OFN_CREATEPROMPT"/>, <see cref="OFN_DONTADDTORECENT"/>, <see cref="OFN_ENABLEHOOK"/>,
        /// <see cref="OFN_ENABLEINCLUDENOTIFY"/>, <see cref="OFN_ENABLESIZING"/>, <see cref="OFN_ENABLETEMPLATE"/>, <see cref="OFN_ENABLETEMPLATEHANDLE"/>,
        /// <see cref="OFN_EXPLORER"/>, <see cref="OFN_EXTENSIONDIFFERENT"/>, <see cref="OFN_FILEMUSTEXIST"/>, <see cref="OFN_FORCESHOWHIDDEN"/>,
        /// <see cref="OFN_HIDEREADONLY"/>, <see cref="OFN_LONGNAMES"/>, <see cref="OFN_NOCHANGEDIR"/>, <see cref="OFN_NODEREFERENCELINKS"/>,
        /// <see cref="OFN_NOLONGNAMES"/>, <see cref="OFN_NONETWORKBUTTON"/>, <see cref="OFN_NOREADONLYRETURN"/>, <see cref="OFN_NOTESTFILECREATE"/>,
        /// <see cref="OFN_NOVALIDATE"/>, <see cref="OFN_OVERWRITEPROMPT"/>, <see cref="OFN_PATHMUSTEXIST"/>, <see cref="OFN_READONLY"/>,
        /// <see cref="OFN_SHAREAWARE"/>, <see cref="OFN_SHOWHELP"/>
        /// </summary>
        public OPENFILENAMEFlags Flags;

        /// <summary>
        /// The zero-based offset, in characters, from the beginning of the path to the file name in the string pointed to by <see cref="lpstrFile"/>.
        /// For the ANSI version, this is the number of bytes; for the Unicode version, this is the number of characters.
        /// For example, if <see cref="lpstrFile"/> points to the following string, "c:\dir1\dir2\file.ext",
        /// this member contains the value 13 to indicate the offset of the "file.ext" string.
        /// If the user selects more than one file, <see cref="nFileOffset"/> is the offset to the first file name.
        /// </summary>
        public WORD nFileOffset;

        /// <summary>
        /// The zero-based offset, in characters, from the beginning of the path to the file name extension
        /// in the string pointed to by <see cref="lpstrFile"/>.
        /// For the ANSI version, this is the number of bytes; for the Unicode version, this is the number of characters.
        /// Usually the file name extension is the substring which follows the last occurrence of the dot (".") character.
        /// For example, txt is the extension of the filename readme.txt, html the extension of readme.txt.html.
        /// Therefore, if lpstrFile points to the string "c:\dir1\dir2\readme.txt", this member contains the value 20.
        /// If <see cref="lpstrFile"/> points to the string "c:\dir1\dir2\readme.txt.html", this member contains the value 24.
        /// If <see cref="lpstrFile"/> points to the string "c:\dir1\dir2\readme.txt.html.", this member contains the value 29.
        /// If <see cref="lpstrFile"/> points to a string that does not contain any "." character such as "c:\dir1\dir2\readme", this member contains zero.
        /// </summary>
        public WORD nFileExtension;

        /// <summary>
        /// The default extension.
        /// <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> append this extension to the file name if the user fails to type an extension.
        /// This string can be any length, but only the first three characters are appended.
        /// The string should not contain a period (.).
        /// If this member is <see cref="NULL"/> and the user fails to type an extension, no extension is appended.
        /// </summary>
        public IntPtr lpstrDefExt;

        /// <summary>
        /// Application-defined data that the system passes to the hook procedure identified by the <see cref="lpfnHook"/> member.
        /// When the system sends the <see cref="WM_INITDIALOG"/> message to the hook procedure,
        /// the message's lParam parameter is a pointer to the <see cref="OPENFILENAME"/> structure specified when the dialog box was created.
        /// The hook procedure can use this pointer to get the <see cref="lCustData"/> value.
        /// </summary>
        public LPARAM lCustData;

        /// <summary>
        /// A pointer to a hook procedure.
        /// This member is ignored unless the Flags member includes the <see cref="OFN_ENABLEHOOK"/> flag.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set in the <see cref="Flags"/> member,
        /// <see cref="lpfnHook"/> is a pointer to an OFNHookProcOldStyle hook procedure that receives messages intended for the dialog box.
        /// The hook procedure returns <see cref="FALSE"/> to pass a message to the default dialog box procedure
        /// or <see cref="TRUE"/> to discard the message.
        /// If <see cref="OFN_EXPLORER"/> is set, <see cref="lpfnHook"/> is a pointer to an OFNHookProc hook procedure.
        /// The hook procedure receives notification messages sent from the dialog box.
        /// The hook procedure also receives messages for any additional controls that you defined by specifying a child dialog template.
        /// The hook procedure does not receive messages intended for the standard controls of the default dialog box.
        /// </summary>
        public LPOFNHOOKPROC lpfnHook;

        /// <summary>
        /// The name of the dialog template resource in the module identified by the <see cref="hInstance"/> member.
        /// For numbered dialog box resources, this can be a value returned by the <see cref="MAKEINTRESOURCE"/> macro.
        /// This member is ignored unless the <see cref="OFN_ENABLETEMPLATE"/> flag is set in the <see cref="Flags"/> member.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set, the system uses the template to create an old-style dialog box
        /// that replaces the default dialog box.
        /// </summary>
        public IntPtr lpTemplateName;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr lpEditInfo;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr lpstrPrompt;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public IntPtr pvReserved;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public DWORD dwReserved;

        /// <summary>
        /// A set of bit flags you can use to initialize the dialog box. Currently, this member can be zero or the following flag.
        /// <see cref="OFN_EX_NOPLACESBAR"/>
        /// </summary>
        public DWORD FlagsEx;
    }
}
