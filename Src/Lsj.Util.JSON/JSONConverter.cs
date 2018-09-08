using Lsj.Util.Text;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Converter
    /// </summary>
    public static class JSONConverter
    {
        /// <summary>
        /// Convert to JSON String
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertToJSONString(decimal val) => val.ToString();
        /// <summary>
        /// Convert to JSON String
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertToJSONString(bool val) => val ? "true" : "false";
        /// <summary>
        /// Convert to JSON String
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertToJSONString(string val) => @"""" + val.Replace("\b", @"\b").Replace("\f", @"\f").Replace("\n", @"\n").Replace("\r", @"\r").Replace("\t", @"\t").Replace("\"", @"\""").Replace("\\", @"\\").Replace("/", @"\/") + @"""";
        /// <summary>
        /// Convert to JSON String
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertToJSONString(Enum val) => val.ToString();
        /// <summary>
        /// Convert to JSON String
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ConvertToJSONString(object val)
        {
            if (val == null)
            {
                return "null";
            }
            else if (val is bool b)
            {
                return ConvertToJSONString(b);
            }
            else if (val is string s)
            {
                return ConvertToJSONString(s);
            }
            else if (val is DateTime d)
            {
                return ConvertToJSONString(d.ToString(@"yyyy/MM/dd HH:mm:ss"));
            }
            else if (val.GetType().IsNumeric())
            {
                return ConvertToJSONString(Convert.ToDecimal(val));
            }
            else if (val.GetType().IsEnum)
            {
                return ConvertToJSONString((Enum)val);
            }
            else
            {
                var result = new StringBuilder();
                char symbol;
                bool isDic = false;


                if (val is IEnumerable && !(isDic = (val is IDictionary)) && !(isDic = (val.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>)))))
                {
                    symbol = '[';
                    result.Append(symbol);
                    bool flag = false;
                    foreach (var value in val as IEnumerable)
                    {
                        flag = true;
                        result.Append(ConvertToJSONString(value) + ",");
                    }
                    if (flag)
                    {
                        result.RemoveLastOne();
                    }

                }
                else
                {
                    symbol = '{';
                    result.Append(symbol);
                    bool flag = false;
                    if (val is DynamicObject)
                    {
                        var x = (val as DynamicObject);
                        var properties = x.GetDynamicMemberNames();
                        foreach (var property in properties)
                        {
                            flag = true;
                            var binder = Binder.GetMember(CSharpBinderFlags.None, property, typeof(JSONConverter), new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
                            var callSite = CallSite<Func<CallSite, object, object>>.Create(binder);
                            var value = callSite.Target(callSite, x);
                            result.Append($@"""{property}"":{ConvertToJSONString(value)},");
                        }
                        if (flag)
                        {
                            result.RemoveLastOne();
                        }
                    }
                    else if (isDic)
                    {
                        foreach (dynamic a in (IEnumerable)val)
                        {
                            flag = true;
                            result.Append($@"""{a.Key}"":{ConvertToJSONString(a.Value)},");
                        }
                        if (flag)
                        {
                            result.RemoveLastOne();
                        }
                    }
                    else
                    {
                        var properties = val.GetType().GetProperties().Where(x => !x.GetCustomAttributes(typeof(NotSerializeAttribute), true).Any());
                        foreach (var property in properties)
                        {
                            flag = true;
                            var name = property.Name;
                            var value = ConvertToJSONString(property.GetValue(val, null));
                            result.Append($@"""{name}"":{value},");
                        }
                        if (flag)
                        {
                            result.RemoveLastOne();
                        }
                    }
                }
                if (symbol == '{')
                {
                    result.Append('}');
                }
                else
                {
                    result.Append(']');
                }
                return result.ToString();
            }
        }
    }
}
