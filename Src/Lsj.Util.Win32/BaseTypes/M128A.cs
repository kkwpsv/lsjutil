using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// M128A 
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16, Pack = 16)]
    public struct M128A
    {
        /// <summary>
        /// Low
        /// </summary>
        [FieldOffset(0)]
        public ULONGLONG Low;

        /// <summary>
        /// High
        /// </summary>
        [FieldOffset(8)]
        public LONGLONG High;
    }
}
