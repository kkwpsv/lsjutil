using Lsj.Util.HtmlBuilder;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Error
{
    /// <summary>
    /// 
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="extracode"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static IHttpResponse Build(int code, int extracode, string server)
        {
            var response = new HttpResponse();
            response.ErrorCode = code;
            response.Write(BuildPage(code, extracode, server));
            response.Headers[eHttpHeader.ContentType] = "text/html;charset=utf8";
            response.Headers[eHttpHeader.Connection] = "close";
            return response;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="extracode"></param>
        /// <param name="server"></param>
        /// <param name="errorstring"></param>
        /// <returns></returns>
        public static IHttpResponse Build(int code, int extracode, string server, string errorstring)
        {
            var response = new HttpResponse();
            response.ErrorCode = code;
            response.Write(BuildPage(code, extracode, server, errorstring));
            response.Headers[eHttpHeader.ContentType] = "text/html;charset=utf8";
            response.Headers[eHttpHeader.Connection] = "close";
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static string BuildPage(int code, string server) => BuildPage(code, 0, server);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="extracode"></param>
        /// <param name="server"></param>
        /// <returns></returns>
        public static string BuildPage(int code, int extracode, string server)
        {
            var ErrorString = SatusCode.GetStringByCode(code, extracode);
            var ErrorPage = new HtmlPage();
            ErrorPage.head.Add(new title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.body.Add(
                new HtmlParam { name = "bgcolor", value = "white" }
                );
            ErrorPage.body.AddRange(
                new List<HtmlNode>
                {
                new span
                    {
                        new h1
                        {
                            new HtmlRawNode("Server Error."),
                        },
                        new hr
                        {
                            new HtmlParam { name = "width", value = "100%" },
                            new HtmlParam { name = "size", value = "1" },
                            new HtmlParam { name = "color", value = "silver" }
                        },
                        new h2
                        {
                            new i
                            {
                                new HtmlRawNode($"HTTP Error {code}- {ErrorString}.")
                            }
                        }
                    },
                    new hr
                    {
                            new HtmlParam { name = "width", value = "100%" },
                            new HtmlParam { name = "size", value = "1" },
                            new HtmlParam { name = "color", value = "silver" }
                    },
                    new b
                    {
                        new HtmlRawNode("Server Information:")
                    },
                    new HtmlRawNode($" &nbsp; {server}")
                }
            );
            return ErrorPage.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="extracode"></param>
        /// <param name="server"></param>
        /// <param name="ErrorString"></param>
        /// <returns></returns>
        public static string BuildPage(int code, int extracode, string server, string ErrorString)
        {
            var ErrorPage = new HtmlPage();
            ErrorPage.head.Add(new title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.body.Add(
                new HtmlParam { name = "bgcolor", value = "white" }
             );
            ErrorPage.body.AddRange(
                new List<HtmlNode>
                {
                new span
                    {
                        new h1
                        {
                            new HtmlRawNode("Server Error."),
                        },
                        new hr
                        {
                            new HtmlParam { name = "width", value = "100%" },
                            new HtmlParam { name = "size", value = "1" },
                            new HtmlParam { name = "color", value = "silver" }
                        },
                        new h2
                        {
                            new i
                            {
                                new HtmlRawNode($"HTTP Error {code}- {ErrorString}.")
                            }
                        }
                    },
                    new hr
                    {
                            new HtmlParam { name = "width", value = "100%" },
                            new HtmlParam { name = "size", value = "1" },
                            new HtmlParam { name = "color", value = "silver" }
                    },
                    new b
                    {
                        new HtmlRawNode("Server Information:")
                    },
                    new HtmlRawNode($" &nbsp; {server}")
                }
            );
            return ErrorPage.ToString();
        }

    }
}
