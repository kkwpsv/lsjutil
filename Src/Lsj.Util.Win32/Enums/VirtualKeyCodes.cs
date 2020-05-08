using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.WindowsMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Virtual Key Codes
    /// The following table shows the symbolic constant names, hexadecimal values, and mouse or keyboard equivalents
    /// for the virtual-key codes used by the system.
    /// The codes are listed in numeric order.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/inputdev/virtual-key-codes
    /// </para>
    /// </summary>
    public enum VirtualKeyCodes : ushort
    {
        /// <summary>
        /// Left mouse button
        /// </summary>
        VK_LBUTTON = 0x01,

        /// <summary>
        /// Right mouse button
        /// </summary>
        VK_RBUTTON = 0x02,

        /// <summary>
        /// Control-break processing
        /// </summary>
        VK_CANCEL = 0x03,

        /// <summary>
        /// Middle mouse button (three-button mouse)
        /// </summary>
        VK_MBUTTON = 0x04,

        /// <summary>
        /// X1 mouse button
        /// </summary>
        VK_XBUTTON1 = 0x05,

        /// <summary>
        /// X2 mouse button
        /// </summary>
        VK_XBUTTON2 = 0x06,

        /// <summary>
        /// BACKSPACE key
        /// </summary>
        VK_BACK = 0x08,

        /// <summary>
        /// TAB key
        /// </summary>
        VK_TAB = 0x09,

        /// <summary>
        /// CLEAR key
        /// </summary>
        VK_CLEAR = 0x0C,

        /// <summary>
        /// ENTER key
        /// </summary>
        VK_RETURN = 0x0D,

        /// <summary>
        /// SHIFT key
        /// </summary>
        VK_SHIFT = 0x10,

        /// <summary>
        /// CTRL key
        /// </summary>
        VK_CONTROL = 0x11,

        /// <summary>
        /// ALT key
        /// </summary>
        VK_MENU = 0x12,

        /// <summary>
        /// PAUSE Key
        /// </summary>
        VK_PAUSE = 0x13,

        /// <summary>
        /// CAPS LOCK key
        /// </summary>
        VK_CAPITAL = 0x14,

        /// <summary>
        /// IME Kana mode
        /// </summary>
        VK_KANA = 0x15,

        /// <summary>
        /// IME Hanguel mode (maintained for compatibility; use <see cref="VK_HANGUL"/>)
        /// </summary>
        VK_HANGEUL = 0x15,

        /// <summary>
        /// IME Hangul mode
        /// </summary>
        VK_HANGUL = 0x15,

        /// <summary>
        /// IME On
        /// </summary>
        VK_IME_ON = 0x16,

        /// <summary>
        /// IME Junja mode
        /// </summary>
        VK_JUNJA = 0x17,

        /// <summary>
        /// IME final mode
        /// </summary>
        VK_FINAL = 0x18,

        /// <summary>
        /// IME Hanja mode
        /// </summary>
        VK_HANJA = 0x19,

        /// <summary>
        /// IME Kanji mode
        /// </summary>
        VK_KANJI = 0x19,

        /// <summary>
        /// IME Off
        /// </summary>
        VK_IME_OFF = 0x1A,

        /// <summary>
        /// ESC key
        /// </summary>
        VK_ESCAPE = 0x1B,

        /// <summary>
        /// IME convert
        /// </summary>
        VK_CONVERT = 0x1C,

        /// <summary>
        /// IME nonconvert
        /// </summary>
        VK_NONCONVERT = 0x1D,

        /// <summary>
        /// IME accept
        /// </summary>
        VK_ACCEPT = 0x1E,

        /// <summary>
        /// IME mode change request
        /// </summary>
        VK_MODECHANGE = 0x1F,

        /// <summary>
        /// SPACEBAR
        /// </summary>
        VK_SPACE = 0x20,

        /// <summary>
        /// PAGE UP key
        /// </summary>
        VK_PRIOR = 0x21,

        /// <summary>
        /// PAGE DOWN key
        /// </summary>
        VK_NEXT = 0x22,

        /// <summary>
        /// END key
        /// </summary>
        VK_END = 0x23,

        /// <summary>
        /// HOME Key
        /// </summary>
        VK_HOME = 0x24,

        /// <summary>
        /// LEFT ARROW key
        /// </summary>
        VK_LEFT = 0x25,

        /// <summary>
        /// UP ARROW key
        /// </summary>
        VK_UP = 0x26,

        /// <summary>
        /// RIGHT ARROW key
        /// </summary>
        VK_RIGHT = 0x27,

        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        VK_DOWN = 0x28,

        /// <summary>
        /// SELECT key
        /// </summary>
        VK_SELECT = 0x29,

        /// <summary>
        /// PRINT key
        /// </summary>
        VK_PRINT = 0x2A,

        /// <summary>
        /// EXECUTE key
        /// </summary>
        VK_EXECUTE = 0x2B,

        /// <summary>
        /// PRINT SCREEN key
        /// </summary>
        VK_SNAPSHOT = 0x2C,

        /// <summary>
        /// INS key
        /// </summary>
        VK_INSERT = 0x2D,

        /// <summary>
        /// DEL Key
        /// </summary>
        VK_DELETE = 0x2E,

        /// <summary>
        /// HELP Key
        /// </summary>
        VK_HELP = 0x2F,

        /// <summary>
        /// 0
        /// </summary>
        VK_0 = 0x30,

        /// <summary>
        /// 1
        /// </summary>
        VK_1 = 0x31,

        /// <summary>
        /// 2
        /// </summary>
        VK_2 = 0x32,

        /// <summary>
        /// 3
        /// </summary>
        VK_3 = 0x33,

        /// <summary>
        /// 4
        /// </summary>
        VK_4 = 0x34,

        /// <summary>
        /// 5
        /// </summary>
        VK_5 = 0x35,

        /// <summary>
        /// 6
        /// </summary>
        VK_6 = 0x36,

        /// <summary>
        /// 7
        /// </summary>
        VK_7 = 0x37,

        /// <summary>
        /// 8
        /// </summary>
        VK_8 = 0x38,

        /// <summary>
        /// 9
        /// </summary>
        VK_9 = 0x39,

        /// <summary>
        /// Left Windows key (Natural keyboard)
        /// </summary>
        VK_LWIN = 0x5B,

        /// <summary>
        /// Right Windows key (Natural keyboard)
        /// </summary>
        VK_RWIN = 0x5C,

        /// <summary>
        /// Applications key (Natural keyboard)
        /// </summary>
        VK_APPS = 0x5D,

        /// <summary>
        /// Computer Sleep key
        /// </summary>
        VK_SLEEP = 0x5F,

        /// <summary>
        /// Numeric keypad 0 key
        /// </summary>
        VK_NUMPAD0 = 0x60,

        /// <summary>
        /// Numeric keypad 1 key
        /// </summary>
        VK_NUMPAD1 = 0x61,

        /// <summary>
        /// Numeric keypad 2 key
        /// </summary>
        VK_NUMPAD2 = 0x62,

        /// <summary>
        /// Numeric keypad 3 key
        /// </summary>
        VK_NUMPAD3 = 0x63,

        /// <summary>
        /// Numeric keypad 4 key
        /// </summary>
        VK_NUMPAD4 = 0x64,

        /// <summary>
        /// Numeric keypad 5 key
        /// </summary>
        VK_NUMPAD5 = 0x65,

        /// <summary>
        /// Numeric keypad 6 key
        /// </summary>
        VK_NUMPAD6 = 0x66,

        /// <summary>
        /// Numeric keypad 7 key
        /// </summary>
        VK_NUMPAD7 = 0x67,

        /// <summary>
        /// Numeric keypad 8 key
        /// </summary>
        VK_NUMPAD8 = 0x68,

        /// <summary>
        /// Numeric keypad 9 key
        /// </summary>
        VK_NUMPAD9 = 0x69,

        /// <summary>
        /// Multiply key
        /// </summary>
        VK_MULTIPLY = 0x6A,

        /// <summary>
        /// Add key
        /// </summary>
        VK_ADD = 0x6B,

        /// <summary>
        /// Separator key
        /// </summary>
        VK_SEPARATOR = 0x6C,

        /// <summary>
        /// Subtract key
        /// </summary>
        VK_SUBTRACT = 0x6D,

        /// <summary>
        /// Decimal key
        /// </summary>
        VK_DECIMAL = 0x6E,

        /// <summary>
        /// Divide key
        /// </summary>
        VK_DIVIDE = 0x6F,

        /// <summary>
        /// F1 key
        /// </summary>
        VK_F1 = 0x70,

        /// <summary>
        /// F2 key
        /// </summary>
        VK_F2 = 0x71,

        /// <summary>
        /// F3 key
        /// </summary>
        VK_F3 = 0x72,

        /// <summary>
        /// F4 key
        /// </summary>
        VK_F4 = 0x73,

        /// <summary>
        /// F5 key
        /// </summary>
        VK_F5 = 0x74,

        /// <summary>
        /// F6 key
        /// </summary>
        VK_F6 = 0x75,

        /// <summary>
        /// F7 key
        /// </summary>
        VK_F7 = 0x76,

        /// <summary>
        /// F8 key
        /// </summary>
        VK_F8 = 0x77,

        /// <summary>
        /// F9 key
        /// </summary>
        VK_F9 = 0x78,

        /// <summary>
        /// F10 key
        /// </summary>
        VK_F10 = 0x79,

        /// <summary>
        /// F11 key
        /// </summary>
        VK_F11 = 0x7A,

        /// <summary>
        /// F11 key
        /// </summary>
        VK_F12 = 0x7B,

        /// <summary>
        /// F13 key
        /// </summary>
        VK_F13 = 0x7C,

        /// <summary>
        /// F14 key
        /// </summary>
        VK_F14 = 0x7D,

        /// <summary>
        /// F15 key
        /// </summary>
        VK_F15 = 0x7E,

        /// <summary>
        /// F16 key
        /// </summary>
        VK_F16 = 0x7F,

        /// <summary>
        /// F17 key
        /// </summary>
        VK_F17 = 0x80,

        /// <summary>
        /// F18 key
        /// </summary>
        VK_F18 = 0x81,

        /// <summary>
        /// F19 key
        /// </summary>
        VK_F19 = 0x82,

        /// <summary>
        /// F20 key
        /// </summary>
        VK_F20 = 0x83,

        /// <summary>
        /// F21 key
        /// </summary>
        VK_F21 = 0x84,

        /// <summary>
        /// F22 key
        /// </summary>
        VK_F22 = 0x85,

        /// <summary>
        /// F23 key
        /// </summary>
        VK_F23 = 0x86,

        /// <summary>
        /// F24 key
        /// </summary>
        VK_F24 = 0x87,

        /// <summary>
        /// VK_NAVIGATION_VIEW
        /// </summary>
        VK_NAVIGATION_VIEW = 0x88,

        /// <summary>
        /// VK_NAVIGATION_MENU
        /// </summary>
        VK_NAVIGATION_MENU = 0x89,

        /// <summary>
        /// VK_NAVIGATION_UP
        /// </summary>
        VK_NAVIGATION_UP = 0x8A,

        /// <summary>
        /// VK_NAVIGATION_DOWN
        /// </summary>
        VK_NAVIGATION_DOWN = 0x8B,

        /// <summary>
        /// VK_NAVIGATION_LEFT
        /// </summary>
        VK_NAVIGATION_LEFT = 0x8C,

        /// <summary>
        /// VK_NAVIGATION_RIGHT
        /// </summary>
        VK_NAVIGATION_RIGHT = 0x8D,

        /// <summary>
        /// VK_NAVIGATION_ACCEPT
        /// </summary>
        VK_NAVIGATION_ACCEPT = 0x8E,

        /// <summary>
        /// VK_NAVIGATION_CANCEL
        /// </summary>
        VK_NAVIGATION_CANCEL = 0x8F,


        /// <summary>
        /// NUM LOCK key
        /// </summary>
        VK_NUMLOCK = 0x90,

        /// <summary>
        /// SCROLL LOCK key
        /// </summary>
        VK_SCROLL = 0x91,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_NEC_EQUAL = 0x92,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FJ_JISHO = 0x92,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FJ_MASSHOU = 0x93,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FJ_TOUROKU = 0x94,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FJ_LOYA = 0x95,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FJ_ROYA = 0x96,

        /// <summary>
        /// Left SHIFT key
        /// </summary>
        VK_LSHIFT = 0xA0,

        /// <summary>
        /// Right SHIFT key
        /// </summary>
        VK_RSHIFT = 0xA1,

        /// <summary>
        /// Left CONTROL key
        /// </summary>
        VK_LCONTROL = 0xA2,

        /// <summary>
        /// Right CONTROL key
        /// </summary>
        VK_RCONTROL = 0xA3,

        /// <summary>
        /// Left MENU key
        /// </summary>
        VK_LMENU = 0xA4,

        /// <summary>
        /// Right MENU key
        /// </summary>
        VK_RMENU = 0xA5,

        /// <summary>
        /// Browser Back key
        /// </summary>
        VK_BROWSER_BACK = 0xA6,

        /// <summary>
        /// Browser Forward key
        /// </summary>
        VK_BROWSER_FORWARD = 0xA7,

        /// <summary>
        /// Browser Refresh key
        /// </summary>
        VK_BROWSER_REFRESH = 0xA8,

        /// <summary>
        /// Browser Stop key
        /// </summary>
        VK_BROWSER_STOP = 0xA9,

        /// <summary>
        /// Browser Search key
        /// </summary>
        VK_BROWSER_SEARCH = 0xAA,

        /// <summary>
        /// Browser Favorites key
        /// </summary>
        VK_BROWSER_FAVORITES = 0xAB,

        /// <summary>
        /// Browser Start and Home key
        /// </summary>
        VK_BROWSER_HOME = 0xAC,

        /// <summary>
        /// Volume Mute key
        /// </summary>
        VK_VOLUME_MUTE = 0xAD,

        /// <summary>
        /// Volume Down key
        /// </summary>
        VK_VOLUME_DOWN = 0xAE,

        /// <summary>
        /// Volume Up key
        /// </summary>
        VK_VOLUME_UP = 0xAF,

        /// <summary>
        /// Next Track key
        /// </summary>
        VK_MEDIA_NEXT_TRACK = 0xB0,

        /// <summary>
        /// Previous Track key
        /// </summary>
        VK_MEDIA_PREV_TRACK = 0xB1,

        /// <summary>
        /// Stop Media key
        /// </summary>
        VK_MEDIA_STOP = 0xB2,

        /// <summary>
        /// Play/Pause Media key
        /// </summary>
        VK_MEDIA_PLAY_PAUSE = 0xB3,

        /// <summary>
        /// Start Mail key
        /// </summary>
        VK_LAUNCH_MAIL = 0xB4,

        /// <summary>
        /// Select Media key
        /// </summary>
        VK_LAUNCH_MEDIA_SELECT = 0xB5,

        /// <summary>
        /// Start Application 1 key
        /// </summary>
        VK_LAUNCH_APP1 = 0xB6,

        /// <summary>
        /// Start Application 2 key
        /// </summary>
        VK_LAUNCH_APP2 = 0xB7,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ';:' key
        /// </summary>
        VK_OEM_1 = 0xBA,

        /// <summary>
        /// For any country/region, the '+' key
        /// </summary>
        VK_OEM_PLUS = 0xBB,

        /// <summary>
        /// For any country/region, the ',' key
        /// </summary>
        VK_OEM_COMMA = 0xBC,

        /// <summary>
        /// For any country/region, the '-' key
        /// </summary>
        VK_OEM_MINUS = 0xBD,

        /// <summary>
        /// For any country/region, the '.' key
        /// </summary>
        VK_OEM_PERIOD = 0xBE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '/?' key
        /// </summary>
        VK_OEM_2 = 0xBF,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '`~' key
        /// </summary>
        VK_OEM_3 = 0xC0,

        /// <summary>
        /// VK_GAMEPAD_A
        /// </summary>
        VK_GAMEPAD_A = 0xC3,

        /// <summary>
        /// VK_GAMEPAD_B
        /// </summary>
        VK_GAMEPAD_B = 0xC4,

        /// <summary>
        /// VK_GAMEPAD_X
        /// </summary>
        VK_GAMEPAD_X = 0xC5,

        /// <summary>
        /// VK_GAMEPAD_Y
        /// </summary>
        VK_GAMEPAD_Y = 0xC6,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_SHOULDER
        /// </summary>
        VK_GAMEPAD_RIGHT_SHOULDER = 0xC7,

        /// <summary>
        /// VK_GAMEPAD_LEFT_SHOULDER
        /// </summary>
        VK_GAMEPAD_LEFT_SHOULDER = 0xC8,

        /// <summary>
        /// VK_GAMEPAD_LEFT_TRIGGER
        /// </summary>
        VK_GAMEPAD_LEFT_TRIGGER = 0xC9,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_TRIGGER
        /// </summary>
        VK_GAMEPAD_RIGHT_TRIGGER = 0xCA,

        /// <summary>
        /// VK_GAMEPAD_DPAD_UP
        /// </summary>
        VK_GAMEPAD_DPAD_UP = 0xCB,

        /// <summary>
        /// VK_GAMEPAD_DPAD_DOWN
        /// </summary>
        VK_GAMEPAD_DPAD_DOWN = 0xCC,

        /// <summary>
        /// VK_GAMEPAD_DPAD_LEFT
        /// </summary>
        VK_GAMEPAD_DPAD_LEFT = 0xCD,

        /// <summary>
        /// VK_GAMEPAD_DPAD_RIGHT
        /// </summary>
        VK_GAMEPAD_DPAD_RIGHT = 0xCE,

        /// <summary>
        /// VK_GAMEPAD_MENU
        /// </summary>
        VK_GAMEPAD_MENU = 0xCF,

        /// <summary>
        /// VK_GAMEPAD_VIEW
        /// </summary>
        VK_GAMEPAD_VIEW = 0xD0,

        /// <summary>
        /// VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON
        /// </summary>
        VK_GAMEPAD_LEFT_THUMBSTICK_BUTTON = 0xD1,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON
        /// </summary>
        VK_GAMEPAD_RIGHT_THUMBSTICK_BUTTON = 0xD2,

        /// <summary>
        /// VK_GAMEPAD_LEFT_THUMBSTICK_UP
        /// </summary>
        VK_GAMEPAD_LEFT_THUMBSTICK_UP = 0xD3,

        /// <summary>
        /// VK_GAMEPAD_LEFT_THUMBSTICK_DOWN
        /// </summary>
        VK_GAMEPAD_LEFT_THUMBSTICK_DOWN = 0xD4,

        /// <summary>
        /// VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT
        /// </summary>
        VK_GAMEPAD_LEFT_THUMBSTICK_RIGHT = 0xD5,

        /// <summary>
        /// VK_GAMEPAD_LEFT_THUMBSTICK_LEFT
        /// </summary>
        VK_GAMEPAD_LEFT_THUMBSTICK_LEFT = 0xD6,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_THUMBSTICK_UP
        /// </summary>
        VK_GAMEPAD_RIGHT_THUMBSTICK_UP = 0xD7,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN
        /// </summary>
        VK_GAMEPAD_RIGHT_THUMBSTICK_DOWN = 0xD8,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT
        /// </summary>
        VK_GAMEPAD_RIGHT_THUMBSTICK_RIGHT = 0xD9,

        /// <summary>
        /// VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT
        /// </summary>
        VK_GAMEPAD_RIGHT_THUMBSTICK_LEFT = 0xDA,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '[{' key
        /// </summary>
        VK_OEM_4 = 0xDB,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the '\|' key
        /// </summary>
        VK_OEM_5 = 0xDC,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the ']}' key
        /// </summary>
        VK_OEM_6 = 0xDD,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// For the US standard keyboard, the 'single-quote/double-quote' key
        /// </summary>
        VK_OEM_7 = 0xDE,

        /// <summary>
        /// Used for miscellaneous characters; it can vary by keyboard.
        /// </summary>
        VK_OEM_8 = 0xDF,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_AX = 0xE1,

        /// <summary>
        /// Either the angle bracket key or the backslash key on the RT 102-key keyboard
        /// </summary>
        VK_OEM_102 = 0xE2,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_HELP = 0xE3,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_00 = 0xE4,

        /// <summary>
        /// IME PROCESS key
        /// </summary>
        VK_PROCESSKEY = 0xE5,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_ICO_CLEAR = 0xE6,

        /// <summary>
        /// Used to pass Unicode characters as if they were keystrokes.
        /// The <see cref="VK_PACKET"/> key is the low word of a 32-bit Virtual Key value used for non-keyboard input methods.
        /// For more information, see Remark in <see cref="KEYBDINPUT"/>, <see cref="SendInput"/>, <see cref="WM_KEYDOWN"/>, and <see cref="WM_KEYUP"/>
        /// </summary>
        VK_PACKET = 0xE7,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_RESET = 0xE9,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_JUMP = 0xEA,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA1 = 0xEB,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA2 = 0xEC,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_PA3 = 0xED,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_WSCTRL = 0xEE,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_CUSEL = 0xEF,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_ATTN = 0xF0,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_FINISH = 0xF1,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_COPY = 0xF2,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_AUTO = 0xF3,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_ENLW = 0xF4,

        /// <summary>
        /// OEM specific
        /// </summary>
        VK_OEM_BACKTAB = 0xF5,

        /// <summary>
        /// Attn key
        /// </summary>
        VK_ATTN = 0xF6,

        /// <summary>
        /// CrSel key
        /// </summary>
        VK_CRSEL = 0xF7,

        /// <summary>
        /// ExSel key
        /// </summary>
        VK_EXSEL = 0xF8,

        /// <summary>
        /// Erase EOF key
        /// </summary>
        VK_EREOF = 0xF9,

        /// <summary>
        /// Play key
        /// </summary>
        VK_PLAY = 0xFA,

        /// <summary>
        /// Zoom key
        /// </summary>
        VK_ZOOM = 0xFB,

        /// <summary>
        /// Reserved
        /// </summary>
        VK_NONAME = 0xFC,

        /// <summary>
        /// PA1 key
        /// </summary>
        VK_PA1 = 0xFD,

        /// <summary>
        /// Clear Key
        /// </summary>
        VK_OEM_CLEAR = 0xFE,
    }
}
