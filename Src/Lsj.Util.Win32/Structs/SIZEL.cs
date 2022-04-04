using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// SIZEL
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SIZEL
    {
        /// <summary>
        /// cx
        /// </summary>
        public LONG cx;

        /// <summary>
        /// cy
        /// </summary>
        public LONG cy;
    }
}
