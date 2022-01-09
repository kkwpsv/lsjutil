using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.InputTypes;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used by <see cref="SendInput"/> to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-input"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="INPUT_KEYBOARD"/> supports nonkeyboard input methods, such as handwriting recognition or voice recognition,
    /// as if it were text input by using the <see cref="KEYEVENTF_UNICODE"/> flag.
    /// For more information, see the remarks section of <see cref="KEYBDINPUT"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct INPUT
    {
        /// <summary>
        /// The type of the input event. This member can be one of the following values.
        /// <see cref="INPUT_MOUSE"/>, <see cref="INPUT_KEYBOARD"/>, <see cref="INPUT_HARDWARE"/>
        /// </summary>
        [FieldOffset(0)]
        public InputTypes type;

        /// <summary>
        /// The information about a simulated mouse event.
        /// </summary>
        [FieldOffset(0)]
        public MOUSEINPUT mi;

        /// <summary>
        /// The information about a simulated keyboard event.
        /// </summary>
        [FieldOffset(0)]
        public KEYBDINPUT ki;

        /// <summary>
        /// The information about a simulated hardware event.
        /// </summary>
        [FieldOffset(0)]
        public HARDWAREINPUT hi;

    }
}
