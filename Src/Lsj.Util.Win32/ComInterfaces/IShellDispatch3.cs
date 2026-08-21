using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IShellDispatch2"/> object.
    /// <see cref="IShellDispatch3"/> supports one new method in addition to the properties and methods supported by <see cref="IShellDispatch2"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-object"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch3
    {
        nint* _vTable;

        /// <summary>
        /// Adds a file to the most recently used (MRU) list.
        /// </summary>
        /// <param name="varFile">
        /// A String that contains the path of the file to add to the list of recently used documents.
        /// Windows Vista: Set this parameter to null to clear the recent documents folder.
        /// </param>
        /// <param name="bstrCategory"></param>
        /// <returns></returns>
        public HRESULT AddToRecent([In] VARIANT varFile, [In] BSTR bstrCategory)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, VARIANT, BSTR, HRESULT>)_vTable[39])(thisPtr, varFile, bstrCategory);
            }
        }
    }
}
