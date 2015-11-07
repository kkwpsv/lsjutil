using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using Lsj.Util.Net.Web.Protocol;

namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// MyHttpWebRequest辅助类  基于HttpWebRequest重新封装
    /// </summary>
    public class MyHttpWebRequest
    {
        private HttpWebRequest m_instance;
        private string m_Connection = "";
        private bool m_IsKeepalive = true;
        private string m_Accept = "*/*";
        private string m_ContentType = "application/x-www-form-urlencoded";
        private CookieContainer m_CookieContainer = new MyCookieContainer().Instance;
        private eHttpMethod m_Method = eHttpMethod.GET;
        private int m_Timeout = 100*1000;
        private string m_UserAgent = "LSJ/1.0(compatible,HttpWebRequest)";



        /// <summary>
        /// <value>获取当前HttpWebRequest实例</value>
        /// </summary>
        public HttpWebRequest Instance
        {
            get
            {
                return m_instance;
            }

        }

        /// <summary>
        /// <value>获取请求的URI</value>
        /// </summary>
        public string RequsetUri
        {
            get
            {
                if (m_instance.RequestUri != null)
                    return m_instance.RequestUri.ToString();
                else return "";
            }
        }

        /// <summary>
        /// <value>获取响应请求的URI</value>
        /// </summary>
        public string ResponseUri
        {
            get
            {
                if (m_instance.Address != null)
                    return m_instance.Address.ToString();
                else return "";
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
                if (value.ToLower() == "keep-alive")
                    this.m_IsKeepalive = true;
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
        /// <value>获取 Content-length HTTP 标头</value>
        /// </summary>
        public long ContentLength
        {
            get
            {
                return m_instance.ContentLength;
            }
        }

        /// <summary>
        /// <value>获取 Content-Type HTTP 标头</value>
        /// </summary>
        public string ContentType
        {
            get
            {
                return m_instance.ContentType;
            }
        }

        /// <summary>
        /// <value>获取或设置关联的 cookie</value>
        /// </summary>
        public CookieContainer CookieContainer
        {
            get
            {
                return m_instance.CookieContainer;
            }
        }

        /// <summary>
        /// <value>获取一个值，该值指示是否收到了来自 Internet 资源的响应</value>
        /// </summary>
        public bool HaveResponse
        {
            get
            {
                return m_instance.HaveResponse;
            }
        }

        /// <summary>
        /// <value>获取或设置请求的方法</value>
        /// </summary>
        public eHttpMethod Method
        {
            get
            {
                return this.m_Method;
            }
            set
            {
                this.m_Method = value;
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
        /// 用HttpWebRequest初始化一个新实例
        /// </summary>
        public MyHttpWebRequest(HttpWebRequest instance)
        {
            m_instance = instance;
            this.OnSetThis();
        }

        /// <summary>
        /// 用uri地址初始化一个新实例
        /// </summary>
        public MyHttpWebRequest(string uri)
        {
            this.NewInstance(uri);
        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        public MyHttpWebRequest() : this("")
        {
        }

        /// <summary>
        /// 设置Uri
        /// <param name="uri"> Uri地址</param>  
        /// </summary>
        public void SetUri(string uri)
        {
            this.NewInstance(uri);
        }


        private void NewInstance(string uri)
        {
            if (Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                m_instance = (HttpWebRequest)WebRequest.Create(uri);
                m_instance.Accept = this.m_Accept;
                m_instance.CookieContainer = this.m_CookieContainer;
                m_instance.KeepAlive = this.m_IsKeepalive;
                m_instance.Method = this.m_Method.ToString();
                m_instance.Timeout = this.m_Timeout;
                m_instance.UserAgent = this.m_UserAgent;
            }
        }

        private void OnSetThis()
        {
            if (m_instance != null)
            {
                this.m_Connection = m_instance.Connection;
                this.m_Accept = m_instance.Accept;
                this.m_ContentType = m_instance.ContentType;
                this.m_CookieContainer = m_instance.CookieContainer;
                this.m_IsKeepalive = m_instance.KeepAlive;
                this.m_Method = (eHttpMethod)Enum.Parse(typeof(eHttpMethod),m_instance.Method.ToUpper());
                this.m_Timeout = m_instance.Timeout;
                this.m_UserAgent = m_instance.UserAgent;
            }
        }
        private void OnSetInstance()
        {
            if (m_instance != null)
            {
                m_instance.Accept = this.m_Accept;
                m_instance.ContentType = this.m_ContentType;
                m_instance.CookieContainer = this.m_CookieContainer;
                m_instance.KeepAlive = this.m_IsKeepalive;
                m_instance.Method = this.m_Method.ToString();
                m_instance.Timeout = this.m_Timeout;
                m_instance.UserAgent = this.m_UserAgent;
            }
        }

        /// <summary>
        /// 写POST数据
        /// <param name="request"> Post数据 可以为byte[]、string、Stream</param>  
        /// </summary>
        public void WritePost(object request)
        {
            this.OnSetInstance();

            Stream temp;


            if (request is Stream)
            {
                
                Stream a = (request as Stream);
                m_instance.ContentLength = a.Length;
                temp = m_instance.GetRequestStream();
                a.CopyTo(temp);
                temp.Close();

            }
            else
            {
                if (request is byte[])
                {
                    byte[] byteArray = (request as byte[]);
                    m_instance.ContentLength = byteArray.Length;
                    temp = m_instance.GetRequestStream();
                    temp.Write(byteArray, 0, byteArray.Length);
                    temp.Close();

                }
                else
                {
                    byte[] byteArray = Encoding.Default.GetBytes(request.ToString());
                    m_instance.ContentLength = byteArray.Length;
                    temp = m_instance.GetRequestStream();
                    temp.Write(byteArray, 0, byteArray.Length);
                    temp.Close();

                }


                
            }

            
        }

        /// <summary>
        /// 获取响应的WebResponse
        /// <returns>响应的WebResponse</returns>  
        /// </summary>
        public HttpWebResponse GetResponse()
        {
            if (m_instance != null)
            {
                OnSetInstance();
                return m_instance.GetResponse() as HttpWebResponse;
            }
            throw new Exception("Null Instance");
        }


        /// <summary>
        /// 获取响应的Stream
        /// <returns>响应的Stream</returns>  
        /// </summary>
        public Stream GetResponseStream()
        {
            return new MyHttpWebResponse(this.GetResponse()).GetResponseStream();
        }

        /// <summary>
        /// 获取响应的String
        /// <returns>响应的String</returns>  
        /// </summary>
        public string GetResponseString()
        {
            return new MyHttpWebResponse(this.GetResponse()).GetResponseString();
        }



    }
}
