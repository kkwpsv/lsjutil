using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ObjectStateConstants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains combo box status information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-comboboxinfo"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// The following example code retrieves information about the combo box specified by the window handle.
    /// </para>
    /// <code>
    /// COMBOBOXINFO info = { sizeof(COMBOBOXINFO) };
    /// GetComboBoxInfo(hwnd, &amp;info);
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMBOBOXINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// The calling application must set this to <c>sizeof(COMBOBOXINFO)</c>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// A <see cref="RECT"/> structure that specifies the coordinates of the edit box.
        /// </summary>
        public RECT rcItem;

        /// <summary>
        /// A <see cref="RECT"/> structure that specifies the coordinates of the button that contains the drop-down arrow.
        /// </summary>
        public RECT rcButton;

        /// <summary>
        /// <para>
        /// The combo box button state. This parameter can be one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The button exists and is not pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATE_SYSTEM_INVISIBLE"/>
        /// </term>
        /// <term>
        /// There is no button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="STATE_SYSTEM_PRESSED"/>
        /// </term>
        /// <term>
        /// The button is pressed.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public DWORD stateButton;

        /// <summary>
        /// A handle to the combo box.
        /// </summary>
        public HWND hwndCombo;

        /// <summary>
        /// A handle to the edit box.
        /// </summary>
        public HWND hwndItem;

        /// <summary>
        /// A handle to the drop-down list.
        /// </summary>
        public HWND hwndList;
    }
}
