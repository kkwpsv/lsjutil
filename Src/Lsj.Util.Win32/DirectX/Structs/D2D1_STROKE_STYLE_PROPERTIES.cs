using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the stroke that outlines a shape.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_stroke_style_properties"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_STROKE_STYLE_PROPERTIES
    {
        /// <summary>
        /// The cap applied to the start of all the open figures in a stroked geometry.
        /// </summary>
        public D2D1_CAP_STYLE startCap;

        /// <summary>
        /// The cap applied to the end of all the open figures in a stroked geometry.
        /// </summary>
        public D2D1_CAP_STYLE endCap;

        /// <summary>
        /// The shape at either end of each dash segment.
        /// </summary>
        public D2D1_CAP_STYLE dashCap;

        /// <summary>
        /// A value that describes how segments are joined.
        /// This value is ignored for a vertex if the segment flags specify that the segment should have a smooth join.
        /// </summary>
        public D2D1_LINE_JOIN lineJoin;

        /// <summary>
        /// The limit of the thickness of the join on a mitered corner.
        /// This value is always treated as though it is greater than or equal to 1.0f.
        /// </summary>
        public FLOAT miterLimit;

        /// <summary>
        /// A value that specifies whether the stroke has a dash pattern and, if so, the dash style.
        /// </summary>
        public D2D1_DASH_STYLE dashStyle;

        /// <summary>
        /// A value that specifies an offset in the dash sequence.
        /// A positive dash offset value shifts the dash pattern,
        /// in units of stroke width, toward the start of the stroked geometry.
        /// A negative dash offset value shifts the dash pattern,
        /// in units of stroke width, toward the end of the stroked geometry.
        /// </summary>
        public FLOAT dashOffset;
    }
}
