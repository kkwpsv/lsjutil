using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enumerates the advisory connection information for a data object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ienumstatdata"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumSTATDATA
    {
        nint* _vTable;
    }
}
