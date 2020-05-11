using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.CLSID;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.STGC;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.Enums.STGMOVE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using FILETIME = Lsj.Util.Win32.Structs.FILETIME;
using STATSTG = Lsj.Util.Win32.Structs.STATSTG;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IStorage"/> interface supports the creation and management of structured storage objects.
    /// Structured storage allows hierarchical storage of information within a single file, and is often referred to as "a file system within a file".
    /// Elements of a structured storage object are storages and streams.
    /// Storages are analogous to directories, and streams are analogous to files.
    /// Within a structured storage there will be a primary storage object that may contain substorages, possibly nested, and streams.
    /// Storages provide the structure of the object, and streams contain the data, which is manipulated through the <see cref="IStream"/> interface.
    /// The <see cref="IStorage"/> interface provides methods for
    /// creating and managing the root storage object, child storage objects, and stream objects.
    /// These methods can create, open, enumerate, move, copy, rename, or delete the elements in the storage object.
    /// An application must release its <see cref="IStorage"/> pointers when it is done with the storage object to deallocate memory used.
    /// There are also methods for changing the date and time of an element.
    /// There are a number of different modes in which a storage object and its elements can be opened,
    /// determined by setting values from <see cref="STGM"/> Constants.
    /// One aspect of this is how changes are committed.
    /// You can set direct mode, in which changes to an object are immediately written to it, or transacted mode,
    /// in which changes are written to a buffer until explicitly committed.
    /// The <see cref="IStorage"/> interface provides methods for committing changes and reverting to the last-committed version.
    /// For example, a stream can be opened in read-only mode or read/write mode.
    /// For more information, see <see cref="STGM"/> Constants.
    /// Other methods provide access to information about a storage object and its elements through the <see cref="STATSTG"/> structure.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-istorage
    /// </para>
    /// </summary>
    [ComImport]
    [Guid(IID_IPersist)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStorage
    {
        /// <summary>
        /// The <see cref="CreateStream"/> method creates and opens a stream object with the specified name contained in this storage object.
        /// All elements within a storage objects, both streams and other storage objects, are kept in the same name space.
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to a wide character null-terminated Unicode string that contains the name of the newly created stream.
        /// The name can be used later to open or reopen the stream.
        /// The name must not exceed 31 characters in length, not including the string terminator.
        /// The 000 through 01f characters, serving as the first character of the stream/storage name, are reserved for use by OLE.
        /// This is a compound file restriction, not a structured storage restriction.
        /// </param>
        /// <param name="grfMode">
        /// Specifies the access mode to use when opening the newly created stream.
        /// For more information and descriptions of the possible values, see <see cref="STGM"/> Constants.
        /// </param>
        /// <param name="reserved1">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="reserved2">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="ppstm">
        /// On return, pointer to the location of the new <see cref="IStream"/> interface pointer.
        /// This is only valid if the operation is successful.
        /// When an error occurs, this parameter is set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// If a stream with the name specified in the <paramref name="pwcsName"/> parameter already exists
        /// and the <paramref name="grfMode"/> parameter includes the <see cref="STGM_CREATE"/> flag,
        /// the existing stream is replaced by a newly created one.
        /// Both the destruction of the old stream and the creation of the new stream object are subject to the transaction mode on the parent storage object.
        /// The COM-provided compound file implementation of the <see cref="CreateStream"/> method does not support the following behaviors:
        /// The <see cref="STGM_DELETEONRELEASE"/> flag is not supported.
        /// Transacted mode (<see cref="STGM_TRANSACTED"/>) is not supported for stream objects.
        /// Opening the same stream more than once from the same storage is not supported.
        /// The <see cref="STGM_SHARE_EXCLUSIVE"/> sharing-mode flag must be specified in the <paramref name="grfMode"/> parameter.
        /// If the stream already exists and grfMode is set to <see cref="STGM_FAILIFTHERE"/>,
        /// this method fails with the return value <see cref="STG_E_FILEALREADYEXISTS"/>. 
        /// </remarks>
        [PreserveSig]
        HRESULT CreateStream([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]STGM grfMode, [In]DWORD reserved1, [In]DWORD reserved2,
            [Out]out IStream ppstm);

        /// <summary>
        /// The <see cref="OpenStream"/> method opens an existing stream object within this storage object in the specified access mode.
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to a wide character null-terminated Unicode string that contains the name of the stream to open.
        /// The 000 through 01f characters, serving as the first character of the stream/storage name, are reserved for use by OLE.
        /// This is a compound file restriction, not a structured storage restriction.
        /// </param>
        /// <param name="reserved1">
        /// Reserved for future use; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="grfMode">
        /// Specifies the access mode to be assigned to the open stream.
        /// For more information and descriptions of possible values, see <see cref="STGM"/> Constants.
        /// Other modes you choose must at least specify <see cref="STGM_SHARE_EXCLUSIVE"/>
        /// when calling this method in the compound file implementation.
        /// </param>
        /// <param name="reserved2">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="ppstm">
        /// A pointer to <see cref="IStream"/> pointer variable that receives the interface pointer to the newly opened stream object.
        /// If an error occurs, *<paramref name="ppstm"/> must be set to <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="OpenStream"/> opens an existing stream object within this storage object
        /// in the access mode specified in <paramref name="grfMode"/>.
        /// There are restrictions on the permissions that can be given in <paramref name="grfMode"/>.
        /// For example, the permissions on this storage object restrict the permissions on its streams.
        /// In general, access restrictions on streams need to be stricter than those on their parent storages.
        /// Compound-file streams must be opened with <see cref="STGM_SHARE_EXCLUSIVE"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT OpenStream([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]IntPtr reserved1, [In]STGM grfMode, [In]DWORD reserved2,
            [Out]out IStream ppstm);

        /// <summary>
        /// The <see cref="CreateStorage"/> method creates and opens a new storage object nested
        /// within this storage object with the specified name in the specified access mode.
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to a wide character null-terminated Unicode string that contains the name of the newly created storage object.
        /// The name can be used later to reopen the storage object.
        /// The name must not exceed 31 characters in length, not including the string terminator.
        /// The 000 through 01f characters, serving as the first character of the stream/storage name, are reserved for use by OLE.
        /// This is a compound file restriction, not a structured storage restriction.
        /// </param>
        /// <param name="grfMode">
        /// A value that specifies the access mode to use when opening the newly created storage object.
        /// For more information and a description of possible values, see <see cref="STGM"/> Constants.
        /// </param>
        /// <param name="reserved1">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="reserved2">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="ppstm">
        /// A pointer, when successful, to the location of the <see cref="IStorage"/> pointer to the newly created storage object.
        /// This parameter is set to <see langword="null"/> if an error occurs.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// If a storage with the name specified in the <paramref name="pwcsName"/> parameter already exists within the parent storage object,
        /// and the <paramref name="grfMode"/> parameter includes the <see cref="STGM_CREATE"/> flag,
        /// the existing storage is replaced by the new one.
        /// If the <paramref name="grfMode"/> parameter includes the <see cref="STGM_CONVERT"/> flag,
        /// the existing element is converted to a stream object named CONTENTS
        /// and the new storage object is created containing the CONTENTS stream object.
        /// The destruction of the old element and the creation of the new storage object
        /// are both subject to the transaction mode on the parent storage object.
        /// Be aware that you cannot use <see cref="STGM_CONVERT"/> if you are also using <see cref="STGM_CREATE"/>.
        /// The COM-provided compound file implementation of the <see cref="CreateStorage"/> method does not support the following behavior:
        /// The <see cref="STGM_PRIORITY"/> flag for nonroot storages.
        /// Opening the same storage object more than once from the same parent storage.
        /// The <see cref="STGM_SHARE_EXCLUSIVE"/> flag must be specified.
        /// The <see cref="STGM_DELETEONRELEASE"/> flag. If this flag is specified, the function returns <see cref="STG_E_INVALIDFLAG"/>.
        /// If a storage object with the same name already exists and <paramref name="grfMode"/> is set to <see cref="STGM_FAILIFTHERE"/>,
        /// this method fails with the return value <see cref="STG_E_FILEALREADYEXISTS"/>. 
        /// </remarks>
        [PreserveSig]
        HRESULT CreateStorage([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]STGM grfMode, [In]DWORD reserved1, [In]DWORD reserved2,
            [Out]out IStream ppstm);

        /// <summary>
        /// The <see cref="OpenStorage"/> method opens an existing storage object with the specified name in the specified access mode.
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to a wide character null-terminated Unicode string that contains the name of the storage object to open.
        /// The 000 through 01f characters, serving as the first character of the stream/storage name, are reserved for use by OLE.
        /// This is a compound file restriction, not a structured storage restriction.
        /// It is ignored if <paramref name="pstgPriority"/> is non-NULL.
        /// </param>
        /// <param name="pstgPriority">
        /// Must be <see langword="null"/>.
        /// A non-NULL value will return <see cref="STG_E_INVALIDPARAMETER"/>.
        /// </param>
        /// <param name="grfMode">
        /// Specifies the access mode to use when opening the storage object.
        /// For descriptions of the possible values, see <see cref="STGM"/> Constants.
        /// Other modes you choose must at least specify <see cref="STGM_SHARE_EXCLUSIVE"/> when calling this method.
        /// </param>
        /// <param name="snbExclude">
        /// Must be <see langword="null"/>.
        /// A non-NULL value will return <see cref="STG_E_INVALIDPARAMETER"/>.
        /// </param>
        /// <param name="reserved">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="ppstg">
        /// When successful, pointer to the location of an <see cref="IStorage"/> pointer to the opened storage object.
        /// This parameter is set to <see langword="null"/> if an error occurs.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="pstgPriority"/> parameter is <see langword="null"/>, it is ignored.
        /// If the <paramref name="pstgPriority"/> parameter is not <see langword="null"/>,
        /// it is an <see cref="IStorage"/> pointer to a previous opening of an element of the storage object,
        /// usually one that was opened in priority mode.
        /// The storage object should be closed and reopened according to <paramref name="grfMode"/>.
        /// When the <see cref="OpenStorage"/> method returns, <paramref name="pstgPriority"/> is no longer valid.
        /// Use the value supplied in the ppstg parameter.
        /// Storage objects can be opened with <see cref="STGM_DELETEONRELEASE"/>,
        /// in which case the object is destroyed when it receives its final release.
        /// This is useful for creating temporary storage objects.
        /// </remarks>
        [PreserveSig]
        HRESULT OpenStorage([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]IStorage pstgPriority, [In]STGM grfMode,
            [MarshalAs(UnmanagedType.LPWStr)][In]in string snbExclude, [In]DWORD reserved, [Out]out IStorage ppstg);

        /// <summary>
        /// The <see cref="CopyTo"/> method copies the entire contents of an open storage object to another storage object.
        /// </summary>
        /// <param name="ciidExclude">
        /// The number of elements in the array pointed to by <paramref name="rgiidExclude"/>.
        /// If <paramref name="rgiidExclude"/> is <see langword="null"/>, then <paramref name="ciidExclude"/> is ignored.
        /// </param>
        /// <param name="rgiidExclude">
        /// An array of interface identifiers (IIDs) that either the caller knows about and does not want copied
        /// or that the storage object does not support, but whose state the caller will later explicitly copy.
        /// The array can include <see cref="IStorage"/>, indicating that only stream objects are to be copied,
        /// and <see cref="IStream"/>, indicating that only storage objects are to be copied.
        /// An array length of zero indicates that only the state exposed by the <see cref="IStorage"/> object is to be copied;
        /// all other interfaces on the object are to be ignored.
        /// Passing <see langword="null"/> indicates that all interfaces on the object are to be copied.
        /// </param>
        /// <param name="snbExclude">
        /// A string name block (refer to SNB) that specifies a block of storage or stream objects that are not to be copied to the destination.
        /// These elements are not created at the destination.
        /// If <see cref="IID_IStorage"/> is in the <paramref name="rgiidExclude"/> array, this parameter is ignored.
        /// This parameter may be <see langword="null"/>.
        /// </param>
        /// <param name="pstgDest">
        /// A pointer to the open storage object into which this storage object is to be copied.
        /// The destination storage object can be a different implementation of the <see cref="IStorage"/> interface from the source storage object.
        /// Thus, <see cref="CopyTo"/> can use only publicly available methods of the destination storage object.
        /// If <paramref name="pstgDest"/> is open in transacted mode, it can be reverted by calling its <see cref="Revert"/> method.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// This method merges elements contained in the source storage object with those already present in the destination.
        /// The layout of the destination storage object may differ from the source storage object.
        /// The copy process is recursive, invoking <see cref="CopyTo"/> and <see cref="IStream.CopyTo"/> on the elements nested inside the source.
        /// When copying a stream on top of an existing stream with the same name,
        /// the existing stream is first removed and then replaced with the source stream.
        /// When copying a storage on top of an existing storage with the same name, the existing storage is not removed.
        /// As a result, after the copy operation, the destination <see cref="IStorage"/> contains older elements,
        /// unless they were replaced by newer ones with the same names.
        /// A storage object may expose interfaces other than <see cref="IStorage"/>,
        /// including <see cref="IRootStorage"/>, <see cref="IPropertyStorage"/>, or <see cref="IPropertySetStorage"/>.
        /// The <paramref name="rgiidExclude"/> parameter permits the exclusion of any or all of these additional interfaces from the copy operation.
        /// A caller with a newer or more efficient copy of an existing substorage or stream object may
        /// want to exclude the current versions of these objects from the copy operation.
        /// The <paramref name="snbExclude"/> and <paramref name="rgiidExclude"/> parameters provide
        /// two ways of excluding a storage objects existing storages or streams.
        /// Note to Callers
        /// The most common way to use the <see cref="CopyTo"/> method is to copy everything from the source to the destination,
        /// as in most full-save and save-as operations.
        /// The following example code shows how to copy everything from the source storage object to the destination storage object.
        /// <code>
        /// pstg->CopyTo(0, Null, Null, pstgDest)
        /// </code>
        /// Note To compact a document file, call <see cref="CopyTo"/> on the root storage object and copy to a new storage object.
        /// </remarks>
        [PreserveSig]
        HRESULT CopyTo([In]DWORD ciidExclude, [MarshalAs(UnmanagedType.LPArray)][In]Guid[] rgiidExclude,
            [MarshalAs(UnmanagedType.LPWStr)][In]in string snbExclude, [In]in IStorage pstgDest);

        /// <summary>
        /// The <see cref="MoveElementTo"/> method copies or moves a substorage or stream from this storage object to another storage object.
        /// </summary>
        /// <param name="pwcsName">
        /// Pointer to a wide character null-terminated Unicode string that contains the name of the element in this storage object to be moved or copied.
        /// </param>
        /// <param name="pstgDest">
        /// <see cref="IStorage"/> pointer to the destination storage object.
        /// </param>
        /// <param name="pwcsNewName">
        /// Pointer to a wide character null-terminated unicode string that contains the new name for the element in its new storage object.
        /// </param>
        /// <param name="grfFlags">
        /// Specifies whether the operation should be a move (<see cref="STGMOVE_MOVE"/>) or a copy (<see cref="STGMOVE_COPY"/>).
        /// See the <see cref="STGMOVE"/> enumeration.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The <see cref="MoveElementTo"/> method is typically the same as invoking the <see cref="CopyTo"/> method
        /// on the indicated element and then removing the source element.
        /// In this case, the <see cref="MoveElementTo"/> method uses only the publicly available
        /// functions of the destination storage object to carry out the move.
        /// If the source and destination storage objects have special knowledge about each other's implementation
        /// (they could, for example, be different instances of the same implementation), this method can be implemented more efficiently.
        /// Before calling this method, the element to be moved must be closed, and the destination storage must be open.
        /// Also, the destination object and element cannot be the same storage object/element name as the source of the move.
        /// That is, you cannot move an element to itself.
        /// </remarks>
        [PreserveSig]
        HRESULT MoveElementTo([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]IStorage pstgDest,
            [MarshalAs(UnmanagedType.LPWStr)][In]string pwcsNewName, [In]STGMOVE grfFlags);

        /// <summary>
        /// The Commit method ensures that any changes made to a storage object open in transacted mode are reflected in the parent storage.
        /// For nonroot storage objects in direct mode, this method has no effect.
        /// For a root storage, it reflects the changes in the actual device; for example, a file on disk.
        /// For a root storage object opened in direct mode, always call the <see cref="Commit"/> method prior to Release.
        /// <see cref="Commit"/> flushes all memory buffers to the disk for a root storage in direct mode and will return an error code upon failure.
        /// Although Release also flushes memory buffers to disk, it has no capacity to return any error codes upon failure.
        /// Therefore, calling Release without first calling <see cref="Commit"/> causes indeterminate results.
        /// </summary>
        /// <param name="grfCommitFlags">
        /// Controls how the changes are committed to the storage object.
        /// See the <see cref="STGC"/> enumeration for a definition of these values.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="Commit"/> makes permanent changes to a storage object that is in transacted mode, in which changes are accumulated in a buffer,
        /// and not reflected in the storage object until there is a call to this method.
        /// The alternative is to open an object in direct mode, in which changes are immediately reflected in the storage object.
        /// An object opened in the direct mode does not require calling <see cref="Commit"/> to make permanent changes in the storage object.
        /// Calling the <see cref="Commit"/> method on a nonroot storage opened in direct mode has no effect.
        /// Opening a root storage object in direct mode ensures that changes in memory buffers are written to the underlying storage device.
        /// The commit operation publishes the current changes in this storage object and its children to the next level up in the storage hierarchy.
        /// To undo current changes before committing them, call <see cref="Revert"/> to roll back to the last-committed version.
        /// Calling <see cref="Commit"/> has no effect on currently opened nested elements of this storage object.
        /// They remain valid and can be used.
        /// However, the <see cref="Commit"/> method does not automatically commit changes to these nested elements.
        /// The commit operation publishes only known changes to the next higher level in the storage hierarchy.
        /// Thus, transactions to nested levels must be committed to this storage object before they can be committed to higher levels.
        /// In commit operations, you need to take steps to ensure that data is protected during the commit process:
        /// When committing changes to root storage objects, the caller must check the return value to determine
        /// whether the operation has been completed successfully, and if not,
        /// that the old committed contents of the <see cref="IStorage"/> are still intact and can be restored.
        /// If this storage object was opened with some of its items excluded, the caller is responsible for rewriting them before calling commit.
        /// Write mode is required on the storage opening for the commit to succeed.
        /// Unless prohibiting multiple simultaneous writers on the same storage object,
        /// an application calling this method should specify at least <see cref="STGC_ONLYIFCURRENT"/>
        /// in the <paramref name="grfCommitFlags"/> parameter to prevent the changes made by one writer
        /// from inadvertently overwriting the changes made by another.
        /// If the <see cref="STGC_CONSOLIDATE"/> flag is not supported by a storage implementation,
        /// calling <see cref="Commit"/> with <see cref="STGC_CONSOLIDATE"/> specified
        /// in the <paramref name="grfCommitFlags"/> parameter returns the value <see cref="STG_E_INVALIDFLAG"/>. 
        /// </remarks>
        [PreserveSig]
        HRESULT Commit([In]STGC grfCommitFlags);

        /// <summary>
        /// The <see cref="Revert"/> method discards all changes that have been made to the storage object since the last commit operation.
        /// </summary>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// For storage objects opened in transacted mode, the <see cref="Revert"/> method discards any uncommitted changes
        /// to this storage object or changes that have been committed to this storage object from nested elements.
        /// After this method returns, any existing elements (substorages or streams) that were opened
        /// from the reverted storage object are invalid and can no longer be used.
        /// Specifying these reverted elements in any call except IUnknown::Release returns the error <see cref="STG_E_REVERTED"/>
        /// This method has no effect on storage objects opened in direct mode.
        /// </remarks>
        [PreserveSig]
        HRESULT Revert();

        /// <summary>
        /// The <see cref="EnumElements"/> method retrieves a pointer to an enumerator object
        /// that can be used to enumerate the storage and stream objects contained within this storage object.
        /// </summary>
        /// <param name="reserved1">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="reserved2">
        /// Reserved for future use; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="reserved3">
        /// Reserved for future use; must be zero.
        /// </param>
        /// <param name="ppenum">
        /// Pointer to <see cref="IEnumSTATSTG"/> pointer variable that receives the interface pointer to the new enumerator object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The enumerator object returned by this method implements the <see cref="IEnumSTATSTG"/> interface,
        /// one of the standard enumerator interfaces that contain the <see cref="IEnumSTATSTG.Next"/>,
        /// <see cref="IEnumSTATSTG.Reset"/>, <see cref="IEnumSTATSTG.Clone"/>, and <see cref="IEnumSTATSTG.Skip"/> methods.
        /// <see cref="IEnumSTATSTG"/> enumerates the data stored in an array of <see cref="STATSTG"/> structures.
        /// The storage object must be open in read mode to allow the enumeration of its elements.
        /// The order in which the elements are enumerated and whether the enumerator is a snapshot
        /// or always reflects the current state of the storage object, and depends on the <see cref="IStorage"/> implementation.
        /// </remarks>
        [PreserveSig]
        HRESULT EnumElements([In]DWORD reserved1, [In]IntPtr reserved2, [In]DWORD reserved3, [Out]IEnumSTATSTG ppenum);

        /// <summary>
        /// The <see cref="DestroyElement"/> method removes the specified storage or stream from this storage object.
        /// </summary>
        /// <param name="pwcsName">
        /// A pointer to a wide character null-terminated Unicode string that contains the name of the storage or stream to be removed.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The <see cref="DestroyElement"/> method deletes a substorage or stream from the current storage object.
        /// After a successful call to <see cref="DestroyElement"/>,
        /// any open instance of the destroyed element from the parent storage becomes invalid.
        /// If a storage object is opened in the transacted mode, destruction of an element requires
        /// that the call to <see cref="DestroyElement"/> be followed by a call to <see cref="Commit"/>.
        /// Note
        /// The DestroyElement method does not shrink the directory stream.
        /// It only marks the deleted directory entry as invalid.
        /// Invalid entries are reused when creating a new storage or stream.
        /// For content streams, the deleted stream sectors are marked as free.
        /// If the free sectors are at the end of the file, the document file should shrink.
        /// To compact a document file, call <see cref="CopyTo"/> on the root storage object and copy to a new storage object. 
        /// </remarks>
        [PreserveSig]
        HRESULT DestroyElement([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName);

        /// <summary>
        /// The <see cref="RenameElement"/> method renames the specified substorage or stream in this storage object.
        /// </summary>
        /// <param name="pwcsOldName">
        /// Pointer to a wide character null-terminated Unicode string that contains the name of the substorage or stream to be changed.
        /// Note
        /// The pwcsName, created in <see cref="CreateStorage"/> or <see cref="CreateStream"/> must not exceed 31 characters in length,
        /// not including the string terminator.
        /// </param>
        /// <param name="pwcsNewName">
        /// Pointer to a wide character null-terminated unicode string that contains the new name for the specified substorage or stream.
        /// Note
        /// The pwcsName, created in <see cref="CreateStorage"/> or <see cref="CreateStream"/> must not exceed 31 characters in length,
        /// not including the string terminator.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="RenameElement"/> renames the specified substorage or stream in this storage object.
        /// An element in a storage object cannot be renamed while it is open.
        /// The rename operation is subject to committing the changes if the storage is open in transacted mode.
        /// The <see cref="RenameElement"/> method is not guaranteed to work in low memory with storage objects open in transacted mode.
        /// It may work in direct mode.
        /// </remarks>
        [PreserveSig]
        HRESULT RenameElement([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsOldName, [MarshalAs(UnmanagedType.LPWStr)][In]string pwcsNewName);

        /// <summary>
        /// The <see cref="SetElementTimes"/> method sets the modification, access, and creation times of the specified storage element,
        /// if the underlying file system supports this method.
        /// </summary>
        /// <param name="pwcsName">
        /// The name of the storage object element whose times are to be modified.
        /// If <see langword="null"/>, the time is set on the root storage rather than one of its elements.
        /// </param>
        /// <param name="pctime">
        /// Either the new creation time for the element or <see cref="NullRef{FILETIME}"/> if the creation time is not to be modified.
        /// </param>
        /// <param name="patime">
        /// Either the new access time for the element or <see cref="NullRef{FILETIME}"/> if the access time is not to be modified.
        /// </param>
        /// <param name="pmtime">
        /// Either the new modification time for the element or <see cref="NullRef{FILETIME}"/> if the modification time is not to be modified.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="SetElementTimes"/> sets time statistics for the specified storage element within this storage object.
        /// Not all file systems support all the time values. This method sets those times that are supported and ignores the rest.
        /// Each time-value parameter can be <see cref="NullRef{FILETIME}"/>; indicating that no modification should occur.
        /// Call the <see cref="Stat"/> method to retrieve these time values.
        /// </remarks>
        [PreserveSig]
        HRESULT SetElementTimes([MarshalAs(UnmanagedType.LPWStr)][In]string pwcsName, [In]in FILETIME pctime,
            [In]in FILETIME patime, [In]in FILETIME pmtime);

        /// <summary>
        /// The <see cref="SetClass"/> method assigns the specified class identifier (CLSID) to this storage object.
        /// </summary>
        /// <param name="clsid">
        /// The CLSID that is to be associated with the storage object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// When first created, a storage object has an associated CLSID of <see cref="CLSID_NULL"/>.
        /// Call <see cref="SetClass"/> to assign a CLSID to the storage object.
        /// Call the <see cref="Stat"/> method to retrieve the current CLSID of a storage object.
        /// </remarks>
        [PreserveSig]
        HRESULT SetClass([In]in CLSID clsid);

        /// <summary>
        /// The <see cref="SetStateBits"/> method stores up to 32 bits of state information in this storage object.
        /// This method is reserved for future use.
        /// </summary>
        /// <param name="grfStateBits">
        /// Specifies the new values of the bits to set.
        /// No legal values are defined for these bits; they are all reserved for future use and must not be used by applications.
        /// </param>
        /// <param name="grfMask">
        /// A binary mask indicating which bits in <paramref name="grfStateBits"/> are significant in this call.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The values for the state bits are not currently defined.
        /// </remarks>
        [PreserveSig]
        HRESULT SetStateBits([In]DWORD grfStateBits, [In]DWORD grfMask);

        /// <summary>
        /// The <see cref="Stat"/> method retrieves the <see cref="STATSTG"/> structure for this open storage object.
        /// </summary>
        /// <param name="pstatstg">
        /// On return, pointer to a <see cref="STATSTG"/> structure where this method places information about the open storage object.
        /// This parameter is <see cref="NullRef{STATSTG}"/> if an error occurs.
        /// </param>
        /// <param name="grfStatFlag">
        /// Specifies that some of the members in the <see cref="STATSTG"/> structure are not returned, thus saving a memory allocation operation.
        /// Values are taken from the <see cref="STATFLAG"/> enumeration.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="Stat"/> retrieves the <see cref="STATSTG"/> structure for the current storage object.
        /// The <see cref="STATSTG"/> structure contains statistical information about the storage object.
        /// <see cref="EnumElements"/> returns a pointer to an enumerator object.
        /// The enumerator object returned by this method implements the <see cref="IEnumSTATSTG"/> interface,
        /// through which the data stored in the array of the <see cref="STATSTG"/> structures is enumerated.
        /// </remarks>
        [PreserveSig]
        HRESULT Stat([Out]out STATSTG pstatstg, [In]STATFLAG grfStatFlag);
    }
}
