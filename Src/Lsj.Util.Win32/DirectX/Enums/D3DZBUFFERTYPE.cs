using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe depth-buffer formats.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dzbuffertype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Members of this enumerated type are used with the <see cref="D3DRS_ZENABLE"/> render state.
    /// </remarks>
    public enum D3DZBUFFERTYPE
    {
        /// <summary>
        /// Disable depth buffering.
        /// </summary>
        D3DZB_FALSE = 0,

        /// <summary>
        /// Enable z-buffering.
        /// </summary>
        D3DZB_TRUE = 1,

        /// <summary>
        /// Enable w-buffering.
        /// </summary>
        D3DZB_USEW = 2,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DZB_FORCE_DWORD = 0x7fffffff
    }
}
