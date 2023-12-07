using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains cursor ID mappings for pointer devices.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_device_cursor_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct POINTER_DEVICE_CURSOR_INFO
    {
        /// <summary>
        /// The assigned cursor ID.
        /// </summary>
        public UINT32 cursorId;

        /// <summary>
        /// The <see cref="POINTER_DEVICE_CURSOR_TYPE"/> that the ID is mapped to.
        /// </summary>
        public POINTER_DEVICE_CURSOR_TYPE cursor;
    }
}
