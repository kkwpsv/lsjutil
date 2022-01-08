using Lsj.Util.Win32.Callbacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="LPPROGRESS_ROUTINE"/> Results
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nc-winbase-lpprogress_routine"/>
    /// </para>
    /// </summary>
    public enum LPPROGRESS_ROUTINEResults : uint
    {
        /// <summary>
        /// Continue the copy operation.
        /// </summary>
        PROGRESS_CONTINUE = 0,

        /// <summary>
        /// Cancel the copy operation and delete the destination file.
        /// </summary>
        PROGRESS_CANCEL = 1,

        /// <summary>
        /// Stop the copy operation. It can be restarted at a later time.
        /// </summary>
        PROGRESS_STOP = 2,

        /// <summary>
        /// Continue the copy operation, but stop invoking CopyProgressRoutine to report progress.
        /// </summary>
        PROGRESS_QUIET = 3,
    }
}
