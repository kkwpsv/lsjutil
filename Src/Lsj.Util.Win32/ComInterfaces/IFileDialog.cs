using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that initialize, show, and get results from the common file dialog.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifiledialog
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IFileDialog)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFileDialog : IModalWindow
    {
        /// <summary>
        /// From <see cref="IModalWindow"/>, just make COM happy.
        /// </summary>
        /// <param name="parent"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT Show([In]IntPtr parent);

        /// <summary>
        /// Sets the file types that the dialog can open or save.
        /// </summary>
        /// <param name="cFileTypes">
        /// The number of elements in the array specified by <paramref name="rgFilterSpec"/>.
        /// </param>
        /// <param name="rgFilterSpec">
        /// A pointer to an array of <see cref="COMDLG_FILTERSPEC"/> structures, each representing a file type.
        /// </param>
        /// <returns>
        /// If the method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code, including the following:
        /// <see cref="E_UNEXPECTED"/>: <see cref="SetFileTypes"/> has already been called.
        /// <see cref="E_UNEXPECTED"/>: The <see cref="FOS_PICKFOLDERS"/> flag was set in the <see cref="SetOptions"/> method.
        /// <see cref="E_INVALIDARG"/>: The <paramref name="rgFilterSpec"/> parameter is NULL.
        /// </returns>
        /// <remarks>
        /// When using the Open dialog, the file types declared there are used to filter the view.
        /// When using the Save dialog, these values determine which file name extension is appended to the file name.
        /// This method must be called before the dialog is shown and can only be called once for each dialog instance.
        /// File types cannot be modified once the Common Item dialog box is displayed.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFileTypes([In]uint cFileTypes, [MarshalAs(UnmanagedType.LPArray)][In]COMDLG_FILTERSPEC[] rgFilterSpec);

        /// <summary>
        /// Sets the file type that appears as selected in the dialog.
        /// </summary>
        /// <param name="iFileType">
        /// The index of the file type in the file type array passed to <see cref="SetFileTypes"/> in its cFileTypes parameter.
        /// Note that this is a one-based index, not zero-based.
        /// </param>
        /// <returns></returns>
        [PreserveSig]
        HRESULT SetFileTypeIndex([In]uint iFileType);

        /// <summary>
        /// Gets the currently selected file type.
        /// </summary>
        /// <param name="piFileType">
        /// A pointer to a UINT value that receives the index of the selected file type in the file type array
        /// passed to <see cref="SetFileTypes"/> in its cFileTypes parameter.
        /// This is a one-based index rather than zero-based.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>. Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <see cref="GetFileTypeIndex"/> can be called either while the dialog is open or after it has closed.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFileTypeIndex([Out]out uint piFileType);

        /// <summary>
        /// Assigns an event handler that listens for events coming from the dialog.
        /// </summary>
        /// <param name="pfde">
        /// A pointer to an <see cref="IFileDialogEvents"/> implementation that will receive events from the dialog.
        /// </param>
        /// <param name="pdwCookie">
        /// A pointer to a DWORD that receives a value identiying this event handler.
        /// When the client is finished with the dialog, that client must call the <see cref="Unadvise"/> method with this value.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT Advise([MarshalAs(UnmanagedType.Interface)]IFileDialogEvents pfde, [Out]out uint pdwCookie);

        /// <summary>
        /// Removes an event handler that was attached through the <see cref="Advise"/> method.
        /// </summary>
        /// <param name="dwCookie">
        /// The DWORD value that represents the event handler.
        /// This value is obtained through the <paramref name="dwCookie"/> parameter of the <see cref="Advise"/> method.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT Unadvise([In]uint dwCookie);

        /// <summary>
        /// Sets flags to control the behavior of the dialog.
        /// </summary>
        /// <param name="fos">
        /// One or more of the <see cref="FILEOPENDIALOGOPTIONS"/> values.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Generally, this method should take the value that was retrieved by <see cref="GetOptions"/>
        /// and modify it to include or exclude options by setting the appropriate flags.
        /// </remarks>
        [PreserveSig]
        HRESULT SetOptions([In]FILEOPENDIALOGOPTIONS fos);

        /// <summary>
        /// Gets the current flags that are set to control dialog behavior.
        /// </summary>
        /// <param name="pfos">
        /// When this method returns successfully, points to a value made up of one or more of the <see cref="FILEOPENDIALOGOPTIONS"/> values.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT GetOptions([Out]out FILEOPENDIALOGOPTIONS pfos);

        /// <summary>
        /// Sets the folder used as a default if there is not a recently used folder value available.
        /// </summary>
        /// <param name="psi">
        /// A pointer to the interface that represents the folder.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT SetDefaultFolder([MarshalAs(UnmanagedType.Interface)][In]IShellItem psi);

        /// <summary>
        /// Sets a folder that is always selected when the dialog is opened, regardless of previous user action.
        /// </summary>
        /// <param name="psi">
        /// A pointer to the interface that represents the folder.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This folder overrides any "most recently used" folder. If this method is called while the dialog is displayed,
        /// it causes the dialog to navigate to the specified folder.
        /// In general, we do not recommended the use of this method.
        /// If you call <see cref="SetFolder"/> before you display the dialog box, the most recent location that the user saved to or opened from is not shown.
        /// Unless there is a very specific reason for this behavior, it is not a good or expected user experience and should therefore be avoided.
        /// In almost all instances, <see cref="SetDefaultFolder"/> is the better method.
        /// As of Windows 7, if the path of the folder specified through psi is the default path of a known folder,
        /// the known folder's current path is used in the dialog.
        /// That path might not be the same as the path specified in psi; for instance, if the known folder has been redirected.
        /// If the known folder is a library (virtual folders Documents, Music, Pictures, and Videos), the library's path is used in the dialog.
        /// If the specified library is hidden (as they are by default as of Windows 8.1), the library's default save location is used in the dialog,
        /// such as the Microsoft OneDrive Documents folder for the Documents library.
        /// Because of these mappings, the folder location used in the dialog might not be exactly as you specified when you called this method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetFolder([MarshalAs(UnmanagedType.Interface)][In]IShellItem psi);

        /// <summary>
        /// Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed,
        /// the folder that is to be selected when the dialog is opened.
        /// </summary>
        /// <param name="ppsi">
        /// The address of a pointer to the interface that represents the folder.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The calling application is responsible for releasing the retrieved <see cref="IShellItem"/> when it is no longer needed.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFolder([MarshalAs(UnmanagedType.Interface)][Out]out IShellItem ppsi);

        /// <summary>
        /// Gets the user's current selection in the dialog.
        /// </summary>
        /// <param name="ppsi">
        /// The address of a pointer to the interface that represents the item currently selected in the dialog.
        /// This item can be a file or folder selected in the view window, or something that the user has entered into the dialog's edit box.
        /// The latter case may require a parsing operation (cancelable by the user) that blocks the current thread.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The calling application is responsible for releasing the retrieved <see cref="IShellItem"/> when it is no longer needed.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentSelection([MarshalAs(UnmanagedType.Interface)][Out]out IShellItem ppsi);

        /// <summary>
        /// Sets the file name that appears in the File name edit box when that dialog box is opened.
        /// </summary>
        /// <param name="pszName">
        /// A pointer to the name of the file.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT SetFileName([MarshalAs(UnmanagedType.LPWStr)][In]string pszName);

        /// <summary>
        /// Retrieves the text currently entered in the dialog's File name edit box.
        /// </summary>
        /// <param name="pszName">
        /// The address of a pointer to a buffer that, when this method returns successfully, receives the text.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The text in the File name edit box does not necessarily reflect the item the user chose.
        /// To get the item the user chose, use <see cref="GetResult"/>.
        /// The calling application is responsible for releasing the retrieved buffer by using the <see cref="CoTaskMemFree"/> function.
        /// </remarks>
        [PreserveSig]
        HRESULT GetFileName([MarshalAs(UnmanagedType.LPWStr)][Out]out string pszName);

        /// <summary>
        /// Sets the title of the dialog.
        /// </summary>
        /// <param name="pszTitle">
        /// A pointer to a buffer that contains the title text.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT SetTitle([MarshalAs(UnmanagedType.LPWStr)][In]string pszTitle);

        /// <summary>
        /// <para>
        /// Sets the text of the Open or Save button.
        /// </para>
        /// </summary>
        /// <param name="pszText">
        /// A pointer to a buffer that contains the button text.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT SetOkButtonLabel([MarshalAs(UnmanagedType.LPWStr)][In]string pszText);

        /// <summary>
        /// Sets the text of the label next to the file name edit box.
        /// </summary>
        /// <param name="pszLabel">
        /// A pointer to a buffer that contains the label text.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        [PreserveSig]
        HRESULT SetFileNameLabel([MarshalAs(UnmanagedType.LPWStr)][In]string pszLabel);

        /// <summary>
        /// Gets the choice that the user made in the dialog.
        /// </summary>
        /// <param name="ppsi">
        /// The address of a pointer to an <see cref="IShellItem"/> that represents the user's choice.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <see cref="GetResult"/> can be called after the dialog has closed or during the handling of an OnFileOk event.
        /// Calling this method at any other time will fail.
        /// If multiple items were chosen, this method will fail.
        /// In the case of multiple items, call <see cref="GetResults"/>.
        /// <see cref="Show"/> must return a success code for a result to be available to <see cref="GetResult"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT GetResult([MarshalAs(UnmanagedType.Interface)][Out]out IShellItem ppsi);

        /// <summary>
        /// Adds a folder to the list of places available for the user to open or save items.
        /// </summary>
        /// <param name="psi">
        /// A pointer to an <see cref="IShellItem"/> that represents the folder to be made available to the user.
        /// This can only be a folder.
        /// </param>
        /// <param name="fdap">
        /// Specifies where the folder is placed within the list.
        /// See <see cref="FDAP"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <see cref="SHSetTemporaryPropertyForItem"/> can be used to set a temporary <see cref="PKEY_ItemNameDisplay"/> property
        /// on the item represented by the <paramref name="psi"/> parameter.
        /// The value for this property will be used in place of the item's UI name.
        /// </remarks>
        [PreserveSig]
        HRESULT AddPlace([MarshalAs(UnmanagedType.Interface)][In]IShellItem psi, [In]FDAP fdap);

        /// <summary>
        /// Sets the default extension to be added to file names.
        /// </summary>
        /// <param name="pszDefaultExtension">
        /// A pointer to a buffer that contains the extension text.
        /// This string should not include a leading period. For example, "jpg" is correct, while ".jpg" is not.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// If this method is called before showing the dialog, the dialog will update the default extension automatically
        /// when the user chooses a new file type (see <see cref="SetFileTypes"/>).
        /// </remarks>
        [PreserveSig]
        HRESULT SetDefaultExtension([MarshalAs(UnmanagedType.LPWStr)][In]string pszDefaultExtension);

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        /// <param name="hr">
        /// The code that will be returned by <see cref="Show"/> to indicate that the dialog was closed before a selection was made.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// An application can call this method from a callback method or function while the dialog is open.
        /// The dialog will close and the <see cref="Show"/> method will return with the <see cref="HRESULT"/> specified in <paramref name="hr"/>.
        /// If this method is called, there is no result available for the <see cref="GetResult"/> or <see cref="GetResults"/> methods,
        /// and they will fail if called.
        /// </remarks>
        [PreserveSig]
        HRESULT Close([In]HRESULT hr);

        /// <summary>
        /// Enables a calling application to associate a GUID with a dialog's persisted state.
        /// </summary>
        /// <param name="guid">
        /// The GUID to associate with this dialog state.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// A dialog's state can include factors such as the last visited folder and the position and size of the dialog.
        /// Typically, this state is persisted based on the name of the executable file.
        /// By specifying a GUID, an application can have different persisted states for different versions of the dialog
        /// within the same application (for example, an import dialog and an open dialog).
        /// <see cref="SetClientGuid"/> should be called immediately after creation of the dialog object.
        /// </remarks>
        [PreserveSig]
        HRESULT SetClientGuid([In]ref Guid guid);

        /// <summary>
        /// Instructs the dialog to clear all persisted state information.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Persisted information can be associated with an application or a GUID.
        /// If a GUID was set by using <see cref="SetClientGuid"/>, that GUID is used to clear persisted information.
        /// </remarks>
        [PreserveSig]
        HRESULT ClearClientData();

        /// <summary>
        /// Sets the filter.
        /// </summary>
        /// <param name="pFilter">
        /// A pointer to the <see cref="IShellItemFilter"/> that is to be set.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// This method can be used if the application needs to perform special filtering to remove some items from the dialog box's view.
        /// IncludeItem will be called for each item that would normally be included in the view.
        /// <see cref="GetEnumFlagsForItem"/> is not used.
        /// To filter by file type, <see cref="SetFileTypes"/> should be used,
        /// because in folders with a large number of items it may offer better performance than applying an <see cref="IShellItemFilter"/>.
        /// </remarks>
        [Obsolete("Deprecated. SetFilter is no longer available for use as of Windows 7.")]
        [PreserveSig]
        HRESULT SetFilter([MarshalAs(UnmanagedType.Interface)][In]IShellItemFilter pFilter);
    }
}
