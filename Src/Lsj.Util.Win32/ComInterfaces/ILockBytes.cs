using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.STATFLAG;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using STATSTG = Lsj.Util.Win32.Structs.STATSTG;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The ILockBytes interface is implemented on a byte array object that is backed by some physical storage,
    /// such as a disk file, global memory, or a database.
    /// It is used by a COM compound file storage object to give its root storage access to the physical device,
    /// while isolating the root storage from the details of accessing the physical storage.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ilockbytes"/>
    /// </para>
    /// </summary>
    public unsafe struct ILockBytes
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="ReadAt"/> method reads a specified number of bytes
        /// starting at a specified offset from the beginning of the byte array object.
        /// </summary>
        /// <param name="ulOffset">
        /// Specifies the starting point from the beginning of the byte array for reading data.
        /// </param>
        /// <param name="pv">
        /// Pointer to the buffer into which the byte array is read.
        /// The size of this buffer is contained in <paramref name="cb"/>.
        /// </param>
        /// <param name="cb">
        /// Specifies the number of bytes of data to attempt to read from the byte array.
        /// </param>
        /// <param name="pcbRead">
        /// Pointer to a <see cref="ULONG"/> where this method writes the actual number of bytes read from the byte array.
        /// You can set this pointer to <see cref="NullRef{ULONG}"/> to indicate that you are not interested in this value.
        /// In this case, this method does not provide the actual number of bytes that were read.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="ReadAt"/> reads bytes from the byte array object.
        /// It reports the number of bytes that were actually read.
        /// This value may be less than the number of bytes requested if an error occurs or if the end of the byte array is reached during the read.
        /// It is not an error to read less than the specified number of bytes if the operation encounters the end of the byte array.
        /// Note that this is the same end-of-file behavior as found in MS-DOS file allocation table (FAT) file system files.
        /// </remarks>
        public HRESULT ReadAt([In] ULARGE_INTEGER ulOffset, [In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbRead)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[3])(thisPtr, ulOffset, pv, cb, out pcbRead);
            }
        }

        /// <summary>
        /// The <see cref="WriteAt"/> method writes the specified number of bytes starting at a specified offset from the beginning of the byte array.
        /// </summary>
        /// <param name="ulOffset">
        /// Specifies the starting point from the beginning of the byte array for the data to be written.
        /// </param>
        /// <param name="pv">
        /// Pointer to the buffer containing the data to be written.
        /// </param>
        /// <param name="cb">
        /// Specifies the number of bytes of data to attempt to write into the byte array.
        /// </param>
        /// <param name="pcbWritten">
        /// Pointer to a location where this method specifies the actual number of bytes written to the byte array.
        /// You can set this pointer to <see cref="NullRef{ULONG}"/> to indicate that you are not interested in this value.
        /// In this case, this method does not provide the actual number of bytes written.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="WriteAt"/> writes the specified data at the specified location in the byte array.
        /// The number of bytes actually written must always be returned in pcbWritten, even if an error is returned.
        /// If the byte count is zero bytes, the write operation has no effect.
        /// If <paramref name="ulOffset"/> is past the end of the byte array and <paramref name="cb"/> is greater than zero,
        /// <see cref="WriteAt"/> increases the size of the byte array.
        /// The fill bytes written to the byte array are not initialized to any particular value.
        /// </remarks>
        public HRESULT WriteAt([In] ULARGE_INTEGER ulOffset, [In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbWritten)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[4])(thisPtr, ulOffset, pv, cb, out pcbWritten);
            }
        }

        /// <summary>
        /// The <see cref="Flush"/> method ensures that any internal buffers maintained
        /// by the <see cref="ILockBytes"/> implementation are written out to the underlying physical storage.
        /// </summary>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="Flush"/> flushes internal buffers to the underlying storage device.
        /// The COM-provided implementation of compound files calls this method during a transacted commit operation
        /// to provide a two-phase commit process that protects against loss of data.
        /// </remarks>
        public HRESULT Flush()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[5])(thisPtr);
            }
        }

        /// <summary>
        /// The <see cref="SetSize"/> method changes the size of the byte array.
        /// </summary>
        /// <param name="cb">
        /// Specifies the new size of the byte array as a number of bytes.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="SetSize"/> changes the size of the byte array.
        /// If the <paramref name="cb"/> parameter is larger than the current byte array,
        /// the byte array is extended to the indicated size by filling the intervening space with bytes of undefined value,
        /// as does <see cref="WriteAt"/>, if the seek pointer is past the current end-of-stream.
        /// If the <paramref name="cb"/> parameter is smaller than the current byte array, the byte array is truncated to the indicated size.
        /// Notes to Callers
        /// Callers cannot rely on <see cref="STG_E_MEDIUMFULL"/> being returned at the appropriate time
        /// because of cache buffering in the operating system or network.
        /// However, callers must be able to deal with this return code because some <see cref="ILockBytes"/> implementations might support it. 
        /// </remarks>
        public HRESULT SetSize([In] ULARGE_INTEGER cb)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, HRESULT>)_vTable[6])(thisPtr, cb);
            }
        }

        /// <summary>
        /// The <see cref="LockRegion"/> method restricts access to a specified range of bytes in the byte array.
        /// </summary>
        /// <param name="libOffset">
        /// Specifies the byte offset for the beginning of the range.
        /// </param>
        /// <param name="cb">
        /// Specifies, in bytes, the length of the range to be restricted.
        /// </param>
        /// <param name="dwLockType">
        /// Specifies the type of restrictions being requested on accessing the range.
        /// This parameter uses one of the values from the <see cref="LOCKTYPE"/> enumeration.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="LockRegion"/> restricts access to the specified range of bytes.
        /// Once a region is locked, attempts by others to gain access to the restricted range must fail with the <see cref="STG_E_ACCESSDENIED"/> error.
        /// The byte range can extend past the current end of the byte array.
        /// Locking beyond the end of an array is useful as a method of communication between different instances of the byte array object
        /// without changing data that is actually part of the byte array.
        /// For example, an implementation of <see cref="ILockBytes"/> for compound files could rely on locking past the current end of the array
        /// as a means of access control, using specific locked regions to indicate permissions currently granted.
        /// The <paramref name="dwLockType"/> parameter specifies one of three types of locking, using values from the <see cref="LOCKTYPE"/> enumeration.
        /// The types are as follows: locking to exclude other writers, locking to exclude other readers or writers,
        /// and locking that allows only one requester to obtain a lock on the given range.
        /// This third type of locking is usually an alias for one of the other two lock types, and permits an Implementer to add other behavior as well.
        /// A given byte array might support either of the first two types, or both.
        /// To determine the lock types supported by a particular <see cref="ILockBytes"/> implementation,
        /// you can examine the <see cref="STATSTG.grfLocksSupported"/> member of the <see cref="STATSTG"/> structure
        /// returned by a call to <see cref="Stat"/>.
        /// Any region locked with <see cref="LockRegion"/> must later be explicitly unlocked by calling <see cref="UnlockRegion"/>
        /// with exactly the same values for the <paramref name="libOffset"/>, <paramref name="cb"/>, and <paramref name="dwLockType"/> parameters.
        /// The region must be unlocked before the stream is released.
        /// Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
        /// Notes to Callers
        /// Since the type of locking supported is optional and can vary in different implementations of <see cref="ILockBytes"/>,
        /// you must provide code to deal with the <see cref="STG_E_INVALIDFUNCTION"/> error.
        /// Notes to Implementers
        /// Support for this method depends on how the storage object built on top of the <see cref="ILockBytes"/> implementation is used.
        /// If you know that only one storage object at any given time can be opened on the storage device that underlies the byte array,
        /// then your <see cref="ILockBytes"/> implementation does not need to support locking.
        /// However, if multiple simultaneous openings of a storage object are possible, then region locking is needed to coordinate them.
        /// A <see cref="LockRegion"/> implementation can choose to support all, some, or none of the lock types.
        /// For unsupported lock types, the implementation should return <see cref="STG_E_INVALIDFUNCTION"/>.
        /// </remarks>
        public HRESULT LockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] LOCKTYPE dwLockType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, ULARGE_INTEGER, LOCKTYPE, HRESULT>)_vTable[7])(thisPtr, libOffset, cb, dwLockType);
            }
        }

        /// <summary>
        /// The <see cref="UnlockRegion"/> method removes the access restriction on a previously locked range of bytes.
        /// </summary>
        /// <param name="libOffset">
        /// Specifies the byte offset for the beginning of the range.
        /// </param>
        /// <param name="cb">
        /// Specifies, in bytes, the length of the range that is restricted.
        /// </param>
        /// <param name="dwLockType">
        /// Specifies the type of access restrictions previously placed on the range.
        /// This parameter uses a value from the <see cref="LOCKTYPE"/> enumeration.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="UnlockRegion"/> unlocks a region previously locked with a call to <see cref="LockRegion"/>.
        /// Each region locked must be explicitly unlocked, using the same values for the <paramref name="libOffset"/>,
        /// <paramref name="cb"/>, and <paramref name="dwLockType"/> parameters as in the matching calls to <see cref="LockRegion"/>.
        /// Two adjacent regions cannot be locked separately and then unlocked with a single unlock call.
        /// </remarks>
        public HRESULT UnlockRegion([In] ULARGE_INTEGER libOffset, [In] ULARGE_INTEGER cb, [In] LOCKTYPE dwLockType)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, ULARGE_INTEGER, ULARGE_INTEGER, LOCKTYPE, HRESULT>)_vTable[8])(thisPtr, libOffset, cb, dwLockType);
            }
        }

        /// <summary>
        /// The <see cref="Stat"/> method retrieves a <see cref="STATSTG"/> structure containing information for this byte array object.
        /// </summary>
        /// <param name="pstatstg">
        /// Pointer to a <see cref="STATSTG"/> structure in which this method places information about this byte array object.
        /// The pointer is NULL if an error occurs.
        /// </param>
        /// <param name="grfStatFlag">
        /// Specifies whether this method should supply the <see cref="STATSTG.pwcsName"/> member of the <see cref="STATSTG"/> structure
        /// through values taken from the <see cref="STATFLAG"/> enumeration.
        /// If the <see cref="STATFLAG_NONAME"/> is specified, the <see cref="STATSTG.pwcsName"/> member of <see cref="STATSTG"/> is not supplied,
        /// thus saving a memory-allocation operation.
        /// The other possible value, <see cref="STATFLAG_DEFAULT"/>, indicates that all members of the <see cref="STATSTG"/> structure be supplied.
        /// </param>
        /// <returns></returns>
        public HRESULT Stat([Out] out STATSTG pstatstg, [In] STATFLAG grfStatFlag)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out STATSTG, STATFLAG, HRESULT>)_vTable[9])(thisPtr, out pstatstg, grfStatFlag);
            }
        }
    }
}
