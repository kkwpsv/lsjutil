using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.MediaFoundation
{
    public static class Constants
    {
        /// <summary>
        /// MF_API_VERSION
        /// </summary>
        public const int MF_API_VERSION = 0x0070;

        /// <summary>
        /// MF_SDK_VERSION
        /// </summary>
        public const int MF_SDK_VERSION = 0x0002;

        /// <summary>
        /// MF_VERSION
        /// </summary>
        public const uint MF_VERSION = MF_SDK_VERSION << 16 | MF_API_VERSION;
    }
}
