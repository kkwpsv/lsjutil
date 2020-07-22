namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies the destination context, which is the process in which the unmarshaling is to be done.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wtypesbase/ne-wtypesbase-mshctx
    /// </para>
    /// </summary>
    public enum MSHCTX : uint
    {
        /// <summary>
        /// The unmarshaling process is local and has shared memory access with the marshaling process.
        /// </summary>
        MSHCTX_LOCAL = 0,

        /// <summary>
        /// The unmarshaling process does not have shared memory access with the marshaling process.
        /// </summary>
        MSHCTX_NOSHAREDMEM = 1,

        /// <summary>
        /// The unmarshaling process is on a different computer.
        /// The marshaling code cannot assume that a particular piece of application code is installed on that computer.
        /// </summary>
        MSHCTX_DIFFERENTMACHINE = 2,

        /// <summary>
        /// The unmarshaling will be done in another apartment in the same process.
        /// </summary>
        MSHCTX_INPROC = 3,

        /// <summary>
        /// Create a new context in the current apartment.
        /// </summary>
        MSHCTX_CROSSCTX = 4,

        /// <summary>
        /// 
        /// </summary>
        MSHCTX_RESERVED1 = 5
    }
}
