using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.WindowsRuntimeInterfaces
{
    /// <summary>
    /// <para>
    /// IInputPane2
    /// </para>
    /// <para>
    /// Interface of InputPane, See: <see href="https://learn.microsoft.com/en-us/uwp/api/windows.ui.viewmanagement.inputpane"/>
    /// </para>
    /// </summary>
    [WindowsVersionRequirement(WindowsVersion.Windows10, BuildNumbers.Windows10_1507)]
    [ComInterface(BeginVTableSlotIndex = 6, EndVTableSlotIndex = 7, IID = "8a6b3f26-7090-4793-944c-c3f2cde26276",
        InheritedFromTypes = [typeof(IUnknown), typeof(IInspectable)])]
    public unsafe struct IInputPane2
    {
        IntPtr* _vTable;

        /// <summary>
        /// TryShow
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public HRESULT TryShow([Out] out BOOLEAN result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[6])(thisPtr, out result);
            }
        }

        /// <summary>
        /// TryHide
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public HRESULT TryHide([Out] out BOOLEAN result)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out BOOLEAN, HRESULT>)_vTable[7])(thisPtr, out result);
            }
        }
    }
}
