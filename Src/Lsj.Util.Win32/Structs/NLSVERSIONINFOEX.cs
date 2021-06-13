using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SYSNLS_FUNCTION;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains version information about an NLS capability.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnls/ns-winnls-nlsversioninfoex"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// The <see cref="dwNLSVersion"/> and <see cref="dwDefinedVersion"/> members are completely independent.
    /// Although each member is defined for a single <see cref="DWORD"/>, actually each is composed of a major version and a minor version.
    /// See Handling Sorting in Your Applications for more information.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NLSVERSIONINFOEX
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
        /// Starting with Windows 8: Deprecated. Use dwNLSVersion instead.
        /// </summary>
        public DWORD dwDefinedVersion;

        /// <summary>
        /// Identifier of the sort order used for the input locale for the represented version.
        /// For example, for a custom locale en-Mine that uses 0409 for a sort order identifier, this member contains "0409".
        /// If this member specifies a "real" sort, <see cref="guidCustomVersion"/> is set to an empty GUID.
        /// Starting with Windows 8: Deprecated. Use <see cref="guidCustomVersion"/> instead.
        /// </summary>
        public DWORD dwEffectiveId;

        /// <summary>
        /// Unique GUID for the behavior of a custom sort used by the locale for the represented version.
        /// </summary>
        public GUID guidCustomVersion;
    }
}
