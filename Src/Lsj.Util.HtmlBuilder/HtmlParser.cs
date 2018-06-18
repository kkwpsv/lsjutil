using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.Logs;
using Lsj.Util.Text;




namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlParser
    /// </summary>
    public static class HtmlParser
    {
        /// <summary>
        /// ParsePage
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static HtmlPage ParsePage(string str)
        {
            var page = new HtmlPage();
            page = Parse(str) as HtmlPage;
            return page;
        }
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static HtmlNode Parse(string str) => InternalParse(str);

        unsafe static HtmlNode InternalParse(string str)
        {
            HtmlNode root = null;
            var length = str.Length;
            fixed (char* tmp = str)
            {
                var current = tmp;
                root = ParseNode(ref current, tmp + length);
            }
            return root;
        }
        /// <summary>
        /// TotallyShit
        /// </summary>
        /// <param name="current"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        unsafe static HtmlNode ParseNode(ref char* current, char* end)
        {
            HtmlNode node = null;
            char* start = null;//内容的开始
            string key = null;
            bool isNote = false;//是否为注释状态
            bool isParam = false;//是否为参数
            bool isWithoutEnd = false;
            bool isInChildren = false;
            bool isCheckEnd = false;//判断标签结束
            bool inDoctype = false;
            bool isStart = false;
            while (current < end)
            {
                if (isNote)//注释处理
                {
                    if (*current == '-' && *(current + 1) == '-' && *(current + 2) == '>')
                    {
                        current = current + 2;
                        return new HtmlNote(StringHelper.ReadStringFromCharPoint(start + 3, current - start - 5));
                    }
                }
                else
                {
                    if (key == null)//未在标签内
                    {
                        if (inDoctype)//DOCTYPE
                        {
                            if (*current == '>')
                            {
                                inDoctype = false;
                            }
                        }
                        else
                        {
                            if (*current == '<' && !isNote)//开始标签
                            {
                                start = current + 1;
                                isStart = true;
                            }
                            else if (*current == '!' && current == start && *(current + 1) == '-' && *(current + 2) == '-')//注释处理 <!---->
                            {
                                isNote = true;
                                current = current + 2;
                            }
                            else if (isStart && (Char.IsWhiteSpace(*current) || *current == '>'))//结束标签名
                            {
                                key = StringHelper.ReadStringFromCharPoint(start, current - start);
                                if (key != "!DOCTYPE")
                                {
                                    node = GetObject(key);
                                    isWithoutEnd = node is HtmlNodeWithoutEnd;
                                    start = current + 1;
                                    if (*current == '>')
                                    {
                                        isInChildren = true;
                                    }
                                }
                                else
                                {
                                    key = null;
                                    inDoctype = true;
                                }
                            }
                        }

                    }
                    else//在标签内
                    {
                        if (isInChildren)//处理子标签
                        {
                            if (*current == '<')
                            {
                                if (start != current)//中间是否有内容
                                {
                                    var str = StringHelper.ReadStringFromCharPoint(start, current - start);
                                    str = str.Replace("\r", "").Replace("\n", "").Trim();//去除换行及空白
                                    if (str.Length > 0)
                                    {
                                        node.Add(new HtmlRawNode(str));
                                    }
                                }



                                if (*(current + 1) == '/')//处理标签结束
                                {
                                    isCheckEnd = true;
                                    start = current + 2;
                                    current++;
                                }
                                else//处理子标签
                                {
                                    node.Add(ParseNode(ref current, end));
                                    start = current + 1;
                                }
                            }
                            else if (*current == '>' && isCheckEnd)//标签结束
                            {
                                var tmp = StringHelper.ReadStringFromCharPoint(start, current - start);
                                if (tmp == node.Name)
                                {
                                    break;
                                }
                            }
                        }
                        else//处理参数
                        {
                            if (isParam)
                            {
                                if (*current == '"')//结束参数
                                {
                                    var value = StringHelper.ReadStringFromCharPoint(start, current - start);
                                    node.Add(new HtmlParam
                                    {
                                        Name = key,
                                        Value = value
                                    });
                                    isParam = false;
                                }
                            }
                            else
                            {
                                if (*current == ' ')
                                {
                                    start = current + 1;
                                }
                                else if (*current == '>' || (*current == '/' && *(current + 1) == '>' && (current++) != null/*指针加1*/))
                                {
                                    if (isWithoutEnd)//有无结束标签
                                    {
                                        break;//直接返回
                                    }
                                    else
                                    {
                                        isInChildren = true;
                                        start = current + 1;
                                    }
                                }
                                else if (*current == '=' && *(current + 1) == '"')//开始标签内容 ="
                                {
                                    key = StringHelper.ReadStringFromCharPoint(start, current - start).TrimStart();//清除多余空格
                                    isParam = true;
                                    start = current + 2;
                                    current = current + 1;
                                }
                            }
                        }
                    }
                }
                current++;
            }
            return node;
        }

        private static HtmlNode GetObject(string type)
        {
            switch (type)
            {
                case "html":
                    return new HtmlPage();
                case "body":
                    return new Body.Body();
                case "head":
                    return new Head();
                case "meta":
                    return new Meta();
                case "link":
                    return new Link();
                case "base":
                    return new Base();
                case "title":
                    return new Title();
                case "div":
                    return new Div();
                case "section":
                    return new Section();
                case "h1":
                    return new H1();
                case "h2":
                    return new H2();
                case "p":
                    return new P();
                case "a":
                    return new A();
                case "img":
                    return new Img();
                case "input":
                    return new Input();
                case "label":
                    return new Label();


                default:
                    LogProvider.Default.Warn("Unknown type: " + type);
                    return new Unknown(type);
            }
        }


    }
}
