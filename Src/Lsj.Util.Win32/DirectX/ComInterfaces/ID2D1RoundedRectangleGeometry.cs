using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Describes a rounded rectangle.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1roundedrectanglegeometry"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1RoundedRectangleGeometry"/> Objects
    /// </para>
    /// <para>
    /// To create a rectangle geometry, use the <see cref="ID2D1Factory.CreateRoundedRectangleGeometry"/> method.
    /// </para>
    /// <para>
    /// Direct2D geometries are immutable and device-independent resources created by <see cref="ID2D1Factory"/>.
    /// In general, you should create geometries once and retain them for the life of the application, or until they need to be modified.
    /// For more information about device-independent and device-dependent resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a3-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 17,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Geometry)])]
    public unsafe struct ID2D1RoundedRectangleGeometry
    {
        IntPtr* _vTable;
    }
}
