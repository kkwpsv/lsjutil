using Lsj.Util.Win32.DirectX.Structs;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_MAP;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies expected resource use during rendering.
    /// The usage directly reflects whether a resource is accessible by the CPU and/or the graphics processing unit (GPU).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_usage"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An application identifies the way a resource is intended to be used (its usage) in a resource description.
    /// There are several structures for creating resources including:
    /// <see cref="D3D11_TEXTURE1D_DESC"/>, <see cref="D3D11_TEXTURE2D_DESC"/>,
    /// <see cref="D3D11_TEXTURE3D_DESC"/>, and <see cref="D3D11_BUFFER_DESC"/>.
    /// </para>
    /// <para>
    /// Differences between Direct3D 9 and Direct3D 10/11:
    /// </para>
    /// <para>
    /// In Direct3D 9, you specify the type of memory a resource should be created in at resource creation time (using <see cref="D3DPOOL"/>).
    /// It was an application's job to decide what memory pool would provide the best combination of functionality and performance.
    /// </para>
    /// <para>
    /// In Direct3D 10/11, an application no longer specifies what type of memory (the pool) to create a resource in.
    /// Instead, you specify the intended usage of the resource, and let the runtime (in concert with the driver and a memory manager)
    /// choose the type of memory that will achieve the best performance.
    /// </para>
    /// <para>
    /// Resource Usage Restrictions
    /// </para>
    /// <para>
    /// Each usage dictates a tradeoff between accessibility for the CPU and accessibility for the GPU.
    /// In general, higher-performance access for one of these two processors means lower-performance access for the other.
    /// At either extreme are the <see cref="D3D11_USAGE_DEFAULT"/> and <see cref="D3D11_USAGE_STAGING"/> usages.
    /// <see cref="D3D11_USAGE_DEFAULT"/> restricts access almost entirely to the GPU.
    /// <see cref="D3D11_USAGE_STAGING"/> restricts access almost entirely to the CPU
    /// and allows only a data transfer (copy) of a resource between the GPU and the CPU.
    /// You can perform these copy operations via the <see cref="ID3D11DeviceContext.CopySubresourceRegion"/>
    /// and <see cref="ID3D11DeviceContext.CopyResource"/> methods.
    /// You can also use these copy methods to copy data between two resources of the same usage.
    /// You can also use the <see cref="ID3D11DeviceContext.UpdateSubresource"/> method
    /// to copy memory directly from a CPU-supplied pointer to any resource,
    /// most usefully a resource with <see cref="D3D11_USAGE_DEFAULT"/>.
    /// </para>
    /// <para>
    /// <see cref="D3D11_USAGE_DYNAMIC"/> usage is a special case that optimizes the flow of data from CPU to GPU
    /// when the CPU generates that data on-the-fly and sends that data with high frequency.
    /// <see cref="D3D11_USAGE_DYNAMIC"/> is typically used on resources with vertex data and on constant buffers.
    /// Use the <see cref="ID3D11DeviceContext.Map"/> and <see cref="ID3D11DeviceContext.Unmap"/> methods to write data to these resources.
    /// To achieve the highest performance for data consumed serially, like vertex data,
    /// use the <see cref="D3D11_MAP_WRITE_NO_OVERWRITE"/> and <see cref="D3D11_MAP_WRITE_DISCARD"/> sequence.
    /// For more info about this sequence, see Common Usage of D3D11_MAP_WRITE_DISCARD with D3D11_MAP_WRITE_NO_OVERWRITE.
    /// </para>
    /// <para>
    /// <see cref="D3D11_USAGE_IMMUTABLE"/> usage is another special case that causes the GPU to generate data just once when you create a resource.
    /// <see cref="D3D11_USAGE_IMMUTABLE"/> is well-suited to data such as textures because such data is typically read into memory from some file format. 
    /// Therefore, when you create a texture with <see cref="D3D11_USAGE_IMMUTABLE"/>, the GPU directly reads that texture into memory.
    /// </para>
    /// <para>
    /// Use the following table to choose the usage that best describes how the resource will need to be accessed by the CPU and/or the GPU.
    /// Of course, there will be performance tradeoffs.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Resource Usage
    /// </term>
    /// <term>
    /// Default
    /// </term>
    /// <term>
    /// Dynamic
    /// </term>
    /// <term>
    /// Immutable
    /// </term>
    /// <term>
    /// Staging
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// GPU-Read
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// yes¹
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// GPU-Write
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// yes¹
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// CPU-Read
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// yes¹
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// CPU-Write
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// yes¹
    /// </term>
    /// </item>
    /// </list>
    /// <para>
    /// 1 - GPU read or write of a resource with the <see cref="D3D11_USAGE_STAGING"/> usage is restricted to copy operations.
    /// You use <see cref="ID3D11DeviceContext.CopySubresourceRegion"/> and <see cref="ID3D11DeviceContext.CopyResource"/> for these copy operations.
    /// Also, because depth-stencil formats and multisample layouts are implementation details of a particular GPU design,
    /// the operating system can’t expose these formats and layouts to the CPU in general.
    /// Therefore, staging resources can't be a depth-stencil buffer or a multisampled render target.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// You can technically use <see cref="ID3D11DeviceContext.UpdateSubresource"/>
    /// to copy to a resource with any usage except <see cref="D3D11_USAGE_IMMUTABLE"/>.
    /// However, we recommend to use <see cref="ID3D11DeviceContext.UpdateSubresource"/>
    /// to update only a resource with <see cref="D3D11_USAGE_DEFAULT"/>.
    /// We recommend to use <see cref="ID3D11DeviceContext.Map"/> and <see cref="ID3D11DeviceContext.Unmap"/>
    /// to update resources with <see cref="D3D11_USAGE_DYNAMIC"/>
    /// because that is the specific purpose of <see cref="D3D11_USAGE_DYNAMIC"/> resources, and is therefore the most optimized path.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para> 
    /// <see cref="D3D11_USAGE_DYNAMIC"/> resources consume specific hardware capabilities. Therefore, use them sparingly.
    /// The display driver typically allocates memory for <see cref="D3D11_USAGE_DYNAMIC"/> resources
    /// with a caching algorithm that favors CPU writes and hinders CPU reads.
    /// Furthermore, the memory behind <see cref="D3D11_USAGE_DYNAMIC"/> resources
    /// might not even be the same for successive calls to <see cref="ID3D11DeviceContext.Map"/>.
    /// Therefore, do not expect high performance or even consistent CPU reads from <see cref="D3D11_USAGE_DYNAMIC"/> resources.
    /// </para>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// <see cref="ID3D11DeviceContext.CopyStructureCount"/> is a special case of GPU-to-CPU copy.
    /// Use <see cref="ID3D11DeviceContext.CopyStructureCount"/> only with unordered access views (UAVs) of buffers. 
    /// </para>
    /// <para>
    /// Resource Bind Options
    /// </para>
    /// <para>
    /// To maximize performance, not all resource usage options can be used as input or output resources to the pipeline.
    /// This table identifies these limitations.
    /// </para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Resource Can Be Bound As
    /// </term>
    /// <term>
    /// Default
    /// </term>
    /// <term>
    /// Dynamic
    /// </term>
    /// <term>
    /// Immutable
    /// </term>
    /// <term>
    /// Staging
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// Input to a Stage
    /// </term>
    /// <term>
    /// yes²
    /// </term>
    /// <term>
    /// yes³
    /// </term>
    /// <term>
    /// yes
    /// </term>
    /// <term>
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// Output from a Stage
    /// </term>
    /// <term>
    /// yes²
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// </term>
    /// <term>
    /// </term>
    /// </item>
    /// </list>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// 2 - If bound as an input and an output using different views, each view must use different subresources.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// 3 - The resource can only be created with a single subresource.
    /// The resource cannot be a texture array. The resource cannot be a mipmap chain.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public enum D3D11_USAGE
    {
        /// <summary>
        /// A resource that requires read and write access by the GPU.
        /// This is likely to be the most common usage choice.
        /// </summary>
        D3D11_USAGE_DEFAULT = 0,

        /// <summary>
        /// A resource that can only be read by the GPU.
        /// It cannot be written by the GPU, and cannot be accessed at all by the CPU.
        /// This type of resource must be initialized when it is created, since it cannot be changed after creation.
        /// </summary>
        D3D11_USAGE_IMMUTABLE = 1,

        /// <summary>
        /// A resource that is accessible by both the GPU (read only) and the CPU (write only).
        /// A dynamic resource is a good choice for a resource that will be updated by the CPU at least once per frame.
        /// To update a dynamic resource, use a Map method.
        /// For info about how to use dynamic resources, see How to: Use dynamic resources.
        /// </summary>
        D3D11_USAGE_DYNAMIC = 2,

        /// <summary>
        /// A resource that supports data transfer (copy) from the GPU to the CPU.
        /// </summary>
        D3D11_USAGE_STAGING = 3,
    }
}
