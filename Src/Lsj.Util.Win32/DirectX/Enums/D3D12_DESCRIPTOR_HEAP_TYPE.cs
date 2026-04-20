using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies a type of descriptor heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_heap_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the <see cref="D3D12_DESCRIPTOR_HEAP_DESC"/> structure, and the following methods:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CopyDescriptors"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CopyDescriptorsSimple"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.GetDescriptorHandleIncrementSize"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_DESCRIPTOR_HEAP_TYPE
    {
        /// <summary>
        /// The descriptor heap for the combination of constant-buffer, shader-resource, and unordered-access views.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV = 0,

        /// <summary>
        /// The descriptor heap for the sampler.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER = (D3D12_DESCRIPTOR_HEAP_TYPE_CBV_SRV_UAV + 1),

        /// <summary>
        /// The descriptor heap for the render-target view.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_TYPE_RTV = (D3D12_DESCRIPTOR_HEAP_TYPE_SAMPLER + 1),

        /// <summary>
        /// The descriptor heap for the depth-stencil view.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_TYPE_DSV = (D3D12_DESCRIPTOR_HEAP_TYPE_RTV + 1),

        /// <summary>
        /// The number of types of descriptor heaps.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_TYPE_NUM_TYPES = (D3D12_DESCRIPTOR_HEAP_TYPE_DSV + 1)
    }
}
