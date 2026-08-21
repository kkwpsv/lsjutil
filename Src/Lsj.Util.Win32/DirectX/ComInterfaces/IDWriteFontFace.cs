using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// This interface exposes various font data such as metrics, names, and glyph outlines.
    /// It contains font face type, appropriate file references, and face identification data.
    /// </para>
    /// <para>
    /// This interface extends <see cref="IUnknown"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwritefontface"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "5f49804d-7024-4d43-bfa9-d25984f53849", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 17, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDWriteFontFace
    {
        nint* _vTable;
    }
}
