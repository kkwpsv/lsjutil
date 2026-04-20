using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An interface from which other core interfaces inherit from,
    /// including (but not limited to) <see cref="ID3D12PipelineLibrary"/>, <see cref="ID3D12CommandList"/>,
    /// <see cref="ID3D12Pageable"/>, and <see cref="ID3D12RootSignature"/>.
    /// It provides a method to get back to the device object it was created against.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12devicechild"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "905db94b-a00c-4140-9df5-2b64ca9ea357", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object)])]
    public unsafe struct ID3D12DeviceChild
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets a pointer to the device that created this interface.
        /// </summary>
        /// <param name="riid">
        /// The globally unique identifier (<see cref="GUID"/>) for the device interface.
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the device can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, <c>__uuidof(ID3D12Device)</c> will get the <see cref="GUID"/> of the interface to a device.
        /// </param>
        /// <param name="ppvDevice">
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12Device"/> interface for the device.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// Any returned interfaces have their reference count incremented by one,
        /// so be sure to call <see cref="IUnknown.Release"/> on the returned pointers
        /// before they are freed or else you will have a memory leak.
        /// </remarks>
        public HRESULT GetDevice([In] in GUID riid, [Out] out IntPtr ppvDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in GUID, out IntPtr, HRESULT>)_vTable[7])(thisPtr, riid, out ppvDevice);
            }
        }
    }
}
