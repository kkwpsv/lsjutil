using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.InputTypes;
using static Lsj.Util.Win32.Enums.KeyEventFlags;
using static Lsj.Util.Win32.Enums.VirtualKeyCodes;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a simulated keyboard event.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-keybdinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="INPUT_KEYBOARD"/> supports nonkeyboard-input methods—such as handwriting recognition or voice recognition—
    /// as if it were text input by using the <see cref="KEYEVENTF_UNICODE"/> flag.
    /// If <see cref="KEYEVENTF_UNICODE"/> is specified, <see cref="SendInput"/> sends a <see cref="WM_KEYDOWN"/> or <see cref="WM_KEYUP"/> message
    /// to the foreground thread's message queue with wParam equal to <see cref="VK_PACKET"/>.
    /// Once <see cref="GetMessage"/> or <see cref="PeekMessage"/> obtains this message, passing the message to <see cref="TranslateMessage"/>
    /// posts a <see cref="WM_CHAR"/> message with the Unicode character originally specified by <see cref="wScan"/>.
    /// This Unicode character will automatically be converted to the appropriate ANSI value if it is posted to an ANSI window.
    /// Set the <see cref="KEYEVENTF_SCANCODE"/> flag to define keyboard input in terms of the scan code.
    /// This is useful to simulate a physical keystroke regardless of which keyboard is currently being used.
    /// The virtual key value of a key may alter depending on the current keyboard layout or what other keys were pressed,
    /// but the scan code will always be the same.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct KEYBDINPUT
    {
        /// <summary>
        /// A virtual-key code.
        /// The code must be a value in the range 1 to 254.
        /// If the <see cref="dwFlags"/> member specifies <see cref="KEYEVENTF_UNICODE"/>, <see cref="wVk"/> must be 0.
        /// </summary>
        public VirtualKeyCodes wVk;

        /// <summary>
        /// A hardware scan code for the key.
        /// If <see cref="dwFlags"/> specifies <see cref="KEYEVENTF_UNICODE"/>, <see cref="wScan"/> specifies a Unicode character
        /// which is to be sent to the foreground application.
        /// </summary>
        public WORD wScan;

        /// <summary>
        /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
        /// <see cref="KEYEVENTF_EXTENDEDKEY"/>:
        /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
        /// <see cref="KEYEVENTF_KEYUP"/>:
        /// If specified, the key is being released.
        /// If not specified, the key is being pressed.
        /// <see cref="KEYEVENTF_SCANCODE"/>:
        /// If specified, <see cref="wScan"/> identifies the key and <see cref="wVk"/> is ignored.
        /// <see cref="KEYEVENTF_UNICODE"/>:
        /// If specified, the system synthesizes a <see cref="VK_PACKET"/> keystroke.
        /// The <see cref="wVk"/> parameter must be zero.
        /// This flag can only be combined with the <see cref="KEYEVENTF_KEYUP"/> flag.
        /// For more information, see the Remarks section.
        /// </summary>
        public KeyEventFlags dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// If this parameter is zero, the system will provide its own time stamp.
        /// </summary>
        public DWORD time;

        /// <summary>
        /// An additional value associated with the keystroke.
        /// Use the <see cref="GetMessageExtraInfo"/> function to obtain this information.
        /// </summary>
        public ULONG_PTR dwExtraInfo;
    }
}
