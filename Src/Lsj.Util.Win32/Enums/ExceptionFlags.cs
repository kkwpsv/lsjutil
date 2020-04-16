using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// Exception Flags
    /// </summary>
    [Flags]
    public enum ExceptionFlags : uint
    {
        /// <summary>
        /// EXCEPTION_NONCONTINUABLE
        /// </summary>
        EXCEPTION_NONCONTINUABLE = 0x1,

        /// <summary>
        /// EXCEPTION_UNWINDING
        /// </summary>
        EXCEPTION_UNWINDING = 0x2,

        /// <summary>
        /// EXCEPTION_EXIT_UNWIND
        /// </summary>
        EXCEPTION_EXIT_UNWIND = 0x4,

        /// <summary>
        /// EXCEPTION_STACK_INVALID
        /// </summary>
        EXCEPTION_STACK_INVALID = 0x8,

        /// <summary>
        /// EXCEPTION_NESTED_CALL
        /// </summary>
        EXCEPTION_NESTED_CALL = 0x10,

        /// <summary>
        /// EXCEPTION_TARGET_UNWIND
        /// </summary>
        EXCEPTION_TARGET_UNWIND = 0x20,

        /// <summary>
        /// EXCEPTION_COLLIDED_UNWIND
        /// </summary>
        EXCEPTION_COLLIDED_UNWIND = 0x40,
    }
}
