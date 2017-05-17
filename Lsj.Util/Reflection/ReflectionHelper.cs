using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

#if NETCOREAPP1_1
using Lsj.Util.Core.Logs;
#else
using Lsj.Util.Logs;
#endif


#if NETCOREAPP1_1
namespace Lsj.Util.Core.Reflection
#else
namespace Lsj.Util.Reflection
#endif
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
        public static T GetAttribute<T>(this MemberInfo type) where T : Attribute
        {
            var x = type.GetCustomAttributes(typeof(T), true);
            return (T)x.FirstOrDefault();

        }
        /// <summary>
        /// Create Instance
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(this Type type, params object[] param)
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
