using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.RegistryKeyAccessRights;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.TokenAccessRights;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Userenv.dll
    /// </summary>
    public static class Userenv
    {
        /// <summary>
        /// <para>
        /// Retrieves the environment variables for the specified user.
        /// This block can then be passed to the <see cref="CreateProcessAsUser"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/userenv/nf-userenv-createenvironmentblock
        /// </para>
        /// </summary>
        /// <param name="lpEnvironment">
        /// When this function returns, receives a pointer to the new environment block.
        /// The environment block is an array of null-terminated Unicode strings. The list ends with two nulls (\0\0).
        /// </param>
        /// <param name="hToken">
        /// Token for the user, returned from the <see cref="LogonUser"/> function.
        /// If this is a primary token, the token must have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_DUPLICATE"/> access.
        /// If the token is an impersonation token, it must have <see cref="TOKEN_QUERY"/> access.
        /// For more information, see Access Rights for Access-Token Objects.
        /// If this parameter is <see cref="IntPtr.Zero"/>, the returned environment block contains system variables only.
        /// </param>
        /// <param name="bInherit">
        /// Specifies whether to inherit from the current process' environment.
        /// If this value is <see langword="true"/>, the process inherits the current process' environment.
        /// If this value is <see langword="false"/>, the process does not inherit the current process' environment.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if successful; otherwise, <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// To free the buffer when you have finished with the environment block, call the <see cref="DestroyEnvironmentBlock"/> function.
        /// If the environment block is passed to <see cref="CreateProcessAsUser"/>, you must also specify
        /// the <see cref="ProcessCreationFlags.CREATE_UNICODE_ENVIRONMENT"/> flag.
        /// After <see cref="CreateProcessAsUser"/> has returned, the new process has a copy of the environment block,
        /// and <see cref="DestroyEnvironmentBlock"/> can be safely called.
        /// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded.
        /// To load a user's profile, call the <see cref="LoadUserProfile"/> function.
        /// </remarks>
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEnvironmentBlock", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateEnvironmentBlock([Out]out IntPtr lpEnvironment, [In]IntPtr hToken, [In]bool bInherit);

        /// <summary>
        /// <para>
        /// Frees environment variables created by the CreateEnvironmentBlock function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/userenv/nf-userenv-destroyenvironmentblock
        /// </para>
        /// </summary>
        /// <param name="lpEnvironment">
        /// Pointer to the environment block created by <see cref="CreateEnvironmentBlock"/>.
        /// The environment block is an array of null-terminated Unicode strings.
        /// The list ends with two nulls (\0\0).
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyEnvironmentBlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyEnvironmentBlock([In]IntPtr lpEnvironment);

        /// <summary>
        /// <para>
        /// Loads the specified user's profile. The profile can be a local user profile or a roaming user profile.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/userenv/nf-userenv-loaduserprofilew
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// Token for the user, which is returned by the <see cref="LogonUser"/>, <see cref="CreateRestrictedToken"/>,
        /// <see cref="DuplicateToken"/>, <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> function.
        /// The token must have <see cref="TOKEN_QUERY"/>, <see cref="TOKEN_IMPERSONATE"/>, and <see cref="TOKEN_DUPLICATE"/> access.
        /// For more information, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="lpProfileInfo">
        /// Pointer to a <see cref="PROFILEINFO"/> structure.
        /// <see cref="LoadUserProfile"/> fails and returns <see cref="ERROR_INVALID_PARAMETER"/>
        /// if the <see cref="PROFILEINFO.dwSize"/> member of the structure is not set to <code>sizeof(PROFILEINFO)</code> or
        /// if the <see cref="PROFILEINFO.lpUserName"/> member is <see cref="NULL"/>.
        /// For more information, see Remarks.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>. To get extended error information, call <see cref="GetLastError"/>.
        /// The function fails and returns <see cref="ERROR_INVALID_PARAMETER"/> if the <see cref="PROFILEINFO.dwSize"/> member
        /// of the structure at <paramref name="lpProfileInfo"/> is not set to <code>sizeof(PROFILEINFO)</code> or
        /// if the <see cref="PROFILEINFO.lpUserName"/> member is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When a user logs on interactively, the system automatically loads the user's profile.
        /// If a service or an application impersonates a user, the system does not load the user's profile.
        /// Therefore, the service or application should load the user's profile with <see cref="LoadUserProfile"/>.
        /// Services and applications that call <see cref="LoadUserProfile"/> should check to see if the user has a roaming profile.
        /// If the user has a roaming profile, specify its path as the <see cref="PROFILEINFO.lpProfilePath"/> member of <see cref="PROFILEINFO"/>.
        /// To retrieve the user's roaming profile path, you can call the <see cref="NetUserGetInfo"/> function, specifying information level 3 or 4.
        /// Upon successful return, the <see cref="PROFILEINFO.hProfile"/> member of <see cref="PROFILEINFO"/> is
        /// a registry key handle opened to the root of the user's hive.
        /// It has been opened with full access (<see cref="KEY_ALL_ACCESS"/>).
        /// If a service that is impersonating a user needs to read or write to the user's registry file,
        /// use this handle instead of <see cref="HKEY_CURRENT_USER"/>. Do not close the <see cref="PROFILEINFO.hProfile"/> handle.
        /// Instead, pass it to the <see cref="UnloadUserProfile"/> function. This function closes the handle.
        /// You should ensure that all handles to keys in the user's registry hive are closed.
        /// If you do not close all open registry handles, the user's profile fails to unload.
        /// For more information, see Registry Key Security and Access Rights and Registry Hives.
        /// Note that it is your responsibility to load the user's registry hive into the <see cref="HKEY_USERS"/> registry key
        /// with the <see cref="LoadUserProfile"/> function before you call <see cref="CreateProcessAsUser"/>.
        /// This is because <see cref="CreateProcessAsUser"/> does not load the specified user's profile into <see cref="HKEY_USERS"/>.
        /// This means that access to information in the <see cref="HKEY_CURRENT_USER"/> registry key
        /// may not produce results consistent with a normal interactive logon.
        /// The calling process must have the SE_RESTORE_NAME and SE_BACKUP_NAME privileges.
        /// For more information, see Running with Special Privileges.
        /// Starting with Windows XP Service Pack 2 (SP2) and Windows Server 2003, the caller must be an administrator or the LocalSystem account.
        /// It is not sufficient for the caller to merely impersonate the administrator or LocalSystem account.
        /// </remarks>
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadUserProfileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LoadUserProfile([In]HANDLE hToken, [In]in PROFILEINFO lpProfileInfo);
    }
}
