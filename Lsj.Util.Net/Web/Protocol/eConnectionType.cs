using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Protocol
#else
namespace Lsj.Util.Net.Web.Protocol
#endif
{
    /// <summary>
    /// ConnectionType
    /// </summary>
    public enum eConnectionType
    {
        /// <summary>
        /// Close
        /// </summary>
        Close,
        /// <summary>
        /// Keep-Alive
        /// </summary>
        KeepAlive
    }
}
