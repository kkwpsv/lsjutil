using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enumerates the components of a moniker or the monikers in a table of monikers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ienummoniker"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumMoniker
    {
        nint* _vTable;
    }
}
