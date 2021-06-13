using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Owner draw actions
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-drawitemstruct"/>
    /// </para>
    /// </summary>
    [Flags]
    public enum OwnerDrawActions : uint
    {
        /// <summary>
        /// The entire control needs to be drawn.
        /// </summary>
        ODA_DRAWENTIRE = 0x0001,

        /// <summary>
        /// The control has lost or gained the keyboard focus. The itemState member should be checked to determine whether the control has the focus.
        /// </summary>
        ODA_FOCUS = 0x0002,

        /// <summary>
        /// The selection status has changed. The itemState member should be checked to determine the new selection state.
        /// </summary>
        ODA_SELECT = 0x0004,
    }
}
