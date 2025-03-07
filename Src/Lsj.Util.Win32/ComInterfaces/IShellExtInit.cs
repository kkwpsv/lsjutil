using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method that initializes Shell extensions for property sheets, shortcut menus,
    /// and drag-and-drop handlers (extensions that add items to shortcut menus during nondefault drag-and-drop operations).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellextinit"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implement <see cref="IShellExtInit"/> when you are writing a handler based on the <see cref="IContextMenu"/> or <see cref="IShellPropSheetExt"/> interface.
    /// </para>
    /// <para>
    /// Note that Shell extensions based on other interfaces do not use this method of initialization.
    /// </para>
    /// <para>
    /// You do not use this interface directly. The Shell calls it to initialize the handler.
    /// </para>
    /// </remarks>
    public unsafe struct IShellExtInit
    {
        IntPtr* _vTable;
    }
}
