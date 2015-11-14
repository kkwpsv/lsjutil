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
        public DateTimeHeader(string content) : base(content)
        {
            value = content.ConvertToDateTime("r");
            Content = value.ToString("r");
        }
    }
}
