using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using IUnknown = Lsj.Util.Win32.ComInterfaces.IUnknown;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIObject"/> interface is a base interface for all DXGI objects;
    /// <see cref="IDXGIObject"/> supports associating caller-defined (private data) with an object and retrieval of an interface to the parent object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiobject"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIObject
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="Name">
        /// A GUID that identifies the data.
        /// Use this GUID in a call to <see cref="GetPrivateData"/> to get the data.
        /// </param>
        /// <param name="DataSize">
        /// The size of the object's data.
        /// </param>
        /// <param name="pData">
        /// A pointer to the object's data.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <see cref="SetPrivateData"/> makes a copy of the specified data and stores it with the object.
        /// Private data that <see cref="SetPrivateData"/> stores in the object occupies the same storage spaceas private data
        /// that is stored by associated Direct3D objects (for example, by a Microsoft Direct3D 11 device
        /// through <see cref="ID3D11Device.SetPrivateData"/> or by a Direct3D 11 child device through <see cref="ID3D11DeviceChild.SetPrivateData"/>).
        /// The debug layer reports memory leaks by outputting a list of object interface pointers along with their friendly names.
        /// The default friendly name is "&lt;unnamed&gt;".
        /// You can set the friendly name so that you can determine if the corresponding object interface pointer caused the leak.
        /// To set the friendly name, use the <see cref="SetPrivateData"/> method
        /// and the well-known private data GUID (<see cref="WKPDID_D3DDebugObjectName"/>) that is in D3Dcommon.h.
        /// For example, to give pContext a friendly name of My name, use the following code:
        /// <code>
        /// static const char c_szName[] = "My name";
        /// hr = pContext->SetPrivateData( WKPDID_D3DDebugObjectName, sizeof( c_szName ) - 1, c_szName );
        /// </code>
        /// You can use <see cref="WKPDID_D3DDebugObjectName"/> to track down memory leaks and understand performance characteristics of your applications.
        /// This information is reflected in the output of the debug layer that is related to memory leaks
        /// (<see cref="ID3D11Debug.ReportLiveDeviceObjects"/>) and with the event tracing for Windows events that we've added to Windows 8.
        /// </remarks>
        public HRESULT SetPrivateData([In] in GUID Name, [In] UINT DataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, UINT, IntPtr, HRESULT>)_vTable[3])(thisPtr, Name, DataSize, pData);
            }
        }

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="Name">
        /// A GUID identifying the interface.
        /// </param>
        /// <param name="pUnknown">
        /// The interface to set.
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// This API associates an interface pointer with the object.
        /// When the interface is set its reference count is incremented.
        /// When the data are overwritten (by calling SPD or SPDI with the same GUID) or the object is destroyed,
        /// <see cref="IUnknown.Release"/> is called and the interface's reference count is decremented.
        /// </remarks>
        public HRESULT SetPrivateDataInterface([In] in GUID Name, [In] in IUnknown pUnknown)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, in IUnknown, HRESULT>)_vTable[4])(thisPtr, Name, pUnknown);
            }
        }

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="Name">
        /// A GUID identifying the data.
        /// </param>
        /// <param name="pDataSize">
        /// The size of the data.
        /// </param>
        /// <param name="pData">
        /// Pointer to the data.
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// If the data returned is a pointer to an <see cref="IUnknown"/>, or one of its derivative classes,
        /// previously set by <see cref="SetPrivateDataInterface"/>, you must call <see cref="IUnknown.Release"/> on the pointer
        /// before the pointer is freed to decrement the reference count.
        /// You can pass <see cref="GUID_DeviceType"/> in the <paramref name="Name"/> parameter of <see cref="GetPrivateData"/>
        /// to retrieve the device type from the display adapter object (<see cref="IDXGIAdapter"/>, <see cref="IDXGIAdapter1"/>, <see cref="IDXGIAdapter2"/>).
        /// To get the type of device on which the display adapter was created
        /// 1. Call <see cref="IUnknown.QueryInterface"/> on the <see cref="ID3D11Device"/> or <see cref="ID3D10Device"/> object
        /// to retrieve the <see cref="IDXGIDevice"/> object.
        /// 2. Call <see cref="GetParent"/> on the <see cref="IDXGIDevice"/> object to retrieve the <see cref="IDXGIAdapter"/> object.
        /// 3. Call <see cref="GetPrivateData"/> on the <see cref="IDXGIAdapter"/> object with <see cref="GUID_DeviceType"/>
        /// to retrieve the type of device on which the display adapter was created.
        /// <paramref name="pData"/> will point to a value from the driver-type enumeration (for example, a value from <see cref="D3D_DRIVER_TYPE"/>).
        /// On Windows 7 or earlier, this type is either a value from <see cref="D3D10_DRIVER_TYPE"/> or <see cref="D3D_DRIVER_TYPE"/>
        /// depending on which kind of device was created.
        /// On Windows 8, this type is always a value from <see cref="D3D_DRIVER_TYPE"/>.
        /// Don't use <see cref="SetPrivateData"/> with <see cref="GUID_DeviceType"/> because the behavior when doing so is undefined.
        /// </remarks>
        public HRESULT GetPrivateData([In] in GUID Name, [In][Out] ref UINT pDataSize, [In] IntPtr pData)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, ref UINT, IntPtr, HRESULT>)_vTable[5])(thisPtr, Name, ref pDataSize, pData);
            }
        }

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">
        /// The ID of the requested interface.
        /// </param>
        /// <param name="ppParent">
        /// The address of a pointer to the parent object.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        public HRESULT GetParent([In] in IID riid, [Out] out IntPtr ppParent)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[6])(thisPtr, riid, out ppParent);
            }
        }
    }
}
