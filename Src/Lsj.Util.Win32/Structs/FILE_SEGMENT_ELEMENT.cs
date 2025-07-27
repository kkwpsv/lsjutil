using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Represents a segment of an I/O buffer for scatter/gather read/write actions.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-file_segment_element"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_SEGMENT_ELEMENT
    {
        /// <summary>
        /// <para>
        /// A pointer to the data for the scatter/gather read/write action.
        /// </para>
        /// <para>
        /// Assigning a pointer to the <see cref="Buffer"/> member will sign-extend the value if the code is compiled as 32-bits;
        /// this can break large-address aware applications running on systems configured with 4-Gigabyte Tuning or running under WOW64 on 64-bit Windows.
        /// Therefore, use the <see cref="PtrToPtr64"/> macro when assigning pointers to <see cref="Buffer"/>.
        /// </para>
        /// </summary>
        public PVOID64 Buffer;

        /// <summary>
        /// An integer representation of the <see cref="Buffer"/>.
        /// The system uses this member to validate that the buffer is properly aligned.
        /// Applications typically operate on the <see cref="Buffer"/> member.
        /// </summary>
        public ULONGLONG Alignment;
    }
}
