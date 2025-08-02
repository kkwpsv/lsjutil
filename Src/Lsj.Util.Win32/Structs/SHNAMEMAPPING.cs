using Lsj.Util.Win32.Marshals;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the old and new path names for each file that was moved, copied, or renamed by the <see cref="SHFileOperation"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shellapi/ns-shellapi-shnamemappingw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// There are two versions of this structure, an ANSI version (SHFILEOPSTRUCTA) and a Unicode version (SHFILEOPSTRUCTW).
    /// The Unicode version is identical to the ANSI version, except that wide character strings (<see cref="LPCWSTR"/>) are used
    /// in place of ANSI character strings (<see cref="LPCSTR"/>).
    /// On Windows 98 and earlier, only the ANSI version is supported.
    /// On Microsoft Windows NT 4.0 and later, both the ANSI and Unicode versions of this structure are supported.
    /// SHNAMEMAPPINGA and SHNAMEMAPPINGW should never be used directly;
    /// the appropriate structure is redefined as <see cref="SHNAMEMAPPING"/> by the precompiler
    /// depending on whether the application is compiled for ANSI or Unicode.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHNAMEMAPPING
    {
        /// <summary>
        /// The address of a character buffer that contains the old path name.
        /// </summary>
        public IntPtr pszOldPath;

        /// <summary>
        /// The address of a character buffer that contains the new path name.
        /// </summary>
        public IntPtr pszNewPath;

        /// <summary>
        /// The number of characters in <see cref="pszOldPath"/>.
        /// </summary>
        public int cchOldPath;

        /// <summary>
        /// The number of characters in <see cref="pszNewPath"/>.
        /// </summary>
        public int cchNewPath;
    }
}
