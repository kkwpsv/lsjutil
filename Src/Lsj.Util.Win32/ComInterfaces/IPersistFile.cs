using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables an object to be loaded from or saved to a disk file, rather than a storage object or stream.
    /// Because the information needed to open a file varies greatly from one application to another
    /// the implementation of <see cref="Load"/> on the object must also open its disk file.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-ipersistfile
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IPersistFile)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistFile : IPersist
    {
        /// <summary>
        /// From <see cref="IPersist"/>, just make COM happy.
        /// </summary>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT GetClassID([Out] out Guid pClassID);

        /// <summary>
        /// Determines whether an object has changed since it was last saved to its current file.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the object has changed.
        /// Otherwise, it returns <see cref="S_FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Use this method to determine whether an object should be saved before closing it.
        /// The dirty flag for an object is conditionally cleared in the <see cref="Save"/> method.
        /// Notes to Callers
        /// OLE does not call <see cref="IsDirty"/>. Applications would not call it unless they are also saving an object to a file.
        /// You should treat any error return codes as an indication that the object has changed.
        /// Unless this method explicitly returns S_FALSE, assume that the object must be saved.
        /// Notes to Implementers
        /// An object with no contained objects simply checks its dirty flag to return the appropriate result.
        /// A container with one or more contained objects must maintain an internal dirty flag that is set
        /// when any of its contained objects has changed since it was last saved.
        /// To do this, the container should maintain an advise sink by implementing the <see cref="IAdviseSink"/> interface.
        /// Then, the container can register each link or embedding for data change notifications with a call to <see cref="IDataObject.DAdvise"/>.
        /// Then, the container can set its internal dirty flag when it receives an <see cref="IAdviseSink.OnDataChange"/> notification.
        /// If the container does not register for data change notifications, the <see cref="IsDirty"/> implementation
        /// would call <see cref="IsDirty"/> for each of its contained objects to determine whether they have changed.
        /// The container can clear its dirty flag whenever it is saved, as long as the file to
        /// which the object is saved is the current working file after the save.
        /// Therefore, the dirty flag would be cleared after a successful Save or Save As operation, but not after a Save A Copy As . . . operation.
        /// </remarks>
        [PreserveSig]
        HRESULT IsDirty();

        /// <summary>
        /// Opens the specified file and initializes an object from the file contents.
        /// </summary>
        /// <param name="pszFileName">
        /// The absolute path of the file to be opened.
        /// </param>
        /// <param name="dwMode">
        /// The access mode to be used when opening the file.
        /// Possible values are taken from the <see cref="STGM"/> enumeration.
        /// The method can treat this value as a suggestion, adding more restrictive permissions if necessary.
        /// If <paramref name="dwMode"/> is 0, the implementation should open the file
        /// using whatever default permissions are used when a user opens the file.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_OUTOFMEMORY"/>: The object could not be loaded due to a lack of memory.
        /// <see cref="E_FAIL"/>: The object could not be loaded for some reason other than a lack of memory.
        /// </returns>
        /// <remarks>
        /// <see cref="Load"/> loads the object from the specified file.
        /// This method is for initialization only and does not show the object to the end user.
        /// It is not equivalent to what occurs when a user selects the File Open command.
        /// Notes to Callers
        /// The <see cref="IMoniker.BindToObject"/> method in file monikers calls this method to load an object
        /// during a moniker binding operation (when a linked object is run).
        /// Typically, applications do not call this method directly.
        /// Notes to Implementers
        /// Because the information needed to open a file varies greatly from one application to another,
        /// the object on which this method is implemented must also open the file specified by the <paramref name="pszFileName"/> parameter.
        /// This differs from the <see cref="IPersistStorage.Load"/>::Load and <see cref="IPersistStream.Load"/>,
        /// in which the caller opens the storage or stream and then passes an open storage or stream pointer to the loaded object.
        /// For an application that normally uses OLE compound files, your <see cref="Load"/> implementation can simply
        /// call the <see cref="StgOpenStorage"/> function to open the storage object in the specified file.
        /// Then, you can proceed with normal initialization.
        /// Applications that do not use storage objects can perform normal file-opening procedures.
        /// When the object has been loaded, your implementation should register the object in the running object table
        /// (see <see cref="IRunningObjectTable.Register"/>).
        /// </remarks>
        [PreserveSig]
        HRESULT Load([MarshalAs(UnmanagedType.LPWStr)][In] string pszFileName, [In] STGM dwMode);

        /// <summary>
        /// Saves a copy of the object to the specified file.
        /// </summary>
        /// <param name="pszFileName">
        /// The absolute path of the file to which the object should be saved.
        /// If <paramref name="pszFileName"/> is <see langword="null"/>, the object should save its data to the current file, if there is one.
        /// </param>
        /// <param name="fRemember">
        /// Indicates whether the <paramref name="pszFileName"/> parameter is to be used as the current working file.
        /// If <see cref="TRUE"/>, <paramref name="pszFileName"/> becomes the current file and the object should clear its dirty flag after the save.
        /// If <see cref="FALSE"/>, this save operation is a Save A Copy As ... operation.
        /// In this case, the current file is unchanged and the object should not clear its dirty flag.
        /// If <paramref name="pszFileName"/> is <see langword="null"/>, the implementation should ignore the <paramref name="fRemember"/> flag.
        /// </param>
        /// <returns>
        /// If the object was successfully saved, the return value is <see cref="S_OK"/>.
        /// Otherwise, it is <see cref="S_FALSE"/>. This method can also return various storage errors.
        /// </returns>
        /// <remarks>
        /// This method can be called to save an object to the specified file in one of three ways:
        /// The implementer must detect which type of save operation the caller is requesting.
        /// If the <paramref name="pszFileName"/> parameter is <see langword="null"/>, a Save is being requested.
        /// If the <paramref name="pszFileName"/> parameter is not <see langword="null"/>,
        /// use the value of the <paramref name="fRemember"/> parameter to distinguish between a Save As and a Save a Copy As.
        /// In Save or Save As operations, IPersistFile::Save clears the internal dirty flag after the save
        /// and sends <see cref="IAdviseSink.OnSave"/> notifications to any advisory connections (see also <see cref="IOleAdviseHolder.SendOnSave"/>).
        /// Also, in these operations, the object is in NoScribble mode until it receives an <see cref="SaveCompleted"/> call.
        /// In NoScribble mode, the object must not write to the file.
        /// In the Save As scenario, the implementation should also send <see cref="IAdviseSink.OnRename"/> notifications
        /// to any advisory connections (see also <see cref="IOleAdviseHolder.SendOnRename"/>).
        /// In the Save a Copy As scenario, the implementation does not clear the internal dirty flag after the save.
        /// Notes to Callers
        /// OLE does not call <see cref="Save"/>.
        /// Typically, applications would not call it unless they are saving an object to a file directly, which is generally left to the end-user. 
        /// </remarks>
        [PreserveSig]
        HRESULT Save([MarshalAs(UnmanagedType.LPWStr)][In] string pszFileName, [In] BOOL fRemember);

        /// <summary>
        /// Notifies the object that it can write to its file.
        /// It does this by notifying the object that it can revert from NoScribble mode (in which it must not write to its file),
        /// to Normal mode (in which it can).
        /// The component enters NoScribble mode when it receives an <see cref="Save"/> call.
        /// </summary>
        /// <param name="pszFileName">
        /// The absolute path of the file where the object was saved previously.
        /// </param>
        /// <returns>
        /// This method always returns <see cref="S_OK"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="SaveCompleted"/> is called when a call to <see cref="Save"/> is completed,
        /// and the file that was saved is now the current working file (having been saved with Save or Save As operations).
        /// The call to Save puts the object into NoScribble mode so it cannot write to its file.
        /// When <see cref="SaveCompleted"/> is called, the object reverts to Normal mode, in which it is free to write to its file.
        /// Notes to Callers
        /// OLE does not call the <see cref="SaveCompleted"/> method.
        /// Typically, applications would not call it unless they are saving objects directly to files,
        /// an operation which is generally left to the end-user. 
        /// </remarks>
        [PreserveSig]
        HRESULT SaveCompleted([MarshalAs(UnmanagedType.LPWStr)][In] string pszFileName);

        /// <summary>
        /// Retrieves the current name of the file associated with the object.
        /// If there is no current working file, this method retrieves the default save prompt for the object.
        /// </summary>
        /// <param name="ppszFileName">
        /// The path for the current file or the default file name prompt (such as *.txt).
        /// If an error occurs, <paramref name="ppszFileName"/> is set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: A valid absolute path was returned successfully.
        /// <see cref="S_FALSE"/>: The default save prompt was returned.
        /// <see cref="E_OUTOFMEMORY"/>: The operation failed due to insufficient memory.
        /// <see cref="E_FAIL"/>: The operation failed due to some reason other than insufficient memory.
        /// </returns>
        /// <remarks>
        /// This method allocates memory for the string returned in the <paramref name="ppszFileName"/> parameter
        /// using the <see cref="IMalloc.Alloc"/> method.
        /// The caller is responsible for calling the <see cref="IMalloc.Free"/> method to free the string.
        /// Both the caller and this method use the OLE task allocator provided by a call to <see cref="CoGetMalloc"/>.
        /// The file name returned in <paramref name="ppszFileName"/> is the name specified in a call to <see cref="Load"/>
        /// when the document was loaded; or in <see cref="SaveCompleted"/> if the document was saved to a different file.
        /// If the object does not have a current working file, it should provide the default prompt that it would display in a Save As dialog box.
        /// For example, the default save prompt for a word processor object could be "*.txt".
        /// Notes to Callers
        /// OLE does not call the <see cref="GetCurFile"/> method.
        /// Applications would not call this method unless they are also calling the save methods of this interface.
        /// In saving the object, you can call this method before calling <see cref="Save"/> to determine whether the object has an associated file.
        /// If this method returns <see cref="S_OK"/>, you can then call <see cref="Save"/> with a <see langword="null"/> filename
        /// and a <see cref="TRUE"/> value for the fRemember parameter to tell the object to save itself to its current file.
        /// If this method returns <see cref="S_FALSE"/>, you can use the save prompt returned in the <paramref name="ppszFileName"/> parameter
        /// to ask the end user to provide a file name.
        /// Then, you can call <see cref="Save"/> with the file name that the user entered to perform a Save As operation.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurFile([Out] out IntPtr ppszFileName);
    }
}
