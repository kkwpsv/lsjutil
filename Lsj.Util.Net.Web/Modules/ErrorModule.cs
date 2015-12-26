using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.Net.Web.Request;
using Lsj.Util.Net.Web.Response;
using Lsj.Util.Net.Web.ActivePages;
using Lsj.Util.Collections;
using Lsj.Util.Net.Web.Website;
using Lsj.Util.HtmlBuilder;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.IO;
using System.IO;
using Lsj.Util.Net.Web.Static;

namespace Lsj.Util.Net.Web.Modules
{
    public class ErrorModule : IModule
    {
        HttpWebsite website;
        string ErrorPagePath;
        public ErrorModule(HttpWebsite website)
        {
            this.website = website;
            this.ErrorPagePath = website.Config!=null?website.Config.ErrorPagePath:"";
        }

        public eModuleType ModuleType => eModuleType.Error;
        public bool CanProcess(HttpRequest request)
        {
            return false;
        }
        public HttpResponse Process(HttpRequest request)
        {
            var code = request.ErrorCode;
            var extracode = request.ExtraErrorCode;
            byte[] result;
            var file = $"{ErrorPagePath}{code}.{extracode}.htm";
            if (file.IsExistsFile())
            {
                result = File.ReadAllBytes(file);
            }
            else
            {
                file = $"{ErrorPagePath}{code}.htm";
                if (file.IsExistsFile())
                {
                    result = File.ReadAllBytes(file);
                }
                else
                {
                    result = BuildPage(code, extracode).ConvertToBytes(Encoding.ASCII);
                }
            }
            var response = new HttpResponse(request);
            response.WriteError(result, code);

            return response;
        }
        internal static string BuildPage(int code,int extracode = 0)
        {
            var ErrorString = SatusCode.GetStringByCode(code,extracode);
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
                    new HtmlRawNode($" &nbsp; {MyHttpWebServer.ServerVersion}")
                }
            );
            return ErrorPage.ToString();
        }
        public static HttpResponse StaticProcess(HttpRequest request)
        {
            var code = request.ErrorCode;
            byte[] result= BuildPage(code).ConvertToBytes(Encoding.ASCII);
             

            var response = new HttpResponse(request);
            response.WriteError(result, code);

            return response;
        }
    }
}
