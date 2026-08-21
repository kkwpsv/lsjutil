using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the gradient origin offset and the size and position of the gradient ellipse for an <see cref="ID2D1RadialGradientBrush"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_radial_gradient_brush_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Different values for <see cref="center"/>, <see cref="gradientOriginOffset"/>,
    /// <see cref="radiusX"/> and/or <see cref="radiusY"/> produce different gradients.
    /// The following illustration shows several radial gradients that have different gradient origin offsets,
    /// creating the appearance of the light illuminating the circles from different angles.
    /// </para>
    /// <para>
    /// For convenience, Direct2D provides the <c>D2D1.RadialGradientBrushProperties</c> function
    /// for creating new <see cref="D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES"/> structures.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES
    {
        /// <summary>
        /// In the brush's coordinate space, the center of the gradient ellipse.
        /// </summary>
        public D2D1_POINT_2F center;

        /// <summary>
        /// In the brush's coordinate space, the offset of the gradient origin relative to the gradient ellipse's center.
        /// </summary>
        public D2D1_POINT_2F gradientOriginOffset;

        /// <summary>
        /// In the brush's coordinate space, the x-radius of the gradient ellipse.
        /// </summary>
        public FLOAT radiusX;

        /// <summary>
        /// In the brush's coordinate space, the y-radius of the gradient ellipse.
        /// </summary>
        public FLOAT radiusY;
    }
}
