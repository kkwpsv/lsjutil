using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended parameters for the <see cref="TrackPopupMenuEx"/> function.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-tpmparams
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct TPMPARAMS
    {
        /// <summary>
        /// The size of structure, in bytes.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// The rectangle to be excluded when positioning the window, in screen coordinates.
        /// </summary>
        public RECT rcExclude;
    }
}
