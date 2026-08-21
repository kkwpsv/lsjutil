using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Paints an area with a linear gradient.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1lineargradientbrush"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID2D1LinearGradientBrush"/> paints an area with a linear gradient along a line
    /// between the brush start point and end point.
    /// The gradient, defined by the brush <see cref="ID2D1GradientStopCollection"/>,
    /// is extruded perpendicular to this line, and then transformed by a brush transform (if specified).
    /// </para>
    /// <para>
    /// The start point and end point are described in the brush space and are mapped to the render target when the brush is used.
    /// Note the starting and ending coordinates are absolute, not relative to the render target size.
    /// A value of (0, 0) maps to the upper-left corner of the render target,
    /// while a value of (1, 1) maps one pixel diagonally away from (0, 0).
    /// If there is a nonidentity brush transform or render target transform, the brush start point and end point are also transformed.
    /// </para>
    /// <para>
    /// It is possible to specify a gradient axis that does not completely fill the area that is being painted.
    /// When this occurs, the <see cref="D2D1_EXTEND_MODE"/>, specified by the <see cref="ID2D1GradientStopCollection"/>,
    /// determines how the remaining area is painted.
    /// </para>
    /// <para>
    /// Creating <see cref="ID2D1LinearGradientBrush"/> Objects
    /// </para>
    /// <para>
    /// To create a linear gradient brush, use the <see cref="ID2D1RenderTarget.CreateLinearGradientBrush"/> method
    /// of the render target on which the brush will be used.
    /// The brush can only be used with the render target that created it or with the compatible targets for that render target.
    /// </para>
    /// <para>
    /// A linear gradient brush is a device-dependent resource: your application should create linear gradient brushes
    /// after it initializes the render target with which the brushes will be used,
    /// and recreate the brushes whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906ab-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 12,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Brush)])]
    public unsafe struct ID2D1LinearGradientBrush
    {
        nint* _vTable;
    }
}
