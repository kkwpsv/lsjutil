using System;

namespace Lsj.Util.JSON
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomSerializeAttribute : Attribute
    {
        public Type Serializer { get; set; }
        public Type SourceType { get; set; }

        public CustomSerializeAttribute()
        {
        }
    }
    public interface ISerializer
    {
        object Convert(object obj);
        object Parse(object str);
    }
}

