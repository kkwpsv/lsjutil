using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.DirectX.D3D12;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a virtual adapter.
    /// This interface extends <see cref="ID3D12Device1"/> to create pipeline state objects from pipeline state stream descriptions.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This interface was introduced in Windows 10 Creators Update.
    /// Applications targetting Windows 10 Creators Update should use this interface instead of earlier or later versions.
    /// Applications targetting an earlier or later version of Windows 10
    /// should use the appropriate version of the <see cref="ID3D12Device"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/nn-d3d12-id3d12device1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Use <see cref="D3D12CreateDevice"/> to create a device.
    /// </remarks>
    [ComInterface(IID = "30baa41e-b15b-475c-a0bb-1af5c5b64328", BeginVTableSlotIndex = 47, EndVTableSlotIndex = 47,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID3D12Object), typeof(ID3D12Device), typeof(ID3D12Device1)])]
    public unsafe struct ID3D12Device2
    {
        IntPtr* _vTable;

        /// <summary>
        /// Creates a pipeline state object from a pipeline state stream description.
        /// </summary>
        /// <param name="pDesc">
        /// The address of a <see cref="D3D12_PIPELINE_STATE_STREAM_DESC"/> structure that describes the pipeline state.
        /// </param>
        /// <param name="riid">
        /// <para>
        /// The globally unique identifier (<see cref="GUID"/>) for the pipeline state interface (<see cref="ID3D12PipelineState"/>).
        /// </para>
        /// <para>
        /// The <c>REFIID</c>, or <see cref="GUID"/>, of the interface to the pipeline state
        /// can be obtained by using the <c>__uuidof()</c> macro.
        /// For example, __uuidof(ID3D12PipelineState) will get the <see cref="GUID"/> of the interface to a pipeline state.
        /// </para>
        /// </param>
        /// <param name="ppPipelineState">
        /// <para>
        /// A pointer to a memory block that receives a pointer to the <see cref="ID3D12PipelineState"/> interface for the pipeline state object.
        /// </para>
        /// <para>
        /// The pipeline state object is an immutable state object. It contains no methods.
        /// </para>
        /// </param>
        /// <returns>
        /// This method returns <see cref="E_OUTOFMEMORY"/> if there is insufficient memory to create the pipeline state object.
        /// See Direct3D 12 Return Codes for other possible return values.
        /// </returns>
        /// <remarks>
        /// This function takes the pipeline description as a <see cref="D3D12_PIPELINE_STATE_STREAM_DESC"/>
        /// and combines the functionality of the <see cref="ID3D12Device.CreateGraphicsPipelineState"/>
        /// and <see cref="ID3D12Device.CreateComputePipelineState"/> functions,
        /// which take their pipeline description as the less-flexible <see cref="D3D12_GRAPHICS_PIPELINE_STATE_DESC"/>
        /// and <see cref="D3D12_COMPUTE_PIPELINE_STATE_DESC"/> structs, respectively.
        /// </remarks>
        public HRESULT CreatePipelineState([In] in D3D12_PIPELINE_STATE_STREAM_DESC pDesc, [In] in IID riid, [Out] out IntPtr ppPipelineState)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in D3D12_PIPELINE_STATE_STREAM_DESC, in IID, out IntPtr, HRESULT>)_vTable[47])
                    (thisPtr, pDesc, riid, out ppPipelineState);
            }
        }
    }
}
