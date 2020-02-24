using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.StandardAccessRights;
using static Lsj.Util.Win32.Enums.DesktopAccessRights;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseDesktop", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopW", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDesktopExW", SetLastError = true)]
        public static extern IntPtr CreateDesktopEx([MarshalAs(UnmanagedType.LPWStr)][In]string lpszDesktop, [In]IntPtr lpszDevice, [In]IntPtr pDevmode,
            [In]uint dwFlags, [In]uint dwDesiredAccess,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<SECURITY_ATTRIBUTES>))]
            [In]StructPointerOrNullObject<SECURITY_ATTRIBUTES> lpsa, [In]uint ulHeapSize, [In]IntPtr pvoid);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumDesktopWindows", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumDesktopWindows([In]IntPtr hDesktop, [In]WNDENUMPROC lpfn, [In]IntPtr lParam);

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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetProcessWindowStation", SetLastError = true)]
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
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetThreadDesktop", SetLastError = true)]
        public static extern IntPtr GetThreadDesktop([In]uint dwThreadId);
    }
}
