using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Formater
    /// </summary>
    public static class JSONFormater
    {
        /// <summary>
        /// Format
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Format(string str)
        {
            var sb = new StringBuilder();
            var stack = new Stack<char>();
            string blank = "  ";
            int x = 0;
            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c == '{' || c == '[')
                {
                    x++;
                    stack.Push(c);
                    sb.Append(c);
                    sb.AppendLine();
                    for (int j = 0; j < x; j++)
                    {
                        sb.Append(blank);
                    }
                }
                else if (c == '}')
                {
                    x--;
                    sb.AppendLine();
                    for (int j = 0; j < x; j++)
                    {
                        sb.Append(blank);
                    }
                    sb.Append(c);
                    if (stack.Pop() != '{')
                    {
                        throw new InvalidDataException();
                    }
                }
                else if (c == ']')
                {
                    x--;
                    sb.AppendLine();
                    for (int j = 0; j < x; j++)
                    {
                        sb.Append(blank);
                    }
                    sb.Append(c);
                    if (stack.Pop() != '[')
                    {
                        throw new InvalidDataException();
                    }
                }
                else if (c == ',')
                {
                    sb.Append(c);
                    sb.AppendLine();
                    for (int j = 0; j < x; j++)
                    {
                        sb.Append(blank);
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Format Json
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatJson(this string str) => Format(str);
    }
}
