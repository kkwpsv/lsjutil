using Lsj.Util.Win32.BaseTypes;
using System;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IShellDispatch5"/> object.
    /// In addition to the properties and methods supported by <see cref="IShellDispatch5"/>,
    /// <see cref="IShellDispatch6"/> adds a method that displays the Apps Search pane.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch6"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch6
    {
        nint* _vTable;

        /// <summary>
        /// Displays the Apps Search pane, which normally appears when you begin to type a search term from the Start screen.
        /// </summary>
        /// <returns></returns>
        public HRESULT SearchCommand()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[45])(thisPtr);
            }
        }
    }
}
