using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Owner draw states
    /// </summary>
    [Flags]
    public enum OwnerDrawStates : uint
    {
        /// <summary>
        /// ODS_CHECKED
        /// </summary>
        ODS_CHECKED = 0x0008,

        /// <summary>
        /// ODS_COMBOBOXEDIT
        /// </summary>
        ODS_COMBOBOXEDIT = 0x1000,

        /// <summary>
        /// ODS_DEFAULT
        /// </summary>
        ODS_DEFAULT = 0x0020,

        /// <summary>
        /// ODS_DISABLED
        /// </summary>
        ODS_DISABLED = 0x0004,

        /// <summary>
        /// ODS_FOUCUS
        /// </summary>
        ODS_FOUCUS = 0x0010,

        /// <summary>
        /// ODS_GRAYED
        /// </summary>
        ODS_GRAYED = 0x0002,

        /// <summary>
        /// ODS_HOTLIGHT
        /// </summary>
        ODS_HOTLIGHT = 0x0040,

        /// <summary>
        /// ODS_INACTIVE
        /// </summary>
        ODS_INACTIVE = 0x0080,

        /// <summary>
        /// ODS_NOACCEL
        /// </summary>
        ODS_NOACCEL = 0x0100,

        /// <summary>
        /// ODS_NOFOCUSRECT
        /// </summary>
        ODS_NOFOCUSRECT = 0x0200,

        /// <summary>
        /// ODS_SELECTED
        /// </summary>
        ODS_SELECTED = 0x0001,
    }
}
