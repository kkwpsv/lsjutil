using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Enables a client to query an object proxy, or handler, for multiple interfaces by using a single RPC call.
    /// By using this interface, instead of relying on separate calls to <see cref="IUnknown.QueryInterface"/>,
    /// clients can reduce the number of RPC calls that have to cross thread, process, or machine boundaries and,
    /// therefore, the amount of time required to obtain the requested interface pointers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-imultiqi"/>
    /// </para>
    /// </summary>
    public unsafe struct IMultiQI
    {
        nint* _vTable;
    }
}
