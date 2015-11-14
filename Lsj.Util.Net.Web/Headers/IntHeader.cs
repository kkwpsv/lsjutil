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
        } = 0;
        public IntHeader(string content) : base(content)
        {
            value = content.Trim().ConvertToInt(0);
            Content = value.ToString();
        }
        public IntHeader(int value)
        {
            value = value;
            Content = value.ToString();
        }
        public static implicit operator int(IntHeader x)
        {
            return x.value;
        }
    }
}
