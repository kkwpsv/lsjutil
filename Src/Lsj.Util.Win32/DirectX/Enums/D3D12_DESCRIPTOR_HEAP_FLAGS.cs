using Lsj.Util.Win32.DirectX.ComInterfaces;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies options for a heap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_descriptor_heap_flags"/>
    /// </para>
    /// </summary>
    public enum D3D12_DESCRIPTOR_HEAP_FLAGS
    {
        /// <summary>
        /// Indicates default usage of a heap.
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_FLAG_NONE = 0,

        /// <summary>
        /// <para>
        /// The flag <see cref="D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE"/> can optionally be set
        /// on a descriptor heap to indicate it is be bound on a command list for reference by shaders.
        /// Descriptor heaps created without this flag allow applications the option to stage descriptors in CPU memory
        /// before copying them to a shader visible descriptor heap, as a convenience.
        /// But it is also fine for applications to directly create descriptors into shader visible descriptor heaps
        /// with no requirement to stage anything on the CPU.
        /// </para>
        /// <para>
        /// Descriptor heaps bound via <see cref="ID3D12GraphicsCommandList.SetDescriptorHeaps"/>
        /// must have the <see cref="D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE"/> flag set, else the debug layer will produce an error.
        /// </para>
        /// <para>
        /// Descriptor heaps with the <see cref="D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE"/> flag
        /// can't be used as the source heaps in calls to <see cref="ID3D12Device.CopyDescriptors"/>
        /// or <see cref="ID3D12Device.CopyDescriptorsSimple"/>,
        /// because they could be resident in <c>WRITE_COMBINE</c> memory or GPU-local memory,
        /// which is very inefficient to read from.
        /// </para>
        /// <para>
        /// This flag only applies to CBV/SRV/UAV descriptor heaps, and sampler descriptor heaps.
        /// It does not apply to other descriptor heap types since shaders do not directly reference the other types.
        /// Attempting to create an RTV/DSV heap with <see cref="D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE"/> results in a debug layer error.
        /// </para>
        /// </summary>
        D3D12_DESCRIPTOR_HEAP_FLAG_SHADER_VISIBLE = 0x1
    }
}
