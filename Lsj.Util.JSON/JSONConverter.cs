using Lsj.Util.Text;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Lsj.Util.JSON
{
    public static class JSONConverter
    {
        public static string ConvertToJSONString(decimal val)
        {
            return val.ToString();
        }
        public static string ConvertToJSONString(bool val)
        {
            return val ? "true" : "false";
        }
        public static string ConvertToJSONString(string val)
        {
            return @"""" + val.Replace("\b", @"\b").Replace("\f", @"\f").Replace("\n", @"\n").Replace("\r", @"\r").Replace("\t", @"\t").Replace("\"", @"\""").Replace("\\", @"\\").Replace("/", @"\/") + @"""";
        }
        public static string ConvertToJSONString(object val)
        {
            if (val == null)
            {
                return "null";
            }
            else if (val is bool)
            {
                return ConvertToJSONString((bool)val);
            }
            else if (val is string)
            {
                return ConvertToJSONString((string)val);
            }
            else if (val.GetType().IsNumeric())
            {
                return ConvertToJSONString(Convert.ToDecimal(val));
            }
            else
            {
                var result = new StringBuilder();
                char symbol;
                if (val.GetType().GetInterfaces().Contains(typeof(IEnumerable)))
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
                    else
                    {
                        var properties = val.GetType().GetProperties();
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
