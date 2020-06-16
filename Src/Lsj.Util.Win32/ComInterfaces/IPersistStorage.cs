using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables a container application to pass a storage object to one of its contained objects and to load and save the storage object.
    /// This interface supports the structured storage model,
    /// in which each contained object has its own storage that is nested within the container's storage.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-ipersiststorage
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IPersistStorage)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStorage : IPersist
    {
        /// <summary>
        /// From <see cref="IPersist"/>, just make COM happy.
        /// </summary>
        /// <param name="pClassID"></param>
        /// <returns></returns>
        [PreserveSig]
        new HRESULT GetClassID([Out] out Guid pClassID);

        /// <summary>
        /// Determines whether an object has changed since it was last saved to its current storage.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the object has changed. Otherwise, it returns <see cref="S_FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Use this method to determine whether an object should be saved before closing it.
        /// The dirty flag for an object is conditionally cleared in the <see cref="Save"/> method.
        /// For example, you could optimize a File Save operation by calling the <see cref="IsDirty"/> method for each object
        /// and then calling the <see cref="Save"/> method only for those objects that are dirty.
        /// Notes to Callers
        /// You should treat any error return codes as an indication that the object has changed.
        /// Unless this method explicitly returns <see cref="S_FALSE"/>, assume that the object must be saved.
        /// Notes to Implementers
        /// An object with no contained objects simply checks its dirty flag to return the appropriate result.
        /// A container with one or more contained objects must maintain an internal dirty flag that is set
        /// when any of its contained objects has changed since it was last saved.
        /// </remarks>
        [PreserveSig]
        HRESULT IsDirty();

        /// <summary>
        /// Initializes a new storage object.
        /// </summary>
        /// <param name="pStg">
        /// An IStorage pointer to the new storage object to be initialized.
        /// The container creates a nested storage object in its storage object (see <see cref="IStorage.CreateStorage"/>).
        /// Then, the container calls the <see cref="WriteClassStg"/> function
        /// to initialize the new storage object with the object class identifier (CLSID).
        /// </param>
        /// <returns></returns>
        [PreserveSig]
        HRESULT InitNew([MarshalAs(UnmanagedType.Interface)][In] IStorage pStg);

        /// <summary>
        /// Loads an object from its existing storage.
        /// </summary>
        /// <param name="pStg">
        /// An <see cref="IStorage"/> pointer to the existing storage from which the object is to be loaded.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="CO_E_ALREADYINITIALIZED"/>:
        /// The object has already been initialized by a previous call to the <see cref="Load"/> method or the <see cref="InitNew"/> method.
        /// <see cref="E_OUTOFMEMORY"/>: The object was not loaded due to lack of memory.
        /// <see cref="E_FAIL"/>: The object was not loaded due to some reason other than a lack of memory.
        /// </returns>
        /// <remarks>
        /// This method initializes an object from an existing storage.
        /// The object is placed in the loaded state if this method is called by the container application.
        /// If called by the default handler, this method places the object in the running state.
        /// Either the default handler or the object itself can hold onto the IStorage pointer while the object is loaded or running.
        /// Notes to Callers
        /// Rather than calling <see cref="Load"/> directly, you typically call the OleLoad helper function which does the following:
        /// Create an uninitialized instance of the object class.
        /// Query the new instance for the <see cref="IPersistStorage"/> interface.
        /// Call Load to initialize the object from the existing storage.
        /// You also call this method indirectly when you call the <see cref="OleCreateFromData"/> function or
        /// the <see cref="OleCreateFromFile"/> function to insert an object into a compound file (as in a drag-and-drop or clipboard paste operation).
        /// The container should cache the IPersistStorage pointer for use in later operations on the object.
        /// Notes to Implementers
        /// Your implementation should perform the following steps to load an object:
        /// Open the object's streams in the storage object, and read the necessary data into the object's internal data structures.
        /// Clear the object's dirty flag.
        /// Call the AddRef method and cache the passed in storage pointer.
        /// Keep open and cache the pointers to any streams or storages that the object will need to save itself to this storage.
        /// Perform any other default initialization required for the object.
        /// Steps 3 and 4 are particularly important for ensuring that the object can save itself in low memory situations.
        /// Holding onto pointers to the storage and stream interfaces guarantees that a save operation to this storage will not fail due to insufficient memory.
        /// Your implementation of this method should return the <see cref="CO_E_ALREADYINITIALIZED"/> error code
        /// if it receives a call to either the <see cref="InitNew"/> method or the <see cref="Load"/> method after it is already initialized.
        /// </remarks>
        [PreserveSig]
        HRESULT Load([MarshalAs(UnmanagedType.Interface)][In] IStorage pStg);

        /// <summary>
        /// Saves an object, and any nested objects that it contains, into the specified storage object. The object enters NoScribble mode.
        /// </summary>
        /// <param name="pStgSave">
        /// An <see cref="IStorage"/> pointer to the storage into which the object is to be saved.
        /// </param>
        /// <param name="fSameAsLoad">
        /// Indicates whether the specified storage is the current one, which was passed to the object by one of the following calls:
        /// <see cref="InitNew"/>, <see cref="Load"/>, or <see cref="SaveCompleted"/>.
        /// This parameter is set to <see cref="FALSE"/> when performing a Save As or Save A Copy To operation or when performing a full save.
        /// In the latter case, this method saves to a temporary file, deletes the original file, and renames the temporary file.
        /// This parameter is set to <see cref="TRUE"/> to perform a full save in a low-memory situation
        /// or to perform a fast incremental save in which only the dirty components are saved.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="STG_E_MEDIUMFULL"/>: The object was not saved because of a lack of space on the disk.
        /// <see cref="E_FAIL"/>: The object could not be saved due to errors other than a lack of disk space.
        /// </returns>
        /// <remarks>
        /// This method saves an object, and any nested objects it contains, into the specified storage.
        /// It also places the object into NoScribble mode.
        /// Thus, the object cannot write to its storage until a subsequent call
        /// to the <see cref="SaveCompleted"/> method returns the object to Normal mode.
        /// If the storage object is the same as the one it was loaded or created from,
        /// the save operation may be able to write incremental changes to the storage object.
        /// Otherwise, a full save must be done.
        /// This method recursively calls the <see cref="Save"/> method, the <see cref="OleSave"/> function,
        /// or the <see cref="IStorage.CopyTo"/> method to save its nested objects.
        /// This method does not call the <see cref="IStorage.Commit"/> method.
        /// Nor does it write the CLSID to the storage object. Both of these tasks are the responsibilities of the caller.
        /// Notes to Callers
        /// Rather than calling <see cref="Save"/> directly, you typically call the <see cref="OleSave"/> helper function
        /// which performs the following steps:
        /// Call the <see cref="WriteClassStg"/> function to write the class identifier for the object to the storage.
        /// Call the <see cref="Save"/> method.
        /// If needed, call the <see cref="IStorage.Commit"/> method on the storage object.
        /// Then, a container application performs any other operations necessary
        /// to complete the save and calls the <see cref="SaveCompleted"/> method for each object.
        /// If an embedded object passes the <see cref="Save"/> method to its nested objects,
        /// it must receive a call to its <see cref="SaveCompleted"/> method before calling this method for its nested objects.
        /// </remarks>
        [PreserveSig]
        HRESULT Save([MarshalAs(UnmanagedType.Interface)][In] IStorage pStgSave, [In] BOOL fSameAsLoad);

        /// <summary>
        /// Notifies the object that it can write to its storage object.
        /// It does this by notifying the object that it can revert from NoScribble mode (in which it must not write to its storage object),
        /// to Normal mode (in which it can).
        /// The object enters NoScribble mode when it receives an <see cref="Save"/> call.
        /// </summary>
        /// <param name="pStgNew">
        /// An <see cref="IStorage"/> pointer to the new storage object, if different from the storage object prior to saving.
        /// This pointer can be <see langword="null"/> if the current storage object does not change during the save operation.
        /// If the object is in HandsOff mode, this parameter must be non-NULL.
        /// </param>
        /// <returns>
        /// This method can return the following values.
        /// <see cref="S_OK"/>: The method completed successfully.
        /// <see cref="E_OUTOFMEMORY"/>:
        /// The object remained in HandsOff mode or NoScribble mode due to a lack of memory.
        /// Typically, this error occurs when the object is not able to open the necessary streams and storage objects in <paramref name="pStgNew"/>.
        /// <see cref="E_INVALIDARG"/>:
        /// The <paramref name="pStgNew"/> parameter is not valid.
        /// Typically, this error occurs if <paramref name="pStgNew"/> is <see langword="null"/> when the object is in HandsOff mode.
        /// <see cref="E_UNEXPECTED"/>:
        /// The object is in Normal mode, and there was no previous call to <see cref="Save"/> or <see cref="HandsOffStorage"/>. 
        /// </returns>
        /// <remarks>
        /// This method notifies an object that it can revert to Normal mode and can once again write to its storage object.
        /// The object exits NoScribble mode or HandsOff mode.
        /// If the object is reverting from HandsOff mode, the <paramref name="pStgNew"/> parameter must be non-NULL.
        /// In HandsOffFromNormal mode, this parameter is the new storage object
        /// that replaces the one that was revoked by the <see cref="HandsOffStorage"/> method.
        /// The data in the storage object is a copy of the data from the revoked storage object.
        /// In HandsOffAfterSave mode, the data is the same as the data that was most recently saved.
        /// It is not the same as the data in the revoked storage object.
        /// If the object is reverting from NoScribble mode, the <paramref name="pStgNew"/> parameter can be NULL or non-NULL.
        /// If NULL, the object once again has access to its storage object.
        /// If it is not NULL, the component object should simulate receiving a call to its <see cref="HandsOffStorage"/> method.
        /// If the component object cannot simulate this call,
        /// its container must be prepared to actually call the <see cref="HandsOffStorage"/> method.
        /// This method must recursively call any nested objects that are loaded or running.
        /// If this method returns an error code, the object is not returned to Normal mode.
        /// Thus, the container object can attempt different save strategies.
        /// </remarks>
        [PreserveSig]
        HRESULT SaveCompleted([MarshalAs(UnmanagedType.Interface)][In] IStorage pStgNew);

        /// <summary>
        /// Instructs the object to release all storage objects that have been passed to it by its container and to enter HandsOff mode.
        /// </summary>
        /// <returns>
        /// This method returns <see cref="S_OK"/> to indicate that the object has entered HandsOff mode successfully.
        /// </returns>
        /// <remarks>
        /// This method causes an object to release any storage objects that it is holding
        /// and to enter the HandsOff mode until a subsequent <see cref="SaveCompleted"/> call.
        /// In HandsOff mode, the object cannot do anything and the only operation that works is a close operation.
        /// A container application typically calls this method during a full save or low-memory full save operation
        /// to force the object to release all pointers to its current storage.
        /// In these scenarios, the HandsOffStorage call comes after a call to either <see cref="OleSave"/> or <see cref="Save"/>,
        /// putting the object in HandsOffAfterSave mode.
        /// Calling this method is necessary so the container application can delete the current file as part of a full save,
        /// or so it can call the <see cref="IRootStorage.SwitchToFile"/> method as part of a low-memory save.
        /// A container application also calls this method when an object is in Normal mode to put the object in HandsOffFromNormal mode.
        /// While the component object is in either HandsOffAfterSave or HandsOffFromNormal mode, most operations on the object will fail.
        /// Thus, the container should restore the object to Normal mode as soon as possible.
        /// The container application does this by calling the <see cref="SaveCompleted"/> method,
        /// which passes a storage pointer back to the component object for the new storage object.
        /// Notes to Implementers
        /// This method must release all pointers to the current storage object, including pointers to any nested streams and storages.
        /// If the object contains nested objects, the container application must recursively
        /// call this method for any nested objects that are loaded or running. 
        /// </remarks>
        [PreserveSig]
        HRESULT HandsOffStorage();
    }
}
