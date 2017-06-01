using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Protocol;
#else
using Lsj.Util.Net.Web.Protocol;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Interfaces
#else
namespace Lsj.Util.Net.Web.Interfaces
#endif
{
    /// <summary>
    /// Request
    /// </summary>
    public interface IHttpRequest : IHttpMessage
    {

        /// <summary>
        /// Method
        /// </summary>
        eHttpMethod Method
        {
            get;
        }
        /// <summary>
        /// Uri
        /// </summary>
        URI Uri
        {
            get;
        }


        /// <summary>
        /// ExtraErrorCode
        /// </summary>
        int ExtraErrorCode
        {
            get;
        }
        /// <summary>
        /// IsReadFinish
        /// </summary>
        bool IsReadFinish
        {
            get;
        }
        /// <summary>
        /// UserHostAddress
        /// </summary>
        string UserHostAddress
        {
            get;

        }
    }
}
