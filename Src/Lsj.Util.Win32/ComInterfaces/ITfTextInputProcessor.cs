using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ITfTextInputProcessor"/> interface is implemented by a text service and used by the TSF manager to activate and deactivate the text service.
    /// The manager obtains a pointer to this interface when it creates an instance of the text service for a thread with a call to <see cref="CoCreateInstance"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itftextinputprocessor"/>
    /// </para>
    /// </summary>
    public unsafe struct ITfTextInputProcessor
    {
        IntPtr* _vTable;

        /// <summary>
        /// Activates a text service when a user session starts.
        /// </summary>
        /// <param name="ptim">
        /// Pointer to the <see cref="ITfThreadMgr"/> interface for the thread manager that owns the text service.
        /// </param>
        /// <param name="tid">
        /// Specifies the client identifier for the text service.
        /// </param>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// TSF calls this method after creating an instance of a text service with a call to <see cref="CoCreateInstance"/>.
        /// This enables operations necessary to start the text service.
        /// This method usually adds a reference to the thread manager for the session and advise sinks for events that involve the text service,
        /// such as change of focus, keystrokes, and window events. It also customizes the language bar for the text service.
        /// The corresponding <see cref="Deactivate"/> method that shuts down the text service must release all references to the ptim parameter.
        /// </remarks>
        public HRESULT Activate([In] in ITfThreadMgr ptim, [In] TfClientId tid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ITfThreadMgr, TfClientId, HRESULT>)_vTable[3])(thisPtr, ptim, tid);
            }
        }

        /// <summary>
        /// Deactivates a text service when a user session ends.
        /// </summary>
        /// <returns>
        /// If this method succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// TSF calls this method immediately before releasing its final reference to a text service.
        /// This provides the opportunity to perform operations necessary to shut down the text service.
        /// This method usually unadvises sinks for events that involve the text service.
        /// It can also close any user interface elements of the text service.
        /// Before this method returns, it must release all references to the ptim parameter passed to the text service by the <see cref="Activate"/> method.
        /// </remarks>
        public HRESULT Deactivate()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }
    }
}
