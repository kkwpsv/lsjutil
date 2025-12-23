using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about the class, title, owner, location, and size of a multiple-document interface (MDI) child window.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mdicreatestructw"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// When the MDI client window creates an MDI child window by calling <see cref="CreateWindow"/>,
    /// the system sends a <see cref="WM_CREATE"/> message to the created window.
    /// The lParam member of the <see cref="WM_CREATE"/> message contains a pointer to a <see cref="CREATESTRUCT"/> structure.
    /// The <see cref="lParam"/> member of this structure contains a pointer to the <see cref="MDICREATESTRUCT"/> structure
    /// passed with the <see cref="WM_MDICREATE"/> message that created the MDI child window.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct MDICREATESTRUCT
    {
        /// <summary>
        /// The name of the window class of the MDI child window.
        /// The class name must have been registered by a previous call to the <see cref="RegisterClass"/> function.
        /// </summary>
        public IntPtr szClass;

        /// <summary>
        /// The title of the MDI child window. The system displays the title in the child window's title bar.
        /// </summary>
        public IntPtr szTitle;

        /// <summary>
        /// A handle to the instance of the application creating the MDI client window.
        /// </summary>
        public HANDLE hOwner;

        /// <summary>
        /// The initial horizontal position, in client coordinates, of the MDI child window.
        /// If this member is <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default horizontal position.
        /// </summary>
        public int x;

        /// <summary>
        /// The initial vertical position, in client coordinates, of the MDI child window.
        /// If this member is <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default vertical position.
        /// </summary>
        public int y;

        /// <summary>
        /// The initial width, in device units, of the MDI child window.
        /// If this member is <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default width.
        /// </summary>
        public int cx;

        /// <summary>
        /// The initial height, in device units, of the MDI child window.
        /// If this member is set to <see cref="CW_USEDEFAULT"/>, the MDI child window is assigned the default height.
        /// </summary>
        public int cy;

        /// <summary>
        /// <para>
        /// The style of the MDI child window.
        /// If the MDI client window was created with the <see cref="MDIS_ALLCHILDSTYLES"/> window style,
        /// this member can be any combination of the window styles listed in the Window Styles page.
        /// Otherwise, this member can be one or more of the following values.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_MINIMIZE"/>
        /// </para>
        /// <para>
        /// 0x20000000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that is initially minimized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_MAXIMIZE"/>
        /// </para>
        /// <para>
        /// 0x01000000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that is initially maximized.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_HSCROLL"/>
        /// </para>
        /// <para>
        /// 0x00100000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that has a horizontal scroll bar.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <para>
        /// <see cref="WS_VSCROLL"/>
        /// </para>
        /// <para>
        /// 0x00200000L
        /// </para>
        /// </term>
        /// <term>
        /// Creates an MDI child window that has a vertical scroll bar.
        /// </term>
        /// </item>
        /// </list>
        /// </summary>
        public WindowStyles style;

        /// <summary>
        /// An application-defined value.
        /// </summary>
        public LPARAM lParam;
    }
}
