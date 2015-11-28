using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ConfigElementNameAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}
