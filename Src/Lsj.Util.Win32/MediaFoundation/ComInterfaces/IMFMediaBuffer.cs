using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.D3DERR;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a block of memory that contains media data. Use this interface to access the data in the buffer.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfmediabuffer"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the buffer contains 2-D image data (such as an uncompressed video frame),
    /// you should query the buffer for the <see cref="IMF2DBuffer"/> interface.
    /// The methods on <see cref="IMF2DBuffer"/> are optimized for 2-D data.
    /// </para>
    /// <para>
    /// To get a buffer from a media sample, call one of the following <see cref="IMFSample"/> methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="IMFSample.ConvertToContiguousBuffer"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IMFSample.GetBufferByIndex"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// To create a new buffer object, use one of the following functions.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Function
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="MFCreateMemoryBuffer"/>
    /// </term>
    /// <term>
    /// Creates a buffer and allocates system memory.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MFCreateMediaBufferWrapper"/>
    /// </term>
    /// <term>
    /// Creates a media buffer that wraps an existing media buffer.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MFCreateDXSurfaceBuffer"/>
    /// </term>
    /// <term>
    /// Creates a buffer that manages a DirectX surface.
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="MFCreateAlignedMemoryBuffer"/>
    /// </term>
    /// <term>
    /// Creates a buffer and allocates system memory with a specified alignment.
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// This interface is available on the following platforms if the Windows Media Format 11 SDK redistributable components are installed:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Windows XP with Service Pack 2 (SP2) and later.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
    /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "045FA593-8799-42b8-BC8D-8968C6453507", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 7, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFMediaBuffer
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gives the caller access to the memory in the buffer, for reading or writing
        /// </summary>
        /// <param name="ppbBuffer">
        /// Receives a pointer to the start of the buffer.
        /// </param>
        /// <param name="pcbMaxLength">
        /// Receives the maximum amount of data that can be written to the buffer.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// The same value is returned by the <see cref="GetMaxLength"/> method.
        /// </param>
        /// <param name="pcbCurrentLength">
        /// Receives the length of the valid data in the buffer, in bytes.
        /// This parameter can be <see cref="NullRef{DWORD}"/>.
        /// The same value is returned by the <see cref="GetCurrentLength"/> method.
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
        /// For Direct3D surface buffers, an error occurred when locking the surface.
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
        /// This method gives the caller access to the entire buffer,
        /// up to the maximum size returned in the <paramref name="pcbMaxLength"/> parameter.
        /// The value returned in <paramref name="pcbCurrentLength"/> is the size of any valid data already in the buffer,
        /// which might be less than the total buffer size.
        /// </para>
        /// <para>
        /// The pointer returned in <paramref name="ppbBuffer"/> is guaranteed to be valid,
        /// and can safely be accessed across the entire buffer for as long as the lock is held.
        /// When you are done accessing the buffer, call <see cref="Unlock"/> to unlock the buffer.
        /// You must call <see cref="Unlock"/> once for each call to <see cref="Lock"/>.
        /// After you unlock the buffer, the pointer returned in <paramref name="ppbBuffer"/> is no longer valid, and should not be used.
        /// Generally, it is best to call <see cref="Lock"/> only when you need to access the buffer memory, and not earlier.
        /// </para>
        /// <para>
        /// Locking the buffer does not prevent other threads from calling <see cref="Lock"/>,
        /// so you should not rely on this method to synchronize threads.
        /// </para>
        /// <para>
        /// This method may allocate memory, but does not transfer ownership of the memory to the caller.
        /// Do not release or free the memory; the media buffer will free the memory when the media buffer is destroyed.
        /// </para>
        /// <para>
        /// If you modify the contents of the buffer, update the current length by calling <see cref="SetCurrentLength"/>.
        /// </para>
        /// <para>
        /// This method may internally allocate some memory, so if the buffer supports the <see cref="IMF2DBuffer"/> interface,
        /// you should use the <see cref="IMF2DBuffer.Lock2D"/> method to lock the buffer instead.
        /// For 2-D buffers, the <see cref="IMF2DBuffer2.Lock2DSize"/> method can be more efficient than the <see cref="Lock"/> method,
        /// depending on the <see cref="MF2DBuffer_LockFlags"/> value you specify.
        /// Calling <see cref="IMF2DBuffer2.Lock2DSize"/> with <see cref="MF2DBuffer_LockFlags_Read"/>
        /// won’t incur a copy back when the buffer is unlocked
        /// and calling it with <see cref="MF2DBuffer_LockFlags_Write"/> won’t incur a copy from the internal buffer.
        /// Calling <see cref="IMF2DBuffer2.Lock2DSize"/> with <see cref="LockFlags_ReadWrite"/>
        /// behaves the same as <see cref="Lock"/> and <see cref="IMF2DBuffer.Lock2D"/>
        /// and will incur a both copy from and copy back when unlocked.
        /// The general guidance for best performance is to avoid using <see cref="IMFMediaBuffer"/> and <see cref="IMF2DBuffer"/> whenever possible
        /// and instead use <see cref="IMF2DBuffer2"/> with the minimum required lock flags.
        /// Note that if the buffer is locked using <see cref="Lock2D"/>,
        /// the <see cref="Lock"/> method might return <see cref="MF_E_INVALIDREQUEST"/>.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT Lock([Out] out P<BYTE> ppbBuffer, [Out] out DWORD pcbMaxLength, [Out] out DWORD pcbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<BYTE>, out DWORD, out DWORD, HRESULT>)_vTable[3])
                    (thisPtr, out ppbBuffer, out pcbMaxLength, out pcbCurrentLength);
            }
        }

        /// <summary>
        /// Unlocks a buffer that was previously locked. Call this method once for every call to <see cref="Lock"/>.
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
        /// <item>
        /// <term>
        /// <see cref="D3DERR_INVALIDCALL"/>
        /// </term>
        /// <term>
        /// For Direct3D surface buffers, an error occurred when unlocking the surface.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// It is an error to call <see cref="Unlock"/> if you did not call <see cref="Lock"/> previously.
        /// </para>
        /// <para>
        /// After calling this method, do not use the pointer returned by the <see cref="Lock"/> method.
        /// It is no longer guaranteed to be valid.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT Unlock()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Retrieves the length of the valid data in the buffer.
        /// </summary>
        /// <param name="pcbCurrentLength">
        /// Receives the length of the valid data, in bytes.
        /// If the buffer does not contain any valid data, the value is zero.
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
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetCurrentLength([Out] out DWORD pcbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[5])(thisPtr, out pcbCurrentLength);
            }
        }

        /// <summary>
        /// Sets the length of the valid data in the buffer.
        /// </summary>
        /// <param name="cbCurrentLength">
        /// Length of the valid data, in bytes.
        /// This value cannot be greater than the allocated size of the buffer,
        /// which is returned by the <see cref="GetMaxLength"/> method.
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
        /// The specified length is greater than the maximum size of the buffer.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Call this method if you write data into the buffer.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT SetCurrentLength(DWORD cbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[6])(thisPtr, cbCurrentLength);
            }
        }

        /// <summary>
        /// Retrieves the allocated size of the buffer.
        /// </summary>
        /// <param name="pcbMaxLength">
        /// Receives the allocated size of the buffer, in bytes.
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
        /// The buffer might or might not contain any valid data,
        /// and if there is valid data in the buffer, it might be smaller than the buffer's allocated size.
        /// To get the length of the valid data, call <see cref="GetCurrentLength"/>.
        /// </para>
        /// <para>
        /// This interface is available on the following platforms
        /// if the Windows Media Format 11 SDK redistributable components are installed:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Windows XP with Service Pack 2 (SP2) and later.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Windows XP Media Center Edition 2005 with KB900325 (Windows XP Media Center Edition 2005)
        /// and KB925766 (October 2006 Update Rollup for Windows XP Media Center Edition) installed.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        public HRESULT GetMaxLength([Out] out DWORD pcbMaxLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[7])(thisPtr, out pcbMaxLength);
            }
        }
    }
}
