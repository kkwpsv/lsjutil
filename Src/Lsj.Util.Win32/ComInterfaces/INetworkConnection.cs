using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="INetworkConnection"/> interface represents a single network connection.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/nn-netlistmgr-inetworkconnection"/>
    /// </para>
    /// </summary>
    public unsafe struct INetworkConnection
    {
        nint* _vTable;
    }
}
