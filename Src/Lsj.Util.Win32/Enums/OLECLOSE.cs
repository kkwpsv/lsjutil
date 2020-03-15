using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Indicates whether an object should be saved before closing.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/oleidl/ne-oleidl-oleclose
    /// </para>
    /// </summary>
    public enum OLECLOSE
    {
        /// <summary>
        /// The object should be saved if it is dirty.
        /// </summary>
        OLECLOSE_SAVEIFDIRTY = 0,

        /// <summary>
        /// The object should not be saved, even if it is dirty.
        /// This flag is typically used when an object is being deleted.
        /// </summary>
        OLECLOSE_NOSAVE = 1,

        /// <summary>
        /// If the object is dirty, the <see cref="IOleObject.Close"/> implementation should display a dialog box to let the end user
        /// determine whether to save the object.
        /// However, if the object is in the running state but its user interface is invisible, the end user should not be prompted,
        /// and the close should be handled as if <see cref="OLECLOSE_SAVEIFDIRTY"/> had been specified.
        /// </summary>
        OLECLOSE_PROMPTSAVE = 2
    }
}
