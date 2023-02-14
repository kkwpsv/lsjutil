using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Show Window Commands
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow"/>
    /// </para>
    /// </summary>
    public enum ShowWindowCommands : uint
    {
        /// <summary>
        /// Minimizes a window, even if the thread that owns the window is not responding.
        /// This flag should only be used when minimizing windows from a different thread.
        /// </summary>
        SW_FORCEMINIMIZE = 11,

        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        SW_HIDE = 0,

        /// <summary>
        /// Maximizes the specified window.
        /// </summary>
        SW_MAXIMIZE = 3,

        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        SW_MINIMIZE = 6,

        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position.
        /// An application should specify this flag when restoring a minimized window.
        /// /// </summary>
        SW_RESTORE = 9,

        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        SW_SHOW = 5,

        /// <summary>
        /// Sets the show state based on the SW_ value specified in the <see cref="STARTUPINFO"/> structure passed to the
        /// <see cref="CreateProcess"/> function by the program that started the application.
        /// </summary>
        SW_SHOWDEFAULT = 10,

        /// <summary>
        /// Activates the window and displays it as a maximized window.
        /// </summary>
        SW_SHOWMAXIMIZED = 3,

        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        SW_SHOWMINIMIZED = 2,

        /// <summary>
        /// Displays the window as a minimized window.
        /// This value is similar to <see cref="SW_SHOWMINIMIZED"/>, except the window is not activated.
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,

        /// <summary>
        /// Displays the window in its current size and position.
        /// This value is similar to <see cref="SW_SHOW"/>, except the window is not activated.
        /// </summary>
        SW_SHOWNA = 8,

        /// <summary>
        /// Displays a window in its most recent size and position.
        /// This value is similar to <see cref="SW_SHOWNORMAL"/>, except the window is not activated.
        /// </summary>
        SW_SHOWNOACTIVATE = 4,

        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position.
        /// An application should specify this flag when displaying the window for the first time.
        /// </summary>
        SW_SHOWNORMAL = 1,
    }
}