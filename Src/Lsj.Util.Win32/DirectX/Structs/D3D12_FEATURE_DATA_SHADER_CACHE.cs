using Lsj.Util.Win32.DirectX.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.DirectX.Enums.D3D12_FEATURE;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the level of shader caching supported in the current graphics driver.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ns-d3d12-d3d12_feature_data_shader_cache"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this structure with <see cref="ID3D12Device.CheckFeatureSupport"/>
    /// to determine the level of support offered for the optional shader-caching features.
    /// </para>
    /// <para>
    /// See the enumeration constant <see cref="D3D12_FEATURE_SHADER_CACHE"/> in the <see cref="D3D12_FEATURE"/> enumeration.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D3D12_FEATURE_DATA_SHADER_CACHE
    {
        /// <summary>
        /// Indicates the level of caching supported.
        /// </summary>
        public D3D12_SHADER_CACHE_SUPPORT_FLAGS SupportFlags;
    }
}
