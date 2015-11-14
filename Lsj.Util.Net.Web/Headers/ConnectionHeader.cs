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
        } = eConnectionType.Close;
        public ConnectionHeader(string content) : base(content)
        {
            if (content.ToLower() == "keep-alive")
                value = eConnectionType.KeepAlive;
            else
                value = eConnectionType.Close;
        }
        public ConnectionHeader(eConnectionType value)
        {
            this.value = value;

            if (value==eConnectionType.KeepAlive)
            {
                Content = "keep-alive";
            }
            else
            {
                Content = "close";
            }
        }
    }
}
