using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public class ConnectionHeader : RawHeader,IHeader
    {
        public eConnectionType value
        {
            private set;
            get;
        }
        public ConnectionHeader(string name, string content) : base(name, content)
        {
            if (content.ToLower() == "keep-alive")
                value = eConnectionType.KeepAlive;
            else
                value = eConnectionType.Close;
        }
    }
}
