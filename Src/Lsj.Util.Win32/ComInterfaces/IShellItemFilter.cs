using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposed by a client to specify how to filter the enumeration of a Shell item by a server application.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellitemfilter"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellItemFilter
    {
        nint* _vTable;
    }
}
