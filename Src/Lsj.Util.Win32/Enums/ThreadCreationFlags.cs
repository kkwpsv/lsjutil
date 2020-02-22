using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Thread Creation Flags
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/processthreadsapi/nf-processthreadsapi-createthread
    /// </para>
    /// </summary>
    public enum ThreadCreationFlags : uint
    {
        /// <summary>
        /// The thread is created in a suspended state, and does not run until the <see cref="ResumeThread"/> function is called.
        /// </summary>
        CREATE_SUSPENDED = 0x00000004,

        /// <summary>
        /// The dwStackSize parameter specifies the initial reserve size of the stack.
        /// If this flag is not specified, dwStackSize specifies the commit size.
        /// </summary>
        STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
    }
}
