using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Defines the set of options available to an Open or Save dialog.
    /// </summary>
    public enum FILEOPENDIALOGOPTIONS : uint
    {
        /// <summary>
        /// When saving a file, prompt before overwriting an existing file of the same name. This is a default value for the Save dialog.
        /// </summary>
        FOS_OVERWRITEPROMPT = 0x2,

        /// <summary>
        /// In the Save dialog, only allow the user to choose a file
        /// that has one of the file name extensions specified through <see cref="IFileDialog.SetFileTypes"/>.
        /// </summary>
        FOS_STRICTFILETYPES = 0x4,

        /// <summary>
        /// Don't change the current working directory.
        /// </summary>
        FOS_NOCHANGEDIR = 0x8,

        /// <summary>
        /// Present an Open dialog that offers a choice of folders rather than files.
        /// </summary>
        FOS_PICKFOLDERS = 0x20,

        /// <summary>
        /// Ensures that returned items are file system items (<see cref="SFGAO_FILESYSTEM"/>).
        /// Note that this does not apply to items returned by <see cref="IFileDialog.GetCurrentSelection"/>.
        /// </summary>
        FOS_FORCEFILESYSTEM = 0x40,

        /// <summary>
        /// Enables the user to choose any item in the Shell namespace,
        /// not just those with <see cref="SFGAO_STREAM"/> or <see cref="SFAGO_FILESYSTEM"/> attributes.
        /// This flag cannot be combined with <see cref="FOS_FORCEFILESYSTEM"/>.
        /// </summary>
        FOS_ALLNONSTORAGEITEMS = 0x80,

        /// <summary>
        /// Do not check for situations that would prevent an application from opening the selected file,
        /// such as sharing violations or access denied errors.
        /// </summary>
        FOS_NOVALIDATE = 0x100,

        /// <summary>
        /// Enables the user to select multiple items in the open dialog.
        /// Note that when this flag is set, the <see cref="IFileOpenDialog"/> interface must be used to retrieve those items.
        /// </summary>
        FOS_ALLOWMULTISELECT = 0x200,

        /// <summary>
        /// The item returned must be in an existing folder.
        /// This is a default value.
        /// </summary>
        FOS_PATHMUSTEXIST = 0x800,

        /// <summary>
        /// The item returned must exist.
        /// This is a default value for the Open dialog.
        /// </summary>
        FOS_FILEMUSTEXIST = 0x1000,

        /// <summary>
        /// Prompt for creation if the item returned in the save dialog does not exist.
        /// Note that this does not actually create the item.
        /// </summary>
        FOS_CREATEPROMPT = 0x2000,

        /// <summary>
        /// In the case of a sharing violation when an application is opening a file,
        /// call the application back through <see cref="OnShareViolation"/> for guidance.
        /// This flag is overridden by <see cref="FOS_NOVALIDATE"/>.
        /// </summary>
        FOS_SHAREAWARE = 0x4000,

        /// <summary>
        /// Do not return read-only items.
        /// This is a default value for the Save dialog.
        /// </summary>
        FOS_NOREADONLYRETURN = 0x8000,

        /// <summary>
        /// Do not test whether creation of the item as specified in the Save dialog will be successful.
        /// If this flag is not set, the calling application must handle errors, such as denial of access, discovered when the item is created.
        /// </summary>
        FOS_NOTESTFILECREATE = 0x10000,

        /// <summary>
        /// Hide the list of places from which the user has recently opened or saved items.
        /// This value is not supported as of Windows 7.
        /// </summary>
        FOS_HIDEMRUPLACES = 0x20000,

        /// <summary>
        /// Hide items shown by default in the view's navigation pane.
        /// This flag is often used in conjunction with the <see cref="IFileDialog.AddPlace"/> method,
        /// to hide standard locations and replace them with custom locations.
        /// Windows 7 and later.
        /// Hide all of the standard namespace locations (such as Favorites, Libraries, Computer, and Network) shown in the navigation pane.
        /// Windows Vista.
        /// Hide the contents of the Favorite Links tree in the navigation pane.
        /// Note that the category itself is still displayed, but shown as empty.
        /// </summary>
        FOS_HIDEPINNEDPLACES = 0x40000,

        /// <summary>
        /// Shortcuts should not be treated as their target items.
        /// This allows an application to open a .lnk file rather than what that file is a shortcut to.
        /// </summary>
        FOS_NODEREFERENCELINKS = 0x100000,

        /// <summary>
        /// 
        /// </summary>
        FOS_OKBUTTONNEEDSINTERACTION = 0x200000,

        /// <summary>
        /// Do not add the item being opened or saved to the recent documents list (<see cref="SHAddToRecentDocs"/>).
        /// </summary>
        FOS_DONTADDTORECENT = 0x2000000,

        /// <summary>
        /// Include hidden and system items.
        /// </summary>
        FOS_FORCESHOWHIDDEN = 0x10000000,

        /// <summary>
        /// Indicates to the Save As dialog box that it should open in expanded mode.
        /// Expanded mode is the mode that is set and unset by clicking the button in the lower-left corner of the Save As dialog box
        /// that switches between Browse Folders and Hide Folders when clicked.
        /// This value is not supported as of Windows 7.
        /// </summary>
        FOS_DEFAULTNOMINIMODE = 0x20000000,

        /// <summary>
        /// Indicates to the Open dialog box that the preview pane should always be displayed.
        /// </summary>
        FOS_FORCEPREVIEWPANEON = 0x40000000,

        /// <summary>
        /// Indicates that the caller is opening a file as a stream (BHID_Stream), so there is no need to download that file.
        /// </summary>
        FOS_SUPPORTSTREAMABLEITEMS = 0x80000000,
    }
}
