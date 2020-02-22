using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// FILTERKEYS
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILTERKEYS
    {
        /// <summary>
        /// cbSize
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// dwFlags
        /// </summary>
        public uint dwFlags;

        /// <summary>
        /// Acceptance Delay
        /// </summary>
        public uint iWaitMSec;

        /// <summary>
        /// Delay Until Repeat
        /// </summary>
        public uint iDelayMSec;

        /// <summary>
        /// Repeat Rate
        /// </summary>
        public uint iRepeatMSec;

        /// <summary>
        /// Debounce Time
        /// </summary>
        public uint iBounceMSec;
    }
}
