using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Lsj.Util
{
	/// <summary>
	/// WinForm辅助类
	/// </summary>
	public static class WinForm
	{
		/// <summary>
		/// 捕获所有异常
		/// </summary>
		public static void CatchAll()
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += new ThreadExceptionEventHandler(WinForm.Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(WinForm.CurrentDomain_UnhandledException);
		}
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			string exceptionMsg = WinForm.GetExceptionMsg(e.Exception, e.ToString());
			MessageBox.Show(exceptionMsg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			string exceptionMsg = WinForm.GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
			MessageBox.Show(exceptionMsg, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		private static string GetExceptionMsg(Exception ex, string backStr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("****************************异常文本****************************");
			stringBuilder.AppendLine("【出现时间】：" + DateTime.Now.ToString());
			bool flag = ex != null;
			if (flag)
			{
				stringBuilder.AppendLine("【异常类型】：" + ex.GetType().Name);
				stringBuilder.AppendLine("【异常信息】：" + ex.Message);
				stringBuilder.AppendLine("【堆栈调用】：" + ex.StackTrace);
			}
			else
			{
				stringBuilder.AppendLine("【未处理异常】：" + backStr);
			}
			stringBuilder.AppendLine("***************************************************************");
			return stringBuilder.ToString();
		}
		/// <summary>
		/// MessageBox提示
		/// </summary>
		public static void Notice(string str)
		{
			MessageBox.Show(str);
		}
		/// <summary>
		/// 固定大小
		/// <param name="form">窗口实例</param>  
		/// </summary>
		public static void FixedSize(this Form form)
		{
			form.MaximizeBox = false;
			form.FormBorderStyle = FormBorderStyle.Fixed3D;
		}
		/// <summary>
		/// 绘图
		/// <param name="form">窗口实例</param>  
		/// <param name="d">PaintEventHandler委托</param>  
		/// </summary>
		public static void Draw(this Form form, PaintEventHandler d)
		{
			form.Paint += d;
		}
		/// <summary>
		/// 窗口关闭事件
		/// <param name="form">窗口实例</param>  
		/// <param name="d">FormClosingEventHandler委托</param>  
		/// </summary>
		public static void OnClosing(this Form form, FormClosingEventHandler d)
		{
			form.FormClosing += d;
		}
	}
}
