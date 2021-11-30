using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Message;
using System.IO;

namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// HttpMessage
    /// </summary>
    public interface IHttpMessage
    {
        /// <summary>
        /// Headers
        /// </summary>
        HttpHeaderDictionary Headers
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
        /// Content
        /// </summary>
        Stream Content
        {
            get;
        }

        /// <summary>
        /// Cookies
        /// </summary>
        HttpCookies Cookies
        {
            get;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, out int read);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, int offset, out int read);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, int offset, int length, out int read);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        void WriteContent(byte[] buffer);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="str"></param>
        void WriteContent(string str);

        /// <summary>
        /// Get Http1.x Header String
        /// </summary>
        /// <returns></returns>
        string GetHttp1HeaderString();

        /// <summary>
        /// IsError
        /// </summary>
        bool IsError
        {
            get;
        }
    }
}
