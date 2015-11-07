using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Headers
{
    public class DateTimeHeader:RawHeader,IHeader
    {
        public DateTime value
        {
            private set;
            get;
        }
        public DateTimeHeader(string name, string content) : base(name, content)
        {
            value = content.ConvertToDateTime("r");
        }
        public DateTimeHeader(string name) : this(name, "")
        {
        }
    }
}
