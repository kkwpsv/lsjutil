using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IMPGetIMEW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IMPGetIME([In] HWND unnamedParam1, [Out] out IMEPRO unnamedParam2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IMPQueryIMEW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IMPQueryIME([In][Out] ref IMEPRO unnamedParam1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IMPSetIMEW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IMPSetIME([In] HWND unnamedParam1, [In] in IMEPRO unnamedParam2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WINNLSGetIMEHotkey", ExactSpelling = true, SetLastError = true)]
        public static extern UINT WINNLSGetIMEHotkey([In] HWND unnamedParam1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WINNLSEnableIME", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WINNLSEnableIME([In] HWND unnamedParam1, [In] BOOL unnamedParam2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "WINNLSGetEnableStatus", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL WINNLSGetEnableStatus([In] HWND unnamedParam1);
    }
}
