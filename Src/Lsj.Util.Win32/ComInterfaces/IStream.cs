using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.BSCF;
using static Lsj.Util.Win32.Enums.STREAM_SEEK;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using STATSTG = Lsj.Util.Win32.Structs.STATSTG;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IStream"/> interface lets you read and write data to stream objects.
    /// Stream objects contain the data in a structured storage object, where storages provide the structure.
    /// Simple data can be written directly to a stream but, most frequently, streams are elements nested within a storage object.
    /// They are similar to standard files.
    /// The <see cref="IStream"/> interface defines methods similar to the MS-DOS FAT file functions.
    /// For example, each stream object has its own access rights and a seek pointer.
    /// The main difference between a DOS file and a stream object is that in the latter case,
    /// streams are opened using an <see cref="IStream"/> interface pointer rather than a file handle.
    /// The methods in this interface present your object's data as a contiguous sequence of bytes that you can read or write.
    /// There are also methods for committing and reverting changes on streams that are open
    /// in transacted mode and methods for restricting access to a range of bytes in the stream.
    /// Streams can remain open for long periods of time without consuming file-system resources.
    /// The IUnknown::Release method is similar to a close function on a file.
    /// Once released, the stream object is no longer valid and cannot be used.
    /// Clients of asynchronous monikers can choose between a data-pull or data-push model
    /// for driving an asynchronous <see cref="IMoniker.BindToStorage"/> operation and for receiving asynchronous notifications.
    /// See URL Monikers for more information.
    /// The following table compares the behavior of asynchronous <see cref="ISequentialStream.Read"/> and <see cref="IStream.Seek"/> calls returned
    /// in <see cref="IBindStatusCallback.OnDataAvailable"/> in these two download models:
    /// <see cref="IStream"/> method call
    /// Behavior in data-pull model
    /// Behavior in data-push model
    /// <see cref="Read"/> is called to read partial data (that is, not all the available data)
    /// Returns <see cref="S_OK"/>. The client must continue to read all available data before returning
    /// from <see cref="IBindStatusCallback.OnDataAvailable"/> or else the bind operation is blocked.
    /// (that is, read until <see cref="S_FALSE"/> or <see cref="E_PENDING"/> is returned)
    /// Returns <see cref="S_OK"/>. Even if the client returns from <see cref="IBindStatusCallback.OnDataAvailable"/> at this point
    /// the bind operation continues and <see cref="IBindStatusCallback.OnDataAvailable"/> will be called again repeatedly until the binding finishes.
    /// <see cref="Read"/> is called to read all the available data
    /// Returns <see cref="E_PENDING"/> if the bind operation has not completed,
    /// and <see cref="IBindStatusCallback.OnDataAvailable"/> will be called again when more data is available.
    /// Same as data-pull model.
    /// <see cref="Read"/> is called to read all the available data and the bind operation is over (end of file)
    /// Returns <see cref="S_FALSE"/>.
    /// There will be a subsequent call to <see cref="IBindStatusCallback.OnDataAvailable"/>
    /// with the grfBSC flag set to <see cref="BSCF_LASTDATANOTIFICATION"/>.
    /// Same as data-pull model.
    /// <see cref="Seek"/> is called
    /// Seek does not work in data-pull model
    /// Seek does not work in data-push model.
    /// For general information on this topic, see Asynchronous Monikers and Data-Pull-Model versus Data Push-Model for more specific information.
    /// Also, see Managing Memory Allocation for details on COM's rules for managing memory.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-istream"/>
    /// </para>
    /// </summary>
    public unsafe struct IStream
    {
        IntPtr* _vTable;

        /// <summary>
        /// Inherit from <see cref="ISequentialStream"/>
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="cb"></param>
        /// <param name="pcbRead"></param>
        /// <returns></returns>
        public HRESULT Read([In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbRead)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[3])(thisPtr, pv, cb, out pcbRead);
            }
        }

        /// <summary>
        /// Inherit from <see cref="ISequentialStream"/>
        /// </summary>
        /// <param name="pv"></param>
        /// <param name="cb"></param>
        /// <param name="pcbWritten"></param>
        /// <returns></returns>
        public HRESULT Write([In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbWritten)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[3])(thisPtr, pv, cb, out pcbWritten);
            }
        }

        /// <summary>
        /// The Seek method changes the seek pointer to a new location.
        /// The new location is relative to either the beginning of the stream, the end of the stream, or the current seek pointer.
        /// </summary>
        /// <param name="dlibMove">
        /// The displacement to be added to the location indicated by the <paramref name="dwOrigin"/> parameter.
        /// If <paramref name="dwOrigin"/> is <see cref="STREAM_SEEK_SET"/>, this is interpreted as an unsigned value rather than a signed value.
        /// </param>
        /// <param name="dwOrigin">
        /// The origin for the displacement specified in <paramref name="dlibMove"/>.
        /// The origin can be the beginning of the file (<see cref="STREAM_SEEK_SET"/>),
        /// the current seek pointer (<see cref="STREAM_SEEK_CUR"/>), or the end of the file (<see cref="STREAM_SEEK_END"/>).
        /// For more information about values, see the <see cref="STREAM_SEEK"/> enumeration.
        /// </param>
        /// <param name="plibNewPosition">
        /// A pointer to the location where this method writes the value of the new seek pointer from the beginning of the stream.
        /// You can set this pointer to <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// In this case, this method does not provide the new seek pointer.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="IStream.Seek"/> changes the seek pointer so that subsequent read and write operations
        /// can be performed at a different location in the stream object.
        /// It is an error to seek before the beginning of the stream.
        /// It is not, however, an error to seek past the end of the stream.
        /// Seeking past the end of the stream is useful for subsequent write operations,
        /// as the stream byte range will be extended to the new seek position immediately before the write is complete.
        /// You can also use this method to obtain the current value of the seek pointer
        /// by calling this method with the <paramref name="dwOrigin"/> parameter set to <see cref="STREAM_SEEK_CUR"/>
        /// and the <paramref name="dlibMove"/> parameter set to 0 so that the seek pointer is not changed.
        /// The current seek pointer is returned in the <paramref name="plibNewPosition"/> parameter.
        /// </remarks>
        public HRESULT Seek([In] LARGE_INTEGER dlibMove, [In] STREAM_SEEK dwOrigin, [Out] out ULARGE_INTEGER plibNewPosition)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LARGE_INTEGER, STREAM_SEEK, out ULARGE_INTEGER, HRESULT>)_vTable[5])(thisPtr, dlibMove, dwOrigin, out plibNewPosition);
            }
        }

        /// <summary>
        /// The <see cref="SetSize"/> method changes the size of the stream object.
        /// </summary>
        /// <param name="libNewSize">
        /// Specifies the new size, in bytes, of the stream.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="IStream.SetSize"/> changes the size of the stream object.
        /// Call this method to preallocate space for the stream.
        /// If the <paramref name="libNewSize"/> parameter is larger than the current stream size,
        /// the stream is extended to the indicated size by filling the intervening space with bytes of undefined value.
        /// This operation is similar to the <see cref="ISequentialStream.Write"/> method if the seek pointer is past the current end of the stream.
        /// If the <paramref name="libNewSize"/> parameter is smaller than the current stream, the stream is truncated to the indicated size.
        /// The seek pointer is not affected by the change in stream size.
        /// Calling <see cref="IStream.SetSize"/> can be an effective way to obtain a large chunk of contiguous space.
        /// </remarks>
        public HRESULT SetSize([In] ULARGE_INTEGER libNewSize)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, HRESULT>)_vTable[6])(thisPtr, libNewSize);
            }
        }

        /// <summary>
        /// The <see cref="CopyTo"/> method copies a specified number of bytes
        /// from the current seek pointer in the stream to the current seek pointer in another stream.
        /// </summary>
        /// <param name="pstm">
        /// A pointer to the destination stream.
        /// The stream pointed to by pstm can be a new stream or a clone of the source stream.
        /// </param>
        /// <param name="cb">
        /// The number of bytes to copy from the source stream.
        /// </param>
        /// <param name="pcbRead">
        /// A pointer to the location where this method writes the actual number of bytes read from the source.
        /// You can set this pointer to <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// In this case, this method does not provide the actual number of bytes read.
        /// </param>
        /// <param name="pcbWritten">
        /// A pointer to the location where this method writes the actual number of bytes written to the destination.
        /// You can set this pointer to <see cref="NullRef{ULARGE_INTEGER}"/>.
        /// In this case, this method does not provide the actual number of bytes written.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The <see cref="CopyTo"/> method copies the specified bytes from one stream to another.
        /// It can also be used to copy a stream to itself.
        /// The seek pointer in each stream instance is adjusted for the number of bytes read or written.
        /// This method is equivalent to reading <paramref name="cb"/> bytes into memory using <see cref="ISequentialStream.Read"/>
        /// and then immediately writing them to the destination stream using <see cref="ISequentialStream.Write"/>,
        /// although <see cref="IStream.CopyTo"/> will be more efficient.
        /// The destination stream can be a clone of the source stream created by calling the <see cref="IStream.Clone"/> method.
        /// If <see cref="IStream.CopyTo"/> returns an error, you cannot assume that the seek pointers are valid for either the source or destination.
        /// Additionally, the values of pcbRead and pcbWritten are not meaningful even though they are returned.
        /// If <see cref="IStream.CopyTo"/> returns successfully, the actual number of bytes read and written are the same.
        /// To copy the remainder of the source from the current seek pointer,
        /// specify the maximum large integer value for the <paramref name="cb"/> parameter.
        /// If the seek pointer is the beginning of the stream, this operation copies the entire stream.
        /// </remarks>
        public HRESULT CopyTo([In] in IStream pstm, [In] ULARGE_INTEGER cb, [Out] out ULARGE_INTEGER pcbRead, [Out] out ULARGE_INTEGER pcbWritten)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IStream, ULARGE_INTEGER, out ULARGE_INTEGER, out ULARGE_INTEGER, HRESULT>)_vTable[7])
                    (thisPtr, pstm, cb, out pcbRead, out pcbWritten);
            }
        }

        /// <summary>
        /// The <see cref="Commit"/> method ensures that any changes made to a stream object open
        /// in transacted mode are reflected in the parent storage.
        /// If the stream object is open in direct mode, <see cref="IStream.Commit"/> has no effect
        /// other than flushing all memory buffers to the next-level storage object.
        /// The COM compound file implementation of streams does not support opening streams in transacted mode.
        /// </summary>
        /// <param name="grfCommitFlags">
        /// Controls how the changes for the stream object are committed.
        /// See the <see cref="STGC"/> enumeration for a definition of these values.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The <see cref="Commit"/> method ensures that changes to a stream object opened in transacted mode are reflected in the parent storage.
        /// Changes that have been made to the stream since it was opened or last committed are reflected to the parent storage object.
        /// If the parent is opened in transacted mode, the parent may revert at a later time, rolling back the changes to this stream object.
        /// The compound file implementation does not support the opening of streams in transacted mode,
        /// so this method has very little effect other than to flush memory buffers.
        /// For more information, see IStream - Compound File Implementation.
        /// If the stream is open in direct mode, this method ensures that any memory buffers have been flushed out to the underlying storage object.
        /// This is much like a flush in traditional file systems.
        /// The <see cref="Commit"/> method is useful on a direct mode stream
        /// when the implementation of the <see cref="IStream"/> interface is a wrapper for underlying file system APIs.
        /// In this case, <see cref="Commit"/> would be connected to the file system's flush call.
        /// </remarks>
        public HRESULT Commit([In] STGC grfCommitFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, STGC, HRESULT>)_vTable[8])(thisPtr, grfCommitFlags);
            }
        }

        /// <summary>
        /// The <see cref="Revert"/> method discards all changes that have been made to a transacted stream since the last <see cref="Commit"/> call.
        /// On streams open in direct mode and streams using the COM compound file implementation of <see cref="Revert"/>, this method has no effect.
        /// </summary>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The <see cref="Revert"/> method discards changes made to a transacted stream since the last commit operation.
        /// </remarks>
        public HRESULT Revert()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[9])(thisPtr);
            }
        }

        /// <summary>
        /// The <see cref="LockRegion"/> method restricts access to a specified range of bytes in the stream.
        /// Supporting this functionality is optional since some file systems do not provide it.
        /// </summary>
        /// <param name="libOffset">
        /// Integer that specifies the byte offset for the beginning of the range.
        /// </param>
        /// <param name="cb">
        /// Integer that specifies the length of the range, in bytes, to be restricted.
        /// </param>
        /// <param name="dwLockType">
        /// Specifies the restrictions being requested on accessing the range.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The byte range of the stream can be extended.
        /// Locking an extended range for the stream is useful as a method of communication
        /// between different instances of the stream without changing data that is actually part of the stream.
        /// Three types of locking can be supported: locking to exclude other writers, locking to exclude other readers or writers,
        /// and locking that allows only one requester to obtain a lock on the given range,
        /// which is usually an alias for one of the other two lock types.
        /// A given stream instance might support either of the first two types, or both.
        /// The lock type is specified by <paramref name="dwLockType"/>, using a value from the <see cref="LOCKTYPE"/> enumeration.
        /// Any region locked with <see cref="LockRegion"/> must later be explicitly unlocked by calling <see cref="UnlockRegion"/>
        /// with exactly the same values for the <paramref name="libOffset"/>, <paramref name="cb"/>, and <paramref name="dwLockType"/> parameters.
        /// The region must be unlocked before the stream is released.
        /// Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
        /// Notes to Callers
        /// Since the type of locking supported is optional and can vary in different implementations of <see cref="IStream"/>,
        /// you must provide code to deal with the <see cref="STG_E_INVALIDFUNCTION"/> error.
        /// The <see cref="LockRegion"/> method has no effect in the compound file implementation,
        /// because the implementation does not support range locking.
        /// Notes to Implementers
        /// Support for this method is optional for implementations of stream objects since it may not be supported by the underlying file system.
        /// The type of locking supported is also optional.
        /// The <see cref="STG_E_INVALIDFUNCTION"/> error is returned if the requested type of locking is not supported. 
        /// </remarks>
        public HRESULT LockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] LOCKTYPE dwLockType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, ULARGE_INTEGER, LOCKTYPE, HRESULT>)_vTable[10])(thisPtr, libOffset, cb, dwLockType);
            }
        }

        /// <summary>
        /// The <see cref="UnlockRegion"/> method removes the access restriction
        /// on a range of bytes previously restricted with <see cref="LockRegion"/>.
        /// </summary>
        /// <param name="libOffset">
        /// Specifies the byte offset for the beginning of the range.
        /// </param>
        /// <param name="cb">
        /// Specifies, in bytes, the length of the range to be restricted.
        /// </param>
        /// <param name="dwLockType">
        /// Specifies the access restrictions previously placed on the range.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="UnlockRegion"/> unlocks a region previously locked with the <see cref="LockRegion"/> method.
        /// Locked regions must later be explicitly unlocked by calling <see cref="UnlockRegion"/>
        /// with exactly the same values for the <paramref name="libOffset"/>, <paramref name="cb"/>, and <paramref name="dwLockType"/> parameters.
        /// The region must be unlocked before the stream is released.
        /// Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
        /// </remarks>
        public HRESULT UnlockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] LOCKTYPE dwLockType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, ULARGE_INTEGER, LOCKTYPE, HRESULT>)_vTable[11])(thisPtr, libOffset, cb, dwLockType);
            }
        }

        /// <summary>
        /// The <see cref="Stat"/> method retrieves the <see cref="STATSTG"/> structure for this stream.
        /// </summary>
        /// <param name="pstatstg">
        /// Pointer to a <see cref="STATSTG"/> structure where this method places information about this stream object.
        /// </param>
        /// <param name="grfStatFlag">
        /// Specifies that this method does not return some of the members in the <see cref="STATSTG"/> structure,
        /// thus saving a memory allocation operation.
        /// Values are taken from the <see cref="STATFLAG"/> enumeration.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="Stat"/> retrieves a pointer to the <see cref="STATSTG"/> structure that contains information about this open stream.
        /// When this stream is within a structured storage and <see cref="IStorage.EnumElements"/> is called,
        /// it creates an enumerator object with the <see cref="IEnumSTATSTG"/> interface on it,
        /// which can be called to enumerate the storages and streams through the <see cref="STATSTG"/> structures associated with each of them.
        /// </remarks>
        public HRESULT Stat([In] in STATSTG pstatstg, [In] STATFLAG grfStatFlag)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in STATSTG, STATFLAG, HRESULT>)_vTable[12])(thisPtr, pstatstg, grfStatFlag);
            }
        }

        /// <summary>
        /// The <see cref="Clone"/> method creates a new stream object with its own seek pointer that references the same bytes as the original stream.
        /// </summary>
        /// <param name="ppstm">
        /// When successful, pointer to the location of an IStream pointer to the new stream object.
        /// If an error occurs, this parameter is <see langword="null"/>.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// The Clone method creates a new stream object for accessing the same bytes but using a separate seek pointer.
        /// The new stream object sees the same data as the source-stream object.
        /// Changes written to one object are immediately visible in the other.
        /// Range locking is shared between the stream objects.
        /// The initial setting of the seek pointer in the cloned stream instance is the same as
        /// the current setting of the seek pointer in the original stream at the time of the clone operation.
        /// </remarks>
        public HRESULT Clone([Out] out IntPtr ppstm)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out IntPtr, HRESULT>)_vTable[13])(thisPtr, out ppstm);
            }
        }
    }
}
