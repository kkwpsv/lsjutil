using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    [ComImport]
    [Guid(IID_IModalWindow)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IModalWindow
    {
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
        HRESULT Show([In]IntPtr parent);
    }
}
