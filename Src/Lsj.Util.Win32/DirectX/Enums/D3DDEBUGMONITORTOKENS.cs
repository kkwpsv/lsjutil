using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the debug monitor tokens.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddebugmonitortokens"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumerated type are used by the <see cref="D3DRS_DEBUGMONITORTOKEN"/> render state and are only relevant for debug builds.
    /// </remarks>
    public enum D3DDEBUGMONITORTOKENS
    {
        /// <summary>
        /// Enable the debug monitor.
        /// </summary>
        D3DDMT_ENABLE = 0,

        /// <summary>
        /// Disable the debug monitor.
        /// </summary>
        D3DDMT_DISABLE = 1,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DDMT_FORCE_DWORD = 0x7fffffff
    }
}
