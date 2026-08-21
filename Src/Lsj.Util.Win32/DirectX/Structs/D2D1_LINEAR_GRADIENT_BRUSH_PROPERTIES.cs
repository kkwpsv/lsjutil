using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.Structs
{
    /// <summary>
    /// <para>
    /// Contains the starting point and endpoint of the gradient axis for an <see cref="ID2D1LinearGradientBrush"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/ns-d2d1-d2d1_linear_gradient_brush_properties"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Use this method when creating new <see cref="ID2D1LinearGradientBrush"/> objects
    /// with the <see cref="ID2D1RenderTarget.CreateLinearGradientBrush"/> method.
    /// For convenience, Direct2D provides the <c>D2D1.LinearGradientBrushProperties</c> helper function
    /// for creating new <see cref="D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES"/> structures.
    /// </para>
    /// <para>
    /// The following illustration shows how a linear gradient changes as you change its start and end points.
    /// For the first gradient, the start point is set to (0,0) and the end point to (150, 50);
    /// this creates a diagonal gradient that starts at the upper-left corner and extends to the lower-right corner of the area being painted.
    /// When you set the start point to (0, 25) and the end point to (150, 25), a horizontal gradient is created.
    /// Similarly, setting the start point to (75, 0) and the end point to (75, 50) creates a vertical gradient.
    /// Setting the start point to (0, 50) and the end point to (150, 0) creates a diagonal gradient
    /// that starts at the lower-left corner and extends to the upper-right corner of the area being painted.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES
    {
        /// <summary>
        /// In the brush's coordinate space, the starting point of the gradient axis.
        /// </summary>
        public D2D1_POINT_2F startPoint;

        /// <summary>
        /// In the brush's coordinate space, the endpoint of the gradient axis.
        /// </summary>
        public D2D1_POINT_2F endPoint;
    }
}
