using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Interfaces
#else
namespace Lsj.Util.Net.Web.Interfaces
#endif
{
    /// <summary>
    /// HttpContext
    /// </summary>
    internal interface IContext
    {
        eContextStatus Status
        {
            get;
        }

        void Dispose();
        void Start();
    }
}
