using System;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that either create or merge a shortcut (context) menu associated with a Shell object.
    /// Extends <see cref="IContextMenu"/> by adding a method that allows client objects to handle messages associated with owner-drawn menu items.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icontextmenu2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface also provides the methods of the <see cref="IContextMenu"/> interface, from which it inherits.
    /// </para>
    /// <para>
    /// When to Implement
    /// </para>
    /// <para>
    /// Implement <see cref="IContextMenu2"/> if your namespace extension or shortcut menu handler needs to process one or more of the following messages.
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="WM_INITMENUPOPUP"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="WM_DRAWITEM"/>
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="WM_MEASUREITEM"/>
    /// </description>
    /// </item>
    /// </list>
    /// <para>
    /// These messages are forwarded to <see cref="IContextMenu2"/>—through the <see cref="HandleMenuMsg"/> method
    /// —only if a <see cref="IUnknown.QueryInterface"/> call for an <see cref="IContextMenu2"/> interface pointer is successful,
    /// indicating that the object supports this interface.
    /// </para>
    /// <para>
    /// When to Use
    /// </para>
    /// <para>
    /// Applications do not normally call this interface directly.
    /// </para>
    /// </remarks>
    public unsafe struct IContextMenu2
    {
        nint* _vTable;
    }
}
