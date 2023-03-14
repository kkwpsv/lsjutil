using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines constants that describe the supported shading modes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dshademode"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The first vertex of a triangle for flat shading mode is defined in the following manner.
    /// For a triangle list, the first vertex of the triangle i is i * 3.
    /// For a triangle fan, the first vertex of the triangle i is vertex i + 1.
    /// The members of this enumerated type define the vales for the <see cref="D3DRS_SHADEMODE"/> render state.
    /// </remarks>
    public enum D3DSHADEMODE
    {
        /// <summary>
        /// Flat shading mode.
        /// The color and specular component of the first vertex in the triangle are used to determine the color and specular component of the face.
        /// These colors remain constant across the triangle; that is, they are not interpolated.
        /// The specular alpha is interpolated.
        /// See Remarks.
        /// </summary>
        D3DSHADE_FLAT = 1,

        /// <summary>
        /// Gouraud shading mode.
        /// The color and specular components of the face are determined by a linear interpolation between all three of the triangle's vertices.
        /// </summary>
        D3DSHADE_GOURAUD = 2,

        /// <summary>
        /// Not supported.
        /// </summary>
        D3DSHADE_PHONG = 3,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DSHADE_FORCE_DWORD = 0x7fffffff
    }
}
