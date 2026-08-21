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
    /// This interface represents a display subsystem, and extends this family of interfaces to expose a method
    /// to check for an adapter's compatibility with Arbitrary Code Guard (ACG).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgiadapter4"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For more details, refer to the Residency section of the D3D12 documentation.
    /// </remarks>
    [ComInterface(IID = "3c8d99d1-4fbf-4181-a82c-af66bf7bd24e", BeginVTableSlotIndex = 18, EndVTableSlotIndex = 18,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIAdapter), typeof(IDXGIAdapter1), typeof(IDXGIAdapter2), typeof(IDXGIAdapter3)])]
    public unsafe struct IDXGIAdapter4
    {
        nint* _vTable;

        /// <summary>
        /// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.6 description of an adapter or video card.
        /// This description includes information about ACG compatibility.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_ADAPTER_DESC3"/> structure that describes the adapter.
        /// This parameter must not be <see cref="NullRef{DXGI_ADAPTER_DESC3}"/>.
        /// On feature level 9 graphics hardware, early versions of <see cref="GetDesc3"/> 
        /// (<see cref = "IDXGIAdapter.GetDesc" /> and <see cref="IDXGIAdapter1.GetDesc1"/>) return zeros
        /// for the PCI ID in the <see cref="DXGI_ADAPTER_DESC3.VendorId"/>,
        /// <see cref="DXGI_ADAPTER_DESC3.DeviceId"/>, <see cref="DXGI_ADAPTER_DESC3.SubSysId"/>,
        /// and <see cref="DXGI_ADAPTER_DESC3.Revision"/> members of the adapter description structure
        /// and “Software Adapter” for the description string in the <see cref="DXGI_ADAPTER_DESC3.Description"/> member.
        /// <see cref="GetDesc3"/> and <see cref="IDXGIAdapter2.GetDesc2"/> returns
        /// the actual feature level 9 hardware values in these members.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="E_INVALIDARG"/> if the <paramref name="pDesc"/> parameter is <see cref="NullRef{DXGI_ADAPTER_DESC3}"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use the <see cref="GetDesc3"/> method to get a DXGI 1.6 description of an adapter.
        /// To get a DXGI 1.2 description, use the <see cref="IDXGIAdapter2.GetDesc2"/> method.
        /// To get a DXGI 1.1 description, use the <see cref="IDXGIAdapter1.GetDesc1"/> method.
        /// To get a DXGI 1.0 description, use the <see cref="IDXGIAdapter.GetDesc"/> method.
        /// </para>
        /// <para>
        /// The Windows Display Driver Model (WDDM) scheduler can preempt
        /// the graphics processing unit (GPU)'s execution of application tasks.
        /// The granularity at which the GPU can be preempted from performing its current task
        /// in the WDDM 1.1 or earlier driver model is a direct memory access (DMA) buffer
        /// for graphics tasks or a compute packet for compute tasks.
        /// The GPU can switch between tasks only after it completes the currently executing unit of work,
        /// a DMA buffer or a compute packet.
        /// </para>
        /// <para>
        /// A DMA buffer is the largest independent unit of graphics work that the WDDM scheduler can submit to the GPU.
        /// This buffer contains a set of GPU instructions that the WDDM driver and GPU use.
        /// A compute packet is the largest independent unit of compute work
        /// that the WDDM scheduler can submit to the GPU.
        /// A compute packet contains dispatches
        /// (for example, calls to the <see cref="ID3D11DeviceContext.Dispatch"/> method), which contain thread groups.
        /// The WDDM 1.2 or later driver model allows the GPU to be preempted
        /// at finer granularity levels than a DMA buffer or compute packet.
        /// You can use the <see cref="GetDesc3"/> or <see cref="IDXGIAdapter2.GetDesc2"/> methods
        /// to retrieve the granularity levels for graphics and compute tasks.
        /// </para>
        /// </remarks>
        public HRESULT GetDesc3([Out] out DXGI_ADAPTER_DESC3 pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_ADAPTER_DESC3, HRESULT>)_vTable[18])(thisPtr, out pDesc);
            }
        }
    }
}
