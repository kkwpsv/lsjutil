using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates the moniker's class.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/objidl/ne-objidl-mksys
    /// </para>
    /// </summary>
    public enum MKSYS : uint
    {
        /// <summary>
        /// Indicates a custom moniker implementation.
        /// </summary>
        MKSYS_NONE = 0,

        /// <summary>
        /// Indicates the system's generic composite moniker class.
        /// </summary>
        MKSYS_GENERICCOMPOSITE = 1,

        /// <summary>
        /// Indicates the system's file moniker class.
        /// </summary>
        MKSYS_FILEMONIKER = 2,

        /// <summary>
        /// Indicates the system's anti-moniker class.
        /// </summary>
        MKSYS_ANTIMONIKER = 3,

        /// <summary>
        /// Indicates the system's item moniker class.
        /// </summary>
        MKSYS_ITEMMONIKER = 4,

        /// <summary>
        /// Indicates the system's pointer moniker class.
        /// </summary>
        MKSYS_POINTERMONIKER = 5,

        /// <summary>
        /// Indicates the system's class moniker class.
        /// </summary>
        MKSYS_CLASSMONIKER = 7,

        /// <summary>
        /// Indicates the system's OBJREF moniker class.
        /// </summary>
        MKSYS_OBJREFMONIKER = 8,

        /// <summary>
        /// Indicates the system's terminal server session moniker class.
        /// </summary>
        MKSYS_SESSIONMONIKER = 9,

        /// <summary>
        /// Indicates the system's elevation moniker class.
        /// </summary>
        MKSYS_LUAMONIKER = 10,
    }
}
