using System;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that the Shell uses to retrieve flags and info tip information
    /// for an item that resides in an <see cref="IShellFolder"/> implementation.
    /// Info tips are usually displayed inside a tooltip control.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/nn-shlobj_core-iqueryinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface is obtained by calling <see cref="IShellFolder.GetUIObjectOf"/> and passing <see cref="IID_IQueryInfo"/> for the interface identifier.
    /// The item for which info tip information is being requested is contained in the apidl argument of the <see cref="IShellFolder.GetUIObjectOf"/> call.
    /// If <see cref="IQueryInfo"/> is not supplied by the folder, the Shell will use the standard display text in the info tip.
    /// </para>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// Implement <see cref="IQueryInfo"/> to provide flags and text information that differs from the normal text that is displayed for an item in a folder.
    /// For example, if your folder contained file objects, you could use the info tip to provide the entire path and file name for the item rather than just the file name.
    /// </para>
    /// <para>
    /// When to Use
    /// </para>
    /// <para>
    /// In most cases, you do not use this interface directly.
    /// The Shell will use this interface when it requires additional information to display inside of an info tip.
    /// However, you can use <see cref="IQueryInfo"/> directly if you want to obtain info tip information from another object.
    /// </para>
    /// </remarks>
    public unsafe struct IQueryInfo
    {
        nint* _vTable;
    }
}
