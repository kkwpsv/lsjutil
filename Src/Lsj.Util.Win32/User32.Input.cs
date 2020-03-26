using Lsj.Util.Win32.BaseTypes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Retrieves the current double-click time for the mouse.
        /// A double-click is a series of two clicks of the mouse button, the second occurring within a specified time after the first.
        /// The double-click time is the maximum number of milliseconds that may occur between the first and second click of a double-click.
        /// The maximum double-click time is 5000 milliseconds.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdoubleclicktime
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the current double-click time, in milliseconds.
        /// The maximum return value is 5000 milliseconds.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDoubleClickTime", SetLastError = true)]
        public static extern uint GetDoubleClickTime();

        /// <summary>
        /// <para>
        /// Maps OEMASCII codes 0 through 0x0FF into the OEM scan codes and shift states.
        /// The function provides information that allows a program to send OEM text to another program by simulating keyboard input.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-oemkeyscan
        /// </para>
        /// </summary>
        /// <param name="wOemChar">
        /// The ASCII value of the OEM character.
        /// </param>
        /// <returns>
        /// The low-order word of the return value contains the scan code of the OEM character, and the high-order word contains the shift state,
        /// which can be a combination of the following bits.
        /// 1: Either SHIFT key is pressed.
        /// 2: Either CTRL key is pressed.
        /// 4: Either ALT key is pressed.
        /// 8: The Hankaku key is pressed.
        /// 16: Reserved (defined by the keyboard layout driver).
        /// 32: Reserved (defined by the keyboard layout driver).
        /// If the character cannot be produced by a single keystroke using the current keyboard layout, the return value is –1.
        /// </returns>
        /// <remarks>
        /// This function does not provide translations for characters that require CTRL+ALT or dead keys.
        /// Characters not translated by this function must be copied by simulating input using the ALT+ keypad mechanism.
        /// The NUMLOCK key must be off.
        /// This function does not provide translations for characters that cannot be typed with one keystroke using the current keyboard layout,
        /// such as characters with diacritics requiring dead keys.
        /// Characters not translated by this function may be simulated using the ALT+ keypad mechanism.
        /// The NUMLOCK key must be on.
        /// This function is implemented using the <see cref="VkKeyScan"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OemKeyScan", SetLastError = true)]
        public static extern DWORD OemKeyScan([In]WORD wOemChar);

        /// <summary>
        /// <para>
        /// Translates a character to the corresponding virtual-key code and shift state for the current keyboard.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-vkkeyscanw
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be translated into a virtual-key code.
        /// </param>
        /// <returns>
        /// If the function succeeds, the low-order byte of the return value contains the virtual-key code and the high-order byte contains the shift state,
        /// which can be a combination of the following flag bits.
        /// 1: Either SHIFT key is pressed.
        /// 2: Either CTRL key is pressed.
        /// 4: Either ALT key is pressed.
        /// 8: The Hankaku key is pressed.
        /// 16: Reserved (defined by the keyboard layout driver).
        /// 32: Reserved (defined by the keyboard layout driver).
        /// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
        /// </returns>
        /// <remarks>
        /// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout),
        /// the shift state is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
        /// Translations for the numeric keypad (<see cref="VK_NUMPAD0"/> through <see cref="VK_DIVIDE"/>) are ignored.
        /// This function is intended to translate characters into keystrokes from the main keyboard section only. 
        /// For example, the character "7" is translated into <see cref="VK_7"/>, not <see cref="VK_NUMPAD7"/>.
        /// <see cref="VkKeyScan"/> is used by applications that send characters by using the <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages.
        /// </remarks>
        [Obsolete("This function has been superseded by the VkKeyScanEx function." +
            "You can still use VkKeyScan, however, if you do not need to specify a keyboard layout.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "VkKeyScanW", SetLastError = true)]
        public static extern SHORT VkKeyScan([In]WCHAR ch);
    }
}
