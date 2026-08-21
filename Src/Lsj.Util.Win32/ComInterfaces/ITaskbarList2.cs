using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="ITaskbarList"/> interface by exposing a method to mark a window as a full-screen display.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itaskbarlist2"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// This interface also provides the methods of the <see cref="ITaskbarList"/> interface, from which it inherits.
    /// </para>
    /// <para>
    /// The Shell also automatically attempts to detect full-screen applications,
    /// but it is not as reliable as using the <see cref="ITaskbarList2.MarkFullscreenWindow"/> method.
    /// </para>
    /// </remarks>
    public unsafe struct ITaskbarList2
    {
        nint* _vTable;

        /// <summary>
        /// Marks a window as full-screen.
        /// </summary>
        /// <param name="hwnd">
        /// The handle of the window to be marked.
        /// </param>
        /// <param name="fFullscreen">
        /// A Boolean value marking the desired full-screen status of the window.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Setting the value of <paramref name="fFullscreen"/> to <see cref="TRUE"/>, the Shell treats this window as a full-screen window,
        /// and the taskbar is moved to the bottom of the z-order when this window is active.
        /// Setting the value of <paramref name="fFullscreen"/> to <see cref="FALSE"/> removes the full-screen marking,
        /// but does not cause the Shell to treat the window as though it were definitely not full-screen.
        /// With a <see cref="FALSE"/> <paramref name="fFullscreen"/> value,
        /// the Shell depends on its automatic detection facility to specify how the window should be treated,
        /// possibly still flagging the window as full-screen.
        /// Since Windows 7, call <code>SetProp(hwnd, L”NonRudeHWND”, reinterpret_cast&lt;HANDLE&gt;(TRUE))</code>
        /// before showing a window to indicate to the Shell that the window should not be treated as full-screen.
        /// This ensures the taskbar does not adjust itself to be below the window in z-order.
        /// This is similar to <code>ITaskbarList2::MarkFullscreenWindow(FALSE)</code> except the Shell will not fallback to its automatic detection facility
        /// and will not treat the window as full-screen.
        /// </remarks>
        public HRESULT MarkFullscreenWindow([In] HWND hwnd, [In] BOOL fFullscreen)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, BOOL, HRESULT>)_vTable[8])(thisPtr, hwnd, fFullscreen);
            }
        }
    }
}
