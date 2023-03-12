namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Driver cursor capability flags.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcursorcaps"/>
    /// </para>
    /// </summary>
    public enum D3DCURSORCAPS
    {
        /// <summary>
        /// The driver supports hardware color cursor in at least high resolution modes (height >= 400).
        /// </summary>
        D3DCURSORCAPS_COLOR = 0x00000001,

        /// <summary>
        /// The driver supports hardware color cursor in low resolution modes (height < 400).
        /// </summary>
        D3DCURSORCAPS_LOWRES = 0x00000002,
    }
}
