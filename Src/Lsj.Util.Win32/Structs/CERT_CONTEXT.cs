using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Crypt32;
using static Lsj.Util.Win32.Enums.CertificateAndMessageEncodingTypes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="CERT_CONTEXT"/> structure contains both the encoded and decoded representations of a certificate.
    /// A certificate context returned by one of the functions defined in Wincrypt.h
    /// must be freed by calling the <see cref="CertFreeCertificateContext"/> function.
    /// The <see cref="CertDuplicateCertificateContext"/> function can be called
    /// to make a duplicate copy (which also must be freed by calling <see cref="CertFreeCertificateContext"/>).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cert_context"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CERT_CONTEXT
    {
        /// <summary>
        /// <para>
        /// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types
        /// by combining them with a bitwise-OR operation as shown in the following example:
        /// </para>
        /// <para>
        /// <code>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING </code>
        /// </para>
        /// <para>
        /// Currently defined encoding types are:
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// X509_ASN_ENCODING
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// PKCS_7_ASN_ENCODING
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public CertificateAndMessageEncodingTypes dwCertEncodingType;

        /// <summary>
        /// A pointer to a buffer that contains the encoded certificate.
        /// </summary>
        public nint pbCertEncoded;

        /// <summary>
        /// The size, in bytes, of the encoded certificate.
        /// </summary>
        public nint cbCertEncoded;

        /// <summary>
        /// The address of a <see cref="CERT_INFO"/> structure that contains the certificate information.
        /// </summary>
        public nint pCertInfo;

        /// <summary>
        /// A handle to the certificate store that contains the certificate context.
        /// </summary>
        public HCERTSTORE hCertStore;
    }
}
