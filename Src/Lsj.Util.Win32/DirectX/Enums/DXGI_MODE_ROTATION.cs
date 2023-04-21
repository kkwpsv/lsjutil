namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Flags that indicate how the back buffers should be rotated to fit the physical rotation of a monitor.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/bb173065(v=vs.85)"/>
    /// </para>
    /// </summary>
    public enum DXGI_MODE_ROTATION
    {
        /// <summary>
        /// Unspecified rotation.
        /// </summary>
        DXGI_MODE_ROTATION_UNSPECIFIED = 0,

        /// <summary>
        /// Specifies no rotation.
        /// </summary>
        DXGI_MODE_ROTATION_IDENTITY = 1,

        /// <summary>
        /// Specifies 90 degrees of rotation.
        /// </summary>
        DXGI_MODE_ROTATION_ROTATE90 = 2,

        /// <summary>
        /// Specifies 180 degrees of rotation.
        /// </summary>
        DXGI_MODE_ROTATION_ROTATE180 = 3,

        /// <summary>
        /// Specifies 270 degrees of rotation.
        /// </summary>
        DXGI_MODE_ROTATION_ROTATE270 = 4
    }
}
