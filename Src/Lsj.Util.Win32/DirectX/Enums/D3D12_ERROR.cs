namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// The following are return codes from API functions.
    /// For more return codes, see <see cref="DXGI_ERROR"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d12/d3d12-graphics-reference-returnvalues"/>
    /// </para>
    /// </summary>
    public enum D3D12_ERROR : uint
    {
        /// <summary>
        /// The specified cached PSO was created on a different adapter and cannot be reused on the current adapter.
        /// </summary>
        D3D12_ERROR_ADAPTER_NOT_FOUND = 0x887E0001,

        /// <summary>
        /// The specified cached PSO was created on a different driver version and cannot be reused on the current adapter.
        /// </summary>
        D3D12_ERROR_DRIVER_VERSION_MISMATCH = 0x887E0002,
    }
}
