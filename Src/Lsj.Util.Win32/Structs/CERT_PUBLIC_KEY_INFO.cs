using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CERT_PUBLIC_KEY_INFO"/> structure contains a public key and its algorithm.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wincrypt/ns-wincrypt-cert_public_key_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_PUBLIC_KEY_INFO
    {
        /// <summary>
        /// <see cref="CRYPT_ALGORITHM_IDENTIFIER"/> structure that contains the public key algorithm type and associated additional parameters.
        /// </summary>
        public CRYPT_ALGORITHM_IDENTIFIER Algorithm;

        /// <summary>
        /// BLOB containing an encoded public key.
        /// </summary>
        public CRYPT_BIT_BLOB PublicKey;
    }
}
