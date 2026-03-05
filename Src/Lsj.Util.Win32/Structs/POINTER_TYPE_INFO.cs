using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the pointer input type.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_type_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    public struct POINTER_TYPE_INFO
    {
        /// <summary>
        /// The pointer input device.
        /// </summary>
        [FieldOffset(0)]
        public POINTER_INPUT_TYPE type;

        /// <summary>
        /// 
        /// </summary>
        [FieldOffset(4)]
        public POINTER_INFO pointerInfo;

        /// <summary>
        /// A <see cref="POINTER_TOUCH_INFO"/> structure representing basic touch information common to all pointer types.
        /// </summary>
        [FieldOffset(4)]
        public POINTER_TOUCH_INFO touchInfo;

        /// <summary>
        /// A <see cref="POINTER_PEN_INFO"/> structure representing basic pen information common to all pointer types.
        /// </summary>
        [FieldOffset(4)]
        public POINTER_PEN_INFO penInfo;
    }
}
