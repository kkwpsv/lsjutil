using static Lsj.Util.Win32.DirectX.Constants;
using static Lsj.Util.Win32.DirectX.Macros;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies how memory gets routed by a shader resource view (SRV).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_shader_component_mapping"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This enum allows the SRV to select how memory gets routed to the four return components in a shader after a memory fetch.
    /// The options for each shader component [0..3] (corresponding to RGBA) are: component 0..3 from the SRV fetch result or force 0 or force 1.
    /// </para>
    /// <para>
    /// The default 1:1 mapping can be indicated by specifying <see cref="D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING"/>,
    /// otherwise an arbitrary mapping can be specified using the macro <see cref="D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING"/>.
    /// </para>
    /// <para>
    /// See below.
    /// </para>
    /// <para>
    /// Note the following defines.
    /// </para>
    /// <code>
    /// #define D3D12_SHADER_COMPONENT_MAPPING_MASK 0x7
    /// #define D3D12_SHADER_COMPONENT_MAPPING_SHIFT 3
    /// #define D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES \
    ///     (1&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*4))
    /// #define D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(Src0,Src1,Src2,Src3) \
    ///     ((((Src0)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)| \
    ///     (((Src1)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;D3D12_SHADER_COMPONENT_MAPPING_SHIFT)| \
    ///     (((Src2)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*2))| \
    ///     (((Src3)&amp;D3D12_SHADER_COMPONENT_MAPPING_MASK)&lt;&lt;(D3D12_SHADER_COMPONENT_MAPPING_SHIFT*3))| \
    ///     D3D12_SHADER_COMPONENT_MAPPING_ALWAYS_SET_BIT_AVOIDING_ZEROMEM_MISTAKES))
    /// #define D3D12_DECODE_SHADER_4_COMPONENT_MAPPING(ComponentToExtract,Mapping) \
    ///     ((D3D12_SHADER_COMPONENT_MAPPING)(Mapping &gt;&gt; (D3D12_SHADER_COMPONENT_MAPPING_SHIFT*ComponentToExtract) &amp; D3D12_SHADER_COMPONENT_MAPPING_MASK))
    /// #define D3D12_DEFAULT_SHADER_4_COMPONENT_MAPPING D3D12_ENCODE_SHADER_4_COMPONENT_MAPPING(0,1,2,3)
    /// </code>
    /// </remarks>
    public enum D3D12_SHADER_COMPONENT_MAPPING
    {
        /// <summary>
        /// Indicates return component 0 (red).
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_0 = 0,

        /// <summary>
        /// Indicates return component 1 (green).
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_1 = 1,

        /// <summary>
        /// Indicates return component 2 (blue).
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_2 = 2,

        /// <summary>
        /// Indicates return component 3 (alpha).
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FROM_MEMORY_COMPONENT_3 = 3,

        /// <summary>
        /// Indicates forcing the resulting value to 0.
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_0 = 4,

        /// <summary>
        /// Indicates forcing the resulting value 1.
        /// The value of forcing 1 is either 0x1 or 1.0f depending on the format type for that component in the source format.
        /// </summary>
        D3D12_SHADER_COMPONENT_MAPPING_FORCE_VALUE_1 = 5
    }
}
