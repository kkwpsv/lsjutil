using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Paints an area with a solid color.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1solidcolorbrush"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1SolidColorBrush"/> Objects
    /// </para>
    /// <para>
    /// To create a solid color brush, use the <see cref="ID2D1RenderTarget.CreateSolidColorBrush"/> method
    /// of the render target on which the brush will be used.
    /// The brush can only be used with the render target that created it or with the compatible targets for that render target.
    /// </para>
    /// <para>
    /// A solid color brush is a device-dependent resource.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906a9-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 9,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Brush)])]
    public unsafe struct ID2D1SolidColorBrush
    {
        nint* _vTable;
    }
}
