using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
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
        /// Retrieves the current code page.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getkbcodepage
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is an OEM code-page identifier, or it is the default identifier if the registry value is not readable.
        /// For a list of OEM code-page identifiers, see Code Page Identifiers.
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetOEMCP function to retrieve the OEM code-page identifier for the system.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKBCodePage", SetLastError = true)]
        public static extern UINT GetKBCodePage();

        /// <summary>
        /// <para>
        /// Retrieves a string that represents the name of a key.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getkeynametextw
        /// </para>
        /// </summary>
        /// <param name="lParam">
        /// The second parameter of the keyboard message (such as <see cref="WM_KEYDOWN"/>) to be processed.
        /// The function interprets the following bit positions in the <paramref name="lParam"/>.
        /// Bits    Meaning
        /// 16-23   Scan code.
        /// 24      Extended-key flag. Distinguishes some keys on an enhanced keyboard.
        /// 25      "Do not care" bit.
        /// The application calling this function sets this bit to indicate that the function should not distinguish between left and right CTRL and SHIFT keys,
        /// for example.
        /// </param>
        /// <param name="lpString">
        /// The buffer that will receive the key name.
        /// </param>
        /// <param name="cchSize">
        /// The maximum length, in characters, of the key name, including the terminating null character.
        /// (This parameter should be equal to the size of the buffer pointed to by the <paramref name="lpString"/> parameter.)
        /// </param>
        /// <returns>
        /// If the function succeeds, a null-terminated string is copied into the specified buffer, and the return value is the length of the string,
        /// in characters, not counting the terminating null character.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The format of the key-name string depends on the current keyboard layout. The keyboard driver maintains a list of names in the form of character strings for keys with names longer than a single character. The key name is translated according to the layout of the currently installed keyboard, thus the function may give different results for different input locales. The name of a character key is the character itself. The names of dead keys are spelled out in full.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyNameTextW", SetLastError = true)]
        public static extern int GetKeyNameText([In]LONG lParam, [MarshalAs(UnmanagedType.LPWStr)[In]StringBuilder lpString, [In]int cchSize);

        /// <summary>
        /// <para>
        /// Retrieves information about the current keyboard.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getkeyboardtype
        /// </para>
        /// </summary>
        /// <param name="nTypeFlag">
        /// The type of keyboard information to be retrieved. This parameter can be one of the following values.
        /// 0: Keyboard type
        /// 1: Keyboard subtype
        /// 2: The number of function keys on the keyboard
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the requested information.
        /// If the function fails and <paramref name="nTypeFlag"/> is not one, the return value is zero;
        /// zero is a valid return value when <paramref name="nTypeFlag"/> is one (keyboard subtype).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The type may be one of the following values.
        /// 1: IBM PC/XT or compatible (83-key) keyboard
        /// 2: Olivetti "ICO" (102-key) keyboard
        /// 3: IBM PC/AT (84-key) or similar keyboard
        /// 4: IBM enhanced (101- or 102-key) keyboard
        /// 5: Nokia 1050 and similar keyboards
        /// 6: Nokia 9140 and similar keyboards
        /// 7: Japanese keyboard
        /// The subtype is an original equipment manufacturer (OEM)-dependent value.
        /// The application can also determine the number of function keys on a keyboard from the keyboard type.
        /// Following are the number of function keys for each keyboard type.
        /// 1: 10
        /// 2: 12 (sometimes 18)
        /// 3: 10
        /// 4: 12
        /// 5: 10
        /// 6: 24
        /// 7: Hardware dependent and specified by the OEM
        /// When a single USB keyboard is connected to the computer, this function returns the code 81.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardType", SetLastError = true)]
        public static extern int GetKeyboardType([In]int nTypeFlag);

        /// <summary>
        /// <para>
        /// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
        /// To specify a handle to the keyboard layout to use for translating the specified code, use the <see cref="MapVirtualKeyEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-mapvirtualkeyw
        /// </para>
        /// </summary>
        /// <param name="uCode">
        /// The virtual key code or scan code for a key.
        /// How this value is interpreted depends on the value of the <paramref name="uMapType"/> parameter.
        /// </param>
        /// <param name="uMapType">
        /// <see cref="MAPVK_VK_TO_CHAR"/>, <see cref="MAPVK_VK_TO_VSC"/>, <see cref="MAPVK_VSC_TO_VK"/>, <see cref="MAPVK_VSC_TO_VK_EX"/>
        /// </param>
        /// <returns>
        /// The return value is either a scan code, a virtual-key code, or a character value,
        /// depending on the value of <paramref name="uCode"/> and <paramref name="uMapType"/>.
        /// If there is no translation, the return value is zero.
        /// </returns>
        /// <remarks>
        /// An application can use <see cref="MapVirtualKey"/> to translate scan codes to the virtual-key code constants <see cref="VK_SHIFT"/>,
        /// <see cref="VK_CONTROL"/>, and <see cref="VK_MENU"/>, and vice versa.
        /// These translations do not distinguish between the left and right instances of the SHIFT, CTRL, or ALT keys.
        /// An application can get the scan code corresponding to the left or right instance of one of these keys
        /// by calling <see cref="MapVirtualKey"/> with <paramref name="uCode"/> set to one of the following virtual-key code constants.
        /// <see cref="VK_LSHIFT"/>, <see cref="VK_RSHIFT"/>, <see cref="VK_LCONTROL"/>,
        /// <see cref="VK_RCONTROL"/>, <see cref="VK_LMENU"/>, <see cref="VK_RMENU"/>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapVirtualKeyW", SetLastError = true)]
        public static extern UINT MapVirtualKey([In]UINT uCode, [In]MapVirtualKeyTypes uMapType);

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
