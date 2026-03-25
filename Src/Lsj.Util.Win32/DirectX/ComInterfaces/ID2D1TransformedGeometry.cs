using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a geometry that has been transformed.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1transformedgeometry"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Using an <see cref="ID2D1TransformedGeometry"/> rather than transforming a geometry
    /// by using a render target's transform enables you to transform a geometry without transforming its stroke.
    /// </para>
    /// <para>
    /// Creating ID2D1TransformedGeometry Objects
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1TransformedGeometry"/>, call the <see cref="ID2D1Factory.CreateTransformedGeometry"/> method.
    /// </para>
    /// <para>
    /// Direct2D geometries are immutable and device-independent resources created by <see cref="ID2D1Factory"/>.
    /// In general, you should create geometries once and retain them for the life of the application, or until they need to be modified.
    /// For more information about device-independent and device-dependent resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906bb-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 18,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Geometry)])]
    public unsafe struct ID2D1TransformedGeometry
    {
        IntPtr* _vTable;
    }
}
