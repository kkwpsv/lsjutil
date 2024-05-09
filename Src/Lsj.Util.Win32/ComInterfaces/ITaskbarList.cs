using Lsj.Util.Win32.BaseTypes;
using System;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes methods that control the taskbar. It allows you to dynamically add, remove, and activate items on the taskbar.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itaskbarlist"/>
    /// </para>
    /// </summary>
    public unsafe struct ITaskbarList
    {
        IntPtr* _vTable;

        /// <summary>
        /// Initializes the taskbar list object.
        /// This method must be called before any other <see cref="ITaskbarList"/> methods can be called.
        /// </summary>
        /// <returns>
        /// Returns <see cref="S_OK"/> if successful, or an error value otherwise.
        /// If the method fails, no other methods can be called.
        /// The calling application should release the interface pointer.
        /// </returns>
        public HRESULT HrInit()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[3])(thisPtr);
            }
        }

        /// <summary>
        /// Adds an item to the taskbar.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be added to the taskbar.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Any type of window can be added to the taskbar, but it is recommended that the window at least have the <see cref="WS_CAPTION"/> style.
        /// Any window added with this method must be removed with the <see cref="DeleteTab"/> method when the added window is destroyed.
        /// </remarks>
        public HRESULT AddTab(HWND hwnd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[4])(thisPtr, hwnd);
            }
        }

        /// <summary>
        /// Deletes an item from the taskbar.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be deleted from the taskbar.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT DeleteTab(HWND hwnd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[5])(thisPtr, hwnd);
            }
        }

        /// <summary>
        /// Activates an item on the taskbar.
        /// The window is not actually activated; the window's item on the taskbar is merely displayed as active.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window on the taskbar to be displayed as active.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT ActivateTab(HWND hwnd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[6])(thisPtr, hwnd);
            }
        }

        /// <summary>
        /// Marks a taskbar item as active but does not visually activate it.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the window to be marked as active.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <see cref="SetActiveAlt"/> marks the item associated with <paramref name="hwnd"/> as the currently active item 
        /// for the window's process without changing the pressed state of any item.
        /// Any user action that would activate a different tab in that process will activate the tab associated with <paramref name="hwnd"/> instead.
        /// The active state of the window's item is not guaranteed to be preserved when the process associated with <paramref name="hwnd"/> is not active.
        /// To ensure that a given tab is always active, call <see cref="SetActiveAlt"/> whenever any of your windows are activated.
        /// Calling <see cref="SetActiveAlt"/> with a <see cref="NULL"/> <paramref name="hwnd"/> clears this state.
        /// </remarks>
        public HRESULT SetActiveAlt(HWND hwnd)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[7])(thisPtr, hwnd);
            }
        }
    }
}
