using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// FILE_SEGMENT_ELEMENT
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_SEGMENT_ELEMENT
    {
        /// <summary>
        /// 
        /// </summary>
        public PVOID64 Buffer;

        /// <summary>
        /// 
        /// </summary>
        public ULONGLONG Alignment;
    }
}
