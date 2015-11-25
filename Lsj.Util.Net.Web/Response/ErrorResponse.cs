using Lsj.Util.HtmlBuilder;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;

using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Net.Web.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class ErrorResponse : HttpResponse
    {
        public ErrorResponse(int code) : base(HttpRequest.NullRequest)
        {
            var ErrorString = GetErrorStringByCode(code);
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
                    new HtmlRawNode($" &nbsp; {Server}")
                }
            );

            this.content = ErrorPage.ToString().ToStringBuilder();
            this.headers.ContentLength = content.ToString().ConvertToBytes(request.headers.AcceptCharset).Length;
            this.status = code;
            this.headers.Connection= eConnectionType.Close;
            this.headers.ContentType = "text/html; charset="+request.headers.AcceptCharset.BodyName;
        }
    }
}
