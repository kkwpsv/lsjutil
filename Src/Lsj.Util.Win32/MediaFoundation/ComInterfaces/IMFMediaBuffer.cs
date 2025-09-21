using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

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

        public HRESULT Lock([Out] out P<BYTE> ppbBuffer, [Out] out DWORD pcbMaxLength, [Out] out DWORD pcbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<BYTE>, out DWORD, out DWORD, HRESULT>)_vTable[3])(thisPtr, out ppbBuffer, out pcbMaxLength, out pcbCurrentLength);
            }
        }

        public HRESULT Unlock()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        public HRESULT GetCurrentLength([Out] out DWORD pcbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[5])(thisPtr, out pcbCurrentLength);
            }
        }

        public HRESULT SetCurrentLength(DWORD cbCurrentLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DWORD, HRESULT>)_vTable[6])(thisPtr, cbCurrentLength);
            }
        }

        public HRESULT GetMaxLength([Out] out DWORD pcbMaxLength)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DWORD, HRESULT>)_vTable[7])(thisPtr, out pcbMaxLength);
            }
        }
    }
}
