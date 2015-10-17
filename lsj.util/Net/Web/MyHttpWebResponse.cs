using System;
using System.IO;
using System.Net;
using Lsj.Util;
namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// HttpWebResponse������  ����HttpWebResponse���·�װ
    /// </summary>
    public class MyHttpWebResponse
	{
		private HttpWebResponse m_instance;
		/// <summary>
		/// <value>��ȡ�����õ�ǰWebResponseʵ��</value>
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
		/// ��HttpWebResponse��ʼ��һ����ʵ��
		/// <param name="instance"> HttpWebResponseʵ��</param>  
		/// </summary>
		public MyHttpWebResponse(HttpWebResponse instance)
		{
			this.m_instance = instance;
		}
		/// <summary>
		/// ��WebResponse��ʼ��һ����ʵ��
		/// <param name="instance"> WebResponseʵ��</param>  
		/// </summary>
		public MyHttpWebResponse(WebResponse instance)
		{
			this.m_instance = (instance as HttpWebResponse);
		}
		/// <summary>
		/// �����Ӧ��
		/// </summary>
		public Stream GetResponseStream() => this.m_instance.GetResponseStream();
		/// <summary>
		/// ����ַ���
		/// </summary>
		public string GetResponseString() => this.m_instance.GetResponseStream().ReadFromStream();
	}
}
