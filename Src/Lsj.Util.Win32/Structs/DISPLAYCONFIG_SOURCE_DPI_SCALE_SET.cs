using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// Undocument
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct DISPLAYCONFIG_SOURCE_DPI_SCALE_SET
    {
        /// <summary>
        /// 
        /// </summary>
        public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

        /// <summary>
        /// 
        /// </summary>
        public int scaleRel;
    }
}
