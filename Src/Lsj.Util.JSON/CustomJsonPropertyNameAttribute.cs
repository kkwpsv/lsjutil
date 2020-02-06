using System;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// Custom Json Property Name Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomJsonPropertyNameAttribute : Attribute
    {
        /// <summary>
        /// Json Property Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public CustomJsonPropertyNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}

