using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ListView
    /// </summary>
    public class ListView : BaseControl
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
        public ListView(string text, int x, int y, int width, int height, ListViewStyles style, HWND parentWindow) : base("SysListView32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }
    }
}
