using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Enums.INITCOMMONCONTROLSFlags;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// TreeView
    /// </summary>
    public class TreeView : BaseControl
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
        public TreeView(string text, int x, int y, int width, int height, TreeViewControlStyles style, HWND parentWindow) : base("SysTreeView32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_LINK_CLASS,
            });

    }
}
