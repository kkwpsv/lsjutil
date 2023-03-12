using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the supported compare functions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dcmpfunc"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumerated type define the supported compare functions
    /// for the <see cref="D3DRS_ZFUNC"/>, <see cref="D3DRS_ALPHAFUNC"/>, and <see cref="D3DRS_STENCILFUNC"/> render states.
    /// </remarks>
    public enum D3DCMPFUNC
    {
        /// <summary>
        /// Always fail the test.
        /// </summary>
        D3DCMP_NEVER = 1,

        /// <summary>
        /// Accept the new pixel if its value is less than the value of the current pixel.
        /// </summary>
        D3DCMP_LESS = 2,

        /// <summary>
        /// Accept the new pixel if its value equals the value of the current pixel.
        /// </summary>
        D3DCMP_EQUAL = 3,

        /// <summary>
        /// Accept the new pixel if its value is less than or equal to the value of the current pixel.
        /// </summary>
        D3DCMP_LESSEQUAL = 4,

        /// <summary>
        /// Accept the new pixel if its value is greater than the value of the current pixel.
        /// </summary>
        D3DCMP_GREATER = 5,

        /// <summary>
        /// Accept the new pixel if its value does not equal the value of the current pixel.
        /// </summary>
        D3DCMP_NOTEQUAL = 6,

        /// <summary>
        /// Accept the new pixel if its value is greater than or equal to the value of the current pixel.
        /// </summary>
        D3DCMP_GREATEREQUAL = 7,

        /// <summary>
        /// Always pass the test.
        /// </summary>
        D3DCMP_ALWAYS = 8,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DCMP_FORCE_DWORD = 0x7fffffff
    }
}
