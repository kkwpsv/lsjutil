using Lsj.Util.JSON.Processer;
using Lsj.Util.JSON.Processer.Interfaces;
using Lsj.Util.Logs;
using Lsj.Util.Reflection;
using Lsj.Util.Text;
using System;
using System.Globalization;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Parser
    /// </summary>
    public class JSONParser
    {
        /// <summary>
        /// LogProvider
        /// </summary>
        public LogProvider LogProvider
        {
            get;
            set;
        } = LogProvider.Default;

        /// <summary>
        /// Settings
        /// </summary>
        public JSONParserSettings Settings { get; } = new JSONParserSettings();

        /// <summary>
        /// Is Last Parse Complete
        /// </summary>
        public bool IsLastParseComplete { get; private set; }

        private enum Status
        {
            WantStart,
            WantName,
            WantColon,
            WantValue,
            WantCommaOrEnd,
            End
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public dynamic? Parse(string? str) => Parse(str, null);

        /// <summary>
        /// Parse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public T? Parse<T>(string? str)
        {
            var result = Parse(str, typeof(T));
            return result ?? default(T);
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str">the string</param>
        /// <param name="type">type, dynamic if null</param>
        /// <returns></returns>
        public dynamic? Parse(string? str, Type? type)
        {
            if (str.IsNullOrEmpty())
            {
                IsLastParseComplete = true;
                return null;
            }
            IsLastParseComplete = false;
            unsafe
            {
                fixed (char* ptr = str)
                {
                    int index = 0;
                    int length = str!.Length;
                    var r = 0;
                    var result = ParseValue(ptr, ref index, length, type, ref r, out var isComplete);
                    IsLastParseComplete = isComplete;
                    index++;
                    if (index < length)
                    {
                        char c = *(ptr + index);
                        while (char.IsWhiteSpace(c))
                        {
                            index++;
                            c = *(ptr + index);
                        }

                        if (index != length)
                        {
                            throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                        }
                    }
                    return result;
                }
            }
        }

        private unsafe object? ParseValue(char* ptr, ref int index, int length, Type? type, ref int r, out bool isComplete)
        {
            if (r > Settings.MaxLayer)
            {
                throw Error($@"Error JSON String. Maximum recursion limit.");
            }
            r++;

            char symbol = '\0';
            var status = Status.WantStart;
            var processer = GetProcesserByType(type);
            string? name = null;
            bool hasFirstName = false;

            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                else if (status == Status.WantStart)//起始字符
                {
                    if (c == '{')//object
                    {
                        symbol = c;
                        status = Status.WantName;
                        if (processer is not IObjectProcesser)
                        {
                            throw Error("Error Type. Json Object must be parsed to a normal object");
                        }
                        else if (processer is DynamicProcesser dynamicProcesser)
                        {
                            dynamicProcesser.SetEmptyObject();
                        }
                        continue;
                    }
                    else if (c == '[')//list
                    {
                        symbol = c;
                        status = Status.WantValue;
                        if (processer is not IListProcesser)
                        {
                            throw Error("Error Type. Json Array must be parsed to a IList<> or IList.");
                        }
                        else if (processer is DynamicProcesser dynamicProcesser)
                        {
                            dynamicProcesser.SetEmptyList();
                        }
                        continue;
                    }
                    else if (c == '"')//字符串
                    {
                        if (processer is IStringProcesser stringProcesser)
                        {
                            var val = GetString(ptr, ref index, length, out var isStringComplete);
                            stringProcesser.SetValue(val);
                            if (!isStringComplete)
                            {
                                isComplete = false;
                                return processer.GetResult();
                            }
                            status = Status.End;
                            break;
                        }
                        else
                        {
                            throw Error("Error Type. Json String must be parsed to string or enum");
                        }
                    }
                    else if (c == 't')//true
                    {
                        if (Settings.AllowPartial)
                        {
                            if (index + 1 < length)
                            {
                                if (*(ptr + index + 1) == 'r')
                                {
                                    index++;
                                    if (index + 1 < length)
                                    {
                                        if (*(ptr + index + 1) == 'u')
                                        {
                                            index++;
                                            if (index + 1 < length)
                                            {
                                                if (*(ptr + index + 1) == 'e')
                                                {
                                                    index++;
                                                    status = Status.End;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (processer is IBoolProcesser boolProcesser)
                            {
                                boolProcesser.SetValue(true);
                                break;
                            }
                            else
                            {
                                throw Error("Error Type. Json Bool must be parsed to bool");
                            }
                        }
                        else if (length - index >= 4)
                        {
                            if (*(ptr + index + 1) == 'r' && *(ptr + index + 2) == 'u' && *(ptr + index + 3) == 'e')
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
                                    throw Error("Error Type. Json Bool must be parsed to bool");
                                }
                            }
                        }
                    }
                    else if (c == 'f')//false
                    {
                        if (Settings.AllowPartial)
                        {
                            if (index + 1 < length)
                            {
                                if (*(ptr + index + 1) == 'a')
                                {
                                    index++;
                                    if (index + 1 < length)
                                    {
                                        if (*(ptr + index + 1) == 'l')
                                        {
                                            index++;
                                            if (index + 1 < length)
                                            {
                                                if (*(ptr + index + 1) == 's')
                                                {
                                                    index++;
                                                    if (index + 1 < length)
                                                    {
                                                        if (*(ptr + index + 1) == 'e')
                                                        {
                                                            index++;
                                                            status = Status.End;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (processer is IBoolProcesser boolProcesser)
                            {
                                boolProcesser.SetValue(false);
                                break;
                            }
                            else
                            {
                                throw Error("Error Type. Json Bool must be parsed to bool");
                            }
                        }
                        else if (length - index >= 5)
                        {
                            if (*(ptr + index + 1) == 'a' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 's' && *(ptr + index + 4) == 'e')
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
                                    throw Error("Error Type. Json Bool must be parsed to bool");
                                }
                            }
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
                            throw Error("Error Type. Json Number must be parsed to a numeric type");
                        }
                    }
                    else if (c == 'n')//null
                    {
                        if (Settings.AllowPartial)
                        {
                            if (index + 1 < length)
                            {
                                if (*(ptr + index + 1) == 'u')
                                {
                                    index++;
                                    if (index + 1 < length)
                                    {
                                        if (*(ptr + index + 1) == 'l')
                                        {
                                            index++;
                                            if (index + 1 < length)
                                            {
                                                if (*(ptr + index + 1) == 'l')
                                                {
                                                    index++;
                                                    status = Status.End;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (processer is INullableProcesser nullableProcesser)
                            {
                                nullableProcesser.SetNull();
                                break;
                            }
                            else
                            {
                                throw Error("Error Type. Json Null must be parsed to a nullable object");
                            }
                        }
                        else if (length - index >= 4)
                        {
                            if (*(ptr + index + 1) == 'u' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 'l')
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
                                    throw Error("Error Type. Json Null must be parsed to a nullable object");
                                }
                            }
                        }
                    }

                    throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                }
                else if (status == Status.WantName)//字段名称
                {
                    if (!hasFirstName && *(ptr + index) == '}')
                    {
                        status = Status.End;
                        break;
                    }
                    if (*(ptr + index) != '"')
                    {
                        throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                    else
                    {
                        name = GetString(ptr, ref index, length, out var isNameComplete);
                        if (!isNameComplete)
                        {
                            isComplete = false;
                            return processer.GetResult();
                        }
                        status = Status.WantColon;
                    }
                }
                else if (status == Status.WantColon)//冒号
                {
                    if (c == ':')
                    {
                        status = Status.WantValue;
                    }
                    else
                    {
                        throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
                else if (status == Status.WantValue)//值
                {
                    if (name != null && processer is IObjectProcesser objectProcesser)
                    {
                        var value = ParseValue(ptr, ref index, length, objectProcesser.GetValueType(name), ref r, out var isObjectComplete);
                        objectProcesser.Set(name, value);
                        status = Status.WantCommaOrEnd;
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
                            var value = ParseValue(ptr, ref index, length, listProcesser.GetChildType(), ref r, out var isObjectComplete);
                            listProcesser.AddChild(value);
                            status = Status.WantCommaOrEnd;
                        }
                    }
                    else
                    {
                        throw Error("Internal Exception");
                    }
                }
                else if (status == Status.WantCommaOrEnd)
                {
                    if (c == ',')
                    {
                        if (name != null)
                        {
                            status = Status.WantName;
                        }
                        else
                        {
                            status = Status.WantValue;
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
                        throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
                    }
                }
            }
            isComplete = status == Status.End;
            if (status != Status.End && !Settings.AllowPartial)
            {
                throw Error($@"Error JSON String. Not Complete.");
            }
            r--;
            return processer.GetResult();
        }

        internal IProcesser GetProcesserByType(Type? type)
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
                    processer = new BoolProcesser(this);
                }
                else if (type == typeof(string))
                {
                    processer = new StringProcesser();
                }
                else if (type.IsDictionary())
                {
                    processer = new DictionaryProcesser(this, type);
                }
                else if (type.IsList())
                {
                    processer = new ListProcesser(this, type);
                }
                else if (type.IsEnum)
                {
                    processer = new EnumProcesser(this, type);
                }
                else if (type.IsValueType)
                {
                    processer = new StructProcesser(this, type);
                }
                else
                {
                    processer = new ObjectProcesser(this, type);
                }
            }
            else
            {
                processer = new DynamicProcesser(this);
            }

            return processer;
        }

        private unsafe string GetString(char* ptr, ref int index, int length, out bool isComplete)
        {
            if (*(ptr + index) != '"')
            {
                throw Error("Internal Error");
            }
            index++;
            var sb = new StringBuilder();
            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (c == '"')
                {
                    isComplete = true;
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
                            throw Error($"Error JSON string. Index = {index}");
                        }
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            if (!Settings.AllowPartial)
            {
                throw Error("Error JSON String. Not Complete.");
            }
            else
            {
                isComplete = false;
                return sb.ToString();
            }
        }

        private unsafe object GetNumeric(char* ptr, ref int index, int length)
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
                        throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
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
                        throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
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
                throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
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
                throw Error($"Error JSON string. Index = {index}. Error char is {*(ptr + index)}. Surrounding is {StringHelper.GetSurroundingChars(ptr, length, index, 5)}");
            }
        }

        internal void Debug(string str)
        {
            LogProvider.Debug(str);
        }
        internal void Warn(string str)
        {
            LogProvider.Warn(str);
        }
        internal Exception Error(string str, Exception? exception = null)
        {
            LogProvider.Error(str);
            throw new JSONParserException(str, exception);
        }
    }
}
