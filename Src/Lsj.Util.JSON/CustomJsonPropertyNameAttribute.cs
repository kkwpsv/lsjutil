using System;

namespace Lsj.Util.JSON
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomJsonPropertyNameAttribute : Attribute
    {
        public string Name { get; set; }

        public CustomJsonPropertyNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}

