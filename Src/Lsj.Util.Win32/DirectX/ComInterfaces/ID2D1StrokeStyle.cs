using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Describes the caps, miter limit, line join, and dash information for a stroke.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1strokestyle"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating ID2D1StrokeStyle Objects
    /// </para>
    /// <para>
    /// To create a stroke style, use the <see cref="ID2D1Factory.CreateStrokeStyle"/> method.
    /// </para>
    /// <para>
    /// A stroke style is a device-independent resource; you can create it once then retain it for the life of your application.
    /// For more information about resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd9069d-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 12,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1StrokeStyle
    {
        nint* _vTable;
    }
}
