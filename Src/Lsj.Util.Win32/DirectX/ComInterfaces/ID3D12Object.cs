using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An interface from which <see cref="ID3D12Device"/> and <see cref="ID3D12DeviceChild"/> inherit from.
    /// It provides methods to associate private data and annotate object names.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12object"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "c4fec28f-7966-4e95-9f94-f431cb56c3b8", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 6, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct ID3D12Object
    {
        nint* _vTable;

        /// <summary>
        /// Gets application-defined data from a device object.
        /// </summary>
        /// <param name="guid">
        /// The <see cref="GUID"/> that is associated with the data.
        /// </param>
        /// <param name="pDataSize">
        /// A pointer to a variable that on input contains the size, in bytes, of the buffer
        /// that <paramref name="pData"/> points to, and on output contains the size, in bytes,
        /// of the amount of data that <see cref="GetPrivateData"/> retrieved.
        /// </param>
        /// <param name="pData">
        /// A pointer to a memory block that receives the data from the device object
        /// if <paramref name="pDataSize"/> points to a value that specifies a buffer large enough to hold the data.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// If the data returned is a pointer to an <see cref="IUnknown"/>, or one of its derivative classes,
        /// which was previously set by <see cref="SetPrivateDataInterface"/>,
        /// that interface will have its reference count incremented before the private data is returned.
        /// </remarks>
        public HRESULT GetPrivateData([In] in GUID guid, [In][Out] ref UINT pDataSize, [Out] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, ref UINT, nint, HRESULT>)_vTable[3])
                    (thisPtr, guid, ref pDataSize, pData);
            }
        }

        /// <summary>
        /// Sets application-defined data to a device object
        /// and associates that data with an application-defined <see cref="GUID"/>.
        /// </summary>
        /// <param name="guid">
        /// The <see cref="GUID"/> to associate with the data.
        /// </param>
        /// <param name="DataSize">
        /// The size in bytes of the data.
        /// </param>
        /// <param name="pData">
        /// A pointer to a memory block that contains the data to be stored with this device object.
        /// If <paramref name="pData"/> is <see cref="NULL"/>, <paramref name="DataSize"/> must also be 0,
        /// and any data that was previously associated with the <see cref="GUID"/> specified in <paramref name="guid"/> will be destroyed.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// Rather than using the Direct3D 11 debug object naming scheme of calling <see cref="SetPrivateData"/>
        /// using <see cref="WKPDID_D3DDebugObjectName"/> with an ASCII name, call <see cref="SetName"/> with a UNICODE name.
        /// </remarks>
        public HRESULT SetPrivateData([In] in GUID guid, [In] UINT DataSize, [In] nint pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT, nint, HRESULT>)_vTable[4])(thisPtr, guid, DataSize, pData);
            }
        }

        /// <summary>
        /// <para>
        /// Associates an <see cref="IUnknown"/>-derived interface with the device object,
        /// and associates that interface with an application-defined <see cref="GUID"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nf-d3d12-id3d12object-setprivatedatainterface"/>
        /// </para>
        /// </summary>
        /// <param name="guid">
        /// The <see cref="GUID"/> to associate with the interface.
        /// </param>
        /// <param name="pData">
        /// A pointer to the <see cref="IUnknown"/>-derived interface to be associated with the device object.
        /// Its reference count is incremented when set, and decremented when either the <see cref="ID3D12Object"/> is destroyed,
        /// or when the data is overwritten by calling <see cref="SetPrivateData"/>
        /// or <see cref="SetPrivateDataInterface"/> with the same <see cref="GUID"/>.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 return codes.
        /// </returns>
        public HRESULT SetPrivateDataInterface([In] in GUID guid, [In] P<IUnknown> pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, P<IUnknown>, HRESULT>)_vTable[5])(thisPtr, guid, pData);
            }
        }

        /// <summary>
        /// Associates a name with the device object.
        /// This name is for use in debug diagnostics and tools.
        /// </summary>
        /// <param name="Name">
        /// A <see cref="NULL"/>-terminated UNICODE string that contains the name to associate with the device object.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 return codes.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method takes UNICODE names.
        /// </para>
        /// <para>
        /// Note that this is simply a convenience wrapper around <see cref="SetPrivateData"/> with <see cref="WKPDID_D3DDebugObjectName"/>.
        /// Therefore names which are set with <c>SetName</c> can be retrieved with <see cref="GetPrivateData"/> with the same GUID.
        /// Additionally, D3D12 supports narrow strings for names, using the <see cref="WKPDID_D3DDebugObjectName"/> GUID directly instead.
        /// </para>
        /// </remarks>
        public HRESULT SetName([In] LPWSTR Name)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, nint, HRESULT>)_vTable[6])(thisPtr, Name.Handle);
            }
        }
    }
}
