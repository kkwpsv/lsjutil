using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Logs
#else
namespace Lsj.Util.Logs
#endif
{
    /// <summary>
    /// Log Type
    /// </summary>
    public enum eLogType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,
        /// <summary>
        /// Debug
        /// </summary>
        Debug,
        /// <summary>
        /// Info
        /// </summary>
        Info,
        /// <summary>
        /// Warn
        /// </summary>
        Warn,
        /// <summary>
        /// Error
        /// </summary>
        Error,
    }
}
