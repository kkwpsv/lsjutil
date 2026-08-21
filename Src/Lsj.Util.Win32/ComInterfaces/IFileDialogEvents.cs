using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that allow notification of events within a common file dialog.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifiledialogevents"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// <see cref="IFileDialogEvents"/> is implemented by an application that is a client of the common file dialog browser.
    /// Methods that are not implemented should return <see cref="E_NOTIMPL"/>.
    /// An example of <see cref="IFileDialogEvents"/> can be found in the Common File Dialog SDK sample.
    /// </para>
    /// </remarks>
    public unsafe struct IFileDialogEvents
    {
        nint* _vTable;
    }
}
