using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Owner draw actions
    /// </summary>
    [Flags]
    public enum OwnerDrawActions : uint
    {
        /// <summary>
        /// ODA_DRAWENTIRE
        /// </summary>
        ODA_DRAWENTIRE = 0x0001,

        /// <summary>
        /// ODA_FOCUS
        /// </summary>
        ODA_FOCUS = 0x0002,

        /// <summary>
        /// ODA_SELECT
        /// </summary>
        ODA_SELECT = 0x0004,
    }
}
