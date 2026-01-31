using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// DATETIME
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DATETIME
    {
        /// <summary>
        /// 
        /// </summary>
        public WORD year;

        /// <summary>
        /// 
        /// </summary>
        public WORD month;

        /// <summary>
        /// 
        /// </summary>
        public WORD day;

        /// <summary>
        /// 
        /// </summary>
        public WORD hour;

        /// <summary>
        /// 
        /// </summary>
        public WORD min;

        /// <summary>
        /// 
        /// </summary>
        public WORD sec;
    }
}
