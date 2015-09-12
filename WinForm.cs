using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace Lsj.Util
{
	/// <summary>
	/// WinForm������
	/// </summary>
	public static class WinForm
	{
		/// <summary>
		/// ���������쳣
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
			MessageBox.Show(exceptionMsg, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			string exceptionMsg = WinForm.GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
			MessageBox.Show(exceptionMsg, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		private static string GetExceptionMsg(Exception ex, string backStr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("****************************�쳣�ı�****************************");
			stringBuilder.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
			bool flag = ex != null;
			if (flag)
			{
				stringBuilder.AppendLine("���쳣���͡���" + ex.GetType().Name);
				stringBuilder.AppendLine("���쳣��Ϣ����" + ex.Message);
				stringBuilder.AppendLine("����ջ���á���" + ex.StackTrace);
			}
			else
			{
				stringBuilder.AppendLine("��δ�����쳣����" + backStr);
			}
			stringBuilder.AppendLine("***************************************************************");
			return stringBuilder.ToString();
		}
		/// <summary>
		/// MessageBox��ʾ
		/// </summary>
		public static void Notice(string str)
		{
			MessageBox.Show(str);
		}
		/// <summary>
		/// �̶���С
		/// <param name="form">����ʵ��</param>  
		/// </summary>
		public static void FixedSize(this Form form)
		{
			form.MaximizeBox = false;
			form.FormBorderStyle = FormBorderStyle.Fixed3D;
		}
		/// <summary>
		/// ��ͼ
		/// <param name="form">����ʵ��</param>  
		/// <param name="d">PaintEventHandlerί��</param>  
		/// </summary>
		public static void Draw(this Form form, PaintEventHandler d)
		{
			form.Paint += d;
		}
		/// <summary>
		/// ���ڹر��¼�
		/// <param name="form">����ʵ��</param>  
		/// <param name="d">FormClosingEventHandlerί��</param>  
		/// </summary>
		public static void OnClosing(this Form form, FormClosingEventHandler d)
		{
			form.FormClosing += d;
		}
	}
}
