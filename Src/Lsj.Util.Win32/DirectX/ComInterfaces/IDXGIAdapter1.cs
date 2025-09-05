using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIAdapter1"/> interface represents a display sub-system
    /// (including one or more GPU's, DACs and video memory).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgiadapter1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
    /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
    /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
    /// </para>
    /// <para>
    /// A display sub-system is often referred to as a video card,
    /// however, on some machines the display sub-system is part of the mother board.
    /// </para>
    /// <para>
    /// To enumerate the display sub-systems, use <see cref="IDXGIFactory1.EnumAdapters1"/>.
    /// To get an interface to the adapter for a particular device, use <see cref="IDXGIDevice.GetAdapter"/>.
    /// To create a software adapter, use <see cref="IDXGIFactory.CreateSoftwareAdapter"/>.
    /// </para>
    /// <para>
    /// Windows Phone 8: This API is supported.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "29038f61-3839-4626-91fd-086879011a05", BeginVTableSlotIndex = 10, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIAdapter)])]
    public unsafe struct IDXGIAdapter1
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets a DXGI 1.1 description of an adapter (or video card).
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_ADAPTER_DESC1"/> structure that describes the adapter.
        /// This parameter must not be <see cref="NullRef{DXGI_ADAPTER_DESC1}"/>.
        /// On feature level 9 graphics hardware, <see cref="GetDesc1"/> returns zeros
        /// for the PCI ID in the <see cref="DXGI_ADAPTER_DESC1.VendorId"/>,
        /// <see cref="DXGI_ADAPTER_DESC1.DeviceId"/>, <see cref="DXGI_ADAPTER_DESC1.SubSysId"/>,
        /// and <see cref="DXGI_ADAPTER_DESC1.Revision"/> members of <see cref="DXGI_ADAPTER_DESC1"/>
        /// and “Software Adapter” for the description string
        /// in the <see cref="DXGI_ADAPTER_DESC1.Description"/> member.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="E_INVALIDARG"/>
        /// if the <paramref name="pDesc"/> parameter is <see cref="NullRef{DXGI_ADAPTER_DESC1}"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// </para>
        /// <para>
        /// Use the <see cref="GetDesc1"/> method to get a DXGI 1.1 description of an adapter.
        /// To get a DXGI 1.0 description, use the <see cref="IDXGIAdapter"/> method.
        /// </para>
        /// </remarks>
        public HRESULT GetDesc1([Out] out DXGI_ADAPTER_DESC1 pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_ADAPTER_DESC1, HRESULT>)_vTable[10])(thisPtr, out pDesc);
            }
        }
    }
}
