using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Inherited from objects that are tied to the device so that they can retrieve a pointer to it.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgidevicesubobject"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    [ComInterface(IID = "3d3e0379-f9de-4d58-bb6c-18d62992f1a6", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject)])]
    public unsafe struct IDXGIDeviceSubObject
    {
        IntPtr* _vTable;

        /// <summary>
        /// Retrieves the device.
        /// </summary>
        /// <param name="riid">
        /// The reference id for the device.
        /// </param>
        /// <param name="ppDevice">
        /// The address of a pointer to the device.
        /// </param>
        /// <returns>
        /// A code that indicates success or failure (see <see cref="DXGI_ERROR"/>).
        /// </returns>
        /// <remarks>
        /// The type of interface that is returned can be any interface published by the device.
        /// For example, it could be an IDXGIDevice * called pDevice,
        /// and therefore the REFIID would be obtained by calling __uuidof(pDevice).
        /// </remarks>
        public HRESULT GetDevice([In] in IID riid, [Out] out IntPtr ppDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[7])(thisPtr, riid, out ppDevice);
            }
        }
    }
}
