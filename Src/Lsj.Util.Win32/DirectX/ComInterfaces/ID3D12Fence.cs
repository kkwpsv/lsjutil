using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.BaseTypes.UINT64;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a fence, an object used for synchronization of the CPU and one or more GPUs.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12fence"/>
    /// </para>
    /// </summary>
    [ComInterface(IID = "0a753dcf-c4d8-4b91-adf6-be5a60d95a76", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12Fence
    {
        nint* _vTable;

        /// <summary>
        /// Gets the current value of the fence.
        /// </summary>
        /// <returns>
        /// Returns the current value of the fence.
        /// If the device has been removed, the return value will be <see cref="UINT64_MAX"/>.
        /// </returns>
        public UINT64 GetCompletedValue()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64>)_vTable[8])(thisPtr);
            }
        }

        /// <summary>
        /// Specifies an event that's raised when the fence reaches a certain value.
        /// </summary>
        /// <param name="Value">
        /// The fence value when the event is to be signaled.
        /// </param>
        /// <param name="hEvent">
        /// A handle to the event object.
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/>
        /// if the kernel components don’t have sufficient memory to store the event in a list.
        /// See Direct3D 12 return codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To specify multiple fences before an event is triggered,
        /// refer to <see cref="ID3D12Device1.SetEventOnMultipleFenceCompletion"/>.
        /// </para>
        /// <para>
        /// If <paramref name="hEvent"/> is a null handle,
        /// then this API will not return until the specified fence value(s) have been reached.
        /// </para>
        /// <para>
        /// This method can be safely called from multiple threads at one time.
        /// </para>
        /// </remarks>
        public HRESULT SetEventOnCompletion([In] UINT64 Value, [In] HANDLE hEvent)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, HANDLE, HRESULT>)_vTable[9])(thisPtr, Value, hEvent);
            }
        }

        /// <summary>
        /// Sets the fence to the specified value.
        /// </summary>
        /// <param name="Value">
        /// The value to set the fence to.
        /// </param>
        /// <returns>
        /// This method returns one of the Direct3D 12 Return Codes.
        /// </returns>
        /// <remarks>
        /// Use this method to set a fence value from the CPU side.
        /// Use <see cref="ID3D12CommandQueue.Signal"/> to set a fence from the GPU side.
        /// </remarks>
        public HRESULT Signal([In] UINT64 Value)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, UINT64, HRESULT>)_vTable[10])(thisPtr, Value);
            }
        }
    }
}
