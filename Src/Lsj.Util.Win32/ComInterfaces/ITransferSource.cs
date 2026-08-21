using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods to manipulate <see cref="IShellItem"/>, including copy, move, recycle, and others.
    /// This interface is offered to provide more control over file operations by providing an <see cref="ITransferSource.Advise"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransfersource"/>
    /// </para>
    /// </summary>
    public unsafe struct ITransferSource
    {
        nint* _vTable;
    }
}
