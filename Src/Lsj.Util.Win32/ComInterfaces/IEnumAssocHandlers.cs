using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method that allows enumeration of a collection of handlers associated with particular file name extensions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ienumassochandlers"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// /// <see cref="SHAssocEnumHandlers"/> is the usual method of creating an IEnumAssocHandlers pointer.
    /// </remarks>
    public unsafe struct IEnumAssocHandlers
    {
        nint* _vTable;
    }
}
