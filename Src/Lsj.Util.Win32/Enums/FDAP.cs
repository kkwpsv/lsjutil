using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies list placement.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/ne-shobjidl_core-fdap"/>
    /// </para>
    /// </summary>
    public enum FDAP
    {
        /// <summary>
        /// The place is added to the bottom of the default list.
        /// </summary>
        FDAP_BOTTOM = 0,

        /// <summary>
        /// The place is added to the top of the default list.
        /// </summary>
        FDAP_TOP = 1,
    }
}
