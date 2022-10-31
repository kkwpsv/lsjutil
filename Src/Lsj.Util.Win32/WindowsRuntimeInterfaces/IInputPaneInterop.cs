using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.GetAncestorFlags;
using static Lsj.Util.Win32.WindowsRuntimeInterfaces.IIDs;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// Enables access to the members of the InputPane class in a desktop app.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/zh-cn/windows/win32/api/inputpaneinterop/nn-inputpaneinterop-iinputpaneinterop"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You can obtain an instance of the <see cref="IInputPaneInterop"/> interface by calling
    /// the <see cref="IUnknown.QueryInterface"/> method on the activation factory instance for the InputPane class.
    /// </remarks>
    public unsafe struct IInputPaneInterop
    {
        IntPtr* _vTable;

        /// <summary>
        /// Gets an instance of an InputPane object for the specified window.
        /// </summary>
        /// <param name="appWindow">
        /// The top-level (<see cref="GA_ROOT"/>) window for which you want to get the InputPane object.
        /// </param>
        /// <param name="riid">
        /// The interface identifier for the interface that you want to get in the <paramref name="inputPane"/> parameter.
        /// This value is typically <see cref="IID_IInputPane"/> or <see cref="IID_IInputPane2"/>, as defined in Windows.UI.ViewManagement.h.
        /// </param>
        /// <param name="inputPane">
        /// The InputPane object for the window that the <paramref name="appWindow"/> parameter specifies.
        /// This parameter is typically a pointer to an <see cref="IInputPane"/> or <see cref="IInputPane2"/> interface, as defined in Windows.UI.ViewManagement.idl.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        public HRESULT GetForWindow([In] HWND appWindow, [In] in IID riid, [Out] out IntPtr inputPane)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, in IID, out IntPtr, HRESULT>)_vTable[6])(thisPtr, appWindow, riid, out inputPane);
            }
        }
    }
}
