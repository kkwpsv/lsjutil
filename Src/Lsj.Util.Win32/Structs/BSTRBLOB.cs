using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct BSTRBLOB
    {
        /// <summary>
        /// 
        /// </summary>
        public ULONG cbSize;

        /// <summary>
        /// 
        /// </summary>
        public P<BYTE> pData;
    }
}
