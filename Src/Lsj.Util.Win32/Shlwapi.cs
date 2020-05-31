using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Shlwapi.dll
    /// </summary>
    public static class Shlwapi
    {
        /// <summary>
        /// <para>
        /// Checks for specified operating systems and operating system features.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shlwapi/nf-shlwapi-isos
        /// </para>
        /// </summary>
        /// <param name="dwOS"></param>
        /// <returns></returns>
        [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode, EntryPoint = "IsOS", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsOS([In] OSFeatures dwOS);
    }
}
