using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IDXGIAdapter2"/> interface represents a display subsystem, which includes one or more GPUs, DACs, and video memory.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgiadapter2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A display subsystem is often referred to as a video card; however, on some computers, the display subsystem is part of the motherboard.
    /// To enumerate the display subsystems, use <see cref="IDXGIFactory1.EnumAdapters1"/>.
    /// To get an interface to the adapter for a particular device, use <see cref="IDXGIDevice.GetAdapter"/>.
    /// To create a software adapter, use <see cref="IDXGIFactory.CreateSoftwareAdapter"/>.
    /// </remarks>
    public unsafe struct IDXGIAdapter2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 description of an adapter or video card.
        /// This description includes information about the granularity at which the graphics processing unit (GPU)
        /// can be preempted from performing its current task.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to a <see cref="DXGI_ADAPTER_DESC2"/> structure that describes the adapter.
        /// This parameter must not be <see cref="NullRef{DXGI_ADAPTER_DESC2}"/>.
        /// On feature level 9 graphics hardware, earlier versions of <see cref="GetDesc2"/>
        /// (<see cref="IDXGIAdapter.GetDesc"/> and <see cref="IDXGIAdapter1.GetDesc1"/>) return zeros
        /// for the PCI ID in the <see cref="DXGI_ADAPTER_DESC2.VendorId"/>, <see cref="DXGI_ADAPTER_DESC2.DeviceId"/>,
        /// <see cref="DXGI_ADAPTER_DESC2.SubSysId"/>, and <see cref="DXGI_ADAPTER_DESC2.Revision"/> members of the adapter description structure
        /// and “Software Adapter” for the description string in the Description member.
        /// <see cref="GetDesc2"/> returns the actual feature level 9 hardware values in these members.
        /// </param>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful;
        /// otherwise, returns <see cref="E_INVALIDARG"/> if the <paramref name="pDesc"/> parameter is <see cref="NullRef{DXGI_ADAPTER_DESC2}"/>.
        /// </returns>
        /// <remarks>
        /// Use the <see cref="GetDesc2"/> method to get a DXGI 1.2 description of an adapter.
        /// To get a DXGI 1.1 description, use the <see cref="IDXGIAdapter1.GetDesc1"/> method.
        /// To get a DXGI 1.0 description, use the <see cref="IDXGIAdapter.GetDesc"/> method.
        /// The Windows Display Driver Model (WDDM) scheduler can preempt the GPU's execution of application tasks.
        /// The granularity at which the GPU can be preempted from performing its current task in the WDDM 1.1
        /// or earlier driver model is a direct memory access (DMA) buffer for graphics tasks or a compute packet for compute tasks.
        /// The GPU can switch between tasks only after it completes the currently executing unit of work, a DMA buffer or a compute packet.
        /// A DMA buffer is the largest independent unit of graphics work that the WDDM scheduler can submit to the GPU.
        /// This buffer contains a set of GPU instructions that the WDDM driver and GPU use.
        /// A compute packet is the largest independent unit of compute work that the WDDM scheduler can submit to the GPU.
        /// A compute packet contains dispatches (for example, calls to the <see cref="ID3D11DeviceContext.Dispatch"/> method), which contain thread groups.
        /// The WDDM 1.2 or later driver model allows the GPU to be preempted at finer granularity levels than a DMA buffer or compute packet.
        /// You can use the <see cref="GetDesc2"/> method to retrieve the granularity levels for graphics and compute tasks.
        /// </remarks>
        public HRESULT GetDesc2([Out] out DXGI_ADAPTER_DESC2 pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_ADAPTER_DESC2, HRESULT>)_vTable[11])(thisPtr, out pDesc);
            }
        }
    }
}
