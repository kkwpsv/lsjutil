using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// IInputPane2
    /// </summary>
    public unsafe struct IInputPane2
    {
        IntPtr* _vTable;

        public HRESULT TryShow([Out] out BOOLEAN result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[6])(thisPtr, out result);
            }
        }

        public HRESULT TryHide([Out] out BOOLEAN result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[7])(thisPtr, out result);
            }
        }
    }
}
