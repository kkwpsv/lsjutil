﻿using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains the specified value to which the end of the file should be set.
    /// Used for file handles.
    /// Use only when calling <see cref="SetFileInformationByHandle"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_end_of_file_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_END_OF_FILE_INFO
    {
        /// <summary>
        /// The specified value for the new end of the file.
        /// </summary>
        public LARGE_INTEGER EndOfFile;
    }
}
