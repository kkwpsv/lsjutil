using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.HeaderControlMessages;
using static Lsj.Util.Win32.Enums.HeaderControlNotifications;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="HDITEM"/> Masks
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/commctrl/ns-commctrl-hditemw"/>
    /// </para>
    /// </summary>
    public enum HDITEMMMasks : uint
    {
        /// <summary>
        /// The <see cref="HDITEM.hbm"/> member is valid.
        /// </summary>
        HDI_BITMAP = 0x0010,

        /// <summary>
        /// While handling the message <see cref="HDM_GETITEM"/>, the header control may not have all the values needed to complete the request.
        /// In this case, the control must call the application back for the values via the <see cref="HDN_GETDISPINFO"/> notification.
        /// If <see cref="HDI_DI_SETITEM"/> has been passed in the <see cref="HDM_GETITEM"/> message,
        /// the control will cache any values returned from <see cref="HDN_GETDISPINFO"/> (otherwise the values remain unset.)
        /// </summary>
        HDI_DI_SETITEM = 0x0040,

        /// <summary>
        /// The <see cref="HDITEM.fmt"/> member is valid.
        /// </summary>
        HDI_FORMAT = 0x0004,

        /// <summary>
        /// The <see cref="HDITEM.type"/> and <see cref="HDITEM.pvFilter"/> members are valid.
        /// This is used to filter out the values specified in the type member.
        /// </summary>
        HDI_FILTER = 0x0100,

        /// <summary>
        /// The same as <see cref="HDI_WIDTH"/>.
        /// </summary>
        HDI_HEIGHT = HDI_WIDTH,

        /// <summary>
        /// The <see cref="HDITEM.iImage"/> member is valid and specifies the image to be displayed with the item.
        /// </summary>
        HDI_IMAGE = 0x0020,

        /// <summary>
        /// The <see cref="HDITEM.lParam"/> member is valid.
        /// </summary>
        HDI_LPARAM = 0x0008,

        /// <summary>
        /// The <see cref="HDITEM.iOrder"/> member is valid and specifies the item's order value.
        /// </summary>
        HDI_ORDER = 0x0080,

        /// <summary>
        /// Version 6.00 and later.
        /// The <see cref="HDITEM.state"/> member is valid.
        /// </summary>
        HDI_STATE = 0x0200,

        /// <summary>
        /// The <see cref="HDITEM.pszText"/> and <see cref="HDITEM.cchTextMax"/> members are valid.
        /// </summary>
        HDI_TEXT = 0x0002,

        /// <summary>
        /// The <see cref="HDITEM.cxy"/> member is valid and specifies the item's width.
        /// </summary>
        HDI_WIDTH = 0x0001,
    }
}
