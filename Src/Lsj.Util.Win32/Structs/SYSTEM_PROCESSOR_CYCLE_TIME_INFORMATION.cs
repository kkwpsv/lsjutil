using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION
    {
        /// <summary>
        /// 
        /// </summary>
        public DWORD64 CycleTime;
    }
}
