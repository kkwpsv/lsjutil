using System;
using Lsj.Util.Win32.Structs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enumerates the <see cref="FORMATETC"/> structures that define the formats and media supported by a given data object.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-ienumformatetc"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumFORMATETC
    {
        nint* _vTable;
    }
}
