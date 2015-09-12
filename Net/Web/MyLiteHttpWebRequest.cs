using Lsj.Util.Net.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// MyLiteHttpWebRequest  基于socket实现
    /// </summary>
    public class MyLiteHttpWebRequest
    {
        TcpSocket socket;
        Uri uri;
        IPAddress remoteip;
        int remoteport;
        eHttpMethod m_Method = eHttpMethod.GET;
        string m_Connection = "keep-alive";

        string m_UserAgent = "LSJ/1.0(compatible,LiteHttpWebRequest)";
        string m_Accept = "*/*";
        int m_Timeout = 10 * 1000;
        long m_ContentLength;

        /// <summary>
        /// <value>获取或设置Method 标头的值</value>
        /// </summary>
        public eHttpMethod Method
        {
            set
            {
                   this.Method = value;
            }
            get
            {
                return this.m_Method;
            }
        }

        /// <summary>
        /// <value>获取或设置User-agent HTTP 标头的值</value>
        /// </summary>
        public string UserAgent
        {
            get
            {
                return this.m_UserAgent;
            }
            set
            {
                this.m_UserAgent = value;
            }
        }

        /// <summary>
        /// <value>获取或设置 Accept HTTP 标头的值</value>
        /// </summary>
        public string Accept
        {
            get
            {
                return this.m_Accept;
            }
            set
            {
                this.m_Accept = value;
            }
        }

        /// <summary>
        /// <value>获取或设置 Connection HTTP 标头的值</value>
        /// </summary>
        public string Connection
        {
            get
            {
                return this.m_Connection;
            }
            set
            {
                if (value.ToLower() == "close")
                {
                    throw new Exception("Connection cannot be close");
                    // return;
                }
                else
                    this.m_Connection = value;

            }
        }
        /// <summary>
        /// <value>获取或设置超时值</value>
        /// </summary>
        public int Timeout
        {
            get
            {
                return this.m_Timeout;
            }
            set
            {
                this.m_Timeout = value;
            }
        }

        /// <summary>
        /// <value>获取 Content-length HTTP 标头</value>
        /// </summary>
        public long ContentLength
        {
            get
            {
                return m_ContentLength;
            }
        }



        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        public MyLiteHttpWebRequest()
        {
            this.socket = new TcpSocket();
        }

        /// <summary>
        /// 使用指定uri初始化一个新实例
        /// <param name="uri"> Uri地址</param>
        /// </summary>
        public MyLiteHttpWebRequest(string uri)
        {
            this.socket = new TcpSocket();
            this.SetUri(uri);
        }

        /// <summary>
        /// 设置uri地址
        /// <param name="uri"> Uri地址</param>
        /// </summary>
        public void SetUri(string uri)
        {
            if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                this.uri = new Uri(uri);
                this.remoteip =Dns.GetHostAddresses(this.uri.DnsSafeHost)[0];
                this.remoteport = this.uri.Port;
                
            }
            else throw new Exception("Invaild Uri");
        }

        /// <summary>
        /// 获取响应的Stream
        /// <returns>响应的Stream</returns>  
        /// </summary>
        public Stream GetResponseStream()
        {
            if (this.Method == eHttpMethod.POST)
            {
                throw new Exception("Unsupported Method");
            }
            if (this.remoteip == null || this.remoteport == 0)
            {
                throw new Exception("Not initialized Uri");
            }
            socket.Connect(remoteip, remoteport);
            socket.ReceiveTimeout = Timeout;
            socket.SendTimeout = Timeout;
            if (!socket.Connected)
            {
                throw new Exception("Cannot connect to server");
            }
            socket.Send(this.BuildRequest().ConvertToBytes(Encoding.UTF8));
            byte[] a = new byte[8 * 1024 * 1024];
            int index = 0;
            if (!ReadHeader(ref a,ref index))
            {
                throw new Exception("Error Response");
            }
            if (index == 0)
            {
                throw new Exception("Error Response");
            }
            if (ContentLength == 0)
            {
                for(long t = 0;t<a.LongLength;t++)
                {
                    var z = a[t];
                    if (z == (byte)0)
                    {
                        m_ContentLength = t - index;
                        break;
                    }
                }
            }
            byte[] result = new byte[this.ContentLength];
            Array.Copy(a, index, result, 0, ContentLength);
            //Console.Write(result.LongLength);
            var x = new MemoryStream(result);
            x.SetLength(ContentLength);
            return x;      
        }

        /// <summary>
        /// 获取响应的String
        /// <returns>响应的String</returns>  
        /// </summary>
        public string GetResponseString()
        {
            return new StreamReader(this.GetResponseStream()).ReadToEnd();
        }

        private string BuildRequest()
        {
            var sb = new StringBuilder();
            sb.Append($"{Method.ToString()} {uri.AbsolutePath} HTTP/1.1 \r\n");
            sb.Append($"Host: {uri.DnsSafeHost} \r\n");
            sb.Append($"User-Agent: {this.UserAgent} \r\n");
            sb.Append($"Accept: {this.Accept} \r\n");
            sb.Append($"Accept-Language: zh-CN \r\n");
            sb.Append($"Accept-Encoding: * \r\n");
            sb.Append($"Connection: {this.m_Connection} \r\n");
            sb.Append($"Cookie: \r\n");
            sb.Append($"\r\n");
            Console.Write(sb);
            return sb.ToString();
        }

        private bool ReadHeader(ref byte[] a,ref int index)
        {
            bool result = false;
            socket.Receive(a);
           Console.Write(a.ConvertFromBytes().Substring(0,1000));
            var sb = new StringBuilder();
            if ((char)a[0] != 'H'|| (char)a[1] != 'T'|| (char)a[2] != 'T'|| (char)a[3] != 'P' || (char)a[4] != '/' || (char)a[5] != '1' || (char)a[6] != '.' || (char)a[7] != '1')
            {
                throw new Exception("Error Response");
            }
            char[] status = new char[3];
            status[0] = (char)a[9];
            status[1] = (char)a[10];
            status[2] = (char)a[11];
            string b = new string(status);
            if (b != "200"&&b!="302")
            {
                throw new Exception($"Http Error {b}");
            }
            for (int i = 0; i < a.Length; i++)
            {
                char c = (char)a[i];
                sb.Append(c);

                if (c == '\n' && string.Concat(sb[sb.Length - 4], sb[sb.Length - 3], sb[sb.Length - 2], sb[sb.Length - 1]).Contains("\r\n\r\n"))
                {
                    index = i + 1;
                    result = true;
                    this.SetHeader(sb.ToString());
                    break;
                }
            }


            return result;
        }

        private void SetHeader(string result)
        {
            string[] heads = result.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var head in heads)
            {
                if (head.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                {
                    this.m_ContentLength = long.Parse(head.Substring(15).Trim());
                    
                }
            }
            //Console.Write(m_ContentLength);
        }
    }
}
