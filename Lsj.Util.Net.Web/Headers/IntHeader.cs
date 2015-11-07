using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public class IntHeader : RawHeader, IHeader
    {
        public int value
        {
            private set;
            get;
        }
        public IntHeader(string name, string content) : base(name, content)
        {
            value = content.Trim().ConvertToInt(0);
        }
    }
}
