using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the capabilities of <see cref="IShellFolder"/>.
    /// Its methods provide a variety of information about the contents of a Shell folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellfolder2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface also provides the methods of the <see cref="IShellFolder"/> interface, from which it inherits.
    /// </para>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// Implement <see cref="IShellFolder2"/> if your namespace extension provides services to clients beyond those in <see cref="IShellFolder"/>.
    /// </para>
    /// <para>
    /// When to Use
    /// </para>
    /// <para>
    /// Call <see cref="IShellFolder2"/> when you need detailed information on items contained by a Shell folder.
    /// This interface supersedes <see cref="IShellDetails"/>.
    /// </para>
    /// </remarks>
    public unsafe struct IShellFolder2
    {
        nint* _vTable;
    }
}
