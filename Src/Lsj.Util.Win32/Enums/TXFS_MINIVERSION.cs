using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// TXFS_MINIVERSION
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-createfiletransactedw"/>
    /// </para>
    /// </summary>
    public enum TXFS_MINIVERSION : ushort
    {
        /// <summary>
        /// The view of the file as of its last commit.
        /// </summary>
        TXFS_MINIVERSION_COMMITTED_VIEW = 0x0000,

        /// <summary>
        /// The view of the file as it is being modified by the transaction.
        /// </summary>
        TXFS_MINIVERSION_DIRTY_VIEW = 0xFFFF,

        /// <summary>
        /// Either the committed or dirty view of the file, depending on the context.
        /// A transaction that is modifying the file gets the dirty view,
        /// while a transaction that is not modifying the file gets the committed view.
        /// </summary>
        TXFS_MINIVERSION_DEFAULT_VIEW = 0xFFFE,
    }
}
