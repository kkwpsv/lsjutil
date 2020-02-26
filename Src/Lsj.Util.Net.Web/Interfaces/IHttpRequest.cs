using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Protocol;


namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpRequest
    /// </summary>
    public interface IHttpRequest : IHttpMessage
    {
        /// <summary>
        /// Method
        /// </summary>
        HttpMethod Method
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
