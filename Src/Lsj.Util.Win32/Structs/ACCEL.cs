using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.AcceleratorBehaviors;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines an accelerator key used in an accelerator table.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-accel"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCEL
    {
        /// <summary>
        /// <para>
        /// The accelerator behavior.
        /// This member can be one or more of the following values.
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
        /// <see cref="FALT"/>
        /// </para>
        /// <para>
        /// 0x10
        /// </para>
        /// </term>
        /// <term>
        /// The ALT key must be held down when the accelerator key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FCONTROL"/>
        /// </para>
        /// <para>
        /// 0x08
        /// </para>
        /// </term>
        /// <term>
        /// The CTRL key must be held down when the accelerator key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FNOINVERT"/>
        /// </para>
        /// <para>
        /// 0x02
        /// </para>
        /// </term>
        /// <term>
        /// No top-level menu item is highlighted when the accelerator is used.
        /// If this flag is not specified, a top-level menu item will be highlighted, if possible, when the accelerator is used.
        /// This attribute is obsolete and retained only for backward compatibility with resource files designed for 16-bit Windows.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FSHIFT"/>
        /// </para>
        /// <para>
        /// 0x04
        /// </para>
        /// </term>
        /// <term>
        /// The SHIFT key must be held down when the accelerator key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="FVIRTKEY"/>
        /// </para>
        /// <para>
        /// TRUE
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="key"/> member specifies a virtual-key code.
        /// If this flag is not specified, <see cref="key"/> is assumed to specify a character code.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public AcceleratorBehaviors fVirt;

        /// <summary>
        /// The accelerator key.
        /// This member can be either a virtual-key code or a character code.
        /// </summary>
        public WORD key;

        /// <summary>
        /// The accelerator identifier.
        /// This value is placed in the low-order word of the wParam parameter of the <see cref="WM_COMMAND"/>
        /// or <see cref="WM_SYSCOMMAND"/> message when the accelerator is pressed.
        /// </summary>
        public WORD cmd;
    }
}
