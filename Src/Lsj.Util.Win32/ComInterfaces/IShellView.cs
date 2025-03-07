using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that present a view in the Windows Explorer or folder windows.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishellview"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The object that exposes <see cref="IShellView"/> is typically created by a call to the <see cref="IShellFolder.CreateViewObject"/> method.
    /// This provides the channel of communication between a view object and Windows Explorer's outermost frame window.
    /// The communication involves the translation of messages, the state of the frame window (activated or deactivated),
    /// the state of the document window (activated or deactivated), and the merging of menus and toolbar items.
    /// </para>
    /// <para>
    /// This interface is implemented by namespace extensions that display themselves in Windows Explorer's namespace.
    /// This object is created by the <see cref="IShellFolder"/> object that hosts the view.
    /// </para>
    /// <para>
    /// These methods are used by the Shell view's Windows Explorer window to manipulate objects while they are active.
    /// </para>
    /// <para>
    /// <see cref="IShellView"/> is derived from <see cref="IOleWindow"/>.
    /// The listed methods are specific to <see cref="IShellView"/>.
    /// </para>
    /// <para>
    /// A special instance of <see cref="IShellView"/> known as the default Shell folder view object can be created
    /// by calling <see cref="SHCreateShellFolderView"/> or <see cref="SHCreateShellFolderViewEx"/>.
    /// This instance can be differentiated from standard implementations by calling <see cref="IUnknown.QueryInterface"/>
    /// on an <see cref="IShellView"/> object using the <see cref="IID_CDefView"/> IID.
    /// This call succeeds only when made on the default Shell folder view object.
    /// </para>
    /// </remarks>
    public unsafe struct IShellView
    {
        IntPtr* _vTable;
    }
}
