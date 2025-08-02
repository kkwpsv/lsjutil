using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Allows you to pass a particular user name and password to the run-time library for the purpose of authentication.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/sspi/ns-sspi-sec_winnt_auth_identity_w"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// When this structure is used with RPC, the structure must remain valid for the lifetime of the binding handle.
    /// </para>
    /// <para>
    /// The strings may be ANSI or Unicode, depending on the value you assign to the <see cref="Flags"/> member.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SEC_WINNT_AUTH_IDENTITY
    {
        /// <summary>
        /// SEC_WINNT_AUTH_IDENTITY_ANSI
        /// </summary>
        public const uint SEC_WINNT_AUTH_IDENTITY_ANSI = 0x1;

        /// <summary>
        /// SEC_WINNT_AUTH_IDENTITY_UNICODE
        /// </summary>
        public const uint SEC_WINNT_AUTH_IDENTITY_UNICODE = 0x2;

        /// <summary>
        /// A string that contains the user name.
        /// </summary>
        public P<char> User;

        /// <summary>
        /// The length, in characters, of the user string, not including the terminating null character.
        /// </summary>
        public uint UserLength;

        /// <summary>
        /// A string that contains the domain name or the workgroup name.
        /// </summary>
        public P<char> Domain;

        /// <summary>
        /// The length, in characters, of the domain string, not including the terminating null character.
        /// </summary>
        public uint DomainLength;

        /// <summary>
        /// A string that contains the password of the user in the domain or workgroup.
        /// When you have finished using the password, remove the sensitive information from memory by calling <see cref="SecureZeroMemory"/>.
        /// For more information about protecting the password, see Handling Passwords.
        /// </summary>
        public P<char> Password;

        /// <summary>
        /// The length, in characters, of the password string, not including the terminating null character.
        /// </summary>
        public uint PasswordLength;

        /// <summary>
        /// <para>
        /// This member can be one of the following values.
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
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_ANSI"/>
        /// </term>
        /// <term>
        /// The strings in this structure are in ANSI format.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="SEC_WINNT_AUTH_IDENTITY_UNICODE"/>
        /// </term>
        /// <term>
        /// The strings in this structure are in Unicode format.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public uint Flags;
    }
}
