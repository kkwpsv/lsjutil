using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Protocol;


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
