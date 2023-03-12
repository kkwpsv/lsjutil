using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe the fog mode.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dfogmode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumerated type are used by the <see cref="D3DRS_FOGTABLEMODE"/> and <see cref="D3DRS_FOGVERTEXMODE"/> render states.
    /// Fog can be considered a measure of visibility: the lower the fog value produced by a fog equation, the less visible an object is.
    /// </remarks>
    public enum D3DFOGMODE
    {
        /// <summary>
        /// No fog effect.
        /// </summary>
        D3DFOG_NONE = 0,

        /// <summary>
        /// Fog effect intensifies exponentially, according to the following formula.
        /// </summary>
        D3DFOG_EXP = 1,

        /// <summary>
        /// Fog effect intensifies exponentially with the square of the distance, according to the following formula.
        /// </summary>
        D3DFOG_EXP2 = 2,

        /// <summary>
        /// Fog effect intensifies linearly between the start and end points, according to the following formula.
        /// This is the only fog mode currently supported.
        /// </summary>
        D3DFOG_LINEAR = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DFOG_FORCE_DWORD = 0x7fffffff,
    }
}
