using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web
{
    public interface IHttpMessage
    {
        void Read(byte[] buffer);
    }
}
