using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that create a destination Shell item for a copy or move operation.
    /// This interface is provided to allow more control over file operations by providing an <see cref="ITransferDestination.Advise"/> method.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransferdestination"/>
    /// </para>
    /// </summary>
    public unsafe struct ITransferDestination
    {
        nint* _vTable;
    }
}
