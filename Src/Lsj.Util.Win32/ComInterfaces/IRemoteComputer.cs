using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method that enumerates or initializes a namespace extension when it is invoked on a remote object.
    /// This interface is used, for example, to initialize the remote printers virtual folder.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iremotecomputer"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implement <see cref="IRemoteComputer"/> when your namespace extension may be invoked on a remote computer.
    /// </para>
    /// <para>
    /// You do not call this interface directly. <see cref="IRemoteComputer"/> is used by the operating system
    /// only when it has confirmed that your application is aware of this interface.
    /// </para>
    /// </remarks>
    public unsafe struct IRemoteComputer
    {
        nint* _vTable;
    }
}
