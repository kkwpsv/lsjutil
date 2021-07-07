using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// RichEdit
    /// </summary>
    public class RichEdit : BaseControl
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
        public RichEdit(string text, int x, int y, int width, int height, RichEditControlStyles style, HWND parentWindow) : base("RICHEDIT50W", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() => LoadLibrary("Msftedit.dll") != NULL;
    }
}
