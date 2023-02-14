using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the address, format, and length, in bytes, of a debugging string.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-output_debug_string_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OUTPUT_DEBUG_STRING_INFO
    {
        /// <summary>
        /// The debugging string in the calling process's address space.
        /// The debugger can use the <see cref="ReadProcessMemory"/> function to retrieve the value of the string.
        /// </summary>
        public IntPtr lpDebugStringData;

        /// <summary>
        /// The format of the debugging string.
        /// If this member is zero, the debugging string is ANSI; if it is nonzero, the string is Unicode.
        /// </summary>
        public WORD fUnicode;

        /// <summary>
        /// The lower 16 bits of the length of the string in bytes.
        /// As <see cref="nDebugStringLength"/> is of type <see cref="WORD"/>, this does not always contain the full length of the string in bytes.
        /// For example, if the original output string is longer than 65536 bytes,
        /// this field will contain a value that is less than the actual string length in bytes.
        /// </summary>
        public WORD nDebugStringLength;
    }
}
