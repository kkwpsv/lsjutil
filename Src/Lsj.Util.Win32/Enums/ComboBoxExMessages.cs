using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.ComboBoxControlMessages;
using static Lsj.Util.Win32.Enums.COMBOBOXEXITEMFlags;
using static Lsj.Util.Win32.Enums.ComboBoxExNotifications;
using static Lsj.Util.Win32.Enums.ComboBoxExStyles;
using static Lsj.Util.Win32.Enums.ComboBoxStyles;
using static Lsj.Util.Win32.Enums.ControlMessages;
using static Lsj.Util.Win32.Enums.WindowsMessages;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// ComboBoxEx Messages
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/controls/bumper-comboboxex-control-reference-messages"/>
    /// </para>
    /// </summary>
    public enum ComboBoxExMessages : uint
    {
        /// <summary>
        /// Removes an item from a ComboBoxEx control.
        /// </summary>
        /// <remarks>
        /// This message maps to the combo box control message <see cref="CB_DELETESTRING"/>.
        /// </remarks>
        CBEM_DELETEITEM = CB_DELETESTRING,

        /// <summary>
        /// Gets the handle to the child combo box control.
        /// </summary>
        CBEM_GETCOMBOCONTROL = (WM_USER + 6),

        /// <summary>
        /// Gets the handle to the edit control portion of a ComboBoxEx control.
        /// A ComboBoxEx control uses an edit box when it is set to the <see cref="CBS_DROPDOWN"/> style.
        /// </summary>
        CBEM_GETEDITCONTROL = (WM_USER + 7),

        /// <summary>
        /// Gets the extended styles that are in use for a ComboBoxEx control.
        /// </summary>
        CBEM_GETEXTENDEDSTYLE = (WM_USER + 9),

        /// <summary>
        /// Gets the handle to an image list assigned to a ComboBoxEx control.
        /// </summary>
        CBEM_GETIMAGELIST = (WM_USER + 3),

        /// <summary>
        /// Gets item information for a given ComboBoxEx item.
        /// </summary>
        /// <remarks>
        /// When the message is sent, the <see cref="iItem"/> and mask members of the structure must be set
        /// to indicate the index of the target item and the type of information to be retrieved.
        /// Other members are set as needed.
        /// For example, to retrieve text, you must set the <see cref="CBEIF_TEXT"/> flag in mask, and assign a value to <see cref="COMBOBOXEXITEM.cchTextMax"/>.
        /// Setting the iItem member to -1 will retrieve the item displayed in the edit control.
        /// If the <see cref="CBEIF_TEXT"/> flag is set in the mask member of the <see cref="COMBOBOXEXITEM"/> structure,
        /// the control may change the <see cref="COMBOBOXEXITEM.pszText"/> member of the structure to point to the new text instead of filling the buffer with the requested text.
        /// Applications should not assume that the text will always be placed in the requested buffer.
        /// </remarks>
        CBEM_GETITEM = (WM_USER + 13),

        /// <summary>
        /// Gets the UNICODE character format flag for the control.
        /// </summary>
        /// <remarks>
        /// See the remarks for <see cref="CCM_GETUNICODEFORMAT"/> for a discussion of this message.
        /// </remarks>
        CBEM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,

        /// <summary>
        /// Determines whether the user has changed the text of a ComboBoxEx edit control.
        /// </summary>
        /// <remarks>
        /// A ComboBoxEx control uses an edit box control when it is set to the <see cref="CBS_DROPDOWN"/> style.
        /// You can retrieve the edit box control's window handle by sending a <see cref="CBEM_GETEDITCONTROL"/> message.
        /// When the user begins editing, you will receive a <see cref="CBEN_BEGINEDIT"/> notification.
        /// When editing is complete, or the focus changes, you will receive a <see cref="CBEN_ENDEDIT"/> notification.
        /// The <see cref="CBEM_HASEDITCHANGED"/> message is only useful for determining whether the text has been changed
        /// if it is sent before the <see cref="CBEN_ENDEDIT"/> notification.
        /// If the message is sent afterward, it will return <see cref="FALSE"/>.
        /// For example, suppose the user starts to edit the text in the edit box but changes focus, generating a <see cref="CBEN_ENDEDIT"/> notification.
        /// If you then send a <see cref="CBEM_HASEDITCHANGED"/> message, it will return FALSE, even though the text has been changed.
        /// The <see cref="CBS_SIMPLE"/> style does not work correctly with <see cref="CBEM_HASEDITCHANGED"/>.
        /// </remarks>
        CBEM_HASEDITCHANGED = (WM_USER + 10),

        /// <summary>
        /// Inserts a new item in a ComboBoxEx control.
        /// </summary>
        CBEM_INSERTITEMW = (WM_USER + 11),

        /// <summary>
        /// Sets extended styles within a ComboBoxEx control.
        /// </summary>
        /// <remarks>
        /// wParam enables you to modify one or more extended styles without having to retrieve the existing styles first.
        /// For example, if you pass <see cref="CBES_EX_NOEDITIMAGE"/> for wParam and 0 for lParam,
        /// the <see cref="CBES_EX_NOEDITIMAGE"/> style will be cleared, but all other styles will remain the same.
        /// If you try to set an extended style for a ComboBoxEx control created with the <see cref="CBS_SIMPLE"/> style, it may not repaint properly.
        /// </remarks>
        CBEM_SETEXTENDEDSTYLE = (WM_USER + 14),

        /// <summary>
        /// Sets an image list for a ComboBoxEx control.
        /// </summary>
        /// <remarks>
        /// The height of images in your image list might change the size requirements of the ComboBoxEx control.
        /// It is recommended that you resize the control after sending this message to ensure that it is displayed properly.
        /// </remarks>
        CBEM_SETIMAGELIST = (WM_USER + 2),

        /// <summary>
        /// Sets the attributes for an item in a ComboBoxEx control.
        /// </summary>
        CBEM_SETITEM = (WM_USER + 12),

        /// <summary>
        /// Sets the UNICODE character format flag for the control.
        /// This message enables you to change the character set used by the control at run time rather than having to re-create the control.
        /// </summary>
        /// <remarks>
        /// See the remarks for <see cref="CCM_SETUNICODEFORMAT"/> for a discussion of this message.
        /// </remarks>
        CBEM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,

        /// <summary>
        /// Sets the visual style of a ComboBoxEx control.
        /// </summary>
        /// <remarks>
        /// To use this message, you must provide a manifest specifying Comclt32 version 6.0.
        /// For more information on manifests, see Enabling Visual Styles.
        /// </remarks>
        CBEM_SETWINDOWTHEME = CCM_SETWINDOWTHEME,
    }
}
