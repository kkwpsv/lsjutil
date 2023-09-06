using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_4/nn-dxgi1_4-idxgifactory4"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIFactory4
    {
        IntPtr* _vTable;

        /// <summary>
        /// Outputs the <see cref="IDXGIAdapter"/> for the specified LUID.
        /// </summary>
        /// <param name="AdapterLuid">
        /// A unique value that identifies the adapter.
        /// See LUID for a definition of the structure. LUID is defined in dxgi.h.
        /// </param>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIAdapter"/> object referenced by the <paramref name="ppAdapter"/> parameter.
        /// </param>
        /// <param name="ppAdapter">
        /// The address of an <see cref="IDXGIAdapter"/> interface pointer to the adapter.
        /// This parameter must not be <see cref="NullRef{IntPtr}"/>.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful; an error code otherwise.
        /// For a list of error codes, see <see cref="DXGI_ERROR"/>.
        /// See also Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// For Direct3D 12, it's no longer possible to backtrack from a device to the <see cref="IDXGIAdapter"/> that was used to create it.
        /// <see cref="EnumAdapterByLuid"/> enables an app to retrieve information about the adapter where a D3D12 device was created.
        /// <see cref="EnumAdapterByLuid"/> is designed to be paired with <see cref="ID3D12Device.GetAdapterLuid"/>.
        /// For more information, see DXGI 1.4 Improvements.
        /// </remarks>
        public HRESULT EnumAdapterByLuid([In] LUID AdapterLuid, [In] in IID riid, [Out] out IntPtr ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, LUID, in IID, out IntPtr, HRESULT>)_vTable[26])(thisPtr, AdapterLuid, riid, out ppAdapter);
            }
        }

        /// <summary>
        /// Provides an adapter which can be provided to <see cref="D3D12CreateDevice"/> to use the WARP renderer.
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (GUID) of the <see cref="IDXGIAdapter"/> object referenced by the <paramref name="ppAdapter"/> parameter.
        /// </param>
        /// <param name="ppAdapter"></param>
        /// <returns></returns>
        public HRESULT EnumWarpAdapter([In] in IID riid, [Out] out IntPtr ppAdapter)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out IntPtr, HRESULT>)_vTable[27])(thisPtr, riid, out ppAdapter);
            }
        }
    }
}
