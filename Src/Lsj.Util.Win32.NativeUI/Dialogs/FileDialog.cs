using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
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
        protected P<IFileDialog> _dialog;

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

                    if (_dialog.As<IModalWindow>().Show(owner))
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
                    _dialog.As<IUnknown>().Release();
                }
            }
        }

        /// <summary>
        /// Create Dialog
        /// </summary>
        protected abstract P<IFileDialog> CreateDialog();

        private void SetOptions()
        {
            unsafe
            {
                var result = S_OK;
                if (_dialog.Value.GetOptions(out var options))
                {
                    if (IsPickFolders)
                    {
                        options |= FOS_PICKFOLDERS;
                    }
                    if (_dialog.Value.SetOptions(options))
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
                List<LPWSTR> strings = new List<LPWSTR>();
                try
                {
                    if (FileTypes == null || FileTypes.Count == 0)
                    {
                        return;
                    }
                    var result = _dialog.Value.SetFileTypes((uint)FileTypes.Count, FileTypes.Select(x =>
                    {
                        var nameStr = new LPWSTR(x.Name);
                        var specStr = new LPWSTR(x.Pattern);
                        strings.Add(nameStr);
                        strings.Add(specStr);
                        return new COMDLG_FILTERSPEC
                        {
                            pszName = nameStr.Handle,
                            pszSpec = specStr.Handle,
                        };
                    }).ToArray());
                    if (result)
                    {
                        return;
                    }
                    throw Marshal.GetExceptionForHR(result)!;
                }
                finally
                {
                    foreach (var str in strings)
                    {
                        str.Dispose();
                    }
                }
            }
        }

        private void SetTitle()
        {
            unsafe
            {
                var result = S_OK;
                if (Title == null || _dialog.Value.SetTitle(Title))
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
                if (result = _dialog.Value.GetResult(out var shellItemPtr))
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
