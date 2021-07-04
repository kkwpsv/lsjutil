using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.Enums.INITCOMMONCONTROLSFlags;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Carries information used to load common control classes from the dynamic-link library (DLL).
    /// This structure is used with the <see cref="InitCommonControlsEx"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-initcommoncontrolsex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The total width of a character is the summation of the A, B, and C spaces.
    /// Either the A or the C space can be negative to indicate underhangs or overhangs.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INITCOMMONCONTROLSEX
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// The set of bit flags that indicate which common control classes will be loaded from the DLL.
        /// This can be a combination of the following values.
        /// <see cref="ICC_ANIMATE_CLASS"/>, <see cref="ICC_BAR_CLASSES"/>, <see cref="ICC_COOL_CLASSES"/>,
        /// <see cref="ICC_DATE_CLASSES"/>, <see cref="ICC_HOTKEY_CLASS"/>, <see cref="ICC_INTERNET_CLASSES"/>,
        /// <see cref="ICC_LINK_CLASS"/>, <see cref="ICC_LISTVIEW_CLASSES"/>, <see cref="ICC_NATIVEFNTCTL_CLASS"/>,
        /// <see cref="ICC_PAGESCROLLER_CLASS"/>, <see cref="ICC_PROGRESS_CLASS"/>, <see cref="ICC_STANDARD_CLASSES"/>,
        /// <see cref="ICC_TAB_CLASSES"/>, <see cref="ICC_TREEVIEW_CLASSES"/>, <see cref="ICC_UPDOWN_CLASS"/>,
        /// <see cref="ICC_USEREX_CLASSES"/>, <see cref="ICC_WIN95_CLASSES"/>
        /// </summary>
        public INITCOMMONCONTROLSFlags dwICC;
    }
}
