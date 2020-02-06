using System;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// Not Serialize Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NotSerializeAttribute : Attribute
    {
    }
}
