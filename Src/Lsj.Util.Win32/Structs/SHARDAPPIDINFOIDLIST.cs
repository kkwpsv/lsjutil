using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains data used by <see cref="SHAddToRecentDocs"/> to identify both an item—
    /// in this case by an absolute pointer to an item identifier list (PIDL)—and the process that it is associated with.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/shlobj_core/ns-shlobj_core-shardappidinfoidlist"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHARDAPPIDINFOIDLIST
    {
        /// <summary>
        /// An absolute PIDL that gives the full path of the item in the Shell namespace.
        /// </summary>
        public LPCITEMIDLIST pidl;

        /// <summary>
        /// The application-defined AppUserModelID associated with the item.
        /// </summary>
        public IntPtr pszAppID;
    }
}
