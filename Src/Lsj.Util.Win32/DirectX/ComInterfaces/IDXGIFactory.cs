using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIFactory"/> interface implements methods for generating DXGI objects (which handle full screen transitions).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgifactory"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Create a factory by calling <see cref="CreateDXGIFactory"/>.
    /// Because you can create a Direct3D device without creating a swap chain,
    /// you might need to retrieve the factory that is used to create the device in order to create a swap chain.
    /// You can request the <see cref="IDXGIDevice"/> interface from the Direct3D device and then
    /// use the <see cref="IDXGIObject.GetParent"/> method to locate the factory.
    /// The following code shows how.
    /// <code>
    /// IDXGIDevice * pDXGIDevice = nullptr;
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void **)&pDXGIDevice);
    /// 
    /// hr = g_pd3dDevice->QueryInterface(__uuidof(IDXGIDevice), (void **)&pDXGIDevice);
    /// hr = pDXGIDevice->GetAdapter( &pDXGIAdapter );
    /// 
    /// IDXGIFactory * pIDXGIFactory = nullptr;
    /// pDXGIAdapter->GetParent(__uuidof(IDXGIFactory), (void **)&pIDXGIFactory);
    /// </code>
    /// Windows Phone 8: This API is supported.
    /// </remarks>
    public unsafe struct IDXGIFactory
    {
        IntPtr* _vTable;

        /// <summary>
        /// Enumerates the adapters (video cards).
        /// </summary>
        /// <param name="Adapter">
        /// The index of the adapter to enumerate.
        /// </param>
        /// <param name="ppAdapter">
        /// The address of a pointer to an <see cref="IDXGIAdapter"/> interface at the position specified by the <paramref name="Adapter"/> parameter.
        /// This parameter must not be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="DXGI_ERROR_NOT_FOUND"/> if the index is greater than or equal to the number of adapters in the local system,
        /// or <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="ppAdapter"/> parameter is <see cref="NULL"/>..
        /// </returns>
        /// <remarks>
        /// When you create a factory, the factory enumerates the set of adapters that are available in the system.
        /// Therefore, if you change the adapters in a system, you must destroy and recreate the <see cref="IDXGIFactory"/> object.
        /// The number of adapters in a system changes when you add or remove a display card, or dock or undock a laptop.
        /// When the <see cref="EnumAdapters"/> method succeeds and fills the ppAdapter parameter with the address of the pointer to the adapter interface,
        /// <see cref="EnumAdapters"/> increments the adapter interface's reference count.
        /// When you finish using the adapter interface, call the <see cref="IUnknown.Release"/> method to decrement the reference count before you destroy the pointer.
        /// <see cref="EnumAdapters"/> first returns the adapter with the output on which the desktop primary is displayed.
        /// This adapter corresponds with an index of zero.
        /// <see cref="EnumAdapters"/> next returns other adapters with outputs.
        /// <see cref="EnumAdapters"/> finally returns adapters without outputs.
        /// </remarks>
        public HRESULT EnumAdapters([In] UINT Adapter, [Out] out P<IDXGIAdapter> ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT, out P<IDXGIAdapter>, HRESULT>)_vTable[7])(thisPtr, Adapter, out ppAdapter);
            }
        }
    }
}
