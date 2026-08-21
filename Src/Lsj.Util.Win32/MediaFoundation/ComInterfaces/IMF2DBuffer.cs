using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a buffer that contains a two-dimensional surface, such as a video frame.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imf2dbuffer"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get a pointer to this interface, call <see cref="IUnknown.QueryInterface"/> on the media buffer.
    /// </para>
    /// <para>
    /// To use a 2-D buffer, it is important to know the <c>stride</c>,
    /// which is the number of bytes needed to go from one row of pixels to the next.
    /// The stride may be larger than the image width, because the surface may contain padding bytes after each row of pixels.
    /// Stride can also be negative, if the pixels are oriented bottom-up in memory.
    /// For more information, see Image Stride.
    /// </para>
    /// <para>
    /// Every video format defines a <c>contiguous</c> or <c>packed</c> representation.
    /// This representation is compatible with the standard layout of a DirectX surface in system memory, with no additional padding.
    /// For RGB video, the contiguous representation has a pitch equal to the image width in bytes,
    /// rounded up to the nearest <see cref="DWORD"/> boundary.
    /// For YUV video, the layout of the contiguous representation depends on the YUV format.
    /// For planar YUV formats, the Y plane might have a different pitch than the U and V planes.
    /// </para>
    /// <para>
    /// If a media buffer supports the <see cref="IMF2DBuffer"/> interface,
    /// the underlying buffer is not guaranteed to have a contiguous representation,
    /// because there might be additional padding bytes after each row of pixels.
    /// When a buffer is non-contiguous,
    /// the <see cref="IMFMediaBuffer.Lock"/> and <see cref="Lock2D"/> methods have different behaviors:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The <see cref="Lock2D"/> method returns a pointer to the underlying buffer.
    /// The buffer might not be contiguous.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// The <see cref="IMFMediaBuffer.Lock"/> method returns a buffer that is guaranteed to be contiguous.
    /// If the underlying buffer is not contiguous, the method copies the data into a new buffer,
    /// and the <see cref="Unlock"/> method copies it back into the original buffer.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Call the <see cref="Lock2D"/> method to access the 2-D buffer in its native format.
    /// The native format might not be contiguous.
    /// The buffer's <see cref="IMFMediaBuffer.Lock"/> method returns a contiguous representation of the buffer.
    /// However, this might require an internal copy from the native format.
    /// For 2-D buffers, therefore, you should use the <see cref="Lock2D"/> method
    /// and avoid the <see cref="IMFMediaBuffer.Lock"/> method.
    /// Because the <see cref="IMFMediaBuffer.Lock"/> method might cause up to two buffer copies,
    /// the <see cref="Lock2D"/> method is generally more efficient and should be used when possible.
    /// To find out if the underlying buffer is contiguous, call <see cref="IMF2DBuffer.IsContiguousFormat"/>.
    /// </para>
    /// <para>
    /// For uncompressed images, the amount of valid data in the buffer is determined by the width, height, and pixel layout of the image.
    /// For this reason, if you call <see cref="Lock2D"/> to access the buffer,
    /// do not rely on the values returned by <see cref="IMFMediaBuffer.GetCurrentLength"/> or <see cref="IMFMediaBuffer.GetMaxLength"/>.
    /// Similarly, if you modify the data in the buffer,
    /// you do not have to call <see cref="IMFMediaBuffer.SetCurrentLength"/> to update the size.
    /// Generally, you should avoid mixing calls to <see cref="IMF2DBuffer"/> and <see cref="IMFMediaBuffer"/> methods on the same media buffer.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "7DC9D5F9-9ED9-44ec-9BBF-0600BB589FBB", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 9, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMF2DBuffer
    {
        nint* _vTable;

        /// <summary>
        /// Gives the caller access to the memory in the buffer.
        /// </summary>
        /// <param name="ppbScanline0">
        /// Receives a pointer to the first byte of the top row of pixels in the image.
        /// The top row is defined as the top row when the image is presented to the viewer, and might not be the first row in memory.
        /// </param>
        /// <param name="plPitch">
        /// Receives the surface stride, in bytes.
        /// The stride might be negative, indicating that the image is oriented from the bottom up in memory.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DERR_INVALIDCALL"/>
        /// </term>
        /// <term>
        /// Cannot lock the Direct3D surface.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_INVALIDREQUEST"/>
        /// </term>
        /// <term>
        /// The buffer cannot be locked at this time.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If <c>p</c> is a pointer to the first byte in a row of pixels,
        /// <c>p + (*plPitch)</c> points to the first byte in the next row of pixels.
        /// A buffer might contain padding after each row of pixels,
        /// so the stride might be wider than the width of the image in bytes.
        /// Do not access the memory that is reserved for padding bytes,
        /// because it might not be read-accessible or write-accessible
        /// . For more information, see Image Stride.
        /// </para>
        /// <para>
        /// The pointer returned in <paramref name="ppbScanline0"/> remains valid as long as the caller holds the lock.
        /// When you are done accessing the memory, call <see cref="Unlock2D"/> to unlock the buffer.
        /// You must call <see cref="Unlock2D"/> once for each call to <see cref="Lock2D"/>.
        /// After you unlock the buffer, the pointer returned in <paramref name="ppbScanline0"/> is no longer valid and should not be used.
        /// Generally, it is best to call <see cref="Lock2D"/> only when you need to access the buffer memory, and not earlier.
        /// </para>
        /// <para>
        /// The values returned by the <see cref="IMFMediaBuffer.GetCurrentLength"/>
        /// and <see cref="IMFMediaBuffer.GetMaxLength"/> methods do not apply to the buffer
        /// that is returned by the <see cref="Lock2D"/> method.
        /// For the same reason, you do not need to call <see cref="IMFMediaBuffer.SetCurrentLength"/>
        /// after manipulating the data in the buffer returned by the <see cref="Lock2D"/> method.
        /// </para>
        /// <para>
        /// The <see cref="IMFMediaBuffer.Lock"/> method fails while the <see cref="Lock2D"/> lock is held, and vice-versa.
        /// Applications should use only one of these methods at a time.
        /// </para>
        /// <para>
        /// When the underlying buffer is a Direct3D surface, the method fails if the surface is not lockable.
        /// </para>
        /// </remarks>
        public HRESULT Lock2D([Out] out P<BYTE> ppbScanline0, [Out] out LONG plPitch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<BYTE>, out LONG, HRESULT>)_vTable[3])(thisPtr, out ppbScanline0, out plPitch);
            }
        }

        /// <summary>
        /// Unlocks a buffer that was previously locked.
        /// Call this method once for each call to <see cref="Lock2D"/>.
        /// </summary>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT Unlock2D()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves a pointer to the buffer memory and the surface stride.
        /// </summary>
        /// <param name="pbScanline0">
        /// Receives a pointer to the first byte of the top row of pixels in the image.
        /// </param>
        /// <param name="plPitch">
        /// Receives the stride, in bytes. For more information, see Image Stride.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ERROR_INVALID_FUNCTION"/>
        /// </term>
        /// <term>
        /// You must lock the buffer before calling this method.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// Before calling this method, you must lock the buffer by calling <see cref="Lock2D"/>.
        /// The pointer returned in <paramref name="plPitch"/> is valid only while the buffer remains locked.
        /// </remarks>
        public HRESULT GetScanline0AndPitch([Out] out P<BYTE> pbScanline0, [Out] out LONG plPitch)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<BYTE>, out LONG, HRESULT>)_vTable[5])(thisPtr, out pbScanline0, out plPitch);
            }
        }

        /// <summary>
        /// Queries whether the buffer is contiguous in its native format.
        /// </summary>
        /// <param name="pfIsContiguous">
        /// Receives a Boolean value.
        /// The value is <see cref="TRUE"/> if the buffer is contiguous, and <see cref="FALSE"/> otherwise.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// For a definition of contiguous as it applies to 2-D buffers, see the Remarks section in <see cref="IMF2DBuffer"/> interface.
        /// For non-contiguous buffers, the <see cref="IMFMediaBuffer.Lock"/> method must perform an internal copy.
        /// </remarks>
        public HRESULT IsContiguousFormat([Out] out BOOL pfIsContiguous)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOL, HRESULT>)_vTable[6])(thisPtr, out pfIsContiguous);
            }
        }

        /// <summary>
        /// Retrieves the number of bytes needed to store the contents of the buffer in contiguous format.
        /// </summary>
        /// <param name="pcbLength">
        /// Receives the number of bytes needed to store the contents of the buffer in contiguous format.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// For a definition of contiguous as it applies to 2-D buffers, see the Remarks section in <see cref="IMF2DBuffer"/> interface.
        /// </remarks>
        public HRESULT GetContiguousLength([Out] out DWORD pcbLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[7])(thisPtr, out pcbLength);
            }
        }

        /// <summary>
        /// Copies this buffer into the caller's buffer, converting the data to contiguous format.
        /// </summary>
        /// <param name="pbDestBuffer">
        /// Pointer to the destination buffer where the data will be copied.
        /// The caller allocates the buffer.
        /// </param>
        /// <param name="cbDestBuffer">
        /// Size of the destination buffer, in bytes.
        /// To get the required size, call <see cref="GetContiguousLength"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_INVALIDARG"/>
        /// </term>
        /// <term>
        /// Invalid size specified in <paramref name="pbDestBuffer"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the original buffer is not contiguous, this method converts the contents into contiguous format during the copy.
        /// For a definition of contiguous as it applies to 2-D buffers,
        /// see the Remarks section in <see cref="IMF2DBuffer"/> interface.
        /// </remarks>
        public HRESULT ContiguousCopyTo(P<BYTE> pbDestBuffer, DWORD cbDestBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<BYTE>, DWORD, HRESULT>)_vTable[8])(thisPtr, pbDestBuffer, cbDestBuffer);
            }
        }

        /// <summary>
        /// Copies data to this buffer from a buffer that has a contiguous format.
        /// </summary>
        /// <param name="pbSrcBuffer">
        /// Pointer to the source buffer. The caller allocates the buffer.
        /// </param>
        /// <param name="cbSrcBuffer">
        /// Size of the source buffer, in bytes.
        /// To get the maximum size of the buffer, call <see cref="GetContiguousLength"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
        /// Possible values include, but are not limited to, those in the following table.
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
        /// The method succeeded.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method copies the contents of the source buffer into the buffer
        /// that is managed by this <see cref="IMF2DBuffer"/> object.
        /// The source buffer must be in contiguous format. 
        /// While copying, the method converts the contents into the destination buffer's native format,
        /// correcting for the buffer's pitch if necessary.
        /// </para>
        /// <para>
        /// For a definition of contiguous as it applies to 2-D buffers,
        /// see the Remarks section in the <see cref="IMF2DBuffer"/> interface topic.
        /// </para>
        /// </remarks>
        public HRESULT ContiguousCopyFrom(P<BYTE> pbSrcBuffer, DWORD cbSrcBuffer)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<BYTE>, DWORD, HRESULT>)_vTable[9])(thisPtr, pbSrcBuffer, cbSrcBuffer);
            }
        }
    }
}
