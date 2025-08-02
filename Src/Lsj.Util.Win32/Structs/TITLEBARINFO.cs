using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.ObjectStateConstants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains title bar information.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-titlebarinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TITLEBARINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure.
        /// The caller must set this member to <code>sizeof(TITLEBARINFO)</code>.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The coordinates of the title bar.
        /// These coordinates include all title-bar elements except the window menu.
        /// </summary>
        public RECT rcTitleBar;

        /// <summary>
        /// <para>
        /// An array that receives a value for each element of the title bar.
        /// The following are the title bar elements represented by the array.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Index
        /// </term>
        /// <term>
        /// Title Bar Element
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The title bar itself.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Reserved.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Minimize button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 3
        /// </term>
        /// <term>
        /// Maximize button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// Help button.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 5
        /// </term>
        /// <term>
        /// Close button.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// Each array element is a combination of one or more of the following values.
        /// </para>
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
        /// <para>
        /// <see cref="STATE_SYSTEM_FOCUSABLE"/>
        /// </para>
        /// <para>
        /// 0x00100000
        /// </para>
        /// </term>
        /// <term>
        /// The element can accept the focus.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STATE_SYSTEM_INVISIBLE"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// The element is invisible.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STATE_SYSTEM_OFFSCREEN"/>
        /// </para>
        /// <para>
        /// 0x00010000
        /// </para>
        /// </term>
        /// <term>
        /// The element has no visible representation.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STATE_SYSTEM_UNAVAILABLE"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The element is unavailable.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STATE_SYSTEM_PRESSED"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The element is in the pressed state.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public ByValDWORDArrayStructForSize6 rgstate;
    }
}
