using Lsj.Util.Text;
using Lsj.Util.Win32.ComInterfaces;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.ComInterfaces.CLSIDs;
using static Lsj.Util.Win32.ComInterfaces.IIDs;
using static Lsj.Util.Win32.Enums.CLSCTX;
using static Lsj.Util.Win32.Enums.FILEOPENDIALOGOPTIONS;
using static Lsj.Util.Win32.Enums.SIGDN;
using static Lsj.Util.Win32.Ole32;
using static Lsj.Util.Win32.Structs.HRESULT;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    public class FileOpenDialog : BaseDialog<string>
    {
        IFileDialog _dialog = null;

        /// <summary>
        /// IsPickFolders
        /// </summary>
        public bool IsPickFolders { get; set; }

        public override ShowDialogResult ShowDialog(IntPtr owner)
        {
            CreateDialog();
            try
            {
                SetOptions();
                if (_dialog.Show(owner))
                {
                    GetResult();
                    return ShowDialogResult.OK;
                }
                else
                {
                    return ShowDialogResult.Cancel;
                }
            }
            finally
            {
                Marshal.ReleaseComObject(_dialog);
            }
        }

        private void CreateDialog()
        {
            var result = CoCreateInstance(CLSID_FileOpenDialog.ToGuid(), null, CLSCTX_INPROC_SERVER, IID_IUnknown.ToGuid(), out var obj);
            if (result)
            {
                _dialog = obj as IFileDialog;
            }
            else
            {
                throw Marshal.GetExceptionForHR(result);
            }
        }

        private void SetOptions()
        {
            var result = S_OK;
            if (_dialog.GetOptions(out var options))
            {
                if (IsPickFolders)
                {
                    options |= FOS_PICKFOLDERS;
                }
                if (_dialog.SetOptions(options))
                {
                    return;
                }
            }
            throw Marshal.GetExceptionForHR(result);
        }

        private void GetResult()
        {
            var result = S_OK;
            if (result = _dialog.GetResult(out var shellItem))
            {
                try
                {
                    if (result = shellItem.GetDisplayName(SIGDN_FILESYSPATH, out var path))
                    {
                        Result = path;
                        return;
                    }
                }
                finally
                {
                    Marshal.ReleaseComObject(shellItem);
                }
            }
            throw Marshal.GetExceptionForHR(result);
        }
    }
}
