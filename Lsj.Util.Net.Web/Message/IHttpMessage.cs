using Lsj.Util.Net.Web.Cookie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Message
{
    public interface IHttpMessage
    {
        /// <summary>
        /// Cookies
        /// </summary>
        HttpCookies Cookies
        {
            get;
        }
        /// <summary>
        /// Header
        /// </summary>
        HttpHeaders Headers
        {
            get;
        }
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        unsafe void Read(byte* buffer,long length);
        /// <summary>
        /// Read
        /// </summary>
        /// <param name="buffer"></param>
        void Read(byte[] buffer);
        /// <summary>
        /// GetHeader
        /// </summary>
        /// <returns></returns>
        string GetHeader();
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        byte[] GetAll();
        /// <summary>
        /// WriteContent
        /// </summary>
        /// <param name="bytes"></param>
        void WriteContent(byte[] bytes);
       

    }
}
