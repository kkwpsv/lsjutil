using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a GPU descriptor handle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_gpu_descriptor_handle"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is returned by <see cref="ID3D12DescriptorHeap.GetGPUDescriptorHandleForHeapStart"/>.
    /// </para>
    /// <para>
    /// This structure is passed into the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewFloat"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.ClearUnorderedAccessViewUint"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.SetComputeRootDescriptorTable"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12GraphicsCommandList.SetGraphicsRootDescriptorTable"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// To get the handle increment size use <see cref="ID3D12Device.GetDescriptorHandleIncrementSize"/>
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_GPU_DESCRIPTOR_HANDLE
    {
        /// <summary>
        /// The address of the descriptor.
        /// </summary>
        public UINT64 ptr;
    }
}
