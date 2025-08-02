using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.ConsoleCharacterAttributes;
using static Lsj.Util.Win32.Enums.ShowWindowCommands;
using static Lsj.Util.Win32.Enums.STARTUPINFOFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// For graphical user interface (GUI) processes, this information affects the first window
    /// created by the <see cref="CreateWindow"/> function and shown by the <see cref="ShowWindow"/> function.
    /// For console processes, this information affects the console window if a new console is created for the process.
    /// A process can use the <see cref="GetStartupInfo"/> function
    /// to retrieve the <see cref="STARTUPINFO"/> structure specified when the process was created.
    /// </para>
    /// <para>
    /// If a GUI process is being started and neither <see cref="STARTF_FORCEONFEEDBACK"/>
    /// or <see cref="STARTF_FORCEOFFFEEDBACK"/> is specified, the process feedback cursor is used.
    /// A GUI process is one whose subsystem is specified as "windows."
    /// </para>
    /// <para>
    /// If a process is launched from the taskbar or jump list,
    /// the system sets <see cref="GetStartupInfo"/> to retrieve the <see cref="STARTUPINFO"/> structure
    /// and check that <see cref="hStdOutput"/> is set.
    /// If so, use <see cref="GetMonitorInfo"/> to check whether <see cref="hStdOutput"/> is a valid monitor handle (HMONITOR).
    /// The process can then use the handle to position its windows.
    /// </para>
    /// <para>
    /// If the <see cref="STARTF_UNTRUSTEDSOURCE"/> flag is specified,
    /// the application should be aware that the command line is untrusted.
    /// If this flag is set, applications should disable potentially dangerous features such as macros, downloaded content, and automatic printing.
    /// This flag is optional.
    /// Applications that call <see cref="CreateProcess"/> are encouraged to set this flag
    /// when launching a program with untrusted command line arguments (e.g. those provided by web content)
    /// so that the newly created process can apply appropriate policy.
    /// </para>
    /// <para>
    /// The <see cref="STARTF_UNTRUSTEDSOURCE"/> flag is supported starting in Windows Vista,
    /// but it is not defined in the SDK header files prior to the Windows 10 SDK.
    /// To use the flag in versions prior to Windows 10, you can define it manually in your program.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STARTUPINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// Reserved; must be <see cref="NULL"/>.
        /// </summary>
        public IntPtr lpReserved;

        /// <summary>
        /// <para>
        /// The name of the desktop, or the name of both the desktop and window station for this process.
        /// A backslash in the string indicates that the string includes both the desktop and window station names.
        /// </para>
        /// <para>
        /// For more information, see Thread Connection to a Desktop.
        /// </para>
        /// </summary>
        public IntPtr lpDesktop;

        /// <summary>
        /// For console processes, this is the title displayed in the title bar if a new console window is created.
        /// If <see cref="NULL"/>, the name of the executable file is used as the window title instead.
        /// This parameter must be <see cref="NULL"/> for GUI or console processes that do not create a new console window.
        /// </summary>
        public IntPtr lpTitle;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USEPOSITION"/>,
        /// this member is the x offset of the upper left corner of a window if a new window is created, in pixels.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The offset is from the upper left corner of the screen.
        /// For GUI processes, the specified position is used the first time the new process
        /// calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the x parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </para>
        /// </summary>
        public DWORD dwX;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USEPOSITION"/>,
        /// this member is the y offset of the upper left corner of a window if a new window is created, in pixels.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// The offset is from the upper left corner of the screen.
        /// For GUI processes, the specified position is used the first time the new process
        /// calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the y parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </para>
        /// </summary>
        public DWORD dwY;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USESIZE"/>,
        /// this member is the width of the window if a new window is created, in pixels.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// For GUI processes, this is used only the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the nWidth parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </para>
        /// </summary>
        public DWORD dwXSize;

        /// <summary>
        /// <para>
        /// f <see cref="dwFlags"/> specifies <see cref="STARTF_USESIZE"/>,
        /// this member is the height of the window if a new window is created, in pixels.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// For GUI processes, this is used only the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the nHeight parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </para>
        /// </summary>
        public DWORD dwYSize;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USECOUNTCHARS"/>,
        /// if a new console window is created in a console process, this member specifies the screen buffer width, in character columns.
        /// Otherwise, this member is ignored.
        /// </summary>
        public DWORD dwXCountChars;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USECOUNTCHARS"/>,
        /// if a new console window is created in a console process, this member specifies the screen buffer height, in character rows.
        /// Otherwise, this member is ignored.
        /// </summary>
        public DWORD dwYCountChars;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USEFILLATTRIBUTE"/>,
        /// this member is the initial text and background colors if a new console window is created in a console application.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// This value can be any combination of the following values:
        /// <see cref="FOREGROUND_BLUE"/>, <see cref="FOREGROUND_GREEN"/>, <see cref="FOREGROUND_RED"/>,
        /// <see cref="FOREGROUND_INTENSITY"/>, <see cref="BACKGROUND_BLUE"/>, <see cref="BACKGROUND_GREEN"/>,
        /// <see cref="BACKGROUND_RED"/>, and <see cref="BACKGROUND_INTENSITY"/>.
        /// For example, the following combination of values produces red text on a white background:
        /// </para>
        /// <code>
        /// FOREGROUND_RED| BACKGROUND_RED| BACKGROUND_GREEN| BACKGROUND_BLUE
        /// </code>
        /// </summary>
        public DWORD dwFillAttribute;

        /// <summary>
        /// <para>
        /// A bitfield that determines whether certain <see cref="STARTUPINFO"/> members are used when the process creates a window.
        /// This member can be one or more of the following values.
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
        /// <see cref="STARTF_FORCEONFEEDBACK"/>
        /// </para>
        /// <para>
        /// 0x00000040
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that the cursor is in feedback mode for two seconds after <see cref="CreateProcess"/> is called.
        /// The Working in Background cursor is displayed (see the Pointers tab in the Mouse control panel utility).
        /// </para>
        /// <para>
        /// If during those two seconds the process makes the first GUI call,
        /// the system gives five more seconds to the process.
        /// If during those five seconds the process shows a window,
        /// the system gives five more seconds to the process to finish drawing the window.
        /// </para>
        /// <para>
        /// The system turns the feedback cursor off after the first call to <see cref="GetMessage"/>,
        /// regardless of whether the process is drawing.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_FORCEOFFFEEDBACK"/>
        /// </para>
        /// <para>
        /// 0x00000080
        /// </para>
        /// </term>
        /// <term>
        /// Indicates that the feedback cursor is forced off while the process is starting.
        /// The Normal Select cursor is displayed.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_PREVENTPINNING"/>
        /// </para>
        /// <para>
        /// 0x00002000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that any windows created by the process cannot be pinned on the taskbar.
        /// </para>
        /// <para>
        /// This flag must be combined with <see cref="STARTF_TITLEISAPPID"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_RUNFULLSCREEN"/>
        /// </para>
        /// <para>
        /// 0x00000020
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// Indicates that the process should be run in full-screen mode, rather than in windowed mode.
        /// </para>
        /// <para>
        /// This flag is only valid for console applications running on an x86 computer.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_TITLEISAPPID"/>
        /// </para>
        /// <para>
        /// 0x00001000
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="lpTitle"/> member contains an AppUserModelID.
        /// This identifier controls how the taskbar and Start menu present the application,
        /// and enables it to be associated with the correct shortcuts and Jump Lists.
        /// Generally, applications will use the <see cref="SetCurrentProcessExplicitAppUserModelID"/>
        /// and <see cref="GetCurrentProcessExplicitAppUserModelID"/> functions instead of setting this flag.
        /// For more information, see Application User Model IDs.
        /// </para>
        /// <para>
        /// If <see cref="STARTF_PREVENTPINNING"/> is used, application windows cannot be pinned on the taskbar.
        /// The use of any AppUserModelID-related window properties by the application overrides this setting for that window only.
        /// </para>
        /// <para>
        /// This flag cannot be used with <see cref="STARTF_TITLEISLINKNAME"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_TITLEISLINKNAME"/>
        /// </para>
        /// <para>
        /// 0x00000800
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The lpTitle member contains the path of the shortcut file (.lnk) that the user invoked to start this process.
        /// This is typically set by the shell when a .lnk file pointing to the launched application is invoked.
        /// Most applications will not need to set this value.
        /// </para>
        /// <para>
        /// This flag cannot be used with <see cref="STARTF_TITLEISAPPID"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_UNTRUSTEDSOURCE"/>
        /// </para>
        /// <para>
        /// 0x00008000
        /// </para>
        /// </term>
        /// <term>
        /// The command line came from an untrusted source.
        /// For more information, see Remarks.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USECOUNTCHARS"/>
        /// </para>
        /// <para>
        /// 0x00000008
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="dwXCountChars"/> and <see cref="dwYCountChars"/> members contain additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USEFILLATTRIBUTE"/>
        /// </para>
        /// <para>
        /// 0x00000010
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="dwFillAttribute"/> member contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USEHOTKEY"/>
        /// </para>
        /// <para>
        /// 0x00000200
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="hStdInput"/> member contains additional information.
        /// </para>
        /// <para>
        /// This flag cannot be used with <see cref="STARTF_USESTDHANDLES"/>.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USEPOSITION"/>
        /// </para>
        /// <para>
        /// 0x00000004
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="dwX"/> and <see cref="dwY"/> members contain additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USESHOWWINDOW"/>
        /// </para>
        /// <para>
        /// 0x00000001
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="wShowWindow"/> member contains additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USESIZE"/>
        /// </para>
        /// <para>
        /// 0x00000002
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="dwXSize"/> and <see cref="dwYSize"/> members contain additional information.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="STARTF_USESTDHANDLES"/>
        /// </para>
        /// <para>
        /// 0x00000100
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The <see cref="hStdInput"/>, <see cref="hStdOutput"/>, and <see cref="hStdError"/> members contain additional information.
        /// </para>
        /// <para>
        /// If this flag is specified when calling one of the process creation functions,
        /// the handles must be inheritable and the function's bInheritHandles parameter must be set to <see cref="TRUE"/>.
        /// For more information, see Handle Inheritance.
        /// </para>
        /// <para>
        /// If this flag is specified when calling the <see cref="GetStartupInfo"/> function,
        /// these members are either the handle value specified during process creation or <see cref="INVALID_HANDLE_VALUE"/>.
        /// </para>
        /// <para>
        /// Handles must be closed with <see cref="CloseHandle"/> when they are no longer needed.
        /// </para>
        /// <para>
        /// This flag cannot be used with <see cref="STARTF_USEHOTKEY"/>.
        /// </para>
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public STARTUPINFOFlags dwFlags;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USESHOWWINDOW"/>,
        /// this member can be any of the values that can be specified in the nCmdShow parameter for the <see cref="ShowWindow"/> function,
        /// except for <see cref="SW_SHOWDEFAULT"/>.
        /// Otherwise, this member is ignored.
        /// </para>
        /// <para>
        /// For GUI processes, the first time <see cref="ShowWindow"/> is called,
        /// its nCmdShow parameter is ignored <see cref="wShowWindow"/> specifies the default value.
        /// In subsequent calls to <see cref="ShowWindow"/>, the <see cref="wShowWindow"/> member is used
        /// if the nCmdShow parameter of <see cref="ShowWindow"/> is set to <see cref="SW_SHOWDEFAULT"/>.
        /// </para>
        /// </summary>
        public WORD wShowWindow;

        /// <summary>
        /// Reserved for use by the C Run-time; must be zero.
        /// </summary>
        public WORD cbReserved2;

        /// <summary>
        /// Reserved for use by the C Run-time; must be <see cref="NULL"/>.
        /// </summary>
        public IntPtr lpReserved2;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USESTDHANDLES"/>,
        /// this member is the standard input handle for the process.
        /// If <see cref="STARTF_USESTDHANDLES"/> is not specified, the default for standard input is the keyboard buffer.
        /// </para>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USEHOTKEY"/>,
        /// this member specifies a hotkey value that is sent as the wParam parameter of a <see cref="WM_SETHOTKEY"/> message
        /// to the first eligible top-level window created by the application that owns the process.
        /// If the window is created with the <see cref="WS_POPUP"/> window style,
        /// it is not eligible unless the <see cref="WS_EX_APPWINDOW"/> extended window style is also set.
        /// For more information, see <see cref="CreateWindowEx"/>.
        /// </para>
        /// <para>
        /// Otherwise, this member is ignored.
        /// </para>
        /// </summary>
        public HANDLE hStdInput;

        /// <summary>
        /// <para>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USESTDHANDLES"/>,
        /// this member is the standard output handle for the process.
        /// Otherwise, this member is ignored and the default for standard output is the console window's buffer.
        /// </para>
        /// <para>
        /// If a process is launched from the taskbar or jump list,
        /// the system sets <see cref="hStdOutput"/> to a handle to the monitor
        /// that contains the taskbar or jump list used to launch the process.
        /// For more information, see Remarks.
        /// </para>
        /// <para>
        /// Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008, Windows XP and Windows Server 2003:
        /// This behavior was introduced in Windows 8 and Windows Server 2012.
        /// </para>
        /// </summary>
        public HANDLE hStdOutput;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTF_USESTDHANDLES"/>,
        /// this member is the standard error handle for the process.
        /// Otherwise, this member is ignored and the default for standard error is the console window's buffer.
        /// </summary>
        public HANDLE hStdError;
    }
}
