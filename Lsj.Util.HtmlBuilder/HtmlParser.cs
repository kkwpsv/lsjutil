using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.HtmlBuilder.Body;
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
        unsafe public static HtmlPage ParsePage(string str)
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
        unsafe public static HtmlNode Parse(string str)
        {
            HtmlNode root = null;
            var length = str.Length;
            fixed (char* tmp = str)
            {
                var ptr = tmp;
                var end = ptr + length;
                char* start = null;
                Status status = ;
                while ((long)ptr < (long)end)
                {
                    if (*ptr == '<')
                    {
                        start = ptr;
                    }
                    else if (*ptr == '>' && start != null)
                    {
                        HtmlNode result;
                        status = ParseNode(start,end,out result);


                    }
                    ptr++;
                }
            }
            return root;
        }

        unsafe static Status ParseNode(char* start, char* end,out HtmlNode result)
        {
            HtmlNode node = null;

        }

        public static HtmlNode GetObject(string type)
        {
            switch (type)
            {
                case "html":
                    return new HtmlPage();
                default:
                    LogProvider.Default.Warn("Unknown type: " + type);
                    return new unknown(type);
            }
        }

        enum Status
        {
            Start,
            End,
        }




    }
}
