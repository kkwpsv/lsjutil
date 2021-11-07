using Lsj.Util.Win32.Enums;
using System;
using static Lsj.Util.Win32.Enums.EditControlMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Macros
{
    /// <summary>
    /// <para>
    /// Edit Control Macros
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-edit-control-reference-macros"/>
    /// </para>
    /// </summary>
    public static class EditControlMacros
    {
        /// <summary>
        /// <para>
        /// Prevents a single-line edit control from receiving keyboard focus.
        /// You can use this macro or send the <see cref="EM_NOSETFOCUS"/> message explicitly.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/nf-commctrl-edit_nosetfocus"/>
        /// </para>
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the edit control.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="EM_NOSETFOCUS"/> message is ignored if the edit control is not a single-line edit control.
        /// After this message is sent, the effect is permanent.
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This macro may not be supported in future versions of Windows.")]
        public static uint Edit_NoSetFocus(IntPtr hwndCtl) =>
            SendMessage(hwndCtl, (WindowMessages)EM_NOSETFOCUS, UIntPtr.Zero, IntPtr.Zero).SafeToUInt32();

        /// <summary>
        /// Forces a single-line edit control to receive keyboard focus.
        /// You can use this macro or send the <see cref="EM_TAKEFOCUS"/> message explicitly.
        /// </summary>
        /// <param name="hwndCtl">
        /// A handle to the edit control.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The <see cref="EM_TAKEFOCUS"/> message is ignored if the edit control is not a single-line edit control.
        /// If the edit control previously received an <see cref="EM_NOSETFOCUS"/> message,
        /// the edit control will appear to have the focus without actually having it; otherwise, the edit control will receive focus.
        /// </remarks>
        [Obsolete("Intended for internal use; not recommended for use in applications." +
            "This macro may not be supported in future versions of Windows.")]
        public static uint Edit_TakeFocus(IntPtr hwndCtl) =>
            SendMessage(hwndCtl, (WindowMessages)EM_TAKEFOCUS, UIntPtr.Zero, IntPtr.Zero).SafeToUInt32();
    }
}
