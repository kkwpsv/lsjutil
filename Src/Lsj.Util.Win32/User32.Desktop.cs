using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DesktopAccessRights;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.UserObjectInformationIndexes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Closes an open handle to a desktop object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closedesktop"/>
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be closed.
        /// This can be a handle returned by the <see cref="CreateDesktop"/>, <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> functions.
        /// Do not specify the handle returned by the <see cref="GetThreadDesktop"/> function.
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
        /// The <see cref="CloseDesktop"/> function will fail if any thread in the calling process is using the specified desktop handle or
        /// if the handle refers to the initial desktop of the calling process.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseDesktop([In] HDESK hDesktop);

        /// <summary>
        /// <para>
        /// Closes an open window station handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-closewindowstation"/>
        /// </para>
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station to be closed.
        /// This handle is returned by the <see cref="CreateWindowStation"/> or <see cref="OpenWindowStation"/> function.
        /// Do not specify the handle returned by the <see cref="GetProcessWindowStation"/> function.
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
        /// Windows Server 2003 and Windows XP/2000:
        /// This function does not set the last error code on failure.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="CloseWindowStation"/> function will fail if the handle being closed is for the window station assigned to the calling process.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseWindowStation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CloseWindowStation([In] HWINSTA hWinSta);

        /// <summary>
        /// <para>
        /// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time
        /// or set by the <see cref="SetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// To specify the size of the heap for the desktop, use the <see cref="CreateDesktopEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdesktopw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be created.
        /// Desktop names are case-insensitive and may not contain backslash characters ().
        /// </param>
        /// <param name="lpszDevice">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDevmode">
        /// Reserved; must be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be zero or the following value.
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
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Enables processes running in other accounts on the desktop to set hooks in this process.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access to the desktop.
        /// For a list of values, see Desktop Security and Access Rights.
        /// </para>
        /// <para>
        /// This parameter must include the <see cref="DESKTOP_CREATEWINDOW"/> access right,
        /// because internally <see cref="CreateDesktop"/> uses the handle to create a window.
        /// </para>
        /// </param>
        /// <param name="lpsa">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpsa"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop.
        /// If this parameter is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the desktop inherits its security descriptor from the parent window station.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </para>
        /// <para>
        /// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB.
        /// Desktop objects use the heap to store resources.
        /// You can increase the number of desktops that can be created by reducing the default heap reserved for each desktop in the interactive window station.
        /// This value is specified in the "SharedSection" substring of the following registry value:
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows</c>.
        /// The default data for this registry value is as follows:
        /// </para>
        /// <para>
        /// "%SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows
        /// ServerDll=basesrv,1 ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2 ProfileControl=Off MaxRequestThreads=16"
        /// </para>
        /// <para>
        /// The values for the "SharedSection" substring are described as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The first "SharedSection" value is the size of the shared heap common to all desktops, in kilobytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The second "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in the interactive window station, WinSta0, in kilobytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The third "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in a noninteractive window station, in kilobytes.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopW", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK CreateDesktop([In] LPCWSTR lpszDesktop, [In] LPCWSTR lpszDevice, [In] in DEVMODE pDevmode,
            [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In] in SECURITY_ATTRIBUTES lpsa);

        /// <summary>
        /// <para>
        /// Creates a new desktop with the specified heap, associates it with the current window station of the calling process,
        /// and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time
        /// or set by the <see cref="SetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createdesktopexw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be created.
        /// Desktop names are case-insensitive and may not contain backslash characters ().
        /// </param>
        /// <param name="lpszDevice">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="pDevmode">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be zero or the following value.
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
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Enables processes running in other accounts on the desktop to set hooks in this process.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// <para>
        /// The access to the desktop.
        /// For a list of values, see Desktop Security and Access Rights.
        /// </para>
        /// <para>
        /// This parameter must include the <see cref="DESKTOP_CREATEWINDOW"/> access right,
        /// because internally <see cref="CreateDesktop"/> uses the handle to create a window.
        /// </para>
        /// </param>
        /// <param name="lpsa">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpsa"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop.
        /// If this parameter is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the desktop inherits its security descriptor from the parent window station.
        /// </para>
        /// </param>
        /// <param name="ulHeapSize">
        /// The size of the desktop heap, in kilobytes.
        /// </param>
        /// <param name="pvoid">
        /// This parameter is reserved and must be <see cref="NULL"/>.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </para>
        /// <para>
        /// The number of desktops that can be created is limited by the size of the system desktop heap.
        /// Desktop objects use the heap to store resources.
        /// You can increase the number of desktops that can be created by increasing the size of the desktop heap
        /// or by reducing the default heap reserved for each desktop in the interactive window station.
        /// This value is specified in the SharedSection substring of the following registry value:
        /// <c>HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows</c>.
        /// The default data for this registry value is as follows:
        /// </para>
        /// <para>
        /// %SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows
        /// ServerDll=basesrv,1 ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2 ProfileControl=Off MaxRequestThreads=16
        /// </para>
        /// <para>
        /// The values for the SharedSection substring are described as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The first SharedSection value is the size of the shared heap common to all desktops, in kilobytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The second SharedSection value is the size of the desktop heap needed for each desktop
        /// that is created in the interactive window station, WinSta0, in kilobytes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The third SharedSection value is the size of the desktop heap needed for each desktop
        /// that is created in a noninteractive window station, in kilobytes.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// The default size of the desktop heap depends on factors such as hardware architecture.
        /// To retrieve the size of the desktop heap, call the <see cref="GetUserObjectInformation"/> function with <see cref="UOI_HEAPSIZE"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsVista)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopExW", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK CreateDesktopEx([In] LPCWSTR lpszDesktop, [In] LPCWSTR lpszDevice, [In] in DEVMODE pDevmode,
            [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In] in SECURITY_ATTRIBUTES lpsa, [In] ULONG ulHeapSize, [In] PVOID pvoid);

        /// <summary>
        /// <para>
        /// Creates a window station object, associates it with the calling process, and assigns it to the current session.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createwindowstationw"/>
        /// </para>
        /// </summary>
        /// <param name="lpwinsta">
        /// The name of the window station to be created.
        /// Window station names are case-insensitive and cannot contain backslash characters (\).
        /// Only members of the Administrators group are allowed to specify a name.
        /// If <paramref name="lpwinsta"/> is <see cref="NULL"/> or an empty string,
        /// the system forms a window station name using the logon session identifier for the calling process.
        /// To get this name, call the <see cref="GetUserObjectInformation"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// If this parameter is <see cref="CWF_CREATE_ONLY"/> and the window station already exists, the call fails.
        /// If this flag is not specified and the window station already exists,
        /// the function succeeds and returns a new handle to the existing window station.
        /// </para>
        /// <para>
        /// Windows XP/2000:  This parameter is reserved and must be zero.
        /// </para>
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The type of access the returned handle has to the window station.
        /// In addition, you can specify any of the standard access rights, such as <see cref="READ_CONTROL"/> or <see cref="WRITE_DAC"/>,
        /// and a combination of the window station-specific access rights.
        /// For more information, see Window Station Security and Access Rights.
        /// </param>
        /// <param name="lpsa">
        /// <para>
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpsa"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the handle cannot be inherited.
        /// </para>
        /// <para>
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new window station.
        /// If <paramref name="lpsa"/> is <see cref="NullRef{SECURITY_ATTRIBUTES}"/>, the window station (and any desktops created within the window)
        /// gets a security descriptor that grants <see cref="GENERIC_ALL"/> access to all users.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the newly created window station.
        /// If the specified window station already exists, the function succeeds and returns a handle to the existing window station.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowStationW", ExactSpelling = true, SetLastError = true)]
        public static extern HWINSTA CreateWindowStation([In] LPCWSTR lpwinsta, [In] DWORD dwFlags, [In] ACCESS_MASK dwDesiredAccess, [In] in SECURITY_ATTRIBUTES lpsa);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows associated with the specified desktop.
        /// It passes the handle to each window, in turn, to an application-defined callback function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-enumdesktopwindows"/>
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// <para>
        /// A handle to the desktop whose top-level windows are to be enumerated.
        /// This handle is returned by the <see cref="CreateDesktop"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>,
        /// or <see cref="OpenInputDesktop"/> function, and must have the <see cref="DESKTOP_READOBJECTS"/> access right.
        /// For more information, see Desktop Security and Access Rights.
        /// </para>
        /// <para>
        /// If this parameter is NULL, the current desktop is used.
        /// </para>
        /// </param>
        /// <param name="lpfn">
        /// A pointer to an application-defined <see cref="WNDENUMPROC"/> callback function.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function fails or is unable to perform the enumeration, the return value is zero.
        /// </para>
        /// <para>
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// You must ensure that the callback function sets <see cref="SetLastError"/> if it fails.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// If there are no windows on the desktop, <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumDesktopWindows"/> function repeatedly invokes the <paramref name="lpfn"/> callback function
        /// until the last top-level window is enumerated or the callback function returns <see cref="FALSE"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDesktopWindows", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnumDesktopWindows([In] HDESK hDesktop, [In] WNDENUMPROC lpfn, [In] LPARAM lParam);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the desktop window.
        /// The desktop window covers the entire screen.
        /// The desktop window is the area on top of which other windows are painted.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdesktopwindow"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a handle to the desktop window.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDesktopWindow", ExactSpelling = true)]
        public static extern HWND GetDesktopWindow();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the current window station for the calling process.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getprocesswindowstation"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the window station.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system associates a window station with a process when the process is created.
        /// A process can use the <see cref="SetProcessWindowStation"/> function to change its window station.
        /// </para>
        /// <para>
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation"/>,
        /// <see cref="GetUserObjectSecurity"/>, <see cref="SetUserObjectInformation"/>, and <see cref="SetUserObjectSecurity"/> functions.
        /// </para>
        /// <para>
        /// Do not close the handle returned by this function.
        /// </para>
        /// <para>
        /// A service application is created with an associated window station and desktop,
        /// so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessWindowStation", ExactSpelling = true, SetLastError = true)]
        public static extern HWINSTA GetProcessWindowStation();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getthreaddesktop"/>
        /// </para>
        /// </summary>
        /// <param name="dwThreadId">
        /// The thread identifier.
        /// The <see cref="GetCurrentThreadId"/> and <see cref="CreateProcess"/> functions return thread identifiers.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the desktop associated with the specified thread.
        /// You do not need to call the <see cref="CloseDesktop"/> function to close the returned handle.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The system associates a desktop with a thread when that thread is created.
        /// A thread can use the <see cref="SetThreadDesktop"/> function to change its desktop.
        /// The desktop associated with a thread must be on the window station associated with the thread's process.
        /// </para>
        /// <para>
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation"/>,
        /// <see cref="GetUserObjectSecurity"/>, <see cref="SetUserObjectInformation"/>, and <see cref="SetUserObjectSecurity"/> functions.
        /// </para>
        /// <para>
        /// A service application is created with an associated window station and desktop,
        /// so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK GetThreadDesktop([In] DWORD dwThreadId);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified window station or desktop object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getuserobjectinformationw"/>
        /// </para>
        /// </summary>
        /// <param name="hObj">
        /// A handle to the window station or desktop object.
        /// This handle is returned by the <see cref="CreateWindowStation"/>, <see cref="OpenWindowStation"/>,
        /// <see cref="CreateDesktop"/>, or <see cref="OpenDesktop"/> function.
        /// </param>
        /// <param name="nIndex">
        /// <para>
        /// The information to be retrieved.
        /// The parameter can be one of the following values.
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
        /// <see cref="UOI_FLAGS"/>
        /// </para>
        /// <para>
        /// 1
        /// </para>
        /// </term>
        /// <term>
        /// The handle flags.
        /// The <paramref name="pvInfo"/> parameter must point to a <see cref="USEROBJECTFLAGS"/> structure.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UOI_HEAPSIZE"/>
        /// </para>
        /// <para>
        /// 5
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// The size of the desktop heap, in KB, as a <see cref="ULONG"/> value.
        /// The <paramref name="hObj"/> parameter must be a handle to a desktop object, otherwise, the function fails.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UOI_IO"/>
        /// </para>
        /// <para>
        /// 6
        /// </para>
        /// </term>
        /// <term>
        /// <para>
        /// <see cref="TRUE"/> if the <paramref name="hObj"/> parameter is a handle to the desktop object that is receiving input from the user.
        /// <see cref="FALSE"/> otherwise.
        /// </para>
        /// <para>
        /// Windows Server 2003 and Windows XP/2000:
        /// This value is not supported.
        /// </para>
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UOI_NAME"/>
        /// </para>
        /// <para>
        /// 2
        /// </para>
        /// </term>
        /// <term>
        /// The name of the object, as a string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UOI_TYPE"/>
        /// </para>
        /// <para>
        /// 3
        /// </para>
        /// </term>
        /// <term>
        /// The type name of the object, as a string.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="UOI_USER_SID"/>
        /// </para>
        /// <para>
        /// 4
        /// </para>
        /// </term>
        /// <term>
        /// The <see cref="SID"/> structure that identifies the user that is currently associated with the specified object.
        /// If no user is associated with the object, the value returned in the buffer pointed to by <paramref name="lpnLengthNeeded"/> is zero.
        /// Note that <see cref="SID"/> is a variable length structure.
        /// You will usually make a call to <see cref="GetUserObjectInformation"/> to determine the length of the <see cref="SID"/> before retrieving its value.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="pvInfo">
        /// A pointer to a buffer to receive the object information.
        /// </param>
        /// <param name="nLength">
        /// The size of the buffer pointed to by the <paramref name="pvInfo"/> parameter, in bytes.
        /// </param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to a variable receiving the number of bytes required to store the requested information.
        /// If this variable's value is greater than the value of the <paramref name="nLength"/> parameter when the function returns,
        /// the function returns <see cref="FALSE"/>, and none of the information is copied to the <paramref name="pvInfo"/> buffer.
        /// If the value of the variable pointed to by <paramref name="lpnLengthNeeded"/> is less than or equal to the value of <paramref name="nLength"/>,
        /// the entire information block is copied.
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserObjectInformationW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetUserObjectInformation([In] IntPtr hObj, [In] UserObjectInformationIndexes nIndex, [In] PVOID pvInfo,
            [In] DWORD nLength, [Out] out DWORD lpnLengthNeeded);

        /// <summary>
        /// <para>
        /// Opens the specified desktop object.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-opendesktopw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// <para>
        /// The name of the desktop to be opened.
        /// Desktop names are case-insensitive.
        /// </para>
        /// <para>
        /// This desktop must belong to the current window station.
        /// </para>
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be zero or the following value.
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
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="fInherit">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the desktop.
        /// For a list of access rights, see Desktop Security and Access Rights.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the opened desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The calling process must have an associated window station,
        /// either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenDesktopW", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK OpenDesktop([In] LPCWSTR lpszDesktop, [In] DWORD dwFlags, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens the desktop that receives user input.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openinputdesktop"/>
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// <para>
        /// This parameter can be zero or the following value.
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
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>
        /// </para>
        /// <para>
        /// 0x0001
        /// </para>
        /// </term>
        /// <term>
        /// Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="fInherit">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the desktop. For a list of access rights, see Desktop Security and Access Rights.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is a handle to the desktop that receives user input.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The calling process must have an associated window station,
        /// either assigned by the system when the process is created, or set by the <see cref="SetProcessWindowStation"/> function.
        /// The window station associated with the calling process must be capable of receiving input.
        /// </para>
        /// <para>
        /// If the calling process is running in a disconnected session,
        /// the function returns a handle to the desktop that becomes active when the user restores the connection.
        /// </para>
        /// <para>
        /// An application can use the <see cref="SwitchDesktop"/> function to change the input desktop.
        /// </para>
        /// <para>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenInputDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK OpenInputDesktop([In] DWORD dwFlags, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens the specified window station.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-openwindowstationw"/>
        /// </para>
        /// </summary>
        /// <param name="lpszWinSta">
        /// <para>
        /// The name of the window station to be opened.
        /// Window station names are case-insensitive.
        /// </para>
        /// <para>
        /// This window station must belong to the current session.
        /// </para>
        /// </param>
        /// <param name="fInherit">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the window station.
        /// For a list of access rights, see Window Station Security and Access Rights.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the handle to the specified window station.
        /// </para>
        /// <para>
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenWindowStationW", ExactSpelling = true, SetLastError = true)]
        public static extern HWINSTA OpenWindowStation([In] LPCWSTR lpszWinSta, [In] BOOL fInherit, [In] ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Assigns the specified window station to the calling process.
        /// This enables the process to access objects in the window station such as desktops, the clipboard, and global atoms.
        /// All subsequent operations on the window station use the access rights granted to <paramref name="hWinSta"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setprocesswindowstation"/>
        /// </para>
        /// </summary>
        /// <param name="hWinSta">
        /// <para>
        /// A handle to the window station.
        /// This can be a handle returned by the <see cref="CreateWindowStation"/>,
        /// <see cref="OpenWindowStation"/>, or <see cref="GetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// This window station must be associated with the current session.
        /// </para>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessWindowStation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessWindowStation([In] HWINSTA hWinSta);

        /// <summary>
        /// <para>
        /// Assigns the specified desktop to the calling thread.
        /// All subsequent operations on the desktop use the access rights granted to the desktop.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setthreaddesktop"/>
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// <para>
        /// A handle to the desktop to be assigned to the calling thread.
        /// This handle is returned by the <see cref="CreateDesktop"/>, <see cref="GetThreadDesktop"/>,
        /// <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function.
        /// </para>
        /// <para>
        /// This desktop must be associated with the current window station for the process.
        /// </para>
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
        /// The <see cref="SetThreadDesktop"/> function will fail if the calling thread has any windows or hooks on its current desktop
        /// (unless the <paramref name="hDesktop"/> parameter is a handle to the current desktop).
        /// </para>
        /// <para>
        /// Warning
        /// </para>
        /// <para>
        /// There is a significant security risk for any service that opens a window on the interactive desktop.
        /// By opening a desktop window, a service makes itself vulnerable to attack from the logged-on user,
        /// whose application could send malicious messages to the service's desktop window and affect its ability to function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadDesktop([In] HDESK hDesktop);

        /// <summary>
        /// <para>
        /// Makes the specified desktop visible and activates it.
        /// This enables the desktop to receive input from the user.
        /// The calling process must have <see cref="DESKTOP_SWITCHDESKTOP"/> access to the desktop for the <see cref="SwitchDesktop"/> function to succeed.
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// <para>
        /// A handle to the desktop.
        /// This handle is returned by the <see cref="CreateDesktop"/> and <see cref="OpenDesktop"/> functions.
        /// </para>
        /// <para>
        /// This desktop must be associated with the current window station for the process.
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is nonzero.
        /// </para>
        /// <para>
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// However, <see cref="SwitchDesktop"/> only sets the last error for the following cases:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// When the desktop belongs to an invisible window station
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// When <paramref name="hDesktop"/> is an invalid handle, refers to a destroyed desktop, or belongs to a different session than that of the calling process
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </returns>
        /// <remarks>
        /// The SwitchDesktop function fails if the desktop belongs to an invisible window station.
        /// <see cref="SwitchDesktop"/> also fails when called from a process that is associated with a secured desktop
        /// such as the WinLogon and ScreenSaver desktops.
        /// Processes that are associated with a secured desktop include custom UserInit processes.
        /// Such calls typically fail with an "access denied" error.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwitchDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SwitchDesktop([In] HDESK hDesktop);
    }
}
