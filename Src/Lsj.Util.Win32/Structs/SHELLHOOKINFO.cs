using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// SHELLHOOKINFO
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHELLHOOKINFO
    {
        /// <summary>
        /// hwnd
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// rc
        /// </summary>
        public RECT rc;
    }
}
