using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.HtmlBuilder;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.Net.Web.Interfaces;
using Lsj.Util.Net.Web.Message;
using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Static;





namespace Lsj.Util.Net.Web.Error
{
    /// <summary>
    /// Error helper.
    /// </summary>
    public static class ErrorHelper
    {
        /// <summary>
        /// Build
        /// </summary>
        /// <returns></returns>
        /// <param name="code">Code</param>
        /// <param name="extraCode">Extra code</param>
        /// <param name="server">Server</param>
        public static IHttpResponse Build(int code, int extraCode, string server)
        {
            var response = new HttpResponse
            {
                ErrorCode = code
            };
            response.Write(BuildPage(code, extraCode, server));
            response.Headers[HttpHeader.ContentType] = "text/html;charset=utf8";
            response.Headers[HttpHeader.Connection] = "close";
            return response;
        }
        /// <summary>
        /// Build.
        /// </summary>
        /// <returns></returns>
        /// <param name="code">Code</param>
        /// <param name="extraCode">Extra code</param>
        /// <param name="server">Server</param>
        /// <param name="errorString">Error string</param>
        public static IHttpResponse Build(int code, int extraCode, string server, string errorString)
        {
            var response = new HttpResponse
            {
                ErrorCode = code
            };
            response.Write(BuildPage(code, extraCode, server, errorString));
            response.Headers[HttpHeader.ContentType] = "text/html;charset=utf8";
            response.Headers[HttpHeader.Connection] = "close";
            return response;
        }

        /// <summary>
        /// Build page
        /// </summary>
        /// <returns></returns>
        /// <param name="code">Code</param>
        /// <param name="server">Server</param>
        public static string BuildPage(int code, string server) => BuildPage(code, 0, server);
        /// <summary>
        /// Builds page
        /// </summary>
        /// <returns>.</returns>
        /// <param name="code">Code</param>
        /// <param name="extraCode">Extra code</param>
        /// <param name="server">Server</param>
        public static string BuildPage(int code, int extraCode, string server)
        {
            var ErrorString = StatusCode.GetStringByCode(code, extraCode);
            var ErrorPage = new HtmlPage();
            ErrorPage.Head.Add(new Title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.Body.Add(
                new HtmlParam { Name = "bgcolor", Value = "white" }
                );
            ErrorPage.Body.AddRange(
                new List<HtmlNode>
                {
                new Span
                    {
                        new H1
                        {
                            new HtmlRawNode("Server Error."),
                        },
                        new Hr
                        {
                            new HtmlParam { Name = "width", Value = "100%" },
                            new HtmlParam { Name = "size", Value = "1" },
                            new HtmlParam { Name = "color", Value = "silver" }
                        },
                        new H2
                        {
                            new I
                            {
                                new HtmlRawNode($"HTTP Error {code}- {ErrorString}.")
                            }
                        }
                    },
                    new Hr
                    {
                            new HtmlParam { Name = "width", Value = "100%" },
                            new HtmlParam { Name = "size", Value = "1" },
                            new HtmlParam { Name = "color", Value = "silver" }
                    },
                    new B
                    {
                        new HtmlRawNode("Server Information:")
                    },
                    new HtmlRawNode($" &nbsp; {server}")
                }
            );
            return ErrorPage.ToString();
        }


        /// <summary>
        /// Builds the page.
        /// </summary>
        /// <returns>The page.</returns>
        /// <param name="code">Code.</param>
        /// <param name="extracode">Extracode.</param>
        /// <param name="server">Server.</param>
        /// <param name="ErrorString">Error string.</param>
        public static string BuildPage(int code, int extracode, string server, string ErrorString)
        {
            var ErrorPage = new HtmlPage();
            ErrorPage.Head.Add(new Title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.Body.Add(
                new HtmlParam { Name = "bgcolor", Value = "white" }
             );
            ErrorPage.Body.AddRange(
                new List<HtmlNode>
                {
                new Span
                    {
                        new H1
                        {
                            new HtmlRawNode("Server Error."),
                        },
                        new Hr
                        {
                            new HtmlParam { Name = "width", Value = "100%" },
                            new HtmlParam { Name = "size", Value = "1" },
                            new HtmlParam { Name = "color", Value = "silver" }
                        },
                        new H2
                        {
                            new I
                            {
                                new HtmlRawNode($"HTTP Error {code}- {ErrorString}.")
                            }
                        }
                    },
                    new Hr
                    {
                            new HtmlParam { Name = "width", Value = "100%" },
                            new HtmlParam { Name = "size", Value = "1" },
                            new HtmlParam { Name = "color", Value = "silver" }
                    },
                    new B
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
