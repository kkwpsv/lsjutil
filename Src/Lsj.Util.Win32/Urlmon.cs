using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Urlmon.dll
    /// </summary>
    public static class Urlmon
    {
        /// <summary>
        /// <para>
        /// Creates a URL moniker from a full URL, or from a base context URL moniker and a partial URL.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775103(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="pMkCtx">
        /// A pointer to an <see cref="IMoniker"/> interface of the URL moniker to use as the base context
        /// when the <paramref name="szURL"/> parameter is a partial URL string.
        /// The <paramref name="pMkCtx"/> parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="szURL">
        /// A string value that contains the URL to be parsed.
        /// </param>
        /// <param name="ppmk">
        /// A pointer to an <see cref="IMoniker"/> interface for the new URL moniker.
        /// </param>
        /// <param name="dwFlags">
        /// A <see cref="DWORD"/> value that specifies which URL parser to use.
        /// This can be one of the following values.
        /// <see cref="URL_MK_LEGACY"/>:
        /// Use the same URL parser as <see cref="CreateURLMoniker"/>.
        /// <see cref="URL_MK_UNIFORM"/>:
        /// Use the updated URL parser.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// Use CreateURLMonikerEx with the <see cref="URL_MK_UNIFORM"/> flag to ensure that a Windows file path
        /// and "file://" Uniform Resource Identifier (URI) is interpreted correctly with regard to percent encoded octets,
        /// and that the result is equivalent to the input.
        /// To correctly extract a Windows file path from the result of <see cref="CreateURLMonikerEx"/>, use <see cref="PathCreateFromUrl"/>.
        /// For compatibility reasons, it might be possible to create a URL moniker from an invalid URL;
        /// however, such a base moniker cannot be combined with a relative URL.
        /// Any attempt to do so will fail with <see cref="E_INVALIDARG"/>.
        /// </remarks>
        [DllImport("Urlmon.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateOleAdviseHolder", ExactSpelling = true, SetLastError = true)]
        public static extern HRESULT CreateURLMonikerEx([In]IMoniker pMkCtx, [MarshalAs(UnmanagedType.LPWStr)][In]string szURL,
            [Out]out IMoniker ppmk, [In]DWORD dwFlags);
    }
}
