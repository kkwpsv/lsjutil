using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents the state of all currently set shaders as well as certain fixed function state objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12pipelinestate"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use <see cref="ID3D12Device.CreateGraphicsPipelineState"/> or <see cref="ID3D12Device.CreateComputePipelineState"/>
    /// to create a pipeline state object (PSO).
    /// </para>
    /// <para>
    /// A pipeline state object corresponds to a significant portion of the state of the graphics processing unit (GPU).
    /// This state includes all currently set shaders and certain fixed function state objects.
    /// The only way to change states contained within the pipeline object is to change the currently bound pipeline object.
    /// </para>
    /// </remarks>
    [ComInterface(IID = "765a30f3-f624-4c6f-a828-ace948622445", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 8,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12DeviceChild)])]
    public unsafe struct ID3D12PipelineState
    {
        nint* _vTable;

        /// <summary>
        /// Gets the cached blob representing the pipeline state.
        /// </summary>
        /// <param name="ppBlob">
        /// After this method returns, points to the cached blob representing the pipeline state.
        /// </param>
        /// <returns>
        /// Refer to the remarks for <see cref="D3D12_CACHED_PIPELINE_STATE"/>.
        /// </returns>
        public HRESULT GetCachedBlob([Out] out P<ID3DBlob> ppBlob)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ID3DBlob>, HRESULT>)_vTable[8])(thisPtr, out ppBlob);
            }
        }
    }
}
