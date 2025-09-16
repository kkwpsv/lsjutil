using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.BaseTypes.HKEY;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PrivilegeConstants;
using static Lsj.Util.Win32.Enums.ProcessCreationFlags;
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
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createenvironmentblock"/>
        /// </para>
        /// </summary>
        /// <param name="lpEnvironment">
        /// When this function returns, receives a pointer to the new environment block.
        /// The environment block is an array of null-terminated Unicode strings. The list ends with two nulls (\0\0).
        /// </param>
        /// <param name="hToken">
        /// <para>
        /// Token for the user, returned from the <see cref="LogonUser"/> function.
        /// If this is a primary token, the token must have <see cref="TOKEN_QUERY"/> and <see cref="TOKEN_DUPLICATE"/> access.
        /// If the token is an impersonation token, it must have <see cref="TOKEN_QUERY"/> access.
        /// For more information, see Access Rights for Access-Token Objects.
        /// </para>
        /// <para>
        /// If this parameter is <see cref="NULL"/>, the returned environment block contains system variables only.
        /// </para>
        /// </param>
        /// <param name="bInherit">
        /// Specifies whether to inherit from the current process' environment.
        /// If this value is <see cref="TRUE"/>, the process inherits the current process' environment.
        /// If this value is <see cref="FALSE"/>, the process does not inherit the current process' environment.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// To free the buffer when you have finished with the environment block, call the <see cref="DestroyEnvironmentBlock"/> function.
        /// </para>
        /// <para>
        /// If the environment block is passed to <see cref="CreateProcessAsUser"/>,
        /// you must also specify the <see cref="CREATE_UNICODE_ENVIRONMENT"/> flag.
        /// After <see cref="CreateProcessAsUser"/> has returned, the new process has a copy of the environment block,
        /// and <see cref="DestroyEnvironmentBlock"/> can be safely called.
        /// </para>
        /// <para>
        /// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded.
        /// To load a user's profile, call the <see cref="LoadUserProfile"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEnvironmentBlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CreateEnvironmentBlock([Out] out LPVOID lpEnvironment, [In] HANDLE hToken, [In] BOOL bInherit);

        /// <summary>
        /// <para>
        /// Frees environment variables created by the <see cref="CreateEnvironmentBlock"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-destroyenvironmentblock"/>
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
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyEnvironmentBlock", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL DestroyEnvironmentBlock([In] LPVOID lpEnvironment);

        /// <summary>
        /// <para>
        /// Loads the specified user's profile. The profile can be a local user profile or a roaming user profile.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-loaduserprofilew"/>
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
        /// <para>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// <para>
        /// The function fails and returns <see cref="ERROR_INVALID_PARAMETER"/>
        /// if the <see cref="PROFILEINFO.dwSize"/> member of the structure at <paramref name="lpProfileInfo"/>
        /// is not set to <c>sizeof(PROFILEINFO)</c> or if the <see cref="PROFILEINFO.lpUserName"/> member is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// When a user logs on interactively, the system automatically loads the user's profile.
        /// If a service or an application impersonates a user, the system does not load the user's profile.
        /// Therefore, the service or application should load the user's profile with <see cref="LoadUserProfile"/>.
        /// </para>
        /// <para>
        /// Services and applications that call <see cref="LoadUserProfile"/> should check to see if the user has a roaming profile.
        /// If the user has a roaming profile, specify its path as the <see cref="PROFILEINFO.lpProfilePath"/> member of <see cref="PROFILEINFO"/>.
        /// To retrieve the user's roaming profile path, you can call the <see cref="NetUserGetInfo"/> function, specifying information level 3 or 4.
        /// </para>
        /// <para>
        /// Upon successful return, the <see cref="PROFILEINFO.hProfile"/> member of <see cref="PROFILEINFO"/>
        /// is a registry key handle opened to the root of the user's hive.
        /// It has been opened with full access (<see cref="KEY_ALL_ACCESS"/>).
        /// If a service that is impersonating a user needs to read or write to the user's registry file,
        /// use this handle instead of <see cref="HKEY_CURRENT_USER"/>.
        /// Do not close the <see cref="PROFILEINFO.hProfile"/> handle.
        /// Instead, pass it to the <see cref="UnloadUserProfile"/> function.
        /// This function closes the handle.
        /// You should ensure that all handles to keys in the user's registry hive are closed.
        /// If you do not close all open registry handles, the user's profile fails to unload.
        /// For more information, see Registry Key Security and Access Rights and Registry Hives.
        /// </para>
        /// <para>
        /// Note that it is your responsibility to load the user's registry hive into the <see cref="HKEY_USERS"/> registry key
        /// with the <see cref="LoadUserProfile"/> function before you call <see cref="CreateProcessAsUser"/>.
        /// This is because <see cref="CreateProcessAsUser"/> does not load the specified user's profile into <see cref="HKEY_USERS"/>.
        /// This means that access to information in the <see cref="HKEY_CURRENT_USER"/> registry key may not produce results consistent with a normal interactive logon.
        /// </para>
        /// <para>
        /// The calling process must have the <see cref="SE_RESTORE_NAME"/> and <see cref="SE_BACKUP_NAME"/> privileges.
        /// For more information, see Running with Special Privileges.
        /// </para>
        /// <para>
        /// Starting with Windows XP Service Pack 2 (SP2) and Windows Server 2003, the caller must be an administrator or the LocalSystem account.
        /// It is not sufficient for the caller to merely impersonate the administrator or LocalSystem account.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadUserProfileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL LoadUserProfile([In] HANDLE hToken, [In] in PROFILEINFO lpProfileInfo);

        /// <summary>
        /// <para>
        /// Unloads a user's profile that was loaded by the <see cref="LoadUserProfile"/> function.
        /// The caller must have administrative privileges on the computer.
        /// For more information, see the Remarks section of the <see cref="LoadUserProfile"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-unloaduserprofile"/>
        /// </para>
        /// </summary>
        /// <param name="hToken">
        /// Token for the user, returned from the <see cref="LogonUser"/>, <see cref="CreateRestrictedToken"/>, <see cref="DuplicateToken"/>,
        /// <see cref="OpenProcessToken"/>, or <see cref="OpenThreadToken"/> function.
        /// The token must have <see cref="TOKEN_IMPERSONATE"/> and <see cref="TOKEN_DUPLICATE"/> access.
        /// For more information, see Access Rights for Access-Token Objects.
        /// </param>
        /// <param name="hProfile">
        /// Handle to the registry key. This value is the <see cref="PROFILEINFO.hProfile"/> member of the <see cref="PROFILEINFO"/> structure.
        /// For more information see the Remarks section of <see cref="LoadUserProfile"/> and Registry Key Security and Access Rights.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if successful; otherwise, <see cref="FALSE"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before calling <see cref="UnloadUserProfile"/> you should ensure that
        /// all handles to keys that you have opened in the user's registry hive are closed.
        /// If you do not close all open registry handles, the user's profile fails to unload.
        /// For more information, see Registry Key Security and Access Rights and Registry Hives.
        /// </para>
        /// <para>
        /// For more information about calling functions that require administrator privileges, see Running with Special Privileges.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "UnloadUserProfile", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL UnloadUserProfile([In] HANDLE hToken, [In] HANDLE hProfile);
    }
}
