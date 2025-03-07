using System;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IFileDialog"/> interface by adding methods specific to the open dialog.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ifileopendialog"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// <see cref="IFileOpenDialog"/> is implemented by the common file open dialog (<see cref="CLSID_FileOpenDialog"/>).
    /// </para>
    /// <para>
    /// This interface also provides the methods of the <see cref="IFileDialog"/> interface, from which it inherits.
    /// </para>
    /// </remarks>
    public unsafe struct IFileOpenDialog
    {
        IntPtr* _vTable;
    }
}
