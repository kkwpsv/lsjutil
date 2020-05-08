using Lsj.Util.Text;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Ole32;
namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// FileOpenDialog
    /// </summary>
    public class FileOpenDialog : FileDialog
    {
        /// <inheritdoc/>
        protected override IFileDialog CreateDialog()
        {
            var result = CoCreateInstance(CLSID_FileOpenDialog.ToGuid(), null, CLSCTX_INPROC_SERVER, IID_IUnknown.ToGuid(), out var obj);
            if (result)
            {
                return obj as IFileDialog;
            }
            else
            {
                throw Marshal.GetExceptionForHR(result);
            }
        }
    }
}
