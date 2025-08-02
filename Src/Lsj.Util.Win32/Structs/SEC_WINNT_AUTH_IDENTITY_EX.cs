using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SEC_WINNT_AUTH_IDENTITY_EX"/> structure contains information about a user.
    /// Both an ANSI and Unicode form of this structure are provided.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sspi/ns-sspi-sec_winnt_auth_identity_exw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Note that when this structure is used with RPC, the structure must remain valid for the lifetime of the binding handle.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SEC_WINNT_AUTH_IDENTITY_EX
    {
        /// <summary>
        /// An unsigned long that indicates the version number of the structure.
        /// </summary>
        public uint Version;

        /// <summary>
        /// An unsigned long that indicates the length, in bytes, of the structure.
        /// </summary>
        public uint Length;

        /// <summary>
        /// A Unicode or ANSI string that contains the name of the user account.
        /// </summary>
        public P<char> User;

        /// <summary>
        /// The length, in characters, of the <see cref="User"/> string.
        /// </summary>
        public uint UserLength;

        /// <summary>
        /// A Unicode or ANSI string that contains the name of the domain for the user account.
        /// </summary>
        public P<char> Domain;

        /// <summary>
        /// The length, in characters, of the <see cref="Domain"/> string.
        /// </summary>
        public uint DomainLength;

        /// <summary>
        /// A Unicode or ANSI string that contains the user password in plaintext.
        /// When you have finished using the password, remove the sensitive information from memory
        /// by calling the <see cref="SecureZeroMemory"/> function.
        /// For more information about protecting the password, see Handling Passwords.
        /// </summary>
        public P<char> Password;

        /// <summary>
        /// The length, in characters, of the <see cref="Password"/> string.
        /// </summary>
        public uint PasswordLength;

        /// <summary>
        /// <para>
        /// An unsigned long flag that indicates the type used by negotiable security packages.
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
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_MARSHALLED"/>
        /// </term>
        /// <term>
        /// All data is in one buffer.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_ONLY"/>
        /// </term>
        /// <term>
        /// Used with the Kerberos security support provider (SSP).
        /// Credentials are for identity only.
        /// The Kerberos package is directed to not include authorization data in the ticket.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_ANSI"/>
        /// </term>
        /// <term>
        /// Credentials are in ANSI form.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_UNICODE"/>
        /// </term>
        /// <term>
        /// Credentials are in Unicode form.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public uint Flags;

        /// <summary>
        /// <para>
        /// A Unicode or ANSI string that contains a comma-separated list of names of security packages that are available when using the Microsoft Negotiate provider.
        /// </para>
        /// <para>
        /// Set this to "!ntlm" to specify that the NTLM package is not to be used.
        /// </para>
        /// </summary>
        public P<char> PackageList;

        /// <summary>
        /// The length, in characters, of the <see cref="PackageList"/> string.
        /// </summary>
        public uint PackageListLength;
    }
}
