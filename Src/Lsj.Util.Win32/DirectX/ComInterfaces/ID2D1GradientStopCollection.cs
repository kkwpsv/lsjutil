using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Structs;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a collection of <see cref="D2D1_GRADIENT_STOP"/> objects for linear and radial gradient brushes.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1gradientstopcollection"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1GradientStopCollection"/> Objects
    /// </para>
    /// <para>
    /// To create an <see cref="ID2D1GradientStopCollection"/>, use the <see cref="ID2D1RenderTarget.CreateGradientStopCollection"/> method.
    /// </para>
    /// <para>
    /// A gradient stop collection is a device-dependent resource:
    /// your application should create gradient stop collections after it initializes the render target
    /// with which the gradient stop collection will be used,
    /// and recreate the gradient stop collection whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a7-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 7,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1GradientStopCollection
    {
        nint* _vTable;
    }
}
