namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines whether the current tessellation mode is discrete or continuous.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dpatchedgestyle"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note that continuous tessellation produces a completely different tessellation pattern
    /// from the discrete one for the same tessellation values (this is more apparent in wireframe mode).
    /// Thus, 4.0 continuous is not the same as 4 discrete.
    /// </remarks>
    public enum D3DPATCHEDGESTYLE
    {
        /// <summary>
        /// Discrete edge style.
        /// In discrete mode, you can specify float tessellation but it will be truncated to integers.
        /// </summary>
        D3DPATCHEDGE_DISCRETE = 0,

        /// <summary>
        /// Continuous edge style.
        /// In continuous mode, tessellation is specified as float values that can be smoothly varied to reduce "popping" artifacts.
        /// </summary>
        D3DPATCHEDGE_CONTINUOUS = 1,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DPATCHEDGE_FORCE_DWORD = 0x7fffffff,
    }
}
