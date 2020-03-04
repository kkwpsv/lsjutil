using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// Not Serialize Property Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class NotSerializePropertyAttribute : Attribute
    {
        /// <summary>
        /// Properties Name
        /// </summary>
        public List<string> Properties { get; set; }
    }
}
