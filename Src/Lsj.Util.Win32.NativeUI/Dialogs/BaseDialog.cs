using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// Base Dialog
    /// </summary>
    public abstract class BaseDialog
    {
        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <returns></returns>
        public virtual ShowDialogResult ShowDialog() => ShowDialog(IntPtr.Zero);

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="owner">Owner Handle</param>
        /// <returns></returns>
        public abstract ShowDialogResult ShowDialog(IntPtr owner);
    }

    /// <summary>
    /// Base Dialog With Result
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class BaseDialog<TResult> : BaseDialog
    {
        /// <summary>
        /// Result
        /// </summary>
        public virtual TResult Result { get; protected set; }
    }
}
