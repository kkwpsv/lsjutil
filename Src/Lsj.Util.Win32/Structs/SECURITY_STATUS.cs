using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// SECURITY_STATUS
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SECURITY_STATUS
    {
        /// <summary>
        /// 
        /// </summary>
        public int Value;
    }
}
