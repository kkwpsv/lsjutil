using System;
using System.IO;
using System.Net;
using Lsj.Util;
namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// HttpWebResponse辅助类  基于HttpWebResponse重新封装
    /// </summary>
    public class MyHttpWebResponse
	{
		private HttpWebResponse m_instance;
		/// <summary>
		/// <value>获取或设置当前WebResponse实例</value>
		/// </summary>
		public HttpWebResponse Instance
		{
			get
			{
				return this.m_instance;
			}
			set
			{
				this.m_instance = value;
			}
		}
		/// <summary>
		/// 用HttpWebResponse初始化一个新实例
		/// <param name="instance"> HttpWebResponse实例</param>  
		/// </summary>
		public MyHttpWebResponse(HttpWebResponse instance)
		{
			this.m_instance = instance;
		}
		/// <summary>
		/// 用WebResponse初始化一个新实例
		/// <param name="instance"> WebResponse实例</param>  
		/// </summary>
		public MyHttpWebResponse(WebResponse instance)
		{
			this.m_instance = (instance as HttpWebResponse);
		}
		/// <summary>
		/// 获得响应流
		/// </summary>
		public Stream GetResponseStream() => this.m_instance.GetResponseStream();
		/// <summary>
		/// 获得字符串
		/// </summary>
		public string GetResponseString() => this.m_instance.GetResponseStream().ReadFromStream();
	}
}
