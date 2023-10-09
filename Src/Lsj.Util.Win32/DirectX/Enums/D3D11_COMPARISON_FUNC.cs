using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Comparison options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11/ne-d3d11-d3d11_comparison_func"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A comparison option determines whether how the runtime compares source (new) data against destination (existing) data before storing the new data.
    /// The comparison option is declared in a description before an object is created.
    /// The API allows you to set a comparison option for a depth-stencil buffer (see <see cref="D3D11_DEPTH_STENCIL_DESC"/>),
    /// depth-stencil operations (see <see cref="D3D11_DEPTH_STENCILOP_DESC"/>), or sampler state (see <see cref="D3D11_SAMPLER_DESC"/>).
    /// </remarks>
    public enum D3D11_COMPARISON_FUNC
    {
        /// <summary>
        /// Never pass the comparison.
        /// </summary>
        D3D11_COMPARISON_NEVER = 1,

        /// <summary>
        /// If the source data is less than the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_LESS = 2,

        /// <summary>
        /// If the source data is equal to the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_EQUAL = 3,

        /// <summary>
        /// If the source data is equal to the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_LESS_EQUAL = 4,

        /// <summary>
        /// If the source data is greater than the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_GREATER = 5,

        /// <summary>
        /// If the source data is not equal to the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_NOT_EQUAL = 6,

        /// <summary>
        /// If the source data is greater than or equal to the destination data, the comparison passes.
        /// </summary>
        D3D11_COMPARISON_GREATER_EQUAL = 7,

        /// <summary>
        /// Always pass the comparison.
        /// </summary>
        D3D11_COMPARISON_ALWAYS = 8,
    }
}
