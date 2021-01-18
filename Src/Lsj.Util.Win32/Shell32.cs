using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.CSIDL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.KNOWNFOLDERID;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.BrowseForFolderMessages;
using static Lsj.Util.Win32.Enums.BROWSEINFOFlags;
using static Lsj.Util.Win32.Enums.COINIT;
using static Lsj.Util.Win32.Enums.FileAttributes;
using static Lsj.Util.Win32.Enums.FILEOP_FLAGS;
using static Lsj.Util.Win32.Enums.FILEOPENDIALOGOPTIONS;
using static Lsj.Util.Win32.Enums.RegistryValueTypes;
using static Lsj.Util.Win32.Enums.SHCNE;
using static Lsj.Util.Win32.Enums.SHCNF;
using static Lsj.Util.Win32.Enums.ShellExecuteErrorCodes;
using static Lsj.Util.Win32.Enums.SHGetFileInfoFlags;
using static Lsj.Util.Win32.Enums.SHGFP_TYPE;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shell32.dll
    /// </summary>
    public static class Shell32
    {
        /// <summary>
        /// <para>
        /// Specifies an application-defined callback function used to send messages to, and process messages from,
        /// a Browse dialog box displayed in response to a call to <see cref="SHBrowseForFolder"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb762598(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window handle of the browse dialog box.
        /// </param>
        /// <param name="uMsg">
        /// The dialog box event that generated the message.
        /// One of the following values.
        /// <see cref="BFFM_INITIALIZED"/>, <see cref="BFFM_IUNKNOWN"/>, <see cref="BFFM_SELCHANGED"/>, <see cref="BFFM_VALIDATEFAILED"/>
        /// </param>
        /// <param name="lParam">
        /// A value whose meaning depends on the event specified in uMsg as follows:
        /// <see cref="BFFM_INITIALIZED"/>: Not used, value is <see cref="NULL"/>.
        /// <see cref="BFFM_IUNKNOWN"/>: A pointer to an <see cref="IUnknown"/> interface.
        /// <see cref="BFFM_SELCHANGED"/>: A PIDL that identifies the newly selected item.
        /// <see cref="BFFM_VALIDATEFAILED"/>: A pointer to a string that contains the invalid name.
        /// An application can use this data in an error dialog informing the user that the name was not valid.
        /// </param>
        /// <param name="lpData">
        /// An application-defined value that was specified in the <see cref="BROWSEINFO.lParam"/> member
        /// of the <see cref="BROWSEINFO"/> structure used in the call to <see cref="SHBrowseForFolder"/>.
        /// </param>
        /// <returns>
        /// Returns zero except in the case of <see cref="BFFM_VALIDATEFAILED"/>.
        /// For that flag, returns zero to dismiss the dialog or nonzero to keep the dialog displayed.
        /// </returns>
        /// <remarks>
        /// To attach your BrowseCallbackProc to a dialog, specify its address in the <see cref="BROWSEINFO.lpfn"/> member
        /// of the <see cref="BROWSEINFO"/> structure used in a <see cref="SHBrowseForFolder"/> call.
        /// BrowseCallbackProc can also send messages to the dialog box through SendMessage, to control these aspects:
        /// OK button enabled/disabled
        /// OK button text
        /// Selected folder
        /// Expanded folder
        /// Status text
        /// Set the SendMessage function's Msg parameter to one of the following values,
        /// providing additional information in the wParam and lParam parameters as indicated for each message type.
        /// Remarks
        /// Msg
        /// Meaning
        /// wParam
        /// lParam
        /// <see cref="BFFM_ENABLEOK"/>
        /// Enables or disables the dialog box's OK button.
        /// Not used.
        /// To enable, set to a nonzero value. To disable, set to zero.
        /// <see cref="BFFM_SETOKTEXT"/>
        /// Version 6.0 or later. Sets the text that is displayed on the dialog box's OK button.
        /// Not used.
        /// A pointer to a null-terminated Unicode string that contains the desired text.
        /// <see cref="BFFM_SETSELECTION"/>
        /// Specifies the path of a folder to select.
        /// The path can be specified as a string or a PIDL.
        /// <see cref="TRUE"/> to use a string; <see cref="FALSE"/> to use a PIDL.
        /// The string or PIDL that specifies the path.
        /// <see cref="BFFM_SETEXPANDED"/>
        /// Version 6.0 or later.
        /// Specifies the path of a folder to expand in the Browse dialog box.
        /// The path can be specified as a Unicode string or a PIDL.
        /// <see cref="TRUE"/> to use a string; <see cref="FALSE"/> to use a PIDL.
        /// The string or PIDL that specifies the path.
        /// <see cref="BFFM_SETSTATUSTEXT"/> Sets the status text.
        /// Set the BrowseCallbackProc lpData parameter to point to a null-terminated string with the desired text.
        /// Not used.
        /// A pointer to a null-terminated string that contains the desired text.
        /// </remarks>
        public delegate int BFFCALLBACK([In] HWND hwnd, [In] BrowseForFolderMessages uMsg, [In] LPARAM lParam, [In] LPARAM lpData);

        /// <summary>
        /// <para>
        /// Parses a Unicode command line string and returns an array of pointers to the command line arguments,
        /// along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-commandlinetoargvw
        /// </para>
        /// </summary>
        /// <param name="lpCmdLine">
        /// Pointer to a null-terminated Unicode string that contains the full command line.
        /// If this parameter is an empty string the function returns the path to the current executable file.
        /// </param>
        /// <param name="pNumArgs">
        /// Pointer to an int that receives the number of array elements returned, similar to argc.
        /// </param>
        /// <returns>
        /// A pointer to an array of LPWSTR values, similar to argv.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The address returned by <see cref="CommandLineToArgvW"/> is the address of the first element in an array of LPWSTR values;
        /// the number of pointers in this array is indicated by <paramref name="pNumArgs"/>.
        /// Each pointer to a null-terminated Unicode string represents an individual argument found on the command line.
        /// <see cref="CommandLineToArgvW"/> allocates a block of contiguous memory for pointers to the argument strings,
        /// and for the argument strings themselves; the calling application must free the memory used by the argument list when it is no longer needed.
        /// To free the memory, use a single call to the <see cref="LocalFree"/> function.
        /// For more information about the argv and argc argument convention, see Argument Definitions and Parsing C++ Command-Line Arguments.
        /// The <see cref="GetCommandLine"/> function can be used to get a command line string
        /// that is suitable for use as the <paramref name="lpCmdLine"/> parameter.
        /// This function accepts command lines that contain a program name; the program name can be enclosed in quotation marks or not.
        /// <see cref="CommandLineToArgvW"/> has a special interpretation of backslash characters when they are followed by a quotation mark character (").
        /// This interpretation assumes that any preceding argument is a valid file system path, or else it may behave unpredictably.
        /// This special interpretation controls the "in quotes" mode tracked by the parser. When this mode is off, whitespace terminates the current argument.
        /// When on, whitespace is added to the argument like all other characters.
        /// 2n backslashes followed by a quotation mark produce n backslashes followed by begin/end quote. This does not become part of the parsed argument,
        /// but toggles the "in quotes" mode.
        /// (2n) + 1 backslashes followed by a quotation mark again produce n backslashes followed by a quotation mark literal (").
        /// This does not toggle the "in quotes" mode.
        /// n backslashes not followed by a quotation mark simply produce n backslashes.
        /// <see cref="CommandLineToArgvW"/> treats whitespace outside of quotation marks as argument delimiters.
        /// However, if <paramref name="lpCmdLine"/> starts with any amount of whitespace,
        /// <see cref="CommandLineToArgvW"/> will consider the first argument to be an empty string.
        /// Excess whitespace at the end of <paramref name="lpCmdLine"/> is ignored.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "CommandLineToArgvW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CommandLineToArgvW(StringHandle lpCmdLine, [Out] out int pNumArgs);

        /// <summary>
        /// <para>
        /// Retrieves the application-defined, explicit Application User Model ID (AppUserModelID) for the current process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-getcurrentprocessexplicitappusermodelid
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// A pointer that receives the address of the AppUserModelID assigned to the process.
        /// The caller is responsible for freeing this string with <see cref="CoTaskMemFree"/> when it is no longer needed.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The AppUserModelID retrieved by this function was set earlier through <see cref="SetCurrentProcessExplicitAppUserModelID"/>.
        /// An application can only retrieve an AppUserModelID that has been explicitly set. System-assigned default AppUserModelIDs cannot be retrieved.
        /// If the application requires knowledge of its AppUserModelID it should set one explicitly.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessExplicitAppUserModelID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([In] IntPtr AppID);

        /// <summary>
        /// <para>
        /// Specifies a unique application-defined Application User Model ID (AppUserModelID) that identifies the current process to the taskbar.
        /// This identifier allows an application to group its associated processes and windows under a single taskbar button.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-setcurrentprocessexplicitappusermodelid
        /// </para>
        /// </summary>
        /// <param name="AppID">
        /// Pointer to the AppUserModelID to assign to the current process.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method must be called during an application's initial startup routine
        /// before the application presents any UI or makes any manipulation of its Jump Lists.
        /// This includes any call to <see cref="SHAddToRecentDocs"/>.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCurrentProcessExplicitAppUserModelID", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)][In] string AppID);

        /// <summary>
        /// <para>
        /// Notifies the system that an item has been accessed, for the purposes of tracking those items used most recently and most frequently.
        /// This function can also be used to clear all usage data.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shaddtorecentdocs
        /// </para>
        /// </summary>
        /// <param name="uFlags">
        /// A value from the <see cref="SHARD"/> enumeration that indicates the form of the information pointed to by the <paramref name="pv"/> parameter.
        /// </param>
        /// <param name="pv">
        /// A pointer to data that identifies the item that has been accessed.
        /// The item can be specified in this parameter in one of the following forms:
        /// A null-terminated string that contains the path and file name of the item.
        /// A PIDL that identifies the item's file object.
        /// Windows 7 and later only. A <see cref="SHARDAPPIDINFO"/>, <see cref="SHARDAPPIDINFOIDLIST"/>,
        /// or <see cref="SHARDAPPIDINFOLINK"/> structure that identifies the item through an AppUserModelID.
        /// See Application User Model IDs (AppUserModelIDs) for more information.
        /// Windows 7 and later only. An <see cref="IShellLink"/> object that identifies the item through a shortcut.
        /// Set this parameter to <see cref="NULL"/> to clear all usage data on all items.
        /// </param>
        /// <remarks>
        /// The usage statistics gathered through calls to this method are used
        /// to determine lists of items accessed most recently and most frequently.
        /// These lists are seen in the Start menu and, in Windows 7 and later, in an application's Jump List.
        /// When this method is called, it affects the following areas:
        /// Updates the Recent and Frequent lists for the associated application's Jump List.
        /// Adds a shortcut to the user's Recent folder (<see cref="FOLDERID_Recent"/>, <see cref="CSIDL_RECENT"/>).
        /// This is reflected in the My Recent Documents (Windows XP) and Recent Items (Windows Vista and later) menu in the Start menu.
        /// Adds a shortcut to the Classic Start menu's Documents submenu.
        /// (Note that the Classic Start menu option is not available in Windows 7 and later.)
        /// Items represented by an <see cref="IShellLink"/> are not added to the Recent folder,
        /// although they are reflected in an application's Jump List.
        /// In some cases, notably when a user opens an item through Windows Explorer or uses the common file dialog to open,
        /// save, or create a file, the Shell calls <see cref="SHAddToRecentDocs"/> on behalf of the application.
        /// An application that has a custom UI for selecting items should call <see cref="SHAddToRecentDocs"/> explicitly
        /// to ensure accurate statistics.
        /// Duplicate calls are accounted for by the system so there is no risk of skewing the data by doing so.
        /// Executable(.exe) files are filtered from the recently used documents list in Windows XP and later versions.
        /// Although <see cref="SHAddToRecentDocs"/> will accept the path of an executable file, that file will not appear in the Recent Items list.
        /// Folders are also accepted by <see cref="SHAddToRecentDocs"/>, but appear only in the Jump List for the Windows Explorer taskbar button.
        /// Folders do not appear in any other application's Jump List.
        /// In certain cases, <see cref="SHAddToRecentDocs"/> attempts to register an application to handle a file type
        /// that it is not registered to handle.
        /// This occurs under these circumstances:
        /// An application explicitly calls <see cref="SHAddToRecentDocs"/> with a file type that it is not registered to handle.
        /// This also applies to calls made to <see cref="SHAddToRecentDocs"/> by the common file dialog on behalf of the application,
        /// but only when the dialog is used to open a file, not when it is used to save one.
        /// The user drops a file of a type that the application is not registered to handle on the application's taskbar button.
        /// This registration is done per-user.
        /// A set of requirements must be met for the registration to be accomplished successfully:
        /// The application must be registered under HKEY_CLASSES_ROOT\Applications.
        /// That registration cannot include the NoOpenWith value. See File Types for more details on NoOpenWith.
        /// That registration cannot supply data under a SupportedTypes subkey. See File Types for more details on the SupportedTypes subkey.
        /// The application's executable file cannot be listed in the KillList value found here:
        /// HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\FileAssociation\KillList
        /// Note Third party applications should not modify the KillList value. It should be regarded as read-only.
        /// The application's HKEY_CLASSES_ROOT\Applications registration must have a set of default verbs defined
        /// under a HKEY_CLASSES_ROOT\Applications\ExampleApp.exe\shell subkey.
        /// If <see cref="SHAddToRecentDocs"/> is attempting the registration as the result of a drag-and-drop onto the taskbar button,
        /// the shell subkey is created if it does not already exist, as long as the existing application registration does not contain 
        /// a NoOpenWith value and the application's executable is not listed in the KillList value.
        /// Suppressing Calls to <see cref="SHAddToRecentDocs"/>
        /// In versions of Windows before Windows 7, a file type could set the <see cref="FTA_NoRecentDocs"/> flag
        /// to prevent that file type from being added to the Recent folder.
        /// This mechanism is also supported under Windows 7 and later.See File Types for more information.
        /// <see cref="SHAddToRecentDocs"/> tracks document usage statistics through the verbs that are invoked to access those documents.
        /// Verbs supplied by registered <see cref="IContextMenu"/> handlers are tracked,
        /// those items appear in My Recent Documents (Windows XP) and Recent Items (Windows Vista).
        /// In Windows 7, the parent folders of the documents appear in the Jump List for the Windows Explorer taskbar button.
        /// However, the documents accessed through those <see cref="IContextMenu"/> verbs do not appear in application Jump Lists.
        /// For those items to appear in an application's Jump List, an application must call <see cref="SHAddToRecentDocs"/> explicitly.
        /// Prior to Windows 7, only the open verb resulted in a call to <see cref="SHAddToRecentDocs"/>.
        /// In Windows 7 and later, other verbs can also generate usage statistics.
        /// This information is used to make a Jump List's destinations more complete and accurate.
        /// However, some classes of file type association registrations or individual <see cref="IContextMenu"/> implementations
        /// are not appropriate for this sort of tracking.
        /// The point of usage tracking is to generate a list of items that the user is likely to want to access again.
        /// If a particular verb—delete, for instance—is inherently invoked on an item that the user will not access again,
        /// or is a secondary action such as a virus scan on a file, that verb is not appropriate for tracking.
        /// File type classes should remove themselves from this tracking through the registry entry NoRecentDocs.
        /// NoRecentDocs is of type REG_SZ and has no associated data.
        /// Its presence is all that is required to prevent the call to <see cref="SHAddToRecentDocs"/>.
        /// For example, context menu extensions and static verbs registered under <see cref="HKEY_CLASSES_ROOT"/> in classes
        /// such as "*", "AllFileSystemObjects", or "Folder" should not be tracked.
        /// In cases such as these, the NoRecentDocs entry is added to the root of the class key
        /// as shown here to suppress tracking of documents launched through any verb or extension registered to that class:
        /// HKEY_CLASSES_ROOT\AllFileSystemObjects\NoRecentDocs
        /// The NoRecentDocs entry is assigned by default to the*, AllFileSystemObjects, Folder, Directory, and DesktopBackground class subkeys.
        /// Individual <see cref="IContextMenu"/> implementations can opt out of tracking by adding a NoRecentDocs subkey
        /// to its Component Object Model(COM) object's registration, in its shellex subkey, as shown here:
        /// HKEY_CLASSES_ROOT\CLSID\{093C7AAB-5E72-454f-A91D-CA1BC991FCEC}\shellex\NoRecentDocs
        /// This subkey is not present by default on any <see cref="IContextMenu"/> implementation.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHAddToRecentDocs", ExactSpelling = true, SetLastError = true)]
        public static extern void SHAddToRecentDocs([In] SHARD uFlags, [In] LPCVOID pv);

        /// <summary>
        /// <para>
        /// Takes a pointer to a fully qualified item identifier list (PIDL), and returns a specified interface pointer on the parent object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shbindtoparent
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// The item's PIDL.
        /// </param>
        /// <param name="riid">
        /// The REFIID of one of the interfaces exposed by the item's parent object.
        /// </param>
        /// <param name="ppv">
        /// A pointer to the interface specified by <paramref name="riid"/>.
        /// You must release the object when you are finished.
        /// </param>
        /// <param name="ppidlLast">
        /// The item's PIDL relative to the parent folder.
        /// This PIDL can be used with many of the methods supported by the parent folder's interfaces.
        /// If you set <paramref name="ppidlLast"/> to <see cref="NullRef{LPCITEMIDLIST}"/>, the PIDL is not returned.
        /// Note
        /// <see cref="SHBindToParent"/> does not allocate a new PIDL; it simply receives a pointer through this parameter.
        /// Therefore, you are not responsible for freeing this resource.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHBindToParent", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHBindToParent([In] LPCITEMIDLIST pidl, [In][Out] ref IID riid,
            [Out] out object ppv, [Out] out LPCITEMIDLIST ppidlLast);

        /// <summary>
        /// <para>
        /// Displays a dialog box that enables the user to select a Shell folder.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shbrowseforfolderw
        /// </para>
        /// </summary>
        /// <param name="lpbi">
        /// A pointer to a <see cref="BROWSEINFO"/> structure that contains information used to display the dialog box.
        /// </param>
        /// <returns>
        /// Returns a PIDL that specifies the location of the selected folder relative to the root of the namespace.
        /// If the user chooses the Cancel button in the dialog box, the return value is <see cref="NULL"/>.
        /// It is possible that the PIDL returned is that of a folder shortcut rather than a folder.
        /// For a full discussion of this case, see the Remarks section.
        /// </returns>
        /// <remarks>
        /// For Windows Vista or later, it is recommended that you use <see cref="IFileDialog"/>
        /// with the <see cref="FOS_PICKFOLDERS"/> option rather than the <see cref="SHBrowseForFolder"/> function.
        /// This uses the Open Files dialog in pick folders mode and is the preferred implementation.
        /// You must initialize Component Object Model (COM) before you call <see cref="SHBrowseForFolder"/>.
        /// If you initialize COM using <see cref="CoInitializeEx"/>,
        /// you must set the <see cref="COINIT_APARTMENTTHREADED"/> flag in its dwCoInit parameter.
        /// You can also use <see cref="CoInitialize"/> or <see cref="OleInitialize"/>, which always use apartment threading.
        /// If you require drag-and-drop functionality,
        /// <see cref="OleInitialize"/> is recommended because it initializes the required OLE as well as COM.
        /// Note If COM is initialized using <see cref="CoInitializeEx"/> with the <see cref="COINIT_MULTITHREADED"/> flag,
        /// <see cref="SHBrowseForFolder"/> fails if the calling application
        /// uses the <see cref="BIF_USENEWUI"/> or <see cref="BIF_NEWDIALOGSTYLE"/> flag in the <see cref="BROWSEINFO"/> structure.
        /// It is the responsibility of the calling application to call <see cref="CoTaskMemFree"/> 
        /// to free the IDList returned by <see cref="SHBrowseForFolder"/> when it is no longer needed.
        /// There are two styles of dialog box available. The older style is displayed by default and is not resizable. 
        /// The newer style provides a number of additional features, including drag-and-drop capability within the dialog box,
        /// reordering, deletion, shortcut menus, the ability to create new folders, and other shortcut menu commands.
        /// Initially, it is larger than the older dialog box, but the user can resize it.
        /// To specify a dialog box using the newer style, set the <see cref="BIF_USENEWUI"/> flag
        /// in the <see cref="BROWSEINFO.ulFlags"/> member of the <see cref="BROWSEINFO"/> structure.
        /// If you implement a callback function, specified in the <see cref="BROWSEINFO.lpfn"/> member
        /// of the <see cref="BROWSEINFO"/> structure, you receive a handle to the dialog box.
        /// One use of this window handle is to modify the layout or contents of the dialog box.
        /// Because it is not resizable, modifying the older style dialog box is relatively straightforward.
        /// Modifying the newer style dialog box is much more difficult, and not recommended.
        /// Not only does it have a different size and layout than the old style,
        /// but its dimensions and the positions of its controls change every time it is resized by the user.
        /// If the <see cref="BIF_RETURNONLYFSDIRS"/> flag is set in the <see cref="BROWSEINFO.ulFlags"/> member
        /// of the <see cref="BROWSEINFO"/> structure, the OK button remains enabled for "\server" items, 
        /// as well as "\server\share" and directory items.
        /// However, if the user selects a "\server" item, passing the PIDL
        /// returned by <see cref="SHBrowseForFolder"/> to <see cref="SHGetPathFromIDList"/> fails.
        /// Custom Filtering
        /// As of Windows XP, <see cref="SHBrowseForFolder"/> supports custom filtering on the contents of the dialog box.
        /// To create a custom filter, follow these steps.
        /// Set the <see cref="BIF_NEWDIALOGSTYLE"/> flag in the <see cref="BROWSEINFO.ulFlags"/> member
        /// of the <see cref="BROWSEINFO"/> structure pointed to by the <paramref name="lpbi"/> parameter.
        /// Specify a callback function in the <see cref="BROWSEINFO.lpfn"/> member of that same <see cref="BROWSEINFO"/> structure.
        /// Code the callback function to receive the <see cref="BFFM_INITIALIZED"/> and <see cref="BFFM_IUNKNOWN"/> messages.
        /// On receipt of the <see cref="BFFM_IUNKNOWN"/> message, the callback function's lParam parameter
        /// contains a pointer to the dialog box's implementation of <see cref="IUnknown"/>.
        /// Call QueryInterface on that <see cref="IUnknown"/> to obtain a pointer to an instance of <see cref="IFolderFilterSite"/>.
        /// Create an object that implements <see cref="IFolderFilter"/>.
        /// Call <see cref="IFolderFilterSite.SetFilter"/>, passing to it a pointer to your <see cref="IFolderFilter"/>.
        /// <see cref="IFolderFilter"/> methods can then be used to include and exclude items from the tree.
        /// Once the filter is created, the <see cref="IFolderFilterSite"/> interface is no longer needed.
        /// Call IFolderFilterSite::Release if you have no further use for it.
        /// Dealing With Shortcuts
        /// Note  This section applies to only Windows 2000 and earlier systems.By default
        /// , Windows XP and later systems return the PIDL of a shortcut's target rather than the shortcut itself,
        /// as long as the <see cref="BIF_NOTRANSLATETARGETS"/> flag is not set in the <see cref="BROWSEINFO"/> structure.
        /// If <see cref="SHBrowseForFolder"/> returns a PIDL to a shortcut,
        /// sending that PIDL to <see cref="SHGetPathFromIDList"/> returns the path of the shortcut itself rather than the path of its target.
        /// The path to the shortcut's target can be obtained by using the <see cref="IShellLink"/> interface as shown in this example.
        /// <code>
        /// #include
        /// // Macros for interface casts
        /// #ifdef __cplusplus
        /// #define IID_PPV_ARG(IType, ppType) IID_##IType, reinterpret_cast(static_cast(ppType))
        /// #else
        /// #define IID_PPV_ARG(IType, ppType) &amp;IID_##IType, (void**)(ppType)
        /// #endif
        /// // Retrieves the UIObject interface for the specified full PIDL
        /// STDAPI SHGetUIObjectFromFullPIDL(LPCITEMIDLIST pidl, HWND hwnd, REFIID riid, void** ppv)
        /// {
        ///     LPCITEMIDLIST pidlChild;
        ///     IShellFolder* psf;
        /// 
        ///     *ppv = NULL;
        /// 
        ///     HRESULT hr = SHBindToParent(pidl, IID_PPV_ARG(IShellFolder, &amp;psf), &amp;pidlChild);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psf->GetUIObjectOf(hwnd, 1, &amp;pidlChild, riid, NULL, ppv);
        ///         psf->Release();
        ///     }
        ///     return hr;
        ///  }
        ///  
        /// #define ILSkip(pidl, cb)       ((LPITEMIDLIST)(((BYTE*)(pidl))+cb))
        /// #define ILNext(pidl)           ILSkip(pidl, (pidl)->mkid.cb)
        /// HRESULT SHILClone(LPCITEMIDLIST pidl, LPITEMIDLIST* ppidl)
        /// {
        ///     DWORD cbTotal = 0;
        ///     if (pidl)
        ///     {
        ///         LPCITEMIDLIST pidl_temp = pidl;
        ///         cbTotal += sizeof(pidl_temp->mkid.cb);
        ///         
        ///         while (pidl_temp->mkid.cb)
        ///         {
        ///             cbTotal += pidl_temp->mkid.cb;
        ///             pidl_temp += ILNext(pidl_temp);
        ///         }
        ///     }
        ///     *ppidl = (LPITEMIDLIST)CoTaskMemAlloc(cbTotal);
        ///     if (*ppidl)
        ///         CopyMemory(*ppidl, pidl, cbTotal);
        ///     return *ppidl ? S_OK : E_OUTOFMEMORY;
        /// }
        /// 
        /// // Get the target PIDL for a folder PIDL. This also deals with cases of a folder
        /// // shortcut or an alias to a real folder.
        /// STDAPI SHGetTargetFolderIDList(LPCITEMIDLIST pidlFolder, LPITEMIDLIST* ppidl)
        /// {
        ///     IShellLink* psl;
        ///     
        ///     *ppidl = NULL;
        ///     
        ///     HRESULT hr = SHGetUIObjectFromFullPIDL(pidlFolder, NULL, IID_PPV_ARG(IShellLink, &amp;psl));
        ///     
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psl->GetIDList(ppidl);
        ///         psl->Release();
        ///     }
        ///     
        ///     // It's not a folder shortcut so get the PIDL normally.
        ///     if (FAILED(hr))
        ///         hr = SHILClone(pidlFolder, ppidl);
        ///         
        /// 
        ///     return hr;
        ///  }
        ///  
        /// // Get the target folder for a folder PIDL. This deals with cases where a folder
        /// // is an alias to a real folder, folder shortcuts, the My Documents folder, and 
        /// // other items of that nature.
        /// STDAPI SHGetTargetFolderPath(LPCITEMIDLIST pidlFolder, LPWSTR pszPath, UINT cchPath)
        /// {
        ///     LPITEMIDLIST pidlTarget;
        ///     
        ///     *pszPath = 0;
        ///     
        ///     HRESULT hr = SHGetTargetFolderIDList(pidlFolder, &amp;pidlTarget);
        ///     
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         SHGetPathFromIDListW(pidlTarget, pszPath);   // Make sure it is a path
        ///         CoTaskMemFree(pidlTarget);
        ///     }
        ///     
        ///     return *pszPath ? S_OK : E_FAIL;
        /// }
        /// // Retrieves the UIObject interface for the specified full PIDLstatic 
        /// HRESULT SHGetUIObjectFromFullPIDL(LPCITEMIDLIST pidl, HWND hwnd, REFIID riid, void** ppv)
        /// {
        ///     LPCITEMIDLIST pidlChild;
        ///     IShellFolder* psf;
        ///     *ppv = NULL;
        ///     
        ///     HRESULT hr = SHBindToParent(pidl, IID_IShellFolder, (LPVOID*)&amp;psf, &amp;pidlChild);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psf->GetUIObjectOf(hwnd, 1, &amp;pidlChild, riid, NULL, ppv);
        ///         psf->Release();
        ///     }
        ///     return hr;
        ///     }
        ///     
        /// static HRESULT SHILClone(LPCITEMIDLIST pidl, LPITEMIDLIST* ppidl)
        /// {
        ///     DWORD cbTotal = 0;
        ///     if (pidl)
        ///     {
        ///         LPCITEMIDLIST pidl_temp = pidl;
        ///         cbTotal += pidl_temp->mkid.cb;
        ///         
        ///         while (pidl_temp->mkid.cb)
        ///         {
        ///             cbTotal += pidl_temp->mkid.cb;
        ///             pidl_temp = ILNext(pidl_temp);
        ///          }
        ///      }
        ///      
        ///      *ppidl = (LPITEMIDLIST)CoTaskMemAlloc(cbTotal);
        ///      if (*ppidl)
        ///         CopyMemory(*ppidl, pidl, cbTotal);
        ///         
        ///      return *ppidl ? S_OK : E_OUTOFMEMORY;
        ///      }
        ///      
        /// // Get the target PIDL for a folder PIDL. This also deals with cases of a folder
        /// // shortcut or an alias to a real folder.
        /// static HRESULT SHGetTargetFolderIDList(LPCITEMIDLIST pidlFolder, LPITEMIDLIST* ppidl)
        /// {
        ///     IShellLink* psl;
        ///     *ppidl = NULL;
        ///     
        ///     HRESULT hr = SHGetUIObjectFromFullPIDL(pidlFolder, NULL, IID_IShellLink, (LPVOID*)&amp;psl);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         hr = psl->GetIDList(ppidl);
        ///         psl->Release();
        ///     }
        ///
        ///     // It's not a folder shortcut so get the PIDL normally.
        ///     if (FAILED(hr))
        ///         hr = SHILClone(pidlFolder, ppidl);
        ///     return hr;
        /// }
        /// 
        /// // Get the target folder for a folder PIDL. This deals with cases where a folder
        /// // is an alias to a real folder, folder shortcuts, the My Documents folder, 
        /// // and so on.
        /// STDAPI SHGetTargetFolderPath(LPCITEMIDLIST pidlFolder, LPWSTR pszPath, UINT cchPath)
        /// {
        ///     LPITEMIDLIST pidlTarget;
        ///     *pszPath = 0;
        ///     
        ///     HRESULT hr = SHGetTargetFolderIDList(pidlFolder, &amp;pidlTarget);
        ///     if (SUCCEEDED(hr))
        ///     {
        ///         SHGetPathFromIDListW(pidlTarget, pszPath);
        ///         
        ///         // Make sure it is a path
        ///         CoTaskMemFree(pidlTarget);
        ///      }
        ///      
        ///     return *pszPath ? S_OK : E_FAIL;
        /// }
        /// </code>
        /// The shlobj_core.h header defines <see cref="SHBrowseForFolder"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead
        /// to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHBrowseForFolderW", ExactSpelling = true, SetLastError = true)]
        public static extern LPITEMIDLIST SHBrowseForFolder([In] in BROWSEINFO lpbi);

        /// <summary>
        /// <para>
        /// Notifies the system of an event that an application has performed.
        /// An application should use this function if it performs an action that may affect the Shell.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shchangenotify
        /// </para>
        /// </summary>
        /// <param name="wEventId">
        /// Describes the event that has occurred.
        /// Typically, only one event is specified at a time.
        /// If more than one event is specified, the values contained in the <paramref name="dwItem1"/>
        /// and <paramref name="dwItem2"/> parameters must be the same, respectively, for all specified events.
        /// This parameter can be one or more of the following values:
        /// <see cref="SHCNE_ALLEVENTS"/>:
        /// All events have occurred.
        /// <see cref="SHCNE_ASSOCCHANGED"/>:
        /// A file type association has changed.
        /// <see cref="SHCNF_IDLIST"/> must be specified in the <paramref name="uFlags"/> parameter.
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are not used and must be <see cref="NULL"/>.
        /// This event should also be sent for registered protocols.
        /// <see cref="SHCNE_ATTRIBUTES"/>:
        /// The attributes of an item or folder have changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item or folder that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_CREATE"/>:
        /// A nonfolder item has been created.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that was created.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_DELETE"/>:
        /// A nonfolder item has been deleted.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that was deleted.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_DRIVEADD"/>:
        /// A drive has been added.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that was added.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_DRIVEADDGUI"/>:
        /// Windows XP and later: Not used.
        /// <see cref="SHCNE_DRIVEREMOVED"/>:
        /// A drive has been removed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_EXTENDED_EVENT"/>:
        /// Not currently used.
        /// <see cref="SHCNE_FREESPACE"/>:
        /// The amount of free space on a drive has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive on which the free space changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_MEDIAINSERTED"/>:
        /// Storage media has been inserted into a drive.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive that contains the new media.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_MEDIAREMOVED"/>:
        /// Storage media has been removed from a drive.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the root of the drive from which the media was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_MKDIR"/>:
        /// A folder has been created.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that was created.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_NETSHARE"/>:
        /// A folder on the local computer is being shared via the network.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that is being shared.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_NETUNSHARE"/>:
        /// A folder on the local computer is no longer being shared via the network.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that is no longer being shared.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_RENAMEFOLDER"/>:
        /// The name of a folder has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the previous PIDL or name of the folder.
        /// <paramref name="dwItem2"/> contains the new PIDL or name of the folder.
        /// <see cref="SHCNE_RENAMEITEM"/>:
        /// The name of a nonfolder item has changed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the previous PIDL or name of the item.
        /// <paramref name="dwItem2"/> contains the new PIDL or name of the item.
        /// <see cref="SHCNE_RMDIR"/>:
        /// A folder has been removed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that was removed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_SERVERDISCONNECT"/>:
        /// The computer has disconnected from a server.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the server from which the computer was disconnected.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_UPDATEDIR"/>:
        /// The contents of an existing folder have changed, but the folder still exists and has not been renamed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the folder that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// If a folder has been created, deleted, or renamed, use <see cref="SHCNE_MKDIR"/>,
        /// <see cref="SHCNE_RMDIR"/>, or <see cref="SHCNE_RENAMEFOLDER"/>, respectively.
        /// <see cref="SHCNE_UPDATEIMAGE"/>:
        /// An image in the system image list has changed.
        /// <see cref="SHCNF_DWORD"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem2"/> contains the index in the system image list that has changed.
        /// <paramref name="dwItem1"/> is not used and should be <see cref="NULL"/>.
        /// <see cref="SHCNE_UPDATEITEM"/>:
        /// An existing item (a folder or a nonfolder) has changed, but the item still exists and has not been renamed.
        /// <see cref="SHCNF_IDLIST"/> or <see cref="SHCNF_PATH"/> must be specified in <paramref name="uFlags"/>.
        /// <paramref name="dwItem1"/> contains the item that has changed.
        /// <paramref name="dwItem2"/> is not used and should be <see cref="NULL"/>.
        /// If a nonfolder item has been created, deleted, or renamed, use <see cref="SHCNE_CREATE"/>,
        /// <see cref="SHCNE_DELETE"/>, or <see cref="SHCNE_RENAMEITEM"/>, respectively, instead.
        /// <see cref="SHCNE_DISKEVENTS"/>:
        /// Specifies a combination of all of the disk event identifiers.
        /// <see cref="SHCNE_GLOBALEVENTS"/>:
        /// Specifies a combination of all of the global event identifiers.
        /// <see cref="SHCNE_INTERRUPT"/>:
        /// The specified event occurred as a result of a system interrupt.
        /// As this value modifies other event values, it cannot be used alone.
        /// </param>
        /// <param name="uFlags">
        /// Flags that, when combined bitwise with <see cref="SHCNF_TYPE"/>,
        /// indicate the meaning of the <paramref name="dwItem1"/> and <paramref name="dwItem2"/> parameters.
        /// The <paramref name="uFlags"/> parameter must be one of the following values.
        /// <see cref="SHCNF_DWORD"/>:
        /// The <paramref name="dwItem1"/> and <paramref name="dwItem2"/> parameters are <see cref="DWORD"/> values.
        /// <see cref="SHCNF_IDLIST"/>:
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of <see cref="ITEMIDLIST"/> structures
        /// that represent the item(s) affected by the change.
        /// Each <see cref="ITEMIDLIST"/> must be relative to the desktop folder.
        /// <see cref="SHCNF_PATH"/>:
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of null-terminated strings
        /// of maximum length <see cref="MAX_PATH"/> that contain the full path names of the items affected by the change.
        /// <see cref="SHCNF_PRINTER"/>:
        /// <paramref name="dwItem1"/> and <paramref name="dwItem2"/> are the addresses of null-terminated strings
        /// that represent the friendly names of the printer(s) affected by the change.
        /// <see cref="SHCNF_FLUSH"/>:
        /// The function should not return until the notification has been delivered to all affected components.
        /// As this flag modifies other data-type flags, it cannot be used by itself.
        /// <see cref="SHCNF_FLUSHNOWAIT"/>:
        /// The function should begin delivering notifications to all affected components
        /// but should return as soon as the notification process has begun.
        /// As this flag modifies other data-type flags, it cannot by used by itself.
        /// This flag includes <see cref="SHCNF_FLUSH"/>.
        /// <see cref="SHCNF_NOTIFYRECURSIVE"/>:
        /// Notify clients registered for all children.
        /// </param>
        /// <param name="dwItem1">
        /// Optional. First event-dependent value.
        /// </param>
        /// <param name="dwItem2">
        /// Optional. Second event-dependent value.
        /// </param>
        /// <remarks>
        /// Applications that register new handlers of any type must call <see cref="SHChangeNotify"/>
        /// with the <see cref="SHCNE_ASSOCCHANGED"/> flag to instruct the Shell to invalidate the icon and thumbnail cache.
        /// This will also load new icon and thumbnail handlers that have been registered.
        /// Note, however, that icon overlay handlers are not reloaded.
        /// The strings pointed to by <paramref name="dwItem1"/> and <paramref name="dwItem2"/> can be either ANSI or Unicode.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHChangeNotify", ExactSpelling = true, SetLastError = true)]
        public static extern void SHChangeNotify([In] SHCNE wEventId, [In] SHCNF uFlags, [In] LPCVOID dwItem1, [In] LPCVOID dwItem2);

        /// <summary>
        /// <para>
        /// Creates a new file system folder, with optional security attributes.
        /// This function is available through Windows XP Service Pack 2 (SP2) and Windows Server 2003.
        /// It might be altered or unavailable in subsequent versions of Windows.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shcreatedirectoryexw
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to a parent window.
        /// This parameter can be set to <see cref="NULL"/> if no user interface will be displayed.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string specifying the fully qualified path of the directory.
        /// This string is of maximum length of 248 characters, including the terminating null character.
        /// </param>
        /// <param name="psa">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure with the directory's security attribute.
        /// Set this parameter to <see cref="NullRef{SECURITY_ATTRIBUTES}"/> if no security attributes need to be set.
        /// </param>
        /// <returns>
        /// Returns <see cref="ERROR_SUCCESS"/> if successful. If the operation fails, other error codes can be returned, including those listed here.
        /// For values not specifically listed, see System Error Codes.
        /// <see cref="ERROR_BAD_PATHNAME"/>:
        /// The <paramref name="pszPath"/> parameter was set to a relative path.
        /// <see cref="ERROR_FILENAME_EXCED_RANGE"/>:
        /// The path pointed to by <paramref name="pszPath"/> is too long.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>:
        /// The system cannot find the path pointed to by <paramref name="pszPath"/>. The path may contain an invalid entry.
        /// <see cref="ERROR_FILE_EXISTS"/>:
        /// The directory exists.
        /// <see cref="ERROR_ALREADY_EXISTS"/>:
        /// The directory exists.
        /// <see cref="ERROR_CANCELLED"/>:
        /// The user canceled the operation.
        /// </returns>
        /// <remarks>
        /// This function creates a file system folder whose fully qualified path is given by <paramref name="pszPath"/>.
        /// If one or more of the intermediate folders do not exist, they are created as well.
        /// <see cref="SHCreateDirectoryEx"/> also verifies that the files are visible.
        /// If they are not visible, expect one of the following:
        /// If <paramref name="hwnd"/> is set to a valid window handle,
        /// a message box is displayed warning the user that he or she might not be able to access the files.
        /// If the user chooses not to proceed, the function returns <see cref="ERROR_CANCELLED"/>.
        /// If <paramref name="hwnd"/> is set to <see cref="NULL"/>, no user interface is displayed and the function returns <see cref="ERROR_CANCELLED"/>.
        /// The shlobj_core.h header defines <see cref="SHCreateDirectoryEx"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead
        /// to mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHCreateDirectoryExW", ExactSpelling = true, SetLastError = true)]
        public static extern int SHCreateDirectoryEx([In] HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)][In] string pszPath,
            [In] in SECURITY_ATTRIBUTES psa);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shellexecutew
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the parent window used for displaying a UI or error messages.
        /// This value can be <see cref="NULL"/> if the operation is not associated with a window.
        /// </param>
        /// <param name="lpOperation">
        /// A pointer to a null-terminated string, referred to in this case as a verb, that specifies the action to be performed.
        /// The set of available verbs depends on the particular file or folder.
        /// Generally, the actions available from an object's shortcut menu are available verbs.
        /// The following verbs are commonly used:
        /// edit:
        /// Launches an editor and opens the document for editing. If <paramref name="lpFile"/> is not a document file, the function will fail.
        /// explore:
        /// Explores a folder specified by <paramref name="lpFile"/>.
        /// find:
        /// Initiates a search beginning in the directory specified by <paramref name="lpDirectory"/>.
        /// open:
        /// Opens the item specified by the <paramref name="lpFile"/> parameter. The item can be a file or folder.
        /// print:
        /// Prints the file specified by <paramref name="lpFile"/>. If <paramref name="lpFile"/> is not a document file, the function fails.
        /// runas:
        /// Launches an application as Administrator.
        /// User Account Control (UAC) will prompt the user for consent to run the application elevated or enter
        /// the credentials of an administrator account used to run the application.
        /// <see langword="null"/>:
        /// The default verb is used, if available.
        /// If not, the "open" verb is used. If neither verb is available, the system uses the first verb listed in the registry.
        /// </param>
        /// <param name="lpFile">
        /// A pointer to a null-terminated string that specifies the file or object on which to execute the specified verb.
        /// To specify a Shell namespace object, pass the fully qualified parse name.
        /// Note that not all verbs are supported on all objects. For example, not all document types support the "print" verb.
        /// If a relative path is used for the <paramref name="lpDirectory"/> parameter do not use a relative path for <paramref name="lpFile"/>.
        /// </param>
        /// <param name="lpParameters">
        /// If <paramref name="lpFile"/> specifies an executable file, this parameter is a pointer to a null-terminated string
        /// that specifies the parameters to be passed to the application.
        /// The format of this string is determined by the verb that is to be invoked.
        /// If <paramref name="lpFile"/> specifies a document file, <paramref name="lpParameters"/> should be <see langword="null"/>.
        /// </param>
        /// <param name="lpDirectory">
        /// A pointer to a null-terminated string that specifies the default (working) directory for the action.
        /// If this value is <see langword="null"/>, the current working directory is used.
        /// If a relative path is provided at <paramref name="lpFile"/>, do not use a relative path for <paramref name="lpDirectory"/>.
        /// </param>
        /// <param name="nShowCmd">
        /// The flags that specify how an application is to be displayed when it is opened.
        /// If <paramref name="lpFile"/> specifies a document file, the flag is simply passed to the associated application.
        /// It is up to the application to decide how to handle it.
        /// These values are defined in Winuser.h.
        /// <see cref="SW_HIDE"/>:
        /// Hides the window and activates another window.
        /// <see cref="SW_MAXIMIZE"/>:
        /// Maximizes the specified window.
        /// <see cref="SW_MINIMIZE"/>:
        /// Minimizes the specified window and activates the next top-level window in the z-order.
        /// <see cref="SW_RESTORE"/>:
        /// Activates and displays the window. If the window is minimized or maximized, Windows restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// <see cref="SW_SHOW"/>:
        /// Activates the window and displays it in its current size and position.
        /// <see cref="SW_SHOWDEFAULT"/>:
        /// Sets the show state based on the SW_ flag specified in the <see cref="STARTUPINFO"/> structure
        /// passed to the <see cref="CreateProcess"/> function by the program that started the application.
        /// An application should call <see cref="ShowWindow"/> with this flag to set the initial show state of its main window.
        /// <see cref="SW_SHOWMAXIMIZED"/>:
        /// Activates the window and displays it as a maximized window.
        /// <see cref="SW_SHOWMINIMIZED"/>:
        /// Activates the window and displays it as a minimized window.
        /// <see cref="SW_SHOWMINNOACTIVE"/>:
        /// Displays the window as a minimized window. The active window remains active.
        /// <see cref="SW_SHOWNA"/>:
        /// Displays the window in its current state. The active window remains active.
        /// <see cref="SW_SHOWNOACTIVATE"/>:
        /// Displays a window in its most recent size and position. The active window remains active.
        /// <see cref="SW_SHOWNORMAL"/>:
        /// Activates and displays a window. If the window is minimized or maximized, Windows restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// </param>
        /// <returns>
        /// If the function succeeds, it returns a value greater than 32.
        /// If the function fails, it returns an error value that indicates the cause of the failure.
        /// The return value is cast as an <see cref="HINSTANCE"/> for backward compatibility with 16-bit Windows applications.
        /// It is not a true <see cref="HINSTANCE"/>, however. It can be cast only to an int and compared to either 32 or the following error codes below.
        /// 0: The operating system is out of memory or resources.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// <see cref="ERROR_BAD_FORMAT"/>: The.exe file is invalid (non-Win32 .exe or error in .exe image).
        /// <see cref="SE_ERR_ACCESSDENIED"/>: The operating system denied access to the specified file.
        /// <see cref="SE_ERR_ASSOCINCOMPLETE"/>: The file name association is incomplete or invalid.
        /// <see cref="SE_ERR_DDEBUSY"/>: The DDE transaction could not be completed because other DDE transactions were being processed.
        /// <see cref="SE_ERR_DDEFAIL"/>: The DDE transaction failed.
        /// <see cref="SE_ERR_DDETIMEOUT"/>: The DDE transaction could not be completed because the request timed out.
        /// <see cref="SE_ERR_DLLNOTFOUND"/>: The specified DLL was not found.
        /// <see cref="SE_ERR_FNF"/>: The specified file was not found.
        /// <see cref="SE_ERR_NOASSOC"/>:
        /// There is no application associated with the given file name extension.
        /// This error will also be returned if you attempt to print a file that is not printable.
        /// <see cref="SE_ERR_OOM"/>: There was not enough memory to complete the operation.
        /// <see cref="SE_ERR_PNF"/>: The specified path was not found.
        /// <see cref="SE_ERR_SHARE"/>: A sharing violation occurred.
        /// </returns>
        /// <remarks>
        /// Because <see cref="ShellExecute"/> can delegate execution to Shell extensions
        /// (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecute"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// There are certainly instances where <see cref="ShellExecute"/> does not use one of these types of Shell extension
        /// and those instances would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initalize COM before using this function.
        /// This method allows you to execute any commands in a folder's shortcut menu or stored in the registry.
        /// To open a folder, use either of the following calls:
        /// <code>
        /// ShellExecute(handle, NULL, &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// or
        /// <code>
        /// ShellExecute(handle, "open", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// To explore a folder, use the following call:
        /// <code>
        /// ShellExecute(handle, "explore", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, SW_SHOWNORMAL);
        /// </code>
        /// To launch the Shell's Find utility for a directory, use the following call.
        /// <code>
        /// ShellExecute(handle, "find", &lt;fully_qualified_path_to_folder&gt;, NULL, NULL, 0);
        /// </code>
        /// If <paramref name="lpOperation"/> is <see langword="null"/>, the function opens the file specified by <paramref name="lpFile"/>.
        /// If <paramref name="lpOperation"/> is "open" or "explore", the function attempts to open or explore the folder.
        /// To obtain information about the application that is launched as a result of calling <see cref="ShellExecute"/>, use <see cref="ShellExecuteEx"/>.
        /// Note
        /// The Launch folder windows in a separate process setting in Folder Options affects <see cref="ShellExecute"/>.
        /// If that option is disabled (the default setting), <see cref="ShellExecute"/> uses an open Explorer window rather than launch a new one.
        /// If no Explorer window is open, <see cref="ShellExecute"/> launches a new one.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteW", ExactSpelling = true, SetLastError = true)]
        public static extern HINSTANCE ShellExecute([In] HWND hwnd, [MarshalAs(UnmanagedType.LPWStr)][In] string lpOperation,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpFile, [MarshalAs(UnmanagedType.LPWStr)][In] string lpParameters,
            [MarshalAs(UnmanagedType.LPWStr)][In] string lpDirectory, [In] ShowWindowCommands nShowCmd);

        /// <summary>
        /// <para>
        /// Performs an operation on a specified file.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shellexecuteexw
        /// </para>
        /// </summary>
        /// <param name="pExecInfo">
        /// A pointer to a <see cref="SHELLEXECUTEINFO"/> structure that contains and receives information about the application being executed.
        /// </param>
        /// <returns>
        /// Returns <see langword="true"/> if successful; otherwise, <see langword="false"/>.
        /// Call <see cref="GetLastError"/> for extended error information.
        /// </returns>
        /// <remarks>
        /// Because <see cref="ShellExecuteEx"/> can delegate execution to Shell extensions (data sources, context menu handlers, verb implementations)
        /// that are activated using Component Object Model (COM), COM should be initialized before <see cref="ShellExecuteEx"/> is called.
        /// Some Shell extensions require the COM single-threaded apartment (STA) type.
        /// In that case, COM should be initialized as shown here:
        /// <code>
        /// CoInitializeEx(NULL, COINIT_APARTMENTTHREADED | COINIT_DISABLE_OLE1DDE)
        /// </code>
        /// There are instances where <see cref="ShellExecuteEx"/> does not use one of these types of Shell extension and those instances
        /// would not require COM to be initialized at all.
        /// Nonetheless, it is good practice to always initalize COM before using this function.
        /// When DLLs are loaded into your process, you acquire a lock known as a loader lock.
        /// The DllMain function always executes under the loader lock.
        /// It is important that you do not call <see cref="ShellExecuteEx"/> while you hold a loader lock.
        /// Because <see cref="ShellExecuteEx"/> is extensible, you could load code that does not function properly in the presence of a loader lock,
        /// risking a deadlock and therefore an unresponsive thread.
        /// With multiple monitors, if you specify an HWND and set the <see cref="SHELLEXECUTEINFO.lpVerb"/> member 
        /// of the <see cref="SHELLEXECUTEINFO"/> structure pointed to by <paramref name="pExecInfo"/> to "Properties",
        /// any windows created by <see cref="ShellExecuteEx"/> might not appear in the correct position.
        /// If the function succeeds, it sets the <see cref="SHELLEXECUTEINFO.hInstApp"/> member
        /// of the <see cref="SHELLEXECUTEINFO"/> structure to a value greater than 32.
        /// If the function fails, <see cref="SHELLEXECUTEINFO.hInstApp"/> is set to the SE_ERR_XXX error value that best indicates the cause of the failure.
        /// Although <see cref="SHELLEXECUTEINFO.hInstApp"/> is declared as an HINSTANCE for compatibility with 16-bit Windows applications,
        /// it is not a true HINSTANCE.
        /// It can be cast only to an int and can be compared only to either the value 32 or the SE_ERR_XXX error codes.
        /// The SE_ERR_XXX error values are provided for compatibility with <see cref="ShellExecute"/>.
        /// To retrieve more accurate error information, use <see cref="GetLastError"/>.
        /// It may return one of the following values.
        /// <see cref="ERROR_FILE_NOT_FOUND"/>: The specified file was not found.
        /// <see cref="ERROR_PATH_NOT_FOUND"/>: The specified path was not found.
        /// <see cref="ERROR_DDE_FAIL"/>: The Dynamic Data Exchange(DDE) transaction failed.
        /// <see cref="ERROR_NO_ASSOCIATION"/>: There is no application associated with the specified file name extension.
        /// <see cref="ERROR_ACCESS_DENIED"/>: Access to the specified file is denied.
        /// <see cref="ERROR_DLL_NOT_FOUND"/>: One of the library files necessary to run the application can't be found.
        /// <see cref="ERROR_CANCELLED"/>: The function prompted the user for additional information, but the user canceled the request.
        /// <see cref="ERROR_NOT_ENOUGH_MEMORY"/>: There is not enough memory to perform the specified action.
        /// <see cref="ERROR_SHARING_VIOLATION"/>: A sharing violation occurred.
        /// Opening items from a URL You can register your application to activate when passed URLs.
        /// You can also specify which protocols your application supports. See Application Registration for more info.
        /// Site chain support As of Windows 8, you can provide a site chain pointer to the <see cref="ShellExecuteEx"/> function 
        /// to support item activation with services from that site.
        /// See Launching Applications(<see cref="ShellExecute"/>, <see cref="ShellExecuteEx"/>, <see cref="SHELLEXECUTEINFO"/>) for more information.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShellExecuteExW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShellExecuteEx([In][Out] ref SHELLEXECUTEINFO pExecInfo);

        /// <summary>
        /// <para>
        /// Copies, moves, renames, or deletes a file system object.
        /// This function has been replaced in Windows Vista by <see cref="IFileOperation"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shfileoperationw
        /// </para>
        /// </summary>
        /// <param name="lpFileOp">
        /// A pointer to an <see cref="SHFILEOPSTRUCT"/> structure that contains information this function needs to carry out the specified operation.
        /// This parameter must contain a valid value that is not <see cref="NullRef{SHFILEOPSTRUCT}"/>.
        /// You are responsible for validating the value. If you do not validate it, you will experience unexpected results.
        /// </param>
        /// <returns>
        /// Returns zero if successful; otherwise nonzero.
        /// Applications normally should simply check for zero or nonzero.
        /// It is good practice to examine the value of the <see cref="SHFILEOPSTRUCT.fAnyOperationsAborted"/> member of the <see cref="SHFILEOPSTRUCT"/>.
        /// <see cref="SHFileOperation"/> can return 0 for success if the user cancels the operation.
        /// If you do not check <see cref="SHFILEOPSTRUCT.fAnyOperationsAborted"/> as well as the return value,
        /// you cannot know that the function accomplished the full task you asked of it and you might proceed under incorrect assumptions.
        /// Do not use GetLastError with the return values of this function.
        /// To examine the nonzero values for troubleshooting purposes, they largely map to those defined in Winerror.h.
        /// However, several of its possible return values are based on pre-Win32 error codes,
        /// which in some cases overlap the later Winerror.h values without matching their meaning.
        /// Those particular values are detailed here, and for these specific values only these meanings should be accepted over the Winerror.h codes.
        /// However, these values are provided with these warnings:
        /// These are pre-Win32 error codes and are no longer supported or defined in any public header file.
        /// To use them, you must either define them yourself or compare against the numerical value.
        /// These error codes are subject to change and have historically done so.
        /// These values are provided only as an aid in debugging.
        /// They should not be regarded as definitive.
        /// DE_SAMEFILE         0x71
        /// The source and destination files are the same file.
        /// DE_MANYSRC1DEST 	0x72
        /// Multiple file paths were specified in the source buffer, but only one destination file path.
        /// DE_DIFFDIR 	        0x73
        /// Rename operation was specified but the destination path is a different directory. Use the move operation instead.
        /// DE_ROOTDIR 	        0x74
        /// The source is a root directory, which cannot be moved or renamed.
        /// DE_OPCANCELLED 	    0x75
        /// The operation was canceled by the user, or silently canceled if the appropriate flags were supplied to SHFileOperation.
        /// DE_DESTSUBTREE 	    0x76
        /// The destination is a subtree of the source.
        /// DE_ACCESSDENIEDSRC 	0x78
        /// Security settings denied access to the source.
        /// DE_PATHTOODEEP 	    0x79
        /// The source or destination path exceeded or would exceed <see cref="MAX_PATH"/>.
        /// DE_MANYDEST 	    0x7A
        /// The operation involved multiple destination paths, which can fail in the case of a move operation.
        /// DE_INVALIDFILES 	0x7C
        /// The path in the source or destination or both was invalid.
        /// DE_DESTSAMETREE 	0x7D
        /// The source and destination have the same parent folder.
        /// DE_FLDDESTISFILE 	0x7E
        /// The destination path is an existing file.
        /// DE_FILEDESTISFLD 	0x80
        /// The destination path is an existing folder.
        /// DE_FILENAMETOOLONG 	0x81
        /// The name of the file exceeds <see cref="MAX_PATH"/>.
        /// DE_DEST_IS_CDROM 	0x82
        /// The destination is a read-only CD-ROM, possibly unformatted.
        /// DE_DEST_IS_DVD 	    0x83
        /// The destination is a read-only DVD, possibly unformatted.
        /// DE_DEST_IS_CDRECORD 0x84
        /// The destination is a writable CD-ROM, possibly unformatted.
        /// DE_FILE_TOO_LARGE 	0x85
        /// The file involved in the operation is too large for the destination media or file system.
        /// DE_SRC_IS_CDROM 	0x86
        /// The source is a read-only CD-ROM, possibly unformatted.
        /// DE_SRC_IS_DVD 	    0x87
        /// The source is a read-only DVD, possibly unformatted.
        /// DE_SRC_IS_CDRECORD 	0x88
        /// The source is a writable CD-ROM, possibly unformatted.
        /// DE_ERROR_MAX 	    0xB7
        /// MAX_PATH was exceeded during the operation.
        /// 0x402
        /// An unknown error occurred.
        /// This is typically due to an invalid path in the source or destination.
        /// This error does not occur on Windows Vista and later.
        /// ERRORONDEST 	    0x10000
        /// An unspecified error occurred on the destination.
        /// DE_ROOTDIR | ERRORONDEST 	0x10074
        /// Destination is a root directory and cannot be renamed.
        /// </returns>
        /// <remarks>
        /// You should use fully qualified path names with this function.
        /// Using it with relative path names is not thread safe.
        /// With two exceptions, you cannot use <see cref="SHFileOperation"/> to move special folders
        /// from a local drive to a remote computer by specifying a network path.
        /// The exceptions are the My Documents (<see cref="CSIDL_PERSONAL"/>, <see cref="CSIDL_MYDOCUMENTS"/>)
        /// and My Pictures folders (<see cref="CSIDL_MYPICTURES"/>).
        /// When used to delete a file, <see cref="SHFileOperation"/> permanently deletes the file
        /// unless you set the <see cref="FOF_ALLOWUNDO"/> flag in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the <see cref="SHFILEOPSTRUCT"/> structure pointed to by <paramref name="lpFileOp"/>.
        /// Setting that flag sends the file to the Recycle Bin.
        /// If you want to simply delete a file and guarantee that it is not placed in the Recycle Bin, use <see cref="DeleteFile"/>.
        /// If a copy callback handler is exposed and registered, <see cref="SHFileOperation"/> calls it
        /// unless you set a flag such as <see cref="FOF_NOCONFIRMATION"/> in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the structure pointed to by <paramref name="lpFileOp"/>.
        /// See <see cref="ICopyHook.CopyCallback"/> for details on implementing copy callback handlers.
        /// File deletion is recursive unless you set the <see cref="FOF_NORECURSION"/> flag in <paramref name="lpFileOp"/>.
        /// Connecting Files
        /// With Windows 2000 or later, it is possible to connect an HTML file with a folder
        /// that contains related files such as Graphics Interchange Format (GIF) images or style sheets.
        /// If file connection is enabled, when you move or copy the HTML file, the connected folder and all of its files are also moved or copied.
        /// Conversely, if you move the folder with the related files, the HTML file is also moved.
        /// The HTML file must have a .htm or .html extension. You create the connection to the related files
        /// by placing the folder that contains them into the same folder as the HTML file.
        /// The name of the folder that contains the connected files must be the same as the name of the HTML file followed by "_files" or ".files"
        /// (this is case sensitive; for example, ".Files" does not work).
        /// An example is given here.
        /// Create a file named Test.htm in the C:\Files directory (C:\Files\Test.htm).
        /// Create a new folder named Test.files in the C:\Files directory (C:\Files\Test.files).
        /// Populate the folder with a few files. Any file placed in this folder is connected to Test.htm.
        /// Move or copy the Test.htm file to the C:\Files2 directory.
        /// Note that the Test.files directory is now found in the C:\Files2 directory as well.
        /// File connection is enabled by default. It can be disabled by adding a <see cref="REG_DWORD"/> entry, NoFileFolderConnection, as shown here:
        /// HKEY_CURRENT_USER\ Software\Microsoft\Windows\CurrentVersion\Explorer\NoFileFolderConnection
        /// Setting NoFileFolderConnection to 1 disables file connection.
        /// If the value is set to zero or is missing, file connection is enabled.
        /// To move only the specified files and none of the connected files,
        /// set the <see cref="FOF_NO_CONNECTED_ELEMENTS"/> flag in the <see cref="SHFILEOPSTRUCT.fFlags"/> member
        /// of the structure pointed to by <paramref name="lpFileOp"/>.
        /// Note that the use of a folder with a name like "MyFile_files" to define a connection may not be valid for localized versions of Windows.
        /// The term "files" may need to be replaced by the equivalent word in the local language.
        /// The shellapi.h header defines SHFileOperation as an alias which automatically selects the ANSI or Unicode version of this function
        /// based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHFileOperationW", ExactSpelling = true, SetLastError = true)]
        public static extern int SHFileOperation([In] in SHFILEOPSTRUCT lpFileOp);

        /// <summary>
        /// <para>
        /// Frees a file name mapping object that was retrieved by the <see cref="SHFileOperation"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shfreenamemappings
        /// </para>
        /// </summary>
        /// <param name="hNameMappings">
        /// A handle to the file name mapping object to be freed.
        /// </param>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHFreeNameMappings", ExactSpelling = true, SetLastError = true)]
        public static extern void SHFreeNameMappings([In] HANDLE hNameMappings);

        /// <summary>
        /// <para>
        /// Retrieves the <see cref="IShellFolder"/> interface for the desktop folder, which is the root of the Shell's namespace.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetdesktopfolder
        /// </para>
        /// </summary>
        /// <param name="ppshf">
        /// When this method returns, receives an <see cref="IShellFolder"/> interface pointer for the desktop folder.
        /// The calling application is responsible for eventually freeing the interface by calling its IUnknown::Release method.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetDesktopFolder", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetDesktopFolder([MarshalAs(UnmanagedType.Interface)][Out] out IShellFolder ppshf);

        /// <summary>
        /// <para>
        /// Contains information about a file object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shgetfileinfow
        /// </para>
        /// </summary>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of maximum length <see cref="MAX_PATH"/> that contains the path and file name.
        /// Both absolute and relative paths are valid.
        /// If the <paramref name="uFlags"/> parameter includes the <see cref="SHGFI_PIDL"/> flag,
        /// this parameter must be the address of an ITEMIDLIST (PIDL) structure that contains the list of item identifiers
        /// that uniquely identifies the file within the Shell's namespace.
        /// The PIDL must be a fully qualified PIDL. Relative PIDLs are not allowed.
        /// If the <paramref name="uFlags"/> parameter includes the <see cref="SHGFI_USEFILEATTRIBUTES"/> flag,
        /// this parameter does not have to be a valid file name.
        /// The function will proceed as if the file exists with the specified name and
        /// with the file attributes passed in the <paramref name="dwFileAttributes"/> parameter.
        /// This allows you to obtain information about a file type by passing just the extension for <paramref name="pszPath"/>
        /// and passing <see cref="FILE_ATTRIBUTE_NORMAL"/> in <paramref name="dwFileAttributes"/>.
        /// This string can use either short (the 8.3 form) or long file names.
        /// </param>
        /// <param name="dwFileAttributes">
        /// A combination of one or more file attribute flags (FILE_ATTRIBUTE_ values as defined in Winnt.h).
        /// If <paramref name="uFlags"/> does not include the <see cref="SHGFI_USEFILEATTRIBUTES"/> flag, this parameter is ignored.
        /// </param>
        /// <param name="psfi">
        /// Pointer to a <see cref="SHFILEINFO"/> structure to receive the file information.
        /// </param>
        /// <param name="cbFileInfo">
        /// The size, in bytes, of the <see cref="SHFILEINFO"/> structure pointed to by the psfi parameter.
        /// </param>
        /// <param name="uFlags">
        /// The flags that specify the file information to retrieve.
        /// This parameter can be a combination of the following values.
        /// <see cref="SHGFI_ADDOVERLAYS"/>:
        /// Version 5.0. Apply the appropriate overlays to the file's icon. The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_ATTR_SPECIFIED"/>:
        /// Modify <see cref="SHGFI_ATTRIBUTES"/> to indicate that the <see cref="SHFILEINFO.dwAttributes"/> member
        /// of the <see cref="SHFILEINFO"/> structure at <paramref name="psfi"/> contains the specific attributes that are desired.
        /// These attributes are passed to <see cref="IShellFolder.GetAttributesOf"/>.
        /// If this flag is not specified, 0xFFFFFFFF is passed to <see cref="IShellFolder.GetAttributesOf"/>, requesting all attributes.
        /// This flag cannot be specified with the <see cref="SHGFI_ICON"/> flag.
        /// <see cref="SHGFI_ATTRIBUTES"/>:
        /// Retrieve the item attributes.
        /// The attributes are copied to the <see cref="SHFILEINFO.dwAttributes"/> member of the structure specified in the <paramref name="psfi"/> parameter.
        /// These are the same attributes that are obtained from <see cref="IShellFolder.GetAttributesOf"/>.
        /// <see cref="SHGFI_DISPLAYNAME"/>:
        /// Retrieve the display name for the file, which is the name as it appears in Windows Explorer.
        /// The name is copied to the <see cref="SHFILEINFO.szDisplayName"/> member of the structure specified in <paramref name="psfi"/>.
        /// The returned display name uses the long file name, if there is one, rather than the 8.3 form of the file name.
        /// Note that the display name can be affected by settings such as whether extensions are shown.
        /// <see cref="SHGFI_EXETYPE"/>:
        /// Retrieve the type of the executable file if <paramref name="pszPath"/> identifies an executable file.
        /// The information is packed into the return value.
        /// This flag cannot be specified with any other flags.
        /// <see cref="SHGFI_ICON"/>:
        /// Retrieve the handle to the icon that represents the file and the index of the icon within the system image list.
        /// The handle is copied to the <see cref="SHFILEINFO.hIcon"/> member of the structure
        /// specified by <paramref name="psfi"/>, and the index is copied to the <see cref="SHFILEINFO.iIcon"/> member.
        /// <see cref="SHGFI_ICONLOCATION"/>:
        /// Retrieve the name of the file that contains the icon representing the file specified by <paramref name="pszPath"/>,
        /// as returned by the <see cref="IExtractIcon.GetIconLocation"/> method of the file's icon handler.
        /// Also retrieve the icon index within that file.
        /// The name of the file containing the icon is copied to the <see cref="SHFILEINFO.szDisplayName"/> member
        /// of the structure specified by <paramref name="psfi"/>.
        /// The icon's index is copied to that structure's <see cref="SHFILEINFO.iIcon"/> member.
        /// <see cref="SHGFI_LARGEICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's large icon.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_LINKOVERLAY"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to add the link overlay to the file's icon.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_OPENICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's open icon.
        /// Also used to modify <see cref="SHGFI_SYSICONINDEX"/>, causing the function to return the handle
        /// to the system image list that contains the file's small open icon.
        /// A container object displays an open icon to indicate that the container is open.
        /// The <see cref="SHGFI_ICON"/> and/or <see cref="SHGFI_SYSICONINDEX"/> flag must also be set.
        /// <see cref="SHGFI_OVERLAYINDEX"/>:
        /// Version 5.0. Return the index of the overlay icon.
        /// The value of the overlay index is returned in the upper eight bits of the <see cref="SHFILEINFO.iIcon"/> member
        /// of the structure specified by <paramref name="psfi"/>.
        /// This flag requires that the <see cref="SHGFI_ICON"/> be set as well.
        /// <see cref="SHGFI_PIDL"/>:
        /// Indicate that <paramref name="pszPath"/> is the address of an <see cref="ITEMIDLIST"/> structure rather than a path name.
        /// <see cref="SHGFI_SELECTED"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to blend the file's icon with the system highlight color.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_SHELLICONSIZE"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve a Shell-sized icon.
        /// If this flag is not specified the function sizes the icon according to the system metric values.
        /// The <see cref="SHGFI_ICON"/> flag must also be set.
        /// <see cref="SHGFI_SMALLICON"/>:
        /// Modify <see cref="SHGFI_ICON"/>, causing the function to retrieve the file's small icon.
        /// Also used to modify <see cref="SHGFI_SYSICONINDEX"/>, causing the function to return
        /// the handle to the system image list that contains small icon images.
        /// The <see cref="SHGFI_ICON"/> and/or <see cref="SHGFI_SYSICONINDEX"/> flag must also be set.
        /// <see cref="SHGFI_SYSICONINDEX"/>:
        /// Retrieve the index of a system image list icon.
        /// If successful, the index is copied to the <see cref="SHFILEINFO.iIcon"/> member of <paramref name="psfi"/>.
        /// The return value is a handle to the system image list.
        /// Only those images whose indices are successfully copied to iIcon are valid.
        /// Attempting to access other images in the system image list will result in undefined behavior.
        /// <see cref="SHGFI_TYPENAME"/>:
        /// Retrieve the string that describes the file's type.
        /// The string is copied to the <see cref="SHFILEINFO.szTypeName"/> member of the structure specified in <paramref name="psfi"/>.
        /// <see cref="SHGFI_USEFILEATTRIBUTES"/>:
        /// Indicates that the function should not attempt to access the file specified by <paramref name="pszPath"/>.
        /// Rather, it should act as if the file specified by <paramref name="pszPath"/> exists
        /// with the file attributes passed in <paramref name="dwFileAttributes"/>.
        /// This flag cannot be combined with the <see cref="SHGFI_ATTRIBUTES"/>, <see cref="SHGFI_EXETYPE"/>, or <see cref="SHGFI_PIDL"/> flags.
        /// </param>
        /// <returns>
        /// Returns a value whose meaning depends on the <paramref name="uFlags"/> parameter.
        /// If <paramref name="uFlags"/> does not contain <see cref="SHGFI_EXETYPE"/> or <see cref="SHGFI_SYSICONINDEX"/>,
        /// the return value is nonzero if successful, or zero otherwise.
        /// If <paramref name="uFlags"/> contains the <see cref="SHGFI_EXETYPE"/> flag, the return value specifies the type of the executable file.
        /// It will be one of the following values.
        /// 0: Nonexecutable file or an error condition. 
        /// LOWORD = NE or PE and HIWORD = Windows version: Windows application.
        /// LOWORD = MZ and HIWORD = 0: MS-DOS .exe or .com file
        /// LOWORD = PE and HIWORD = 0: Console application or .bat file
        /// </returns>
        /// <remarks>
        /// You should call this function from a background thread. Failure to do so could cause the UI to stop responding.
        /// If <see cref="SHGetFileInfo"/> returns an icon handle in the <see cref="SHFILEINFO.hIcon"/> member of
        /// the <see cref="SHFILEINFO"/> structure pointed to by <paramref name="psfi"/>,
        /// you are responsible for freeing it with <see cref="DestroyIcon"/> when you no longer need it.
        /// Note Once you have a handle to a system image list, you can use the Image List API to manipulate it like any other image list.
        /// Because system image lists are created on a per-process basis, you should treat them as read-only objects.
        /// Writing to a system image list may overwrite or delete one of the system images,
        /// making it unavailable or incorrect for the remainder of the process.
        /// You must initialize Component Object Model (COM) with CoInitialize or OleInitialize prior to calling <see cref="SHGetFileInfo"/>.
        /// When you use the <see cref="SHGFI_EXETYPE"/> flag with a Windows application,
        /// the Windows version of the executable is given in the HIWORD of the return value.
        /// This version is returned as a hexadecimal value.
        /// For details on equating this value with a specific Windows version, see Using the Windows Headers.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFileInfoW", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD_PTR SHGetFileInfo([MarshalAs(UnmanagedType.LPWStr)][In] string pszPath, [In] FileAttributes dwFileAttributes,
            [In][Out] ref SHFILEINFO psfi, [In] UINT cbFileInfo, [In] SHGetFileInfoFlags uFlags);

        /// <summary>
        /// <para>
        /// Deprecated. Gets the path of a folder identified by a CSIDL value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetfolderpathw
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="csidl">
        /// A CSIDL value that identifies the folder whose path is to be retrieved.
        /// Only real folders are valid.
        /// If a virtual folder is specified, this function fails.
        /// You can force creation of a folder by combining the folder's CSIDL with <see cref="CSIDL_FLAG_CREATE"/>.
        /// </param>
        /// <param name="hToken">
        /// An access token that can be used to represent a particular user.
        /// Microsoft Windows 2000 and earlier: Always set this parameter to <see cref="NULL"/>.
        /// Windows XP and later: This parameter is usually set to <see cref="NULL"/>, but you might need to assign a non-NULL value
        /// to <paramref name="hToken"/> for those folders that can have multiple users but are treated as belonging to a single user.
        /// The most commonly used folder of this type is Documents.
        /// The calling process is responsible for correct impersonation when <paramref name="hToken"/> is non-NULL.
        /// The calling process must have appropriate security privileges for the particular user,
        /// including <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/>, and the user's registry hive must be currently mounted.
        /// See Access Control for further discussion of access control issues.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// This enables clients of <see cref="SHGetFolderPath"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created,
        /// and includes special folders such as My Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify the path to be returned.
        /// This value is used in cases where the folder associated with a <see cref="KNOWNFOLDERID"/> (or <see cref="CSIDL"/>) can be moved,
        /// renamed, redirected, or roamed across languages by a user or administrator.
        /// The known folder system that underlies <see cref="SHGetFolderPath"/> allows users or administrators
        /// to redirect a known folder to a location that suits their needs.
        /// This is achieved by calling <see cref="IKnownFolderManager.Redirect"/>,
        /// which sets the "current" value of the folder associated with the <see cref="SHGFP_TYPE_CURRENT"/> flag.
        /// The default value of the folder, which is the location of the folder if a user or administrator had not redirected it elsewhere,
        /// is retrieved by specifying the <see cref="SHGFP_TYPE_DEFAULT"/> flag.
        /// This value can be used to implement a "restore defaults" feature for a known folder.
        /// For example, the default value (<see cref="SHGFP_TYPE_DEFAULT"/>)
        /// for <see cref="FOLDERID_Music"/> (<see cref="CSIDL_MYMUSIC"/>) is "C:\Users\user name\Music".
        /// If the folder was redirected, the current value (<see cref="SHGFP_TYPE_CURRENT"/>) might be "D:\Music".
        /// If the folder has not been redirected, then <see cref="SHGFP_TYPE_DEFAULT"/> and <see cref="SHGFP_TYPE_CURRENT"/> retrieve the same path.
        /// <see cref="SHGFP_TYPE_CURRENT"/>: Retrieve the folder's current path.
        /// <see cref="SHGFP_TYPE_DEFAULT"/>: Retrieve the folder's default path.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string of length <see cref="MAX_PATH"/> which will receive the path.
        /// If an error occurs or <see cref="S_FALSE"/> is returned, this string will be empty.
        /// The returned path does not include a trailing backslash. 
        /// For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This function is a superset of <see cref="SHGetSpecialFolderPath"/>.
        /// Only some <see cref="CSIDL"/> values are supported, including the following:
        /// <see cref="CSIDL_ADMINTOOLS"/>, <see cref="CSIDL_APPDATA"/>, <see cref="CSIDL_COMMON_ADMINTOOLS"/>,
        /// <see cref="CSIDL_COMMON_APPDATA"/>, <see cref="CSIDL_COMMON_DOCUMENTS"/>, <see cref="CSIDL_COOKIES"/>,
        /// <see cref="CSIDL_FLAG_CREATE"/>, <see cref="CSIDL_FLAG_DONT_VERIFY"/>, <see cref="CSIDL_HISTORY"/>,
        /// <see cref="CSIDL_INTERNET_CACHE"/>, <see cref="CSIDL_LOCAL_APPDATA"/>, <see cref="CSIDL_MYPICTURES"/>,
        /// <see cref="CSIDL_PERSONAL"/>, <see cref="CSIDL_PROGRAM_FILES"/>, <see cref="CSIDL_PROGRAM_FILES_COMMON"/>,
        /// <see cref="CSIDL_SYSTEM"/>, <see cref="CSIDL_WINDOWS"/>
        /// </remarks>
        [Obsolete("As of Windows Vista, this function is merely a wrapper for SHGetKnownFolderPath." +
            "The CSIDL value is translated to its associated KNOWNFOLDERID and then SHGetKnownFolderPath is called." +
            "New applications should use the known folder system rather than the older CSIDL system," +
            "which is supported only for backward compatibility.")]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetFolderPathW", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetFolderPath([In] HWND hwnd, [In] CSIDL csidl, [In] HANDLE hToken, [In] SHGFP_TYPE dwFlags, [In] IntPtr pszPath);

        /// <summary>
        /// <para>
        /// Retrieves the full path of a known folder identified by the folder's <see cref="KNOWNFOLDERID"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetknownfolderpath
        /// </para>
        /// </summary>
        /// <param name="rfid">
        /// A reference to the <see cref="KNOWNFOLDERID"/> that identifies the folder.
        /// </param>
        /// <param name="dwFlags">
        /// Flags that specify special retrieval options.
        /// This value can be 0; otherwise, one or more of the <see cref="KNOWN_FOLDER_FLAG"/> values.
        /// </param>
        /// <param name="hToken">
        /// An access token that represents a particular user.
        /// If this parameter is <see cref="NULL"/>, which is the most common usage, the function requests the known folder for the current user.
        /// Request a specific user's folder by passing the hToken of that user.
        /// This is typically done in the context of a service that has sufficient privileges to retrieve the token of a given user.
        /// That token must be opened with <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_IMPERSONATE"/> rights.
        /// In some cases, you also need to include <see cref="TOKEN_DUPLICATE"/>.
        /// In addition to passing the user's <paramref name="hToken"/>, the registry hive of that specific user must be mounted.
        /// See Access Control for further discussion of access control issues.
        /// Assigning the hToken parameter a value of -1 indicates the Default User.
        /// This allows clients of <see cref="SHGetKnownFolderPath"/> to find folder locations (such as the Desktop folder) for the Default User.
        /// The Default User user profile is duplicated when any new user account is created,
        /// and includes special folders such as Documents and Desktop.
        /// Any items added to the Default User folder also appear in any new user account.
        /// Note that access to the Default User folders requires administrator privileges.
        /// </param>
        /// <param name="ppszPath">
        /// When this method returns, contains the address of a pointer to a null-terminated Unicode string that specifies the path of the known folder.
        /// The calling process is responsible for freeing this resource once it is no longer needed by calling <see cref="CoTaskMemFree"/>,
        /// whether <see cref="SHGetKnownFolderPath"/> succeeds or not.
        /// The returned path does not include a trailing backslash. For example, "C:\Users" is returned rather than "C:\Users\".
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise, including the following:
        /// <see cref="E_FAIL"/>:
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter references a <see cref="KNOWNFOLDERID"/>
        /// which does not have a path (such as a folder marked as <see cref="KF_CATEGORY_VIRTUAL"/>).
        /// <see cref="E_INVALIDARG"/>:
        /// Among other things, this value can indicate that the <paramref name="rfid"/> parameter
        /// references a <see cref="KNOWNFOLDERID"/> that is not present on the system.
        /// Not all <see cref="KNOWNFOLDERID"/> values are present on all systems.
        /// Use <see cref="IKnownFolderManager.GetFolderIds"/> to retrieve the set of <see cref="KNOWNFOLDERID"/> values for the current system.
        /// </returns>
        /// <remarks>
        /// This function replaces <see cref="SHGetFolderPath"/>.
        /// That older function is now simply a wrapper for <see cref="SHGetKnownFolderPath"/>.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetKnownFolderPath", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetKnownFolderPath([In] in KNOWNFOLDERID rfid, [In] KNOWN_FOLDER_FLAG dwFlags,
            [In] HANDLE hToken, [Out] out string ppszPath);

        /// <summary>
        /// <para>
        /// Retrieves the display name of an item identified by its IDList.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-shgetnamefromidlist
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// A PIDL that identifies the item.
        /// </param>
        /// <param name="sigdnName">
        /// A value from the <see cref="SIGDN"/> enumeration that specifies the type of display name to retrieve.
        /// </param>
        /// <param name="ppszName">
        /// A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// It is the responsibility of the caller to free the string pointed to by <paramref name="ppszName"/> when it is no longer needed.
        /// Call <see cref="CoTaskMemFree"/> on *<paramref name="ppszName"/> to free the memory.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetNameFromIDList", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetNameFromIDList([In] LPCITEMIDLIST pidl, [In] SIGDN sigdnName,
            [MarshalAs(UnmanagedType.LPWStr)][Out] out string ppszName);

        /// <summary>
        /// <para>
        /// Converts an item identifier list to a file system path.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetpathfromidlistw
        /// </para>
        /// </summary>
        /// <param name="pidl">
        /// The address of an item identifier list that specifies a file or directory location relative to the root of the namespace (the desktop).
        /// </param>
        /// <param name="pszPath">
        /// The address of a buffer to receive the file system path.
        /// This buffer must be at least <see cref="MAX_PATH"/> characters in size.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// If the location specified by the <paramref name="pidl"/> parameter is not part of the file system, this function will fail.
        /// If the <paramref name="pidl"/> parameter specifies a shortcut,
        /// the <paramref name="pszPath"/> will contain the path to the shortcut, not to the shortcut's target.
        /// The shlobj_core.h header defines <see cref="SHGetPathFromIDList"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetPathFromIDListW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SHGetPathFromIDList([In] LPCITEMIDLIST pidl, [In] IntPtr pszPath);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the <see cref="ITEMIDLIST"/> structure of a special folder.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetspecialfolderlocation
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> value that identifies the folder of interest.
        /// </param>
        /// <param name="ppidl">
        /// A PIDL specifying the folder's location relative to the root of the namespace (the desktop).
        /// It is the responsibility of the calling application to free the returned IDList by using <see cref="CoTaskMemFree"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [Obsolete("SHGetSpecialFolderLocation is not supported and may be altered or unavailable in the future. Instead, use SHGetFolderLocation.")]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetSpecialFolderLocation", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetSpecialFolderLocation([In] HWND hwnd, [In] CSIDL csidl, [Out] out LPITEMIDLIST ppidl);

        /// <summary>
        /// <para>
        /// Retrieves the path of a special folder, identified by its <see cref="CSIDL"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlobj_core/nf-shlobj_core-shgetspecialfolderpathw
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// Reserved.
        /// </param>
        /// <param name="pszPath">
        /// A pointer to a null-terminated string that receives the drive and path of the specified folder.
        /// This buffer must be at least <see cref="MAX_PATH"/> characters in size.
        /// </param>
        /// <param name="csidl">
        /// A <see cref="CSIDL"/> that identifies the folder of interest.
        /// If a virtual folder is specified, this function will fail.
        /// </param>
        /// <param name="fCreate">
        /// Indicates whether the folder should be created if it does not already exist.
        /// If this value is nonzero, the folder is created.
        /// If this value is zero, the folder is not created.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// The Microsoft Internet Explorer 4.0 Desktop Update must be installed for this function to be available.
        /// The shlobj_core.h header defines <see cref="SHGetSpecialFolderPath"/> as an alias which automatically selects
        /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
        /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
        /// mismatches that result in compilation or runtime errors.
        /// For more information, see Conventions for Function Prototypes.
        /// </remarks>
        [Obsolete("SHGetSpecialFolderPath is not supported. Instead, use SHGetFolderPath.")]
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetSpecialFolderPathW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SHGetSpecialFolderPath([In] HWND hwnd, [In] IntPtr pszPath, [In] CSIDL csidl, [In] BOOL fCreate);

        /// <summary>
        /// <para>
        /// Retrieves information about system-defined Shell icons.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/nf-shellapi-shgetstockiconinfo
        /// </para>
        /// </summary>
        /// <param name="siid">
        /// One of the values from the <see cref="SHSTOCKICONID"/> enumeration that specifies which icon should be retrieved.
        /// </param>
        /// <param name="uFlags">
        /// A combination of zero or more of the following flags that specify which information is requested.
        /// </param>
        /// <param name="psii">
        /// A pointer to a <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function is called, the <see cref="SHSTOCKICONINFO.cbSize"/> member of this structure needs to be
        /// set to the size of the <see cref="SHSTOCKICONINFO"/> structure.
        /// When this function returns, contains a pointer to a <see cref="SHSTOCKICONINFO"/> structure that contains the requested information.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If this function returns an icon handle in the <see cref="SHSTOCKICONINFO.hIcon"/> member of the <see cref="SHSTOCKICONINFO"/> structure
        /// pointed to by <paramref name="psii"/>, you are responsible for freeing the icon with <see cref="DestroyIcon"/> when you no longer need it.
        /// </remarks>
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "SHGetStockIconInfo", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT SHGetStockIconInfo([In] SHSTOCKICONID siid, [In] SHGetStockIconInfoFlags uFlags, [Out] out SHSTOCKICONINFO psii);
    }
}
