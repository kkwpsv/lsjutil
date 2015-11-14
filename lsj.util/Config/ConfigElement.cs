using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{
    public class ConfigElement
    {
        string value;
        public ConfigElement(string value)
        {
            this.value = value;
        }
        public static implicit operator string (ConfigElement x)
        {
            return x.value;
        }
        public static implicit operator ConfigElement(string x)
        {
            return new ConfigElement(x);
        }
        public static implicit operator int (ConfigElement x)
        {
            return x.value.ConvertToInt(0);
        }
    }
}
