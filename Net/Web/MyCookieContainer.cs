using System;
using System.Net;
namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// CookieContainer������  ����CookiesContainer���·�װ
    /// </summary>
    public class MyCookieContainer
	{
		private CookieContainer m_instance;
		/// <summary>
		/// <value>��ȡ�����õ�ǰCookieContainerʵ��</value>
		/// </summary>
		public CookieContainer Instance
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
		/// ��ʼ��һ����ʵ��
		/// </summary>
		public MyCookieContainer()
		{
			this.m_instance = new CookieContainer();
		}
		/// <summary>
		/// ��CookieContainer��ʼ��һ����ʵ��
		/// <param name="instance"> CookieContainerʵ��</param>  
		/// </summary>
		public MyCookieContainer(CookieContainer instance)
		{
			this.m_instance = instance;
		}
	}
}
