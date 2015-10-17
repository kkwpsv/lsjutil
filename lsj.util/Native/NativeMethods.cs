using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Native
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        [return:MarshalAs(UnmanagedType.Bool)]
        internal static extern bool WritePrivateProfileString(
            [In][MarshalAs(UnmanagedType.LPWStr)]string section,
            [In][MarshalAs(UnmanagedType.LPWStr)]string key,
            [In][MarshalAs(UnmanagedType.LPWStr)]string val,
            [In][MarshalAs(UnmanagedType.LPWStr)]string filePath);

        [DllImport("kernel32.dll")]
        
        internal static extern uint GetPrivateProfileString(
            [In][MarshalAs(UnmanagedType.LPWStr)]string section,
            [In][MarshalAs(UnmanagedType.LPWStr)]string key,
            [In][MarshalAs(UnmanagedType.LPWStr)]string def,
            [Out][MarshalAs(UnmanagedType.LPWStr)]StringBuilder retVal,
            [In]uint size,
            [In][MarshalAs(UnmanagedType.LPWStr)]string filePath);
    }
}
