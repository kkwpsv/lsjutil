using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.DirectX.D3D11;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CREATE_DEVICE_FLAG;
using static Lsj.Util.Win32.MediaFoundation.Mfplat;

namespace Lsj.Util.Win32.MediaFoundation.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables two threads to share the same Microsoft Direct3D 11 device.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/mfobjects/nn-mfobjects-imfdxgidevicemanager"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is exposed by the Microsoft DirectX Graphics Infrastructure (DXGI) Device Manager.
    /// To create the DXGI Device Manager, call the <see cref="MFCreateDXGIDeviceManager"/> function.
    /// </para>
    /// <para>
    /// When you create an <see cref="IMFDXGIDeviceManager"/> with <see cref="MFCreateDXGIDeviceManager"/>,
    /// a Direct3D 11 device is not associated with the device manager.
    /// To associate a Direct3D 11 device with the device manager,
    /// call <see cref="ResetDevice"/>, passing in the pointer to the Direct3D 11 device.
    /// To create a Direct3D 11 device, call <see cref="D3D11CreateDevice"/>.
    /// The device should be created with the <see cref="D3D11_CREATE_DEVICE_VIDEO_SUPPORT"/> device creation flag
    /// which is defined in the <see cref="D3D11_CREATE_DEVICE_FLAG"/> enumeration.
    /// </para>
    /// <para>
    /// For Microsoft Direct3D 9 devices, use the <see cref="IDirect3DDeviceManager9"/> interface.
    /// </para>
    /// <para>
    /// Windows Store apps must use <see cref="IMFDXGIDeviceManager"/> and Direct3D 11 Video APIs.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows8)]
    [ComInterface(IID = "eb533d5d-2db6-40f8-97a9-494692014f07", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 9, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IMFDXGIDeviceManager
    {
        IntPtr* _vTable;

        /// <summary>
        /// Closes a Microsoft Direct3D device handle.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
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
        /// Call this method to release a device handle
        /// that was retrieved by the <see cref="OpenDeviceHandle"/> method.
        /// </remarks>
        public HRESULT CloseDeviceHandle([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[3])(thisPtr, hDevice);
            }
        }

        /// <summary>
        /// Queries the Microsoft Direct3D device for an interface.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The interface identifier (IID) of the requested interface. The Direct3D device supports the following interfaces:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D11Device"/>. 
        /// To get a pointer to the Direct3D11 device,
        /// use <see cref="IID_ID3D11Device"/> as the <paramref name="riid"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D11VideoDevice"/>.
        /// To get a pointer to the Direct3D11 video device,
        /// use <see cref="IID_ID3D11VideoDevice"/> as the <paramref name="riid"/>.
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
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_DEVICE_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The DXGI Device Manager was not initialized.
        /// The owner of the device must call <see cref="ResetDevice"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_NOINTERFACE"/>
        /// </term>
        /// <term>
        /// If a <see cref="ID3D11VideoDevice"/> is specified and the D3D device created is using the reference rasterizer or WARP.
        /// Or it is a hardware device and you are using the Microsoft Basic Display Adapter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the method returns <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>,
        /// call <see cref="CloseDeviceHandle"/> to close the handle
        /// and then call <see cref="OpenDeviceHandle"/> again to get a new handle.
        /// The <see cref="ResetDevice"/> method invalidates all open device handles.
        /// </para>
        /// <para>
        /// For more info see, Supporting Direct3D 11 Video Decoding in Media Foundation.
        /// </para>
        /// </remarks>
        public HRESULT GetVideoService([In] HANDLE hDevice, [In] in IID riid, out IntPtr ppService)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, HRESULT>)_vTable[4])
                    (thisPtr, hDevice, riid, out ppService);
            }
        }

        /// <summary>
        /// Gives the caller exclusive access to the Microsoft Direct3D device.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The interface identifier (IID) of the requested interface. The Direct3D device will support the following interfaces:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="ID3D11Device"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D11VideoContext"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="ID3D11VideoDevice"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="ppUnkDevice">
        /// Receives a pointer to the requested interface.
        /// The caller must release the interface.
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
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_DEVICE_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The DXGI Device Manager was not initialized.
        /// The owner of the device must call <see cref="ResetDevice"/>.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_VIDEO_DEVICE_LOCKED"/>
        /// </term>
        /// <term>
        /// The device is locked and <paramref name="fBlock"/> is <see cref="FALSE"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you are done using the Direct3D device, call <see cref="UnlockDevice"/> to unlock the device.
        /// </para>
        /// <para>
        /// If the method returns <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>,
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
        public HRESULT LockDevice([In] HANDLE hDevice, [In] in IID riid, [Out] out IntPtr ppUnkDevice, [In] BOOL fBlock)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, in IID, out IntPtr, BOOL, HRESULT>)_vTable[5])
                    (thisPtr, hDevice, riid, out ppUnkDevice, fBlock);
            }
        }

        /// <summary>
        /// Gets a handle to the Microsoft Direct3D device.
        /// </summary>
        /// <param name="phDevice">
        /// Receives the device handle.
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
        /// <see cref="MF_E_DXGI_DEVICE_NOT_INITIALIZED"/>
        /// </term>
        /// <term>
        /// The DXGI Device Manager was not initialized.
        /// The owner of the device must call <see cref="ResetDevice"/>.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        public HRESULT OpenDeviceHandle([Out] out HANDLE phDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HANDLE, HRESULT>)_vTable[6])(thisPtr, out phDevice);
            }
        }

        /// <summary>
        /// Sets the Microsoft Direct3D device or notifies the device manager that the Direct3D device was reset.
        /// </summary>
        /// <param name="pUnkDevice">
        /// A pointer to the <see cref="IUnknown"/> interface of the DXGI device.
        /// </param>
        /// <param name="resetToken">
        /// The token that was received in the pResetToken parameter of the <see cref="MFCreateDXGIDeviceManager"/> function.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// When you first create the DXGI Device Manager, call this method with a pointer to the Direct3D device.
        /// (The device manager does not create the device; the caller must provide the device pointer initially.)
        /// Also call this method if the Direct3D device becomes lost and you need to reset the device or create a new device.
        /// </para>
        /// <para>
        /// The <paramref name="resetToken"/> parameter ensures that only the component
        /// that originally created the device manager can invalidate the current device.
        /// </para>
        /// <para>
        /// If this method succeeds, all open device handles become invalid.
        /// </para>
        /// <para>
        /// To create a Microsoft Direct3D 11 device, call <see cref="D3D11CreateDevice"/>.
        /// </para>
        /// <para>
        /// The device should be created with the <see cref="D3D11_CREATE_DEVICE_VIDEO_SUPPORT"/> device creation flag
        /// which is defined in the <see cref="D3D11_CREATE_DEVICE_FLAG"/> enumeration.
        /// </para>
        /// <para>
        /// It is recommended that you use multi-thread protection on the device context to prevent deadlock issues
        /// that can sometimes happen when you call or <see cref="ID3D11VideoContext.ReleaseDecoderBuffer"/>.
        /// To set multi-thread protection,
        /// first call <see cref="IUnknown.QueryInterface"/> on <see cref="ID3D11Device"/>
        /// to get an <see cref="ID3D10Multithread"/> pointer.
        /// Then call <see cref="ID3D10Multithread.SetMultithreadProtected"/>, passing in true for bMTProtect.
        /// </para>
        /// </remarks>
        public HRESULT ResetDevice([In] P<IUnknown> pUnkDevice, [In] UINT resetToken)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, UINT, HRESULT>)_vTable[7])(thisPtr, pUnkDevice, resetToken);
            }
        }

        /// <summary>
        /// Tests whether a Microsoft Direct3D device handle is valid.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
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
        /// <see cref="E_HANDLE"/>
        /// </term>
        /// <term>
        /// The specified handle is not a Direct3D device handle.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>
        /// </term>
        /// <term>
        /// The device handle is invalid.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// If the method returns <see cref="MF_E_DXGI_NEW_VIDEO_DEVICE"/>,
        /// call <see cref="CloseDeviceHandle"/> to close the handle
        /// and then call <see cref="OpenDeviceHandle"/> again to get a new handle.
        /// The <see cref="ResetDevice"/> method invalidates all open device handles.
        /// </remarks>
        public HRESULT TestDevice([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[8])(thisPtr, hDevice);
            }
        }

        /// <summary>
        /// Unlocks the Microsoft Direct3D device.
        /// </summary>
        /// <param name="hDevice">
        /// A handle to the Direct3D device.
        /// To get the device handle, call <see cref="OpenDeviceHandle"/>.
        /// </param>
        /// <param name="fSaveState">
        /// Reserved.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Call this method to release the device after calling <see cref="LockDevice"/>.
        /// </remarks>
        public HRESULT UnlockDevice([In] HANDLE hDevice, [In] BOOL fSaveState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, BOOL, HRESULT>)_vTable[9])(thisPtr, hDevice, fSaveState);
            }
        }
    }
}
