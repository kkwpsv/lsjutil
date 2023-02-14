using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.GradientFillModes;
using static Lsj.Util.Win32.Msimg32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="GRADIENT_RECT"/> structure specifies the index of two vertices
    /// in the pVertex array in the <see cref="GradientFill"/> function.
    /// These two vertices form the upper-left and lower-right boundaries of a rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/ns-wingdi-gradient_rect"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="GRADIENT_RECT"/> structure specifies the values of the pVertex array that are used
    /// when the dwMode parameter of the <see cref="GradientFill"/> function is <see cref="GRADIENT_FILL_RECT_H"/> or <see cref="GRADIENT_FILL_RECT_V"/>.
    /// For related <see cref="GradientFill"/> structures, see <see cref="GRADIENT_TRIANGLE"/> and <see cref="TRIVERTEX"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct GRADIENT_RECT
    {
        /// <summary>
        /// The upper-left corner of a rectangle.
        /// </summary>
        public ULONG UpperLeft;

        /// <summary>
        /// The lower-right corner of a rectangle.
        /// </summary>
        public ULONG LowerRight;
    }
}
