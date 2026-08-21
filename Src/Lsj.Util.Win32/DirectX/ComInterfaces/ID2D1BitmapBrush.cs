using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Paints an area with a bitmap.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmapbrush"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// A bitmap brush is used to fill a geometry with a bitmap.
    /// Like all brushes, it defines an infinite plane of content.
    /// Because bitmaps are finite, the brush relies on an "extend mode" to determine how the plane is filled horizontally and vertically.
    /// </para>
    /// <para>
    /// Creating <see cref="ID2D1BitmapBrush"/> Objects
    /// </para>
    /// <para>
    /// To create a bitmap brush, use the <see cref="ID2D1RenderTarget.CreateBitmapBrush"/> method.
    /// </para>
    /// <para>
    /// An <see cref="ID2D1BitmapBrush"/> is a device-dependent resource:
    /// your application should create bitmap brushes after it initializes the render target with which the bitmap brush will be used,
    /// and recreate the bitmap brush whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd906aa-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 8, EndVTableSlotIndex = 15,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource), typeof(ID2D1Brush)])]
    public unsafe struct ID2D1BitmapBrush
    {
        nint* _vTable;
    }
}
