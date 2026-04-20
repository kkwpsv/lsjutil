using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_STATES;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the type of heap.
    /// When resident, heaps reside in a particular physical memory pool with certain CPU cache properties.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_heap_type"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum is used by the following API items:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_DESC"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_PROPERTIES"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.GetCustomHeapProperties"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The heap types fall into two categories: abstracted heap types, and custom heap types.
    /// </para>
    /// <para>
    /// The following are abstracted heap types:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_TYPE_DEFAULT"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_TYPE_UPLOAD"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_TYPE_READBACK"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The following is a custom heap type:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_TYPE_CUSTOM"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The abstracted heap types (<c>_DEFAULT</c>, <c>_UPLOAD</c>, and <c>_READBACK</c>)
    /// are useful to simplify writing adapter-neutral applications,
    /// because such applications don't need to be aware of the adapter memory architecture.
    /// To use an abstracted heap type to simplify writing adapter-neutral applications,
    /// the application essentially treats the adapter as if it were a discrete or NUMA adapter.
    /// But, using the heap types enables efficient translation for UMA adapters.
    /// Adapter architecture neutral applications should assume there are two memory pools available,
    /// where the pool with the most GPU bandwidth cannot provide CPU access.
    /// The pool with the least GPU bandwidth can have CPU access;
    /// but must be either optimized for upload to GPU or readback from GPU.
    /// </para>
    /// <para>
    /// Note that textures (unlike buffers) can't be heap type <c>UPLOAD</c> or <c>READBACK</c>.
    /// </para>
    /// </remarks>
    public enum D3D12_HEAP_TYPE
    {
        /// <summary>
        /// Specifies the default heap.
        /// This heap type experiences the most bandwidth for the GPU, but cannot provide CPU access.
        /// The GPU can read and write to the memory from this pool, and resource transition barriers may be changed.
        /// The majority of heaps and resources are expected to be located here,
        /// and are typically populated through resources in upload heaps.
        /// </summary>
        D3D12_HEAP_TYPE_DEFAULT = 1,

        /// <summary>
        /// <para>
        /// Specifies a heap used for uploading.
        /// This heap type has CPU access optimized for uploading to the GPU,
        /// but does not experience the maximum amount of bandwidth for the GPU.
        /// This heap type is best for CPU-write-once, GPU-read-once data; but GPU-read-once is stricter than necessary.
        /// GPU-read-once-or-from-cache is an acceptable use-case for the data;
        /// but such usages are hard to judge due to differing GPU cache designs and sizes.
        /// If in doubt, stick to the GPU-read-once definition or profile the difference on many GPUs
        /// between copying the data to a <c>_DEFAULT</c> heap vs. reading the data from an <c>_UPLOAD</c> heap.
        /// </para>
        /// <para>
        /// Resources in this heap must be created with <see cref="D3D12_RESOURCE_STATE_GENERIC_READ"/>
        /// and cannot be changed away from this.
        /// The CPU address for such heaps is commonly not efficient for CPU reads.
        /// </para>
        /// <para>
        /// The following are typical usages for <c>_UPLOAD</c> heaps:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Initializing resources in a <c>_DEFAULT</c> heap with data from the CPU.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Uploading dynamic data in a constant buffer that is read, repeatedly, by each vertex or pixel.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The following are likely not good usages for <c>_UPLOAD</c> heaps:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Re-initializing the contents of a resource every frame.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Uploading constant data which is only used every other Draw call, where each Draw uses a non-trivial amount of other data
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_HEAP_TYPE_UPLOAD = 2,

        /// <summary>
        /// <para>
        /// Specifies a heap used for reading back.
        /// This heap type has CPU access optimized for reading data back from the GPU,
        /// but does not experience the maximum amount of bandwidth for the GPU.
        /// This heap type is best for GPU-write-once, CPU-readable data.
        /// The CPU cache behavior is write-back, which is conducive for multiple sub-cache-line CPU reads.
        /// </para>
        /// <para>
        /// Resources in this heap must be created with <see cref="D3D12_RESOURCE_STATE_COPY_DEST"/>,
        /// and cannot be changed away from this.
        /// </para>
        /// </summary>
        D3D12_HEAP_TYPE_READBACK = 3,

        /// <summary>
        /// <para>
        /// Specifies a custom heap.
        /// The application may specify the memory pool and CPU cache properties directly,
        /// which can be useful for UMA optimizations, multi-engine, multi-adapter, or other special cases.
        /// To do so, the application is expected to understand the adapter architecture to make the right choice.
        /// For more details, see <see cref="D3D12_FEATURE_ARCHITECTURE"/>, <see cref="D3D12_FEATURE_DATA_ARCHITECTURE"/>,
        /// and <see cref="ID3D12Device.GetCustomHeapProperties"/>.
        /// </para>
        /// </summary>
        D3D12_HEAP_TYPE_CUSTOM = 4,

        /// <summary>
        /// 
        /// </summary>
        D3D12_HEAP_TYPE_GPU_UPLOAD = 5
    }
}
