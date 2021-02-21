using Lsj.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the old and new path names for each file that was moved, copied, or renamed by the <see cref="SHFileOperation"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shnamemappingw
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHNAMEMAPPING
    {
        /// <summary>
        /// The address of a character buffer that contains the old path name.
        /// </summary>
        public StringHandle pszOldPath;

        /// <summary>
        /// The address of a character buffer that contains the new path name.
        /// </summary>
        public StringHandle pszNewPath;

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
