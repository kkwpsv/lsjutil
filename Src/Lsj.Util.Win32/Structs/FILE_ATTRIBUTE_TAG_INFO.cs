using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives the requested file attribute information.
    /// Used for any handles.
    /// Use only when calling <see cref="GetFileInformationByHandleEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-file_attribute_tag_info"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_ATTRIBUTE_TAG_INFO
    {
        /// <summary>
        /// The file attribute information.
        /// </summary>
        public DWORD FileAttributes;

        /// <summary>
        /// The reparse tag.
        /// </summary>
        public DWORD ReparseTag;
    }
}
