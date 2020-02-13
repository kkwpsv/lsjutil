using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the menu and first multiple-document interface (MDI) child window of an MDI client window.
    /// An application passes a pointer to this structure as the lpParam parameter of
    /// the <see cref="CreateWindow"/> function when creating an MDI client window.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-clientcreatestruct
    /// </para>
    /// </summary>
    /// <remarks>
    /// When the MDI client window is created by calling <see cref="CreateWindow"/>, the system sends
    /// a <see cref="WindowsMessages.WM_CREATE"/> message to the window.
    /// The lParam parameter of <see cref="WindowsMessages.WM_CREATE"/> contains a pointer to a <see cref="CREATESTRUCT"/> structure.
    /// The lpCreateParams member of this structure contains a pointer to a <see cref="CLIENTCREATESTRUCT"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CLIENTCREATESTRUCT
    {
        /// <summary>
        /// A handle to the MDI application's window menu.
        /// An MDI application can retrieve this handle from the menu of the MDI frame window by using the <see cref="GetSubMenu"/> function.
        /// </summary>
        public IntPtr hWindowMenu;

        /// <summary>
        /// The child window identifier of the first MDI child window created.
        /// The system increments the identifier for each additional MDI child window the application creates,
        /// and reassigns identifiers when the application destroys a window to keep the range of identifiers contiguous.
        /// These identifiers are used in <see cref="WindowsMessages.WM_COMMAND"/> messages sent to the application's MDI frame window
        /// when a child window is chosen from the window menu; they should not conflict with any other command identifiers.
        /// </summary>
        public uint idFirstChild;
    }
}
