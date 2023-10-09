namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies whether conservative rasterization is on or off.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_3/ne-d3d11_3-d3d11_conservative_rasterization_mode"/>
    /// </para>
    /// </summary>
    public enum D3D11_CONSERVATIVE_RASTERIZATION_MODE
    {
        /// <summary>
        /// Conservative rasterization is off.
        /// </summary>
        D3D11_CONSERVATIVE_RASTERIZATION_MODE_OFF = 0,

        /// <summary>
        /// Conservative rasterization is on.
        /// </summary>
        D3D11_CONSERVATIVE_RASTERIZATION_MODE_ON = 1,
    }
}
