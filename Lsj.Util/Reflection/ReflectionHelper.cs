using Lsj.Util.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lsj.Util.Reflection
{
    /// <summary>
    /// Reflection Helper
    /// </summary>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Get All Non-Public Field
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static FieldInfo[] GetAllNonPublicField(this Type type) => type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this MemberInfo type)
        {
            if (typeof(T).BaseType==typeof(Attribute))
            {
                var x = type.GetCustomAttributes(typeof(T), true);
                return x.Length > 0 ? (T)x[0] : default(T);
            }
            else
            {
                LogProvider.Default.Error(typeof(T).Name+" is not a Attribute");
                return default(T);
            }
        }
        /// <summary>
        /// Create Instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type,params object[] param)
        {
            if (typeof(T).IsAssignableFrom(type))
            {
                return (T)Activator.CreateInstance(type, param);
            }
            else
            {
                LogProvider.Default.Error("Error Type");
                return default(T);
            }
        }
    }
}
