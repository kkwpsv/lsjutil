using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.TOKEN_INFORMATION_CLASS;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
#pragma warning disable CS1574
    /// <summary>
    /// Advapi32.dll
    /// </summary>
    public static class Advapi32
    {
        /// <summary>
        /// <para>
        /// The <see cref="GetTokenInformation"/> function retrieves a specified type of information about an access token.
        /// The calling process must have appropriate access rights to obtain the information.
        /// To determine if a user is a member of a specific group, use the <see cref="CheckTokenMembership"/> function.
        /// To determine group membership for app container tokens, use the <see cref="CheckTokenMembershipEx"/> function.
        /// </para>
        /// </summary>
        /// <param name="TokenHandle">
        /// A handle to an access token from which information is retrieved.
        /// If <paramref name="TokenInformationClass"/> specifies <see cref="TokenSource"/>, the handle must have <see cref="TOKEN_QUERY_SOURCE"/> access.
        /// For all other <paramref name="TokenInformationClass"/> values, the handle must have <see cref="TOKEN_QUERY"/> access.
        /// </param>
        /// <param name="TokenInformationClass">
        /// Specifies a value from the <see cref="TOKEN_INFORMATION_CLASS"/> enumerated type to identify the type of information the function retrieves.
        /// Any callers who check the TokenIsAppContainer and have it return 0 should also verify that
        /// the caller token is not an identify level impersonation token.
        /// If the current token is not an app container but is an identity level token, you should return AccessDenied.
        /// </param>
        /// <param name="TokenInformation">
        /// A pointer to a buffer the function fills with the requested information.
        /// The structure put into this buffer depends upon the type of information specified by the <paramref name="TokenInformationClass"/> parameter.
        /// </param>
        /// <param name="TokenInformationLength">
        /// Specifies the size, in bytes, of the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If <paramref name="TokenInformation"/> is NULL, this parameter must be zero.
        /// </param>
        /// <param name="ReturnLength">
        /// A pointer to a variable that receives the number of bytes needed for the buffer pointed to by the <paramref name="TokenInformation"/> parameter.
        /// If this value is larger than the value specified in the <paramref name="TokenInformationLength"/> parameter,
        /// the function fails and stores no data in the buffer.
        /// If the value of the <paramref name="TokenInformationClass"/> parameter is <see cref="TokenDefaultDacl"/> and the token has no default DACL,
        /// the function sets the variable pointed to by <paramref name="ReturnLength"/> to sizeof(<see cref="TOKEN_DEFAULT_DACL"/>) and
        /// sets the <see cref="TOKEN_DEFAULT_DACL.DefaultDacl"/> member of the <see cref="TOKEN_DEFAULT_DACL"/> structure to <see cref="IntPtr.Zero"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTokenInformation", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTokenInformation([In]IntPtr TokenHandle, [In]TOKEN_INFORMATION_CLASS TokenInformationClass,
            [In]IntPtr TokenInformation, [In]uint TokenInformationLength, [Out]out uint ReturnLength);
    }
}
#pragma warning restore CS1574