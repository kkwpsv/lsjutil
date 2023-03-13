using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the location at which a color or color component must be accessed for lighting calculations.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dmaterialcolorsource"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// These flags are used to set the value of the following render states in the <see cref="D3DRENDERSTATETYPE"/> enumerated type.
    /// <see cref="D3DRS_AMBIENTMATERIALSOURCE"/>, <see cref="D3DRS_DIFFUSEMATERIALSOURCE"/>,
    /// <see cref="D3DRS_EMISSIVEMATERIALSOURCE"/>, <see cref="D3DRS_SPECULARMATERIALSOURCE"/>
    /// </remarks>
    public enum D3DMATERIALCOLORSOURCE : uint
    {
        /// <summary>
        /// Use the color from the current material.
        /// </summary>
        D3DMCS_MATERIAL = 0,

        /// <summary>
        /// Use the diffuse vertex color.
        /// </summary>
        D3DMCS_COLOR1 = 1,

        /// <summary>
        /// Use the specular vertex color.
        /// </summary>
        D3DMCS_COLOR2 = 2,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DMCS_FORCE_DWORD = 0x7fffffff,
    }
}
