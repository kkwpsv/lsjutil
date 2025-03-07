using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Used by item monikers when they are bound to the objects they identify.
    /// </para>
    /// <para>
    /// When any container of objects uses item monikers to identify its objects, it must define a naming scheme for those objects.
    /// The container's <see cref="IOleItemContainer"/> implementation uses knowledge of that naming scheme to retrieve an object given a particular name.
    /// Item monikers use the container's <see cref="IOleItemContainer"/> implementation during binding.
    /// </para>
    /// <para>
    /// This interface is not supported for use across machine boundaries.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleitemcontainer"/>
    /// </para>
    /// </summary>
    public unsafe struct IOleItemContainer
    {
        IntPtr* _vTable;
    }
}
