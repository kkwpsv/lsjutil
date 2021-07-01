using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowStyles;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// Base Control
    /// </summary>
    public abstract class BaseControl : Win32Window
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="parentWindow"></param>
        protected BaseControl(string className, string text, int x, int y, int width, int height, uint style, HWND parentWindow) : base(className, text, false, x, y, width, height, (WindowStyles)style, 0, parentWindow)
        {

        }

        /// <summary>
        /// No used
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected override sealed LRESULT WindowProc(HWND hWnd, WindowsMessages msg, WPARAM wParam, LPARAM lParam)
        {
            //No used
            return NULL;
        }

        /// <inheritdoc/>
        protected override HWND CreateWindowImpl(string windowClassName, string windowText, int x, int y, int width, int height, uint style, uint styleEx, HWND parentWindow, HINSTANCE hInstance)
            => base.CreateWindowImpl(windowClassName, windowText, x, y, width, height, (uint)WS_CHILD | style, styleEx, parentWindow, hInstance);
    }
}
