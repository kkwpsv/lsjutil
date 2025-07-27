using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.CSIDL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommDlgExtendedErrorCodes;
using static Lsj.Util.Win32.Enums.CommonDialogBoxNotifications;
using static Lsj.Util.Win32.Enums.ListBoxStyles;
using static Lsj.Util.Win32.Enums.OPENFILENAMEFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information that the <see cref="GetOpenFileName"/> and <see cref="GetSaveFileName"/> functions
    /// use to initialize an Open or Save As dialog box.
    /// After the user closes the dialog box, the system returns information about the user's selection in this structure.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commdlg/ns-commdlg-openfilenamew"/>
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
        /// <para>
        /// A buffer containing pairs of null-terminated filter strings.
        /// The last string in the buffer must be terminated by two <see cref="NULL"/> characters.
        /// </para>
        /// <para>
        /// The first string in each pair is a display string that describes the filter (for example, "Text Files"),
        /// and the second string specifies the filter pattern (for example, ".TXT").
        /// To specify multiple filter patterns for a single display string,
        /// use a semicolon to separate the patterns (for example, ".TXT;.DOC;.BAK").
        /// A pattern string can be a combination of valid file name characters and the asterisk (*) wildcard character.
        /// Do not include spaces in the pattern string.
        /// </para>
        /// <para>
        /// The system does not change the order of the filters.
        /// It displays them in the File Types combo box in the order specified in lpstrFilter.
        /// </para>
        /// <para>
        /// If <see cref="lpstrFilter"/> is <see cref="NULL"/>, the dialog box does not display any filters.
        /// </para>
        /// <para>
        /// In the case of a shortcut, if no filter is set, <see cref="GetOpenFileName"/>
        /// and <see cref="GetSaveFileName"/> retrieve the name of the .lnk file, not its target.
        /// This behavior is the same as setting the <see cref="OFN_NODEREFERENCELINKS"/> flag in the <see cref="Flags"/> member.
        /// To retrieve a shortcut's target without filtering, use the string <code>"All Files\0*.*\0\0"</code>.
        /// </para>
        /// </summary>
        public IntPtr lpstrFilter;

        /// <summary>
        /// <para>
        /// A static buffer that contains a pair of null-terminated filter strings for preserving the filter pattern chosen by the user.
        /// The first string is your display string that describes the custom filter,
        /// and the second string is the filter pattern selected by the user.
        /// The first time your application creates the dialog box, you specify the first string, which can be any nonempty string.
        /// When the user selects a file, the dialog box copies the current filter pattern to the second string.
        /// The preserved filter pattern can be one of the patterns specified in the <see cref="lpstrFilter"/> buffer,
        /// or it can be a filter pattern typed by the user.
        /// The system uses the strings to initialize the user-defined file filter the next time the dialog box is created.
        /// If the <see cref="nFilterIndex"/> member is zero, the dialog box uses the custom filter.
        /// </para>
        /// <para>
        /// If this member is <see cref="NULL"/>, the dialog box does not preserve user-defined filter patterns.
        /// </para>
        /// <para>
        /// If this member is not <see cref="NULL"/>, the value of the <see cref="nMaxCustFilter"/> member must specify the size,
        /// in characters, of the <see cref="lpstrCustomFilter"/> buffer.
        /// </para>
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
        /// <para>
        /// The file name used to initialize the File Name edit control.
        /// The first character of this buffer must be <see cref="NULL"/> if initialization is not necessary.
        /// When the <see cref="GetOpenFileName"/> or <see cref="GetSaveFileName"/> function returns successfully,
        /// this buffer contains the drive designator, path, file name, and extension of the selected file.
        /// </para>
        /// <para>
        /// If the <see cref="OFN_ALLOWMULTISELECT"/> flag is set and the user selects multiple files,
        /// the buffer contains the current directory followed by the file names of the selected files.
        /// For Explorer-style dialog boxes, the directory and file name strings are <see cref="NULL"/> separated,
        /// with an extra <see cref="NULL"/> character after the last file name.
        /// For old-style dialog boxes, the strings are space separated and the function uses short file names for file names with spaces.
        /// You can use the <see cref="FindFirstFile"/> function to convert between long and short file names.
        /// If the user selects only one file, the <see cref="lpstrFile"/> string does not have a separator between the path and file name.
        /// </para>
        /// <para>
        /// If the buffer is too small, the function returns <see cref="FALSE"/>
        /// and the <see cref="CommDlgExtendedError"/> function returns <see cref="FNERR_BUFFERTOOSMALL"/>.
        /// In this case, the first two bytes of the <see cref="lpstrFile"/> buffer contain the required size, in bytes or characters.
        /// </para>
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
        /// <para>
        /// The initial directory. The algorithm for selecting the initial directory varies on different platforms.
        /// </para>
        /// <para>
        /// Windows 7:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// If <see cref="lpstrInitialDir"/> has the same value as was passed the first time 
        /// the application used an Open or Save As dialog box, the path most recently selected by the user is used as the initial directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, if <see cref="lpstrFile"/> contains a path, that path is the initial directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, if <see cref="lpstrInitialDir"/> is not <see cref="NULL"/>, it specifies the initial directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <see cref="lpstrInitialDir"/> is <see cref="NULL"/> and the current directory contains any files of the specified filter types,
        /// the initial directory is the current directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, the initial directory is the personal files directory of the current user.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, the initial directory is the Desktop folder.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// Windows 2000/XP/Vista:
        /// </para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// If <see cref="lpstrFile"/> contains a path, that path is the initial directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, <see cref="lpstrInitialDir"/> specifies the initial directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, if the application has used an Open or Save As dialog box in the past,
        /// the path most recently used is selected as the initial directory.
        /// However, if an application is not run for a long time, its saved selected path is discarded.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If <see cref="lpstrInitialDir"/> is <see cref="NULL"/> and the current directory contains any files of the specified filter types,
        /// the initial directory is the current directory.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, the initial directory is the personal files directory of the current user.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Otherwise, the initial directory is the Desktop folder.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public IntPtr lpstrInitialDir;

        /// <summary>
        /// A string to be placed in the title bar of the dialog box.
        /// If this member is <see cref="NULL"/>, the system uses the default title (that is, Save As or Open).
        /// </summary>
        public IntPtr lpstrTitle;

        /// <summary>
        /// <para>
        /// A set of bit flags you can use to initialize the dialog box.
        /// When the dialog box returns, it sets these flags to indicate the user's input.
        /// This member can be a combination of the following flags.
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
        /// <see cref="OFN_ALLOWMULTISELECT"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The File Name list box allows multiple selections.
        /// If you also set the <see cref="OFN_EXPLORER"/> flag, the dialog box uses the Explorer-style user interface;
        /// otherwise, it uses the old-style user interface.
        /// </para>
        /// <para>
        /// If the user selects more than one file, the <see cref="lpstrFile"/> buffer
        /// returns the path to the current directory followed by the file names of the selected files.
        /// The <see cref="nFileOffset"/> member is the offset, in bytes or characters,
        /// to the first file name, and the <see cref="nFileExtension"/> member is not used.
        /// For Explorer-style dialog boxes, the directory and file name strings are <see cref="NULL"/> separated,
        /// with an extra <see cref="NULL"/> character after the last file name.
        /// This format enables the Explorer-style dialog boxes to return long file names that include spaces.
        /// For old-style dialog boxes, the directory and file name strings are separated by spaces
        /// and the function uses short file names for file names with spaces.
        /// You can use the <see cref="FindFirstFile"/> function to convert between long and short file names.
        /// </para>
        /// <para>
        /// If you specify a custom template for an old-style dialog box,
        /// the definition of the File Name list box must contain the <see cref="LBS_EXTENDEDSEL"/> value.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_CREATEPROMPT"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// If the user specifies a file that does not exist, this flag causes the dialog box to prompt the user for permission to create the file.
        /// If the user chooses to create the file, the dialog box closes and the function returns the specified name;
        /// otherwise, the dialog box remains open.
        /// If you use this flag with the <see cref="OFN_ALLOWMULTISELECT"/> flag,
        /// the dialog box allows the user to specify only one nonexistent file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_DONTADDTORECENT"/>
        /// </para>
        /// <para>
        /// 0x02000000
        /// </para>
        /// </term>
        /// <term>
        /// Prevents the system from adding a link to the selected file in the file system directory
        /// that contains the user's most recently used documents.
        /// To retrieve the location of this directory,
        /// call the <see cref="SHGetSpecialFolderLocation"/> function with the <see cref="CSIDL_RECENT"/> flag.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_ENABLEHOOK"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// Enables the hook function specified in the <see cref="lpfnHook"/> member.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_ENABLEINCLUDENOTIFY"/>
        /// </para>
        /// <para>
        /// 0x00400000
        /// </para>
        /// </term>
        /// <term>
        /// Causes the dialog box to send <see cref="CDN_INCLUDEITEM"/> notification messages to your OFNHookProc hook procedure when the user opens a folder.
        /// The dialog box sends a notification for each item in the newly opened folder.
        /// These messages enable you to control which items the dialog box displays in the folder's item list.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_ENABLESIZING"/>
        /// </para>
        /// <para>
        /// 0x00800000
        /// </para>
        /// </term>
        /// <term>
        /// Enables the Explorer-style dialog box to be resized using either the mouse or the keyboard.
        /// By default, the Explorer-style Open and Save As dialog boxes allow the dialog box to be resized regardless of whether this flag is set.
        /// This flag is necessary only if you provide a hook procedure or custom template.
        /// The old-style dialog box does not permit resizing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_ENABLETEMPLATE"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="lpTemplateName"/> member is a pointer to the name of a dialog template resource
        /// in the module identified by the <see cref="hInstance"/> member.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set,
        /// the system uses the template to create an old-style dialog box that replaces the default dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_ENABLETEMPLATEHANDLE"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="hInstance"/> member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores <see cref="lpTemplateName"/> if this flag is specified.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set,
        /// the system uses the template to create an old-style dialog box that replaces the default dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_EXPLORER"/>
        /// </para>
        /// <para>
        /// 0x00080000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that any customizations made to the Open or Save As dialog box use the Explorer-style customization methods.
        /// For more information, see Explorer-Style Hook Procedures and Explorer-Style Custom Templates.
        /// </para>
        /// <para>
        /// By default, the Open and Save As dialog boxes use the Explorer-style user interface regardless of whether this flag is set.
        /// This flag is necessary only if you provide a hook procedure or custom template, or set the <see cref="OFN_ALLOWMULTISELECT"/> flag.
        /// </para>
        /// <para>
        /// If you want the old-style user interface, omit the <see cref="OFN_EXPLORER"/> flag
        /// and provide a replacement old-style template or hook procedure.
        /// If you want the old style but do not need a custom template or hook procedure,
        /// simply provide a hook procedure that always returns <see cref="FALSE"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_EXTENSIONDIFFERENT"/>
        /// </para>
        /// <para>
        /// 0x00000400
        /// </para>
        /// </term>
        /// <term>
        /// The user typed a file name extension that differs from the extension specified by <see cref="lpstrDefExt"/>.
        /// The function does not use this flag if <see cref="lpstrDefExt"/> is <see cref="NULL"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_FILEMUSTEXIST"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// The user can type only names of existing files in the File Name entry field.
        /// If this flag is specified and the user enters an invalid name,
        /// the dialog box procedure displays a warning in a message box.
        /// If this flag is specified, the <see cref="OFN_PATHMUSTEXIST"/> flag is also used.
        /// This flag can be used in an Open dialog box.
        /// It cannot be used with a Save As dialog box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_FORCESHOWHIDDEN"/>
        /// </para>
        /// <para>
        /// 0x10000000
        /// </para>
        /// </term>
        /// <term>
        /// Forces the showing of system and hidden files, thus overriding the user setting to show or not show hidden files.
        /// However, a file that is marked both system and hidden is not shown.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_HIDEREADONLY"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// Hides the Read Only check box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_LONGNAMES"/>
        /// </para>
        /// <para>
        /// 0x00200000
        /// </para>
        /// </term>
        /// <term>
        /// For old-style dialog boxes, this flag causes the dialog box to use long file names.
        /// If this flag is not specified, or if the <see cref="OFN_ALLOWMULTISELECT"/> flag is also set,
        /// old-style dialog boxes use short file names (8.3 format) for file names with spaces.
        /// Explorer-style dialog boxes ignore this flag and always display long file names.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NOCHANGEDIR"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Restores the current directory to its original value if the user changed the directory while searching for files.
        /// </para>
        /// <para>
        /// This flag is ineffective for <see cref="GetOpenFileName"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NODEREFERENCELINKS"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// Directs the dialog box to return the path and file name of the selected shortcut (.LNK) file.
        /// If this value is not specified, the dialog box returns the path and file name of the file referenced by the shortcut.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NOLONGNAMES"/>
        /// </para>
        /// <para>
        /// 0x00040000
        /// </para>
        /// </term>
        /// <term>
        /// For old-style dialog boxes, this flag causes the dialog box to use short file names (8.3 format).
        /// Explorer-style dialog boxes ignore this flag and always display long file names.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NONETWORKBUTTON"/>
        /// </para>
        /// <para>
        /// 0x00020000
        /// </para>
        /// </term>
        /// <term>
        /// Hides and disables the Network button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NOREADONLYRETURN"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// The returned file does not have the Read Only check box selected and is not in a write-protected directory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NOTESTFILECREATE"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// The file is not created before the dialog box is closed.
        /// This flag should be specified if the application saves the file on a create-nonmodify network share.
        /// When an application specifies this flag, the library does not check for write protection,
        /// a full disk, an open drive door, or network protection.
        /// Applications using this flag must perform file operations carefully,
        /// because a file cannot be reopened once it is closed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_NOVALIDATE"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// The common dialog boxes allow invalid characters in the returned file name.
        /// Typically, the calling application uses a hook procedure that checks the file name by using the <see cref="FILEOKSTRING"/> message.
        /// If the text box in the edit control is empty or contains nothing but spaces, the lists of files and directories are updated.
        /// If the text box in the edit control contains anything else,
        /// <see cref="nFileOffset"/> and <see cref="nFileExtension"/> are set to values generated by parsing the text.
        /// No default extension is added to the text, nor is text copied to the buffer specified by <see cref="lpstrFileTitle"/>.
        /// If the value specified by <see cref="nFileOffset"/> is less than zero, the file name is invalid.
        /// Otherwise, the file name is valid, and <see cref="nFileExtension"/> and <see cref="nFileOffset"/> can be used
        /// as if the <see cref="OFN_NOVALIDATE"/> flag had not been specified.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_OVERWRITEPROMPT"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// Causes the Save As dialog box to generate a message box if the selected file already exists.
        /// The user must confirm whether to overwrite the file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_PATHMUSTEXIST"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// The user can type only valid paths and file names.
        /// If this flag is used and the user types an invalid path and file name in the File Name entry field,
        /// the dialog box function displays a warning in a message box.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_READONLY"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// Causes the Read Only check box to be selected initially when the dialog box is created.
        /// This flag indicates the state of the Read Only check box when the dialog box is closed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_SHAREAWARE"/>
        /// </para>
        /// <para>
        /// 0x00004000
        /// </para>
        /// </term>
        /// <term>
        /// Specifies that if a call to the <see cref="OpenFile"/> function fails because of a network sharing violation,
        /// the error is ignored and the dialog box returns the selected file name.
        /// If this flag is not set, the dialog box notifies your hook procedure
        /// when a network sharing violation occurs for the file name specified by the user.
        /// If you set the <see cref="OFN_EXPLORER"/> flag, the dialog box sends the <see cref="CDN_SHAREVIOLATION"/> message to the hook procedure.
        /// If you do not set <see cref="OFN_EXPLORER"/>, the dialog box sends the <see cref="SHAREVISTRING"/> registered message to the hook procedure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="OFN_SHOWHELP"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button
        /// . An Explorer-style dialog box sends a <see cref="CDN_HELP"/> notification message
        /// to your hook procedure when the user clicks the Help button.
        /// </term>
        /// </item>
        /// </list>
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
        /// <para>
        /// A pointer to a hook procedure.
        /// This member is ignored unless the <see cref="Flags"/> member includes the <see cref="OFN_ENABLEHOOK"/> flag.
        /// </para>
        /// <para>
        /// If the <see cref="OFN_EXPLORER"/> flag is not set in the <see cref="Flags"/> member,
        /// <see cref="lpfnHook"/> is a pointer to an <see cref="OFNHookProcOldStyle"/> hook procedure that receives messages intended for the dialog box. The hook procedure returns <see cref="FALSE"/> to pass a message to the default dialog box procedure or <see cref="TRUE"/> to discard the message.
        /// </para>
        /// <para>
        /// If <see cref="OFN_EXPLORER"/> is set, lpfnHook is a pointer to an <see cref="OFNHookProc"/> hook procedure.
        /// The hook procedure receives notification messages sent from the dialog box.
        /// The hook procedure also receives messages for any additional controls that you defined by specifying a child dialog template.
        /// The hook procedure does not receive messages intended for the standard controls of the default dialog box.
        /// </para>
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
        /// This member is reserved.
        /// </summary>
        public IntPtr pvReserved;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public DWORD dwReserved;

        /// <summary>
        /// <para>
        /// A set of bit flags you can use to initialize the dialog box.
        /// Currently, this member can be zero or the following flag.
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
        /// <see cref="OFN_EX_NOPLACESBAR"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// If this flag is set, the places bar is not displayed.
        /// If this flag is not set, Explorer-style dialog boxes include a places bar containing icons for commonly-used folders, such as Favorites and Desktop.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public DWORD FlagsEx;
    }
}
