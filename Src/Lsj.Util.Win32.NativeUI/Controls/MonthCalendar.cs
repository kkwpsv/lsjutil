using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Comctl32;
using static Lsj.Util.Win32.Enums.INITCOMMONCONTROLSFlags;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// MonthCalendar
    /// </summary>
    public class MonthCalendar : BaseControl
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
        public MonthCalendar(string text, int x, int y, int width, int height, MonthCalendarStyles style, HWND parentWindow) : base("SysMonthCal32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_DATE_CLASSES,
            });
    }
}
