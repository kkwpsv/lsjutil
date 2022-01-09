using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// NEON128
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct NEON128
    {
        /// <summary>
        /// Low
        /// </summary>
        public ULONGLONG Low;

        /// <summary>
        /// High
        /// </summary>
        public LONGLONG High;
    }
}
