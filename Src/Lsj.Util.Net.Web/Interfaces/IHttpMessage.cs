using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Lsj.Util.Net.Web.Cookie;
using Lsj.Util.Net.Web.Message;

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
        HttpHeaders Headers
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
        bool Read(byte[] buffer, ref int read);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, int offset, ref int read);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        bool Read(byte[] buffer, int offset, int length, ref int read);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="buffer"></param>
        void Write(byte[] buffer);

        /// <summary>
        /// Write
        /// </summary>
        /// <param name="str"></param>
        void Write(string str);

        /// <summary>
        /// GetHttpHeader
        /// </summary>
        /// <returns></returns>
        string GetHttpHeader();

        /// <summary>
        /// IsError
        /// </summary>
        bool IsError
        {
            get;
        }
    }
}
