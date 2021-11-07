using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Extensions;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Macros
{
    /// <summary>
    /// <para>
    /// ComboBox Control Macros
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-combobox-control-reference-macros"/>
    /// </para>
    /// </summary>
    public static class ComboBoxControlMacros
    {
        /// <summary>
        /// Gets the cue banner text displayed in the edit control of a combo box.
        /// Use this macro or send the <see cref="CB_GETCUEBANNER"/> message explicitly.
        /// </summary>
        /// <param name="hwnd">
        /// A handle to the combo box.
        /// </param>
        /// <param name="lpwText">
        /// A pointer to a Unicode string buffer that receives the cue banner text.
        /// The calling application is responsible for allocating the memory for the buffer.
        /// The buffer size must be equal to the length of the cue banner string in WCHARs, plus 1—for the terminating NULL WCHAR.
        /// </param>
        /// <param name="cchText">
        /// The size of the buffer pointed to by <paramref name="lpwText"/> in WCHARs.
        /// </param>
        /// <returns></returns>
        public static bool ComboBox_GetCueBannerText(HWND hwnd, out string lpwText, int cchText)
        {
            var lparam = Marshal.AllocHGlobal(cchText * 2);
            var result = SendMessage(hwnd, (WindowMessages)CB_GETCUEBANNER, lparam.SafeToUIntPtr(), (IntPtr)cchText);
            lpwText = Marshal.PtrToStringUni(lparam);
            Marshal.FreeHGlobal(lparam);
            return result != IntPtr.Zero;
        }
    }
}
