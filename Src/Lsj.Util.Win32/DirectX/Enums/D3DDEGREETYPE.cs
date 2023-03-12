using static Lsj.Util.Win32.DirectX.Enums.D3DRENDERSTATETYPE;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Defines the degree of the variables in the equation that describes a curve.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3d9/d3ddegreetype"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are used to describe the curves used by rectangle and triangle patches.
    /// For more information, see <see cref="D3DRS_CULLMODE"/>.
    /// </remarks>
    public enum D3DDEGREETYPE
    {
        /// <summary>
        /// Curve is described by variables of first order.
        /// </summary>
        D3DDEGREE_LINEAR = 1,

        /// <summary>
        /// Curve is described by variables of second order.
        /// </summary>
        D3DDEGREE_QUADRATIC = 2,

        /// <summary>
        /// Curve is described by variables of third order.
        /// </summary>
        D3DDEGREE_CUBIC = 3,

        /// <summary>
        /// Curve is described by variables of fourth order.
        /// </summary>
        D3DDEGREE_QUINTIC = 5,

        /// <summary>
        /// Forces this enumeration to compile to 32 bits in size.
        /// Without this value, some compilers would allow this enumeration to compile to a size other than 32 bits.
        /// This value is not used.
        /// </summary>
        D3DCULL_FORCE_DWORD = 0x7fffffff
    }
}
