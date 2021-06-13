using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Used generically to filter elements.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shtypes/ns-shtypes-comdlg_filterspec"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COMDLG_FILTERSPEC
    {
        /// <summary>
        /// A pointer to a buffer that contains the friendly name of the filter.
        /// </summary>
        public string pszName;

        /// <summary>
        /// A pointer to a buffer that contains the filter pattern.
        /// </summary>
        public string pszSpec;
    }
}
