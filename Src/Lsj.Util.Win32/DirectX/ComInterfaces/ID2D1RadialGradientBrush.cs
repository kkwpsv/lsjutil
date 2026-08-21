using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Paints an area with a radial gradient.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1radialgradientbrush"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="ID2D1RadialGradientBrush"/> is similar to the <see cref="ID2D1LinearGradientBrush"/>
    /// in that they both map a collection of gradient stops to a gradient.
    /// However, the linear gradient has a start and an end point to define the gradient vector,
    /// while the radial gradient uses an ellipse and a gradient origin to define its gradient behavior.
    /// To define the position and size of the ellipse, use the <see cref="ID2D1RadialGradientBrush.SetCenter"/>,
    /// <see cref="ID2D1RadialGradientBrush.SetRadiusX"/>, and <see cref="ID2D1RadialGradientBrush.SetRadiusY"/> methods
    /// to specify the center, x-radius, and y-radius of the ellipse.
    /// The gradient origin is the center of the ellipse,
    /// unless a gradient offset is specified by using the <see cref="ID2D1RadialGradientBrush.SetGradientOriginOffset"/> method.
    /// </para>
    /// <para>
    /// The brush maps the gradient stop position 0.0f of the gradient origin, and the position 1.0f is mapped to the ellipse boundary.
    /// When the gradient origin is within the ellipse,
    /// the contents of the ellipse enclose the entire [0, 1] range of the brush gradient stops.
    /// If the gradient origin is outside the bounds of the ellipse,
    /// the brush still works, but its gradient is not well-defined.
    /// </para>
    /// <para>
    /// The start point and end point are described in the brush space and are mapped to the render target when the brush is used.
    /// Note the starting and ending coordinates are absolute, not relative to the render target size.
    /// A value of (0, 0) maps to the upper-left corner of the render target,
    /// while a value of (1, 1) maps just one pixel diagonally away from (0, 0).
    /// If there is a nonidentity brush transform or render target transform, the brush ellipse and gradient origin are also transformed.
    /// </para>
    /// <para>
    /// It is possible to specify an ellipse that does not completely fill area being painted.
    /// When this occurs, the <see cref="D2D1_EXTEND_MODE"/> and setting
    /// (specified by the brush <see cref="ID2D1GradientStopCollection"/>) determines how the remaining area is painted.
    /// </para>
    /// <para>
    /// Creating <see cref="ID2D1RadialGradientBrush"/> Objects
    /// </para>
    /// <para>
    /// To create a radial gradient brush, use the <see cref="ID2D1RenderTarget.CreateRadialGradientBrush"/> method
    /// of the render target on which the brush will be used.
    /// The brush may be used only with the render target that created it or with the compatible targets for that render target.
    /// </para>
    /// <para>
    /// A radial gradient brush is a device-dependent resource:
    /// your application should create radial gradient brushes
    /// after it initializes the render target with which the brushes will be used,
    /// and recreate the brushes whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906ac-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 16,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Brush)])]
    public unsafe struct ID2D1RadialGradientBrush
    {
        nint* _vTable;
    }
}
