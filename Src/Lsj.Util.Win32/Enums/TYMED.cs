using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.GlobalMemoryFlags;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the type of storage medium being used in a data transfer.
    /// They are used in the <see cref="STGMEDIUM"/> or <see cref="FORMATETC"/> structures.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ne-objidl-tymed
    /// </para>
    /// </summary>
    /// <remarks>
    /// During data transfer operations, a storage medium is specified.
    /// This medium must be released after the data transfer operation.
    /// The provider of the medium indicates its choice of ownership scenarios in the value it provides in the <see cref="STGMEDIUM"/> structure.
    /// A <see cref="IntPtr.Zero"/> value for the <see cref="STGMEDIUM.pUnkForRelease"/> member indicates that
    /// the receiving body of code owns and can free the medium.
    /// A non-NULL pointer specifies that <see cref="ReleaseStgMedium"/> can always be called to free the medium.
    /// </remarks>
    public enum TYMED
    {
        /// <summary>
        /// The storage medium is a global memory handle (HGLOBAL).
        /// Allocate the global handle with the <see cref="GMEM_MOVEABLE"/> flag.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member of <see cref="STGMEDIUM"/> is <see cref="NULL"/>,
        /// the destination process should use <see cref="GlobalFree"/> to release the memory.
        /// </summary>
        TYMED_HGLOBAL = 1,

        /// <summary>
        /// The storage medium is a disk file identified by a path.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is NULL, the destination process should use <see cref="OpenFile"/> to delete the file.
        /// </summary>
        TYMED_FILE = 2,

        /// <summary>
        /// The storage medium is a stream object identified by an <see cref="IStream"/> pointer.
        /// Use <see cref="ISequentialStream.Read"/> to read the data.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is not <see cref="IntPtr.Zero"/>,
        /// the destination process should use Release to release the stream component.
        /// </summary>
        TYMED_ISTREAM = 4,

        /// <summary>
        /// The storage medium is a storage component identified by an <see cref="IStorage"/> pointer.
        /// The data is in the streams and storages contained by this <see cref="IStorage"/> instance.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is not <see cref="IntPtr.Zero"/>,
        /// the destination process should use Release to release the storage component.
        /// </summary>
        TYMED_ISTORAGE = 8,

        /// <summary>
        /// The storage medium is a GDI component (HBITMAP).
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is not <see cref="IntPtr.Zero"/>,
        /// the destination process should use <see cref="DeleteObject"/> to delete the bitmap.
        /// </summary>
        TYMED_GDI = 16,

        /// <summary>
        /// The storage medium is a metafile (HMETAFILE).
        /// Use the GDI functions to access the metafile's data.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is not <see cref="IntPtr.Zero"/>,
        /// the destination process should use <see cref="DeleteMetaFile"/> to delete the bitmap.
        /// </summary>
        TYMED_MFPICT = 32,

        /// <summary>
        /// The storage medium is an enhanced metafile.
        /// If the <see cref="STGMEDIUM.pUnkForRelease"/> member is not <see cref="IntPtr.Zero"/>,
        /// the destination process should use <see cref="DeleteEnhMetaFile"/> to delete the bitmap.
        /// </summary>
        TYMED_ENHMF = 64,

        /// <summary>
        /// No data is being passed.
        /// </summary>
        TYMED_NULL = 0
    }
}
