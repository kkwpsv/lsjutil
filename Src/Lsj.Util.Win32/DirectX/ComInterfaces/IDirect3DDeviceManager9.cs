using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.MediaFoundation.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Dxva2;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables two threads to share the same Direct3D 9 device, and provides access to the DirectX Video Acceleration (DXVA) features of the device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxva2api/nn-dxva2api-idirect3ddevicemanager9"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is exposed by the Direct3D Device Manager.
    /// To create the Direct3D device manager, call <see cref="DXVA2CreateDirect3DDeviceManager9"/>.
    /// </para>
    /// <para>
    /// To get this interface from the Enhanced Video Renderer (EVR), call <see cref="IMFGetService.GetService"/>.
    /// The service GUID is <see cref="MR_VIDEO_ACCELERATION_SERVICE"/>.
    /// For the DirectShow EVR filter, call <see cref="IMFGetService.GetService"/> on the filter's pins.
    /// </para>
    /// <para>
    /// The Direct3D Device Manager supports Direct3D 9 devices only. It does not support DXGI devices.
    /// </para>
    /// <para>
    /// Windows Store apps must use <see cref="IMFDXGIDeviceManager"/> and Direct3D 11 Video APIs.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
    [ComInterface(IID = "a0cade0f-06d5-4cf4-a1c7-f3cdd725aa75", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 9, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DDeviceManager9
    {
        IntPtr* _vTable;

        /// <summary>
        /// Sets the Direct3D device or notifies the device manager that the Direct3D device was reset.
        /// </summary>
        /// <param name="pDevice">
        /// Pointer to the <see cref="IDirect3DDevice9"/> interface of the Direct3D device.
        /// </param>
        /// <param name="resetToken">
        /// Token received in the <c>pResetToken</c> parameter of the <see cref="DXVA2CreateDirect3DDeviceManager9"/> function.
        /// </param>
        /// <returns>
        /// <para>
        /// The method returns an <see cref="HRESULT"/>.
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
        /// Invalid token
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="D3DERR_INVALIDCALL"/>
        /// </term>
        /// <term>
        /// Direct3D device error.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you first create the Direct3D device manager, call this method with a pointer to the Direct3D device.
        /// The device manager does not create the device; the caller must provide the device pointer initially.
        /// </para>
        /// <para>
        /// Also call this method if the Direct3D device becomes lost and you need to reset the device or create a new device.
        /// This occurs if <see cref="IDirect3DDevice9.TestCooperativeLevel"/> returns
        /// <see cref="D3DERR_DEVICELOST"/> or <see cref="D3DERR_DEVICENOTRESET"/>.
        /// For more information about lost devices, see the Direct3D documentation.
        /// </para>
        /// <para>
        /// The <paramref name="resetToken"/> parameter ensures that only the component
        /// which originally created the device manager can invalidate the current device.
        /// </para>
        /// <para>
        /// If this method succeeds, all open device handles become invalid.
        /// </para>
        /// </remarks>
        public HRESULT ResetDevice([In] P<IDirect3DDevice9> pDevice, [In] UINT resetToken)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDirect3DDevice9>, UINT, HRESULT>)_vTable[3])(thisPtr, pDevice, resetToken);
            }
        }

        /// <summary>
        /// Gets a handle to the Direct3D device.
        /// </summary>
        /// <param name="phDevice">
        /// Receives the device handle.
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
        /// <see cref="DXVA2_E_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The Direct3D device manager was not initialized.
        /// The owner of the device must call <see cref="ResetDevice"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// To get the Direct3D device's <see cref="IDirect3DDevice9"/> pointer,
        /// call <see cref="LockDevice"/> with the handle returned in <paramref name="phDevice"/>.
        /// Close the device handle when you are done using it, by calling <see cref="CloseDeviceHandle"/>.
        /// </para>
        /// <para>
        /// To test whether a device handle is still valid, call <see cref="TestDevice"/>.
        /// </para>
        /// </remarks>
        public HRESULT OpenDeviceHandle([Out] out HANDLE phDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HANDLE, HRESULT>)_vTable[4])(thisPtr, out phDevice);
            }
        }

        /// <summary>
        /// Closes a Direct3D device handle.
        /// Call this method to release a device handle retrieved by the <see cref="OpenDeviceHandle"/> method.
        /// </summary>
        /// <param name="hDevice">
        /// Handle to the Direct3D device.
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
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// Invalid handle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT CloseDeviceHandle([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[5])(thisPtr, hDevice);
            }
        }

        /// <summary>
        /// Tests whether a Direct3D device handle is valid.
        /// </summary>
        /// <param name="hDevice">
        /// Handle to a Direct3D device.
        /// To get a device handle, call <see cref="OpenDeviceHandle"/>.
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
        /// The device handle is valid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the method returns <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>,
        /// call <see cref="CloseDeviceHandle"/> to close the handle and then call <see cref="OpenDeviceHandle"/> again to get a new handle.
        /// The <see cref="ResetDevice"/> method invalidates all open device handles.
        /// </remarks>
        public HRESULT TestDevice([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[6])(thisPtr, hDevice);
            }
        }

        /// <summary>
        /// Gives the caller exclusive access to the Direct3D device.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="ppDevice">
        /// Receives a pointer to the device's <see cref="IDirect3DDevice9"/> interface.
        /// </param>
        /// <param name="fBlock">
        /// Specifies whether to wait for the device lock.
        /// If the device is already locked and this parameter is <see cref="TRUE"/>,
        /// the method blocks until the device is unlocked.
        /// Otherwise, if the device is locked and this parameter is <see cref="FALSE"/>,
        /// the method returns immediately with the error code <see cref="DXVA2_E_VIDEO_DEVICE_LOCKED"/>.
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
        /// <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXVA2_E_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The Direct3D device manager was not initialized.
        /// The owner of the device must call <see cref="IDirect3DDeviceManager9.ResetDevice"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXVA2_E_VIDEO_DEVICE_LOCKED"/>
        /// </term>
        /// <term>
        /// The device is locked and <paramref name="fBlock"/> is <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you are done using the Direct3D device,
        /// call <see cref="UnlockDevice"/> to unlock to the device.
        /// </para>
        /// <para>
        /// If the method returns <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>,
        /// call <see cref="CloseDeviceHandle"/> to close the handle
        /// and then call <see cref="OpenDeviceHandle"/> again to get a new handle.
        /// The <see cref="ResetDevice"/> method invalidates all open device handles.
        /// </para>
        /// <para>
        /// If <paramref name="fBlock"/> is <see cref="TRUE"/>, this method can potentially deadlock.
        /// For example, it will deadlock if a thread calls <see cref="LockDevice"/>
        /// and then waits on another thread that calls <see cref="LockDevice"/>.
        /// It will also deadlock if a thread calls <see cref="LockDevice"/> twice
        /// without calling <see cref="UnlockDevice"/> in between.
        /// </para>
        /// </remarks>
        public HRESULT LockDevice([In] HANDLE hDevice, [Out] out P<IDirect3DDevice9> ppDevice, [In] BOOL fBlock)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out P<IDirect3DDevice9>, BOOL, HRESULT>)_vTable[7])
                    (thisPtr, hDevice, out ppDevice, fBlock);
            }
        }

        /// <summary>
        /// Unlocks the Direct3D device.
        /// Call this method to release the device after calling <see cref="LockDevice"/>.
        /// </summary>
        /// <param name="hDevice">
        /// Handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="fSaveState">
        /// If <see cref="TRUE"/>, the method saves the Direct3D device state in a state block.
        /// Internally, the method uses the Direct3D <see cref="IDirect3DStateBlock9"/> interface to save the device state.
        /// The next time you call <see cref="LockDevice"/> with the same device handle, the state block is restored.
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
        /// The specified device handle is not locked, or is not a valid handle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT UnlockDevice([In] HANDLE hDevice, [In] BOOL fSaveState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, BOOL, HRESULT>)_vTable[8])(thisPtr, hDevice, fSaveState);
            }
        }

        /// <summary>
        /// Gets a DirectX Video Acceleration (DXVA) service interface.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to a Direct3D device.
        /// To get a device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The interface identifier (IID) of the requested interface.
        /// The Direct3D device might support the following DXVA service interfaces:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="IDirectXVideoDecoderService"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="IDirectXVideoProcessorService"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ppService">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
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
        /// <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXVA2_E_NOT_AVAILABLE"/>
        /// </term>
        /// <term>
        /// The Direct3D device does not support video acceleration.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="DXVA2_E_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The Direct3D device manager was not initialized.
        /// The owner of the device must call <see cref="ResetDevice"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the method returns <see cref="DXVA2_E_NEW_VIDEO_DEVICE"/>,
        /// call <see cref="CloseDeviceHandle"/> to close the handle
        /// and then call <see cref="OpenDeviceHandle"/> again to get a new handle.
        /// The <see cref="ResetDevice"/> method invalidates all open device handles.
        /// </remarks>
        public HRESULT GetVideoService([In] HANDLE hDevice, [In] in IID riid, out IntPtr ppService)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[9])
                    (thisPtr, hDevice, riid, out ppService);
            }
        }
    }
}
