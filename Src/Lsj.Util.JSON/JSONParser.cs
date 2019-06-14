using Lsj.Util.JSON.Processer;
using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Logs;
using Lsj.Util.Reflection;
using Lsj.Util.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Parser
    /// </summary>
    public static class JSONParser
    {
        /// <summary>
        /// LogProvider
        /// </summary>
        public static LogProvider LogProvider
        {
            get;
            set;
        } = LogProvider.Default;
        /// <summary>
        /// Is Strict
        /// </summary>
        public static bool IsStrict
        {
            get;
            set;
        }
        /// <summary>
        /// Max Recursion Layer
        /// </summary>
        public static int MaxLayer
        {
            get;
            set;
        } = 100;

        private enum Status
        {
            wantStart,
            wantName,
            wantColon,
            wantValue,
            wantCommaOrEnd,
            End
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static dynamic Parse(string str) => Parse(str, null);

        /// <summary>
        /// Parse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Parse<T>(string str)
        {
            var result = Parse(str, typeof(T));
            return result ?? default(T);
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static dynamic Parse(string str, Type type)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            unsafe
            {
                fixed (char* ptr = str)
                {
                    int index = 0;
                    int length = str.Length;
                    var r = 0;
                    var result = ParseValue(ptr, ref index, length, type, ref r);
                    if (index != length)
                    {
                        char c = *(ptr + index);
                        while (char.IsWhiteSpace(c))
                        {
                            index++;
                            c = *(ptr + index);
                        }
                        if (index != length - 1)
                        {
                            Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                        }
                    }
                    return result;
                }
            }
        }

        private static unsafe object ParseValue(char* ptr, ref int index, int length, Type type, ref int r)
        {
            if (r > MaxLayer)
            {
                Warn($@"Error JSON String. Maximum recursion limit.");
                r--;
                return type == null ? null : type.IsValueType ? Activator.CreateInstance(type) : null;
            }
            r++;

            char symbol = '\0';
            var status = Status.wantStart;
            var processer = GetProcesserByType(type);
            string name = null;
            bool hasFirstName = false;

            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                else if (status == Status.wantStart)//起始字符
                {
                    if (c == '{')//object
                    {
                        symbol = c;
                        status = Status.wantName;
                        if (!(processer is IObjectProcesser))
                        {
                            Error("Error Type. Json Object must be parsed to a normal object");
                        }
                    }
                    else if (c == '[')//list
                    {
                        symbol = c;
                        status = Status.wantValue;
                        if (!(processer is IListProcesser))
                        {
                            Error("Error Type. Json Array must be parssed to a IList<> or IList.");
                        }
                    }
                    else if (c == '"')//字符串
                    {
                        if (processer is IStringProcesser stringProcesser)
                        {
                            var val = GetString(ptr, ref index, length);
                            stringProcesser.SetValue(val);
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            Error("Error Type. Json String must be parsed to string or enum");
                        }
                    }
                    else if (c == 't' && length - index >= 4 && *(ptr + index + 1) == 'r' && *(ptr + index + 2) == 'u' && *(ptr + index + 3) == 'e')//true
                    {
                        index += 3;
                        if (processer is IBoolProcesser boolProcesser)
                        {
                            boolProcesser.SetValue(true);
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            Error("Error Type. Json Bool must be parsed to bool");
                        }
                    }
                    else if (c == 'f' && length - index >= 5 && *(ptr + index + 1) == 'a' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 's' && *(ptr + index + 4) == 'e')//false
                    {
                        index += 4;
                        if (processer is IBoolProcesser boolProcesser)
                        {
                            boolProcesser.SetValue(false);
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            Error("Error Type. Json Bool must be parsed to bool");
                        }
                    }
                    else if (c == '-' || (c >= ASCIIChar.Num0 && c <= ASCIIChar.Num9))//decimal
                    {
                        if (processer is INumericProcesser numericProcesser)
                        {
                            numericProcesser.SetValue(GetNumeric(ptr, ref index, length));
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            Error("Error Type. Json Number must be parsed to a numeric type");
                        }
                    }
                    else if (c == 'n' && length - index >= 4 && *(ptr + index + 1) == 'u' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 'l')//null
                    {
                        index += 3;
                        if (processer is INullableProcesser nullableProcesser)
                        {
                            nullableProcesser.SetNull();
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            Error("Error Type. Json Null must be parsed to a nullable object");
                        }
                    }
                    else
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
                else if (status == Status.wantName)//名称
                {
                    if (!hasFirstName && *(ptr + index) == '}')
                    {
                        status = Status.End;
                        break;
                    }
                    if (*(ptr + index) != '"')
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                    else
                    {
                        name = GetString(ptr, ref index, length);
                        status = Status.wantColon;
                    }
                }
                else if (status == Status.wantColon)//冒号
                {
                    if (c == ':')
                    {
                        status = Status.wantValue;
                    }
                    else
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
                else if (status == Status.wantValue)//值
                {
                    if (name != null && processer is IObjectProcesser objectProcesser)
                    {
                        var value = ParseValue(ptr, ref index, length, objectProcesser.GetValueType(name), ref r);
                        objectProcesser.Set(name, value);
                        status = Status.wantCommaOrEnd;
                    }
                    else if (processer is IListProcesser listProcesser)
                    {
                        if (listProcesser.IsListEmpty() && c == ']')
                        {
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            var value = ParseValue(ptr, ref index, length, listProcesser.GetChildType(), ref r);
                            listProcesser.AddChild(value);
                            status = Status.wantCommaOrEnd;
                        }
                    }
                    else
                    {
                        Error("Internal Exception");
                    }
                }
                else if (status == Status.wantCommaOrEnd)
                {
                    if (c == ',')
                    {
                        if (name != null)
                        {
                            status = Status.wantName;
                        }
                        else
                        {
                            status = Status.wantValue;
                        }
                    }
                    else if (symbol == '{' && c == '}')
                    {
                        status = Status.End;
                        break;
                    }
                    else if (symbol == '[' && c == ']')
                    {
                        status = Status.End;
                        break;
                    }
                    else
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
            }
            if (status != Status.End)
            {
                Error($@"Error JSON String. Not Complete.");
            }
            r--;
            return processer.GetResult();
        }

        internal static IProcesser GetProcesserByType(Type type)
        {
            IProcesser processer;
            if (type != null)
            {
                if (type.IsNumeric())
                {
                    processer = new NumericProcesser(type);
                }
                else if (type == typeof(bool))
                {
                    processer = new BoolProcesser();
                }
                else if (type == typeof(string))
                {
                    processer = new StringProcesser();
                }
                else if (type.IsDictionary())
                {
                    processer = new DictionaryProcesser(type);
                }
                else if (type.IsList())
                {
                    processer = new ListProcesser(type);
                }
                else if (type.IsEnum)
                {
                    processer = new EnumProcesser(type);
                }
                else if (type.IsValueType)
                {
                    processer = new StructProcesser(type);
                }
                else
                {
                    processer = new ObjectProcesser(type);
                }
            }
            else
            {
                processer = new DynamicProcesser();
            }

            return processer;
        }

        private static unsafe string GetString(char* ptr, ref int index, int length)
        {
            if (*(ptr + index) != '"')
            {
                Error("Internal Error");
            }
            index++;
            var sb = new StringBuilder();
            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (c == '"')
                {
                    return sb.ToString();
                }
                else if (c == '\\')
                {
                    index++;
                    if (index >= length)
                    {
                        break;
                    }
                    c = *(ptr + index);
                    if (c == '"' || c == '\\' || c == '/')
                    {
                        sb.Append(c);
                    }
                    else if (c == 'b')
                    {
                        sb.Append('\b');
                    }
                    else if (c == 'f')
                    {
                        sb.Append('\f');
                    }
                    else if (c == 'n')
                    {
                        sb.Append('\n');
                    }
                    else if (c == 'r')
                    {
                        sb.Append('\r');
                    }
                    else if (c == 't')
                    {
                        sb.Append('\t');
                    }
                    else if (c == 'u')
                    {
                        index += 4;
                        if (index >= length)
                        {
                            break;
                        }
                        var x = "" + *(ptr + index - 3) + *(ptr + index - 2) + *(ptr + index - 1) + *(ptr + index);
                        if (int.TryParse(x, NumberStyles.AllowHexSpecifier, null, out int result))
                        {
                            sb.Append((char)result);
                        }
                        else
                        {
                            Error($"Error JSON string. Index = {index}");
                        }
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            Error("Error JSON String. Not Complete.");
        }

        private static unsafe object GetNumeric(char* ptr, ref int index, int length)
        {
            bool hasDot = false;
            bool hasNumber = false;
            int start = index;
            var sb = new StringBuilder();
            while (index < length)
            {
                var c = *(ptr + index);
                if (c == '.')
                {
                    if (hasNumber && !hasDot)
                    {
                        sb.Append(c);
                        index++;
                    }
                    else
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
                else if (c >= '0' && c <= '9')
                {
                    sb.Append(c);
                    hasNumber = true;
                    index++;
                }
                else if (c == '-')
                {
                    if (index != start)
                    {
                        Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                    else
                    {
                        sb.Append(c);
                        index++;
                    }
                }
                else
                {
                    break;
                }
            }
            if (!hasNumber)
            {
                Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
            }
            var strVal = sb.ToString();
            index--;
            if (!strVal.Contains("."))
            {
                if (byte.TryParse(strVal, out byte byteVal))
                {
                    return byteVal;
                }
                else if (short.TryParse(strVal, out short shortVal))
                {
                    return shortVal;
                }
                else if (int.TryParse(strVal, out int intVal))
                {
                    return intVal;
                }
                else if (long.TryParse(strVal, out long longVal))
                {
                    return longVal;
                }
                else if (ulong.TryParse(strVal, out ulong ulongVal))
                {
                    return ulongVal;
                }
            }
            if (decimal.TryParse(strVal, out decimal decimalVal))
            {
                return decimalVal;
            }
            else
            {
                Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
            }
        }

        internal static void Warn(string str, Exception exception = null)
        {
            LogProvider.Warn(str);
            if (IsStrict)
            {
                throw new JSONParserException(str, exception);
            }
        }
        internal static void Error(string str, Exception exception = null)
        {
            LogProvider.Error(str);
            throw new JSONParserException(str, exception);
        }
    }
}
