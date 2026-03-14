using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.DirectX.Enums.D3D_FEATURE_LEVEL;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_BIND_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_FEATURE;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_USAGE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Note
    /// </para>
    /// <para>
    /// This structure is supported by the Direct3D 11.2 runtime, which is available on Windows 8.1 and later operating systems.
    /// </para>
    /// <para>
    /// Describes Direct3D 11.2 feature options in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ns-d3d11-d3d11_feature_data_d3d11_options1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// If the Direct3D API is the Direct3D 11.2 runtime and can support 11.2 features,
    /// <see cref="ID3D11Device.CheckFeatureSupport"/> for <see cref="D3D11_FEATURE_D3D11_OPTIONS1"/>
    /// will return a SUCCESS code when valid parameters are passed.
    /// The members of <see cref="D3D11_FEATURE_DATA_D3D11_OPTIONS1"/> will be set appropriately
    /// based on the system's graphics hardware and graphics driver.
    /// </para>
    /// <para>
    /// Mappable default buffers
    /// </para>
    /// <para>
    /// When creating a default buffer with <see cref="D3D11_CPU_ACCESS_FLAG"/>,
    /// only the <see cref="D3D11_BIND_SHADER_RESOURCE"/> and <see cref="D3D11_BIND_UNORDERED_ACCESS"/> bind flags may be used.
    /// </para>
    /// <para>
    /// The <see cref="D3D11_RESOURCE_MISC_FLAG"/> cannot be used when creating resources with <c>D3D11_CPU_ACCESS</c> flags.
    /// </para>
    /// <para>
    /// On non-unified memory architecture systems (discrete GPUs), apps should not use mappable default buffers
    /// if the compute shader code accesses the same byte in a default buffer more than once -
    /// sending the data across the bus multiple times eliminates the performance
    /// gained by mapping the default buffer instead of copying it.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D11_FEATURE_DATA_D3D11_OPTIONS1
    {
        /// <summary>
        /// Specifies whether the hardware and driver support tiled resources.
        /// The runtime sets this member to a <see cref="D3D11_TILED_RESOURCES_TIER"/>-typed value
        /// that indicates if the hardware and driver support tiled resources and at what tier level.
        /// </summary>
        public D3D11_TILED_RESOURCES_TIER TiledResourcesTier;

        /// <summary>
        /// Specifies whether the hardware and driver support the filtering options (<see cref="D3D11_FILTER"/>)
        /// of comparing the result to the minimum or maximum value during texture sampling.
        /// The runtime sets this member to <see cref="TRUE"/> if the hardware and driver support these filtering options.
        /// </summary>
        public BOOL MinMaxFiltering;

        /// <summary>
        /// Specifies whether the hardware and driver also support the <see cref="ID3D11DeviceContext1.ClearView"/> method on depth formats.
        /// For info about valid depth formats, see <see cref="D3D11_DEPTH_STENCIL_VIEW_DESC"/>.
        /// </summary>
        public BOOL ClearViewAlsoSupportsDepthOnlyFormats;

        /// <summary>
        /// Specifies support for creating <see cref="ID3D11Buffer"/> resources
        /// that can be passed to the <see cref="ID3D11DeviceContext.Map"/> and <see cref="ID3D11DeviceContext.Unmap"/> methods.
        /// This means that the <see cref="D3D11_BUFFER_DESC.CPUAccessFlags"/> member of the <see cref="D3D11_BUFFER_DESC"/> structure
        /// may be set with the desired <see cref="D3D11_CPU_ACCESS_FLAG"/> elements
        /// when the <see cref="D3D11_BUFFER_DESC.Usage"/> member of <see cref="D3D11_BUFFER_DESC"/> is set to <see cref="D3D11_USAGE_DEFAULT"/>.
        /// The runtime sets this member to <see cref="TRUE"/>
        /// if the hardware is capable of at least <see cref="D3D_FEATURE_LEVEL_11_0"/>
        /// and the graphics device driver supports mappable default buffers.
        /// </summary>
        public BOOL MapOnDefaultBuffers;
    }
}
