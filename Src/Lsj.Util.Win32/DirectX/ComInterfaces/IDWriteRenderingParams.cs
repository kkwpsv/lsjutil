using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
using System;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents text rendering settings such as ClearType level, enhanced contrast,
    /// and gamma correction for glyph rasterization and filtering.
    /// </para>
    /// <para>
    /// An application typically obtains a rendering parameters object
    /// by calling the <see cref="IDWriteFactory.CreateMonitorRenderingParams"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dwrite/nn-dwrite-idwriterenderingparams"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows7)]
    [ComInterface(IID = "06152247-6f50-465a-9245-118bfd3b6007", BeginVTableSlotIndex = 3, EndVTableSlotIndex = 7, InheritedFromTypes = [typeof(IUnknown)])]
    public unsafe struct IDWriteRenderingParams
    {
        nint* _vTable;
    }
}
