using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// FileSaveDialog
    /// </summary>
    public class FileSaveDialog : FileDialog
    {
        /// <inheritdoc/>
        protected override unsafe IFileDialog* CreateDialog()
        {
            var result = CoCreateInstance(CLSID_FileSaveDialog, NullRef<IUnknown>(), CLSCTX_INPROC_SERVER, IID_IFileDialog, out var obj);
            if (result)
            {
                return (IFileDialog*)obj;
            }
            else
            {
                throw Marshal.GetExceptionForHR(result);
            }
        }
    }
}
