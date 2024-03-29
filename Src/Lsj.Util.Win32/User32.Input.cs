﻿using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.MapVirtualKeyTypes;
using static Lsj.Util.Win32.Enums.SystemParametersInfoParameters;
using static Lsj.Util.Win32.Enums.VirtualKeyCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.MouseEventFlags;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// XBUTTON1
        /// </summary>
        public const ushort XBUTTON1 = 0x0001;

        /// <summary>
        /// XBUTTON2
        /// </summary>
        public const ushort XBUTTON2 = 0x0002;


        /// <summary>
        /// <para>
        /// Attaches or detaches the input processing mechanism of one thread to that of another thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-attachthreadinput"/>
        /// </para>
        /// </summary>
        /// <param name="idAttach">
        /// The identifier of the thread to be attached to another thread. The thread to be attached cannot be a system thread.
        /// </param>
        /// <param name="idAttachTo">
        /// The identifier of the thread to which <paramref name="idAttach"/> will be attached. This thread cannot be a system thread.
        /// A thread cannot attach to itself. Therefore, <paramref name="idAttachTo"/> cannot equal <paramref name="idAttach"/>.
        /// </param>
        /// <param name="fAttach">
        /// If this parameter is <see cref="TRUE"/>, the two threads are attached.
        /// If the parameter is <see cref="FALSE"/>, the threads are detached.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Windows Server 2003 and Windows XP:
        /// There is no extended error information; do not call <see cref="GetLastError"/>. This behavior changed as of Windows Vista.
        /// </returns>
        /// <remarks>
        /// By using the <see cref="AttachThreadInput"/> function, a thread can share its input states
        /// (such as keyboard states and the current focus window) with another thread.
        /// Keyboard and mouse events received by both threads are processed in the order they were received until the threads are detached
        /// by calling <see cref="AttachThreadInput"/> a second time and specifying <see cref="FALSE"/> for the <paramref name="fAttach"/> parameter.
        /// The <see cref="AttachThreadInput"/> function fails if either of the specified threads does not have a message queue.
        /// The system creates a thread's message queue when the thread makes its first call to one of the USER or GDI functions.
        /// The <see cref="AttachThreadInput"/> function also fails if a journal record hook is installed.
        /// Journal record hooks attach all input queues together.
        /// Note that key state, which can be ascertained by calls to the <see cref="GetKeyState"/> or <see cref="GetKeyboardState"/> function,
        /// is reset after a call to <see cref="AttachThreadInput"/>.
        /// You cannot attach a thread to a thread in another desktop.
        /// </remarks>
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
        /// To get the handle to the foreground window, you can use <see cref="GetForegroundWindow"/>.
        /// To get the window handle to the active window in the message queue for another thread, use <see cref="GetGUIThreadInfo"/>.
        /// </remarks>
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
        /// The virtual-key code.
        /// For more information, see Virtual Key Codes.
        /// You can use left- and right-distinguishing constants to specify certain keys.
        /// See the Remarks section for further information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies whether the key was pressed since the last call to <see cref="GetAsyncKeyState"/>,
        /// and whether the key is currently up or down.
        /// If the most significant bit is set, the key is down, and if the least significant bit is set,
        /// the key was pressed after the previous call to <see cref="GetAsyncKeyState"/>.
        /// However, you should not rely on this last behavior; for more information, see the Remarks.
        /// The return value is zero for the following cases:
        /// The current desktop is not the active desktop
        /// The foreground thread belongs to another process and the desktop does not allow the hook or the journal record.
        /// </returns>
        /// <remarks>
        /// The GetAsyncKeyState function works with mouse buttons.
        /// However, it checks on the state of the physical mouse buttons, not on the logical mouse buttons that the physical buttons are mapped to.
        /// For example, the call <code>GetAsyncKeyState(VK_LBUTTON)</code> always returns the state of the left physical mouse button,
        /// regardless of whether it is mapped to the left or right logical mouse button.
        /// You can determine the system's current mapping of physical mouse buttons to logical mouse buttons
        /// by calling <code>GetSystemMetrics(SM_SWAPBUTTON)</code> which returns <see cref="TRUE"/> if the mouse buttons have been swapped.
        /// Although the least significant bit of the return value indicates whether the key has been pressed since the last query,
        /// due to the pre-emptive multitasking nature of Windows, another application can call <see cref="GetAsyncKeyState"/>
        /// and receive the "recently pressed" bit instead of your application.
        /// The behavior of the least significant bit of the return value is retained strictly for compatibility with 16-bit Windows applications
        /// (which are non-preemptive) and should not be relied upon.
        /// You can use the virtual-key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/>,
        /// and <see cref="VK_MENU"/> as values for the <paramref name="vKey"/> parameter.
        /// This gives the state of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// You can use the following virtual-key code constants as values for vKey to distinguish between the left and right instances of those keys.
        /// <see cref="VK_LSHIFT"/>, <see cref="VK_RSHIFT"/>, <see cref="VK_LCONTROL"/>, <see cref="VK_RCONTROL"/>,
        /// <see cref="VK_LMENU"/>, <see cref="VK_RMENU"/>
        /// These left- and right-distinguishing constants are only available when you call the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetAsyncKeyState", ExactSpelling = true, SetLastError = true)]
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
        /// A <see cref="NULL"/> return value means the current thread has not captured the mouse.
        /// However, it is possible that another thread or process has captured the mouse.
        /// To get a handle to the capture window on another thread, use the <see cref="GetGUIThreadInfo"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCapture", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDoubleClickTime", ExactSpelling = true, SetLastError = true)]
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
        /// <see cref="GetFocus"/> returns the window with the keyboard focus for the current thread's message queue.
        /// If <see cref="GetFocus"/> returns NULL, another thread's queue may be attached to a window that has the keyboard focus.
        /// Use the <see cref="GetForegroundWindow"/> function to retrieve the handle to the window with which the user is currently working.
        /// You can associate your thread's message queue with the windows owned by another thread by using the <see cref="AttachThreadInput"/> function.
        /// To get the window with the keyboard focus on the foreground queue or the queue of another thread, use the <see cref="GetGUIThreadInfo"/> function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetFocus", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetFocus();

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKBCodePage", ExactSpelling = true, SetLastError = true)]
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application can call this function to retrieve the current status of all the virtual keys.
        /// The status changes as a thread removes keyboard messages from its message queue.
        /// The status does not change as keyboard messages are posted to the thread's message queue,
        /// nor does it change as keyboard messages are posted to or retrieved from message queues of other threads.
        /// (Exception: Threads that are connected through <see cref="AttachThreadInput"/> share the same keyboard state.)
        /// When the function returns, each member of the array pointed to by the <paramref name="lpKeyState"/> parameter contains status data for a virtual key.
        /// If the high-order bit is 1, the key is down; otherwise, it is up.
        /// If the key is a toggle key, for example CAPS LOCK, then the low-order bit is 1 when the key is toggled and is 0 if the key is untoggled.
        /// The low-order bit is meaningless for non-toggle keys.
        /// A toggle key is said to be toggled when it is turned on.
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// To retrieve status information for an individual key, use the <see cref="GetKeyState"/> function.
        /// To retrieve the current state for an individual key regardless of whether the corresponding keyboard message has been retrieved
        /// from the message queue, use the <see cref="GetAsyncKeyState"/> function.
        /// An application can use the virtual-key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/> and <see cref="VK_MENU"/>
        /// as indices into the array pointed to by <paramref name="lpKeyState"/>.
        /// This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// An application can also use the following virtual-key code constants as indices to distinguish between the left and right instances of those keys:
        /// <see cref="VK_LSHIFT"/>, <see cref="VK_RSHIFT"/>, <see cref="VK_LCONTROL"/>, <see cref="VK_RCONTROL"/>, <see cref="VK_LMENU"/>, <see cref="VK_RMENU"/>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyboardState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetKeyboardState([MarshalAs(UnmanagedType.LPArray)][Out] BYTE[] lpKeyState);

        /// <summary>
        /// <para>
        /// Retrieves information about the current keyboard.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getkeyboardtype"/>
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
        /// The format of the key-name string depends on the current keyboard layout.
        /// The keyboard driver maintains a list of names in the form of character strings for keys with names longer than a single character.
        /// The key name is translated according to the layout of the currently installed keyboard,
        /// thus the function may give different results for different input locales.
        /// The name of a character key is the character itself.
        /// The names of dead keys are spelled out in full.
        /// </remarks>
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
        /// A virtual key.
        /// If the desired virtual key is a letter or digit (A through Z, a through z, or 0 through 9),
        /// <paramref name="nVirtKey"/> must be set to the ASCII value of that character.
        /// For other keys, it must be a virtual-key code.
        /// If a non-English keyboard layout is used, virtual keys with values in the range ASCII A through Z and 0 through 9
        /// are used to specify most of the character keys.
        /// For example, for the German keyboard layout, the virtual key of value ASCII O (0x4F) refers to the "o" key,
        /// whereas <see cref="VK_OEM_1"/> refers to the "o with umlaut" key.
        /// </param>
        /// <returns>
        /// The return value specifies the status of the specified virtual key, as follows:
        /// If the high-order bit is 1, the key is down; otherwise, it is up.
        /// If the low-order bit is 1, the key is toggled.
        /// A key, such as the CAPS LOCK key, is toggled if it is turned on.
        /// The key is off and untoggled if the low-order bit is 0.
        /// A toggle key's indicator light (if any) on the keyboard will be on when the key is toggled, and off when the key is untoggled.
        /// </returns>
        /// <remarks>
        /// The key status returned from this function changes as a thread reads key messages from its message queue.
        /// The status does not reflect the interrupt-level state associated with the hardware.
        /// Use the <see cref="GetAsyncKeyState"/> function to retrieve that information.
        /// An application calls <see cref="GetKeyState"/> in response to a keyboard-input message.
        /// This function retrieves the state of the key when the input message was generated.
        /// To retrieve state information for all the virtual keys, use the <see cref="GetKeyboardState"/> function.
        /// An application can use the virtual key code constants <see cref="VK_SHIFT"/>, <see cref="VK_CONTROL"/>,
        /// and <see cref="VK_MENU"/> as values for the <paramref name="nVirtKey"/> parameter.
        /// This gives the status of the SHIFT, CTRL, or ALT keys without distinguishing between left and right.
        /// An application can also use the following virtual-key code constants as values for <paramref name="nVirtKey"/>
        /// to distinguish between the left and right instances of those keys:
        /// <see cref="VK_LSHIFT"/> <see cref="VK_RSHIFT"/> <see cref="VK_LCONTROL"/> <see cref="VK_RCONTROL"/> <see cref="VK_LMENU"/> <see cref="VK_RMENU"/>
        /// These left- and right-distinguishing constants are available to an application only through the <see cref="GetKeyboardState"/>,
        /// <see cref="SetKeyboardState"/>, <see cref="GetAsyncKeyState"/>, <see cref="GetKeyState"/>, and <see cref="MapVirtualKey"/> functions.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetKeyState", ExactSpelling = true, SetLastError = true)]
        public static extern SHORT GetKeyState([In] int nVirtKey);

        /// <summary>
        /// <para>
        /// Gets device properties that aren't included in the <see cref="POINTER_DEVICE_INFO"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdeviceproperties"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The pointer device to query properties from.
        /// A call to the <see cref="GetPointerDevices"/> function returns this handle in the <see cref="POINTER_DEVICE_INFO"/> structure.
        /// </param>
        /// <param name="propertyCount">
        /// The number of properties.
        /// Returns the count that's written or needed if <paramref name="pointerProperties"/> is <see langword="null"/>.
        /// If this value is less than the number of properties that the pointer device supports
        /// and <paramref name="pointerProperties"/> is not <see langword="null"/>,
        /// the function returns the actual number of properties in this variable and fails.
        /// </param>
        /// <param name="pointerProperties">
        /// The array of properties.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call the <see cref="GetLastError"/> function for more information.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDeviceProperties", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDeviceProperties([In] HANDLE device, [In][Out] ref UINT32 propertyCount,
            [Out] POINTER_DEVICE_PROPERTY[] pointerProperties);

        /// <summary>
        /// <para>
        /// Gets information about the pointer device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevice"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The handle to the device.
        /// </param>
        /// <param name="pointerDevice">
        /// A <see cref="POINTER_DEVICE_INFO"/> structure that contains information about the pointer device.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDevice", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDevice([In] HANDLE device, [Out] out POINTER_DEVICE_INFO pointerDevice);

        /// <summary>
        /// <para>
        /// Gets information about the pointer devices attached to the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevices"/>
        /// </para>
        /// </summary>
        /// <param name="deviceCount">
        /// If <paramref name="pointerDevices"/> is <see langword="null"/>,
        /// <paramref name="deviceCount"/> returns the total number of attached pointer devices.
        /// Otherwise, <paramref name="deviceCount"/> specifies
        /// the number of <see cref="POINTER_DEVICE_INFO"/> structures pointed to by <paramref name="pointerDevices"/>.
        /// </param>
        /// <param name="pointerDevices">
        /// Array of <see cref="POINTER_DEVICE_INFO"/> structures for the pointer devices attached to the system.
        /// If <see langword="null"/>, the total number of attached pointer devices is returned in <paramref name="deviceCount"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Windows 8 supports the following:
        /// 256 contacts per pointer device.
        /// 2560 total contacts per system session, regardless of the number of attached devices.
        /// For example, 10 pointer devices with 256 contacts each, 20 pointer devices with 128 contacts each, and so on.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDevices", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDevices([In][Out] ref UINT32 deviceCount, [Out] POINTER_DEVICE_INFO[] pointerDevices);

        /// <summary>
        /// <para>
        /// Translates (maps) a virtual-key code into a scan code or character value, or translates a scan code into a virtual-key code.
        /// To specify a handle to the keyboard layout to use for translating the specified code, use the <see cref="MapVirtualKeyEx"/> function.
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "MapVirtualKeyW", ExactSpelling = true, SetLastError = true)]
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
        /// Controls various aspects of mouse motion and button clicking.
        /// This parameter can be certain combinations of the following values.
        /// <see cref="MOUSEEVENTF_ABSOLUTE"/>:
        /// The <paramref name="dx"/> and <paramref name="dy"/> parameters contain normalized absolute coordinates.
        /// If not set, those parameters contain relative data: the change in position since the last reported position.
        /// This flag can be set, or not set, regardless of what kind of mouse or mouse-like device, if any, is connected to the system.
        /// For further information about relative mouse motion, see the following Remarks section. 
        /// </param>
        /// <see cref="MOUSEEVENTF_LEFTDOWN"/>:
        /// The left button is down. 
        /// <see cref="MOUSEEVENTF_LEFTUP"/>:
        /// The left button is up.
        /// <see cref="MOUSEEVENTF_MIDDLEDOWN"/>:
        /// The middle button is down.
        /// <see cref="MOUSEEVENTF_MIDDLEUP"/>:
        /// The middle button is up.
        /// <see cref="MOUSEEVENTF_MOVE"/>:
        /// Movement occurred.
        /// <see cref="MOUSEEVENTF_RIGHTDOWN"/>:
        /// The right button is down.
        /// <see cref="MOUSEEVENTF_RIGHTUP"/>:
        /// The right button is up.
        /// <see cref="MOUSEEVENTF_WHEEL"/>:
        /// The wheel has been moved, if the mouse has a wheel. The amount of movement is specified in <paramref name="dwData"/>.
        /// <see cref="MOUSEEVENTF_XDOWN"/>:
        /// An X button was pressed.
        /// <see cref="MOUSEEVENTF_XUP"/>:
        /// An X button was released.
        /// <see cref="MOUSEEVENTF_WHEEL"/>:
        /// The wheel button is rotated.
        /// <see cref="MOUSEEVENTF_HWHEEL"/>:
        /// The wheel button is tilted.
        /// The values that specify mouse button status are set to indicate changes in status, not ongoing conditions.
        /// For example, if the left mouse button is pressed and held down, <see cref="MOUSEEVENTF_LEFTDOWN"/> is set
        /// when the left button is first pressed, but not for subsequent motions.
        /// Similarly, <see cref="MOUSEEVENTF_LEFTUP"/> is set only when the button is first released.
        /// You cannot specify both <see cref="MOUSEEVENTF_WHEEL"/> and either <see cref="MOUSEEVENTF_XDOWN"/>
        /// or <see cref="MOUSEEVENTF_XUP"/> simultaneously in the <paramref name="dwFlags"/> parameter,
        /// because they both require use of the <paramref name="dwData"/> field.
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
        /// If dwFlags contains <see cref="MOUSEEVENTF_WHEEL"/>, then <paramref name="dwData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// If dwFlags contains <see cref="MOUSEEVENTF_HWHEEL"/>, then <paramref name="dwData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was tilted to the right; a negative value indicates that the wheel was tilted to the left.
        /// If dwFlags contains <see cref="MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF_XUP"/>,
        /// then <paramref name="dwData"/> specifies which X buttons were pressed or released.
        /// This value may be any combination of the following flags.
        /// If dwFlags is not <see cref="MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF_XDOWN"/>,
        /// or <see cref="MOUSEEVENTF_XDOWN"/>, then <paramref name="dwData"/> should be zero.
        /// <see cref="XBUTTON1"/>: Set if the first X button was pressed or released.
        /// <see cref="XBUTTON2"/>: Set if the second X button was pressed or released. 
        /// </param>
        /// <param name="dwExtraInfo">
        /// An additional value associated with the mouse event.
        /// An application calls <see cref="GetMessageExtraInfo"/> to obtain this extra information.
        /// </param>
        /// <remarks>
        /// If the mouse has moved, indicated by <see cref="MOUSEEVENTF_MOVE"/> being set,
        /// <paramref name="dx"/> and <paramref name="dy"/> hold information about that motion.
        /// The information is specified as absolute or relative integer values.
        /// If <see cref="MOUSEEVENTF_ABSOLUTE"/> value is specified, dx and dy contain normalized absolute coordinates between 0 and 65,535.
        /// The event procedure maps these coordinates onto the display surface.
        /// Coordinate (0,0) maps onto the upper-left corner of the display surface, (65535,65535) maps onto the lower-right corner.
        /// If the <see cref="MOUSEEVENTF_ABSOLUTE"/> value is not specified,
        /// <paramref name="dx"/> and <paramref name="dy"/> specify relative motions from
        /// when the last mouse event was generated (the last reported position).
        /// Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
        /// Relative mouse motion is subject to the settings for mouse speed and acceleration level.
        /// An end user sets these values using the Mouse application in Control Panel.
        /// An application obtains and sets these values with the <see cref="SystemParametersInfo"/> function.
        /// The system applies two tests to the specified relative mouse motion when applying acceleration.
        /// If the specified distance along either the x or y axis is greater than the first mouse threshold value,
        /// and the mouse acceleration level is not zero, the operating system doubles the distance.
        /// If the specified distance along either the x- or y-axis is greater than the second mouse threshold value,
        /// and the mouse acceleration level is equal to two, the operating system doubles the distance
        /// that resulted from applying the first threshold test.
        /// It is thus possible for the operating system to multiply relatively-specified mouse motion along the x- or y-axis by up to four times.
        /// Once acceleration has been applied, the system scales the resultant value by the desired mouse speed.
        /// Mouse speed can range from 1 (slowest) to 20 (fastest) and represents how much the pointer moves based on the distance the mouse moves.
        /// The default value is 10, which results in no additional modification to the mouse motion.
        /// The <see cref="mouse_event"/> function is used to synthesize mouse events by applications that need to do so.
        /// It is also used by applications that need to obtain more information from the mouse than its position and button state.
        /// For example, if a tablet manufacturer wants to pass pen-based information to its own applications,
        /// it can write a DLL that communicates directly to the tablet hardware, obtains the extra information, and saves it in a queue.
        /// The DLL then calls mouse_event with the standard button and x/y position data, along with,
        /// in the <paramref name="dwExtraInfo"/> parameter, some pointer or index to the queued extra information.
        /// When the application needs the extra information, it calls the DLL with the pointer or index stored in <paramref name="dwExtraInfo"/>,
        /// and the DLL returns the extra information.
        /// </remarks>
        [Obsolete("This function has been superseded. Use SendInput instead.")]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "mouse_event", ExactSpelling = true, SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OemKeyScan", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD OemKeyScan([In] WORD wOemChar);

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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application calls this function after calling the <see cref="SetCapture"/> function.
        /// </remarks>
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
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
        /// If the function returns zero, the input was already blocked by another thread.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// This function fails when it is blocked by UIPI.
        /// Note that neither <see cref="GetLastError"/> nor the return value will indicate the failure was caused by UIPI blocking.
        /// </returns>
        /// <remarks>
        /// This function is subject to UIPI.
        /// Applications are permitted to inject input only into applications that are at an equal or lesser integrity level.
        /// The <see cref="SendInput"/> function inserts the events in the <see cref="INPUT"/> structures serially into the keyboard or mouse input stream.
        /// These events are not interspersed with other keyboard or mouse input events inserted
        /// either by the user (with the keyboard or mouse) or by calls to keybd_event, mouse_event, or other calls to <see cref="SendInput"/>.
        /// This function does not reset the keyboard's current state.
        /// Any keys that are already pressed when the function is called might interfere with the events that this function generates.
        /// To avoid this problem, check the keyboard's state with the <see cref="GetAsyncKeyState"/> function and correct as necessary.
        /// Because the touch keyboard uses the surrogate macros defined in winnls.h to send input to the system,
        /// a listener on the keyboard event hook must decode input originating from the touch keyboard.
        /// For more information, see Surrogates and Supplementary Characters.
        /// An accessibility application can use <see cref="SendInput"/> to inject keystrokes corresponding
        /// to application launch shortcut keysthat are handled by the shell.
        /// This functionality is not guaranteed to work for other types of applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SendInput", ExactSpelling = true, SetLastError = true)]
        public static extern UINT SendInput([In] UINT cInputs, [MarshalAs(UnmanagedType.LPArray)][In] INPUT[] pInputs, [In] int cbSize);

        /// <summary>
        /// <para>
        /// Activates a window. The window must be attached to the calling thread's message queue.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setactivewindow"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the top-level window to be activated.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the window that was previously active.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetActiveWindow"/> function activates a window, but not if the application is in the background.
        /// The window will be brought into the foreground (top of Z-Order) if its application is in the foreground when the system activates the window.
        /// If the window identified by the <paramref name="hWnd"/> parameter was created by the calling thread,
        /// the active window status of the calling thread is set to <paramref name="hWnd"/>.
        /// Otherwise, the active window status of the calling thread is set to <see cref="NULL"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetActiveWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetActiveWindow([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Sets the mouse capture to the specified window belonging to the current thread.
        /// <see cref="SetCapture"/> captures mouse input either when the mouse is over the capturing window,
        /// or when the mouse button was pressed while the mouse was over the capturing window and the button is still down.
        /// Only one window at a time can capture the mouse.
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
        /// Only the foreground window can capture the mouse.
        /// When a background window attempts to do so, the window receives messages only for mouse events that occur
        /// when the cursor hot spot is within the visible portion of the window.
        /// Also, even if the foreground window has captured the mouse, the user can still click another window, bringing it to the foreground.
        /// When the window no longer requires all mouse input, the thread that created the window
        /// should call the <see cref="ReleaseCapture"/> function to release the mouse.
        /// This function cannot be used to capture mouse input meant for another process.
        /// When the mouse is captured, menu hotkeys and other keyboard accelerators do not work.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCapture", ExactSpelling = true, SetLastError = true)]
        public static extern HWND SetCapture([In] HWND hWnd);

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
        /// If the function succeeds, the return value is the handle to the window that previously had the keyboard focus.
        /// If the <paramref name="hWnd"/> parameter is invalid or the window is not attached to the calling thread's message queue,
        /// the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// This function sends a <see cref="WM_KILLFOCUS"/> message to the window that loses the keyboard focus
        /// and a <see cref="WM_SETFOCUS"/> message to the window that receives the keyboard focus.
        /// It also activates either the window that receives the focus or the parent of the window that receives the focus.
        /// If a window is active but does not have the focus, any key pressed produces the <see cref="WM_SYSCHAR"/>,
        /// <see cref="WM_SYSKEYDOWN"/>, or <see cref="WM_SYSKEYUP"/> message.
        /// If the <see cref="VK_MENU"/> key is also pressed, bit 30 of the lParam parameter of the message is set.
        /// Otherwise, the messages produced do not have this bit set.
        /// By using the <see cref="AttachThreadInput"/> function, a thread can attach its input processing to another thread.
        /// This allows a thread to call <see cref="SetFocus"/> to set the keyboard focus to a window attached to another thread's message queue.
        /// </remarks>
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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Because the SetKeyboardState function alters the input state of the calling thread and not the global input state of the system,
        /// an application cannot use <see cref="SetKeyboardState"/> to set the NUM LOCK, CAPS LOCK,
        /// or SCROLL LOCK (or the Japanese KANA) indicator lights on the keyboard.
        /// These can be set or cleared using <see cref="SendInput"/> to simulate keystrokes.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetKeyboardState", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetKeyboardState([MarshalAs(UnmanagedType.LPArray)][In] BYTE[] lpKeyState);

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
        /// If the meaning of the mouse buttons was reversed previously, before the function was called, the return value is <see cref="TRUE"/>.
        /// If the meaning of the mouse buttons was not reversed, the return value is <see cref="FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Button swapping is provided as a convenience to people who use the mouse with their left hands.
        /// The <see cref="SwapMouseButton"/> function is usually called by Control Panel only.
        /// Although an application is free to call the function, the mouse is a shared resource and
        /// reversing the meaning of its buttons affects all applications.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwapMouseButton", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SwapMouseButton([In] BOOL fSwap);

        /// <summary>
        /// <para>
        /// Translates the specified virtual-key code and keyboard state to the corresponding character or characters.
        /// The function translates the code using the input language and physical keyboard layout identified by the keyboard layout handle.
        /// To specify a handle to the keyboard layout to use to translate the specified code, use the <see cref="ToAsciiEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="uVirtKey">
        /// The virtual-key code to be translated. See Virtual-Key Codes.
        /// </param>
        /// <param name="uScanCode">
        /// The hardware scan code of the key to be translated. The high-order bit of this value is set if the key is up (not pressed).
        /// </param>
        /// <param name="lpKeyState">
        /// A pointer to a 256-byte array that contains the current keyboard state.
        /// Each element (byte) in the array contains the state of one key.
        /// If the high-order bit of a byte is set, the key is down (pressed).
        /// The low bit, if set, indicates that the key is toggled on.
        /// In this function, only the toggle bit of the CAPS LOCK key is relevant.
        /// The toggle state of the NUM LOCK and SCROLL LOCK keys is ignored.
        /// </param>
        /// <param name="lpChar">
        /// The buffer that receives the translated character or characters.
        /// </param>
        /// <param name="uFlags">
        /// This parameter must be 1 if a menu is active, or 0 otherwise.
        /// </param>
        /// <returns>
        /// If the specified key is a dead key, the return value is negative. Otherwise, it is one of the following values.
        /// 0: 	The specified virtual key has no translation for the current state of the keyboard.
        /// 1: One character was copied to the buffer.
        /// 2: Two characters were copied to the buffer. This usually happens when a dead-key character (accent or diacritic) stored
        /// in the keyboard layout cannot be composed with the specified virtual key to form a single character.
        /// </returns>
        /// <remarks>
        /// The parameters supplied to the <see cref="ToAscii"/> function might not be sufficient to translate the virtual-key code,
        /// because a previous dead key is stored in the keyboard layout.
        /// Typically, <see cref="ToAscii"/> performs the translation based on the virtual-key code.
        /// In some cases, however, bit 15 of the <paramref name="uScanCode"/> parameter may be used to distinguish between a key press and a key release.
        /// The scan code is used for translating ALT+ number key combinations.
        /// Although NUM LOCK is a toggle key that affects keyboard behavior,
        /// <see cref="ToAscii"/> ignores the toggle setting (the low bit) of <paramref name="lpKeyState"/> (VK_NUMLOCK)
        /// because the <paramref name="uVirtKey"/> parameter alone is sufficient to distinguish the cursor movement keys
        /// (<see cref="VK_HOME"/>, <see cref="VK_INSERT"/>, and so on)
        /// from the numeric keys (<see cref="VK_DECIMAL"/>, <see cref="VK_NUMPAD0"/> - <see cref="VK_NUMPAD9"/>).
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ToAscii", ExactSpelling = true, SetLastError = true)]
        public static extern int ToAscii([In] UINT uVirtKey, [In] UINT uScanCode, [MarshalAs(UnmanagedType.LPArray)][In] BYTE[] lpKeyState,
            [Out] out WORD lpChar, [In] UINT uFlags);

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
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The mouse pointer is considered to be hovering when it stays within a specified rectangle for a specified period of time.
        /// Call <see cref="SystemParametersInfo"/>. and use the values <see cref="SPI_GETMOUSEHOVERWIDTH"/>,
        /// <see cref="SPI_GETMOUSEHOVERHEIGHT"/>, and <see cref="SPI_GETMOUSEHOVERTIME"/> to retrieve the size of the rectangle and the time.
        /// The function can post the following messages.
        /// <see cref="WM_NCMOUSEHOVER"/>: The same meaning as <see cref="WM_MOUSEHOVER"/> except this is for the nonclient area of the window.
        /// <see cref="WM_NCMOUSELEAVE"/>: The same meaning as <see cref="WM_MOUSELEAVE"/> except this is for the nonclient area of the window.
        /// <see cref="WM_MOUSEHOVER"/>:
        /// The mouse hovered over the client area of the window for the period of time specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// Hover tracking stops when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> again if it requires further tracking of mouse hover behavior.
        /// <see cref="WM_MOUSELEAVE"/>:
        /// The mouse left the client area of the window specified in a prior call to <see cref="TrackMouseEvent"/>.
        /// All tracking requested by <see cref="TrackMouseEvent"/> is canceled when this message is generated.
        /// The application must call <see cref="TrackMouseEvent"/> when the mouse reenters its window
        /// if it requires further tracking of mouse hover behavior.
        /// </remarks>
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "VkKeyScanW", ExactSpelling = true, SetLastError = true)]
        public static extern SHORT VkKeyScan([In] WCHAR ch);
    }
}
