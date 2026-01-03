using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Urlmon.dll
    /// </summary>
    public static class Urlmon
    {
        /// <summary>
        /// <para>
        /// Deprecated in Windows Internet Explorer 7.
        /// Use <see cref="CreateURLMonikerEx"/> instead.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775102(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="pMkCtx">
        /// The address of the <see cref="IMoniker"/> interface for the URL moniker to use as the base context
        /// when the <paramref name="szURL"/> parameter is a partial URL string.
        /// The <paramref name="pMkCtx"/> parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="szURL">
        /// The address of a string value that contains the display name to be parsed.
        /// </param>
        /// <param name="ppmk">
        /// Pointer to an <see cref="IMoniker"/> interface for the new URL moniker.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns one of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Return code
        /// </term>
        /// <term>
        /// Description
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="S_OK"/>
        /// </term>
        /// <term>
        /// Success.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="E_OUTOFMEMORY"/>
        /// </term>
        /// <term>
        /// The operation ran out of memory.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="MK_E_SYNTAX"/>
        /// </term>
        /// <term>
        /// A moniker cannot be created because <paramref name="szURL"/> does not correspond to valid URL syntax for a full or partial URL.
        /// This is uncommon, because most parsing of the URL occurs during binding, and the syntax for URLs is extremely flexible.
        /// </term>
        /// </item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The <see cref="CreateURLMoniker"/> function creates a URL moniker from a full URL string,
        /// or from a base context URL moniker and a partial URL string.
        /// </para>
        /// <para>
        /// Security Warning:
        /// This function does not correctly interpret percent encoded octets in Windows file paths or "file://" scheme Uniform Resource Identifiers (URIs).
        /// On systems with Microsoft Internet Explorer 6 and earlier,
        /// calling <see cref="CreateURLMoniker"/> with the output of a previous call might produce a result that is not equivalent.
        /// Since <see cref="CreateURLMoniker"/> can produce results that are not equivalent to the input, its use can result in security problems.
        /// </para>
        /// <para>
        /// Use <see cref="CreateURLMonikerEx"/> with the <see cref="URL_MK_UNIFORM"/> flag
        /// to ensure that Windows file paths and "file://" URIs are interpreted correctly with regard to percent encoded octets;
        /// and that the result is equivalent to the input.
        /// To correctly extract a Windows file path from the result of <see cref="CreateURLMoniker"/>, use the <see cref="PathCreateFromUrl"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("Urlmon.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateURLMoniker", ExactSpelling = true)]
        public static extern HRESULT CreateURLMoniker(
#if NETFRAMEWORK
            [In] nint pMkCtx,
#else
            [In] P<IMoniker> pMkCtx,
#endif
            [In] LPCWSTR szURL,
#if NETFRAMEWORK
            [Out] out nint ppmk
#else
            [Out] out P<IMoniker> ppmk
#endif
            );

        /// <summary>
        /// <para>
        /// Creates a URL moniker from a full URL, or from a base context URL moniker and a partial URL.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/previous-versions/windows/internet-explorer/ie-developer/platform-apis/ms775103(v=vs.85)"/>
        /// </para>
        /// </summary>
        /// <param name="pMkCtx">
        /// A pointer to an <see cref="IMoniker"/> interface of the URL moniker to use as the base context
        /// when the <paramref name="szURL"/> parameter is a partial URL string.
        /// The <paramref name="pMkCtx"/> parameter can be <see cref="NULL"/>.
        /// </param>
        /// <param name="szURL">
        /// A string value that contains the URL to be parsed.
        /// </param>
        /// <param name="ppmk">
        /// A pointer to an <see cref="IMoniker"/> interface for the new URL moniker.
        /// </param>
        /// <param name="dwFlags">
        /// <para>
        /// A <see cref="DWORD"/> value that specifies which URL parser to use.
        /// This can be one of the following values.
        /// </para>
        /// <para>
        /// <see cref="URL_MK_LEGACY"/>
        /// </para>
        /// <para>
        /// Use the same URL parser as <see cref="CreateURLMoniker"/>.
        /// </para>
        /// <para>
        /// <see cref="URL_MK_UNIFORM"/>
        /// </para>
        /// <para>
        /// Use the updated URL parser.
        /// </para>
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it returns an <see cref="HRESULT"/> error code.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Use <see cref="CreateURLMonikerEx"/> with the <see cref="URL_MK_UNIFORM"/> flag to ensure
        /// that a Windows file path and "file://" Uniform Resource Identifier (URI) is interpreted correctly with regard to percent encoded octets,
        /// and that the result is equivalent to the input.
        /// To correctly extract a Windows file path from the result of <see cref="CreateURLMonikerEx"/>, use <see cref="PathCreateFromUrl"/>.
        /// </para>
        /// <para>
        /// For compatibility reasons, it might be possible to create a URL moniker from an invalid URL;
        /// however, such a base moniker cannot be combined with a relative URL.
        /// Any attempt to do so will fail with <see cref="E_INVALIDARG"/>.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsXP)]
        [DllImport("Urlmon.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateURLMonikerEx", ExactSpelling = true)]
        public static extern HRESULT CreateURLMonikerEx(
#if NETFRAMEWORK
            [In] nint pMkCtx,
#else
            [In] P<IMoniker> pMkCtx,
#endif
            [In] LPCWSTR szURL,
#if NETFRAMEWORK
            [Out] out nint ppmk,
#else
            [Out] out P<IMoniker> ppmk,
#endif
            [In] DWORD dwFlags);
    }
}
