using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents the drawing state of a render target: the antialiasing mode, transform, tags, and text-rendering options.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1drawingstateblock"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1DrawingStateBlock"/> Objects
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1DrawingStateBlock"/>, use the <see cref="ID2D1Factory.CreateDrawingStateBlock"/> method.
    /// </para>
    /// <para>
    /// A drawing state block is a device-independent resource; you can create it once and retain it for the life of your application.
    /// For more information about resources, see the Resources Overview.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "28506e39-ebf6-46a1-bb47-fd85565ab957", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1DrawingStateBlock
    {
        IntPtr* _vTable;
    }
}
