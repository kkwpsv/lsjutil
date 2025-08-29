using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CLIPDATA
    {
        /// <summary>
        /// 
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// 
        /// </summary>
        public LONG ulClipFmt;

        /// <summary>
        /// 
        /// </summary>
        public P<BYTE> pClipData;
    }
}
