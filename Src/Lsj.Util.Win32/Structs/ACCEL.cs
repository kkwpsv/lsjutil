using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.AcceleratorBehaviors;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Defines an accelerator key used in an accelerator table.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-accel
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCEL
    {
        /// <summary>
        /// The accelerator behavior. This member can be one or more of the following values.
        /// <see cref="FALT"/>, <see cref="FCONTROL"/>, <see cref="FNOINVERT"/>, <see cref="FSHIFT"/>, <see cref="FVIRTKEY"/>
        /// </summary>
        public AcceleratorBehaviors fVirt;

        /// <summary>
        /// The accelerator key. This member can be either a virtual-key code or a character code.
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
