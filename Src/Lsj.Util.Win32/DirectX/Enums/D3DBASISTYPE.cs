using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the basis type of a high-order patch surface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3dbasistype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The members of <see cref="D3DBASISTYPE"/> specify the formulation to be used in evaluating the high-order patch surface primitive during tessellation.
    /// </remarks>
    public enum D3DBASISTYPE
    {
        /// <summary>
        /// Input vertices are treated as a series of Bézier patches.
        /// The number of vertices specified must be divisible by 4.
        /// Portions of the mesh beyond this criterion will not be rendered.
        /// Full continuity is assumed between sub-patches in the interior of the surface rendered by each call.
        /// Only the vertices at the corners of each sub-patch are guaranteed to lie on the resulting surface.
        /// </summary>
        D3DBASIS_BEZIER = 0,

        /// <summary>
        /// Input vertices are treated as control points of a B-spline surface.
        /// The number of apertures rendered is two fewer than the number of apertures in that direction.
        /// In general, the generated surface does not contain the control vertices specified.
        /// </summary>
        D3DBASIS_BSPLINE = 1,

        /// <summary>
        /// An interpolating basis defines the surface so that the surface goes through all the input vertices specified.
        /// In DirectX 8, this was <see cref="D3DBASIS_INTERPOLATE"/>.
        /// </summary>
        D3DBASIS_CATMULL_ROM = 2,

        /// <summary>
        /// D3DBASIS_INTERPOLATE
        /// </summary>
        D3DBASIS_INTERPOLATE = D3DBASIS_CATMULL_ROM,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DBASIS_FORCE_DWORD = 0x7fffffff
    }
}
