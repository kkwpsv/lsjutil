using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Comdlg32;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CommonDialogBoxNotifications;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="OPENFILENAME"/> Flags
    /// </summary>
    public enum OPENFILENAMEFlags : uint
    {
        /// <summary>
        /// The File Name list box allows multiple selections.
        /// If you also set the <see cref="OFN_EXPLORER"/> flag, the dialog box uses the Explorer-style user interface;
        /// otherwise, it uses the old-style user interface.
        /// If the user selects more than one file, the <see cref="OPENFILENAME.lpstrFile"/> buffer returns the path
        /// to the current directory followed by the file names of the selected files.
        /// The <see cref="OPENFILENAME.nFileOffset"/> member is the offset, in bytes or characters, to the first file name,
        /// and the <see cref="OPENFILENAME.nFileExtension"/> member is not used.
        /// For Explorer-style dialog boxes, the directory and file name strings are <see cref="NULL"/> separated,
        /// with an extra <see cref="NULL"/> character after the last file name.
        /// This format enables the Explorer-style dialog boxes to return long file names that include spaces.
        /// For old-style dialog boxes, the directory and file name strings are separated by spaces
        /// and the function uses short file names for file names with spaces.
        /// You can use the <see cref="FindFirstFile"/> function to convert between long and short file names.
        /// If you specify a custom template for an old-style dialog box,
        /// the definition of the File Name list box must contain the <see cref="LBS_EXTENDEDSEL"/> value.
        /// </summary>
        OFN_ALLOWMULTISELECT = 0x00000200,

        /// <summary>
        /// If the user specifies a file that does not exist, this flag causes the dialog box to prompt the user for permission to create the file.
        /// If the user chooses to create the file, the dialog box closes and the function returns the specified name;
        /// otherwise, the dialog box remains open.
        /// If you use this flag with the <see cref="OFN_ALLOWMULTISELECT"/> flag, the dialog box allows the user to specify only one nonexistent file.
        /// </summary>
        OFN_CREATEPROMPT = 0x00002000,

        /// <summary>
        /// Prevents the system from adding a link to the selected file in the file system directory that contains the user's most recently used documents.
        /// To retrieve the location of this directory, call the <see cref="SHGetSpecialFolderLocation"/> function with the <see cref="CSIDL_RECENT"/> flag.
        /// </summary>
        OFN_DONTADDTORECENT = 0x02000000,

        /// <summary>
        /// Enables the hook function specified in the <see cref="OPENFILENAME.lpfnHook"/> member.
        /// </summary>
        OFN_ENABLEHOOK = 0x00000020,

        /// <summary>
        /// Causes the dialog box to send <see cref="CDN_INCLUDEITEM"/> notification messages
        /// to your OFNHookProc hook procedure when the user opens a folder.
        /// The dialog box sends a notification for each item in the newly opened folder.
        /// These messages enable you to control which items the dialog box displays in the folder's item list.
        /// </summary>
        OFN_ENABLEINCLUDENOTIFY = 0x00400000,

        /// <summary>
        /// Enables the Explorer-style dialog box to be resized using either the mouse or the keyboard.
        /// By default, the Explorer-style Open and Save As dialog boxes allow the dialog box to be resized regardless of whether this flag is set.
        /// This flag is necessary only if you provide a hook procedure or custom template.
        /// The old-style dialog box does not permit resizing.
        /// </summary>
        OFN_ENABLESIZING = 0x00800000,

        /// <summary>
        /// The lpTemplateName member is a pointer to the name of a dialog template resource
        /// in the module identified by the <see cref="OPENFILENAME.hInstance"/> member.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set, the system uses the template to create an old-style dialog box
        /// that replaces the default dialog box.
        /// </summary>
        OFN_ENABLETEMPLATE = 0x00000040,

        /// <summary>
        /// The hInstance member identifies a data block that contains a preloaded dialog box template.
        /// The system ignores <see cref="OPENFILENAME.lpTemplateName"/> if this flag is specified.
        /// If the <see cref="OFN_EXPLORER"/> flag is set, the system uses the specified template to create a dialog box
        /// that is a child of the default Explorer-style dialog box.
        /// If the <see cref="OFN_EXPLORER"/> flag is not set, the system uses the template
        /// to create an old-style dialog box that replaces the default dialog box.
        /// </summary>
        OFN_ENABLETEMPLATEHANDLE = 0x00000080,

        /// <summary>
        /// Indicates that any customizations made to the Open or Save As dialog box use the Explorer-style customization methods.
        /// For more information, see Explorer-Style Hook Procedures and Explorer-Style Custom Templates
        /// By default, the Open and Save As dialog boxes use the Explorer-style user interface regardless of whether this flag is set.
        /// This flag is necessary only if you provide a hook procedure or custom template, or set the <see cref="OFN_ALLOWMULTISELECT"/> flag.
        /// If you want the old-style user interface, omit the <see cref="OFN_EXPLORER"/> flag
        /// and provide a replacement old-style template or hook procedure.
        /// If you want the old style but do not need a custom template or hook procedure,
        /// simply provide a hook procedure that always returns <see cref="FALSE"/>.
        /// </summary>
        OFN_EXPLORER = 0x00080000,

        /// <summary>
        /// The user typed a file name extension that differs from the extension specified by <see cref="OPENFILENAME.lpstrDefExt"/>.
        /// The function does not use this flag if <see cref="OPENFILENAME.lpstrDefExt"/> is <see cref="NULL"/>.
        /// </summary>
        OFN_EXTENSIONDIFFERENT = 0x00000400,

        /// <summary>
        /// The user can type only names of existing files in the File Name entry field.
        /// If this flag is specified and the user enters an invalid name, the dialog box procedure displays a warning in a message box.
        /// If this flag is specified, the <see cref="OFN_PATHMUSTEXIST"/> flag is also used.
        /// This flag can be used in an Open dialog box.
        /// It cannot be used with a Save As dialog box.
        /// </summary>
        OFN_FILEMUSTEXIST = 0x00001000,

        /// <summary>
        /// Forces the showing of system and hidden files, thus overriding the user setting to show or not show hidden files.
        /// However, a file that is marked both system and hidden is not shown.
        /// </summary>
        OFN_FORCESHOWHIDDEN = 0x10000000,

        /// <summary>
        /// Hides the Read Only check box.
        /// </summary>
        OFN_HIDEREADONLY = 0x00000004,

        /// <summary>
        /// For old-style dialog boxes, this flag causes the dialog box to use long file names.
        /// If this flag is not specified, or if the <see cref="OFN_ALLOWMULTISELECT"/> flag is also set,
        /// old-style dialog boxes use short file names (8.3 format) for file names with spaces.
        /// Explorer-style dialog boxes ignore this flag and always display long file names.
        /// </summary>
        OFN_LONGNAMES = 0x00200000,

        /// <summary>
        /// Restores the current directory to its original value if the user changed the directory while searching for files.
        /// This flag is ineffective for <see cref="GetOpenFileName"/>.
        /// </summary>
        OFN_NOCHANGEDIR = 0x00000008,

        /// <summary>
        /// Directs the dialog box to return the path and file name of the selected shortcut (.LNK) file.
        /// If this value is not specified, the dialog box returns the path and file name of the file referenced by the shortcut.
        /// </summary>
        OFN_NODEREFERENCELINKS = 0x00100000,

        /// <summary>
        /// For old-style dialog boxes, this flag causes the dialog box to use short file names (8.3 format).
        /// Explorer-style dialog boxes ignore this flag and always display long file names.
        /// </summary>
        OFN_NOLONGNAMES = 0x00040000,

        /// <summary>
        /// Hides and disables the Network button.
        /// </summary>
        OFN_NONETWORKBUTTON = 0x00020000,

        /// <summary>
        /// The returned file does not have the Read Only check box selected and is not in a write-protected directory.
        /// </summary>
        OFN_NOREADONLYRETURN = 0x00008000,

        /// <summary>
        /// The file is not created before the dialog box is closed.
        /// This flag should be specified if the application saves the file on a create-nonmodify network share.
        /// When an application specifies this flag, the library does not check for write protection, a full disk,
        /// an open drive door, or network protection.
        /// Applications using this flag must perform file operations carefully, because a file cannot be reopened once it is closed.
        /// </summary>
        OFN_NOTESTFILECREATE = 0x00010000,

        /// <summary>
        /// The common dialog boxes allow invalid characters in the returned file name.
        /// Typically, the calling application uses a hook procedure that checks the file name by using the <see cref="FILEOKSTRING"/> message.
        /// If the text box in the edit control is empty or contains nothing but spaces, the lists of files and directories are updated.
        /// If the text box in the edit control contains anything else, <see cref="OPENFILENAME.nFileOffset"/>
        /// and <see cref="OPENFILENAME.nFileExtension"/> are set to values generated by parsing the text.
        /// No default extension is added to the text, nor is text copied to the buffer specified by <see cref="OPENFILENAME.lpstrFileTitle"/>.
        /// If the value specified by nFileOffset is less than zero, the file name is invalid.
        /// Otherwise, the file name is valid, and <see cref="OPENFILENAME.nFileExtension"/> and <see cref="OPENFILENAME.nFileOffset"/> can be used
        /// as if the <see cref="OFN_NOVALIDATE"/> flag had not been specified.
        /// </summary>
        OFN_NOVALIDATE = 0x00000100,

        /// <summary>
        /// Causes the Save As dialog box to generate a message box if the selected file already exists.
        /// The user must confirm whether to overwrite the file.
        /// </summary>
        OFN_OVERWRITEPROMPT = 0x00000002,

        /// <summary>
        /// The user can type only valid paths and file names.
        /// If this flag is used and the user types an invalid path and file name in the File Name entry field,
        /// the dialog box function displays a warning in a message box.
        /// </summary>
        OFN_PATHMUSTEXIST = 0x00000800,

        /// <summary>
        /// Causes the Read Only check box to be selected initially when the dialog box is created.
        /// This flag indicates the state of the Read Only check box when the dialog box is closed.
        /// </summary>
        OFN_READONLY = 0x00000001,

        /// <summary>
        /// Specifies that if a call to the <see cref="OpenFile"/> function fails because of a network sharing violation,
        /// the error is ignored and the dialog box returns the selected file name.
        /// If this flag is not set, the dialog box notifies your hook procedure when a network sharing violation occurs
        /// for the file name specified by the user.
        /// If you set the <see cref="OFN_EXPLORER"/> flag, the dialog box sends the <see cref="CDN_SHAREVIOLATION"/> message to the hook procedure.
        /// If you do not set <see cref="OFN_EXPLORER"/>, the dialog box sends the <see cref="SHAREVISTRING"/> registered message to the hook procedure.
        /// </summary>
        OFN_SHAREAWARE = 0x00004000,

        /// <summary>
        /// Causes the dialog box to display the Help button.
        /// The <see cref="OPENFILENAME.hwndOwner"/> member must specify the window to receive the <see cref="HELPMSGSTRING"/> registered messages
        /// that the dialog box sends when the user clicks the Help button.
        /// An Explorer-style dialog box sends a <see cref="CDN_HELP"/> notification message to your hook procedure when the user clicks the Help button.
        /// </summary>
        OFN_SHOWHELP = 0x00000010,
    }
}
