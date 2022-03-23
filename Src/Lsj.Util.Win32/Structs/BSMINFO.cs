using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.BroadcastSystemMessageFlags;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a window that denied a request from <see cref="BroadcastSystemMessageEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-bsminfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BSMINFO
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public UINT cbSize;

        /// <summary>
        /// A desktop handle to the window specified by <see cref="hwnd"/>.
        /// This value is returned only if <see cref="BroadcastSystemMessageEx"/> specifies <see cref="BSF_RETURNHDESK"/> and <see cref="BSF_QUERY"/>.
        /// </summary>
        public HDESK hdesk;

        /// <summary>
        /// A handle to the window that denied the request.
        /// This value is returned if <see cref="BroadcastSystemMessageEx"/> specifies <see cref="BSF_QUERY"/>.
        /// </summary>
        public HWND hwnd;

        /// <summary>
        /// A locally unique identifier (LUID) for the window.
        /// </summary>
        public LUID luid;
    }
}
