using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains exception information that can be used by a debugger.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/minwinbase/ns-minwinbase-exception_debug_info
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXCEPTION_DEBUG_INFO
    {
        /// <summary>
        /// An <see cref="EXCEPTION_RECORD"/> structure with information specific to the exception.
        /// This includes the exception code, flags, address, a pointer to a related exception, extra parameters, and so on.
        /// </summary>
        public EXCEPTION_RECORD ExceptionRecord;

        /// <summary>
        /// A value that indicates whether the debugger has previously encountered the exception specified by the <see cref="ExceptionRecord"/> member.
        /// If the <see cref="dwFirstChance"/> member is nonzero, this is the first time the debugger has encountered the exception.
        /// Debuggers typically handle breakpoint and single-step exceptions when they are first encountered.
        /// If this member is zero, the debugger has previously encountered the exception.
        /// This occurs only if, during the search for structured exception handlers, either no handler was found or the exception was continued.
        /// </summary>
        public DWORD dwFirstChance;
    }
}
