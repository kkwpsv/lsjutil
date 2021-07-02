using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// Rebar
    /// </summary>
    public class Rebar : BaseControl
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
        public Rebar(string text, int x, int y, int width, int height, RebarStyles style, HWND parentWindow) : base("ReBarWindow32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }
    }
}
