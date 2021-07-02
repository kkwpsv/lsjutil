using Lsj.Util.Win32.BaseTypes;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// IPAddress
    /// </summary>
    public class IPAddress : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parentWindow"></param>
        public IPAddress(string text, int x, int y, int width, int height, HWND parentWindow) : base("SysIPAddress32", text, x, y, width, height, 0, parentWindow)
        {

        }
    }
}
