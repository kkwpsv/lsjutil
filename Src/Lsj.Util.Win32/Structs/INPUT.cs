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
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="INPUT_KEYBOARD"/> supports nonkeyboard input methods, such as handwriting recognition or voice recognition,
    /// as if it were text input by using the <see cref="KEYEVENTF_UNICODE"/> flag.
    /// For more information, see the remarks section of <see cref="KEYBDINPUT"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT
    {
        /// <summary>
        /// The type of the input event. This member can be one of the following values.
        /// <see cref="INPUT_MOUSE"/>, <see cref="INPUT_KEYBOARD"/>, <see cref="INPUT_HARDWARE"/>
        /// </summary>
        public InputTypes type;

#pragma warning disable IDE1006
        private INPUT_DUMMYUNIONNAME DUMMYUNIONNAME;

        /// <summary>
        /// The information about a simulated mouse event.
        /// </summary>
        public MOUSEINPUT mi
        {
            get => DUMMYUNIONNAME.mi;
            set => DUMMYUNIONNAME.mi = value;
        }

        /// <summary>
        /// The information about a simulated keyboard event.
        /// </summary>
        public KEYBDINPUT ki
        {
            get => DUMMYUNIONNAME.ki;
            set => DUMMYUNIONNAME.ki = value;
        }

        /// <summary>
        /// The information about a simulated hardware event.
        /// </summary>
        public HARDWAREINPUT hi
        {
            get => DUMMYUNIONNAME.hi;
            set => DUMMYUNIONNAME.hi = value;
        }
#pragma warning restore IDE1006

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        private struct INPUT_DUMMYUNIONNAME
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
    }
}
