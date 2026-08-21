using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes enumeration of <see cref="IShellItem"/> interfaces.
    /// This interface is typically obtained by calling the <see cref="IEnumShellItems"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumshellitems"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumShellItems
    {
        nint* _vTable;
    }
}
