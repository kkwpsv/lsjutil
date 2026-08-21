using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a complex shape that may be composed of arcs, curves, and lines.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1pathgeometry"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID2D1PathGeometry"/> object enables you to describe a geometric path.
    /// To describe an <see cref="ID2D1PathGeometry"/> object's path,
    /// use the object's <see cref="ID2D1PathGeometry.Open"/> method to retrieve an <see cref="ID2D1GeometrySink"/>.
    /// Use the sink to populate the path geometry with figures and segments.
    /// </para>
    /// <para>
    /// Creating ID2D1PathGeometry Objects
    /// </para>
    /// <para>
    /// To create a path geometry, use the <see cref="ID2D1Factory.CreatePathGeometry"/> method.
    /// </para>
    /// <para>
    /// <see cref="ID2D1PathGeometry"/> objects are device-independent resources created by <see cref="ID2D1Factory"/>.
    /// In general, you should create geometries once and retain them for the life of the application, or until they need to be modified.
    /// For more information about device-independent and device-dependent resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a5-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 20,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Geometry)])]
    public unsafe struct ID2D1PathGeometry
    {
        nint* _vTable;
    }
}
