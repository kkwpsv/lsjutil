using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents a producer of pixels that can fill an arbitrary 2D plane.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1image"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="ID2D1Image"/> is abstract.
    /// Concrete instances can be created through <see cref="ID2D1DeviceContext.CreateEffect"/> and <see cref="ID2D1DeviceContext.CreateBitmap"/>.
    /// </para>
    /// <para>
    /// Images are evaluated lazily.
    /// If the type of image passed in is concrete, then the image can be directly sampled from.
    /// Other images can act only as a source of pixels and can produce content only as a result of calling <see cref="ID2D1DeviceContext.DrawImage"/>.
    /// </para>
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "65019f75-8da2-497c-b32c-dfa34e48ede6", BeginVTableSlotIndex = -1, EndVTableSlotIndex = 3,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1Image
    {
        nint* _vTable;
    }
}
