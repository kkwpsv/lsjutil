using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposed by Shell folders to provide detailed information about the items in a folder.
    /// This is the same information that is displayed by the Windows Explorer when the view of the folder is set to Details.
    /// For Windows 2000 and later systems, <see cref="IShellDetails"/> is superseded by <see cref="IShellFolder2"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-ishelldetails"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For Windows 2000 and later systems, folder objects should implement <see cref="IShellFolder2"/> instead of this interface.
    /// However, if your application needs to function on earlier systems, <see cref="IShellDetails"/> should also be exposed.
    /// </remarks>
    public unsafe struct IShellDetails
    {
        IntPtr* _vTable;
    }
}
