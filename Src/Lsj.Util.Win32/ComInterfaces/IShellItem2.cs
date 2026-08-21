using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends <see cref="IShellItem"/> with methods that retrieve various property values of the item.
    /// <see cref="IShellItem"/> and <see cref="IShellItem2"/> are the preferred representations of items in any new code.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitem2"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellItem2
    {
        nint* _vTable;
    }
}
