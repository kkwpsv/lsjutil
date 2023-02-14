using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Structs.SEC_WINNT_AUTH_IDENTITY;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains a user name and password.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ns-wtypesbase-coauthidentity"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// COM does not persist the user's password information.
    /// For applications that use passwords, please see the documentation on Cryptography (CryptoAPI).
    /// This structure is equivalent to the <see cref="SEC_WINNT_AUTH_IDENTITY"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COAUTHIDENTITY
    {
        /// <summary>
        /// The user's name.
        /// </summary>
        public P<USHORT> User;

        /// <summary>
        /// The length of the <see cref="User"/> string, without the terminating <see cref="NULL"/>.
        /// </summary>
        public ULONG UserLength;

        /// <summary>
        /// The domain or workgroup name.
        /// </summary>
        public P<USHORT> Domain;

        /// <summary>
        /// The length of the <see cref="Domain"/> string, without the terminating <see cref="NULL"/>.
        /// </summary>
        public ULONG DomainLength;

        /// <summary>
        /// The user's password in the domain or workgroup.
        /// </summary>
        public P<USHORT> Password;

        /// <summary>
        /// The length of the <see cref="Password"/> string, without the terminating <see cref="NULL"/>.
        /// </summary>
        public ULONG PasswordLength;

        /// <summary>
        /// Indicates whether the strings are Unicode strings.
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_ANSI"/>: The strings are ANSI strings.
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_UNICODE"/>: The strings are Unicode strings.
        /// </summary>
        public ULONG Flags;
    }
}
