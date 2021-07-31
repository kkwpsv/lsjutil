using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Enums.FILEOPENDIALOGOPTIONS;
using static Lsj.Util.Win32.Enums.SIGDN;
using static Lsj.Util.Win32.Ole32;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// File Dialog
    /// </summary>
    public abstract class FileDialog : BaseDialog<string>
    {
        /// <summary>
        /// Dialog
        /// </summary>
        protected unsafe IFileDialog* _dialog = null;

        /// <summary>
        /// IsPickFolders
        /// </summary>
        public bool IsPickFolders { get; set; }

        /// <summary>
        /// FileTypes
        /// </summary>
        public IList<FileDialogFileTypeItem>? FileTypes { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string? Title { get; set; }

        /// <inheritdoc/>
        public override ShowDialogResult ShowDialog(IntPtr owner)
        {
            unsafe
            {
                _dialog = CreateDialog();
                try
                {
                    SetOptions();
                    SetFileTypes();
                    SetTitle();
                    if (_dialog->Show(owner))
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
                    ((IUnknown*)_dialog)->Release();
                }
            }
        }

        /// <summary>
        /// Create Dialog
        /// </summary>
        protected abstract unsafe IFileDialog* CreateDialog();

        private void SetOptions()
        {
            unsafe
            {
                var result = S_OK;
                if (_dialog->GetOptions(out var options))
                {
                    if (IsPickFolders)
                    {
                        options |= FOS_PICKFOLDERS;
                    }
                    if (_dialog->SetOptions(options))
                    {
                        return;
                    }
                }
                throw Marshal.GetExceptionForHR(result)!;
            }
        }

        private void SetFileTypes()
        {
            unsafe
            {
                var result = S_OK;
                if (FileTypes == null || FileTypes.Count == 0 ||
                    _dialog->SetFileTypes((uint)FileTypes.Count, FileTypes.Select(x =>
                    new COMDLG_FILTERSPEC
                    {
                        pszName = x.Name,
                        pszSpec = x.Pattern
                    }).ToArray()))
                {
                    return;
                }
                throw Marshal.GetExceptionForHR(result)!;
            }
        }

        private void SetTitle()
        {
            unsafe
            {
                var result = S_OK;
                if (Title == null || _dialog->SetTitle(Title))
                {
                    return;
                }
                throw Marshal.GetExceptionForHR(result)!;
            }
        }

        private void GetResult()
        {

            unsafe
            {
                var result = S_OK;
                if (result = _dialog->GetResult(out var shellItemPtr))
                {
                    var shellItem = (IShellItem*)shellItemPtr;
                    try
                    {
                        if (result = shellItem->GetDisplayName(SIGDN_FILESYSPATH, out var path))
                        {
                            Result = Marshal.PtrToStringUni(path)!;
                            CoTaskMemFree(path);
                            return;
                        }
                    }
                    finally
                    {
                        ((IUnknown*)shellItem)->Release();
                    }
                }
                throw Marshal.GetExceptionForHR(result)!;
            }
        }
    }
}
