using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies whether conservative rasterization is on or off.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d12/ne-d3d12-d3d12_conservative_rasterization_mode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This enum is used by the <see cref="D3D12_RASTERIZER_DESC"/> structure.
    /// </remarks>
    public enum D3D12_CONSERVATIVE_RASTERIZATION_MODE
    {
        /// <summary>
        /// Conservative rasterization is off.
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_MODE_OFF = 0,

        /// <summary>
        /// Conservative rasterization is on.
        /// </summary>
        D3D12_CONSERVATIVE_RASTERIZATION_MODE_ON = 1
    }
}
