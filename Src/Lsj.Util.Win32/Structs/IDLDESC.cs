using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// IDLDESC
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct IDLDESC
    {
        /// <summary>
        /// 
        /// </summary>
        public ULONG_PTR dwReserved;

        /// <summary>
        /// 
        /// </summary>
        public USHORT wIDLFlags;
    }
}
