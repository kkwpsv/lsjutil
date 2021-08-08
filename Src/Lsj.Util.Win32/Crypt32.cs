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
        /// The <see cref="CertCompareIntegerBlob"/> function compares two integer BLOBs to determine whether they represent equal numeric values.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/wincrypt/nf-wincrypt-certcompareintegerblob"/>
        /// </para>
        /// </summary>
        /// <param name="pInt1">
        /// A pointer to a <see cref="CRYPT_INTEGER_BLOB"/> structure that contains the first integer in the comparison.
        /// </param>
        /// <param name="pInt2">
        /// A pointer to a <see cref="CRYPT_INTEGER_BLOB"/> structure that contains the second integer in the comparison.
        /// </param>
        /// <returns>
        /// If the representations of the integer BLOBs are identical and the function succeeds, the function returns <see cref="TRUE"/>.
        /// If the function fails, it returns <see cref="FALSE"/>. For extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertCompareIntegerBlob", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CertCompareIntegerBlob([In] in CRYPT_INTEGER_BLOB pInt1, [In] in CRYPT_INTEGER_BLOB pInt2);

        /// <summary>
        /// <para>
        /// The <see cref="CertDuplicateCertificateContext"/> function duplicates a certificate context by incrementing its reference count.
        /// </para>
        /// </summary>
        /// <param name="pCertContext">
        /// A pointer to the <see cref="CERT_CONTEXT"/> structure for which the reference count is incremented.
        /// </param>
        /// <returns>
        /// Currently, a copy is not made of the context, and the returned pointer to a context has the same value as the pointer to a context that was input.
        /// If the pointer passed into this function is <see cref="NULL"/>, <see cref="NULL"/> is returned.
        /// When you have finished using the duplicate context, decrease its reference count by calling the <see cref="CertFreeCertificateContext"/> function.
        /// </returns>
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertDuplicateCertificateContext", ExactSpelling = true, SetLastError = true)]
        public static extern PCCERT_CONTEXT CertDuplicateCertificateContext([In] in PCCERT_CONTEXT pCertContext);

        /// <summary>
        /// <para>
        /// The <see cref="CertFreeCertificateContext"/> function frees a certificate context by decrementing its reference count.
        /// When the reference count goes to zero, <see cref="CertFreeCertificateContext"/> frees the memory used by a certificate context.
        /// To free a context obtained by a get, duplicate, or create function, call the appropriate free function.
        /// To free a context obtained by a find or enumerate function,
        /// either pass it in as the previous context parameter to a subsequent invocation of the function, or call the appropriate free function.
        /// For more information, see the reference topic for the function that obtains the context.
        /// </para>
        /// </summary>
        /// <param name="pCertContext">
        /// A pointer to the <see cref="CERT_CONTEXT"/> to be freed.
        /// </param>
        /// <returns></returns>
        [DllImport("Crypt32.dll", CharSet = CharSet.Unicode, EntryPoint = "CertFreeCertificateContext", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL CertFreeCertificateContext([In] PCCERT_CONTEXT pCertContext);
    }
}
