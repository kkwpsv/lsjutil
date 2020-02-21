using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Structs.HRESULT;

namespace Lsj.Util.Win32
{
	/// <summary>
	/// Shell32.dll
	/// </summary>
	public static class Shell32
	{
		/// <summary>
		/// <para>
		/// Retrieves the application-defined, explicit Application User Model ID (AppUserModelID) for the current process.
		/// </para>
		/// <para>
		/// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shobjidl_core/nf-shobjidl_core-getcurrentprocessexplicitappusermodelid
		/// </para>
		/// </summary>
		/// <param name="AppID">
		/// A pointer that receives the address of the AppUserModelID assigned to the process.
		/// The caller is responsible for freeing this string with <see cref="CoTaskMemFree"/> when it is no longer needed.
		/// </param>
		/// <returns>
		/// If this function succeeds, it returns <see cref="S_OK"/>.
		/// Otherwise, it returns an <see cref="HRESULT"/> error code.
		/// </returns>
		/// <remarks>
		/// The AppUserModelID retrieved by this function was set earlier through <see cref="SetCurrentProcessExplicitAppUserModelID"/>.
		/// An application can only retrieve an AppUserModelID that has been explicitly set. System-assigned default AppUserModelIDs cannot be retrieved.
		/// If the application requires knowledge of its AppUserModelID it should set one explicitly.
		/// </remarks>
		[DllImport("Shell32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetCurrentProcessExplicitAppUserModelID", SetLastError = true)]
		public static extern HRESULT GetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)][Out]string AppID);
	}
}
