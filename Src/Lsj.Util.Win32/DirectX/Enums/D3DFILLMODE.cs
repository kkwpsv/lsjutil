using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants describing the fill mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dfillmode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumerated type are used by the <see cref="D3DRS_FILLMODE"/> render state.
    /// </remarks>
    public enum D3DFILLMODE
    {
        /// <summary>
        /// Fill points.
        /// </summary>
        D3DFILL_POINT = 1,

        /// <summary>
        /// Fill wireframes.
        /// </summary>
        D3DFILL_WIREFRAME = 2,

        /// <summary>
        /// Fill solids.
        /// </summary>
        D3DFILL_SOLID = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DFILL_FORCE_DWORD = 0x7fffffff,
    }
}
