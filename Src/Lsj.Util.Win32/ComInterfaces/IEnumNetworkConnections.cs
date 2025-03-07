using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IEnumNetworkConnections"/> interface provides a standard enumerator for network connections.
    /// It enumerates active, disconnected, or all network connections within a network.
    /// This interface can be obtained from the <see cref="INetwork"/> interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/netlistmgr/nn-netlistmgr-ienumnetworkconnections"/>
    /// </para>
    /// </summary>
    public unsafe struct IEnumNetworkConnections
    {
        IntPtr* _vTable;
    }
}
