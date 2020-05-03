using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.FILEOPENDIALOGOPTIONS;
using static Lsj.Util.Win32.Enums.SIGDN;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// File Dialog
    /// </summary>
    public abstract class FileDialog : BaseDialog<string>
    {
        /// <summary>
        /// dialog
        /// </summary>
        protected IFileDialog _dialog = null;

        /// <summary>
        /// IsPickFolders
        /// </summary>
        public bool IsPickFolders { get; set; }

        /// <summary>
        /// FileTypes
        /// </summary>
        public IList<FileDialogFileTypeItem> FileTypes { get; set; }

        /// <inheritdoc/>
        public override ShowDialogResult ShowDialog(IntPtr owner)
        {
            _dialog = CreateDialog();
            try
            {
                SetOptions();
                SetFileTypes();
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

        /// <summary>
        /// Create Dialog
        /// </summary>
        protected abstract IFileDialog CreateDialog();

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

        private void SetFileTypes()
        {
            var result = S_OK;
            if (FileTypes == null || FileTypes.Count == 0 ||
                _dialog.SetFileTypes((uint)FileTypes.Count, FileTypes.Select(x =>
                new COMDLG_FILTERSPEC
                {
                    pszName = x.Name,
                    pszSpec = x.Pattern
                }).ToArray()))
            {
                return;
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
