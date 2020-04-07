using static Lsj.Util.Win32.Enums.NTSTATUS;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// ExceptionCodes
    /// </summary>
    public enum ExceptionCodes : uint
    {
        /// <summary>
        /// EXCEPTION_ACCESS_VIOLATION
        /// </summary>
        EXCEPTION_ACCESS_VIOLATION = STATUS_ACCESS_VIOLATION,

        /// <summary>
        /// EXCEPTION_ARRAY_BOUNDS_EXCEEDED
        /// </summary>
        EXCEPTION_ARRAY_BOUNDS_EXCEEDED = STATUS_ARRAY_BOUNDS_EXCEEDED,

        /// <summary>
        /// EXCEPTION_BREAKPOINT
        /// </summary>
        EXCEPTION_BREAKPOINT = STATUS_BREAKPOINT,

        /// <summary>
        /// EXCEPTION_DATATYPE_MISALIGNMENT
        /// </summary>
        EXCEPTION_DATATYPE_MISALIGNMENT = STATUS_DATATYPE_MISALIGNMENT,

        /// <summary>
        /// EXCEPTION_FLT_DENORMAL_OPERAND
        /// </summary>
        EXCEPTION_FLT_DENORMAL_OPERAND = STATUS_FLOAT_DENORMAL_OPERAND,

        /// <summary>
        /// EXCEPTION_FLT_DIVIDE_BY_ZERO
        /// </summary>
        EXCEPTION_FLT_DIVIDE_BY_ZERO = STATUS_FLOAT_DIVIDE_BY_ZERO,

        /// <summary>
        /// EXCEPTION_FLT_INEXACT_RESULT
        /// </summary>
        EXCEPTION_FLT_INEXACT_RESULT = STATUS_FLOAT_INEXACT_RESULT,

        /// <summary>
        /// EXCEPTION_FLT_INVALID_OPERATION
        /// </summary>
        EXCEPTION_FLT_INVALID_OPERATION = STATUS_FLOAT_INVALID_OPERATION,

        /// <summary>
        /// EXCEPTION_FLT_OVERFLOW
        /// </summary>
        EXCEPTION_FLT_OVERFLOW = STATUS_FLOAT_OVERFLOW,

        /// <summary>
        /// EXCEPTION_FLT_STACK_CHECK
        /// </summary>
        EXCEPTION_FLT_STACK_CHECK = STATUS_FLOAT_STACK_CHECK,

        /// <summary>
        /// EXCEPTION_FLT_UNDERFLOW
        /// </summary>
        EXCEPTION_FLT_UNDERFLOW = STATUS_FLOAT_UNDERFLOW,

        /// <summary>
        /// EXCEPTION_ILLEGAL_INSTRUCTION
        /// </summary>
        EXCEPTION_ILLEGAL_INSTRUCTION = STATUS_ILLEGAL_INSTRUCTION,

        /// <summary>
        /// EXCEPTION_IN_PAGE_ERROR
        /// </summary>
        EXCEPTION_IN_PAGE_ERROR = STATUS_IN_PAGE_ERROR,

        /// <summary>
        /// EXCEPTION_INT_DIVIDE_BY_ZERO
        /// </summary>
        EXCEPTION_INT_DIVIDE_BY_ZERO = STATUS_INTEGER_DIVIDE_BY_ZERO,

        /// <summary>
        /// EXCEPTION_INT_OVERFLOW
        /// </summary>
        EXCEPTION_INT_OVERFLOW = STATUS_INTEGER_OVERFLOW,

        /// <summary>
        /// EXCEPTION_INVALID_DISPOSITION
        /// </summary>
        EXCEPTION_INVALID_DISPOSITION = STATUS_INVALID_DISPOSITION,

        /// <summary>
        /// EXCEPTION_NONCONTINUABLE_EXCEPTION
        /// </summary>
        EXCEPTION_NONCONTINUABLE_EXCEPTION = STATUS_NONCONTINUABLE_EXCEPTION,

        /// <summary>
        /// EXCEPTION_PRIV_INSTRUCTION
        /// </summary>
        EXCEPTION_PRIV_INSTRUCTION = STATUS_PRIVILEGED_INSTRUCTION,

        /// <summary>
        /// EXCEPTION_SINGLE_STEP
        /// </summary>
        EXCEPTION_SINGLE_STEP = STATUS_SINGLE_STEP,

        /// <summary>
        /// EXCEPTION_STACK_OVERFLOW
        /// </summary>
        EXCEPTION_STACK_OVERFLOW = STATUS_STACK_OVERFLOW,

        /// <summary>
        /// DBG_CONTROL_C
        /// </summary>
        DBG_CONTROL_C = 0x40010005,
    }
}
