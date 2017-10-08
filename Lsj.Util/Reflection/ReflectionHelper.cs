using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Lsj.Util.Logs;

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
        /// <param name="type">Type</param>
        public static FieldInfo[] GetAllNonPublicField(this Type type) => type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        /// <summary>
        /// Get Attribute
        /// </summary>
        /// <typeparam name="T">Attribute Type</typeparam>
        /// <param name="member">member</param>
        public static T GetAttribute<T>(this MemberInfo member) where T : Attribute
        {
            var x = member.GetCustomAttributes(typeof(T), true);
            return (T)x.FirstOrDefault();

        }
        /// <summary>
        /// Create Instance
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static T CreateInstance<T>(params object[] param) => CreateInstance<T>(typeof(T), param);
        /// <summary>
        /// Create Instance
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="type">type</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type, params object[] param)
        {
            if (typeof(T).IsAssignableFrom(type))
            {
                return (T)Activator.CreateInstance(type, param);
            }
            else
            {
                throw new InvalidCastException("Error Type");
            }
        }
        /// <summary>
        /// Get Type Name
        /// </summary>
        /// <param name="type"></param>
        public static string GetTypeName(this Type type)
        {
            if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(string))
            {
                return "string";
            }
            else
            {
                return type.Name;
            }
        }
        /// <summary>
        /// Create List Of Type
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static object CreateListOfType(this Type type)
        {
            return Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
        }
    }
}
