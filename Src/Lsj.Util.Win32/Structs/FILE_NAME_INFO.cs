using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives the file name.
    /// Used for any handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-file_io_priority_hint_info"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// If the call to <see cref="GetFileInformationByHandleEx"/> fails with <see cref="ERROR_MORE_DATA"/>
    /// because there was not enough buffer space for the full length of the <see cref="FileName"/>
    /// then the <see cref="FileNameLength"/> field will contain the required length of the <see cref="FileName"/> in bytes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_NAME_INFO
    {
        /// <summary>
        /// The size of the <see cref="FileName"/> string, in bytes.
        /// </summary>
        public DWORD FileNameLength;

        /// <summary>
        /// The file name that is returned.
        /// </summary>
        public WCHAR FileName;
    }
}
