using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Describes the opacity and transformation of a brush.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_brush_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This structure is used when creating a brush.
    /// For convenience, Direct2D provides the <c>D2D1.BrushProperties</c> function for creating <see cref="D2D1_BRUSH_PROPERTIES"/> structures.
    /// </para>
    /// <para>
    /// After creating a brush, you can change its opacity or transform
    /// by calling the <see cref="ID2D1Brush.SetOpacity"/> or <see cref="ID2D1Brush.SetTransform"/> methods.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_BRUSH_PROPERTIES
    {
        /// <summary>
        /// A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.
        /// </summary>
        public FLOAT opacity;

        /// <summary>
        /// The transformation that is applied to the brush.
        /// </summary>
        public D2D1_MATRIX_3X2_F transform;
    }
}
