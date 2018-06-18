using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lsj.Util.Config
{
    /// <summary>
    /// ConfigElement Name Attribute
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
