using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="IAdviseSink2"/> interface is an extension of the <see cref="IAdviseSink"/> interface,
    /// adding the method <see cref="OnLinkSrcChange"/> to the contract to handle a change in the moniker of a linked object.
    /// This avoids overloading the implementation <see cref="IAdviseSink.OnRename"/> to handle the renaming of both embedded objects and linked objects.
    /// In applications where different blocks of code might execute depending on which of these two similar events has occurred,
    /// using the same method for both events complicates testing and debugging.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/objidl/nn-objidl-iadvisesink2"/>
    /// </para>
    /// </summary>

    public unsafe struct IAdviseSink2
    {
        nint* _vTable;
    }
}
