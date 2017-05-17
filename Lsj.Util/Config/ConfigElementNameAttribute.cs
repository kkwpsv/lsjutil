using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Config
#else
namespace Lsj.Util.Config
#endif
{
    /// <summary>
    /// ConfigElementNameAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class ConfigElementNameAttribute : Attribute
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
