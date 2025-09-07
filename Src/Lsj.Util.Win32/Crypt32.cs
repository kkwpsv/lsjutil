using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Crypt32.dll
    /// </summary>
    public static class Crypt32
    {
        /// <summary>
        /// <para>
        /// The <see cref="CertCompareIntegerBlob"/> function compares two integer BLOBs
        /// to determine whether they represent equal numeric values.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certcompareintegerblob"/>
        /// </para>
        /// </summary>
        /// <param name="pInt1">
        /// A pointer to a <see cref="CRYPT_INTEGER_BLOB"/> structure that contains the first integer in the comparison.
        /// </param>
        /// <param name="pInt2">
        /// A pointer to a <see cref="CRYPT_INTEGER_BLOB"/> structure that contains the second integer in the comparison.
        /// </param>
        /// <returns>
        /// <para>
        /// If the representations of the integer BLOBs are identical and the function succeeds,
        /// the function returns nonzero (<see cref="TRUE"/>).
        /// </para>
        /// <para>
        /// If the function fails, it returns zero (<see cref="FALSE"/>).
        /// For extended error information, call <see cref="GetLastError"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Before doing the comparison, most significant bytes with a value of 0x00 are removed from a positive number.
        /// Positive here means that the most significant bit in the next nonzero byte is not set.
        /// </para>
        /// <para>
        /// Most significant bytes with a value of 0xFF are removed from a negative number.
        /// Negative here means that the most significant bit in the next non-0xFF byte is set.
        /// This produces the unique representation of that integer, as shown in the following table.
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Original bytes
        /// </term>
        /// <term>
        /// Reduced form
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// 0xFFFFFF88
        /// </term>
        /// <term>
        /// 0xFF88
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0xFF23
        /// </term>
        /// <term>
        /// 0xFF23
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x007F
        /// </term>
        /// <term>
        /// 0x7F
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// 0x00000080
        /// </term>
        /// <term>
        /// 0x80
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Multiple-byte integers are treated as little-endian.
        /// The least significant byte is pbData[0].
        /// The most significant byte is pbData[cbData - 1], that is, 0xFFFFFF88 is stored in four bytes as:
        /// </para>
        /// <para>
        /// {0x88, 0xFF, 0xFF, 0xFF}
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertCompareIntegerBlob", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CertCompareIntegerBlob([In] in CRYPT_INTEGER_BLOB pInt1, [In] in CRYPT_INTEGER_BLOB pInt2);

        /// <summary>
        /// <para>
        /// The <see cref="CertDuplicateCertificateContext"/> function duplicates a certificate context
        /// by incrementing its reference count.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certduplicatecertificatecontext"/>
        /// </para>
        /// </summary>
        /// <param name="pCertContext">
        /// A pointer to the <see cref="CERT_CONTEXT"/> structure for which the reference count is incremented.
        /// </param>
        /// <returns>
        /// Currently, a copy is not made of the context,
        /// and the returned pointer to a context has the same value as the pointer to a context that was input.
        /// If the pointer passed into this function is <see cref="NULL"/>, <see cref="NULL"/> is returned.
        /// When you have finished using the duplicate context,
        /// decrease its reference count by calling the <see cref="CertFreeCertificateContext"/> function.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertDuplicateCertificateContext", ExactSpelling = true)]
        public static extern PCCERT_CONTEXT CertDuplicateCertificateContext([In] in PCCERT_CONTEXT pCertContext);

        /// <summary>
        /// <para>
        /// The <see cref="CertFreeCertificateContext"/> function frees a certificate context by decrementing its reference count.
        /// When the reference count goes to zero, <see cref="CertFreeCertificateContext"/> frees the memory used by a certificate context.
        /// </para>
        /// <para>
        /// To free a context obtained by a get, duplicate, or create function, call the appropriate free function.
        /// To free a context obtained by a find or enumerate function,
        /// either pass it in as the previous context parameter to a subsequent invocation of the function,
        /// or call the appropriate free function.
        /// For more information, see the reference topic for the function that obtains the context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-certfreecertificatecontext"/>
        /// </para>
        /// </summary>
        /// <param name="pCertContext">
        /// A pointer to the <see cref="CERT_CONTEXT"/> to be freed.
        /// </param>
        /// <returns>
        /// The function always returns nonzero.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertFreeCertificateContext", ExactSpelling = true)]
        public static extern BOOL CertFreeCertificateContext([In] PCCERT_CONTEXT pCertContext);
    }
}
