using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Lsj.Util.Net.Socks5.Proxyer
{
    public interface IProxyer
    {
        IPAddress IP
        {
            get;
            set;
        }
        int Port
        {
            get;
            set;
        }
        void Start();
        void Handle(byte[] buffer, int offset, int count);
    }
}
