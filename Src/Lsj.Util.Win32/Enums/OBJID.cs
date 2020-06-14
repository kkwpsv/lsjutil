using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// This topic describes the Microsoft Active Accessibility object identifiers,
    /// 32-bit values that identify categories of accessible objects within a window.
    /// Microsoft Active Accessibility servers and Microsoft UI Automation providers use the object identifiers
    /// to determine the object to which a <see cref="WM_GETOBJECT"/> message request refers.
    /// Clients receive these values in their WinEventProc callback function and use them to identify parts of a window.
    /// Servers use these values to identify the corresponding parts of a window when calling <see cref="NotifyWinEvent"/>
    /// or when responding to the <see cref="WM_GETOBJECT"/> message.
    /// Servers can define custom object IDs to identify other categories of objects within their applications.
    /// Custom object IDs must be assigned positive values because Microsoft Active Accessibility reserves zero
    /// and all negative values for the following standard object identifiers.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winauto/object-identifiers
    /// </para>
    /// </summary>
    public enum OBJID
    {
        /// <summary>
        /// The window itself rather than a child object.
        /// </summary>
        OBJID_WINDOW = 0x00000000,

        /// <summary>
        /// The window's system menu.
        /// </summary>
        OBJID_SYSMENU = unchecked((int)0xFFFFFFFF),

        /// <summary>
        /// The window's title bar.
        /// </summary>
        OBJID_TITLEBAR = unchecked((int)0xFFFFFFFE),

        /// <summary>
        /// The window's menu bar.
        /// </summary>
        OBJID_MENU = unchecked((int)0xFFFFFFFD),

        /// <summary>
        /// The window's client area.
        /// In most cases, the operating system controls the frame elements and the client object
        /// contains all elements that are controlled by the application.
        /// Servers only process the <see cref="WM_GETOBJECT"/> messages in which the lParam
        /// is <see cref="OBJID_CLIENT"/>, <see cref="OBJID_WINDOW"/>, or a custom object identifier.
        /// </summary>
        OBJID_CLIENT = unchecked((int)0xFFFFFFFC),

        /// <summary>
        /// The window's vertical scroll bar.
        /// </summary>
        OBJID_VSCROLL = unchecked((int)0xFFFFFFFB),

        /// <summary>
        /// The window's horizontal scroll bar.
        /// </summary>
        OBJID_HSCROLL = unchecked((int)0xFFFFFFFA),

        /// <summary>
        /// The window's size grip: an optional frame component located at the lower-right corner of the window frame.
        /// </summary>
        OBJID_SIZEGRIP = unchecked((int)0xFFFFFFF9),

        /// <summary>
        /// The text insertion bar (caret) in the window.
        /// </summary>
        OBJID_CARET = unchecked((int)0xFFFFFFF8),

        /// <summary>
        /// The mouse pointer. There is only one mouse pointer in the system, and it is not a child of any window.
        /// </summary>
        OBJID_CURSOR = unchecked((int)0xFFFFFFF7),

        /// <summary>
        /// An alert that is associated with a window or an application.
        /// System provided message boxes are the only UI elements that send events with this object identifier.
        /// Server applications cannot use the AccessibleObjectFromX functions with this object identifier.
        /// This is a known issue with Microsoft Active Accessibility.
        /// </summary>
        OBJID_ALERT = unchecked((int)0xFFFFFFF6),

        /// <summary>
        /// A sound object. Sound objects do not have screen locations or children, but they do have name and state attributes.
        /// They are children of the application that is playing the sound.
        /// </summary>
        OBJID_SOUND = unchecked((int)0xFFFFFFF5),

        /// <summary>
        /// An object identifier that Oleacc.dll uses internally.
        /// For more information, see Appendix F: Object Identifier Values for <see cref="OBJID_QUERYCLASSNAMEIDX"/>.
        /// </summary>
        OBJID_QUERYCLASSNAMEIDX = unchecked((int)0xFFFFFFF4),

        /// <summary>
        /// In response to this object identifier, third-party applications can expose their own object model.
        /// Third-party applications can return any COM interface in response to this object identifier.
        /// </summary>
        OBJID_NATIVEOM = unchecked((int)0xFFFFFFF0),
    }
}
