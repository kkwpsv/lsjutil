using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Constants
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// MAX_PATH
        /// </summary>
        public const int MAX_PATH = 260;

        /// <summary>
        /// AccessSystemAcl access type
        /// </summary>
        public const uint ACCESS_SYSTEM_SECURITY = 0x01000000;

        /// <summary>
        /// MaximumAllowed access type
        /// </summary>
        public const uint MAXIMUM_ALLOWED = 0x02000000;
    }
}
