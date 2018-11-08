using System;

namespace Lsj.Util.JSON
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomSerializeAttribute : Attribute
    {
        public Type Serializer { get; set; }

        public CustomSerializeAttribute()
        {
        }
    }
    public interface ISerializer
    {
        string Convert(object obj);
        object Parse(string str);
    }
}

