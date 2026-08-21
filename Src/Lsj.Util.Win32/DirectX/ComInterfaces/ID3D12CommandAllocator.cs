using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents the allocations of storage for graphics processing unit (GPU) commands.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12commandallocator"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="ID3D12Device.CreateCommandAllocator"/> to create a command allocator object.
    /// </para>
    /// <para>
    /// The command allocator object corresponds to the underlying allocations in which GPU commands are stored.
    /// The command allocator object applies to both direct command lists and bundles.
    /// You must use a command allocator object in a DirectX 12 app.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "6102dee4-af59-4b09-b999-b44d73f09b24", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 8,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild), typeof(ID3D12Pageable)])]
    public unsafe struct ID3D12CommandAllocator
    {
        nint* _vTable;

        /// <summary>
        /// Indicates to re-use the memory that is associated with the command allocator.
        /// </summary>
        /// <returns>
        /// <para>
        /// This method returns <see cref="E_FAIL"/>
        /// if there is an actively recording command list referencing the command allocator.
        /// The debug layer will also issue an error in this case.
        /// </para>
        /// <para>
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Your app calls <see cref="Reset"/> to re-use the memory that is associated with a command allocator.
        /// From this call to <see cref="Reset"/>, the runtime and driver assume
        /// that the graphics processing unit (GPU) is no longer executing any command lists
        /// that have recorded commands with the command allocator.
        /// So you should ensure that you don't call <see cref="Reset"/>
        /// until the GPU is done executing command lists associated with the allocator.
        /// </para>
        /// <para>
        /// It's undefined behavior to call <see cref="Reset"/> on a command allocator
        /// while it has a command list still being executed.
        /// </para>
        /// <para>
        /// The debug layer will issue a warning if it can't prove tha
        /// t there are no pending GPU references to command lists that have recorded commands in the allocator.
        /// </para>
        /// <para>
        /// The debug layer will issue an error if <see cref="Reset"/> is called concurrently by multiple threads (on the same allocator object).
        /// </para>
        /// </remarks>
        public HRESULT Reset()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[8])(thisPtr);
            }
        }
    }
}
