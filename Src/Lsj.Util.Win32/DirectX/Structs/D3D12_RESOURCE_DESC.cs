using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_HEAP_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_DIMENSION;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_RESOURCE_FLAGS;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_TEXTURE_LAYOUT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Constants;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes a resource, such as a texture.
    /// This structure is used extensively.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_resource_desc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure with:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID3D12Resource.GetDesc"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.GetResourceAllocationInfo"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateCommittedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreatePlacedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.CreateReservedResource"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID3D12Device.GetCopyableFootprints"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// A number of the helper functions, refer to Helper Structures and Functions for D3D12.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// Two common resources are buffers and textures, which both use this structure, but with quite different uses of the fields.
    /// </para>
    /// <para>
    /// Buffers
    /// </para>
    /// <para>
    /// Buffers are a contiguous memory region.
    /// <see cref="Width"/> may be between 1 and
    /// either the <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT.MaxGPUVirtualAddressBitsPerResource"/> field
    /// of <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT"/> for reserved resources
    /// or the <see cref="D3D12_FEATURE_DATA_GPU_VIRTUAL_ADDRESS_SUPPORT.MaxGPUVirtualAddressBitsPerProcess"/> field for committed resources.
    /// However, exhaustion of GPU virtual address space, memory residency budget
    /// (see <see cref="IDXGIAdapter3.QueryVideoMemoryInfo"/>),
    /// and or system memory may easily occur first.
    /// </para>
    /// <para>
    /// <see cref="Alignment"/> must be 64KB (<see cref="D3D12_DEFAULT_RESOURCE_PLACEMENT_ALIGNMENT"/>) or 0, which is effectively 64KB.
    /// </para>
    /// <para>
    /// <see cref="Height"/>, <see cref="DepthOrArraySize"/>, and <see cref="MipLevels"/> must be 1.
    /// </para>
    /// <para>
    /// <see cref="Format"/> must be <see cref="DXGI_FORMAT_UNKNOWN"/>.
    /// </para>
    /// <para>
    /// <c>SampleDesc.Count</c> must be 1 and <see cref="DXGI_SAMPLE_DESC.Quality"/> must be 0.
    /// </para>
    /// <para>
    /// <see cref="Layout"/> must be <see cref="D3D12_TEXTURE_LAYOUT_ROW_MAJOR"/>,
    /// as buffer memory layouts are understood by applications and row-major texture data is commonly marshaled through buffers.
    /// </para>
    /// <para>
    /// <see cref="Flags"/> must still be accurately filled out by applications for buffers, with minor exceptions.
    /// However, applications can use the most amount of capability support without concern about the efficiency impact on buffers.
    /// The flags field is meant to control properties related to textures.
    /// </para>
    /// <para>
    /// Textures
    /// </para>
    /// <para>
    /// Textures are a multi-dimensional arrangement of texels in a contiguous region of memory,
    /// heavily optimized to maximize bandwidth for rendering and sampling.
    /// Texture sizes are hard to predict and vary from adapter to adapter.
    /// Applications must use <see cref="ID3D12Device.GetResourceAllocationInfo"/> to accurately understand their size.
    /// </para>
    /// <para>
    /// <c>TEXTURE1D</c>, <c>TEXTURE2D</c>, and <c>TEXTURE3D</c> are not supported orthogonally on every format.
    /// See the use of <see cref="D3D12_FORMAT_SUPPORT1.D3D12_FORMAT_SUPPORT1_TEXTURE1D"/>,
    /// <see cref="D3D12_FORMAT_SUPPORT1.D3D12_FORMAT_SUPPORT1_TEXTURE2D"/>,
    /// and <see cref="D3D12_FORMAT_SUPPORT1.D3D12_FORMAT_SUPPORT1_TEXTURE3D"/> in <see cref="D3D12_FORMAT_SUPPORT1"/>.
    /// </para>
    /// <para>
    /// <see cref="Width"/>, <see cref="Height"/>, and <see cref="DepthOrArraySize"/> must be
    /// between 1 and the maximum dimension supported for the particular feature level and texture dimension.
    /// However, exhaustion of GPU virtual address space,
    /// memory residency budget (see <see cref="IDXGIAdapter3.QueryVideoMemoryInfo"/>),
    /// and or system memory may easily occur first.
    /// For compressed formats, these dimensions are logical.
    /// For example:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <para>
    /// For <c>TEXTURE1D</c>:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="Width"/> must be less than or equal to <see cref="D3D10_REQ_TEXTURE1D_U_DIMENSION"/> on feature levels less than 11_0
    /// and <see cref="D3D11_REQ_TEXTURE1D_U_DIMENSION"/> on feature level 11_0 or greater.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="Height"/> must be 1.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DepthOrArraySize"/> is interpreted as array size
    /// and must be less than or equal to <see cref="D3D10_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION"/> on feature levels less than 11_0
    /// and <see cref="D3D11_REQ_TEXTURE1D_ARRAY_AXIS_DIMENSION"/> on feature levels 11_0 or greater.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <para>
    /// For <c>TEXTURE2D</c>:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="Width"/> and <see cref="Height"/> must be
    /// less than or equal to <see cref="D3D10_REQ_TEXTURE2D_U_OR_V_DIMENSION"/> on feature levels less than 11_0
    /// and <see cref="D3D11_REQ_TEXTURE2D_U_OR_V_DIMENSION"/> or feature level 11_0 or greater.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DepthOrArraySize"/> is interpreted as array size
    /// and must be less than or equal to <see cref="D3D10_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION"/> on feature levels less than 11_0
    /// and <see cref="D3D11_REQ_TEXTURE2D_ARRAY_AXIS_DIMENSION"/> on feature levels 11_0 or greater.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <para>
    /// For <c>TEXTURE3D</c>:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="Width"/> and <see cref="Height"/> and <see cref="DepthOrArraySize"/> must be
    /// less than or equal to <see cref="D3D10_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> on feature levels less than 11_0
    /// and <see cref="D3D11_REQ_TEXTURE3D_U_V_OR_W_DIMENSION"/> on feature level 11_0 or greater.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="DepthOrArraySize"/> is interpreted as depth.
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// The following notes are for all texture sizes.
    /// </para>
    /// <para>
    /// Alignment
    /// </para>
    /// <para>
    /// <see cref="Alignment"/> may be one of 0, 4KB, 64KB or 4MB.
    /// </para>
    /// <para>
    /// If <see cref="Alignment"/> is set to 0, the runtime will use 4MB for MSAA textures and 64KB for everything else.
    /// The application may choose smaller alignments than these defaults for a couple of texture types when the texture is small.
    /// Textures with UNKNOWN layout and MSAA may be created with 64KB alignment
    /// (if they pass the small size restriction detailed below).
    /// </para>
    /// <para>
    /// Textures with UNKNOWN layout without MSAA and without render-target nor depth-stencil flags
    /// may be created with 4KB Alignment (again, passing the small size restriction).
    /// </para>
    /// <para>
    /// Applications can create smaller aligned resources
    /// when the estimated size of the most-detailed mip level is a total of the larger alignment restriction or less.
    /// The runtime will use an architecture-independent mechanism of size-estimation,
    /// that mimics the way standard swizzle and D3D12 tiled resources are sized.
    /// However, the tile sizes will be of the smaller alignment restriction for such calculations.
    /// Using the non-render-target and non-depth-stencil texture as an example,
    /// the runtime will assume near-equilateral tile shapes of 4KB,
    /// and calculate the number of tiles needed for the most-detailed mip level.
    /// If the number of tiles is equal to or less than 16, then the application can create a 4KB aligned resource.
    /// So, a mipped tex2d array of any array size and any number of mip levels can be 4KB,
    /// as long as the width and height are small enough for the particular format and MSAA.
    /// </para>
    /// <para>
    /// MipLevels
    /// </para>
    /// <para>
    /// <see cref="MipLevels"/> may be 0, or 1 to the maximum mip levels
    /// supported by the <see cref="Width"/>, <see cref="Height"/> , and <see cref="DepthOrArraySize"/> dimensions.
    /// When 0 is used, the API will automatically calculate the maximum mip levels supported and use that.
    /// But, some resource and heap properties preclude mip levels, so the app must specify the value as 1.
    /// </para>
    /// <para>
    /// Refer to the <see cref="D3D12_FORMAT_SUPPORT1.D3D12_FORMAT_SUPPORT1_MIP"/> field
    /// of <see cref="D3D12_FORMAT_SUPPORT1"/> for per-format restrictions.
    /// MSAA resources, textures with <see cref="D3D12_RESOURCE_FLAG_ALLOW_CROSS_ADAPTER"/>,
    /// and heaps with <see cref="D3D12_HEAP_FLAG_ALLOW_DISPLAY"/> all preclude mip levels.
    /// </para>
    /// <para>
    /// Format
    /// </para>
    /// <para>
    /// <see cref="Format"/> must be a valid format supported at the feature level of the device.
    /// </para>
    /// <para>
    /// SampleDesc
    /// </para>
    /// <para>
    /// A <c>SampleDesc.Count</c> greater than 1 and/ or non-zero <see cref="DXGI_SAMPLE_DESC.Quality"/>
    /// are only supported for <c>TEXTURE2D</c> and when either <see cref="D3D12_RESOURCE_FLAG_ALLOW_RENDER_TARGET"/>
    /// or <see cref="D3D12_RESOURCE_FLAG_ALLOW_DEPTH_STENCIL"/> are set.
    /// </para>
    /// <para>
    /// The following are unsupported:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="D3D12_TEXTURE_LAYOUT_64KB_STANDARD_SWIZZLE"/>,
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_UNORDERED_ACCESS"/>,
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_RESOURCE_FLAG_ALLOW_SIMULTANEOUS_ACCESS"/>,
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="D3D12_HEAP_FLAG_ALLOW_DISPLAY"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// See <see cref="D3D12_FEATURE_DATA_MULTISAMPLE_QUALITY_LEVELS"/> for determining
    /// valid <see cref="DXGI_SAMPLE_DESC.Count"/> and <see cref="DXGI_SAMPLE_DESC.Quality"/> values.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_RESOURCE_DESC
    {
        /// <summary>
        /// One member of <see cref="D3D12_RESOURCE_DIMENSION"/>,
        /// specifying the dimensions of the resource (for example, <see cref="D3D12_RESOURCE_DIMENSION_TEXTURE1D"/>),
        /// or whether it is a buffer ((<see cref="D3D12_RESOURCE_DIMENSION_BUFFER"/>).
        /// </summary>
        public D3D12_RESOURCE_DIMENSION Dimension;

        /// <summary>
        /// Specifies the alignment.
        /// </summary>
        public UINT64 Alignment;

        /// <summary>
        /// Specifies the width of the resource.
        /// </summary>
        public UINT64 Width;

        /// <summary>
        /// Specifies the height of the resource.
        /// </summary>
        public UINT Height;

        /// <summary>
        /// Specifies the depth of the resource, if it is 3D,
        /// or the array size if it is an array of 1D or 2D resources.
        /// </summary>
        public UINT16 DepthOrArraySize;

        /// <summary>
        /// Specifies the number of MIP levels.
        /// </summary>
        public UINT16 MipLevels;

        /// <summary>
        /// Specifies one member of <see cref="DXGI_FORMAT"/>.
        /// </summary>
        public DXGI_FORMAT Format;

        /// <summary>
        /// Specifies a <see cref="DXGI_SAMPLE_DESC"/> structure.
        /// </summary>
        public DXGI_SAMPLE_DESC SampleDesc;

        /// <summary>
        /// Specifies one member of <see cref="D3D12_TEXTURE_LAYOUT"/>.
        /// </summary>
        public D3D12_TEXTURE_LAYOUT Layout;

        /// <summary>
        /// Bitwise-OR'd flags, as <see cref="D3D12_RESOURCE_FLAGS"/> enumeration constants.
        /// </summary>
        public D3D12_RESOURCE_FLAGS Flags;
    }
}
