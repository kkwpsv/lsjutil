using Lsj.Util.Net.Web.Protocol;


namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpRequest
    /// </summary>
    public interface IHttpRequest : IHttpMessage
    {
        /// <summary>
        /// HttpVersion
        /// </summary>
        public Version HttpVersion
        {
            get;
        }

        /// <summary>
        /// Method
        /// </summary>
        HttpMethods Method
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

        /// <summary>
        /// ContentLength
        /// </summary>
        int ContentLength
        {
            get;
        }
    }
}
