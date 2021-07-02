using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ComboBoxEx
    /// </summary>
    public class ComboBoxEx : BaseControl
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
        public ComboBoxEx(string text, int x, int y, int width, int height, ComboBoxStyles style, ComboBoxExStyles exStyles, HWND parentWindow) : base("ComboBoxEx32", text, x, y, width, height, (uint)style, (uint)exStyles, parentWindow)
        {

        }
    }
}
