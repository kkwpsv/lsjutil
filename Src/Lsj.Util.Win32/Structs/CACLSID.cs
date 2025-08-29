using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct CACLSID
    {
        /// <summary>
        /// 
        /// </summary>
        public ULONG cElems;

        /// <summary>
        /// 
        /// </summary>
        public P<CLSID> pElems;
    }
}
