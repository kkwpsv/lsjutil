using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains an exception record with a machine-independent description of an exception and a context record
    /// with a machine-dependent description of the processor context at the time of the exception.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-exception_pointers"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct EXCEPTION_POINTERS
    {
        /// <summary>
        /// A pointer to an <see cref="EXCEPTION_RECORD"/> structure that contains a machine-independent description of the exception.
        /// </summary>
        public IntPtr ExceptionRecord;

        /// <summary>
        /// A pointer to a <see cref="CONTEXT"/> structure that contains a processor-specific description
        /// of the state of the processor at the time of the exception.
        /// </summary>
        public IntPtr ContextRecord;
    }
}
