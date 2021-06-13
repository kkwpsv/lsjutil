using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the window station, desktop, standard handles, and appearance of the main window for a process at creation time.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/ns-processthreadsapi-startupinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// For graphical user interface (GUI) processes, this information affects the first window
    /// created by the <see cref="CreateWindow"/> function and shown by the ShowWindow function.
    /// For console processes, this information affects the console window if a new console is created for the process.
    /// A process can use the <see cref="GetStartupInfo"/> function to retrieve the <see cref="STARTUPINFO"/> structure specified
    /// when the process was created.
    /// If a GUI process is being started and neither <see cref="STARTUPINFOFlags.STARTF_FORCEONFEEDBACK"/> or
    /// <see cref="STARTUPINFOFlags.STARTF_FORCEOFFFEEDBACK"/> is specified, the process feedback cursor is used.
    /// A GUI process is one whose subsystem is specified as "windows."
    /// If a process is launched from the taskbar or jump list, the system sets <see cref="GetStartupInfo"/> to retrieve
    /// the <see cref="STARTUPINFO"/> structure and check that <see cref="hStdOutput"/> is set.
    /// If so, use <see cref="GetMonitorInfo"/> to check whether <see cref="hStdOutput"/> is a valid monitor handle (HMONITOR).
    /// The process can then use the handle to position its windows.
    /// If the <see cref="GetStartupInfo"/> function, then applications should be aware that the command line is untrusted.
    /// If this flag is set, applications should disable potentially dangerous features such as macros,
    /// downloaded content, and automatic printing.
    /// This flag is optional.
    /// Applications that call <see cref="CreateProcess"/> are encouraged to set this flag when launching a program
    /// with a untrusted command line so that the created process can apply appropriate policy.
    /// The <see cref="STARTUPINFOFlags.STARTF_UNTRUSTEDSOURCE"/> flag is supported starting in Windows Vista,
    /// but it is not defined in the SDK header files prior to the Windows 10 SDK.
    /// To use the flag in versions prior to Windows 10, you can define it manually in your program.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STARTUPINFO
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </summary>
        public IntPtr lpReserved;

        /// <summary>
        /// The name of the desktop, or the name of both the desktop and window station for this process.
        /// A backslash in the string indicates that the string includes both the desktop and window station names.
        /// For more information, see Thread Connection to a Desktop.
        /// </summary>
        public IntPtr lpDesktop;

        /// <summary>
        /// The <see cref="string"/> value of <see cref="lpDesktop"/>,
        /// which cannot be declared as <see cref="string"/> ,or lead to heap memory corruption.
        /// </summary>
        public string lpDesktopString => Marshal.PtrToStringUni(lpDesktop);

        /// <summary>
        /// For console processes, this is the title displayed in the title bar if a new console window is created.
        /// If <see langword="null"/>, the name of the executable file is used as the window title instead.
        /// This parameter must be <see langword="null"/> for GUI or console processes that do not create a new console window.
        /// </summary>
        public IntPtr lpTitle;

        /// <summary>
        /// The <see cref="string"/> value of <see cref="lpTitleString"/>,
        /// which cannot be declared as <see cref="string"/> ,or lead to heap memory corruption.
        /// </summary>
        public string lpTitleString => Marshal.PtrToStringUni(lpTitle);

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USEPOSITION"/>,
        /// this member is the x offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// The offset is from the upper left corner of the screen.For GUI processes,
        /// the specified position is used the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the x parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </summary>
        public DWORD dwX;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USEPOSITION"/>,
        /// this member is the y offset of the upper left corner of a window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// The offset is from the upper left corner of the screen.
        /// For GUI processes, the specified position is used the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the y parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </summary>
        public DWORD dwY;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USESIZE"/>,
        /// this member is the width of the window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// For GUI processes, this is used only the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the nWidth parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </summary>
        public DWORD dwXSize;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USESIZE"/>,
        /// this member is the height of the window if a new window is created, in pixels. Otherwise, this member is ignored.
        /// For GUI processes, this is used only the first time the new process calls <see cref="CreateWindow"/> to create an overlapped window
        /// if the nHeight parameter of <see cref="CreateWindow"/> is <see cref="CW_USEDEFAULT"/>.
        /// </summary>
        public DWORD dwYSize;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USECOUNTCHARS"/>,
        /// if a new console window is created in a console process,
        /// this member specifies the screen buffer width, in character columns. Otherwise, this member is ignored.
        /// </summary>
        public DWORD dwXCountChars;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USECOUNTCHARS"/>,
        /// if a new console window is created in a console process,
        /// this member specifies the screen buffer height, in character rows. Otherwise, this member is ignored.
        /// </summary>
        public DWORD dwYCountChars;

        /// <summary>
        /// If <see cref="dwFlags"/> specifies <see cref="STARTUPINFOFlags.STARTF_USEFILLATTRIBUTE"/>,
        /// this member is the initial text and background colors if a new console window is created in a console application.
        /// Otherwise, this member is ignored.
        /// This value can be any combination of the following values: <see cref="ConsoleCharacterAttributes.FOREGROUND_BLUE"/>,
        /// <see cref="ConsoleCharacterAttributes.FOREGROUND_GREEN"/>, <see cref="ConsoleCharacterAttributes.FOREGROUND_RED"/>,
        /// <see cref="ConsoleCharacterAttributes.FOREGROUND_INTENSITY"/>, <see cref="ConsoleCharacterAttributes.BACKGROUND_BLUE"/>,
        /// <see cref="ConsoleCharacterAttributes.BACKGROUND_GREEN"/>, <see cref="ConsoleCharacterAttributes.BACKGROUND_RED"/>,
        /// and <see cref="ConsoleCharacterAttributes.BACKGROUND_INTENSITY"/>.
        /// For example, the following combination of values produces red text on a white background:
        /// <code>FOREGROUND_RED| BACKGROUND_RED| BACKGROUND_GREEN| BACKGROUND_BLUE</code>
        /// </summary>
        public DWORD dwFillAttribute;

        /// <summary>
        /// A bitfield that determines whether certain <see cref="STARTUPINFO"/> members are used when the process creates a window.
        /// </summary>
        public STARTUPINFOFlags dwFlags;

        /// <summary>
        /// If dwFlags specifies <see cref="STARTUPINFOFlags.STARTF_USESHOWWINDOW"/>,
        /// this member can be any of the values that can be specified in the nCmdShow parameter for the <see cref="ShowWindow"/> function,
        /// except for <see cref="ShowWindowCommands.SW_SHOWDEFAULT"/>. Otherwise, this member is ignored.
        /// For GUI processes, the first time <see cref="ShowWindow"/> is called,
        /// its nCmdShow parameter is ignored wShowWindow specifies the default value.
        /// In subsequent calls to <see cref="ShowWindow"/>, the <see cref="wShowWindow"/> member is used
        /// if the nCmdShow parameter of <see cref="ShowWindow"/> is set to <see cref="ShowWindowCommands.SW_SHOWDEFAULT"/>.
        /// </summary>
        public WORD wShowWindow;

        /// <summary>
        /// Reserved for use by the C Run-time; must be zero.
        /// </summary>
        public WORD cbReserved2;

        /// <summary>
        /// Reserved for use by the C Run-time; must be <see cref="IntPtr.Zero"/>.
        /// </summary>
        public IntPtr lpReserved2;

        /// <summary>
        /// If dwFlags specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>,
        /// this member is the standard input handle for the process.
        /// If <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/> is not specified, the default for standard input is the keyboard buffer.
        /// If dwFlags specifies <see cref="STARTUPINFOFlags.STARTF_USEHOTKEY"/>,
        /// this member specifies a hotkey value that is sent as the wParam parameter of a <see cref="WindowsMessages.WM_SETHOTKEY"/> message
        /// to the first eligible top-level window created by the application that owns the process.
        /// If the window is created with the <see cref="WindowStyles.WS_POPUP"/> window style,
        /// it is not eligible unless the <see cref="WindowStylesEx.WS_EX_APPWINDOW"/> extended window style is also set.
        /// For more information, see CreateWindowEx.
        /// Otherwise, this member is ignored.
        /// </summary>
        public HANDLE hStdInput;

        /// <summary>
        /// If dwFlags specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, this member is the standard output handle for the process.
        /// Otherwise, this member is ignored and the default for standard output is the console window's buffer.
        /// If a process is launched from the taskbar or jump list,
        /// the system sets <see cref="hStdOutput"/> to a handle to the monitor that contains the taskbar or jump list used to launch the process.
        /// For more information, see Remarks. This behavior was introduced in Windows 8 and Windows Server 2012.
        /// </summary>
        public HANDLE hStdOutput;

        /// <summary>
        /// If dwFlags specifies <see cref="STARTUPINFOFlags.STARTF_USESTDHANDLES"/>, this member is the standard error handle for the process.
        /// Otherwise, this member is ignored and the default for standard error is the console window's buffer.
        /// </summary>
        public HANDLE hStdError;
    }
}
