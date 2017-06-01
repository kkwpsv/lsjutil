﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Static
#else
namespace Lsj.Util.Net.Web.Static
#endif
{
    /// <summary>
    /// StatusCode
    /// </summary>
    public static class SatusCode
    {
        /// <summary>
        /// GetStringByCode
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="ExtraCode"></param>
        /// <returns></returns>
        public static string GetStringByCode(int StatusCode,int ExtraCode = 0)
        {
            switch (StatusCode)
            {
                //Information
                case 100:
                    return "Continue";
                case 101:
                    return "Switching Protocols";
                //Success
                case 200:
                    return "OK";
                case 201:
                    return "Created";
                case 202:
                    return "Accepted";
                case 203:
                    return "Non -Authoritative Information";
                case 204:
                    return "No Content";
                case 205:
                    return "Reset Content";
                case 206:
                    return "Partial Content";
                //Rediction
                case 300:
                    return "Multiple Choices";
                case 301:
                    return "Moved Permanently";
                case 302:
                    return "Found";
                case 303:
                    return "See Other";
                case 304:
                    return "Not Modified";
                case 305:
                    return "Use Proxy";
                case 307:
                    return "Temporary Redirect";
                //ClientError
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 402:
                    return "Payment Required";
                case 403:
                    switch (ExtraCode)
                    {
                        case 9:
                            return "Too Many Users Are Connected";
                        default:
                            return "Forbidden";
                    }
                case 404:
                    return "Not Found";
                case 405:
                    return "Method Not Allowed";
                case 406:
                    return "Not Acceptable";
                case 407:
                    return "Proxy Authentication Required";
                case 408:
                    return "Request Timeout";
                case 409:
                    return "Conflict";
                case 410:
                    return "Gone";
                case 411:
                    return "Length Required";
                case 412:
                    return "Precondition Failed";
                case 413:
                    return "Request Entity Too Large ";
                case 414:
                    return "Request URI Too Long";
                case 415:
                    return "Unsupported Media Type";
                case 416:
                    return "Requested Range Not Satisfiable";
                case 417:
                    return "Expectation Failed";
                //Server Error
                case 500:
                    return "Internal Server Error";
                case 501:
                    return "Not Implemented";
                case 502:
                    return "Bad Gateway";
                case 503:
                    return "Service Unavailable";
                case 504:
                    return "Gateway Time-out";
                case 505:
                    return "HTTP Version not supported";
                default:
                    Logs.LogProvider.Default.Warn($"Try Get Unknown StatusCode {StatusCode}{(ExtraCode == 0 ? "" : ExtraCode.ToString())}");
                    return "UnKnown";
            }
        }
    }
}
