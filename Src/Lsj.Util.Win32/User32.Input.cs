using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MapVirtualKeyTypes;
using static Lsj.Util.Win32.Enums.RawInputDeviceFlags;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.VirtualKeyCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Attaches or detaches the input processing mechanism of one thread to that of another thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-attachthreadinput"/>
        /// </para>
        /// </summary>
        /// <param name="idAttach">
        /// The identifier of the thread to be attached to another thread.
        /// The thread to be attached cannot be a system thread.
        /// </param>
        /// <param name="idAttachTo">
        /// <para>
        /// The identifier of the thread to which <paramref name="idAttach"/> will be attached.
        /// This thread cannot be a system thread.
        /// </para>
        /// <para>
        /// A thread cannot attach to itself.
        /// Therefore, <paramref name="idAttachTo"/> cannot equal <paramref name="idAttach"/>.
        /// </para>
        /// </param>
        /// <param name="fAttach">
        /// If this parameter is <see cref="TRUE"/>, the two threads are attached.
        /// If the parameter is <see cref="FALSE"/>, the threads are detached.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP:
        /// There is no extended error information; do not call <see cref="GetLastError"/>.
        /// This behavior changed as of Windows Vista.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// By using the <see cref="AttachThreadInput"/> function,
        /// a thread can share its input states (such as keyboard states and the current focus window) with another thread.
        /// Keyboard and mouse events received by both threads are processed in the order they were received
        /// until the threads are detached by calling <see cref="AttachThreadInput"/> a second time
        /// and specifying <see cref="FALSE"/> for the <paramref name="fAttach"/> parameter.
        /// </para>
        /// <para>
        /// The <see cref="AttachThreadInput"/> function fails if either of the specified threads does not have a message queue.
        /// The system creates a thread's message queue when the thread makes its first call to one of the USER or GDI functions.
        /// The <see cref="AttachThreadInput"/> function also fails if a journal record hook is installed.
        /// Journal record hooks attach all input queues together.
        /// </para>
        /// <para>
        /// Note that key state, which can be ascertained by calls to the <see cref="GetKeyState"/> or <see cref="GetKeyboardState"/> function,
        /// is reset after a call to <see cref="AttachThreadInput"/>.
        /// You cannot attach a thread to a thread in another desktop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "AttachThreadInput", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL AttachThreadInput([In] DWORD idAttach, [In] DWORD idAttachTo, [In] BOOL fAttach);

        /// <summary>
        /// <para>
        /// Retrieves the window handle to the active window attached to the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getactivewindow"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the handle to the active window attached to the calling thread's message queue.
        /// Otherwise, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To get the handle to the foreground window, you can use <see cref="GetForegroundWindow"/>.
        /// </para>
        /// <para>
        /// To get the window handle to the active window in the message queue for another thread, use <see cref="GetGUIThreadInfo"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetActiveWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetActiveWindow();

        /// <summary>
        /// <para>
        /// Determines whether a key is up or down at the time the function is called,
        /// and whether the key was pressed after a previous call to <see cref="GetAsyncKeyState"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getasynckeystate"/>
        /// </para>
        /// </summary>
        /// <param name="vKey">
        /// <para>
        /// The virtual-key code.
        /// For more information, see Virtual Key Codes.
        /// </para>
        /// <para>
        /// You can use left- and right-distinguishing constants to specify certain keys.
        /// See the Remarks section for further information.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies whether the key was pressed
        /// since the last call to <see cref="GetAsyncKeyState"/>, and whether the key is currently up or down.
        /// If the most significant bit is set, the key is down, and if the least significant bit is set,
        /// the key was pressed after the previous call to <see cref="GetAsyncKeyState"/>.
        /// However, you should not rely on this last behavior; for more information, see the Remarks.
        /// </para>
        /// <para>
        /// The return value is zero for the following cases:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The current desktop is not the active desktop
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The foreground thread belongs to another process and the desktop does not allow the hook or the journal record.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="GetAsyncKeyState"/> function works with mouse buttons.
        /// However, it checks on the state of the physical mouse buttons, not on the logical mouse buttons that the physical buttons are mapped to.
        /// For example, the call <c>GetAsyncKeyState(VK_LBUTTON)</c> always returns the state of the left physical mouse button,
        /// regardless of whether it is mapped to the left or right logical mouse button.
        /// You can determine the system's current mapping of physical mouse buttons to logical mouse buttons by calling <c>GetSystemMetrics(SM_SWAPBUTTON)</c>.
        /// </para>
        /// <para>
        /// which returns <see cref="TRUE"/> if the mouse buttons have been swapped.
        /// </para>
        /// <para>
        /// Although the least significant bit of the return value indicates whether the key has been pressed since the last query,
        /// due to the preemptive multitasking nature of Windows,
        /// another application can call <see cref="GetAsyncKeyState"/> and receive the "recently pressed" bit instead of your application.
        /// The behavior of the least significant bit of the return value is retained strictly for compatibility with 16-bit Windows applications 
        /// (which are non-preemptive) and should not be relied upon.
        /// </para>
        /// <para>
        /// You can use the virtual-key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/>,
        /// and <see cref="VK_MENU"/> as values for the <paramref name="vKey"/> parameter.
        /// This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// </para>
        /// <para>
        /// You can use the following virtual-key code constants as values for <paramref name="vKey"/>
        /// to distinguish between the left and right instances of those keys.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Code
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="VK_LSHIFT"/>
        /// </term>
        /// <term>
        /// Left-shift key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_RSHIFT"/>
        /// </term>
        /// <term>
        /// Right-shift key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_LCONTROL"/>
        /// </term>
        /// <term>
        /// Left-control key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_RCONTROL"/>
        /// </term>
        /// <term>
        /// Right-control key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_LMENU"/>
        /// </term>
        /// <term>
        /// Left-menu key.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_RMENU"/>
        /// </term>
        /// <term>
        /// Right-menu key.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// These left- and right-distinguishing constants are only available when you call the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAsyncKeyState", ExactSpelling = true)]
        public static extern SHORT GetAsyncKeyState([In] int vKey);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the window (if any) that has captured the mouse.
        /// Only one window at a time can capture the mouse; this window receives mouse input whether or not the cursor is within its borders.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcapture"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a handle to the capture window associated with the current thread.
        /// If no window in the thread has captured the mouse, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// A <see cref="NULL"/> return value means the current thread has not captured the mouse.
        /// However, it is possible that another thread or process has captured the mouse.
        /// </para>
        /// <para>
        /// To get a handle to the capture window on another thread, use the <see cref="GetGUIThreadInfo"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCapture", ExactSpelling = true)]
        public static extern HWND GetCapture();

        /// <summary>
        /// <para>
        /// Retrieves the current double-click time for the mouse.
        /// A double-click is a series of two clicks of the mouse button, the second occurring within a specified time after the first.
        /// The double-click time is the maximum number of milliseconds that may occur between the first and second click of a double-click.
        /// The maximum double-click time is 5000 milliseconds.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdoubleclicktime"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value specifies the current double-click time, in milliseconds.
        /// The maximum return value is 5000 milliseconds.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDoubleClickTime", ExactSpelling = true)]
        public static extern UINT GetDoubleClickTime();

        /// <summary>
        /// <para>
        /// Retrieves the handle to the window that has the keyboard focus, if the window is attached to the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getfocus"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is the handle to the window with the keyboard focus.
        /// If the calling thread's message queue does not have an associated window with the keyboard focus, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetFocus"/> returns the window with the keyboard focus for the current thread's message queue.
        /// If <see cref="GetFocus"/> returns <see cref="NULL"/>, another thread's queue may be attached to a window that has the keyboard focus.
        /// </para>
        /// <para>
        /// Use the <see cref="GetForegroundWindow"/> function to retrieve the handle to the window with which the user is currently working.
        /// You can associate your thread's message queue with the windows owned by another thread by using the <see cref="AttachThreadInput"/> function.
        /// </para>
        /// <para>
        /// To get the window with the keyboard focus on the foreground queue or the queue of another thread, use the <see cref="GetGUIThreadInfo"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus", ExactSpelling = true)]
        public static extern HWND GetFocus();

        /// <summary>
        /// <para>
        /// Determines whether there are mouse-button or keyboard messages in the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getinputstate"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the queue contains one or more new mouse-button or keyboard messages, the return value is nonzero.
        /// </para>
        /// <para>
        /// If there are no new mouse-button or keyboard messages in the queue, the return value is zero.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetInputState", ExactSpelling = true)]
        public static extern BOOL GetInputState();

        /// <summary>
        /// <para>
        /// Retrieves the current code page.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkbcodepage"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is an OEM code-page identifier, or it is the default identifier if the registry value is not readable.
        /// For a list of OEM code-page identifiers, see Code Page Identifiers.
        /// </returns>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            "Applications should use the GetOEMCP function to retrieve the OEM code-page identifier for the system.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKBCodePage", ExactSpelling = true)]
        public static extern UINT GetKBCodePage();

        /// <summary>
        /// <para>
        /// Copies the status of the 256 virtual keys to the specified buffer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeyboardstate"/>
        /// </para>
        /// </summary>
        /// <param name="lpKeyState">
        /// The 256-byte array that receives the status data for each virtual key.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// An application can call this function to retrieve the current status of all the virtual keys.
        /// The status changes as a thread removes keyboard messages from its message queue.
        /// The status does not change as keyboard messages are posted to the thread's message queue,
        /// nor does it change as keyboard messages are posted to or retrieved from message queues of other threads.
        /// (Exception: Threads that are connected through <see cref="AttachThreadInput"/> share the same keyboard state.)
        /// </para>
        /// <para>
        /// When the function returns, each member of the array pointed to by the <paramref name="lpKeyState"/> parameter contains status data for a virtual key.
        /// If the high-order bit is 1, the key is down; otherwise, it is up.
        /// If the key is a toggle key, for example CAPS LOCK, then the low-order bit is 1 when the key is toggled and is 0 if the key is untoggled.
        /// The low-order bit is meaningless for non-toggle keys. A toggle key is said to be toggled when it is turned on.
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </para>
        /// <para>
        /// To retrieve status information for an individual key, use the <see cref="GetKeyState"/> function.
        /// To retrieve the current state for an individual key regardless of
        /// whether the corresponding keyboard message has been retrieved from the message queue, use the <see cref="GetAsyncKeyState"/> function.
        /// </para>
        /// <para>
        /// An application can use the virtual-key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/> and <see cref="VK_MENU"/>
        /// as indices into the array pointed to by <paramref name="lpKeyState"/>.
        /// This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// An application can also use the following virtual-key code constants as indices to distinguish between the left and right instances of those keys:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// <see cref="VK_LSHIFT"/>
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="VK_RSHIFT"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_LCONTROL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_RCONTROL"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_LMENU"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="VK_RMENU"/>
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        ///  
        /// </para>
        /// <para>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetKeyboardState([Out] BYTE[] lpKeyState);

        /// <summary>
        /// <para>
        /// Retrieves information about the current keyboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeyboardtype"/>
        /// </para>
        /// </summary>
        /// <param name="nTypeFlag">
        /// <para>
        /// The type of keyboard information to be retrieved.
        /// This parameter can be one of the following values.
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
        /// 0
        /// </term>
        /// <term>
        /// Keyboard type
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Keyboard subtype
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// The number of function keys on the keyboard
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value specifies the requested information.
        /// </para>
        /// <para>
        /// If the function fails and <paramref name="nTypeFlag"/> is not 1, the return value is 0;
        /// 0 is a valid return value when <paramref name="nTypeFlag"/> is 1 (keyboard subtype).
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Valid keyboard types are:
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0x4
        /// </term>
        /// <term>
        /// Enhanced 101- or 102-key keyboards (and compatibles)
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x7
        /// </term>
        /// <term>
        /// Japanese Keyboard
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x8
        /// </term>
        /// <term>
        /// Korean Keyboard
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x51
        /// </term>
        /// <term>
        /// Unknown type or HID keyboard
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Keyboard subtypes are original equipment manufacturer (OEM)-dependent values.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardType", ExactSpelling = true, SetLastError = true)]
        public static extern int GetKeyboardType([In] int nTypeFlag);

        /// <summary>
        /// <para>
        /// Retrieves a string that represents the name of a key.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeynametextw"/>
        /// </para>
        /// </summary>
        /// <param name="lParam">
        /// <para>
        /// The second parameter of the keyboard message (such as <see cref="WM_KEYDOWN"/>) to be processed.
        /// The function interprets the following bit positions in the <paramref name="lParam"/>.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bits
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 16-23
        /// </term>
        /// <term>
        /// The scan code. The value depends on the OEM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 24
        /// </term>
        /// <term>
        /// Indicates whether the key is an extended key, such as the right-hand ALT and CTRL keys that appear on an enhanced 101- or 102-key keyboard.
        /// The value is 1 if it is an extended key; otherwise, it is 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 25
        /// </term>
        /// <term>
        /// "Do not care" bit. The application calling this function sets this bit to indicate
        /// that the function should not distinguish between left and right CTRL and SHIFT keys, for example.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For more detail, see Keystroke Message Flags.
        /// </para>
        /// </param>
        /// <param name="lpString">
        /// The buffer that will receive the key name.
        /// </param>
        /// <param name="cchSize">
        /// The maximum length, in characters, of the key name, including the terminating null character.
        /// (This parameter should be equal to the size of the buffer pointed to by the <paramref name="lpString"/> parameter.)
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, a null-terminated string is copied into the specified buffer,
        /// and the return value is the length of the string, in characters, not counting the terminating null character.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The format of the key-name string depends on the current keyboard layout.
        /// </para>
        /// <para>
        /// The keyboard layout maintains a list of names in the form of character strings for keys with names longer than a single character.
        /// The key name is translated according to the currently active keyboard layout,
        /// therefore the function might return different results for different keyboard layouts.
        /// </para>
        /// <para>
        /// The name of a character key is the character itself.
        /// The names of dead keys are spelled out in full.
        /// </para>
        /// <para>
        /// Character keys that are mapped to the 'A'..'Z' virtual-key codes are translated to
        /// the &lt;U+0041 LATIN CAPITAL LETTER A&gt;..&lt;U+005A LATIN CAPITAL LETTER Z&gt; characters regardless of current keyboard layout.
        /// In this case, use the <see cref="ToUnicode"/> or <see cref="ToUnicodeEx"/> methods to get the character for the corresponding key press.
        /// </para>
        /// <para>
        /// This method might not work properly with some keyboard layouts that produce multiple characters (such as ligatures)
        /// or supplementary Unicode characters on a single key press.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyNameTextW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetKeyNameText([In] LONG lParam, [In] IntPtr lpString, [In] int cchSize);

        /// <summary>
        /// <para>
        /// Retrieves the status of the specified virtual key.
        /// The status specifies whether the key is up, down, or toggled (on, off—alternating each time the key is pressed).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeystate"/>
        /// </para>
        /// </summary>
        /// <param name="nVirtKey">
        /// <para>
        /// A virtual key.
        /// If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9),
        /// <paramref name="nVirtKey"/> must be set to the ASCII value of that character.
        /// For other keys, it must be a virtual-key code.
        /// </para>
        /// <para>
        /// If a non-English keyboard layout is used,
        /// virtual keys with values in the range ASCII A through Z and 0 through 9 are used to specify most of the character keys.
        /// For example, for the German keyboard layout, the virtual key of value ASCII O (0x4F) refers to the "o" key,
        /// whereas <see cref="VK_OEM_1"/> refers to the "o with umlaut" key.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// The return value specifies the status of the specified virtual key, as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If the high-order bit is 1, the key is down; otherwise, it is up.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If the low-order bit is 1, the key is toggled.
        /// A key, such as the CAPS LOCK key, is toggled if it is turned on.
        /// The key is off and untoggled if the low-order bit is 0.
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The key status returned from this function changes as a thread reads key messages from its message queue.
        /// The status does not reflect the interrupt-level state associated with the hardware.
        /// Use the <see cref="GetAsyncKeyState"/> function to retrieve that information.
        /// </para>
        /// <para>
        /// An application calls <see cref="GetKeyState"/> in response to a keyboard-input message.
        /// This function retrieves the state of the key when the input message was generated.
        /// </para>
        /// <para>
        /// To retrieve state information for all the virtual keys, use the <see cref="GetKeyboardState"/> function.
        /// </para>
        /// <para>
        /// An application can use the virtual key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/>,
        /// and <see cref="VK_MENU"/> as values for the <paramref name="nVirtKey"/> parameter.
        /// This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// An application can also use the following virtual-key code constants as values
        /// for <paramref name="nVirtKey"/> to distinguish between the left and right instances of those keys:
        /// </para>
        /// <para>
        /// <see cref="VK_LSHIFT"/> <see cref="VK_RSHIFT"/> <see cref="VK_LCONTROL"/> <see cref="VK_RCONTROL"/> <see cref="VK_LMENU"/> <see cref="VK_RMENU"/>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyState", ExactSpelling = true)]
        public static extern SHORT GetKeyState([In] int nVirtKey);

        /// <summary>
        /// Retrieves the raw input from the specified device.
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawinputdata"/>
        /// </para>
        /// </summary>
        /// <param name="hRawInput">
        /// A handle to the <see cref="RAWINPUT"/> structure.
        /// This comes from the <c>lParam</c> in <see cref="WM_INPUT"/>.
        /// </param>
        /// <param name="uiCommand">
        /// <para>
        /// The command flag.
        /// This parameter can be one of the following values.
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
        /// <see cref="RID_HEADER"/>
        /// </para>
        /// <para>
        /// 0x10000005
        /// </para>
        /// </term>
        /// <term>
        /// Get the header information from the <see cref="RAWINPUT"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="RID_INPUT"/>
        /// </para>
        /// <para>
        /// 0x10000003
        /// </para>
        /// </term>
        /// <term>
        /// Get the raw data from the <see cref="RAWINPUT"/> structure.
        /// </term>
        /// </item>
        /// </list>
        /// </param>
        /// <param name="pData">
        /// <para>
        /// A pointer to the data that comes from the <see cref="RAWINPUT"/> structure.
        /// This depends on the value of <paramref name="uiCommand"/>.
        /// Pointer should be aligned on a <see cref="DWORD"/> (32-bit) boundary.
        /// </para>
        /// <para>
        /// If <paramref name="pData"/> is <see cref="NULL"/>, the required size of the buffer is returned in *<paramref name="pcbSize"/>.
        /// </para>
        /// </param>
        /// <param name="pcbSize">
        /// The size, in bytes, of the data in <paramref name="pData"/>.
        /// </param>
        /// <param name="cbSizeHeader">
        /// The size, in bytes, of the <see cref="RAWINPUTHEADER"/> structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If <paramref name="pData"/> is <see cref="NULL"/> and the function is successful, the return value is 0.
        /// If <paramref name="pData"/> is not <see cref="NULL"/> and the function is successful,
        /// the return value is the number of bytes copied into <paramref name="pData"/>.
        /// </para>
        /// <para>
        /// If there is an error, the return value is (<see cref="UINT"/>)-1.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <see cref="GetRawInputData"/> gets the raw input one <see cref="RAWINPUT"/> structure at a time.
        /// In contrast, <see cref="GetRawInputBuffer"/> gets an array of <see cref="RAWINPUT"/> structures.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRawInputData", ExactSpelling = true)]
        public static extern UINT GetRawInputData([In] HRAWINPUT hRawInput, [In] UINT uiCommand, [In] LPVOID pData,
            [In][Out] ref UINT pcbSize, [In] UINT cbSizeHeader);

        /// <summary>
        /// <para>
        /// Retrieves the feedback configuration for a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getwindowfeedbacksetting"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window to check for feedback configuration.
        /// </param>
        /// <param name="feedback">
        /// One of the values from the <see cref="FEEDBACK_TYPE"/> enumeration.
        /// </param>
        /// <param name="dwFlags">
        /// Specify <see cref="GWFS_INCLUDE_ANCESTORS"/> to check the parent window chain until a value is found.
        /// The default is 0 and indicates that only the specified window will be checked.
        /// </param>
        /// <param name="pSize">
        /// <para>
        /// The size of memory region that the <paramref name="config"/> parameter points to.
        /// </para>
        /// <para>
        /// The <paramref name="pSize"/> parameter specifies the size of the configuration data
        /// for the feedback type in <paramref name="feedback"/> and must be <c>sizeof(BOOL)</c>.
        /// </para>
        /// </param>
        /// <param name="config">
        /// <para>
        /// The configuration data.
        /// </para>
        /// <para>
        /// The <paramref name="config"/> parameter must point to a value of type <see cref="BOOL"/>.
        /// </para>
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if the specified feedback setting is configured on the specified window.
        /// Otherwise, it returns <see cref="FALSE"/> (and <paramref name="config"/> won't be modified).
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowFeedbackSetting", ExactSpelling = true)]
        public static extern BOOL GetWindowFeedbackSetting([In] HWND hwnd, [In] FEEDBACK_TYPE feedback, [In] DWORD dwFlags,
            [In][Out] ref UINT32 pSize, [In] PVOID config);

        /// <summary>
        /// <para>
        /// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mapvirtualkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="uCode">
        /// The virtual key code or scan code for a key.
        /// How this value is interpreted depends on the value of the <paramref name="uMapType"/> parameter.
        /// </param>
        /// <param name="uMapType">
        /// <para>
        /// The translation to be performed.
        /// The value of this parameter depends on the value of the <paramref name="uCode"/> parameter.
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
        /// <para>
        /// <see cref="MAPVK_VK_TO_VSC"/>
        /// </para>
        /// <para>
        /// 0
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="uCode"/> parameter is a virtual-key code and is translated into a scan code.
        /// If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned.
        /// If there is no translation, the function returns 0.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAPVK_VSC_TO_VK"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="uCode"/> parameter is a scan code and is translated into a virtual-key code
        /// that does not distinguish between left- and right-hand keys.
        /// If there is no translation, the function returns 0.
        /// </para>
        /// <para>
        /// Windows Vista and later:
        /// the high byte of the <paramref name="uCode"/> value can contain either 0xe0 or 0xe1 to specify the extended scan code.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAPVK_VK_TO_CHAR"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="uCode"/> parameter is a virtual-key code and is translated into an unshifted character value
        /// in the low order word of the return value.
        /// Dead keys (diacritics) are indicated by setting the top bit of the return value.
        /// If there is no translation, the function returns 0.
        /// See Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAPVK_VSC_TO_VK_EX"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <paramref name="uCode"/> parameter is a scan code and is translated into a virtual-key code
        /// that distinguishes between left- and right-hand keys.
        /// If there is no translation, the function returns 0.
        /// </para>
        /// <para>
        /// Windows Vista and later:
        /// the high byte of the <paramref name="uCode"/> value can contain either 0xe0 or 0xe1 to specify the extended scan code.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MAPVK_VK_TO_VSC_EX"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// Windows Vista and later:
        /// The <paramref name="uCode"/> parameter is a virtual-key code and is translated into a scan code.
        /// If it is a virtual-key code that does not distinguish between left- and right-hand keys, the left-hand scan code is returned.
        /// If the scan code is an extended scan code, the high byte of the returned value
        /// will contain either 0xe0 or 0xe1 to specify the extended scan code.
        /// If there is no translation, the function returns 0.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// The return value is either a scan code, a virtual-key code, or a character value,
        /// depending on the value of <paramref name="uCode"/> and <paramref name="uMapType"/>.
        /// If there is no translation, the return value is zero.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To specify a handle to the keyboard layout to use for translating the specified code, use the <see cref="MapVirtualKeyEx"/> function.
        /// </para>
        /// <para>
        /// An application can use <see cref="MapVirtualKey"/> to translate scan codes to the virtual-key code constants
        /// <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/>, and <see cref="VK_MENU"/>, and vice versa.
        /// These translations do not distinguish between the left and right instances of the SHIFT, CTRL, or ALT keys.
        /// </para>
        /// <para>
        /// An application can get the scan code corresponding to the left or right instance of one of these keys
        /// by calling <see cref="MapVirtualKey"/> with <paramref name="uCode"/> set to one of the following virtual-key code constants:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="VK_LSHIFT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VK_RSHIFT"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VK_LCONTROL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VK_RCONTROL"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VK_LMENU"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="VK_RMENU"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>,
        /// <see cref="MapVirtualKey"/>, and <see cref="MapVirtualKeyEx"/> functions.
        /// For list complete table of virtual key codes, see Virtual Key Codes.
        /// </para>
        /// <para>
        /// In <see cref="MAPVK_VK_TO_CHAR"/> mode virtual-key codes, the 'A'..'Z' keys
        /// are translated to upper-case 'A'..'Z' characters regardless of current keyboard layout.
        /// If you want to translate a virtual-key code to the corresponding character, use the <see cref="ToUnicode"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapVirtualKeyW", ExactSpelling = true)]
        public static extern UINT MapVirtualKey([In] UINT uCode, [In] MapVirtualKeyTypes uMapType);

