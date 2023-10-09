namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Identifies how to check multisample quality levels.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d3d11_2/ne-d3d11_2-d3d11_check_multisample_quality_levels_flag"/>
    /// </para>
    /// </summary>
    public enum D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_FLAG
    {
        /// <summary>
        /// Indicates to check the multisample quality levels of a tiled resource.
        /// </summary>
        D3D11_CHECK_MULTISAMPLE_QUALITY_LEVELS_TILED_RESOURCE = 0x01,
    }
}
