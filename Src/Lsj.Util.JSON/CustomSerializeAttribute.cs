using System;

namespace Lsj.Util.JSON
{
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

