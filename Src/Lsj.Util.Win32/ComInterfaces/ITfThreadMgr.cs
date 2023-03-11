using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// The <see cref="ITfThreadMgr"/> defines the primary object implemented by the TSF manager.
    /// <see cref="ITfThreadMgr"/> is used by applications and text services to activate and deactivate text services,
    /// create document managers, and maintain the document context focus.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/msctf/nn-msctf-itfthreadmgr"/>
    /// </para>
    /// </summary>
    public unsafe struct ITfThreadMgr
    {
        IntPtr* _vTable;

        /// <summary>
        /// Activates TSF for the calling thread.
        /// </summary>
        /// <param name="ptid">
        /// Pointer to a <see cref="TfClientId"/> value that receives a client identifier.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_INVALIDARG"/>: <paramref name="ptid"/> is invalid.
        /// <see cref="E_UNEXPECTED"/>: This method was called while the thread was deactivating.
        /// </returns>
        /// <remarks>
        /// This method can be called more than once from a thread,
        /// but each call must be matched with a corresponding call to <see cref="Deactivate"/> from the same thread.
        /// </remarks>
        public HRESULT Activate([Out] out TfClientId ptid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out TfClientId, HRESULT>)_vTable[3])(thisPtr, out ptid);
            }
        }

        /// <summary>
        /// Deactivates TSF for the calling thread.
        /// </summary>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_UNEXPECTED"/>： This method was called while the thread was activating or this call had no corresponding <see cref="Activate"/> call.
        /// </returns>
        /// <remarks>
        /// Each call to this method must be matched with a previous call to <see cref="Activate"/>.
        /// This method must be called from the same thread that the corresponding <see cref="Activate"/> call was made from.
        /// </remarks>
        public HRESULT Deactivate()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        /// <summary>
        /// Creates a document manager object.
        /// </summary>
        /// <param name="ppdim">
        /// Pointer to an <see cref="ITfDocumentMgr"/> interface that receives the document manager object.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_INVALIDARG"/>: <paramref name="ppdim"/> is invalid.
        /// <see cref="E_OUTOFMEMORY"/>: A memory allocation failure occurred.
        /// </returns>
        /// <remarks>
        /// The caller must release the document manager when it is no longer required.
        /// </remarks>
        public HRESULT CreateDocumentMgr([Out] out P<ITfDocumentMgr> ppdim)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITfDocumentMgr>, HRESULT>)_vTable[5])(thisPtr, out ppdim);
            }
        }

        /// <summary>
        /// Returns the document manager that has the input focus.
        /// </summary>
        /// <param name="ppdimFocus">
        /// Pointer to a <see cref="ITfDocumentMgr"/> interface that receives the document manager with the current input focus.
        /// Receives <see cref="NULL"/> if no document manager has the focus.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="S_FALSE"/>: No document manager has focus. <paramref name="ppdimFocus"/> be set to <see cref="NULL"/>.
        /// <see cref="E_INVALIDARG"/>: <paramref name="ppdimFocus"/> is invalid.
        /// </returns>
        public HRESULT GetFocus([Out] out P<ITfDocumentMgr> ppdimFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITfDocumentMgr>, HRESULT>)_vTable[7])(thisPtr, out ppdimFocus);
            }
        }

        /// <summary>
        /// Sets the input focus to the specified document manager.
        /// </summary>
        /// <param name="ppdimFocus">
        /// Pointer to a <see cref="ITfDocumentMgr"/> interface that receives the input focus.
        /// This parameter cannot be <see cref="NullRef{ITfDocumentMgr}"/>.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_INVALIDARG"/>: <paramref name="ppdimFocus"/> is invalid.
        /// </returns>
        /// <remarks>
        /// The application must call this method when the document window receives the input focus.
        /// If the application associates a window with a document manager using <see cref="ITfThreadMgr.AssociateFocus"/>,
        /// the TSF manager calls this method for the application.
        /// </remarks>
        public HRESULT SetFocus([In] in ITfDocumentMgr ppdimFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ITfDocumentMgr, HRESULT>)_vTable[8])(thisPtr, ppdimFocus);
            }
        }

        /// <summary>
        /// Associates the focus for a window with a document manager object.
        /// </summary>
        /// <param name="hwnd">
        /// Handle of the window to associate the focus with.
        /// </param>
        /// <param name="pdimNew">
        /// Pointer to the document manager to associate the focus with.
        /// The TSF manager does not increment the object reference count.
        /// This value can be <see cref="NullRef{ITfDocumentMgr}"/>.
        /// </param>
        /// <param name="ppdimPrev">
        /// Receives the document manager previously associated with the window.
        /// Receives <see cref="NULL"/> if there is no previous association.
        /// This parameter cannot be NULL.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_INVALIDARG"/>: One or more parameters are invalid.
        /// </returns>
        /// <remarks>
        /// This method is provided as a convenience to the application developer.
        /// Associating the focus for a window with a document manager causes the TSF manager to automatically
        /// call <see cref="SetFocus"/> with the associated document manager when the associated window receives the focus.
        /// This method can only associate a single window with a single document manager.
        /// If the implementation associates multiple document managers with a single window, or the opposite,
        /// the implementation must call <see cref="SetFocus"/> to set the focus to the proper document manager.
        /// To restore the previous focus association, call this method with the same window handle
        /// and the value returned in the original call <paramref name="ppdimPrev"/> for <paramref name="pdimNew"/>.
        /// The following is an example.
        /// <code>
        /// //associate the focus for m_hwnd with m_pDocMgr 
        /// pThreadMgr->AssociateFocus(m_hwnd, m_pDocMgr, &amp;m_pPrevDocMgr);
        /// 
        /// //Restore the original focus association. 
        /// ITfDocumentMgr *pTempDocMgr = NULL;
        /// 
        /// pThreadMgr->AssociateFocus(m_hwnd, m_pPrevDocMgr, &amp;pTempDocMgr);
        /// 
        /// if(pTempDocMgr)
        /// {
        ///     pTempDocMgr->Release();
        /// }
        /// 
        /// if(m_pPrevDocMgr)
        /// {
        ///     m_pPrevDocMgr->Release();
        /// }
        /// </code>
        /// </remarks>
        public HRESULT AssociateFocus([In] HWND hwnd, [In] in ITfDocumentMgr pdimNew, [Out] out P<ITfDocumentMgr> ppdimPrev)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HWND, in ITfDocumentMgr, out P<ITfDocumentMgr>, HRESULT>)_vTable[9])(thisPtr, hwnd, pdimNew, out ppdimPrev);
            }
        }

        /// <summary>
        /// Determines if the calling thread has the TSF input focus.
        /// </summary>
        /// <param name="pfThreadFocus">
        /// Pointer to a <see cref="BOOL"/> that receives a value that indicates if the calling thread has input focus.
        /// This parameter receives a nonzero value if the calling thread has the focus or zero otherwise.
        /// </param>
        /// <returns>
        /// This method can return one of these values.
        /// <see cref="S_OK"/>: The method was successful.
        /// <see cref="E_INVALIDARG"/>: <paramref name="pfThreadFocus"/> is invalid.
        /// </returns>
        public HRESULT IsThreadFocus([Out] out BOOL pfThreadFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOL, HRESULT>)_vTable[10])(thisPtr, out pfThreadFocus);
            }
        }
    }
}
