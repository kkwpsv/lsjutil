using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.DesktopAccessRights;
using static Lsj.Util.Win32.Enums.GenericAccessRights;
using static Lsj.Util.Win32.Enums.GetUserObjectInformationIndexes;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// CWF_CREATE_ONLY
        /// </summary>
        public const uint CWF_CREATE_ONLY = 0x00000001;

        /// <summary>
        /// DF_ALLOWOTHERACCOUNTHOOK
        /// </summary>
        public const uint DF_ALLOWOTHERACCOUNTHOOK = 0x0001;

        /// <summary>
        /// <para>
        /// Closes an open handle to a desktop object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-closedesktop
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be closed. This can be a handle returned by the <see cref="CreateDesktop"/>, <see cref="OpenDesktop"/>,
        /// or <see cref="OpenInputDesktop"/> functions. Do not specify the handle returned by the <see cref="GetThreadDesktop"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="CloseDesktop"/> function will fail if any thread in the calling process is using the specified desktop handle or
        /// if the handle refers to the initial desktop of the calling process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseDesktop", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseDesktop([In]IntPtr hDesktop);

        /// <summary>
        /// <para>
        /// Creates a new desktop, associates it with the current window station of the calling process, and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time
        /// or set by the <see cref="SetProcessWindowStation"/> function.
        /// To specify the size of the heap for the desktop, use the <see cref="CreateDesktopEx"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createdesktopw
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be created.
        /// Desktop names are case-insensitive and may not contain backslash characters ().
        /// </param>
        /// <param name="lpszDevice">
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pDevmode">
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>: Enables processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the desktop. For a list of values, see Desktop Security and Access Rights.
        /// This parameter must include the <see cref="DESKTOP_CREATEWINDOW"/> access right,
        /// because internally <see cref="CreateDesktop"/> uses the handle to create a window.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpsa"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the desktop inherits its security descriptor from the parent window station.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>,
        /// or <see cref="WRITE_OWNER"/> standard access rights, you must also request the <see cref="DESKTOP_READOBJECTS"/>
        /// and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB.
        /// Desktop objects use the heap to store resources.
        /// You can increase the number of desktops that can be created by reducing the default heap reserved for each desktop 
        /// in the interactive window station.
        /// This value is specified in the "SharedSection" substring of the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows.
        /// The default data for this registry value is as follows:
        /// "%SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows ServerDll=basesrv,1 
        /// ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2 ProfileControl=Off MaxRequestThreads=16"
        /// The values for the "SharedSection" substring are described as follows:
        /// The first "SharedSection" value is the size of the shared heap common to all desktops, in kilobytes.
        /// The second "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in the interactive window station, WinSta0, in kilobytes.
        /// The third "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in a noninteractive window station, in kilobytes.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateDesktop([MarshalAs(UnmanagedType.LPWStr)][In]string lpszDesktop, [In]IntPtr lpszDevice, [In]IntPtr pDevmode,
            [In]uint dwFlags, [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpsa);

        /// <summary>
        /// <para>
        /// Creates a new desktop with the specified heap, associates it with the current window station of the calling process,
        /// and assigns it to the calling thread.
        /// The calling process must have an associated window station, either assigned by the system at process creation time
        /// or set by the <see cref="SetProcessWindowStation"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createdesktopexw
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be created.
        /// Desktop names are case-insensitive and may not contain backslash characters ().
        /// </param>
        /// <param name="lpszDevice">
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="pDevmode">
        /// Reserved; must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>: Enables processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the desktop. For a list of values, see Desktop Security and Access Rights.
        /// This parameter must include the <see cref="DESKTOP_CREATEWINDOW"/> access right,
        /// because internally <see cref="CreateDesktop"/> uses the handle to create a window.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If <paramref name="lpsa"/> is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new desktop.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the desktop inherits its security descriptor from the parent window station.
        /// </param>
        /// <param name="ulHeapSize">
        /// The size of the desktop heap, in kilobytes.
        /// </param>
        /// <param name="pvoid">
        /// This parameter is reserved and must be <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created desktop.
        /// If the specified desktop already exists, the function succeeds and returns a handle to the existing desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>, <see cref="WRITE_DAC"/>,
        /// or <see cref="WRITE_OWNER"/> standard access rights, you must also request the <see cref="DESKTOP_READOBJECTS"/>
        /// and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// The number of desktops that can be created is limited by the size of the system desktop heap, which is 48 MB.
        /// Desktop objects use the heap to store resources.
        /// You can increase the number of desktops that can be created by reducing the default heap reserved for each desktop 
        /// in the interactive window station.
        /// This value is specified in the "SharedSection" substring of the following registry value:
        /// HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Session Manager\SubSystems\Windows.
        /// The default data for this registry value is as follows:
        /// "%SystemRoot%\system32\csrss.exe ObjectDirectory=\Windows SharedSection=1024,3072,512 Windows=On SubSystemType=Windows ServerDll=basesrv,1 
        /// ServerDll=winsrv:UserServerDllInitialization,3 ServerDll=winsrv:ConServerDllInitialization,2 ProfileControl=Off MaxRequestThreads=16"
        /// The values for the "SharedSection" substring are described as follows:
        /// The first "SharedSection" value is the size of the shared heap common to all desktops, in kilobytes.
        /// The second "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in the interactive window station, WinSta0, in kilobytes.
        /// The third "SharedSection" value is the size of the desktop heap needed for each desktop
        /// that is created in a noninteractive window station, in kilobytes.
        /// The default size of the desktop heap depends on factors such as hardware architecture.
        /// To retrieve the size of the desktop heap, call the <see cref="GetUserObjectInformation"/> function with <see cref="UOI_HEAPSIZE"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopExW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateDesktopEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpszDesktop, [In]IntPtr lpszDevice, [In]IntPtr pDevmode,
            [In]uint dwFlags, [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpsa, [In]uint ulHeapSize, [In]IntPtr pvoid);

        /// <summary>
        /// <para>
        /// Creates a window station object, associates it with the calling process, and assigns it to the current session.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-createwindowstationw
        /// </para>
        /// </summary>
        /// <param name="lpwinsta">
        /// The name of the window station to be created.
        /// Window station names are case-insensitive and cannot contain backslash characters ().
        /// Only members of the Administrators group are allowed to specify a name.
        /// If lpwinsta is <see langword="null"/> or an empty string,
        /// the system forms a window station name using the logon session identifier for the calling process.
        /// To get this name, call the <see cref="GetUserObjectInformation"/> function.
        /// </param>
        /// <param name="dwFlags">
        /// If this parameter is <see cref="CWF_CREATE_ONLY"/> and the window station already exists, the call fails.
        /// If this flag is not specified and the window station already exists,
        /// the function succeeds and returns a new handle to the existing window station.
        /// Windows XP/2000:  This parameter is reserved and must be zero.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The type of access the returned handle has to the window station.
        /// In addition, you can specify any of the standard access rights, such as <see cref="READ_CONTROL"/> or <see cref="WRITE_DAC"/>,
        /// and a combination of the window station-specific access rights.
        /// For more information, see Window Station Security and Access Rights.
        /// </param>
        /// <param name="lpsa">
        /// A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that determines whether the returned handle can be inherited by child processes.
        /// If lpsa is <see langword="null"/>, the handle cannot be inherited.
        /// The <see cref="SECURITY_ATTRIBUTES.lpSecurityDescriptor"/> member of the structure specifies a security descriptor for the new window station.
        /// If lpsa is <see langword="null"/>, the window station (and any desktops created within the window) gets a security descriptor
        /// that grants <see cref="GENERIC_ALL"/> access to all users.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the newly created window station.
        /// If the specified window station already exists, the function succeeds and returns a handle to the existing window station.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateWindowStationW", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateWindowStation([MarshalAs(UnmanagedType.LPWStr)][In]string lpwinsta, [In]uint dwFlags,
            [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpsa);

        /// <summary>
        /// <para>
        /// Closes an open window station handle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-closewindowstation
        /// </para>
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station to be closed.
        /// This handle is returned by the <see cref="CreateWindowStation"/> or <see cref="OpenWindowStation"/> function.
        /// Do not specify the handle returned by the <see cref="GetProcessWindowStation"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// Windows Server 2003 and Windows XP/2000:  This function does not set the last error code on failure.
        /// </returns>
        /// <remarks>
        /// The <see cref="CloseWindowStation"/> function will fail if the handle being closed is for the window station assigned to the calling process.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseWindowStation", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseWindowStation([In]IntPtr hWinSta);

        /// <summary>
        /// <para>
        /// Enumerates all top-level windows associated with the specified desktop.
        /// It passes the handle to each window, in turn, to an application-defined callback function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-enumdesktopwindows
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop whose top-level windows are to be enumerated.
        /// This handle is returned by the <see cref="CreateDesktop"/>, <see cref="GetThreadDesktop"/>, <see cref="OpenDesktop"/>,
        /// or <see cref="OpenInputDesktop"/> function, and must have the <see cref="DESKTOP_READOBJECTS"/> access right.
        /// For more information, see Desktop Security and Access Rights.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the current desktop is used.
        /// </param>
        /// <param name="lpfn">
        /// A pointer to an application-defined <see cref="WNDENUMPROC"/> callback function.
        /// </param>
        /// <param name="lParam">
        /// An application-defined value to be passed to the callback function.
        /// </param>
        /// <returns>
        /// If the function fails or is unable to perform the enumeration, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// You must ensure that the callback function sets <see cref="SetLastError"/> if it fails.
        /// Windows Server 2003 and Windows XP/2000:
        /// If there are no windows on the desktop, <see cref="GetLastError"/> returns <see cref="ERROR_INVALID_HANDLE"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumDesktopWindows"/> function repeatedly invokes the <paramref name="lpfn"/> callback function
        /// until the last top-level window is enumerated or the callback function returns <see langword="false"/>.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDesktopWindows", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([In]IntPtr hDesktop, [In]WNDENUMPROC lpfn, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// Retrieves a handle to the desktop window.
        /// The desktop window covers the entire screen.
        /// The desktop window is the area on top of which other windows are painted.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getdesktopwindow
        /// </para>
        /// </summary>
        /// <returns>
        /// The return value is a handle to the desktop window.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDesktopWindow", ExactSpelling = true, SetLastError = true)]
        public static extern HWND GetDesktopWindow();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the current window station for the calling process.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getprocesswindowstation
        /// </para>
        /// </summary>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the window station.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system associates a window station with a process when the process is created.
        /// A process can use the <see cref="SetProcessWindowStation"/> function to change its window station.
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation"/>,
        /// <see cref="GetUserObjectSecurity"/>, <see cref="SetUserObjectInformation"/>, and <see cref="SetUserObjectSecurity"/> functions.
        /// Do not close the handle returned by this function.
        /// A service application is created with an associated window station and desktop,
        /// so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessWindowStation", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcessWindowStation();

        /// <summary>
        /// <para>
        /// Retrieves a handle to the desktop assigned to the specified thread.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getthreaddesktop
        /// </para>
        /// </summary>
        /// <param name="dwThreadId">
        /// The thread identifier.
        /// The <see cref="GetCurrentThreadId"/> and <see cref="CreateProcess"/> functions return thread identifiers.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the desktop associated with the specified thread.
        /// You do not need to call the <see cref="CloseDesktop"/> function to close the returned handle.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The system associates a desktop with a thread when that thread is created.
        /// A thread can use the <see cref="SetThreadDesktop"/> function to change its desktop.
        /// The desktop associated with a thread must be on the window station associated with the thread's process.
        /// The calling process can use the returned handle in calls to the <see cref="GetUserObjectInformation"/>, <see cref="GetUserObjectSecurity"/>,
        /// <see cref="SetUserObjectInformation"/>, and <see cref="SetUserObjectSecurity"/> functions.
        /// A service application is created with an associated window station and desktop,
        /// so there is no need to call a USER or GDI function to connect the service to a window station and desktop.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetThreadDesktop([In]uint dwThreadId);

        /// <summary>
        /// <para>
        /// Retrieves information about the specified window station or desktop object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-getuserobjectinformationw
        /// </para>
        /// </summary>
        /// <param name="hObj">
        /// A handle to the window station or desktop object.
        /// This handle is returned by the <see cref="CreateWindowStation"/>, <see cref="OpenWindowStation"/>,
        /// <see cref="CreateDesktop"/>, or <see cref="OpenDesktop"/> function.
        /// </param>
        /// <param name="nIndex">
        /// The information to be retrieved.
        /// </param>
        /// <param name="pvInfo">
        /// A pointer to a buffer to receive the object information.
        /// </param>
        /// <param name="nLength">
        /// The size of the buffer pointed to by the <paramref name="pvInfo"/> parameter, in bytes.
        /// </param>
        /// <param name="lpnLengthNeeded">
        /// A pointer to a variable receiving the number of bytes required to store the requested information.
        /// If this variable's value is greater than the value of the <paramref name="nLength"/> parameter when the function returns,
        /// the function returns <see langword="false"/>, and none of the information is copied to the pvInfo buffer.
        /// If the value of the variable pointed to by <paramref name="lpnLengthNeeded"/> is less than or equal to the value of <paramref name="nLength"/>,
        /// the entire information block is copied.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="false"/>.
        /// If the function fails, the return value is <see langword="true"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUserObjectInformationW", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetUserObjectInformation([In]IntPtr hObj, [In]GetUserObjectInformationIndexes nIndex, [In]IntPtr pvInfo,
            [In]uint nLength, [Out]out uint lpnLengthNeeded);

        /// <summary>
        /// <para>
        /// Opens the specified desktop object.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-opendesktopw
        /// </para>
        /// </summary>
        /// <param name="lpszDesktop">
        /// The name of the desktop to be opened. Desktop names are case-insensitive.
        /// This desktop must belong to the current window station.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>:
        /// Allows processes running in other accounts on the desktop to set hooks in this process.
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
        /// If the function succeeds, the return value is a handle to the opened desktop.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The calling process must have an associated window station,
        /// either assigned by the system at process creation time or set by the <see cref="SetProcessWindowStation"/> function.
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenDesktopW", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK OpenDesktop([MarshalAs(UnmanagedType.LPWStr)][In]string lpszDesktop, [In]DWORD dwFlags,
            [In]BOOL fInherit, [In]ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens the specified window station.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-openwindowstationw
        /// </para>
        /// </summary>
        /// <param name="lpszWinSta">
        /// The name of the window station to be opened.
        /// Window station names are case-insensitive.
        /// This window station must belong to the current session.
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
        /// If the function succeeds, the return value is the handle to the specified window station.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// After you are done with the handle, you must call <see cref="CloseWindowStation"/> to free the handle.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenWindowStationW", ExactSpelling = true, SetLastError = true)]
        public static extern HWINSTA OpenWindowStation([MarshalAs(UnmanagedType.LPWStr)][In]string lpszWinSta, [In]BOOL fInherit,
            [In]ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Opens the desktop that receives user input.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-openinputdesktop
        /// </para>
        /// </summary>
        /// <param name="dwFlags">
        /// This parameter can be zero or the following value.
        /// <see cref="DF_ALLOWOTHERACCOUNTHOOK"/>: Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </param>
        /// <param name="fInherit">
        /// If this value is <see cref="TRUE"/>, processes created by this process will inherit the handle.
        /// Otherwise, the processes do not inherit this handle.
        /// </param>
        /// <param name="dwDesiredAccess">
        /// The access to the desktop. For a list of access rights, see Desktop Security and Access Rights.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the desktop that receives user input.
        /// When you are finished using the handle, call the <see cref="CloseDesktop"/> function to close it.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The calling process must have an associated window station, either assigned by the system when the process is created,
        /// or set by the <see cref="SetProcessWindowStation"/> function.
        /// The window station associated with the calling process must be capable of receiving input.
        /// If the calling process is running in a disconnected session, the function returns a handle to the desktop
        /// that becomes active when the user restores the connection.
        /// An application can use the <see cref="SwitchDesktop"/> function to change the input desktop.
        /// If the <paramref name="dwDesiredAccess"/> parameter specifies the <see cref="READ_CONTROL"/>,
        /// <see cref="WRITE_DAC"/>, or <see cref="WRITE_OWNER"/> standard access rights,
        /// you must also request the <see cref="DESKTOP_READOBJECTS"/> and <see cref="DESKTOP_WRITEOBJECTS"/> access rights.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "OpenInputDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern HDESK OpenInputDesktop([In]DWORD dwFlags, [In]BOOL fInherit, [In]ACCESS_MASK dwDesiredAccess);

        /// <summary>
        /// <para>
        /// Assigns the specified window station to the calling process.
        /// This enables the process to access objects in the window station such as desktops, the clipboard, and global atoms.
        /// All subsequent operations on the window station use the access rights granted to <paramref name="hWinSta"/>.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setprocesswindowstation
        /// </para>
        /// </summary>
        /// <param name="hWinSta">
        /// A handle to the window station.
        /// This can be a handle returned by the <see cref="CreateWindowStation"/>,
        /// <see cref="OpenWindowStation"/>, or <see cref="GetProcessWindowStation"/> function.
        /// This window station must be associated with the current session.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetProcessWindowStation", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetProcessWindowStation([In]HWINSTA hWinSta);

        /// <summary>
        /// <para>
        /// Assigns the specified desktop to the calling thread.
        /// All subsequent operations on the desktop use the access rights granted to the desktop.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-setthreaddesktop
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop to be assigned to the calling thread.
        /// This handle is returned by the <see cref="CreateDesktop"/>, <see cref="GetThreadDesktop"/>,
        /// <see cref="OpenDesktop"/>, or <see cref="OpenInputDesktop"/> function.
        /// This desktop must be associated with the current window station for the process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="SetThreadDesktop"/> function will fail if the calling thread has any windows or hooks on its current desktop
        /// (unless the hDesktop parameter is a handle to the current desktop).
        /// Warning There is a significant security risk for any service that opens a window on the interactive desktop.
        /// By opening a desktop window, a service makes itself vulnerable to attack from the logged-on user,
        /// whose application could send malicious messages to the service's desktop window and affect its ability to function.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetThreadDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SetThreadDesktop([In]HDESK hDesktop);

        /// <summary>
        /// <para>
        /// Makes the specified desktop visible and activates it.
        /// This enables the desktop to receive input from the user.
        /// The calling process must have <see cref="DESKTOP_SWITCHDESKTOP"/> access to the desktop for the <see cref="SwitchDesktop"/> function to succeed.
        /// </para>
        /// </summary>
        /// <param name="hDesktop">
        /// A handle to the desktop.
        /// This handle is returned by the <see cref="CreateDesktop"/> and <see cref="OpenDesktop"/> functions.
        /// This desktop must be associated with the current window station for the process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="TRUE"/>.
        /// If the function fails, the return value is <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// However, <see cref="SwitchDesktop"/> only sets the last error for the following cases:
        /// When the desktop belongs to an invisible window station
        /// When <paramref name="hDesktop"/> is an invalid handle, refers to a destroyed desktop,
        /// or belongs to a different session than that of the calling process
        /// </returns>
        /// <remarks>
        /// The SwitchDesktop function fails if the desktop belongs to an invisible window station.
        /// <see cref="SwitchDesktop"/> also fails when called from a process that is associated with a secured desktop
        /// such as the WinLogon and ScreenSaver desktops.
        /// Processes that are associated with a secured desktop include custom UserInit processes.
        /// Such calls typically fail with an "access denied" error.
        /// </remarks>
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SwitchDesktop", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SwitchDesktop([In]HDESK hDesktop);
    }
}
