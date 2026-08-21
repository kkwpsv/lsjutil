using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables the management of access to objects and properties on the objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/iaccess/nn-iaccess-iaccesscontrol"/>
    /// </para>
    /// </summary>
    public unsafe struct IAccessControl
    {
        nint* _vTable;
    }
}
