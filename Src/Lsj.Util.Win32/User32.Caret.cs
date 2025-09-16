using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowClassStyles;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Creates a new shape for the system caret and assigns ownership of the caret to the specified window.
        /// The caret shape can be a line, a block, or a bitmap.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createcaret"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// </param>
        /// <param name="hBitmap">
        /// A handle to the bitmap that defines the caret shape.
        /// If this parameter is <see cref="NULL"/>, the caret is solid.
        /// If this parameter is (HBITMAP) 1, the caret is gray.
        /// If this parameter is a bitmap handle, the caret is the specified bitmap.
        /// The bitmap handle must have been created by the <see cref="CreateBitmap"/>, <see cref="CreateDIBitmap"/>, or <see cref="LoadBitmap"/> function.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/>
        /// ignores the <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters;
        /// the bitmap defines its own width and height.
        /// </param>
        /// <param name="nWidth">
        /// The width of the caret, in logical units.
        /// If this parameter is zero, the width is set to the system-defined window border width.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/> ignores this parameter.
        /// </param>
        /// <param name="nHeight">
        /// The height of the caret, in logical units.
        /// If this parameter is zero, the height is set to the system-defined window border height.
        /// If <paramref name="hBitmap"/> is a bitmap handle, <see cref="CreateCaret"/> ignores this parameter.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <paramref name="nWidth"/> and <paramref name="nHeight"/> parameters specify the caret's width and height, in logical units;
        /// the exact width and height, in pixels, depend on the window's mapping mode.
        /// <see cref="CreateCaret"/> automatically destroys the previous caret shape, if any, regardless of the window that owns the caret.
        /// The caret is hidden until the application calls the <see cref="ShowCaret"/> function to make the caret visible.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The width and height parameters are interpreted as logical sizes in terms of the window in question.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateCaret([In] HWND hWnd, [In] HBITMAP hBitmap, [In] int nWidth, [In] int nHeight);

        /// <summary>
        /// <para>
        /// Destroys the caret's current shape, frees the caret from the window, and removes the caret from the screen.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroycaret"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="DestroyCaret"/> destroys the caret only if a window in the current task owns the caret.
        /// If a window that is not in the current task owns the caret, <see cref="DestroyCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// For an example, see Destroying a Caret
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyCaret();

        /// <summary>
        /// <para>
        /// Retrieves the time required to invert the caret's pixels. The user can set this value.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcaretblinktime"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is the blink time, in milliseconds.
        /// A return value of <see cref="INFINITE"/> indicates that the caret does not blink.
        /// A return value is zero indicates that the function has failed.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCaretBlinkTime", ExactSpelling = true, SetLastError = true)]
        public static extern UINT GetCaretBlinkTime();

        /// <summary>
        /// <para>
        /// Copies the caret's position to the specified <see cref="POINT"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getcaretpos"/>
        /// </para>
        /// </summary>
        /// <param name="lpPoint">
        /// A pointer to the POINT structure that is to receive the client coordinates of the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The caret position is always given in the client coordinates of the window that contains the caret.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization. 
        /// The returned values are interpreted as logical sizes in terms of the window in question.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCaretPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetCaretPos([Out] out POINT lpPoint);

        /// <summary>
        /// <para>
        /// Removes the caret from the screen.
        /// Hiding a caret does not destroy its current shape or invalidate the insertion point.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-hidecaret"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// If this parameter is <see cref="NULL"/>, <see cref="HideCaret"/> searches the current task for the window that owns the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="HideCaret"/> hides the caret only if the specified window owns the caret.
        /// If the specified window does not own the caret, <see cref="HideCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// Hiding is cumulative.
        /// If your application calls <see cref="HideCaret"/> five times in a row,
        /// it must also call <see cref="ShowCaret"/> five times before the caret is displayed.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "HideCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL HideCaret([In] HWND hWnd);

        /// <summary>
        /// <para>
        /// Sets the caret blink time to the specified number of milliseconds.
        /// The blink time is the elapsed time, in milliseconds, required to invert the caret's pixels.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcaretblinktime"/>
        /// </para>
        /// </summary>
        /// <param name="uMSeconds">
        /// The new blink time, in milliseconds.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The user can set the blink time using the Control Panel.
        /// Applications should respect the setting that the user has chosen.
        /// The <see cref="SetCaretBlinkTime"/> function should only be used by application
        /// that allow the user to set the blink time, such as a Control Panel applet.
        /// If you change the blink time, subsequently activated applications will use the modified blink time,
        /// even if you restore the previous blink time when you lose the keyboard focus or become inactive.
        /// This is due to the multithreaded environment, where deactivation of your application is not synchronized with the activation of another application.
        /// This feature allows the system to activate another application even if the current application is not responding.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCaretBlinkTime", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCaretBlinkTime([In] UINT uMSeconds);

        /// <summary>
        /// <para>
        /// Moves the caret to the specified coordinates.
        /// If the window that owns the caret was created with the <see cref="CS_OWNDC"/> class style,
        /// then the specified coordinates are subject to the mapping mode of the device context associated with that window.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setcaretpos"/>
        /// </para>
        /// </summary>
        /// <param name="X">
        /// The new x-coordinate of the caret.
        /// </param>
        /// <param name="Y">
        /// The new y-coordinate of the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="SetCaretPos"/> moves the caret whether the caret is hidden.
        /// The system provides one caret per queue.
        /// A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// A window can set the caret position only if it owns the caret.
        /// DPI Virtualization
        /// This API does not participate in DPI virtualization.
        /// The provided position is interpreted as logical coordinates in terms of the window associated with the caret.
        /// The calling thread is not taken into consideration.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetCaretPos", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetCaretPos([In] int X, [In] int Y);

        /// <summary>
        /// <para>
        /// Makes the caret visible on the screen at the caret's current position.
        /// When the caret becomes visible, it begins flashing automatically.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showcaret"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window that owns the caret.
        /// If this parameter is <see cref="NULL"/>, <see cref="ShowCaret"/> searches the current task for the window that owns the caret.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="ShowCaret"/> shows the caret only if the specified window owns the caret, the caret has a shape,
        /// and the caret has not been hidden two or more times in a row.
        /// If one or more of these conditions is not met, <see cref="ShowCaret"/> does nothing and returns <see cref="FALSE"/>.
        /// Hiding is cumulative. If your application calls <see cref="HideCaret"/> five times in a row,
        /// it must also call <see cref="ShowCaret"/> five times before the caret reappears.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active.
        /// The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "ShowCaret", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL ShowCaret([In] HWND hWnd);
    }
}
