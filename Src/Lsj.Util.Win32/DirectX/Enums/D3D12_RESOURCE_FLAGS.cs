using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_STATES;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_LAYOUT;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_VIDEO_DECODE_CONFIGURATION_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_VIDEO_DECODE_TIER;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that specify options for working with resources.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_resource_flags"/>
    /// </para>
    /// </summary>
    public enum D3D12_RESOURCE_FLAGS
    {
        /// <summary>
        /// No options are specified.
        /// </summary>
        D3D12_RESOURCE_FLAG_NONE = 0,

        /// <summary>
        /// <para>
        /// Allows a render target view to be created for the resource;
        /// and also enables the resource to transition into the state of <see cref="D3D12_RESOURCE_STATE_RENDER_TARGET"/>.
        /// Some adapter architectures allocate extra memory for textures with this flag
        /// to reduce the effective bandwidth during common rendering.
        /// This characteristic may not be beneficial for textures that are never rendered to,
        /// nor is it available for textures compressed with BC formats.
        /// Your application should avoid setting this flag when rendering will never occur.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Either the texture format must support render target capabilities at the current feature level.
        /// Or, when the format is a typeless format, a format within the same typeless group
        /// must support render target capabilities at the current feature level.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be set in conjunction with textures that have <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/>
        /// when <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossAdapterRowMajorTextureSupported"/> is <see cref="FALSE"/>,
        /// nor in conjunction with textures that have <see cref="D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE"/>
        /// when <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.StandardSwizzle64KBSupported"/> is <see cref="FALSE"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with 4KB alignment, <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>,
        /// nor usage with heaps that have <see cref="D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET = 0x1,

        /// <summary>
        /// <para>
        /// Allows a depth stencil view to be created for the resource,
        /// as well as enables the resource to transition into the state of <see cref="D3D12_RESOURCE_STATE_DEPTH_WRITE"/>
        /// and/or <see cref="D3D12_RESOURCE_STATE_DEPTH_READ"/>.
        /// Most adapter architectures allocate extra memory for textures with this flag to reduce the effective bandwidth,
        /// and maximize optimizations for early depth-test.
        /// Your application should avoid setting this flag when depth operations will never occur.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Either the texture format must support depth stencil capabilities at the current feature level.
        /// Or, when the format is a typeless format, a format within the same typeless group
        /// must support depth stencil capabilities at the current feature level.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>, 4KB alignment, 
        /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>, <see cref="D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS"/>,
        /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS"/>, <see cref="D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE"/>,
        /// <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/>, nor used with heaps
        /// that have <see cref="D3D12_HEAP_FLAG_DENY_RT_DS_TEXTURES"/> or <see cref="D3D12_HEAP_FLAG_ALLOW_DISPLAY"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Precludes usage of <see cref="ID3D12Resource.WriteToSubresource"/>
        /// and <see cref="ID3D12Resource.ReadFromSubresource"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Precludes GPU copying of a subregion.
        /// <see cref="ID3D12GraphicsCommandList.CopyTextureRegion"/> must copy a whole subresource to or from resources with this flag.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL = 0x2,

        /// <summary>
        /// <para>
        /// Allows an unordered access view to be created for the resource,
        /// as well as enables the resource to transition into the state of <see cref="D3D12_RESOURCE_STATE_UNORDERED_ACCESS"/>.
        /// Some adapter architectures must resort to less efficient texture layouts in order to provide this functionality.
        /// If a texture is rarely used for unordered access,
        /// then it might be worth having two textures around and copying between them.
        /// One texture would have this flag, while the other wouldn't.
        /// Your application should avoid setting this flag when unordered access operations will never occur.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Either the texture format must support unordered access capabilities at the current feature level.
        /// Or, when the format is a typeless format, a format within the same typeless group
        /// must support unordered access capabilities at the current feature level.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be set in conjunction with textures that have <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/>
        /// when <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.CrossAdapterRowMajorTextureSupported"/> is <see cref="FALSE"/>,
        /// nor in conjunction with textures that have <see cref="D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE"/>
        /// when <see cref="D3D12_FEATURE_DATA_D3D12_OPTIONS.StandardSwizzle64KBSupported"/> is <see cref="FALSE"/>,
        /// nor when the feature level is less than 11.0.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with MSAA textures.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS = 0x4,

        /// <summary>
        /// <para>
        /// Disallows a shader resource view from being created for the resource,
        /// as well as disables the resource from transitioning into the state of
        /// <see cref="D3D12_RESOURCE_STATE_NON_PIXEL_SHADER_RESOURCE"/> or <see cref="D3D12_RESOURCE_STATE_PIXEL_SHADER_RESOURCE"/>.
        /// Some adapter architectures gain bandwidth capacity for depth stencil textures when shader resource views are precluded.
        /// If a texture is rarely used for shader resources,
        /// then it might be worth having two textures around and copying between them.
        /// One texture would have this flag, while the other wouldn't.
        /// Your application should set this flag when depth stencil textures will never be used from shader resource views.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Must be used with <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_DENY_SHADER_RESOURCE = 0x8,

        /// <summary>
        /// <para>
        /// Allows the resource to be used for cross-adapter data,
        /// as well as those features enabled by <see cref="D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS"/>.
        /// Cross-adapter resources commonly preclude techniques that reduce effective texture bandwidth during usage,
        /// and some adapter architectures might require different caching behavior.
        /// Your application should avoid setting this flag when the resource data will never be used with another adapter.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Must be used with heaps that have <see cref="D3D12_HEAP_FLAG_SHARED_CROSS_ADAPTER"/>.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with heaps that have <see cref="D3D12_HEAP_FLAG_ALLOW_DISPLAY"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER = 0x10,

        /// <summary>
        /// <para>
        /// Allows a resource to be simultaneously accessed by multiple different queues, devices, or processes
        /// (for example, allows a resource to be used with <see cref="ID3D12GraphicsCommandList.ResourceBarrier"/> transitions
        /// performed in more than one command list executing at the same time).
        /// </para>
        /// <para>
        /// Simultaneous access allows multiple readers and one writer,
        /// as long as the writer doesn't concurrently modify the texels that other readers are accessing.
        /// Some adapter architectures can't leverage techniques to reduce effective texture bandwidth during usage.
        /// </para>
        /// <para>
        /// However, your application should avoid setting this flag
        /// when multiple readers are not required during frequent, non-overlapping writes to textures.
        /// Use of this flag can compromise resource fences to perform waits,
        /// and prevent any compression being used with a resource.
        /// </para>
        /// <para>
        /// The following restrictions and interactions apply:
        /// </para>
        /// <para>
        /// 
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// Can't be used with <see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>;
        /// but buffers always have the properties represented by this flag.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with MSAA textures.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Can't be used with <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/>.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS = 0x20,

        /// <summary>
        /// <para>
        /// Specfies that this resource may be used only as a decode reference frame.
        /// It may be written to or read only by the video decode operation.
        /// </para>
        /// <para>
        /// <see cref="D3D12_VIDEO_DECODE_TIER_1"/> and <see cref="D3D12_VIDEO_DECODE_TIER_2"/> may
        /// report <see cref="D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED"/>
        /// in the <see cref="D3D12_FEATURE_DATA_VIDEO_DECODE_SUPPORT"/> structure configuration flag.
        /// If that happens, then your application must allocate reference frames
        /// with the <see cref="D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY"/> resource flag.
        /// </para>
        /// <para>
        /// <see cref="D3D12_VIDEO_DECODE_TIER_3"/> must not set
        /// the <see cref="D3D12_VIDEO_DECODE_CONFIGURATION_FLAG_REFERENCE_ONLY_ALLOCATIONS_REQUIRED"/> configuration flag,
        /// and must not require the use of this resource flag.
        /// </para>
        /// </summary>
        D3D12_RESOURCE_FLAG_VIDEO_DECODE_REFERENCE_ONLY = 0x40,

        /// <summary>
        /// Specfies that this resource may be used only as an encode reference frame.
        /// It may be written to or read only by the video encode operation.
        /// </summary>
        D3D12_RESOURCE_FLAG_VIDEO_ENCODE_REFERENCE_ONLY = 0x80,

        /// <summary>
        /// Requires the DirectX 12 Agility SDK 1.608.0 or later.
        /// Indicates that a buffer is to be used as a raytracing acceleration structure.
        /// When using D3D12 Enhanced Barriers, this flag serves as a replacement
        /// for <see cref="D3D12_RESOURCE_STATE_RAYTRACING_ACCELERATION_STRUCTURE"/>, since buffers no longer have layouts/states.
        /// Requires <see cref="D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS"/> to be set.
        /// </summary>
        D3D12_RESOURCE_FLAG_RAYTRACING_ACCELERATION_STRUCTURE = 0x100
    }
}
