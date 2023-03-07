using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.ComInterfaces
{
    public unsafe struct ITfThreadMgr
    {
        IntPtr* _vTable;

        public HRESULT Activate([Out] out TfClientId ptid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out TfClientId, HRESULT>)_vTable[3])(thisPtr, out ptid);
            }
        }

        public HRESULT Deactivate()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[4])(thisPtr);
            }
        }

        public HRESULT CreateDocumentMgr([Out] out P<ITfDocumentMgr> ppdim)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITfDocumentMgr>, HRESULT>)_vTable[5])(thisPtr, out ppdim);
            }
        }

        public HRESULT GetFocus([Out] out P<ITfDocumentMgr> ppdimFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<ITfDocumentMgr>, HRESULT>)_vTable[7])(thisPtr, out ppdimFocus);
            }
        }

        public HRESULT SetFocus([In] in ITfDocumentMgr ppdimFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in ITfDocumentMgr, HRESULT>)_vTable[8])(thisPtr, ppdimFocus);
            }
        }

        public HRESULT IsThreadFocus([Out] out BOOL pfThreadFocus)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOL, HRESULT>)_vTable[10])(thisPtr, out pfThreadFocus);
            }
        }
    }
}
