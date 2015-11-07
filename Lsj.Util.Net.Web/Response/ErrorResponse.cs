using Lsj.Util.Net.Web.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Web.Response
{
    public class ErrorResponse : HttpResponse
    {
        public ErrorResponse(int code):base(null)
        {
            var ErrorString = GetErrorStringByCode(code);
            var sb = new StringBuilder();
            sb.Append(
$@"<!DOCTYPE html>
<html>
    <head>
        <title>{ErrorString}</title>
    </head>
    <body bgcolor = ""white"" >
        <span>
            <h1> Server Error.<hr width = 100% size = 1 color = silver ></h1>
            <h2> <i> HTTP Error {code}- {ErrorString}.</i></h2>
        </span>
        <hr width = 100% size = 1 color = silver >
        <b> Server Information:</b> &nbsp; {Server}
    </body>
</html>
");
            this.content = sb;
            this.ContentLength = content.ToString().ConvertToBytes(Encoding.UTF8).Length;
            this.status = code;
            this.Connection = eConnectionType.Close;
        }
    }
}
