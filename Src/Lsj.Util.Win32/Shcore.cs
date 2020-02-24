using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.DEVICE_SCALE_FACTOR;

namespace Lsj.Util.Win32
{
	/// <summary>
	/// Shcore.dll
	/// </summary>
	public static class Shcore
	{
		/// <summary>
		/// <para>
		/// Gets the preferred scale factor for a display device.
		/// </para>
		/// <para>
		/// From: https://docs.microsoft.com/zh-cn/windows/win32/api/shellscalingapi/nf-shellscalingapi-getscalefactorfordevice
		/// </para>
		/// </summary>
		/// <param name="deviceType">
		/// The value that indicates the type of the display device.
		/// </param>
		/// <returns>
		/// A value that indicates the scale factor that should be used with the specified <see cref="DISPLAY_DEVICE_TYPE"/>.
		/// </returns>
		/// <remarks>
		/// The default <see cref="DEVICE_SCALE_FACTOR"/> is <see cref="SCALE_100_PERCENT"/>.
		/// Use the scale factor that is returned to scale point values for fonts and pixel values.
		/// </remarks>
		[DllImport("Shcore.dll", CharSet = CharSet.Unicode, EntryPoint = "GetScaleFactorForDevice", SetLastError = true)]
		public static extern DEVICE_SCALE_FACTOR GetScaleFactorForDevice([In]DISPLAY_DEVICE_TYPE deviceType);
	}
}
