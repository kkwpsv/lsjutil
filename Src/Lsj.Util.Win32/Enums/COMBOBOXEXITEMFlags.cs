using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Enums.ComboBoxExNotifications;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="COMBOBOXEXITEM"/> Flags
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/commctrl/ns-commctrl-comboboxexitemw"/> 
    /// </para>
    /// </summary>
    public enum COMBOBOXEXITEMFlags : uint
    {
        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.pszText"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_TEXT = 0x00000001,

        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.iImage"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_IMAGE = 0x00000002,

        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.iSelectedImage"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_SELECTEDIMAGE = 0x00000004,

        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.iOverlay"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_OVERLAY = 0x00000008,

        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.iIndent"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_INDENT = 0x00000010,

        /// <summary>
        /// The <see cref="COMBOBOXEXITEM.lParam"/> member is valid or must be filled in.
        /// </summary>
        CBEIF_LPARAM = 0x00000020,

        /// <summary>
        /// Set this flag when processing <see cref="CBEN_GETDISPINFO"/>;
        /// the ComboBoxEx control will retain the supplied information and will not request it again.
        /// </summary>
        CBEIF_DI_SETITEM = 0x10000000,
    }
}
