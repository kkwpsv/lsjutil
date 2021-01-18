using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.STGM;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ISequentialStream"/> interface supports simplified sequential access to stream objects.
    /// The <see cref="IStream"/> interface inherits its <see cref="IStream.Read"/> and <see cref="IStream.Write"/> methods
    /// from <see cref="ISequentialStream"/>.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/nn-objidl-isequentialstream
    /// </para>
    /// </summary>
    public unsafe struct ISequentialStream
    {
        IntPtr* _vTable;

        /// <summary>
        /// The <see cref="Read"/> method reads a specified number of bytes from the stream object into memory, starting at the current seek pointer.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the buffer which the stream data is read into.
        /// </param>
        /// <param name="cb">
        /// The number of bytes of data to read from the stream object.
        /// </param>
        /// <param name="pcbRead">
        /// A pointer to a <see cref="ULONG"/> variable that receives the actual number of bytes read from the stream object.
        /// Note  The number of bytes read may be zero.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// This method reads bytes from this stream object into memory.
        /// The stream object must be opened in <see cref="STGM_READ"/> mode.
        /// This method adjusts the seek pointer by the actual number of bytes read.
        /// The number of bytes actually read is also returned in the <paramref name="pcbRead"/> parameter.
        /// Notes to Callers
        /// The actual number of bytes read can be less than the number of bytes requested
        /// if an error occurs or if the end of the stream is reached during the read operation.
        /// The number of bytes returned should always be compared to the number of bytes requested.
        /// If the number of bytes returned is less than the number of bytes requested,
        /// it usually means the Read method attempted to read past the end of the stream.
        /// The application should handle both a returned error and <see cref="S_OK"/> return values on end-of-stream read operations.
        /// </remarks>
        public HRESULT Read([In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbRead)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[3])(thisPtr, pv, cb, out pcbRead);
            }
        }

        /// <summary>
        /// The <see cref="Write"/> method writes a specified number of bytes into the stream object starting at the current seek pointer.
        /// </summary>
        /// <param name="pv">
        /// A pointer to the buffer that contains the data that is to be written to the stream.
        /// A valid pointer must be provided for this parameter even when cb is zero.
        /// </param>
        /// <param name="cb">
        /// The number of bytes of data to attempt to write into the stream. This value can be zero.
        /// </param>
        /// <param name="pcbWritten">
        /// A pointer to a <see cref="ULONG"/> variable where this method writes the actual number of bytes written to the stream object.
        /// The caller can set this pointer to <see cref="NullRef{ULON}"/>,
        /// in which case this method does not provide the actual number of bytes written.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// </returns>
        /// <remarks>
        /// <see cref="Write"/> writes the specified data to a stream object.
        /// The seek pointer is adjusted for the number of bytes actually written.
        /// The number of bytes actually written is returned in the pcbWritten parameter.
        /// If the byte count is zero bytes, the write operation has no effect.
        /// If the seek pointer is currently past the end of the stream and the byte count is nonzero,
        /// this method increases the size of the stream to the seek pointer and writes the specified bytes starting at the seek pointer.
        /// The fill bytes written to the stream are not initialized to any particular value.
        /// This is the same as the end-of-file behavior in the MS-DOS FAT file system.
        /// With a zero byte count and a seek pointer past the end of the stream,
        /// this method does not create the fill bytes to increase the stream to the seek pointer.
        /// In this case, you must call the IStream::SetSize method to increase the size of the stream and write the fill bytes.
        /// The pcbWritten parameter can have a value even if an error occurs.
        /// In the COM-provided implementation, stream objects are not sparse.
        /// Any fill bytes are eventually allocated on the disk and assigned to the stream.
        /// </remarks>
        public HRESULT Write([In] IntPtr pv, [In] ULONG cb, [Out] out ULONG pcbWritten)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, IntPtr, ULONG, out ULONG, HRESULT>)_vTable[3])(thisPtr, pv, cb, out pcbWritten);
            }
        }
    }
}
