using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that either create or merge a shortcut menu associated with a Shell object.
    /// Note that there are several better ways to extend Shell menus.
    /// For more information, see Creating Shortcut Menu Handlers.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icontextmenu"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// Implement <see cref="IContextMenu"/> in the following situations.
    /// For a detailed discussion of how to implement <see cref="IContextMenu"/>, see Creating Context Menu Handlers.
    /// </para>
    /// <para>
    /// When to Use
    /// </para>
    /// <para>
    /// Applications use <see cref="IContextMenu"/> to retrieve information about the items in an object's shortcut menu and to invoke the associated commands.
    /// To retrieve an object's <see cref="IContextMenu"/> interface, an application must call the object's <see cref="IShellFolder.GetUIObjectOf"/> method.
    /// </para>
    /// <para>
    /// Shell extension handlers that export this interface must also export <see cref="IShellExtInit"/>.
    /// For details, see Creating Shell Extension Handlers.
    /// </para>
    /// </remarks>
    public unsafe struct IContextMenu
    {
        nint* _vTable;
    }
}
