﻿using Lsj.Util.HtmlBuilder;
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
    internal static class ErrorMgr
    {

        internal static IHttpResponse Build(int code, int extracode)
        {
            var response = new HttpResponse();
            response.ErrorCode = code;
            response.Write(BuildPage(code));
            response.Headers[eHttpHeader.ContentType] = "text/html;charset=utf8";
            return response;
        }



        internal static string BuildPage(int code) => BuildPage(code, 0);
        internal static string BuildPage(int code, int extracode)
        {
            var ErrorString = SatusCode.GetStringByCode(code, extracode);
            var ErrorPage = new HtmlPage();
            ErrorPage.head.Add(new title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.body.Param["bgcolor"] = "white";
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
                            Param = new HtmlParam
                            {
                                { "width","100%" },
                                { "size","1" },
                                { "color","silver" },
                            }
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
                        Param = new HtmlParam
                                {
                                    { "width","100%" },
                                    { "size","1" },
                                    { "color","silver" },
                                }
                    },
                    new b
                    {
                        new HtmlRawNode("Server Information:")
                    },
                    new HtmlRawNode($" &nbsp; WebServer(1.0)")
                }
            );
            return ErrorPage.ToString();
        }

    }
}
