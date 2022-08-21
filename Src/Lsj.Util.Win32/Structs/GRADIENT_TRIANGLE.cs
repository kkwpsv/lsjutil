using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GradientFillModes;
using static Lsj.Util.Win32.Msimg32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GRADIENT_TRIANGLE"/> structure specifies
    /// the index of three vertices in the pVertex array in the <see cref="GradientFill"/> function.
    /// These three vertices form one triangle.
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="GRADIENT_TRIANGLE"/> structure specifies the values in the pVertex array
    /// that are used when the dwMode parameter of the <see cref="GradientFill"/> function is <see cref="GRADIENT_FILL_TRIANGLE"/>.
    /// For related <see cref="GradientFill"/> structures, see <see cref="GRADIENT_RECT"/> and <see cref="TRIVERTEX"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GRADIENT_TRIANGLE
    {
        /// <summary>
        /// The first point of the triangle where sides intersect.
        /// </summary>
        public ULONG Vertex1;

        /// <summary>
        /// The second point of the triangle where sides intersect.
        /// </summary>
        public ULONG Vertex2;

        /// <summary>
        /// The third point of the triangle where sides intersect.
        /// </summary>
        public ULONG Vertex3;
    }
}
