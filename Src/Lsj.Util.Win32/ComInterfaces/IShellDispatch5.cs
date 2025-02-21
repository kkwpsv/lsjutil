using Lsj.Util.Win32.BaseTypes;
using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IShellDispatch4"/> object.
    /// In addition to the properties and methods supported by <see cref="IShellDispatch4"/>,
    /// <see cref="IShellDispatch5"/> adds a method that displays open windows in a 3D stack.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch5"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch5
    {
        IntPtr* _vTable;

        /// <summary>
        /// Displays your open windows in a 3D stack that you can flip through.
        /// </summary>
        /// <returns></returns>
        public HRESULT WindowSwitcher()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[44])(thisPtr);
            }
        }
    }
}
