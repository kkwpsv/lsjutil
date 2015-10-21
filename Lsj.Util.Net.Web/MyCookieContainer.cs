using System;
using System.Net;
namespace Lsj.Util.Net.Web
{
    /// <summary>
    /// CookieContainer辅助类  基于CookiesContainer重新封装
    /// </summary>
    public class MyCookieContainer
	{
		private CookieContainer m_instance;
		/// <summary>
		/// <value>获取或设置当前CookieContainer实例</value>
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
		/// 初始化一个新实例
		/// </summary>
		public MyCookieContainer()
		{
			this.m_instance = new CookieContainer();
		}
		/// <summary>
		/// 用CookieContainer初始化一个新实例
		/// <param name="instance"> CookieContainer实例</param>  
		/// </summary>
		public MyCookieContainer(CookieContainer instance)
		{
			this.m_instance = instance;
		}
	}
}
