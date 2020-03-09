using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Used to determine how to compare two Shell items.
    /// <see cref="IShellItem.Compare"/> uses this enumerated type.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ne-shobjidl_core-_sichintf
    /// </para>
    /// </summary>
    public enum SICHINTF
    {
        /// <summary>
        /// This relates to the iOrder parameter of the <see cref="IShellItem.Compare"/> interface and indicates that the comparison
        /// is based on the display in a folder view.
        /// </summary>
        SICHINT_DISPLAY = 0,

        /// <summary>
        /// Exact comparison of two instances of a Shell item.
        /// </summary>
        SICHINT_ALLFIELDS = unchecked((int)0x80000000),

        /// <summary>
        /// This relates to the iOrder parameter of the <see cref="IShellItem.Compare"/> interface and indicates that the comparison
        /// is based on a canonical name.
        /// </summary>
        SICHINT_CANONICAL = 0x10000000,

        /// <summary>
        /// Windows 7 and later.
        /// If the Shell items are not the same, test the file system paths.
        /// </summary>
        SICHINT_TEST_FILESYSPATH_IF_NOT_EQUAL = 0x20000000,
    }
}
