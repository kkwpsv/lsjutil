using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// Button
    /// </summary>
    public class Button : BaseControl
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
        /// <param name="identifier"></param>
        public Button(string text, int x, int y, int width, int height, ButtonStyles style, HWND parentWindow, WORD identifier) : base("Button", text, x, y, width, height, (uint)style, parentWindow, hMenu: (nint)identifier)
        {

        }
    }
}
