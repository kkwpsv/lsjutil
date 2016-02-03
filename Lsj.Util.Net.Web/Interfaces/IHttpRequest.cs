using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Interfaces
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
        /// ErrorCode
        /// </summary>
        int ErrorCode
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
        /// IsError
        /// </summary>
        bool IsError
        {
            get;
        }
    }
}
