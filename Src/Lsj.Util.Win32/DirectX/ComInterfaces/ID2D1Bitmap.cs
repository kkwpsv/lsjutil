using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a bitmap that has been bound to an <see cref="ID2D1RenderTarget"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1bitmap"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Creating <see cref="ID2D1Bitmap"/> Objects
    /// </para>
    /// <para>
    /// To create a bitmap, use one of the following methods of the render target on which the bitmap will be drawn:
    /// </para>
    /// <para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ID2D1RenderTarget.CreateBitmap"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ID2D1RenderTarget.CreateBitmapFromWicBitmap"/>
    /// </description>
    /// </item>
    /// </list>
    /// </para>
    /// <para>
    /// For information about the pixel formats supported by Direct2D bitmaps, see Supported Pixel Formats and Alpha Modes.
    /// </para>
    /// <para>
    /// An <see cref="ID2D1Bitmap"/> is a device-dependent resource:
    /// your application should create bitmaps after it initializes the render target with which the bitmap will be used,
    /// and recreate the bitmap whenever the render target needs recreated.
    /// (For more information about resources, see Resources Overview.)
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "a2296057-ea42-4099-983b-539fb6505426", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 10,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Bitmap
    {
        nint* _vTable;
    }
}
