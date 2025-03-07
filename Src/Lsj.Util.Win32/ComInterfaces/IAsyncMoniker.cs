using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Obsolete.
    /// Enables client programs to determine if a moniker supports asynchronous binding.
    /// No additional methods are supported by this interface.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/ms775081(v=vs.85)"/>
    /// </para>
    /// </summary>
    [Obsolete("Obsolete. Enables client programs to determine if a moniker supports asynchronous binding." +
        " No additional methods are supported by this interface.")]

    public unsafe struct IAsyncMoniker
    {
        IntPtr* _vTable;
    }
}
