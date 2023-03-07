using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        /// <param name="styleEx"></param>
        /// <param name="hMenu"></param>
        protected BaseControl(string className, string text, int x, int y, int width, int height, uint style, HWND parentWindow, uint styleEx = 0, HMENU hMenu = default) : base(className, text, false, x, y, width, height, (WindowStyles)style, (WindowStylesEx)styleEx, parentWindow, hMenu)
        {

        }

        /// <inheritdoc/>
        protected override HWND CreateWindowImpl(string windowClassName, string windowText, int x, int y, int width, int height, uint style, uint styleEx, HWND parentWindow, HMENU hMenu, HINSTANCE hInstance)
        {
            if (!_hasInit.TryGetValue(GetType(), out var val) || !val)
            {
                _hasInit[GetType()] = Init();
            }
            if (_hasInit[GetType()])
            {
                return base.CreateWindowImpl(windowClassName, windowText, x, y, width, height, (uint)WS_CHILD | style, styleEx, parentWindow, hMenu, hInstance);
            }
            else
            {
                return NULL;
            }
        }

        private static IDictionary<Type, bool> _hasInit = new ConcurrentDictionary<Type, bool>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual bool Init() => true;
    }
}
