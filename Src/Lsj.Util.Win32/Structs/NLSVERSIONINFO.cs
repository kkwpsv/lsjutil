using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SYSNLS_FUNCTION;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Deprecated. Contains version information about an NLS capability.
    /// Starting with Windows 8, your app should use <see cref="NLSVERSIONINFOEX"/> instead of <see cref="NLSVERSIONINFO"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnls/ns-winnls-nlsversioninfo-r1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Starting with Windows 8, <see cref="NLSVERSIONINFO"/> is deprecated.
    /// In fact, it is identical to <see cref="NLSVERSIONINFOEX"/>, which your app should use instead.
    /// See Remarks for <see cref="NLSVERSIONINFOEX"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NLSVERSIONINFO
    {
        /// <summary>
        /// Size, in bytes, of the structure.
        /// </summary>
        public DWORD dwNLSVersionInfoSize;

        /// <summary>
        /// Version.
        /// This value is used to track changes and additions to the set of code points that have the indicated capability for a particular locale.
        /// The value is locale-specific, and increments when the capability changes.
        /// For example, using the <see cref="COMPARE_STRING"/> capability defined by the <see cref="SYSNLS_FUNCTION"/> enumeration,
        /// the version changes if sorting weights are assigned to code points that previously had no weights defined for the locale.
        /// </summary>
        public DWORD dwNLSVersion;

        /// <summary>
        /// Defined version. This value is used to track changes in the repertoire of Unicode code points.
        /// The value increments when the Unicode repertoire is extended, for example, if more characters are defined.
        /// </summary>
        public DWORD dwDefinedVersion;

    }
}
