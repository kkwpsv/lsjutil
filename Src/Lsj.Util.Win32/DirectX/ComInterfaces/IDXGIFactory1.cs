using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.DXGI;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIFactory1"/> interface implements methods for generating DXGI objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgifactory1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
    /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
    /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
    /// </para>
    /// <para>
    /// To create a factory, call the <see cref="CreateDXGIFactory1"/> function.
    /// </para>
    /// <para>
    /// Because you can create a Direct3D device without creating a swap chain,
    /// you might need to retrieve the factory that is used to create the device in order to create a swap chain.
    /// You can request the <see cref="IDXGIDevice"/> or <see cref="IDXGIDevice1"/> interface
    /// from the Direct3D device and then use the <see cref="IDXGIObject.GetParent"/> method to locate the factory.
    /// The following code shows how.
    /// </para>
    /// <code>
    /// IDXGIDevice1 * pDXGIDevice;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice1), (void **)&amp;pDXGIDevice);
    /// 
    /// IDXGIAdapter * pDXGIAdapter;
    /// hr = pDXGIDevice->GetParent(__uuidof(IDXGIAdapter), (void **)&amp;pDXGIAdapter);
    /// 
    /// IDXGIFactory1 * pIDXGIFactory;
    /// pDXGIAdapter->GetParent(__uuidof(IDXGIFactory1), (void **)&amp;pIDXGIFactory);
    /// </code>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "770aae78-f26f-4dba-a829-253c83d1b387", BeginVTableSlotIndex = 12, EndVTableSlotIndex = 13,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIFactory)])]
    public unsafe struct IDXGIFactory1
    {
        nint* _vTable;

        /// <summary>
        /// Enumerates both adapters (video cards) with or without outputs.
        /// </summary>
        /// <param name="Adapter">
        /// The index of the adapter to enumerate.
        /// </param>
        /// <param name="ppAdapter">
        /// The address of a pointer to an <see cref="IDXGIAdapter1"/> interface
        /// at the position specified by the <paramref name="Adapter"/> parameter.
        /// This parameter must not be <see cref="NullRef{T}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful
        /// ; otherwise, returns <see cref="DXGI_ERROR_NOT_FOUND"/>
        /// if the index is greater than or equal to the number of adapters in the local system,
        /// or <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// if <paramref name="ppAdapter"/> parameter is <see cref="NullRef{T}"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// </para>
        /// <para>
        /// When you create a factory, the factory enumerates the set of adapters that are available in the system.
        /// Therefore, if you change the adapters in a system,
        /// you must destroy and recreate the <see cref="IDXGIFactory1"/> object.
        /// The number of adapters in a system changes
        /// when you add or remove a display card, or dock or undock a laptop.
        /// </para>
        /// <para>
        /// When the <see cref="EnumAdapters1"/> method succeeds and fills the <paramref name="ppAdapter"/> parameter
        /// with the address of the pointer to the adapter interface,
        /// <see cref="EnumAdapters1"/> increments the adapter interface's reference count.
        /// When you finish using the adapter interface, 
        /// call the <see cref="IUnknown.Release"/> method to decrement the reference count before you destroy the pointer.
        /// </para>
        /// <para>
        /// <see cref="EnumAdapters1"/> first returns the adapter with the output on which the desktop primary is displayed.
        /// This adapter corresponds with an index of zero.
        /// <see cref="EnumAdapters1"/> next returns other adapters with outputs.
        /// <see cref="EnumAdapters1"/> finally returns adapters without outputs.
        /// </para>
        /// </remarks>
        public HRESULT EnumAdapters1([In] UINT Adapter, [Out] out P<IDXGIAdapter1> ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGIAdapter1>, HRESULT>)_vTable[12])(thisPtr, Adapter, out ppAdapter);
            }
        }

        /// <summary>
        /// Informs an application of the possible need to re-create the factory and re-enumerate adapters.
        /// </summary>
        /// <returns>
        /// <para>
        /// <see cref="FALSE"/>, if a new adapter is becoming available or the current adapter is going away.
        /// <see cref="TRUE"/>, no adapter changes.
        /// </para>
        /// <para>
        /// <see cref="IsCurrent"/> returns <see cref="FALSE"/> to inform the calling application to re-enumerate adapters.
        /// </para>
        /// </returns>
        /// <remarks>
        /// This method is not supported by DXGI 1.0, which shipped in Windows Vista and Windows Server 2008.
        /// DXGI 1.1 support is required, which is available on Windows 7, Windows Server 2008 R2,
        /// and as an update to Windows Vista with Service Pack 2 (SP2) (KB 971644) and Windows Server 2008 (KB 971512).
        /// </remarks>
        public BOOL IsCurrent()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BOOL>)_vTable[13])(thisPtr);
            }
        }
    }
}
