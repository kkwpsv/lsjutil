using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CPU_PAGE_PROPERTY;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_CROSS_NODE_SHARING_TIER;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FORMAT_SUPPORT1;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_TYPE;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_LAYOUT;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies heap options, such as whether the heap can contain textures, and whether resources are shared across adapters.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_heap_flags"/>
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
    /// <see cref="ID3D12Device.CreateHeap"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommittedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_DESC"/> structure
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The following heap flags must be used with <see cref="ID3D12Device.CreateHeap"/>,
    /// but will be set automatically for implicit heaps created by <see cref="ID3D12Device.CreateCommittedResource"/>.
    /// Adapters that only support heap tier 1 must set two out of the three following flags.
    /// </para>
    /// <para>
    /// <list type="table">
    /// <listheader>
    /// <term>
    /// Value
    /// </term>
    /// <term>
    /// Description
    /// </term>
    /// </listheader>
    /// <item>
    /// <term>
    /// <see cref="D3D12_HEAP_FLAG_DENY_BUFFERS"/>
    /// </term>
    /// <term>
    /// The heap isn't allowed to contain resources with <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>
    /// (which is a <see cref="D3D12_RESOURCE_DIMENSION"/> enumeration constant).
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES"/>
    /// </term>
    /// <term>
    /// The heap isn't allowed to contain resources with <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/>,
    /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE2D"/>, or <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE3D"/>
    /// together with either <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/> or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>.
    /// (The latter two items are <see cref="D3D12_RESOURCE_FLAGS"/> enumeration constants.)
    /// </term>
    /// </item>
    /// <item>
    /// <term>
    /// <see cref="D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES"/>
    /// </term>
    /// <term>
    /// The heap isn't allowed to contain resources with <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/>,
    /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE2D"/>, or <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE3D"/>
    /// unless <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/> and <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> are absent.
    /// </term>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Aliases
    /// </para>
    /// <para>
    /// Adapters that support heap tier 2 or greater are additionally allowed to set none of the above flags.
    /// Aliases for these flags are available for applications that prefer thinking only of which resources are supported.
    /// </para>
    /// <para>
    /// The following aliases exist, so be careful when doing bit-manipulations:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_FLAG_ALLOW_ALL_BUFFERS_AND_TEXTURES"/> = 0 and is only supported on heap tier 2 and greater.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS"/> =
    /// <c>D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES | D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</c>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES"/> =
    /// <c>D3D12_HEAP_FLAG_DENY_BUFFERS | D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES</c>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES"/> =
    /// <c> D3D12_HEAP_FLAG_DENY_BUFFERS | D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES</c>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Displayable heaps
    /// </para>
    /// <para>
    /// Displayable heaps are most commonly created by the swapchain for presentation, to enable scanning out to a monitor.
    /// </para>
    /// <para>
    /// Displayable heaps are specified with the <see cref="D3D12_HEAP_FLAG_ALLOW_DISPLAY"/> member of the <see cref="D3D12_HEAP_FLAGS"/> enum.
    /// </para>
    /// <para>
    /// Applications may create displayable heaps outside of a swapchain; but cannot actually present with them.
    /// This flag is not supported by <see cref="ID3D12Device.CreateHeap"/>
    /// and can only be used with <see cref="ID3D12Device.CreateCommittedResource"/> with D3D12_HEAP_TYPE_DEFAULT.
    /// </para>
    /// <para>
    /// Additional restrictions to the <see cref="D3D12_RESOURCE_DESC"/> apply to the resource created with displayable heaps.
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The format must not only be supported by the device, but must be supported for scan-out.
    /// Refer to the use of the <see cref="D3D12_FORMAT_SUPPORT1_DISPLAY"/> member of <see cref="D3D12_FORMAT_SUPPORT1"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.Dimension"/> must be <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE2D"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.Alignment"/> must be 0.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.DepthOrArraySize"/> may be either 1 or 2.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.MipLevels"/> must be 1.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.SampleDesc"/> must have <see cref="DXGI_SAMPLE_DESC.Count"/> set to 1
    /// and <see cref="DXGI_SAMPLE_DESC.Quality"/> set to 0.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_DESC.Layout"/> must be <see cref="D3D12_TEXTURE_LAYOUT_UNKNOWN"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> and <see cref="D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER"/> are invalid flags.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    [Flags]
    public enum D3D12_HEAP_FLAGS
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        D3D12_HEAP_FLAG_NONE = 0,

        /// <summary>
        /// The heap is shared. Refer to Shared Heaps.
        /// </summary>
        D3D12_HEAP_FLAG_SHARED = 0x1,

        /// <summary>
        /// The heap isn't allowed to contain buffers.
        /// </summary>
        D3D12_HEAP_FLAG_DENY_BUFFERS = 0x4,

        /// <summary>
        /// The heap is allowed to contain swap-chain surfaces.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_DISPLAY = 0x8,

        /// <summary>
        /// The heap is allowed to share resources across adapters.
        /// Refer to Shared Heaps.
        /// A protected session cannot be mixed with resources that are shared across adapters.
        /// </summary>
        D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER = 0x20,

        /// <summary>
        /// The heap is not allowed to store Render Target (RT) and/or Depth-Stencil (DS) textures.
        /// </summary>
        D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES = 0x40,

        /// <summary>
        /// The heap is not allowed to contain resources with <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/>,
        /// <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE2D"/>, or <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE3D"/>
        /// unless either <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>
        /// or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> are present.
        /// Refer to <see cref="D3D12_RESOURCE_DIMENSION"/> and <see cref="D3D12_RESOURCE_FLAGS"/>.
        /// </summary>
        D3D12_HEAP_FLAG_DENY_NON_RT_DS_TEXTURES = 0x80,

        /// <summary>
        /// Unsupported. Do not use.
        /// </summary>
        D3D12_HEAP_FLAG_HARDWARE_PROTECTED = 0x100,

        /// <summary>
        /// The heap supports MEM_WRITE_WATCH functionality,
        /// which causes the system to track the pages that are written to in the committed memory region.
        /// This flag can't be combined with the <see cref="D3D12_HEAP_TYPE_DEFAULT"/>
        /// or <see cref="D3D12_CPU_PAGE_PROPERTY_UNKNOWN"/> flags.
        /// Applications are discouraged from using this flag themselves
        /// because it prevents tools from using this functionality.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_WRITE_WATCH = 0x200,

        /// <summary>
        /// <para>
        /// Ensures that atomic operations will be atomic on this heap's memory, according to components able to see the memory.
        /// </para>
        /// <para>
        /// Creating a heap with this flag will fail under either of these conditions.
        /// </para>
        /// <para>
        /// - The heap type is <see cref="D3D12_HEAP_TYPE_DEFAULT"/>, and the heap can be visible on multiple nodes,
        /// but the device does not support <see cref="D3D12_CROSS_NODE_SHARING_TIER_3"/>.
        /// </para>
        /// <para>
        /// - The heap is CPU-visible, but the heap type is not <see cref="D3D12_HEAP_TYPE_CUSTOM"/>.
        /// </para>
        /// <para>
        /// Note that heaps with this flag might be a limited resource on some systems.
        /// </para>
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_SHADER_ATOMICS = 0x400,

        /// <summary>
        /// <para>
        /// The heap is created in a non-resident state and must be made resident
        /// using <see cref="ID3D12Device.MakeResident"/> or <see cref="ID3D12Device3.EnqueueMakeResident"/>.
        /// </para>
        /// <para>
        /// By default, the final step of heap creation is to make the heap resident,
        /// so this flag skips this step and allows the application to decide when to do so.
        /// </para>
        /// </summary>
        D3D12_HEAP_FLAG_CREATE_NOT_RESIDENT = 0x800,

        /// <summary>
        /// Allows the OS to not zero the heap created.
        /// By default, committed resources and heaps are almost always zeroed upon creation.
        /// This flag allows this to be elided in some scenarios.
        /// However, it doesn't guarantee it.
        /// For example, memory coming from other processes still needs to be zeroed for data protection and process isolation.
        /// This can lower the overhead of creating the heap.
        /// </summary>
        D3D12_HEAP_FLAG_CREATE_NOT_ZEROED = 0x1000,

        /// <summary>
        /// 
        /// </summary>
        D3D12_HEAP_FLAG_TOOLS_USE_MANUAL_WRITE_TRACKING = 0x2000,

        /// <summary>
        /// The heap is allowed to store all types of buffers and/or textures.
        /// This is an alias; for more details, see "Aliases" in the Remarks section.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_ALL_BUFFERS_AND_TEXTURES = 0,

        /// <summary>
        /// The heap is only allowed to store buffers.
        /// This is an alias; for more details, see "Aliases" in the Remarks section.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_ONLY_BUFFERS = 0xc0,

        /// <summary>
        /// The heap is only allowed to store non-RT, non-DS textures.
        /// This is an alias; for more details, see "Aliases" in the Remarks section.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_ONLY_NON_RT_DS_TEXTURES = 0x44,

        /// <summary>
        /// The heap is only allowed to store RT and/or DS textures.
        /// This is an alias; for more details, see "Aliases" in the Remarks section.
        /// </summary>
        D3D12_HEAP_FLAG_ALLOW_ONLY_RT_DS_TEXTURES = 0x84
    }
}
