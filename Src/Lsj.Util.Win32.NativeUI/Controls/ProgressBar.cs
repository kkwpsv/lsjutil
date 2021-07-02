using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ProgressBar
    /// </summary>
    public class ProgressBar : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="parentWindow"></param>
        public ProgressBar(string text, int x, int y, int width, int height, ProgressBarStyles style, HWND parentWindow) : base("msctls_progress32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }
    }
}
