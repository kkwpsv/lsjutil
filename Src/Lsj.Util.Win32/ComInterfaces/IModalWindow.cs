using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.ComInterfaces.IIDs;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Exposes a method that represents a modal window.
    /// This interface is used in the Windows XP Passport Wizard.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nn-shobjidl_core-imodalwindow
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="IModalWindow"/>'s IID is <see cref="IID_IModalWindow"/>.
    /// </remarks>
    public unsafe struct IModalWindow
    {
        IntPtr* _vTable;

        /// <summary>
        /// Launches the modal window.
        /// </summary>
        /// <param name="parent">
        /// The handle of the owner window.
        /// This value can be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the method succeeds, it returns <see cref="S_OK"/>. 
        /// Otherwise, it returns an <see cref="HRESULT"/> error code, including the following:
        /// HRESULT_FROM_WIN32(ERROR_CANCELLED):
        /// The user closed the window by cancelling the operation.
        /// </returns>
        public HRESULT Show([In] HWND parent)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, HRESULT>)_vTable[3])(thisPtr, parent);
            }
        }
    }
}
