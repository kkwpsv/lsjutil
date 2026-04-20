using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Specifies comparison options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_comparison_func"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A comparison option determines how the runtime compares source (new) data against destination (existing) data before storing the new data.
    /// The comparison option is declared in a description before an object is created.
    /// The API allows you to set a comparison option for
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// a depth-stencil buffer (<see cref="D3D12_DEPTH_STENCIL_DESC"/>)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// depth-stencil operations (<see cref="D3D12_DEPTH_STENCILOP_DESC"/>)
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// sampler state (<see cref="D3D12_SAMPLER_DESC"/>)
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// </remarks>
    public enum D3D12_COMPARISON_FUNC
    {
        /// <summary>
        /// 
        /// </summary>
        D3D12_COMPARISON_FUNC_NONE = 0,

        /// <summary>
        /// Never pass the comparison.
        /// </summary>
        D3D12_COMPARISON_FUNC_NEVER = 1,

        /// <summary>
        /// If the source data is less than the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_LESS = 2,

        /// <summary>
        /// If the source data is equal to the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_EQUAL = 3,

        /// <summary>
        /// If the source data is less than or equal to the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_LESS_EQUAL = 4,

        /// <summary>
        /// If the source data is greater than the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_GREATER = 5,

        /// <summary>
        /// If the source data is not equal to the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_NOT_EQUAL = 6,

        /// <summary>
        /// If the source data is greater than or equal to the destination data, the comparison passes.
        /// </summary>
        D3D12_COMPARISON_FUNC_GREATER_EQUAL = 7,

        /// <summary>
        /// Always pass the comparison.
        /// </summary>
        D3D12_COMPARISON_FUNC_ALWAYS = 8
    }
}
