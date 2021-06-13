using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.BaseTypes.CSIDL;
using static Lsj.Util.Win32.Enums.BrowseForFolderMessages;
using static Lsj.Util.Win32.Enums.COINIT;
using static Lsj.Util.Win32.Enums.SFGAOF;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="BROWSEINFO"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/ns-shlobj_core-browseinfow"/>
    /// </para>
    /// </summary>
    public enum BROWSEINFOFlags : uint
    {
        /// <summary>
        /// Only return file system directories.
        /// If the user selects folders that are not part of the file system, the OK button is grayed.
        /// Note 
        /// The OK button remains enabled for "\\server" items, as well as "\\server\share" and directory items.
        /// However, if the user selects a "\\server" item,
        /// passing the PIDL returned by <see cref="SHBrowseForFolder"/> to <see cref="SHGetPathFromIDList"/> fails.
        /// </summary>
        BIF_RETURNONLYFSDIRS = 0x00000001,

        /// <summary>
        /// Do not include network folders below the domain level in the dialog box's tree view control.
        /// </summary>
        BIF_DONTGOBELOWDOMAIN = 0x00000002,

        /// <summary>
        ///  Include a status area in the dialog box.
        ///  The callback function can set the status text by sending messages to the dialog box.
        ///  This flag is not supported when <see cref="BIF_NEWDIALOGSTYLE"/> is specified.
        /// </summary>
        BIF_STATUSTEXT = 0x00000004,

        /// <summary>
        /// Only return file system ancestors. An ancestor is a subfolder that is beneath the root folder in the namespace hierarchy.
        /// If the user selects an ancestor of the root folder that is not part of the file system, the OK button is grayed.
        /// </summary>
        BIF_RETURNFSANCESTORS = 0x00000008,

        /// <summary>
        /// Version 4.71.
        /// Include an edit control in the browse dialog box that allows the user to type the name of an item.
        /// </summary>
        BIF_EDITBOX = 0x00000010,

        /// <summary>
        /// Version 4.71.
        /// If the user types an invalid name into the edit box, the browse dialog box calls
        /// the application's BrowseCallbackProc with the <see cref="BFFM_VALIDATEFAILED"/> message.
        /// This flag is ignored if <see cref="BIF_EDITBOX"/> is not specified.
        /// </summary>
        BIF_VALIDATE = 0x00000020,

        /// <summary>
        /// Version 5.0.
        /// Use the new user interface.
        /// Setting this flag provides the user with a larger dialog box that can be resized.
        /// The dialog box has several new capabilities, including: drag-and-drop capability
        /// within the dialog box, reordering, shortcut menus, new folders, delete, and other shortcut menu commands.
        /// Note 
        /// If COM is initialized through <see cref="CoInitializeEx"/> with the <see cref="COINIT_MULTITHREADED"/> flag set,
        /// <see cref="SHBrowseForFolder"/> fails if <see cref="BIF_NEWDIALOGSTYLE"/> is passed.
        /// </summary>
        BIF_NEWDIALOGSTYLE = 0x00000040,

        /// <summary>
        /// Version 5.0.
        /// Use the new user interface, including an edit box.
        /// This flag is equivalent to <code>BIF_EDITBOX | BIF_NEWDIALOGSTYLE</code>.
        /// Note
        /// If COM is initialized through <see cref="CoInitializeEx"/> with the <see cref="COINIT_MULTITHREADED"/> flag set,
        /// <see cref="SHBrowseForFolder"/> fails if <see cref="BIF_USENEWUI"/> is passed.
        /// </summary>
        BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX),

        /// <summary>
        /// Version 5.0.
        /// The browse dialog box can display URLs.
        /// The <see cref="BIF_USENEWUI"/> and <see cref="BIF_BROWSEINCLUDEFILES"/> flags must also be set.
        /// If any of these three flags are not set, the browser dialog box rejects URLs.
        /// Even when these flags are set, the browse dialog box displays URLs only if the folder that contains the selected item supports URLs.
        /// When the folder's <see cref="IShellFolder.GetAttributesOf"/> method is called to request the selected item's attributes,
        /// the folder must set the <see cref="SFGAO_FOLDER"/> attribute flag.
        /// Otherwise, the browse dialog box will not display the URL.
        /// </summary>
        BIF_BROWSEINCLUDEURLS = 0x00000080,

        /// <summary>
        /// Version 6.0.
        /// When combined with <see cref="BIF_NEWDIALOGSTYLE"/>, adds a usage hint to the dialog box, in place of the edit box.
        /// <see cref="BIF_EDITBOX"/> overrides this flag.
        /// </summary>
        BIF_UAHINT = 0x00000100,

        /// <summary>
        /// Version 6.0.
        /// Do not include the New Folder button in the browse dialog box.
        /// </summary>
        BIF_NONEWFOLDERBUTTON = 0x00000200,

        /// <summary>
        /// Version 6.0.
        /// When the selected item is a shortcut, return the PIDL of the shortcut itself rather than its target.
        /// </summary>
        BIF_NOTRANSLATETARGETS = 0x00000400,

        /// <summary>
        /// Only return computers.
        /// If the user selects anything other than a computer, the OK button is grayed.
        /// </summary>
        BIF_BROWSEFORCOMPUTER = 0x00001000,

        /// <summary>
        /// Only allow the selection of printers.
        /// If the user selects anything other than a printer, the OK button is grayed.
        /// In Windows XP and later systems, the best practice is to use a Windows XP-style dialog,
        /// setting the root of the dialog to the Printers and Faxes folder (<see cref="CSIDL_PRINTERS"/>).
        /// </summary>
        BIF_BROWSEFORPRINTER = 0x00002000,

        /// <summary>
        /// Version 4.71.
        /// The browse dialog box displays files as well as folders.
        /// </summary>
        BIF_BROWSEINCLUDEFILES = 0x00004000,

        /// <summary>
        /// Version 5.0.
        /// The browse dialog box can display sharable resources on remote systems.
        /// This is intended for applications that want to expose remote shares on a local system.
        /// The <see cref="BIF_NEWDIALOGSTYLE"/> flag must also be set.
        /// </summary>
        BIF_SHAREABLE = 0x00008000,

        /// <summary>
        /// Windows 7 and later.
        /// Allow folder junctions such as a library or a compressed file with a .zip file name extension to be browsed.
        /// </summary>
        BIF_BROWSEFILEJUNCTIONS = 0x00010000,
    }
}
