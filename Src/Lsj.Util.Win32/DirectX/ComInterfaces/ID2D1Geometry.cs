using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a geometry resource and defines a set of helper methods for manipulating and measuring geometric shapes.
    /// Interfaces that inherit from <see cref="ID2D1Geometry"/> define specific shapes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1geometry"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// There are several types of Direct2D geometry objects:
    /// a simple geometry (<see cref="ID2D1RectangleGeometry"/>,
    /// <see cref="ID2D1RoundedRectangleGeometry"/>, or <see cref="ID2D1EllipseGeometry"/>),
    /// a path geometry (<see cref="ID2D1PathGeometry"/>),
    /// or a composite geometry (<see cref="ID2D1GeometryGroup"/> and <see cref="ID2D1TransformedGeometry"/>).
    /// </para>
    /// <para>
    /// Direct2D geometries enable you to describe two-dimensional figures and also offer many uses,
    /// such as defining hit-test regions, clip regions, and even animation paths.
    /// </para>
    /// <para>
    /// Direct2D geometries are immutable and device-independent resources created by <see cref="ID2D1Factory"/>.
    /// In general, you should create geometries once and retain them for the life of the application, or until they need to be modified.
    /// For more information about device-independent and device-dependent resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a1-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 16,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Geometry
    {
        IntPtr* _vTable;
    }
}
