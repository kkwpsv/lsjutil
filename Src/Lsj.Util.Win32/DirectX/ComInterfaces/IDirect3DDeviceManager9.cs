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
    /// For the DirectShow EVR filter, call <see cref="GetService"/> on the filter's pins.
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

        public HRESULT ResetDevice([In] P<IDirect3DDevice9> pDevice, [In] UINT resetToken)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDirect3DDevice9>, UINT, HRESULT>)_vTable[3])(thisPtr, pDevice, resetToken);
            }
        }

        public HRESULT OpenDeviceHandle([Out] out HANDLE phDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out HANDLE, HRESULT>)_vTable[4])(thisPtr, out phDevice);
            }
        }

        public HRESULT CloseDeviceHandle([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[5])(thisPtr, hDevice);
            }
        }

        public HRESULT TestDevice([In] HANDLE hDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, HRESULT>)_vTable[6])(thisPtr, hDevice);
            }
        }

        public HRESULT LockDevice([In] HANDLE hDevice, [Out] out P<IDirect3DDevice9> ppDevice, [In] BOOL fBlock)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, out P<IDirect3DDevice9>, BOOL, HRESULT>)_vTable[7])
                    (thisPtr, hDevice, out ppDevice, fBlock);
            }
        }

        public HRESULT UnlockDevice([In] HANDLE hDevice, [In] BOOL fSaveState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HANDLE, BOOL, HRESULT>)_vTable[8])(thisPtr, hDevice, fSaveState);
            }
        }

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
