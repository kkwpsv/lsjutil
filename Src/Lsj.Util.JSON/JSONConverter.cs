using Lsj.Util.Dynamic;
using Lsj.Util.Reflection;
using Lsj.Util.Text;
using System;
using System.Collections;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Converter
    /// </summary>
    public static class JSONConverter
    {
        /// <summary>
        /// Convert Enum To String Or Int (Default String)
        /// </summary>
        public static bool ConvertEnumToStringOrInt
        {
            get;
            set;
        } = true;


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
        public static string ConvertToJSONString(Enum val) => ConvertEnumToStringOrInt ? $@"""{val.ToString()}""" : ((int)(object)val).ToString();
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
                bool flag = false;

                if (val is IEnumerable e)
                {
                    if (val.IsDictionary())
                    {
                        symbol = '{';
                        result.Append(symbol);
                        foreach (dynamic a in e)
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
                        symbol = '[';
                        result.Append(symbol);
                        foreach (var value in e)
                        {
                            flag = true;
                            result.Append(ConvertToJSONString(value) + ",");
                        }
                        if (flag)
                        {
                            result.RemoveLastOne();
                        }
                    }
                }
                else
                {
                    symbol = '{';
                    result.Append(symbol);
                    if (val is DynamicObject dynamicObject)
                    {
                        var properties = dynamicObject.GetDynamicMemberNames();
                        foreach (var property in properties)
                        {
                            flag = true;
                            var value = dynamicObject.GetMember(property);
                            result.Append($@"""{property}"":{ConvertToJSONString(value)},");
                        }
                        if (flag)
                        {
                            result.RemoveLastOne();
                        }
                    }
                    else
                    {
                        var notSerializeProperties = val.GetType().GetAttribute<NotSerializePropertyAttribute>()?.Properties;
                        var properties = val.GetType().GetProperties().
                            Where(x => !x.HasAttribute<NotSerializeAttribute>() && !x.GetIndexParameters().Any() &&
                            (notSerializeProperties == null || !notSerializeProperties.Contains(x.Name)));
                        foreach (var property in properties)
                        {
                            flag = true;
                            var name = property.Name;
                            var attr = property.GetAttribute<CustomJsonPropertyNameAttribute>();
                            if (attr != null)
                            {
                                name = attr.Name;
                            }
                            string value = "";
                            var customSerializeAttribute = property.GetAttribute<CustomSerializeAttribute>();
                            if (customSerializeAttribute != null)
                            {
                                if (Activator.CreateInstance(customSerializeAttribute.Serializer) is ISerializer serializer)
                                {
                                    value = ConvertToJSONString(serializer.Convert(property.GetValue(val, null)));
                                }
                                else
                                {
                                    throw new Exception("Custom Serializer Must Implement ISerializer");
                                }
                            }
                            else
                            {
                                value = ConvertToJSONString(property.GetValue(val, null));
                            }
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