#pragma warning disable IDE1006
        /// <summary>
        /// <para>
        /// The <see cref="mouse_event"/> function synthesizes mouse motion and button clicks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-mouse_event"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// Controls various aspects of mouse motion and button clicking.
        /// This parameter can be certain combinations of the following values.
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
        /// <para>
        /// <see cref="MOUSEEVENTF_ABSOLUTE"/>
        /// </para>
        /// <para>
        /// 0x8000
        /// </para>
        /// </term>
        /// <term>
        /// The <paramref name="dx"/> and <paramref name="dy"/> parameters contain normalized absolute coordinates.
        /// If not set, those parameters contain relative data: the change in position since the last reported position.
        /// This flag can be set, or not set, regardless of what kind of mouse or mouse-like device, if any, is connected to the system.
        /// For further information about relative mouse motion, see the following Remarks section.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_LEFTDOWN"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// The left button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_LEFTUP"/>
        /// </para>
        /// <para>
        /// 0x0004
        /// </para>
        /// </term>
        /// <term>
        /// The left button is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MIDDLEDOWN"/>
        /// </para>
        /// <para>
        /// 0x0020
        /// </para>
        /// </term>
        /// <term>
        /// The middle button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MIDDLEUP"/>
        /// </para>
        /// <para>
        /// 0x0040
        /// </para>
        /// </term>
        /// <term>
        /// The middle button is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_MOVE"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Movement occurred.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_RIGHTDOWN"/>
        /// </para>
        /// <para>
        /// 0x0008
        /// </para>
        /// </term>
        /// <term>
        /// The right button is down.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_RIGHTUP"/>
        /// </para>
        /// <para>
        /// 0x0010
        /// </para>
        /// </term>
        /// <term>
        /// The right button is up.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_WHEEL"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// The wheel has been moved, if the mouse has a wheel.
        /// The amount of movement is specified in <paramref name="dwData"/>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_XDOWN"/>
        /// </para>
        /// <para>
        /// 0x0080
        /// </para>
        /// </term>
        /// <term>
        /// An X button was pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_XUP"/>
        /// </para>
        /// <para>
        /// 0x0100
        /// </para>
        /// </term>
        /// <term>
        /// An X button was released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_WHEEL"/>
        /// </para>
        /// <para>
        /// 0x0800
        /// </para>
        /// </term>
        /// <term>
        /// The wheel button is rotated.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="MOUSEEVENTF_HWHEEL"/>
        /// </para>
        /// <para>
        /// 0x01000
        /// </para>
        /// </term>
        /// <term>
        /// The wheel button is tilted.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The values that specify mouse button status are set to indicate changes in status, not ongoing conditions.
        /// For example, if the left mouse button is pressed and held down, <see cref="MOUSEEVENTF_LEFTDOWN"/> is set
        /// when the left button is first pressed, but not for subsequent motions.
        /// Similarly, <see cref="MOUSEEVENTF_LEFTUP"/> is set only when the button is first released.
        /// </para>
        /// <para>
        /// You cannot specify both <see cref="MOUSEEVENTF_WHEEL"/> and either <see cref="MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF_XUP"/>
        /// simultaneously in the <paramref name="dwFlags"/> parameter, because they both require use of the <paramref name="dwData"/> field.
        /// </para>
        /// <param name="dx">
        /// The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated,
        /// depending on the setting of <see cref="MOUSEEVENTF_ABSOLUTE"/>.
        /// Absolute data is specified as the mouse's actual x-coordinate; relative data is specified as the number of mickeys moved.
        /// A mickey is the amount that a mouse has to move for it to report that it has moved.
        /// </param>
        /// <param name="dy">
        /// The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated,
        /// depending on the setting of <see cref="MOUSEEVENTF_ABSOLUTE"/>.
        /// Absolute data is specified as the mouse's actual y-coordinate; relative data is specified as the number of mickeys moved.
        /// </param>
        /// <param name="dwData">
        /// <para>
        /// If <paramref name="dwFlags"/> contains <see cref="MOUSEEVENTF_WHEEL"/>, then <paramref name="dwData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> contains <see cref="MOUSEEVENTF_HWHEEL"/>, then <paramref name="dwData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> contains <see cref="MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF_XUP"/>,
        /// then <paramref name="dwData"/> specifies which X buttons were pressed or released.
        /// This value may be any combination of the following flags.
        /// </para>
        /// <para>
        /// If <paramref name="dwFlags"/> is not <see cref="MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF_XDOWN"/>,
        /// or <see cref="MOUSEEVENTF_XUP"/>, then <paramref name="dwData"/> should be zero.
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
        /// <para>
        /// <see cref="XBUTTON1"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Set if the first X button was pressed or released.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="XBUTTON2"/>
        /// </para>
        /// <para>
        /// 0x0002
        /// </para>
        /// </term>
        /// <term>
        /// Set if the second X button was pressed or released.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwExtraInfo">
        /// An additional value associated with the mouse event.
        /// An application calls <see cref="GetMessageExtraInfo"/> to obtain this extra information.
        /// </param>
        /// <remarks>
        /// <para>
        /// If the mouse has moved, indicated by <see cref="MOUSEEVENTF_MOVE"/> being set,
        /// <paramref name="dx"/> and <paramref name="dy"/> hold information about that motion.
        /// The information is specified as absolute or relative integer values.
        /// </para>
        /// <para>
        /// If <see cref="MOUSEEVENTF_ABSOLUTE"/> value is specified,
        /// <paramref name="dx"/> and <paramref name="dy"/> contain normalized absolute coordinates between 0 and 65,535.
        /// The event procedure maps these coordinates onto the display surface.
        /// Coordinate (0,0) maps onto the upper-left corner of the display surface, (65535,65535) maps onto the lower-right corner.
        /// </para>
        /// <para>
        /// If the <see cref="MOUSEEVENTF_ABSOLUTE"/> value is not specified,
        /// <paramref name="dx"/> and <paramref name="dy"/> specify relative motions from when the last mouse event was generated (the last reported position).
        /// Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
        /// </para>
        /// <para>
        /// Relative mouse motion is subject to the settings for mouse speed and acceleration level.
        /// An end user sets these values using the Mouse application in Control Panel.
        /// An application obtains and sets these values with the <see cref="SystemParametersInfo"/> function.
        /// </para>
        /// <para>
        /// The system applies two tests to the specified relative mouse motion when applying acceleration.
        /// If the specified distance along either the x or y axis is greater than the first mouse threshold value,
        /// and the mouse acceleration level is not zero, the operating system doubles the distance.
        /// If the specified distance along either the x- or y-axis is greater than the second mouse threshold value,
        /// and the mouse acceleration level is equal to two, the operating system doubles the distance that resulted from applying the first threshold test.
        /// It is thus possible for the operating system to multiply relatively-specified mouse motion along the x- or y-axis by up to four times.
        /// </para>
        /// <para>
        /// Once acceleration has been applied, the system scales the resultant value by the desired mouse speed.
        /// Mouse speed can range from 1 (slowest) to 20 (fastest) and represents how much the pointer moves based on the distance the mouse moves.
        /// 
        /// The default value is 10, which results in no additional modification to the mouse motion.
        /// </para>
        /// <para>
        /// The <see cref="mouse_event"/> function is used to synthesize mouse events by applications that need to do so.
        /// It is also used by applications that need to obtain more information from the mouse than its position and button state.
        /// For example, if a tablet manufacturer wants to pass pen-based information to its own applications,
        /// it can write a DLL that communicates directly to the tablet hardware, obtains the extra information, and saves it in a queue.
        /// The DLL then calls <see cref="mouse_event"/> with the standard button and x/y position data, along with,
        /// in the <paramref name="dwExtraInfo"/> parameter, some pointer or index to the queued extra information.
        /// When the application needs the extra information, it calls the DLL with the pointer or index
        /// stored in <paramref name="dwExtraInfo"/>, and the DLL returns the extra information.
        /// </para>
        /// </remarks>
        [Obsolete("This function has been superseded. Use SendInput instead.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "mouse_event", ExactSpelling = true)]
        public static extern void mouse_event([In] MouseEventFlags dwFlags, [In] DWORD dx, [In] DWORD dy, [In] DWORD dwData, [In] ULONG_PTR dwExtraInfo);
#pragma warning restore IDE1006

        /// <summary>
        /// <para>
        /// Maps OEMASCII codes 0 through 0x0FF into the OEM scan codes and shift states.
        /// The function provides information that allows a program to send OEM text to another program by simulating keyboard input.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-oemkeyscan"/>
        /// </para>
        /// </summary>
        /// <param name="wOemChar">
        /// The ASCII value of the OEM character.
        /// </param>
        /// <returns>
        /// <para>
        /// The low-order word of the return value contains the scan code of the OEM character,
        /// and the high-order word contains the shift state, which can be a combination of the following bits.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Bit
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Either SHIFT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Either CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// Either ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8
        /// </term>
        /// <term>
        /// The Hankaku key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16
        /// </term>
        /// <term>
        /// Reserved (defined by the keyboard layout driver).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 32
        /// </term>
        /// <term>
        /// Reserved (defined by the keyboard layout driver).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the character cannot be produced by a single keystroke using the current keyboard layout, the return value is –1.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function does not provide translations for characters that require CTRL+ALT or dead keys.
        /// Characters not translated by this function must be copied by simulating input using the ALT+ keypad mechanism.
        /// The NUMLOCK key must be off.
        /// </para>
        /// <para>
        /// This function does not provide translations for characters that cannot be typed with one keystroke
        /// using the current keyboard layout, such as characters with diacritics requiring dead keys.
        /// Characters not translated by this function may be simulated using the ALT+ keypad mechanism.
        /// The NUMLOCK key must be on.
        /// </para>
        /// <para>
        /// This function is implemented using the <see cref="VkKeyScan"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OemKeyScan", ExactSpelling = true)]
        public static extern DWORD OemKeyScan([In] WORD wOemChar);

        /// <summary>
        /// <para>
        /// Registers the devices that supply the raw input data.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerrawinputdevices"/>
        /// </para>
        /// </summary>
        /// <param name="pRawInputDevices">
        /// An array of <see cref="RAWINPUTDEVICE"/> structures that represent the devices that supply the raw input.
        /// Pointer should be aligned on a <see cref="DWORD"/> (32-bit) boundary.
        /// </param>
        /// <param name="uiNumDevices">
        /// The number of <see cref="RAWINPUTDEVICE"/> structures pointed to by <paramref name="pRawInputDevices"/>.
        /// </param>
        /// <param name="cbSize">
        /// The size, in bytes, of a <see cref="RAWINPUTDEVICE"/> structure.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call <see cref="GetLastError"/> for more information.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To receive <see cref="WM_INPUT"/> messages,
        /// an application must first register the raw input devices using <see cref="RegisterRawInputDevices"/>.
        /// By default, an application does not receive raw input.
        /// </para>
        /// <para>
        /// To receive <see cref="WM_INPUT_DEVICE_CHANGE"/> messages,
        /// an application must specify the <see cref="RIDEV_DEVNOTIFY"/> flag for each device class
        /// that is specified by the <see cref="RAWINPUTDEVICE.usUsagePage"/> and
        /// <see cref="RAWINPUTDEVICE.usUsage"/> fields of the <see cref="RAWINPUTDEVICE"/> structure.
        /// By default, an application does not receive <see cref="WM_INPUT_DEVICE_CHANGE"/> notifications for raw input device arrival and removal.
        /// </para>
        /// <para>
        /// If a <see cref="RAWINPUTDEVICE"/> structure has the <see cref="RIDEV_REMOVE"/> flag set
        /// and the <see cref="RAWINPUTDEVICE.hwndTarget"/> parameter is not set to <see cref="NULL"/>, then parameter validation will fail.
        /// </para>
        /// <para>
        /// Only one window per raw input device class may be registered to receive raw input within a process
        /// (the window passed in the last call to <see cref="RegisterRawInputDevices"/>).
        /// Because of this, <see cref="RegisterRawInputDevices"/> should not be used from a library,
        /// as it may interfere with any raw input processing logic already present in applications that load it.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterRawInputDevices", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterRawInputDevices([In] RAWINPUTDEVICE[] pRawInputDevices, [In] UINT uiNumDevices, [In] UINT cbSize);

        /// <summary>
        /// <para>
        /// Releases the mouse capture from a window in the current thread and restores normal mouse input processing.
        /// A window that has captured the mouse receives all mouse input, regardless of the position of the cursor,
        /// except when a mouse button is clicked while the cursor hot spot is in the window of another thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasecapture"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// An application calls this function after calling the <see cref="SetCapture"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ReleaseCapture", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ReleaseCapture();

        /// <summary>
        /// <para>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-sendinput"/>
        /// </para>
        /// </summary>
        /// <param name="cInputs">
        /// The number of structures in the <paramref name="pInputs"/> array.
        /// </param>
        /// <param name="pInputs">
        /// An array of <see cref="INPUT"/> structures.
        /// Each structure represents an event to be inserted into the keyboard or mouse input stream.
        /// </param>
        /// <param name="cbSize">
        /// The size, in bytes, of an <see cref="INPUT"/> structure.
        /// If <paramref name="cbSize"/> is not the size of an <see cref="INPUT"/> structure, the function fails.
        /// </param>
        /// <returns>
        /// <para>
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
        /// If the function returns zero, the input was already blocked by another thread.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// This function fails when it is blocked by UIPI.
        /// Note that neither <see cref="GetLastError"/> nor the return value will indicate the failure was caused by UIPI blocking.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function is subject to UIPI.
        /// Applications are permitted to inject input only into applications that are at an equal or lesser integrity level.
        /// </para>
        /// <para>
        /// The <see cref="SendInput"/> function inserts the events in the <see cref="INPUT"/> structures serially into the keyboard or mouse input stream.
        /// These events are not interspersed with other keyboard or mouse input events inserted either by the user (with the keyboard or mouse)
        /// or by calls to <see cref="keybd_event"/>, <see cref="mouse_event"/>, or other calls to <see cref="SendInput"/>.
        /// </para>
        /// <para>
        /// This function does not reset the keyboard's current state.
        /// Any keys that are already pressed when the function is called might interfere with the events that this function generates.
        /// To avoid this problem, check the keyboard's state with the <see cref="GetAsyncKeyState"/> function and correct as necessary.
        /// </para>
        /// <para>
        /// Because the touch keyboard uses the surrogate macros defined in winnls.h to send input to the system,
        /// a listener on the keyboard event hook must decode input originating from the touch keyboard.
        /// For more information, see Surrogates and Supplementary Characters.
        /// </para>
        /// <para>
        /// An accessibility application can use <see cref="SendInput"/> to inject keystrokes
        /// corresponding to application launch shortcut keys that are handled by the shell.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendInput", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SendInput([In] UINT cInputs, [In] INPUT[] pInputs, [In] int cbSize);

        /// <summary>
        /// <para>
        /// Activates a window.
        /// The window must be attached to the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setactivewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the top-level window to be activated.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the window that was previously active.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="SetActiveWindow"/> function activates a window, but not if the application is in the background.
        /// The window will be brought into the foreground (top of Z-Order) if its application is in the foreground when the system activates the window.
        /// </para>
        /// <para>
        /// If the window identified by the <paramref name="hWnd"/> parameter was created by the calling thread,
        /// the active window status of the calling thread is set to <paramref name="hWnd"/>.
        /// Otherwise, the active window status of the calling thread is set to <see cref="NULL"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetActiveWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetActiveWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Sets the mouse capture to the specified window belonging to the current thread.
        /// <see cref="SetCapture"/> captures mouse input either when the mouse is over the capturing window,
        /// or when the mouse button was pressed while the mouse was over the capturing window and the button is still down.
        /// Only one window at a time can capture the mouse.
        /// </para>
        /// <para>
        /// If the mouse cursor is over a window created by another thread,
        /// the system will direct mouse input to the specified window only if a mouse button is down.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcapture"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window in the current thread that is to capture the mouse.
        /// </param>
        /// <returns>
        /// The return value is a handle to the window that had previously captured the mouse.
        /// If there is no such window, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Only the foreground window can capture the mouse.
        /// When a background window attempts to do so, the window receives messages only for mouse events
        /// that occur when the cursor hot spot is within the visible portion of the window.
        /// Also, even if the foreground window has captured the mouse, the user can still click another window, bringing it to the foreground.
        /// </para>
        /// <para>
        /// When the window no longer requires all mouse input,
        /// the thread that created the window should call the <see cref="ReleaseCapture"/> function to release the mouse.
        /// </para>
        /// <para>
        /// This function cannot be used to capture mouse input meant for another process.
        /// </para>
        /// <para>
        /// When the mouse is captured, menu hotkeys and other keyboard accelerators do not work.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCapture", ExactSpelling = true)]
        public static extern HWND SetCapture([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Sets the double-click time for the mouse.
        /// A double-click is a series of two clicks of a mouse button, the second occurring within a specified time after the first.
        /// The double-click time is the maximum number of milliseconds that may occur between the first and second clicks of a double-click.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setdoubleclicktime"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1">
        /// The number of milliseconds that may occur between the first and second clicks of a double-click.
        /// If this parameter is set to 0, the system uses the default double-click time of 500 milliseconds.
        /// If this parameter value is greater than 5000 milliseconds, the system sets the value to 5000 milliseconds.
        /// </param>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="SetDoubleClickTime"/> function alters the double-click time for all windows in the system.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDoubleClickTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetDoubleClickTime([In] UINT unnamedParam1);

        /// <summary>
        /// <para>
        /// Sets the keyboard focus to the specified window.
        /// The window must be attached to the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setfocus"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that will receive the keyboard input.
        /// If this parameter is <see cref="NULL"/>, keystrokes are ignored.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the window that previously had the keyboard focus.
        /// If the <paramref name="hWnd"/> parameter is invalid or the window is not attached to the calling thread's message queue,
        /// the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/> function.
        /// </para>
        /// <para>
        /// Extended error <see cref="ERROR_INVALID_PARAMETER"/> (0x57) means that window is in disabled state.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// This function sends a <see cref="WM_KILLFOCUS"/> message to the window that loses the keyboard focus
        /// and a <see cref="WM_SETFOCUS"/> message to the window that receives the keyboard focus.
        /// It also activates either the window that receives the focus or the parent of the window that receives the focus.
        /// </para>
        /// <para>
        /// If a window is active but does not have the focus,
        /// any key pressed produces the <see cref="WM_SYSCHAR"/>, <see cref="WM_SYSKEYDOWN"/>, or <see cref="WM_SYSKEYUP"/> message.
        /// If the <see cref="VK_MENU"/> key is also pressed, bit 30 of the lParam parameter of the message is set.
        /// Otherwise, the messages produced do not have this bit set.
        /// </para>
        /// <para>
        /// By using the <see cref="AttachThreadInput"/> function, a thread can attach its input processing to another thread.
        /// This allows a thread to call SetFocus to set the keyboard focus to a window attached to another thread's message queue.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetFocus", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetFocus([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Copies an array of keyboard key states into the calling thread's keyboard input-state table.
        /// This is the same table accessed by the <see cref="GetKeyboardState"/> and <see cref="GetKeyState"/> functions.
        /// Changes made to this table do not affect keyboard input to any other thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setkeyboardstate"/>
        /// </para>
        /// </summary>
        /// <param name="lpKeyState">
        /// A pointer to a 256-byte array that contains keyboard key states.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Because the SetKeyboardState function alters the input state of the calling thread and not the global input state of the system,
        /// an application cannot use <see cref="SetKeyboardState"/> to set the NUM LOCK, CAPS LOCK,
        /// or SCROLL LOCK (or the Japanese KANA) indicator lights on the keyboard.
        /// These can be set or cleared using <see cref="SendInput"/> to simulate keystrokes.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetKeyboardState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetKeyboardState([In] BYTE[] lpKeyState);

        /// <summary>
        /// <para>
        /// Sets the feedback configuration for a window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowfeedbacksetting"/>
        /// </para>
        /// </summary>
        /// <param name="hwnd">
        /// The window to configure feedback on.
        /// </param>
        /// <param name="feedback">
        /// One of the values from the <see cref="FEEDBACK_TYPE"/> enumeration.
        /// </param>
        /// <param name="dwFlags">
        /// Reserved.
        /// Must be 0.
        /// </param>
        /// <param name="size">
        /// The size, in bytes, of the configuration data.
        /// Must be <c>sizeof(BOOL)</c> or 0 if the feedback setting is being reset.
        /// </param>
        /// <param name="configuration">
        /// The configuration data.
        /// Must be <see cref="BOOL"/> or <see cref="NULL"/> if the feedback setting is being reset.
        /// </param>
        /// <returns>
        /// Returns <see cref="TRUE"/> if successful; otherwise, returns <see cref="FALSE"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetWindowFeedbackSetting", ExactSpelling = true)]
        public static extern BOOL SetWindowFeedbackSetting([In] HWND hwnd, [In] FEEDBACK_TYPE feedback, [In] DWORD dwFlags,
            [In] UINT32 size, [In] PVOID configuration);

        /// <summary>
        /// <para>
        /// Reverses or restores the meaning of the left and right mouse buttons.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-swapmousebutton"/>
        /// </para>
        /// </summary>
        /// <param name="fSwap">
        /// If this parameter is <see cref="TRUE"/>, the left button generates right-button messages and the right button generates left-button messages.
        /// If this parameter is <see cref="FALSE"/>, the buttons are restored to their original meanings.
        /// </param>
        /// <returns>
        /// <para>
        /// If the meaning of the mouse buttons was reversed previously, before the function was called, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the meaning of the mouse buttons was not reversed, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// Button swapping is provided as a convenience to people who use the mouse with their left hands.
        /// The <see cref="SwapMouseButton"/> function is usually called by Control Panel only.
        /// Although an application is free to call the function, the mouse is a shared resource and
        /// reversing the meaning of its buttons affects all applications.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwapMouseButton", ExactSpelling = true)]
        public static extern BOOL SwapMouseButton([In] BOOL fSwap);

        /// <summary>
        /// <para>
        /// Translates the specified virtual-key code and keyboard state to the corresponding character or characters.
        /// The function translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.
        /// </para>
        /// <para>
        /// To specify a handle to the keyboard layout to use to translate the specified code, use the <see cref="ToAsciiEx"/> function.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This method may not work properly with some keyboard layouts that may produce multiple characters
        /// (i.e. ligatures) and/or supplementary Unicode characters on a single key press.
        /// It is highly recommended to use the <see cref="ToUnicode"/> or <see cref="ToUnicodeEx"/> methods that handles such cases properly.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-toascii"/>
        /// </para>
        /// </summary>
        /// <param name="uVirtKey">
        /// The virtual-key code to be translated. See Virtual-Key Codes.
        /// </param>
        /// <param name="uScanCode">
        /// The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed).
        /// </param>
        /// <param name="lpKeyState">
        /// <para>
        /// A pointer to a 256-byte array that contains the current keyboard state. Each element (byte) in the array contains the state of one key.
        /// If the high-order bit of a byte is set, the key is down (pressed).
        /// </para>
        /// <para>
        /// The low bit, if set, indicates that the key is toggled on.
        /// In this function, only the toggle bit of the CAPS LOCK key is relevant.
        /// The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
        /// </para>
        /// </param>
        /// <param name="lpChar">
        /// The buffer that receives the translated character or characters.
        /// </param>
        /// <param name="uFlags">
        /// This parameter must be 1 if a menu is active, or 0 otherwise.
        /// </param>
        /// <returns>
        /// <para>
        /// The return value is one of the following values.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0
        /// </term>
        /// <term>
        /// The specified virtual key has no translation for the current state of the keyboard.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// One character was copied to the buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Two characters were copied to the buffer.
        /// This usually happens when a dead-key character (accent or diacritic) stored in the keyboard layout
        /// cannot be composed with the specified virtual key to form a single character.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The parameters supplied to the <see cref="ToAscii"/> function might not be sufficient to translate the virtual-key code,
        /// because a previous dead key is stored in the keyboard layout.
        /// </para>
        /// <para>
        /// Typically, <see cref="ToAscii"/> performs the translation based on the virtual-key code.
        /// In some cases, however, bit 15 of the <paramref name="uScanCode"/> parameter may be used to distinguish between a key press and a key release.
        /// The scan code is used for translating ALT+ number key combinations.
        /// </para>
        /// <para>
        /// Although NUM LOCK is a toggle key that affects keyboard behavior,
        /// <see cref="ToAscii"/> ignores the toggle setting (the low bit) of <paramref name="lpKeyState"/> (<see cref="VK_NUMLOCK"/>)
        /// because the <paramref name="uVirtKey"/> parameter alone is sufficient to distinguish the cursor movement keys
        /// (<see cref="VK_HOME"/>, <see cref="VK_INSERT"/>, and so on) from the numeric keys
        /// (<see cref="VK_DECIMAL"/>, <see cref="VK_NUMPAD0"/> - <see cref="VK_NUMPAD9"/>).
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ToAscii", ExactSpelling = true)]
        public static extern int ToAscii([In] UINT uVirtKey, [In] UINT uScanCode, [In] BYTE[] lpKeyState, [Out] out WORD lpChar, [In] UINT uFlags);

        /// <summary>
        /// <para>
        /// Posts messages when the mouse pointer leaves a window or hovers over a window for a specified amount of time.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-trackmouseevent"/>
        /// </para>
        /// </summary>
        /// <param name="lpEventTrack">
        /// A pointer to a <see cref="TRACKMOUSEEVENT"/> structure that contains tracking information.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero .
        /// </para>
        /// <para>
        /// If the function fails, return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The mouse pointer is considered to be hovering when it stays within a specified rectangle for a specified period of time.
        /// Call <see cref="SystemParametersInfo"/>.
        /// and use the values <see cref="SPI_GETMOUSEHOVERWIDTH"/>, <see cref="SPI_GETMOUSEHOVERHEIGHT"/>,
        /// and <see cref="SPI_GETMOUSEHOVERTIME"/> to retrieve the size of the rectangle and the time.
        /// </para>
        /// <para>
        /// The function can post the following messages.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Message
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="WM_NCMOUSEHOVER"/>
        /// </term>
        /// <term>
        /// The same meaning as <see cref="WM_MOUSEHOVER"/> except this is for the nonclient area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_NCMOUSELEAVE"/>
        /// </term>
        /// <term>
        /// The same meaning as <see cref="WM_MOUSELEAVE"/> except this is for the nonclient area of the window.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_MOUSEHOVER"/>
        /// </term>
        /// <term>
        /// The mouse hovered over the client area of the window for the period of time specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// Hover tracking stops when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> again if it requires further tracking of mouse hover behavior.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="WM_MOUSELEAVE"/>
        /// </term>
        /// <term>
        /// The mouse left the client area of the window specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// All tracking requested by <see cref="TrackMouseEvent"/> is canceled when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> when the mouse reenters its window
        /// if it requires further tracking of mouse hover behavior.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "TrackMouseEvent", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL TrackMouseEvent([In] in TRACKMOUSEEVENT lpEventTrack);

        /// <summary>
        /// <para>
        /// Translates a character to the corresponding virtual-key code and shift state for the current keyboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-vkkeyscanw"/>
        /// </para>
        /// </summary>
        /// <param name="ch">
        /// The character to be translated into a virtual-key code.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the low-order byte of the return value contains the virtual-key code
        /// and the high-order byte contains the shift state, which can be a combination of the following flag bits.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return value
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 1
        /// </term>
        /// <term>
        /// Either SHIFT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 2
        /// </term>
        /// <term>
        /// Either CTRL key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 4
        /// </term>
        /// <term>
        /// Either ALT key is pressed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 8
        /// </term>
        /// <term>
        /// The Hankaku key is pressed
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 16
        /// </term>
        /// <term>
        /// Reserved (defined by the keyboard layout driver).
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 32
        /// </term>
        /// <term>
        /// Reserved (defined by the keyboard layout driver).
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// If the function finds no key that translates to the passed character code, both the low-order and high-order bytes contain –1.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// For keyboard layouts that use the right-hand ALT key as a shift key (for example, the French keyboard layout),
        /// the shift state is represented by the value 6, because the right-hand ALT key is converted internally into CTRL+ALT.
        /// </para>
        /// <para>
        /// Translations for the numeric keypad (<see cref="VK_NUMPAD0"/> through <see cref="VK_DIVIDE"/>) are ignored.
        /// This function is intended to translate characters into keystrokes from the main keyboard section only.
        /// For example, the character "7" is translated into <see cref="VK_7"/>, not <see cref="VK_NUMPAD7"/>.
        /// </para>
        /// <para>
        /// <see cref="VkKeyScan"/> is used by applications that send characters by using the <see cref="WM_KEYUP"/> and <see cref="WM_KEYDOWN"/> messages.
        /// </para>
        /// </remarks>
        [Obsolete("This function has been superseded by the VkKeyScanEx function." +
            "You can still use VkKeyScan, however, if you do not need to specify a keyboard layout.")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "VkKeyScanW", ExactSpelling = true)]
        public static extern SHORT VkKeyScan([In] WCHAR ch);
    }
}
