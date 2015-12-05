using Lsj.Util.Net.Web.Cookie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public interface IHttpMessage
    {
        HttpCookies Cookies
        {
            get;
        }
        void Read(byte[] buffer);
        string GetHeader();
        byte[] GetAll();
        void Write(byte[] bytes);
       

    }
}
