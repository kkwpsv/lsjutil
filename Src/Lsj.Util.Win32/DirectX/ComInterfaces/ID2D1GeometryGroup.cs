using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a composite geometry, composed of other <see cref="ID2D1Geometry"/> objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1geometrygroup"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Geometry groups are a convenient way to group several geometries simultaneously
    /// so all figures of several distinct geometries are concatenated into one.
    /// </para>
    /// <para>
    /// Creating ID2D1GeometryGroup Objects
    /// </para>
    /// <para>
    /// To create a <see cref="ID2D1GeometryGroup"/> object, call the <see cref="ID2D1Factory.CreateGeometryGroup"/> method,
    /// passing in the <c>fillMode</c> with possible values of
    /// <see cref="D2D1_FILL_MODE_ALTERNATE"/> (alternate) and <see cref="D2D1_FILL_MODE_WINDING"/>,
    /// an array of geometry objects to add to the geometry group, and the number of elements in this array.
    /// </para>
    /// <para>
    /// Direct2D geometries are immutable and device-independent resources created by <see cref="ID2D1Factory"/>.
    /// In general, you should create geometries once and retain them for the life of the application, or until they need to be modified.
    /// For more information about device-independent and device-dependent resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a6-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 17, EndVTableSlotIndex = 19,
       InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Geometry)])]
    public unsafe struct ID2D1GeometryGroup
    {
        IntPtr* _vTable;
    }
}
