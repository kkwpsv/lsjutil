using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        /// Has Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this MemberInfo member) where T : Attribute => member.GetCustomAttributes(typeof(T), true).Any();

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
        /// Create Instance
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="param">param</param>
        /// <returns></returns>
        public static object CreateInstance(this Type type, params object[] param) => Activator.CreateInstance(type, param);

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
        /// Is IDictionary or IDictionary&lt;,&gt;
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns></returns>
        public static bool IsDictionary(this object obj) => IsDictionary(obj.GetType());

        /// <summary>
        /// Is IDictionary or IDictionary&lt;,&gt;
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static bool IsDictionary(this Type type) => type.GetInterfaces().Any(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>)) || x == typeof(IDictionary));

        /// <summary>
        /// Is IList or IList&lt;&gt;
        /// </summary>
        /// <param name="obj">obj</param>
        /// <returns></returns>
        public static bool IsList(this object obj) => IsList(obj.GetType());

        /// <summary>
        /// Is IList or IList&lt;&gt;
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static bool IsList(this Type type) => type.GetInterfaces().Any(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)) || x == typeof(IList));

        /// <summary>
        /// Create List Of Type
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static object CreateListOfType(this Type type) => Activator.CreateInstance(typeof(List<>).MakeGenericType(type));

        /// <summary>
        /// Create List Of Type
        /// </summary>
        ///<param name="typeKey"></param>
        ///<param name="typeValue"></param>
        /// <returns></returns>
        public static object CreateDictionaryOfType(this Type typeKey, Type typeValue) => Activator.CreateInstance(typeof(Dictionary<,>).MakeGenericType(typeKey, typeValue));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="genericTypeDefinition"></param>
        /// <returns></returns>
        public static Type GetGenericType(this Type type, Type genericTypeDefinition) => type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == genericTypeDefinition).FirstOrDefault();

#if NET40
        /// <summary>
        /// SetValue
        /// </summary>
        /// <param name="property"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetValue(this PropertyInfo property, object obj, object value) => property.SetValue(obj, value, null);
#endif
    }
}
