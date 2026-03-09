using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "33ae5ea6-4316-436f-8ddd-d73d22f829ec", BeginVTableSlotIndex = 10, EndVTableSlotIndex = 11,
        InheritedFromTypes = [typeof(IUnknown), typeof(IMF2DBuffer2)])]
    public unsafe struct IMF2DBuffer2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gives the caller access to the memory in the buffer.
        /// </summary>
        /// <param name="lockFlags">
        /// A member of the <see cref="MF2DBuffer_LockFlags"/> enumeration
        /// that specifies whether to lock the buffer for reading, writing, or both.
        /// </param>
        /// <param name="ppbScanline0">
        /// Receives a pointer to the first byte of the top row of pixels in the image.
        /// The top row is defined as the top row when the image is presented to the viewer, and might not be the first row in memory.
        /// </param>
        /// <param name="plPitch">
        /// Receives the surface stride, in bytes.
        /// The stride might be negative, indicating that the image is oriented from the bottom up in memory.
        /// </param>
        /// <param name="ppbBufferStart">
        /// Receives a pointer to the start of the accessible buffer in memory.
        /// </param>
        /// <param name="pcbBufferLength">
        /// Receives the length of the buffer, in bytes.
        /// </param>
        /// <returns>
        /// <para>
        /// This method can return one of these values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// Invalid request.
        /// The buffer might already be locked with an incompatible locking flag.
        /// See Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// There is insufficient memory to complete the operation.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you are done accessing the memory, call <see cref="IMF2DBuffer.Unlock2D"/> to unlock the buffer.
        /// You must call <see cref="IMF2DBuffer.Unlock2D"/> once for each call to <see cref="Lock2DSize"/>.
        /// </para>
        /// <para>
        /// This method is equivalent to the <see cref="IMF2DBuffer.Lock2D"/> method.
        /// However, <see cref="Lock2DSize"/> is preferred because it enables the caller to validate memory pointers,
        /// and because it supports read-only locks.
        /// A buffer is not guaranteed to support the <see cref="IMF2DBuffer2"/> interface.
        /// To access a buffer, you should try the following methods in the order listed:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see cref="Lock2DSize"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IMF2DBuffer.Lock2D"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IMFMediaBuffer.Lock"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The <paramref name="ppbBufferStart"/> and <paramref name="pcbBufferLength"/> parameters receive the bounds of the buffer memory.
        /// Use these values to guard against buffer overruns.
        /// Use the values of <paramref name="ppbScanline0"/> and <paramref name="plPitch"/> to access the image data.
        /// If the image is bottom-up in memory,
        /// <paramref name="ppbScanline0"/> will point to the last scan line in memory and <paramref name="plPitch"/> will be negative.
        /// For more information, see Image Stride.
        /// </para>
        /// <para>
        /// The <paramref name="lockFlags"/> parameter specifies
        /// whether the buffer is locked for read-only access, write-only access, or read/write access.
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the buffer is already locked for read-only access, it cannot be locked for write access.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the buffer is already locked for write-only access, it cannot be locked for read access.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the buffer is already locked for read/write access, it can be locked for read or write access.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When possible, use a read-only or write-only lock, and avoid locking the buffer for read/write access.
        /// If the buffer represents a DirectX Graphics Infrastructure (DXGI) surface,
        /// a read/write lock can cause an extra copy between CPU memory and GPU memory.
        /// </para>
        /// </remarks>
        public HRESULT Lock2DSize([In] MF2DBuffer_LockFlags lockFlags, [Out] out P<BYTE> ppbScanline0, [Out] out LONG plPitch,
            [Out] out P<BYTE> ppbBufferStart, [Out] out DWORD pcbBufferLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, MF2DBuffer_LockFlags, out P<BYTE>, out LONG, out P<BYTE>, out DWORD, HRESULT>)_vTable[10])(
                    thisPtr, lockFlags, out ppbScanline0, out plPitch, out ppbBufferStart, out pcbBufferLength);
            }
        }

        /// <summary>
        /// Copies the buffer to another 2D buffer object.
        /// </summary>
        /// <param name="pDestBuffer">
        /// A pointer to the <see cref="IMF2DBuffer2"/> interface of the destination buffer.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// The destination buffer must be at least as large as the source buffer.
        /// </remarks>
        public HRESULT Copy2DTo(P<IMF2DBuffer2> pDestBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IMF2DBuffer2>, HRESULT>)_vTable[11])(thisPtr, pDestBuffer);
            }
        }
    }
}
