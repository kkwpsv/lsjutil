using System;
using Lsj.Util.Win32.Marshals;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enumerate strings.
    /// <see cref="LPWSTR"/> is the type that indicates a pointer to a zero-terminated string of wide, or Unicode, characters.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ienumstring"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumString
    {
        nint* _vTable;
    }
}
