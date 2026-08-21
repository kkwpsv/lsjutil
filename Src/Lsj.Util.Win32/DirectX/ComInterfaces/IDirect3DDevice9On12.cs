using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The D3D 9on12 Device interface is exposed with methods for unwrapping and returning a translation layer resource.
    /// Call <see cref="IUnknown.QueryInterface"/> on the D3D9 device to retrieve this interface.
    /// If the D3D9 device is not a 9on12 device, <see cref="IUnknown.QueryInterface"/> will fail with <see cref="E_NOINTERFACE"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://microsoft.github.io/DirectX-Specs/d3d/TranslationLayerResourceInterop.html"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "e7fda234-b589-4049-940d-8878977531c8", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 5, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDirect3DDevice9On12
    {
        nint* _vTable;

        /// <summary>
        /// GetD3D12Device
        /// </summary>
        /// <param name="riid">
        /// The interface ID of the D3D12 device.
        /// Example: __uuidof(ID3D12Device)
        /// </param>
        /// <param name="ppvDevice">
        /// On return, the underlying D3D12 device pointer.
        /// </param>
        /// <returns></returns>
        public HRESULT GetD3D12Device([In] in IID riid, [Out] out nint ppvDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in IID, out nint, HRESULT>)_vTable[3])(thisPtr, riid, out ppvDevice);
            }
        }

        /// <summary>
        /// Checks out the underlying D3D12 resource from the translation layer.
        /// </summary>
        /// <param name="pResource9">
        /// The D3D9 resource to unwrap.
        /// </param>
        /// <param name="pCommandQueue">
        /// This queue has waits scheduled for any pending work on the resource being unwrapped.
        /// </param>
        /// <param name="riid">
        /// The interface id for a D3D12 resource, such as __uuidof(ID3D12Resource).
        /// </param>
        /// <param name="ppvResource12">
        /// On return, the D3D12 resource pointer.
        /// </param>
        /// <returns></returns>
        public HRESULT UnwrapUnderlyingResource([In] P<IDirect3DResource9> pResource9, [In] P<ID3D12CommandQueue> pCommandQueue,
            [In] in IID riid, [Out] out nint ppvResource12)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDirect3DResource9>, P<ID3D12CommandQueue>, in IID, out nint, HRESULT>)_vTable[4])
                    (thisPtr, pResource9, pCommandQueue, riid, out ppvResource12);
            }
        }

        /// <summary>
        /// Returns the underlying D3D12 resource from the translation layer.
        /// </summary>
        /// <param name="pResource9">
        /// The D3D9 resource to return.
        /// </param>
        /// <param name="NumSync">
        /// The count of the <paramref name="pSignalValues"/> and <paramref name="ppFences"/> parallel arrays.
        /// </param>
        /// <param name="pSignalValues">
        /// The list of values that will be signaled once any caller scheduled work is completed.
        /// </param>
        /// <param name="ppFences">
        /// The list of fences that will be signaled once any caller schedule work is completed.
        /// </param>
        /// <returns></returns>
        public HRESULT ReturnUnderlyingResource([In] P<IDirect3DResource9> pResource9, [In] UINT NumSync, [In] UINT64[] pSignalValues, [In] P<ID3D12Fence>[] ppFences)
        {
            fixed (UINT64* pSignalValuesPtr = pSignalValues)
            {
                fixed (P<ID3D12Fence>* ppFencesPtr = ppFences)
                {
                    fixed (void* thisPtr = &this)
                    {
                        return ((delegate* unmanaged[Stdcall]<void*, P<IDirect3DResource9>, UINT, UINT64*, P<ID3D12Fence>*, HRESULT>)_vTable[5])
                            (thisPtr, pResource9, NumSync, pSignalValuesPtr, ppFencesPtr);
                    }
                }
            }

        }
    }
}
