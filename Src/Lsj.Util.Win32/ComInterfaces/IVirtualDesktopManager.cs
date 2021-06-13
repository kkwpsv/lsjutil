using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that enable an application to interact with groups of windows that form virtual workspaces.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nn-shobjidl_core-ivirtualdesktopmanager"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The user can group a collection of windows together to create a virtual desktop.
    /// Every window is considered to be part of a virtual desktop.
    /// When one virtual desktop is hidden, all of the windows associated with it are also hidden.
    /// This enables the user to create multiple working environments and to be able to switch between them.
    /// Similarly, when a virtual desktop is selected to be active, the windows associated with that virtual desktop are displayed on the screen.
    /// To support this concept, applications should avoid automatically switching the user from one virtual desktop to another.
    /// Only the user should instigate that change.
    /// In order to support this, newly created windows should appear on the currently active virtual desktop.
    /// In addition, if an application can reuse currently active windows,
    /// it should only reuse windows if they are on the currently active virtual desktop.
    /// Otherwise, a new window should be created.
    /// Virtual desktop visualization In the above image, the user has two virtual desktops and VD2 is the currently active virtual desktop.
    /// If the user clicks a link in an outlook message, there's a URI activation that should open the link in an Internet Explorer window.
    /// If the user has configured IE to open links in the current window, it would normally use the currently open window.
    /// However, in this case, IE is on an inactive virtual desktop.
    /// In this scenario, IE should create a new window in the currently active virtual desktop.
    /// </remarks>
    public unsafe struct IVirtualDesktopManager
    {
        IntPtr* _vTable;

        /// <summary>
        /// Indicates whether the provided window is on the currently active virtual desktop.
        /// </summary>
        /// <param name="topLevelWindow">
        /// The window of interest.
        /// </param>
        /// <param name="onCurrentDesktop">
        /// <see cref="TRUE"/> if the <paramref name="topLevelWindow"/> is on the currently active virtual desktop, otherwise <see cref="FALSE"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT IsWindowOnCurrentVirtualDesktop([In] HWND topLevelWindow, [Out] out BOOL onCurrentDesktop)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, out BOOL, HRESULT>)_vTable[3])(thisPtr, topLevelWindow, out onCurrentDesktop);
            }
        }

        /// <summary>
        /// Gets the identifier for the virtual desktop hosting the provided top-level window.
        /// </summary>
        /// <param name="topLevelWindow">
        /// The top level window for the virtual desktop you are interested in.
        /// </param>
        /// <param name="desktopId">
        /// The identifier for the virtual desktop hosting the <paramref name="topLevelWindow"/>.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetWindowDesktopId([In] HWND topLevelWindow, [Out] out GUID desktopId)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, out GUID, HRESULT>)_vTable[4])(thisPtr, topLevelWindow, out desktopId);
            }
        }

        /// <summary>
        /// Moves a window to the specified virtual desktop.
        /// </summary>
        /// <param name="topLevelWindow">
        /// The window to move.
        /// </param>
        /// <param name="desktopId">
        /// The identifier of the virtual desktop to move the <see cref="GetWindowDesktopId"/> to get a window's identifier.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT MoveWindowToDesktop([In] HWND topLevelWindow, [In] in GUID desktopId)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, in GUID, HRESULT>)_vTable[5])(thisPtr, topLevelWindow, in desktopId);
            }
        }
    }
}
