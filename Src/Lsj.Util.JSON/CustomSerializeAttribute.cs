using System;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// Custom Seriailize Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomSerializeAttribute : Attribute
    {
        /// <summary>
        /// Serializer Type
        /// </summary>
        public Type Serializer { get; set; }
        /// <summary>
        /// Json Source Type
        /// </summary>
        public Type SourceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CustomSerializeAttribute()
        {
        }
    }

    /// <summary>
    /// ISerializer
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns></returns>
        object Convert(object obj);

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str">json str</param>
        /// <returns></returns>
        object Parse(object str);
    }
}

