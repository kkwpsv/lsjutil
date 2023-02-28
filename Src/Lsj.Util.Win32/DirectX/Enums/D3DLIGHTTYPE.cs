using Lsj.Util.Win32.DirectX.Structs;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the light type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dlighttype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Directional lights are slightly faster than point light sources, but point lights look a little better.
    /// Spotlights offer interesting visual effects but are computationally time-consuming.
    /// </remarks>
    public enum D3DLIGHTTYPE
    {
        /// <summary>
        /// Light is a point source.
        /// The light has a position in space and radiates light in all directions.
        /// </summary>
        D3DLIGHT_POINT = 1,

        /// <summary>
        /// Light is a spotlight source.
        /// This light is like a point light, except that the illumination is limited to a cone.
        /// This light type has a direction and several other parameters that determine the shape of the cone it produces.
        /// For information about these parameters, see the <see cref="D3DLIGHT9"/> structure.
        /// </summary>
        D3DLIGHT_SPOT = 2,

        /// <summary>
        /// Light is a directional light source. This is equivalent to using a point light source at an infinite distance.
        /// </summary>
        D3DLIGHT_DIRECTIONAL = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DLIGHT_FORCE_DWORD = 0x7fffffff,
    }
}
