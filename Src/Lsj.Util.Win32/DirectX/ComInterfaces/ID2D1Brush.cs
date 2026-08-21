using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Defines an object that paints an area.
    /// Interfaces that derive from <see cref="ID2D1Brush"/> describe how the area is painted.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1brush"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID2D1BitmapBrush"/> is a device-dependent resource:
    /// your application should create bitmap brushes after it initializes the render target
    /// with which the bitmap brush will be used, and recreate the bitmap brush whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// <para>
    /// Brush space in Direct2D is specified differently than in XPS and Windows Presentation Foundation (WPF).
    /// In Direct2D, brush space is not relative to the object being drawn,
    /// but rather is the current coordinate system of the render target, transformed by the brush transform, if present.
    /// To paint an object as it would be painted by a WPF brush,
    /// you must translate the brush space origin to the upper-left corner of the object's bounding box,
    /// and then scale the brush space so that the base tile fills the bounding box of the object.
    /// </para>
    /// <para>
    /// For more information about brushes, see the Brushes Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a8-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Brush
    {
        nint* _vTable;
    }
}
