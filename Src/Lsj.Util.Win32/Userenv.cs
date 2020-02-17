using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
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
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
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
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateEnvironmentBlock", SetLastError = true)]
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
        /// <see langword="true"/> if successful; otherwise, <see langword="false"/>.
        /// To get extended error information, call <see cref="Marshal.GetLastWin32Error"/>.
        /// </returns>
        [DllImport("userenv.dll", CharSet = CharSet.Unicode, EntryPoint = "DestroyEnvironmentBlock", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyEnvironmentBlock([In]IntPtr lpEnvironment);
    }
}
