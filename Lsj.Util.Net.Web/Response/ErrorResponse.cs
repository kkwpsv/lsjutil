using Lsj.Util.HtmlBuilder;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.Net.Web.Headers;
using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class ErrorResponse : HttpResponse
    {
        public ErrorResponse(int code) : base(null)
        {
            var ErrorString = GetErrorStringByCode(code);
            var ErrorPage = new HtmlPage();
            ErrorPage.head.Children.Add(new title
            {
                new HtmlRawNode(ErrorString)
            });
            ErrorPage.body.Param["bgcolor"] = "white";
            ErrorPage.body.Children.AddRange(
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
            this.headers[eHttpResponseHeader.ContentLength] = new IntHeader(content.ToString().ConvertToBytes(Encoding.UTF8).Length);
            this.status = code;
            this.headers[eHttpResponseHeader.Connection] = new ConnectionHeader(eConnectionType.Close);
        }
    }
}
