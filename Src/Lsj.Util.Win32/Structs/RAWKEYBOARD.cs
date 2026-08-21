using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the state of the keyboard.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-rawkeyboard"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="KEYBOARD_OVERRUN_MAKE_CODE"/> is a special <see cref="MakeCode"/> value sent
    /// when an invalid or unrecognizable combination of keys is pressed
    /// or the number of keys pressed exceeds the limit for this keyboard.
    /// </para>
    /// <code>
    /// case WM_INPUT:
    /// {
    ///     UINT dwSize = sizeof(RAWINPUT);
    ///     static BYTE lpb[sizeof(RAWINPUT)];
    /// 
    ///     GetRawInputData((HRAWINPUT)lParam, RID_INPUT, lpb, &amp;dwSize, sizeof(RAWINPUTHEADER));
    /// 
    ///     RAWINPUT* raw = (RAWINPUT*)lpb;
    /// 
    ///     if (raw-&gt;header.dwType == RIM_TYPEKEYBOARD)
    ///     {
    ///         RAWKEYBOARD&amp; keyboard = raw-&gt;data.keyboard;
    ///         WORD scanCode = 0;
    ///         BOOL keyUp = keyboard.Flags &amp; RI_KEY_BREAK;
    /// 
    ///         // Ignore key overrun state and keys not mapped to any virtual key code
    ///         if (keyboard.MakeCode == KEYBOARD_OVERRUN_MAKE_CODE || keyboard.VKey &gt;= UCHAR_MAX)
    ///             return 0;
    /// 
    ///         if (keyboard.MakeCode)
    ///         {
    ///             // Compose the full scan code value with its extended byte
    ///             scanCode = MAKEWORD(keyboard.MakeCode &amp; 0x7f, ((keyboard.Flags &amp; RI_KEY_E0) ? 0xe0 : ((keyboard.Flags &amp; RI_KEY_E1) ? 0xe1 : 0x00)));
    ///         }
    ///         else
    ///         {
    ///             // Scan code value may be empty for some buttons (for example multimedia buttons)
    ///             // Try to get the scan code from the virtual key code
    ///             scanCode = LOWORD(MapVirtualKey(keyboard.VKey, MAPVK_VK_TO_VSC_EX));
    ///         }
    /// 
    ///         // Get the key name for debug output
    ///         TCHAR keyNameBuffer[MAX_PATH] = {};
    ///         GetKeyNameText((LONG)MAKELPARAM(0, (HIBYTE(scanCode) ? KF_EXTENDED : 0x00) | LOBYTE(scanCode)), keyNameBuffer, MAX_PATH);
    /// 
    ///         // Debug output
    ///         TCHAR printBuffer[MAX_PATH] = {};
    ///         StringCchPrintf(printBuffer, MAX_PATH, TEXT("Keyboard: scanCode=%04x keyName=%s\r\n"), scanCode, keyNameBuffer);
    ///         OutputDebugString(printBuffer);
    ///     }
    ///     ...
    /// 
    ///     return 0;
    /// }
    /// </code>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RAWKEYBOARD
    {
        /// <summary>
        /// Specifies the scan code associated with a key press.
        /// See Remarks.
        /// </summary>
        public USHORT MakeCode;

        /// <summary>
        /// <para>
        /// Flags for scan code information.
        /// It can be one or more of the following:
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
        /// <see cref="RI_KEY_MAKE"/> 0
        /// </term>
        /// <term>
        /// The key is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RI_KEY_BREAK"/> 1
        /// </term>
        /// <term>
        /// The key is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RI_KEY_E0"/> 2
        /// </term>
        /// <term>
        /// The scan code has the E0 prefix.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="RI_KEY_E1"/> 4
        /// </term>
        /// <term>
        /// The scan code has the E1 prefix.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public USHORT Flags;

        /// <summary>
        /// Reserved; must be zero.
        /// </summary>
        public USHORT Reserved;

        /// <summary>
        /// The corresponding legacy virtual-key code.
        /// </summary>
        public VirtualKeyCodes VKey;

        /// <summary>
        /// The corresponding legacy keyboard window message,
        /// for example <see cref="WM_KEYDOWN"/>, <see cref="WM_SYSKEYDOWN"/>, and so forth.
        /// </summary>
        public WindowMessages Message;

        /// <summary>
        /// The device-specific additional information for the event.
        /// </summary>
        public ULONG ExtraInformation;
    }
}
