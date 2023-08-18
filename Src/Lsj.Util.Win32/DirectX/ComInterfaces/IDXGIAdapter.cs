using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIAdapter"/> interface represents a display subsystem (including one or more GPUs, DACs and video memory).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiadapter"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A display subsystem is often referred to as a video card, however, on some machines the display subsystem is part of the motherboard.
    /// To enumerate the display subsystems, use <see cref="IDXGIFactory.EnumAdapters"/>.
    /// To get an interface to the adapter for a particular device, use <see cref="IDXGIDevice.GetAdapter"/>.
    /// To create a software adapter, use <see cref="IDXGIFactory.CreateSoftwareAdapter"/>.
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct IDXGIAdapter
    {
        IntPtr* _vTable;

        /// <summary>
        /// Enumerate adapter (video card) outputs.
        /// </summary>
        /// <param name="Output">
        /// The index of the output.
        /// </param>
        /// <param name="ppOutput">
        /// The address of a pointer to an <see cref="IDXGIOutput"/> interface at the position specified by the <paramref name="Output"/> parameter.
        /// </param>
        /// <returns>
        /// A code that indicates success or failure (see DXGI_ERROR).
        /// <see cref="DXGI_ERROR_NOT_FOUND"/> is returned if the index is greater than the number of outputs.
        /// If the adapter came from a device created using <see cref="D3D_DRIVER_TYPE_WARP"/>,
        /// then the adapter has no outputs, so <see cref="DXGI_ERROR_NOT_FOUND"/> is returned.
        /// </returns>
        /// <remarks>
        /// Note
        /// If you call this API in a Session 0 process, it returns <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// When the <see cref="EnumOutputs"/> method succeeds and fills the <paramref name="ppOutput"/> parameter with the address of the pointer to the output interface,
        /// <see cref="EnumOutputs"/> increments the output interface's reference count.
        /// To avoid a memory leak, when you finish using the output interface, call the <see cref="IUnknown.Release"/> method to decrement the reference count.
        /// <see cref="EnumOutputs"/> first returns the output on which the desktop primary is displayed.
        /// This output corresponds with an index of zero.
        /// <see cref="EnumOutputs"/> then returns other outputs.
        /// </remarks>
        public HRESULT EnumOutputs([In] UINT Output, [Out] out P<IDXGIOutput> ppOutput)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGIOutput>, HRESULT>)_vTable[7])(thisPtr, Output, out ppOutput);
            }
        }

        /// <summary>
        /// Gets a DXGI 1.0 description of an adapter (or video card).
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_ADAPTER_DESC"/> structure that describes the adapter.
        /// This parameter must not be <see cref="NullRef{DXGI_ADAPTER_DESC}"/>.
        /// On feature level 9 graphics hardware, <see cref="GetDesc"/> returns zeros for the PCI ID in the <see cref="DXGI_ADAPTER_DESC.VendorId"/>,
        /// <see cref="DXGI_ADAPTER_DESC.DeviceId"/>, <see cref="DXGI_ADAPTER_DESC.SubSysId"/>,
        /// and <see cref="DXGI_ADAPTER_DESC.Revision"/> members of <see cref="DXGI_ADAPTER_DESC"/>
        /// and “Software Adapter” for the description string in the <see cref="DXGI_ADAPTER_DESC.Description"/> member.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; otherwise returns <see cref="E_INVALIDARG"/> if the <paramref name="pDesc"/> parameter is <see cref="NullRef{DXGI_ADAPTER_DESC}"/>.
        /// </returns>
        /// <remarks>
        /// Graphics apps can use the DXGI API to retrieve an accurate set of graphics memory values on systems that have Windows Display Driver Model (WDDM) drivers.
        /// The following are the critical steps involved.
        /// Graphics driver model determination —Because DXGI is only available on systems with WDDM drivers, the app must first confirm the driver model by using the following API.
        /// <code>
        /// HasWDDMDriver()
        /// {
        ///     LPDIRECT3DCREATE9EX pD3D9Create9Ex = NULL;
        ///     HMODULE             hD3D9          = NULL;
        ///     
        ///     hD3D9 = LoadLibrary( L"d3d9.dll" );
        ///     
        ///     if ( NULL == hD3D9 ) {
        ///         return false;
        ///     }
        ///     
        ///     //
        ///     /*  Try to create IDirect3D9Ex interface (also known as a DX9L interface). This interface can only be created if the driver is a WDDM driver.
        ///      */
        ///     //
        ///     pD3D9Create9Ex = (LPDIRECT3DCREATE9EX) GetProcAddress( hD3D9, "Direct3DCreate9Ex" );
        ///     
        ///     return pD3D9Create9Ex != NULL;
        /// }
        /// </code>
        /// Retrieval of graphics memory values.—After the app determines the driver model to be WDDM,
        /// the app can use the Direct3D 10 or later API and DXGI to get the amount of graphics memory.
        /// After you create a Direct3D device, use this code to obtain a <see cref="DXGI_ADAPTER_DESC"/> structure that contains the amount of available graphics memory.
        /// <code>
        /// IDXGIDevice * pDXGIDevice;
        /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void **)&amp;pDXGIDevice);
        /// IDXGIAdapter * pDXGIAdapter;
        /// pDXGIDevice->GetAdapter(&amp;pDXGIAdapter);
        /// DXGI_ADAPTER_DESC adapterDesc;
        /// pDXGIAdapter->GetDesc(&amp;adapterDesc);
        /// </code>
        /// </remarks>
        public HRESULT GetDesc([Out] out DXGI_ADAPTER_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_ADAPTER_DESC, HRESULT>)_vTable[8])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Checks whether the system supports a device interface for a graphics component.
        /// </summary>
        /// <param name="InterfaceName">
        /// The GUID of the interface of the device version for which support is being checked.
        /// This should usually be __uuidof(IDXGIDevice), which returns the version number of the Direct3D 9 UMD (user mode driver) binary.
        /// Since WDDM 2.3, all driver components within a driver package (D3D9, D3D11, and D3D12) have been required to share a single version number,
        /// so this is a good way to query the driver version regardless of which API is being used.
        /// </param>
        /// <param name="pUMDVersion">
        /// The user mode driver version of <paramref name="InterfaceName"/>.
        /// This is returned only if the interface is supported, otherwise this parameter will be NULL.
        /// </param>
        /// <returns>
        /// <see cref="S_OK"/> indicates that the interface is supported, otherwise <see cref="DXGI_ERROR_UNSUPPORTED"/> is returned
        /// (For more information, see <see cref="DXGI_ERROR"/>).
        /// </returns>
        /// <remarks>
        /// Note
        /// You can use <see cref="CheckInterfaceSupport"/> only to check whether a Direct3D 10.x interface is supported,
        /// and only on Windows Vista SP1 and later versions of the operating system.
        /// If you try to use <see cref="CheckInterfaceSupport"/> to check whether a Direct3D 11.x and later version interface is supported,
        /// <see cref="CheckInterfaceSupport"/> returns <see cref="DXGI_ERROR_UNSUPPORTED"/>.
        /// Therefore, do not use <see cref="CheckInterfaceSupport"/>.
        /// Instead, to verify whether the operating system supports a particular interface, try to create the interface.
        /// For example, if you call the <see cref="ID3D11Device.CreateBlendState"/> method and it fails, the operating system does not support the ID3D11BlendState interface.
        /// </remarks>
        public HRESULT CheckInterfaceSupport([In] in GUID InterfaceName, [Out] out LARGE_INTEGER pUMDVersion)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out LARGE_INTEGER, HRESULT>)_vTable[9])(thisPtr, InterfaceName, out pUMDVersion);
            }
        }
    }
}
