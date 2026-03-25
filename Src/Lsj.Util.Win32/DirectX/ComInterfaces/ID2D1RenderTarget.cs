using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an object that can receive drawing commands.
    /// Interfaces that inherit from <see cref="ID2D1RenderTarget"/> render the drawing commands they receive in different ways.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/d2d1/nn-d2d1-id2d1rendertarget"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Your application should create render targets once and hold onto them for the life of the application
    /// or until the render target's <see cref="EndDraw"/> method returns the <see cref="D2DERR_RECREATE_TARGET"/> error.
    /// When you receive this error, you need to recreate the render target (and any resources it created).
    /// </remarks>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "2cd90694-12e2-11dc-9fed-001143a055f9", BeginVTableSlotIndex = 4, EndVTableSlotIndex = 56,
        InheritedFromTypes = [typeof(IUnknown), typeof(ID2D1Resource)])]
    public unsafe struct ID2D1RenderTarget
    {
        IntPtr* _vTable;
    }
}
